namespace CSharpBasicsAssignment;

// 1. csproj: الملف الذي يحتوي على إعدادات المشروع مثل إصدار .NET ونوع التطبيق.
// 2. Program.cs: الملف الذي نكتب فيه الكود الذي سينفذه البرنامج.
// 3. obj/: يحتوي على ملفات مؤقتة تُستخدم أثناء عملية Build.
// 4. bin/: يحتوي على الملفات الناتجة بعد بناء المشروع (Build).

// Solution format: This project uses the newer .slnx format.
// One advantage of the classic .sln format is its broad compatibility
// with older tools that may not support .slnx.

internal class Program
{
    private static int sharedNumber = 10;

    static void Main(string[] args)
    {
        RunTypesDemo();
        RunValueVsReferenceDemo();
        RunOrderDemo();

        ReadSharedNumber();
        ReadSharedNumberAgain();
        RunScopeDemo();
        RunCompoundAssignmentDemo();
        RunBitwiseDemo();

        RunSingleNumberDemo();
    }

    // Part B
    static void RunTypesDemo()
    {
        Console.WriteLine("\n--- Variables and Types ---");

        int age = 22;
        long population = 8000000000L;
        double price = 19.75;
        decimal salary = 15000.50m;
        bool isLearning = true;
        char grade = 'A';
        string name = "Eman";
        var city = "Alexandria";

        Console.WriteLine($"age = {age}, Type = {age.GetType()}");
        Console.WriteLine($"population = {population}, Type = {population.GetType()}");
        Console.WriteLine($"price = {price}, Type = {price.GetType()}");
        Console.WriteLine($"salary = {salary}, Type = {salary.GetType()}");
        Console.WriteLine($"isLearning = {isLearning}, Type = {isLearning.GetType()}");
        Console.WriteLine($"grade = {grade}, Type = {grade.GetType()}");
        Console.WriteLine($"name = {name}, Type = {name.GetType()}");
        Console.WriteLine($"city = {city}, Type = {city.GetType()}");

        int number = 100;
        long bigNumber = number;

        char letter = 'A';
        int letterCode = letter;

        Console.WriteLine($"int to long = {bigNumber}");
        Console.WriteLine($"char to int = {letterCode}");

        double value = 9.7;
        int truncated = (int)value;

        int rounded = Convert.ToInt32(value);

        Console.WriteLine($"Explicit cast = {truncated}");
        Console.WriteLine($"Convert.ToInt32 = {rounded}");

        int integerDivision = 5 / 2;
        double doubleDivision = 5.0 / 2;

        Console.WriteLine($"5 / 2 = {integerDivision}");
        Console.WriteLine($"5.0 / 2 = {doubleDivision}");

        int originalNumber = 50;
        object boxedNumber = originalNumber;

        Console.WriteLine($"Boxed value = {boxedNumber}");

        int unboxedNumber = (int)boxedNumber;

        Console.WriteLine($"Unboxed value = {unboxedNumber}");

        string validText = "42";
        int parsedNumber = int.Parse(validText);

        Console.WriteLine($"Parsed number = {parsedNumber}");

        string invalidText = "abc";
        bool success = int.TryParse(invalidText, out int result);

        Console.WriteLine($"TryParse succeeded = {success}");

        if (success)
        {
            Console.WriteLine($"Parsed result = {result}");
        }
        else
        {
            Console.WriteLine("Parsing failed: input is not a valid integer.");
        }

        float floatValue = 12.5f;
        decimal convertedValue = (decimal)floatValue;

        Console.WriteLine($"float value = {floatValue}");
        Console.WriteLine($"Converted decimal value = {convertedValue}");
    }

    // Part C
    struct Point
    {
        public int X;
        public int Y;
    }

    static void RunValueVsReferenceDemo()
    {
        Console.WriteLine("\n--- Value Type Demo ---");

        Point p1 = new Point { X = 1, Y = 2 };

        Point p2 = p1;

        p2.X = 99;

        Console.WriteLine($"p1.X = {p1.X}"); 
        Console.WriteLine($"p2.X = {p2.X}"); 
    }

    // Part C
    static void RunOrderDemo()
    {
        Console.WriteLine("\n--- Reference Type Demo ---");

        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Ali",
            Quantity = 3,
            UnitPrice = 100m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Alexandria",
            Priority = 'H',
            ItemCode = 123456L
        };

        o1.CalculateTotal();

        Order o2 = o1;

        o2.IsPaid = true;

        Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
        Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

        object boxedOrder = o1;

        Order o3 = (Order)boxedOrder;

        Console.WriteLine(
            $"Same instance: {object.ReferenceEquals(o1, o3)}");

        o2.PrintSummary();
    }

    // Part D
    static void ReadSharedNumber()
    {
        Console.WriteLine($"Shared number = {sharedNumber}");
    }

    static void ReadSharedNumberAgain()
    {
        Console.WriteLine($"Shared number again = {sharedNumber}");
    }

// Part D1
static void RunScopeDemo()
    {
        Console.WriteLine("\nScope Demo");

        int localNumber = 5;
        Console.WriteLine($"Local number = {localNumber}");

        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;

            Console.WriteLine($"i = {i}");
            Console.WriteLine($"insideLoop = {insideLoop}");
        }

    }

    // Part D2
    static void RunCompoundAssignmentDemo()
    {
        Console.WriteLine("\n--- Compound Assignment Demo ---");

        int total = 100;

        total += 5; 
        Console.WriteLine($"After += 5: {total}");

        total -= 10; 
        Console.WriteLine($"After -= 10: {total}");

        total *= 2; 
        Console.WriteLine($"After *= 2: {total}");

        total /= 5; 
        Console.WriteLine($"After /= 5: {total}");

        total %= 6; 
        Console.WriteLine($"After %= 6: {total}");
    }

    // Part D3
    static void RunBitwiseDemo()
    {
        Console.WriteLine("\n Bitwise Operators Demo");

        int a = 12; 
        int b = 10; 

        int andResult = a & b;
        int orResult = a | b;
        int xorResult = a ^ b;

        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a & b = {andResult}");
        Console.WriteLine($"a | b = {orResult}");  
        Console.WriteLine($"a ^ b = {xorResult}"); 
    }

   
// Part F

static int FindSingleNumber(int[] nums)
    {
        int result = 0;

        foreach (int num in nums)
        {
            result ^= num;
        }

        return result;
    }

    static void RunSingleNumberDemo()
    {
        Console.WriteLine("\nSingle Number Demo");

        int[] nums1 = { 4, 1, 2, 1, 2 };
        Console.WriteLine($"Single number = {FindSingleNumber(nums1)}");

        int[] nums2 = { 2, 2, 3 };
        Console.WriteLine($"Single number = {FindSingleNumber(nums2)}");
    }

}
