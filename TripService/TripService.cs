using System.Collections.Generic;
using JetBrains.Annotations;
using TripService.Exceptions;

namespace TripService
{
    public class TripService
    {
        private readonly IGetsLoggedInUser _userSession;
        private readonly IGetsTrips _tripRepository;

        public TripService(IGetsLoggedInUser userSession, IGetsTrips tripRepository)
        {
            _userSession = userSession;
            _tripRepository = tripRepository;
        }

        [PublicAPI]
        public IEnumerable<Trip> GetTripsByUser(User user)
        {
            IEnumerable<Trip> tripList = new List<Trip>();
            User loggedUser = _userSession.GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach (User friend in user.Friends)
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    tripList = _tripRepository.GetTripsByUser(user);
                }

                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }

}
