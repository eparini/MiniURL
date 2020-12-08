using System;
using System.Security.Cryptography;
using System.Text;

namespace MiniURL.Services
{
    public static class URLGeneratorService
    {
        public static string GenerateMiniURL(string longURL)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                try
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(longURL));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString().Substring(0, 7);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
