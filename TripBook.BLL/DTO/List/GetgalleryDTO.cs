using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;

namespace TripBook.BLL.DTO.List
{
    public class GetgalleryDTO
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public ICollection<GalleryImageDTO> GalleryImages { get; set; }



        public GetgalleryDTO (Gallery g)
        {
            GalleryId = g.GalleryId;
            Title = g.Title;
            GalleryImages = g.GalleryImages.Select(i => new GalleryImageDTO(i)).ToList();
        }




    }

}
