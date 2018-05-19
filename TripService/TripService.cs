using System.Collections.Generic;
using JetBrains.Annotations;
using TripService.Exceptions;

namespace TripService
{
    public class TripService
    {
        [PublicAPI]
        public IEnumerable<Trip> GetTripsByUser(User user)
        {
            IEnumerable<Trip> tripList = new List<Trip>();
            User loggedUser = UserSession.GetInstance().GetLoggedUser();
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
                    tripList = TripDao.FindTripsByUser(user);
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
