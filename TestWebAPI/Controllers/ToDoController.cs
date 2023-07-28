using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("TestWebAPI/[controller]")]
    public class TodoController : ControllerBase
    {
        private List<string> _todoItems = new List<string> { "test", "test2" };
        [HttpGet]
        public List<string> GetTodo()
        {
            return _todoItems;
        }

        [HttpGet]
        [Route("{id}")]

        public string GetOneItem(int id)
        {
            if (_todoItems.ElementAtOrDefault(id) == null)
                return null;
            return _todoItems[id];
        }

        [HttpPost]
        public string AddToDoItem(ToDoItem item)
        {
            _todoItems.Add(item.Title);
            return item.Title + " was added";
        }
        [HttpPut]
        [Route("{id}")]
        public string UpdateToDoItem(int id, ToDoItem item)
        {
            if (_todoItems.ElementAtOrDefault(id) != null)
            {
                _todoItems.Insert(id, item.Title);
                return id + " was updated";
            }
            return null;
        }
        [HttpDelete]
        [Route("{id}")]
        public string DeleteToDoItem(int id)
        {
            if (_todoItems.ElementAtOrDefault(id) != null)
            {
                _todoItems.RemoveAt(id);
                return id + " was deleted";
            }
            return null;
        }
    }
}
