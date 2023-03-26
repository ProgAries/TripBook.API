using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;

namespace TripBook.BLL.DTO.List
{
    public class AddGalleryDTO
    {
        [Required]
        public string? Title { get; set; }
    }

    public class AddImgToGalleryDTO
    {
        public byte[] Img { get; set; }
    }
}
