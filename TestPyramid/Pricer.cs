using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestPyramid
{
    internal class Pricer
    {
        private static HttpClient _client = new HttpClient();
        public static Movie Price(string imdbId)
        {
            async Task<ImdbMovie> Json()
            {
                HttpResponseMessage response = await _client.GetAsync("http://www.omdbapi.com/?i=" + imdbId + "&apikey=6487ec62");

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<ImdbMovie>(json);
            }


            ImdbMovie imdbMovie = Json().Result;

            double price = 3.95;

            double rating = Double.Parse(imdbMovie.imdbRating);
            
            if(rating > 7.0)
                price += 1.0;

            if (rating < 4)
                price -= 1.0;
            
            return new Movie(imdbMovie.Title, price);
        }
    }

    internal class ImdbMovie
    {
        public string Title {
            get;
            set;
        }

        public string imdbRating
        {
            get;
            set;
        }
    }
}