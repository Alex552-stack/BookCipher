namespace BookCipher
{
    public static class Decode
    {
        public static string DecodeMessage(string encodedMessage)
        {
            string[] pairs = encodedMessage.Split('-', StringSplitOptions.RemoveEmptyEntries); //delimiteaza prin semnul - mesajul codat
            string decodedMessage = "";
            StreamReader reader = new StreamReader("../../../The Orthodox Study Bible.txt");

            foreach (string pair in pairs)
            {
                string[] parts = pair.Split('_');
                if (parts.Length == 2 && int.TryParse(parts[0], out int line) && int.TryParse(parts[1], out int col))
                {
                    decodedMessage += GetCharAtPosition(line, col, reader);
                }
                else
                {
                    decodedMessage += "?"; // Unknown or malformed code
                }
            }

            return decodedMessage;
        }

        private static char GetCharAtPosition(int line, int column, StreamReader reader)// ia coordonatele caracterului si i-l scoate
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < line; i++)
            {
                reader.ReadLine();
            }

            string lineText = reader.ReadLine();
            
            return lineText[column];
            
        }
    }
}
