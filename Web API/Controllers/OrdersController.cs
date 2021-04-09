using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        OrdersContext db;
        public OrdersController(OrdersContext context)
        {
            db = context;
            //if (!db.Orders.Any())
            //{
            //    db.Orders.Add(new Order { Name = "Tom", Age = 26 });
            //    db.Orders.Add(new Order { Name = "Alice", Age = 31 });
            //    db.SaveChanges();
            //}
        }

        // GET: api/<controller>
        [HttpGet]
        [NonAction]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await db.Orders.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [NonAction]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }

        [HttpGet("{order_number}")]//Поиск по номеру заказа
        public async Task<ActionResult<Order>> Get2(string order_number)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(x => x.Order_number == order_number);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }
        // POST api/<controller>        
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody]Order[] orders)//Загрузка списка JSON в массиве
        {
            string jsonString = JsonConvert.SerializeObject(orders);          
            var json = JsonConvert.DeserializeObject<Order[]>(jsonString);

            foreach (var order in json)
            {
                db.Orders.Add(order);
            }
            var result = await db.SaveChangesAsync();
            return new OkObjectResult(result);           
        }

        [HttpPost]
        [NonAction]
        public async Task<ActionResult<Order>> Post2(Order order)//Загрузка по одному заказу
        {
            if (order == null)
            {
                return BadRequest();
            }
            // если ошибок нет, сохраняем в базу данных
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // PUT api/<controller>/5
        [HttpPut]
        //[NonAction]
        public async Task<ActionResult<Order>> Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!db.Orders.Any(x => x.Id == order.Id))
            {
                return NotFound();
            }

            db.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [NonAction]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
