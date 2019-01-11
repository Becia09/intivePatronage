using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi
{
    public class Room
    {
        public Room(string roomName)
        {
            this.id = ++Room.nextId;
            this.name = roomName;
        }

        public int id;
        public static int nextId;
        public string name;
        public bool availability = true;
    }
}
