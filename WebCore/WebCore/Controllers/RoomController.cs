﻿//zrobić kasowanie całej listy pokoi, edycja dostępności

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

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // GET api/<controller>/add
        //https://localhost:44394/room/add/pok1
        [HttpGet("add/{name}")]
        public int GetAdd(string name)
        {
            //bool flag = false;
            Room r = new Room(name);
            roomList.Add(r);
            return r.id;
        }

        // GET api/<controller>/add
        //https://localhost:44394/room/add2/pok1
        [HttpGet("add2/{name}")]
        public int GetAdd2(string name)
        {
            //bool flag = false;
            Room r = new Room(name);
            roomList.Add(r);
            //r = new Room(name);
            //roomList.Add(r);
            return roomList.Count;
        }

        // GET api/<controller>/del
        //https://localhost:44394/room/del/2
        [HttpGet("del/{id}")]
        public int GetDelete(int id)
        {
            //var item = roomList.Single(Room => Room.id == 2);
            //roomList.Remove(item);

            //roomList.RemoveAll(Room => Room.id == id);
            return roomList.RemoveAll(Room => Room.id == id); //zwraca ilość usuniętych elementów
        }


        // GET api/<controller>/add
        //https://localhost:44394/room/edit/2&name2
        [HttpGet("edit/{id}&{newName}")]
        public string GetEdit(int id, string newName)
        {
            if (roomList.Exists(Room => Room.id == id))
            {
                Room rEdit = roomList.Find(Room => Room.id == id); //zwraca pierwszy element spełniający warunek, jeśli nie ma elementu to wartość domyślną dla typu elementó listy
                rEdit.name = newName;
                return rEdit.name;
            }
            else
            {
                return "Nie ma elementu o numerze " + id;
            }
        }

        // GET api/<controller>/add
        //https://localhost:44394/room/edit/2
        [HttpGet("edit/{id}")]
        public string GetEditIf(int id)
        {
            if (roomList.Exists(Room => Room.id == id))
            {
                Room rEdit = roomList.Find(Room => Room.id == id); //zwraca pierwszy element spełniający warunek, jeśli nie ma elementu to wartość domyślną dla typu elementó listy
                return rEdit.name;
            }
            else
            {
                return "Nie ma elementu o numerze" + id;
            }
        }


        // GET api/<controller>/add
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




        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}