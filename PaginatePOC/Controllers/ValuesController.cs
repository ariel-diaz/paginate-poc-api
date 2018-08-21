using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginatePOC.Helpers;
using PaginatePOC.Interfaces;
using PaginatePOC.Model;
using PaginatePOC.Services;

namespace PaginatePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IDataRepository _repo;

        public ValuesController(DataContext context, IDataRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParamsPaginate valuesParams)
        {

            //return new string[] { "value1", "value2", "value1", "value2" , "value1", "value2" , "value1", "value2" , "value1", "value2" ,
            // "value1", "value2", "value1", "value2" , "value1", "value2" , "value1", "value2" , "value1", "value2"};
            var items = await _repo.GetValues(valuesParams);
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _context.Values.AddAsync(item);
                _context.SaveChanges();
                return Ok(item);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
