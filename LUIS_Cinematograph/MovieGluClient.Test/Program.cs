using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieGluClient.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var client = new MovieGluClient();

            client.SetClientGeolocation(-0.076132, 51.508530);

            var data = client.GetCinemasByName("IMAX").GetAwaiter().GetResult();
            var data1 = client.GetFilmsByName("Die hard").GetAwaiter().GetResult();
            var data2 = client.GetCinemasByFilmName("Die hard").GetAwaiter().GetResult();
            var data3 = client.GetCinemasNearby().GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}
