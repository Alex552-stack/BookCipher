namespace BookCipher
{
    public static class Decode
    {
        public static string DecodeMessage(string encodedMessage)
        {
            string[] pairs = encodedMessage.Split('-', StringSplitOptions.RemoveEmptyEntries);
            string decodedMessage = "";
            using (StreamReader reader = new StreamReader("../../../The Orthodox Study Bible.txt"))
            {
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
            }
            return decodedMessage;
        }

        private static char GetCharAtPosition(int line, int column, StreamReader reader)
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < line; i++)
            {
                if (reader.ReadLine() == null) return '?'; // Line not found
            }

            string lineText = reader.ReadLine();
            if (lineText != null && column < lineText.Length)
            {
                return lineText[column];
            }
            return '?'; // Column not found or line not found
        }
    }
}
