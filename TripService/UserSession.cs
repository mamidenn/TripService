using TripService.Exceptions;

namespace TripService
{
    public class UserSession
    {
        private static readonly UserSession Instance = new UserSession();

        private UserSession()
        {
        }

        public static UserSession GetInstance()
        {
            return Instance;
        }

        public User GetLoggedUser()
        {
            throw new DependencyCallDuringUnitTestException();
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependencyCallDuringUnitTestException();
        }
    }
}