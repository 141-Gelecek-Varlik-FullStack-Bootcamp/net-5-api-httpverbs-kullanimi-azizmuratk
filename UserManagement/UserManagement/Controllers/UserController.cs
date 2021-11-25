using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        // Example Data
        private static List<User> UserLists = new List<User>()
        {
            new User
            {
                Id=1,
                Name="Ahmet",
                Surname="Kaptan",
                CreatedDate= new DateTime(2021,07,20),
                Email="ahmetkaptan@hotmail.com",
                Password="ahmet12kaptan"
            },
            new User
            {
                Id=2,
                Name="Murat",
                Surname="Karaca",
                CreatedDate= new DateTime(2021,10,21),
                Email="muratkaraca@yahoo.com",
                Password="mur4tkrc1"
            },
            new User
            {
                Id=3,
                Name="Merve",
                Surname="Uzak",
                CreatedDate= new DateTime(2021,11,05),
                Email="merveuzak@gmail.com",
                Password="merve.uzak"
            }
        };
        // (Get) => api/users // get all users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return UserLists;
        }
        // (Get) => api/users/{id} // get specific user
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = UserLists.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return BadRequest();
            }
            return user;
        }
        //(Post) => api/users // change user
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var user = UserLists.SingleOrDefault(x => x.Email == newUser.Email);

            if(user is not null)
            {
                return BadRequest();
            }

            UserLists.Add(newUser);
            return Ok();
        }
        //(Put) => api/users/{id} // update specific user
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = UserLists.SingleOrDefault(x =>x.Id == id);
            if(user is null)
            {
                return BadRequest();
            }
            // if no change => write default
            user.Name = updatedUser.Name != default ? updatedUser.Name : user.Name;
            user.Surname = updatedUser.Surname != default ? updatedUser.Surname : user.Surname;
            user.CreatedDate = updatedUser.CreatedDate != default ? updatedUser.CreatedDate : user.CreatedDate;
            user.Email = updatedUser.Email != default ? updatedUser.Email : user.Email;
            user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;

            return Ok();
        }
        //(Delete) => api/users/{id} // delete specific user
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserLists.SingleOrDefault(x => x.Id == id);
            if (user is null)
            {
                return BadRequest();
            }
            UserLists.Remove(user);
            return Ok();
        }
    }
}
