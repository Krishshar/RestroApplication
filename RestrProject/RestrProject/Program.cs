using RestrProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RestrProject.Interface;
using RestrProject.Classes;

namespace RestroProject
{
    class Program
    {
        IRestro Crostino = null;
        IRestro Dominos = null;
        IRestro Kfc = null;
        IRestro Panino = null;
        IRestro Pizzahut = null;

        public Program(Crostino crostino, Dominos dominos, Kfc kfc, Panino panino,Pizzahut pizzahut)
        {
            this.Crostino = crostino;
            this.Dominos = dominos;
            this.Kfc = kfc;
            this.Panino = panino;
            this.Pizzahut = pizzahut;
        }
        static void Main(string[] args)
        {
            Program program = new Program(new Crostino(), new Dominos(), new Kfc(), new Panino(), new Pizzahut());
            program.StartProgram();
        }

        private void StartProgram()
        {
            IRestro restro = null;

            while (true)
            {
                RestrauntChooser(restro);

                Console.WriteLine("\tDo you want to continue ?");
                Console.WriteLine("\t1 - Yes");
                Console.WriteLine("\t2 - No");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 2)
                    break;
                else
                    continue;
            }
        }

        private  void RestrauntChooser(IRestro restro)
        {
        RestroChooser:
            int choice = ShowDiffrentRestroOption();
            switch (choice)
            {
                case 1:
                    restro = Crostino;
                    break;
                case 2:
                    restro = Dominos;
                    break;
                case 3:
                    restro = Kfc;
                    break;
                case 4:
                    restro = Panino;
                    break;
                case 5:
                    restro = Pizzahut;
                    break;
            }
            if (restro != null)
                PerformRestroSpecificAction(restro);
            else
            {
                Console.WriteLine("\tInvalid Input Please try again.");
                goto RestroChooser;
            }
        }

        private  void PerformRestroSpecificAction(IRestro restro)
        {
            while (true)
            {
                Console.WriteLine("\tEnter your choice :");
                Console.WriteLine("\t1. Admin");
                Console.WriteLine("\t2. Customer");
                Console.WriteLine("\t3. Change Restraunt");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        restro.PerformRestroAction();
                        break;

                    case 2:
                        restro.RegisterCustomer()
                            .PerformCustomerAction(restro);
                        break;

                    case 3:
                        RestrauntChooser(restro);
                        break;
                }
            }
        }
        private static int ShowDiffrentRestroOption()
        {
            Console.WriteLine("\tChoose Restraunt : ");
            Console.WriteLine("\t\t1. Crostino");
            Console.WriteLine("\t\t2. Dominos");
            Console.WriteLine("\t\t3. KFC");
            Console.WriteLine("\t\t4. Panino");
            Console.WriteLine("\t\t5. Pizzahut");

            return Convert.ToInt32(Console.ReadLine());
        }
    }
}