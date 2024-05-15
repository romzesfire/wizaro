using System.Security.Cryptography;
using System.Text;
using Magic.DTO.Interfaces;

namespace Magic.Service.Functions;

public class SecurityKeyChecker : ISecurityKeyChecker
{
    private readonly string[] _keyHashes = { "8799224DD26405457637AF3839167EBA56C03004B06594E9A5942251B34BD945" };

    public bool Check(string key)
    {
        var hash = GetHashString(key);
        return _keyHashes.Contains(hash);
    }

    private static string GetHashString(string inputString)
    {
        var hash = new StringBuilder();
        foreach (var b in SHA256.HashData(Encoding.UTF8.GetBytes(inputString)))
            hash.Append(b.ToString("X2"));
        return hash.ToString();
    }
}