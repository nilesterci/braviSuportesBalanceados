using BalancedSupport;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var balancedSupport = new BalancedSupportCalculator();
        var result = balancedSupport.Execute("[{({)}]");
        Console.WriteLine(result);
        Console.ReadKey();
    }
}