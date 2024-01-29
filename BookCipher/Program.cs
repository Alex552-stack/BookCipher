namespace BookCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Care este mesajul de codad?");
            string message = Console.ReadLine();
            message = Encode.CodeMessage(message);
            Console.WriteLine($"Mesajul codat este:\n{message}");
            Console.WriteLine($"Mesajul decodat este:\n{Decode.DecodeMessage(message)}");
        }

    }
}
