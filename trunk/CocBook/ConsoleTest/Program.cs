using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.cs;
using DataAccessLayer.cs.DTO;
using DataAccessLayer.cs.DAL;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test PublishDAL
            Publisher publisher = new Publisher();
            PublisherDAL pubDAL = new PublisherDAL();
            //Test Create
            /*
            publisher.PublisherID = 1;
            publisher.PublisherName = "Kim Đồng";
            bool rs = pubDAL.CreatePulisher(publisher);
            if (rs)
            {
                Console.WriteLine("Success !");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            Console.ReadLine();
             */
            //Test Delete
            bool rs = pubDAL.DeletePublisherByID(8);
            if (rs)
            {
                Console.WriteLine("Success !");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            Console.ReadLine();
        }
    }
}
