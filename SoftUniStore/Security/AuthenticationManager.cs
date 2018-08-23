namespace SoftUniStore.Security
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public static class AuthenticationManager
    {
        private static readonly IUnitOfWork Context;

        static AuthenticationManager()
        {
            Context = Data.UnitOfWork;
        }

        public static void Login(User user, string sessionId)
        {
            if (Context.Sessions.All().Any(s => s.SessionId == sessionId))
            {
                return;
            }

            var session = new Session
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            };
            Context.Sessions.Add(session);
            Context.SaveChanges();
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            var sessionEntity = Context.Sessions.All().FirstOrDefault(s => s.SessionId == sessionId);
            if (sessionEntity != null)
            {
                sessionEntity.IsActive = false;
            }
            Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        public static User GetCurrentUser(HttpSession session)
        {
            return Context.Sessions.All().FirstOrDefault(
                s => s.SessionId == session.Id && s.IsActive)?.User;
        }

        public static string GetCurrentUsername(HttpSession session)
        {
            return Context.Sessions.All().FirstOrDefault(
                s => s.SessionId == session.Id && s.IsActive)?.User?.Fullname;
        }

        public static bool IsAuthenticated(HttpSession session)
        {
            return Context.Sessions.All().Any(
                s => s.SessionId == session.Id && s.IsActive);
        }
        public static bool IsAdmin(HttpSession session)
        {
            return Context.Sessions.All().Any(
                s => s.SessionId == session.Id && s.IsActive && s.User.IsAdmin);
        }
    }
}