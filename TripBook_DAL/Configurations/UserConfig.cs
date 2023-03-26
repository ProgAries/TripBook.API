using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;
using TripBook.DAL.Entities.Enums;

namespace TripBook.DAL.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            Guid saltGuid = Guid.NewGuid();
            builder.HasData(new User
            {
                Id = Guid.NewGuid(),
                Name = "Marco Polo",
                NickName = "Milione",
                Email = "marcopolo@gmail.com",
                Salt = saltGuid,
                EncodedPassword = SHA512.HashData(Encoding.UTF8.GetBytes("marcocestmoi" + saltGuid.ToString())),
                PhotoUrl = "",
                BirthDate = new DateTime(1254,09,15,00,00,0),
                Gender = GenderType.Male,
                HomeCountry = "Italy",
                Biography = "I'm Marco Polo, I love Asia!!"
            });
        }
    }
}
