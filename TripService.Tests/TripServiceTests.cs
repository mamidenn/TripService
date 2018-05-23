using NUnit.Framework;
using NSubstitute;
using TripService.Exceptions;

namespace TripService.Tests
{
    [TestFixture]
    public class TripServiceTests
    {
        private static readonly User DefaultUser = new User();
        private static readonly User LoggedOutUser = null;
        private static readonly User LoggedInUser = new User();
        private static readonly Trip ParisTrip = new Trip();
        private static readonly Trip LondonTrip = new Trip();

        private static readonly User UserWithTrips = new UserBuilder()
            .WithTrips(ParisTrip, LondonTrip)
            .WithFriends(DefaultUser)
            .Build();

        [Test]
        public void GetTripsByUser_NotLoggedIn_ThrowsException()
        {
            var userSession = Substitute.For<IGetsLoggedInUser>();
            userSession.GetLoggedUser().Returns(LoggedOutUser);
            var tripService = new TripService(userSession, new TripRepository());

            Assert.Throws<UserNotLoggedInException>(() =>
            {
                tripService.GetTripsByUser(DefaultUser);
            });
        }

        [Test]
        public void GetTripsByUser_NotFriends_ReturnsEmptyList()
        {
            var userSession = Substitute.For<IGetsLoggedInUser>();
            userSession.GetLoggedUser().Returns(LoggedInUser);
            var tripService = new TripService(userSession, new TripRepository());

            Assert.IsEmpty(tripService.GetTripsByUser(UserWithTrips));
        }

        [Test]
        public void GetTripsByUser_IsFriend_ReturnsTrips()
        {
            var userSession = Substitute.For<IGetsLoggedInUser>();
            userSession.GetLoggedUser().Returns(DefaultUser);

            var tripRepository = Substitute.For<IGetsTrips>();
            tripRepository.GetTripsByUser(UserWithTrips).Returns(UserWithTrips.Trips);

            var tripService = new TripService(userSession, tripRepository);

            Assert.AreSame(UserWithTrips.Trips, tripService.GetTripsByUser(UserWithTrips));
        }
    }
}