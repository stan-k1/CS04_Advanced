using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CS04_Advanced.MyExtensions;
using Lab3_Extensions.LabExtensions;

namespace CS04_Advanced
{
    class Program
    {
        public delegate int OperationDelegate(int num, string text);

        public static int DoubleInput(int input, string successMsg)
        {
            Console.WriteLine(successMsg);
            return input * 2;
        }

        public static int TripleInput(int input, string successMsg)
        {
            Console.WriteLine(successMsg);
            return input * 3;
        }

        public static List<int> IntArrayOperation(int[] numbers, OperationDelegate operation)
        {
            List<int> opreatedNumbers = new();

            foreach (int num in numbers)
            {
                int result=operation(num, "Iteration Complete");
                opreatedNumbers.Add(result);
            }

            return opreatedNumbers;
        }

        public delegate void addDelegate(int num);

        public static void Add1(int num)
        {
            Console.WriteLine(num+1);
        }

        public static void Add2(int num)
        {
            Console.WriteLine(num + 2);
        }

        public delegate N GenericDelegate<N,T>(N number, T Text);

        public delegate void CatDel(Cat animal);

        public delegate Animal AnimalDel(string name);

        public static void PrintName(Animal animal)
        {
            Console.WriteLine(animal.Name);
        }

        public static Cat ReturnCat(string name)
        {
            return new Cat() { Name = name };
        }

        public static void TaskResultAnnouncer(object sender, TaskPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"Task was completed in {eventArgs.Seconds / eventArgs.Persons} seconds!");
        }

        static void Main(string[] args)
        {
            //Indexers

            Cat Cadife = new Cat() { Name = "Cadife", Age = 10, Colors = new List<string>(){"Black", "Brown"}};
            Cat Kitty = new Cat() { Name = "Kitty", Age = 0, Colors = new List<string>() { "Grey" }} ;
            Console.WriteLine(Cadife[1]); //Brown
            Console.WriteLine(Kitty[0]); //Grey
            Kitty[1] = "Black";
            Console.WriteLine(Kitty[1]); //Black
            Console.WriteLine(Kitty[1.45f]); //Black from float

            (string CadifeName, int CadifeAge) = Cadife;
            Console.WriteLine(CadifeName+" "+CadifeAge); //Cadife 10
            Cadife.Age = 11;
            Console.WriteLine(Cadife.Age); //11
            Console.WriteLine(CadifeAge); //10

            Console.WriteLine(new string("text").GetFirstChar());
            int neg = -1;
            int abs = neg.GetAbs();
            Console.WriteLine(abs);
            Console.WriteLine();

            int c = 0;
            Func<int> IncrementC = () => c++;
            IncrementC();
            Console.WriteLine(c); //1
            IncrementC();
            Console.WriteLine(c); //2

            c = 4;
            IncrementC();
            Console.WriteLine(c); //5

            //SEP
            
            Console.WriteLine(Double(5));
            TaskContainerSEP taskContainer = new TaskContainerSEP();
            taskContainer.TaskPerformed += TaskResultAnnouncer;
            taskContainer.TaskPerformed += delegate(object sender, TaskPerformedEventArgs e)
            {
                Console.WriteLine($"Hello from Anonymous method to {e.Persons} persons!");
            };
            taskContainer.DoTask(1, 1);

            AltProgram alt = new();

            alt.RunSubscriber();

            Func<string, Animal> func = ReturnCat;
            Animal funcAnimal = func("Tara");
            Console.WriteLine(funcAnimal.Name); //Tara

            CatDel catDel = PrintName;

            Cadife.isKitten();

            
            Console.WriteLine(Kitty.isKitten()); //True

            catDel(Cadife); //Cadife

            Action<Cat> action = PrintName;
            action(Cadife); //Cadife

            AnimalDel animalDel = ReturnCat;
            Animal Annie = animalDel("Annie"); 
            Console.WriteLine(Annie.Name); //Annie

            //Delegates

            GenericDelegate<int, string> intDelegate = DoubleInput;
            
            addDelegate myAddDelegate = Add1;
            myAddDelegate += Add2;
            myAddDelegate(1);

            OperationDelegate myDelegate = DoubleInput;
            myDelegate += TripleInput;

            List<int> Numbers = IntArrayOperation(new int[] { 1, 2 }, myDelegate);
            foreach (var num in Numbers)
            {
                Console.WriteLine(num); 
            }

            //Console.WriteLine(myDelegate(1, "Call to DoubleInput() Completed!"));

            //ArrayOperations Example (Audience Question 2)

            List<int> operatedNumbers = IntArrayOperation(new int[] { 5, 10, 20 }, myDelegate);

            foreach (var num in operatedNumbers)
            {
                Console.WriteLine(num); //10, 20, 40
            }

            OperationDelegate tripleDelegate = TripleInput;
            List<int> operatedNumbersTripled = IntArrayOperation(new int[] { 5, 10, 20 }, tripleDelegate);

            foreach (var num in operatedNumbersTripled)
            {
                Console.WriteLine(num); //15, 30, 60
            }

            //Other delegates

            NumDelegate del = FullDouble;
            Func<int, int> systemDel= FullDouble;
        }

        //Methods for the other delegates

        //public static int NoDouble = x => x + 1;

        public static int FullDouble(int x)
        {
            return x + x;
        }

        public delegate int NumDelegate(int num);
        //public NumDelegate Double = x => x + x;

        public static Func<int, int> Double = x => x + x;
       
        


    }
}
