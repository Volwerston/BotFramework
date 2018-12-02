using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace MovieGluClient.Test
{
    public class MovieGluClient
    {
        public readonly HttpClient _httpClient = new HttpClient();

        public MovieGluClient()
        {
            _httpClient.BaseAddress = new Uri("https://api-gate2.movieglu.com/");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Add("client", "STUD_45");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "nhdYBOaAEf4ql9PPOjmqJ1WtQg4cop4o3QFog6n3");
            _httpClient.DefaultRequestHeaders.Add("api-version", "v200");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic U1RVRF80NTpUYWRtU3pTNE5CTUQ=");
            _httpClient.DefaultRequestHeaders.Add("territory", "UK");
            _httpClient.DefaultRequestHeaders.Add("device-datetime", DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
        }

        public void SetClientGeolocation(double longtitude, double latitude)
        {
            _httpClient.DefaultRequestHeaders.Add("geolocation", $"{latitude:F6};{longtitude:F6}");
        }

        public async Task<CinemaResponse> GetCinemasByName(string name, int count=1)
        {
            string query = name.Replace(' ', '+').Trim();

            var response = await _httpClient.GetAsync($"cinemaLiveSearch/?query={query}&n={count}");

            return await response.Content.ReadAsAsync<CinemaResponse>();
        }

        public async Task<FilmResponse> GetFilmsByName(string name,int count=1)
        {
            string query = name.Replace(' ', '+').Trim();

            var response = await _httpClient.GetAsync($"filmLiveSearch/?query={query}&n={count}");

            return await response.Content.ReadAsAsync<FilmResponse>();
        }

        public async Task<CinemaResponse> GetCinemasByFilmName(string filmName, int count=1)
        {
            string query = filmName.Replace(' ', '+').Trim();

            var filmInfo = await GetFilmsByName(filmName, 1);
            var filmId = filmInfo.films[0].film_id;

            var response = await _httpClient.GetAsync($"closestShowing/?film_id={filmId}&n={count}");

            return await response.Content.ReadAsAsync<CinemaResponse>();
        }

        public async Task<CinemaResponse> GetCinemasNearby(int count = 1)
        {
            var response = await _httpClient.GetAsync($"cinemasNearby/?n={count}");

            return await response.Content.ReadAsAsync<CinemaResponse>();
        }
    }
}
