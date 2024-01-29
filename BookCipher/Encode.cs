namespace BookCipher
{
    public static class Encode
    {
        public static string CodeMessage(string message)
        {
            StreamReader reader = new StreamReader("../../../The Orthodox Study Bible.txt");
            string response = "";
            foreach (char c in message) 
            {
                response += GetFileCoords(RandomNumber(), c, reader) + "-";
            }
            return response;
        }

        private static string GetFileCoords(int line, char c, StreamReader reader)
        {
            reader.DiscardBufferedData(); // Clears the internal buffer
            reader.BaseStream.Seek(0, SeekOrigin.Begin); // Go back to the start of the file

            for (int i = 0; i < line; i++)
            {
                reader.ReadLine();
            }
            while (true)
            {
                string aux = reader.ReadLine();
                

                if (aux.Contains(c)) //verificam daca caracterul care ne intereseaza exista
                {
                    int col = aux.IndexOf(c); //salvam a 2-a coordonata a caracterului
                    return line.ToString() + "_" + col.ToString();
                }
                line++;
            }
        }

        private static int RandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(120000);
            //return 5;
        }
    }
}
