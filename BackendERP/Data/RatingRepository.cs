using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class RatingRepository:IRatingRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public RatingRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Rating CreateRating(Rating rating)
        {
            var createdEntity = context.Add(rating);
            return mapper.Map<Rating>(createdEntity.Entity);
        }

        public void DeleteRating(int rating_id)
        {
            var uplata = GetRatingById(rating_id);
            context.Remove(uplata);
        }

        public Rating GetRatingById(int rating_id)
        {
            return context.Ratings.FirstOrDefault(e => e.Rating_id == rating_id);

        }
        public List<Rating> GetRatings()
        {
            return (from e in context.Ratings
                    select e).ToList();
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public Rating UpdateRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
