using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events.Models
{
    public class BigView
    {
        public BigView(IEnumerable<Events> events, IEnumerable<Users> users, IEnumerable<Tickets> tickets)
        {
            this.events = events;
            this.users = users;
            this.tickets = tickets;
        }

        private IEnumerable<Events> events;
        private IEnumerable<Users> users;
        private IEnumerable<Tickets> tickets;

        public IEnumerable<Events> Events
        {
            get => events;
            set => events = value;
        }
        public IEnumerable<Users> Users
        {
            get => users;
            set => users = value;
        }
        public IEnumerable<Tickets> Tickets
        {
            get => tickets;
            set => tickets = value;
        }
    }
}
