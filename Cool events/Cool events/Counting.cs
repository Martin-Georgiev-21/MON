using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events
{
    public class Counting
    {
        private static int events;
        private static int users;
        private static int tickets;
        public static int Events { get => events; set => events = value; }
        public static int Users { get => users; set => users = value; }
        public static int Tickets { get => tickets; set => tickets = value; }
    }
}
