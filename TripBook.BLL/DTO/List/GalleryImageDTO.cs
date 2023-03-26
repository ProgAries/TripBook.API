using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;

namespace TripBook.BLL.DTO.List
{
    public class GalleryImageDTO
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public int GalleryId { get; set; }

        public GalleryImageDTO(GalleryImage i)
        {
                ImageId = i.ImageId;
            ImageUrl = i.ImageUrl;

            GalleryId = i.GalleryId;
        }
    }
}
