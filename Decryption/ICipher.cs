namespace Decryption
{
    public interface ICipher
    {
        string Encode(string message);
        string Decode(string message);
    }
}