using BrendUz.Data;
using BrendUz.Dtos;
using BrendUz.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BrendUz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ClothController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Creat([FromBody] CreatClothDto dto)
        {
            var created = dbContext.Cloths.Add(new Cloth
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Brend = dto.Brend,
                Price = dto.Price,
                Size = dto.Size,
                Made = dto.Made,
            });

            await dbContext.SaveChangesAsync();
            return Ok(created);

        }
        [HttpGet]
        public async Task<IActionResult> Gets([FromQuery] string search)
            
        {
            var clothQuery = dbContext.Cloths.AsQueryable();

            if(false == string.IsNullOrWhiteSpace(search)) { }
            clothQuery = clothQuery.Where(c => c.Brend.ToLower().Contains(search.ToLower()));

            var cloth = await clothQuery.ToListAsync();
            return Ok(cloth);

        }
        [HttpGet]
        public async Task<IActionResult> GetCloth([FromRoute] Guid Id)
        {
            var getCloth = dbContext.Cloths.Where(c => c.Id == Id)
            .FirstOrDefault();
            if (getCloth is null) 
                return NotFound();
            return Ok(new GetClothDto (getCloth));
        }
    }
}
