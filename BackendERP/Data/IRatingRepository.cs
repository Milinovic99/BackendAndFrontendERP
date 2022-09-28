using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
   public interface IRatingRepository
    {
        List<Rating> GetRatings();
        Rating GetRatingById(int rating_id);
        Rating CreateRating(Rating rating);
        Rating UpdateRating(Rating rating);
        void DeleteRating(int rating_id);
        bool SaveChanges();
    
}
}
