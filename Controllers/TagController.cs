using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelerNotes.Db;
using TravelerNotes.Entitites;
using TravelerNotes.Models.Tag;

namespace TravelerNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TravelerNotesDb _db;

        public TagController()
        {
            _db = new TravelerNotesDb();
        }

        [HttpGet("GetAllTag")]
        public IActionResult GetTags()
        {
            var tags = _db.Tags.Select(t => new TagResponse
            {
                Id = t.Id,
                Comment = t.Comment,
                PlaceId = t.PlaceId,
                TripId = t.TripId,
                TagTime = t.TagTime,
            }).ToList();

            return Ok(tags);

        }



        [HttpPost("AddTag")]
        public IActionResult AddTag(TagRequest request)
        {
            if (!_db.Places.Any(p => p.Id == request.PlaceId))
                return NotFound("Place not found");

            if (!_db.Trips.Any(t => t.Id == request.TripId))
                return NotFound("Trip not found");

            var tag = new Tag
            {
                Comment = request.Comment,
                PlaceId = request.PlaceId,
                TripId = request.TripId,
                TagTime = request.TagTime,
            };

            _db.Tags.Add(tag);
            _db.SaveChanges();

            var response = new TagResponse
            {
                Id = tag.Id,
                PlaceId = tag.PlaceId,
                TripId = tag.TripId,
                TagTime = tag.TagTime,
                Comment = tag.Comment
            };

            return Ok(response);

         
        }


    }
}
