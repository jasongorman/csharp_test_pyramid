using System;

namespace TestPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            string imdbID = args[0];
            string member = args[1];
            Rental rental = new Rental(imdbID, member);
            Console.WriteLine("imdb ID: " + rental.ImdbID + ", member: " + rental.Member + ", title: " 
                              + rental.Title + ", price: " + rental.Price);
        }
    }
}