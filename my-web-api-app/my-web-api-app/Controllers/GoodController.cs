using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using my_web_api_app.Models;

namespace my_web_api_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        public static List<Good> goods = new List<Good>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(goods);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //Test
                //LINQ [Object] Query
                var good = goods.SingleOrDefault(good => good.GoodCode == System.Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }
                return Ok(good);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]

        public IActionResult Create(GoodVM goodVM)
        {
            var good = new Good
            {
                GoodCode = System.Guid.NewGuid(),
                NameOfGood = goodVM.NameOfGood,
                UnitPrice = goodVM.UnitPrice,
            };
            goods.Add(good);
            return Ok(new
            {
                Success = true,
                Data = good
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Good goodEdit)
        {
            try
            {
                //LINQ [Object] Query
                var good = goods.SingleOrDefault(good => good.GoodCode == System.Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }

                if (id != good.GoodCode.ToString())
                {
                    return BadRequest();
                }
                //Update
                good.NameOfGood = goodEdit.NameOfGood;
                good.UnitPrice = goodEdit.UnitPrice;
                return Ok(good);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(string id)
        {
            try
            {
                //LINQ [Object] Query
                var good = goods.SingleOrDefault(good => good.GoodCode == System.Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }
                //Update
                goods.Remove(good);
                return Ok(good);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
