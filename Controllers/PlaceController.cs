using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelerNotes.Db;
using TravelerNotes.Entitites;
using TravelerNotes.Models.Place;

namespace TravelerNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly TravelerNotesDb _db;

        public PlaceController()
        {
            _db = new TravelerNotesDb();
        }

        [HttpGet("GetAllPlaces")]
        public List<PlaceResponse> GetAllPlaces()
        {
            return _db.Places.Select(p => new PlaceResponse
            {
                Id = p.Id,
                Name = p.Name,
                LocationUrl = p.LocationUrl,
                WorkStartTime = p.WorkStartTime,
                WorkEndTime = p.WorkEndTime,
                CountryId = p.CountryId
            }).ToList();
        }

        [HttpPost("AddPlace")]
        public IActionResult AddPlace(PlaceRequest request)
        {
            var place = new Place
            {
                Name = request.Name,
                LocationUrl = request.LocationUrl,
                WorkStartTime = request.WorkStartTime,
                WorkEndTime = request.WorkEndTime,
                CountryId = request.CountryId
            };


            _db.Places.Add(place);
            _db.SaveChanges();
           
            return Ok(place);
        }


        [HttpDelete("RemovePlace")]

        public IActionResult DeletePlace(int placeId)
        {
           var place = _db.Places.FirstOrDefault(p => p.Id == placeId);
            if(place is null)
            {
                return NotFound($"Adgili {placeId} am Id it ar arsebobs");
            }

            _db.Places.Remove(place);
            return Ok($"Adgili waishala: {place.Name}");
           

        }



    }
}
