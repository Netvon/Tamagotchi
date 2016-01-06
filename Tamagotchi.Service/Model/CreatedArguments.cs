using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi.Service.Model
{
    public class CreatedArguments
    {
        public CreatedArguments(int createdId, string createdName, bool wasCreated)
        {
            CreatedId = createdId;
            CreatedName = createdName;
            WasCreated = wasCreated;
        }

        public int CreatedId { get; set; }
        public string CreatedName { get; set; }
        public bool WasCreated { get; set; }
    }
}