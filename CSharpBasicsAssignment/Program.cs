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
    // Shared field: يمكن لجميع الدوال static داخل Program الوصول إليه.
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

    // Part B: Variables, Types, Casting, Boxing and Parsing
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

        // Implicit conversion: int to long
        int number = 100;
        long bigNumber = number;

        // Implicit conversion: char to int
        char letter = 'A';
        int letterCode = letter;

        Console.WriteLine($"int to long = {bigNumber}");
        Console.WriteLine($"char to int = {letterCode}");

        // Explicit cast removes the decimal part.
        double value = 9.7;
        int truncated = (int)value;

        // Convert.ToInt32 rounds to the nearest integer.
        int rounded = Convert.ToInt32(value);

        Console.WriteLine($"Explicit cast = {truncated}");
        Console.WriteLine($"Convert.ToInt32 = {rounded}");

        // Integer division versus floating-point division
        int integerDivision = 5 / 2;
        double doubleDivision = 5.0 / 2;

        Console.WriteLine($"5 / 2 = {integerDivision}");
        Console.WriteLine($"5.0 / 2 = {doubleDivision}");

        // Boxing: converting a value type into object.
        int originalNumber = 50;
        object boxedNumber = originalNumber;

        Console.WriteLine($"Boxed value = {boxedNumber}");

        // Unboxing: converting object back to int.
        int unboxedNumber = (int)boxedNumber;

        Console.WriteLine($"Unboxed value = {unboxedNumber}");

        // Parse: converts valid numeric text into an integer.
        string validText = "42";
        int parsedNumber = int.Parse(validText);

        Console.WriteLine($"Parsed number = {parsedNumber}");

        // TryParse: handles invalid input without throwing a parsing exception.
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

        // float cannot be implicitly converted to decimal.
        // decimal convertedValue = floatValue; // Compile-time error.

        float floatValue = 12.5f;
        decimal convertedValue = (decimal)floatValue;

        Console.WriteLine($"float value = {floatValue}");
        Console.WriteLine($"Converted decimal value = {convertedValue}");
    }

    // Part C: Value Type example
    struct Point
    {
        public int X;
        public int Y;
    }

    static void RunValueVsReferenceDemo()
    {
        Console.WriteLine("\n--- Value Type Demo ---");

        Point p1 = new Point { X = 1, Y = 2 };

        // Copies the values of X and Y into a separate struct.
        Point p2 = p1;

        p2.X = 99;

        Console.WriteLine($"p1.X = {p1.X}"); // 1
        Console.WriteLine($"p2.X = {p2.X}"); // 99
    }

    // Part C: Reference Type example
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

        // Copies the reference, not a new Order object.
        Order o2 = o1;

        o2.IsPaid = true;

        Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
        Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

        // Order is a class, so assigning it to object does not box it.
        object boxedOrder = o1;

        Order o3 = (Order)boxedOrder;

        Console.WriteLine(
            $"Same instance: {object.ReferenceEquals(o1, o3)}");

        o2.PrintSummary();
    }

    // Part D: Shared field accessible by both static methods.
    static void ReadSharedNumber()
    {
        Console.WriteLine($"Shared number = {sharedNumber}");
    }

    static void ReadSharedNumberAgain()
    {
        Console.WriteLine($"Shared number again = {sharedNumber}");
    }

// Part D1: Scope
static void RunScopeDemo()
    {
        Console.WriteLine("\n--- Scope Demo ---");

        // A local variable can be accessed only inside its method.
        int localNumber = 5;
        Console.WriteLine($"Local number = {localNumber}");

        // A loop variable is accessible only inside the for loop.
        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;

            Console.WriteLine($"i = {i}");
            Console.WriteLine($"insideLoop = {insideLoop}");
        }

        // The following lines cause compile-time errors
        // because i and insideLoop are out of scope.
        // Console.WriteLine(i);
        // Console.WriteLine(insideLoop);
    }

    // Part D2: Compound Assignment
    static void RunCompoundAssignmentDemo()
    {
        Console.WriteLine("\n--- Compound Assignment Demo ---");

        int total = 100;

        total += 5; // Same as: total = total + 5
        Console.WriteLine($"After += 5: {total}");

        total -= 10; // Same as: total = total - 10
        Console.WriteLine($"After -= 10: {total}");

        total *= 2; // Same as: total = total * 2
        Console.WriteLine($"After *= 2: {total}");

        total /= 5; // Same as: total = total / 5
        Console.WriteLine($"After /= 5: {total}");

        total %= 6; // Same as: total = total % 6
        Console.WriteLine($"After %= 6: {total}");
    }

    // Part D3: Bitwise Operators
    static void RunBitwiseDemo()
    {
        Console.WriteLine("\n--- Bitwise Operators Demo ---");

        int a = 12; // Binary: 1100
        int b = 10; // Binary: 1010

        int andResult = a & b;
        int orResult = a | b;
        int xorResult = a ^ b;

        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a & b = {andResult}"); // 8
        Console.WriteLine($"a | b = {orResult}");  // 14
        Console.WriteLine($"a ^ b = {xorResult}"); // 6

        // Bitwise & compares the bits of both operands.
        // Logical && works with Boolean expressions and short-circuits
        // when the left operand is false.
    }

   
// Part F: LeetCode 136 - Single Number

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
        Console.WriteLine("\n--- Single Number Demo ---");

        int[] nums1 = { 4, 1, 2, 1, 2 };
        Console.WriteLine($"Single number = {FindSingleNumber(nums1)}");

        int[] nums2 = { 2, 2, 3 };
        Console.WriteLine($"Single number = {FindSingleNumber(nums2)}");
    }

}
