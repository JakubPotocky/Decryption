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
        List<char> CeasarShiftReverse = new List<char>
        { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };
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
            string edited = "";
            List<char> chars = new();
            List<char> changedChars = new();

            for (int i = 0; i < message.Length; i++) //split message to List of chars
            {
                chars.Add(message[i]);
            }
            foreach (char edit in chars) //change each char
            {
                changedChars.Add(EncodeChar(edit));
            }
            foreach (char back in changedChars) //connects changed chars back to string
            {
                edited += back;
            }

            return edited;
        }

        private char DecodeChar(char change, int shift) //method how chars are changing
        {
            change = char.ToLower(change);
            if (CeasarShift.Contains(change))
            {
                int index = CeasarShift.IndexOf(change);
                int finalIndex = index + shift;
                /*while (finalIndex > 25)
                {
                    if (finalIndex > 25)
                    {
                        finalIndex -= 26;
                    }
                }*/
                finalIndex %= 26; // instead of this while loop this works the same way
                change = CeasarShift[finalIndex];
            }
            return change;
        }

        private char EncodeChar(char change) //method how chars are changing
        {
            change = char.ToLower(change);
            if (CeasarShiftReverse.Contains(change))
            {
                int index = CeasarShiftReverse.IndexOf(change);
                int finalIndex = index + 1;
                finalIndex %= 26; // instead of this while loop this works the same way
                change = CeasarShiftReverse[finalIndex];
            }
            return change;
        }
    }
}