using System;
using Microsoft.EntityFrameworkCore;

namespace Opdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            using(MyContext context = new MyContext())
            {
                Klant Bob = new Klant { Naam = "Bob" };
                context.Klanten.Add(Bob);
                context.SaveChanges();
            }
            Console.WriteLine("Test");
        }
    }
}
