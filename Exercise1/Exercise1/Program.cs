namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input integer: ");
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Wrong number format");
            }
            catch (OverflowException fe)
            {
                Console.WriteLine("Number is too big");
            }
            finally
            {
                Console.WriteLine("This is a message");
            }

        }
    }
}