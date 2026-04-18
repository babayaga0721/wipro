using System;
class program
{
    static void Main()
    {
        int num1, num2, sum;
        Console.WriteLine("enter first no. :");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter second no. :");
        num2 = Convert.ToInt32(Console.ReadLine());
        sum = num1 + num2;
        Console.WriteLine("Sum = " + sum);
    }
}
