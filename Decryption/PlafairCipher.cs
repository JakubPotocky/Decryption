using System.Collections.Generic;
using Avalonia;

namespace Decryption
{
    public class PlayfairCipher
    {
        public PlayfairCipher()
        {
            PlayfairMatrix = new char[5, 5];
        }
        private char[,] PlayfairMatrix;
        List<char> AllPlayfair = new List<char>
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r','s','t','u','v','w','x','y','z' };
        public bool CreateMatrix(string word)
        {
            word = word.ToLower();
            List<char> chars = new();

            for (int i = 0; i < word.Length; i++) //split message to List of chars
            {
                if (chars != null)
                {
                    foreach (char c in chars)
                    {
                        if (c == word[i])
                        {
                            return false; //false
                        }

                    }
                }
                chars.Add(word[i]);
            }
            int row = 0; //riadok
            int column = 0; //stĺpec
            foreach (char c in chars)
            {
                if (row == 5)
                {
                    row = 0;
                    column++;
                }
                PlayfairMatrix[column, row] = c;
                AllPlayfair.Remove(c);
                row++;
            }

            if (AllPlayfair.Contains('j'))
            {
                AllPlayfair.Remove('j');
            }

            // until here it's fine
            foreach (char c in AllPlayfair)
            {
                if (row == 5 && column == 4)
                    break;
                if (row == 5)
                {
                    row = 0;
                    column++;
                }
                PlayfairMatrix[column, row] = c;
                //AllPlayfair.Remove(c);
                row++;
            }

            return true; //true
        }
        public string Decode(string message)
        {
            message = message.ToLower();
            message = message.Replace(" ","");
            string decodedMessage = "";
            List<char> chars = new();

            chars.Add(message[0]);
            for(int i = 1; i < message.Length; i++)
            {
                if(message[i-1] == message[i])
                {
                    chars.Add('x');
                    chars.Add(message[i]);
                }   
                else
                {
                    chars.Add(message[i]);
                } 
            }
            if(chars.Count % 2 != 0)
            {
                chars.Add('x');
            }
            for(int i = 0; i < chars.Count; i+=2)
            {
                decodedMessage += DecodeChars(chars[i],chars[i+1]);
            }
            return decodedMessage;
        }
        public string Encode(string message)
        {
            message = message.ToLower();
            message = message.Replace(" ","");
            string decodedMessage = "";
            List<char> chars = new();

            for(int i = 0; i < message.Length; i+=2)
            {
                decodedMessage += EncodeChars(message[i],message[i+1]);
            }
            chars.Add(decodedMessage[0]);
            int shift = 0;
            for(int i = 1; i < decodedMessage.Length-1; i++)
            {
                if(decodedMessage[i-1] == decodedMessage[i+1] && 
                decodedMessage[i] == 'x' )
                {
                    shift++;
                }
                else
                {
                    chars.Add(decodedMessage[i]);
                }
            }
            chars.Add(decodedMessage[decodedMessage.Length-1]); //shift -> 1
            string newMessage = "";
            foreach(char c in chars)
            {
                newMessage += c.ToString();
            }
            return newMessage;
        }

        private string DecodeChars(char change1, char change2) //method how chars are changing
        {
            // column, row -> stlpec, riadok ==> item1, item2
            (int,int) char1pos = FindIndex(change1);
            (int,int) char2pos = FindIndex(change2);
            //if(char1/2pos.Item1 == -1) keep the letter?

            int char1column = char1pos.Item1;
            int char1row = char1pos.Item2;
            int char2column = char2pos.Item1;
            int char2row = char2pos.Item2;

            if( char1column >= 0 && char2column >= 0 )
            {
                if(char1row == char2row)
                {
                    //PlayfairMatrix[]
                    char1column++;
                    char2column++;
                    if(char1column > 4)
                    {
                        char1column = 0;
                    }
                    if(char2column > 4)
                    {
                        char2column = 0;
                    }
                    char return1 = PlayfairMatrix[char1column, char1row];
                    char return2 = PlayfairMatrix[char2column, char2row];
                    string r = "";
                    r += return1.ToString();
                    r+= return2.ToString();
                    return r;
                }   

                if(char1column == char2column)
                {
                    char1row++;
                    char2row++;
                    if(char1row > 4)
                    {
                        char1row = 0;
                    }
                    if(char2row > 4)
                    {
                        char2row = 0;
                    }
                    char return1 = PlayfairMatrix[char1column, char1row];
                    char return2 = PlayfairMatrix[char2column, char2row];
                    string r = "";
                    r += return1.ToString();
                    r+= return2.ToString();
                    return r;
                }

                else
                {
                    string r ="";
                    r += PlayfairMatrix[char1column, char2row].ToString();
                    r += PlayfairMatrix[char2column, char1row].ToString();
                    return r;
                }
            }
            else
            return "XX";
        }

        private string EncodeChars(char change1, char change2) //method how chars are changing
        {
            // column, row -> stlpec, riadok ==> item1, item2
            (int,int) char1pos = FindIndex(change1);
            (int,int) char2pos = FindIndex(change2);
            //if(char1/2pos.Item1 == -1) keep the letter?

            int char1column = char1pos.Item1;
            int char1row = char1pos.Item2;
            int char2column = char2pos.Item1;
            int char2row = char2pos.Item2;

            if( char1column >= 0 && char2column >= 0 )
            {
                if(char1row == char2row)
                {
                    //PlayfairMatrix[]
                    char1column--;
                    char2column--;
                    if(char1column < 0)
                    {
                        char1column = 4;
                    }
                    if(char2column < 0)
                    {
                        char2column = 4;
                    }
                    char return1 = PlayfairMatrix[char1column, char1row];
                    char return2 = PlayfairMatrix[char2column, char2row];
                    string r = "";
                    r += return1.ToString();
                    r+= return2.ToString();
                    return r;
                }   

                if(char1column == char2column)
                {
                    char1row--;
                    char2row--;
                    if(char1row < 0)
                    {
                        char1row = 4;
                    }
                    if(char2row < 0)
                    {
                        char2row = 4;
                    }
                    char return1 = PlayfairMatrix[char1column, char1row];
                    char return2 = PlayfairMatrix[char2column, char2row];
                    string r = "";
                    r += return1.ToString();
                    r+= return2.ToString();
                    return r;
                }

                else
                {
                    string r ="";
                    r += PlayfairMatrix[char1column, char2row].ToString();
                    r += PlayfairMatrix[char2column, char1row].ToString();
                    return r;
                }
            }
            else
            return "XX";
        }

        public (int, int) FindIndex(char target)
        {
            if(target == 'j') target = 'i'; //bleeeee, this can't be like this -> every J will be I from now on lol, if there is J in keyword then it should be different, maybe add private bool which checks if the keyword uses J or make a list and add every index of char in message which will include J
            for (int i = 0; i < PlayfairMatrix.GetLength(0); i++) //i = column
            {
                for (int j = 0; j < PlayfairMatrix.GetLength(1); j++) //j = row
                {
                    if (PlayfairMatrix[i, j] == target)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // Return (-1, -1) if the character is not found
        }
    }
}