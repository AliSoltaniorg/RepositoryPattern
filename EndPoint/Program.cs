using Core.UoW;
using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System;

namespace EndPoint
{
    internal class Program
    {
        private static IPatternDbContext context;
        static void Main(string[] args)
        {
            context = new PatternDbContext();

            using IUnitOfWork unitOfWork = new UnitOfWork(context);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            int selection = 0;
            while (selection != 9)
            {
                Console.WriteLine("1-Section Users:");
                Console.WriteLine(" 2-Add User:");
                Console.WriteLine(" 3-Update User:");
                Console.WriteLine(" 4-Delete User:");
                Console.Write("Enter Number: ");
                selection = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        var users = unitOfWork.UserRepository.GetAll();
                        foreach (var item in users)
                        {
                            Console.WriteLine(item);
                        }
                        users = null;
                        break;
                    case 2:
                        User user = new();
                        Console.Write("Enter Name: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        user.Age = int.Parse(Console.ReadLine());
                        unitOfWork.UserRepository.Add(user);
                        unitOfWork.SaveChanges();
                        break;
                    case 3:
                        Console.Write("Enter Id: ");
                        int userId = int.Parse(Console.ReadLine());
                        var getUser = unitOfWork.UserRepository.FindOrDefault(userId);
                        if(getUser != null)
                        {
                            Console.WriteLine("Update: " + getUser);
                            Console.Write("Enter Name: ");
                            getUser.Name = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            getUser.Age = int.Parse(Console.ReadLine());
                            unitOfWork.UserRepository.Update(getUser);
                            unitOfWork.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("User Not Found!");
                        }
                        break;
                    case 4:
                        Console.Write("Enter Id: ");
                        int id = int.Parse(Console.ReadLine());
                        unitOfWork.UserRepository.Delete(id);
                        unitOfWork.SaveChanges();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
