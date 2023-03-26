using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TripBook.DAL.Entities
{
    public class GalleryImage
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }

    }
}
