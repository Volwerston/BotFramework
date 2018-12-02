using System.Collections.Generic;

namespace MovieGluClient.Test
{
    public class FilmDto
    {
        public int film_id { get; set; }
        public string film_name { get; set; }
    }

    public class FilmResponse
    {
        public List<FilmDto> films { get; set; }
    }
}
