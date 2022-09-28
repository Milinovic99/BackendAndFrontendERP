using AutoMapper;
using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Controllers
{
    [ApiController]
    [Route("api/rejting")]
    [Produces("application/json")]
    public class RatingController:ControllerBase
    {
        private readonly IRatingRepository ratingRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public RatingController(IRatingRepository ratingRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ratingRepository = ratingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Rating>> GetRatings()
        {


            var rating = ratingRepository.GetRatings();
            if (rating == null || rating.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Rating>>(rating));
        }

        [HttpGet("{rating_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Rating> GetRating(int rating_id)
        {

            var rating = ratingRepository.GetRatingById(rating_id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Rating>(rating));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Rating> CreateRating([FromQuery] Rating rating)
        {

            try
            {
                Rating pro = ratingRepository.CreateRating(rating);
                ratingRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                // string location = linkGenerator.GetPathByAction("GetDeliveryData", "Delivery_data", new { delivery = pro.Delivery_id });
                return StatusCode(StatusCodes.Status200OK, pro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{rating_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteRating(int rating_id)
        {
            try
            {
                var productModel = ratingRepository.GetRatingById(rating_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                ratingRepository.DeleteRating(rating_id);
                ratingRepository.SaveChanges();
                // Status iz familije 2xx koji se koristi kada se ne vraca nikakav objekat, ali naglasava da je sve u redu

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        [HttpPut]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Rating> UpdateRating(Rating rating)
        {

            try
            {
                var complaintCheck = ratingRepository.GetRatingById(rating.Rating_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(rating, complaintCheck);
                ratingRepository.SaveChanges();
                return Ok(mapper.Map<Delivery>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        }
}
