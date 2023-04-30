using Cool_events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events
{
    public class Logged
    {
        private static bool loggedIn = false;
        private static bool isAdmin;
        private static int loggedId;
        private static Events currentEvent;
        public static bool LoggedIn { get => loggedIn; set => loggedIn = value; }

        public static bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public static int LoggedId { get => loggedId; set => loggedId = value; }
        public static Events CurrentEvent { get => currentEvent; set => currentEvent = value; }
    }
}
