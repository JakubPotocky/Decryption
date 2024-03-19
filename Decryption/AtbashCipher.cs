using System.Collections.Generic;

namespace Decryption
{
    public class AtbashCipher : ICipher
    {
        public AtbashCipher()
        {

        }
        private Dictionary<char, char> AtbashMethod = new Dictionary<char, char>
        {
            { 'a', 'z' },
            { 'b', 'y' },
            { 'c', 'x' },
            { 'd', 'w' },
            { 'e', 'v' },
            { 'f', 'u' },
            { 'g', 't' },
            { 'h', 's' },
            { 'i', 'r' },
            { 'j', 'q' },
            { 'k', 'p' },
            { 'l', 'o' },
            { 'm', 'n' },
            { 'z', 'a' },
            { 'y', 'b' },
            { 'x', 'c' },
            { 'w', 'd' },
            { 'v', 'e' },
            { 'u', 'f' },
            { 't', 'g' },
            { 's', 'h' },
            { 'r', 'i' },
            { 'q', 'j' },
            { 'p', 'k' },
            { 'o', 'l' },
            { 'n', 'm' }
        };

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
                changedChars.Add(changeChar(edit));
            }
            foreach (char back in changedChars) //connects changed chars back to string
            {
                edited += back;
            }

            return edited;
        }
        public string Decode(string message)
        {
            string edited = string.Empty;
            List<char> chars = new();
            List<char> changedChars = new();

            for (int i = 0; i < message.Length; i++) //split message to List of chars
            {
                chars.Add(message[i]);
            }
            foreach (char edit in chars) //change each char
            {
                changedChars.Add(changeChar(edit));
            }
            foreach (char back in changedChars) //connects changed chars back to string
            {
                edited += back;
            }

            return edited;
        }

        private char changeChar(char change) //method how chars are changing
        {
            change = char.ToLower(change);
            if (AtbashMethod.ContainsKey(change))
            {
                change = AtbashMethod[change];
            }
            return change;
        }
    }
}