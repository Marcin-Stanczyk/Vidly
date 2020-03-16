using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Correct.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte? GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}