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



        // GET api/<controller>/add
        //https://localhost:44394/room/add/pok1
        [HttpPut("add")]
        public int PutAdd(Models.RoomModel rm)
        {
            //bool flag = false;
            Room r = new Room(rm.name);
            roomList.Add(r);
            return r.id;
            
        }

        // GET api/<controller>/del
        //https://localhost:44394/room/del/2
        [HttpDelete("delete/{id}")]
        public int Delete(int id)
        {
            //var item = roomList.Single(Room => Room.id == 2);
            //roomList.Remove(item);

            //roomList.RemoveAll(Room => Room.id == id);
            return roomList.RemoveAll(Room => Room.id == id); //zwraca ilość usuniętych elementów
        }


        // GET api/<controller>/add
        //https://localhost:44394/room/edit/2&name2
        [HttpPatch("edit/{id}")]
        public string GetEdit(int id, Models.RoomModel rm)
        {
            if (roomList.Exists(Room => Room.id == id))
            {
                Room rEdit = roomList.Find(Room => Room.id == id); //zwraca pierwszy element spełniający warunek, jeśli nie ma elementu to wartość domyślną dla typu elementó listy
                rEdit.name = rm.name;
                return rEdit.name;
            }
            else
            {
                return "Nie ma elementu o numerze " + id;
            }
        }

        // GET api/<controller>/add             //dodatkowa funkcja pozwalająca sprawdzić jakie mamy pokoje
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
