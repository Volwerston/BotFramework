using System.Collections.Generic;

namespace MovieGluClient.Test
{
    public class CinemaDto
    {
        public int cinema_id { get; set; }
        public string cinema_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string logo_url { get; set; }
    }

    public class CinemaResponse
    {
        public List<CinemaDto> cinemas { get; set; }
    }
}
