using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripBook.DAL.Entities
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public ICollection<GalleryImage> GalleryImages { get; set; }



    }
}