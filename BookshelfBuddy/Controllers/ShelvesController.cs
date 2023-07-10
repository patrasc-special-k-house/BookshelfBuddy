using BookshelfBuddy.Data.Entities;
using BookshelfBuddy.Services;
using BookshelfBuddy.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookshelfBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShelvesController : ControllerBase
    {
        private readonly ShelfService _shelfService;

        public ShelvesController(ShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _shelfService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetShelf(Guid id)
        {
            Shelf result = _shelfService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult InsertShelf([FromBody] ShelfDto shelf)
        {
            if (shelf == null)
            {
                return BadRequest("Shelf cannot be null");
            }

            if (!_shelfService.Insert(shelf))
            {
                return BadRequest("Shelf cannot be created");
            }

            return Ok(shelf);
        }

        [HttpPost]
        [Route("shelfOwner")]
        [Authorize(Roles = "ShelfOwner")]
        public IActionResult InsertShelfForShelfOwner([FromBody] ShelfDto shelf)
        {
            if (shelf == null)
            {
                return BadRequest("Shelf cannot be null");
            }

            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);
            ShelfOwner shelfOwner = _shelfService.GetShelfOwner(userId);

            if (shelfOwner == null)
            {
                return BadRequest("ShelfOwner cannot be null");
            }

            shelf.ShelfOwnerId = shelfOwner.Id;
            if (!_shelfService.Insert(shelf))
            {
                return BadRequest("Shelf cannot be created");
            }

            return Ok(shelf);
        }

        [HttpPut]
        public IActionResult UpdateShelf([FromBody] ShelfDto shelf)
        {
            if (shelf == null)
            {
                return BadRequest("Shelf cannot be null");
            }

            if (!_shelfService.Update(shelf.Id, shelf))
            {
                return NotFound("Shelf not found");
            }

            return Ok(shelf);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveShelf([Required] Guid id)
        {
            if (!_shelfService.Remove(id))
            {
                return NotFound("Shelf not found");
            }
            return Ok("Shelf deleted");
        }
    }
}