using System.Collections.Generic;

namespace Decryption
{
    public class CeasarCipher : ICipher
    {
        public CeasarCipher()
        {

        }
        List<char> CeasarShift = new List<char>
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r','s','t','u','v','w','x','y','z' };

        public string Decode(string message)
        {
            string edited = "";
            List<char> chars = new();
            List<char> changedChars = new();

            string convert = message[0].ToString();
            int shift;
            bool shiftDone = int.TryParse(convert, out shift);
            if (!shiftDone)
            {
                return "First digit is not number!";
            }

            for (int i = 1; i < message.Length; i++) //split message to List of chars
            {
                chars.Add(message[i]);
            }
            foreach (char edit in chars) //change each char
            {
                changedChars.Add(DecodeChar(edit, shift));
            }
            foreach (char back in changedChars) //connects changed chars back to string
            {
                edited += back;
            }

            return edited;
        }
        public string Encode(string message)
        {

            return message;
        }

        private char DecodeChar(char change, int shift) //method how chars are changing
        {
            change = char.ToLower(change);
            if (CeasarShift.Contains(change))
            {
                int index = CeasarShift.IndexOf(change);
                int finalIndex = index + shift;
                while (finalIndex > 25)
                {
                    if (finalIndex > 25)
                    {
                        finalIndex -= 26;
                    }
                }
                change = CeasarShift[finalIndex];
            }
            return change;
        }
    }
}