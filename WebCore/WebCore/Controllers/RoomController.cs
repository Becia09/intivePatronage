//zrobić kasowanie całej listy pokoi, edycja dostępności

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApi.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private static List<Room> roomList = new List<Room>();
        //private int roomId = 0;



        //https://localhost:44394/room/add?name=roomName
        [HttpPut("add")]
        public int PutAdd(Models.RoomModel rm)
        {
            //bool flag = false;
            Room r = new Room(rm.name);
            roomList.Add(r);
            return r.id;
            
        }

        //https://localhost:44394/room/delete/2
        [HttpDelete("delete/{id}")]
        public int Delete(int id)
        {
            return roomList.RemoveAll(Room => Room.id == id); //returns the number of removed items //zwraca ilość usuniętych elementów
        }

        //https://localhost:44394/room/edit/2?name=newRoomName
        [HttpPatch("edit/{id}")]
        public string GetEdit(int id, Models.RoomModel rm)
        {
            if (roomList.Exists(Room => Room.id == id))
            {
                Room rEdit = roomList.Find(Room => Room.id == id);
                rEdit.name = rm.name;
                return rEdit.name;
            }
            else
            {
                return "Nie ma elementu o numerze " + id;
            }
        }

        // GET <controller>/add             //an additional function that allows you to check what rooms we have //dodatkowa funkcja pozwalająca sprawdzić jakie mamy pokoje
        //https://localhost:44394/room/list
        [HttpGet("list")]
        public string GetList()
        {
            string list = "Nr Id Nazwa pokoju\n";
            int i = 1;
            foreach (Room r in roomList)
            {
                list += i.ToString() + " " + r.id.ToString() + " " + r.name + "\n";
                i++;
            }

            return list;
        }
        

        
    }
}
