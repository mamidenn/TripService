namespace TripService
{
    public class UserBuilder
    {
        private User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public UserBuilder WithFriends(params User[] friends)
        {
            foreach (var friend in friends)
            {
                _user.AddFriend(friend);
            }

            return this;
        }

        public UserBuilder WithTrips(params Trip[] trips)
        {
            foreach (var trip in trips)
            {
                _user.AddTrip(trip);
            }

            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}