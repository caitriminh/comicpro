using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace ComicPro2019
{
    public class Config
    {
        public static string GetSerialHdd()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (var o in searcher.Get())
            {
                var wmiHd = (ManagementObject)o;
                return wmiHd["SerialNumber"].ToString();
            }
            return null;
        }

        public static string CreateMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private static readonly Encoding Encoding = Encoding.UTF8;
        public static string Key = "8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO";
        public static string Encrypt(string plainText)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                aes.Key = Encoding.GetBytes(Key);
                aes.GenerateIV();

                ICryptoTransform aesEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] buffer = Encoding.GetBytes(plainText);

                string encryptedText = Convert.ToBase64String(aesEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

                var mac = BitConverter.ToString(HmacSha256(Convert.ToBase64String(aes.IV) + encryptedText, Key)).Replace("-", "").ToLower();

                var keyValues = new Dictionary<string, object>
                {
                    { "iv", Convert.ToBase64String(aes.IV) },
                    { "value", encryptedText },
                    { "mac", mac }
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                return Convert.ToBase64String(Encoding.GetBytes(serializer.Serialize(keyValues)));
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }

        static byte[] HmacSha256(string data, string key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.GetBytes(key)))
            {
                return hmac.ComputeHash(Encoding.GetBytes(data));
            }
        }

        public static string Decrypt(string plainText)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.Key = Encoding.GetBytes(Key);

                // Base 64 decode
                byte[] base64Decoded = Convert.FromBase64String(plainText);
                string base64DecodedStr = Encoding.GetString(base64Decoded);

                // JSON Decode base64Str
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var payload = ser.Deserialize<Dictionary<string, string>>(base64DecodedStr);

                aes.IV = Convert.FromBase64String(payload["iv"]);

                ICryptoTransform aesDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] buffer = Convert.FromBase64String(payload["value"]);

                return Encoding.GetString(aesDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception)
            {
                // throw new Exception("Error decrypting: " + e.Message);
                return "";
            }
        }
    }
}
