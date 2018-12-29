using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly testContext _context;


        public TodoController(testContext context)
        {
            _context = context;

            if (_context.TodoItem.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItem.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <remarks>
        /// 例子:
        /// </remarks>
        /// <returns>3333333</returns>
        [HttpGet]
        public Res GetAll()
        {
            var list = _context.TodoItem.ToList();
            var _res = new Res{Code=200,Msg="列表获取成功",Rows= list };
            return _res;
  
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">Toded的ID</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = _context.TodoItem.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public Res Create([FromBody]TodoItem item)
        {
            _context.TodoItem.Add(item);
            int i=_context.SaveChanges();
            if(i>0)
                return new Res { Code = 200, Msg = "添加成功" };
            return new Res { Code = 0, Msg = "添加失败" };
           
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.TodoItem.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItem.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("put")]
        public IActionResult Update(TodoItem item)
        {
            var todo = _context.TodoItem.Find(item.Id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItem.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
