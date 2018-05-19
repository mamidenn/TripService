using System.Collections.Generic;
using JetBrains.Annotations;

namespace TripService
{
    public class User
    {
        [PublicAPI]
        public List<User> Friends { get; } =  new List<User>();
        [PublicAPI]
        public List<Trip> Trips { get; } = new List<Trip>();

        [PublicAPI]
        public void AddFriend(User friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
            }

            if (!friend.Friends.Contains(this))
            {
                friend.Friends.Add(this);
            }
        }

        [PublicAPI]
        public void AddTrip(Trip trip)
        {
            if (!Trips.Contains(trip))
            {
                Trips.Add(trip);
            }
        }
    }
}