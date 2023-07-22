using HW_PT4;
using System.Collections;

internal class Program
{
    int index = 0;
    private static void Input(ArrayList list)
    {
        string name;
        DateTime publishDate;
        string director;
        int[] rate = new int[3];
        Console.Write("Name: ");name =Console.ReadLine();
        Console.Write("Publish Date: "); publishDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Director: "); director = Console.ReadLine();
        for(int i=0; i < 3; i++)
        {
            Console.Write("Rate: "); rate[i] = int.Parse(Console.ReadLine());
        }
        Movie movie = new Movie();
        movie.Name = name;
        movie.PublishDate = publishDate;
        movie.Director = director;
        list.Add(movie);
    }
    private static void Main(string[] args)
    {
        ArrayList list = new ArrayList();
        CustomList cl = new CustomList();
        Console.WriteLine("PLEASE AN OPTION:");
        Console.WriteLine("1.Insert new Movie");
        Console.WriteLine("2.View list of Movie");
        Console.WriteLine("3.Sort Movie by Average List");
        Console.WriteLine("4.Delete a movie");
        Console.WriteLine("5.Exit");
        Input(list);
    }
}