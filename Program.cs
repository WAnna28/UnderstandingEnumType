using System;

namespace UnderstandingEnumType
{
    class Program
    {
        // A custom enumeration.
        enum Orientation
        {
            None, // = 0
            North, // = 1
            East1, // = 2
            South, // = 3
            West // = 4
        }

        // Begin with 300.
        enum Level
        {
            Low = 300,
            Medium,
            High
        }

        // Begin with 0.
        enum ErrorCode
        {
            None,
            Unknown,
            ConnectionLost = 100,
            BadRequest = 200
        }

        // Elements of an enumeration need not be sequential!
        enum Vehicle
        {
            Car = 4,
            Bike = 3,
            Truck,
            Taxi,
        }

        public enum Season
        {
            Spring = 500,
            Summer = 200,
            Autumn = 700,
            Winter = 350
        }

        #region Controlling the Underlying Storage for an enum

        enum EmpTypeEnum : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }

        // Compile-time error! 999 is too big for a byte!
        //enum EmpTypeEnum : byte
        //{
        //    Manager = 10,
        //    Grunt = 1,
        //    Contractor = 100,
        //    VicePresident = 999
        //}

        #endregion 

        static void Main()
        {
            DeclaringEnumVariables();

            UsingSystemEnumType(Vehicle.Car);
            UsingSystemEnumType(EmpTypeEnum.VicePresident);

            #region Dynamically Discovering an enum’s Name-Value Pairs
            // Car or Truck
            Console.WriteLine($"{Vehicle.Car} = {(int)Vehicle.Car}");

            string name = Season.Summer.ToString();
            Console.WriteLine($"{name} = {(int)Season.Summer}");
            Console.WriteLine($"{Season.Summer} = {(int)Season.Summer}");
            #endregion     

            ConsoleColor cc = ConsoleColor.Gray;
            EvaluateEnum(cc);
            EvaluateEnum(EmpTypeEnum.VicePresident);

            Console.ReadLine();
        }

        // Because enumerations are nothing more than a user-defined data type,
        // you can use them as function return values, method parameters,
        // local variables, and so forth.
        static void DeclaringEnumVariables()
        {
            ErrorCode ec = ErrorCode.BadRequest;
            ec = ErrorCode.None;
            showError(ec);

            // Error! BadRequest is not in the Season enum!
            //Season s = ErrorCode.BadRequest;

            // Error! Forgot to scope None value to ErrorCode enum!
            //ec = None;
        }

        private static void showError(ErrorCode ec)
        {
            switch (ec)
            {
                case ErrorCode.None:
                    Console.WriteLine("Works as expected!");
                    break;
                case ErrorCode.Unknown:
                    Console.WriteLine("Unknown error!");
                    break;
                case ErrorCode.ConnectionLost:
                    Console.WriteLine("Attention: connection lost!");
                    break;
                case ErrorCode.BadRequest:
                    Console.WriteLine("Attention: bad request!");
                    break;
            }

            Console.WriteLine();
        }

        static void UsingSystemEnumType(Enum e)
        {
            // the static Enum.GetUnderlyingType() returns the data type used to store the values of the enumerated type
            Console.WriteLine($"{e.GetType().Name} uses a {Enum.GetUnderlyingType(e.GetType())} for storage");
            Console.WriteLine();
        }

        // This method will print out the details of any enum.
        static void EvaluateEnum(Enum e)
        {
            Console.WriteLine("\nInformation about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            // Get all name-value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value, using the D format flag.
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                enumData.GetValue(i));
            }
        }
    }
}