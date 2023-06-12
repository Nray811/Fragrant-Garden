namespace PetFragrant_Test.Interface
{
    public interface IHashService
    {
        string MD5Hash(string rawString);
        string MD5HashBase64(string rawString);
        string SHA1Hash(string rawString);
        string SHA512Hash(string rawString);
    }
}
