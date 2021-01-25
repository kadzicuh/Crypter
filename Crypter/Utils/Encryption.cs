using System.Security.Cryptography;
using System.Text;

namespace Crypter.Utils
{
    internal class Encryption
    {
        internal byte[] AES(byte[] _Bytes, string _IKey)
        {
            using (AesCryptoServiceProvider _AES = new AesCryptoServiceProvider())
            {
                using (SHA256CryptoServiceProvider _SHA256 = new SHA256CryptoServiceProvider())
                {
                    byte[] _Key = _SHA256.ComputeHash(Encoding.BigEndianUnicode.GetBytes(_IKey));
                    byte[] _Salt = new byte[] { 0xAA, 0xFF, 0xBB, 0xCF, 0xCC, 0xDD, 0xDF, 0xAF };

                    using (Rfc2898DeriveBytes _Rfc2898DeriveBytes = new Rfc2898DeriveBytes(_Key, _Salt, 0x3E8))
                    {
                        _AES.KeySize = 0x100;
                        _AES.BlockSize = 0x80;
                        _AES.Key = _Rfc2898DeriveBytes.GetBytes(_AES.KeySize / 0x8);
                        _AES.IV = _Rfc2898DeriveBytes.GetBytes(_AES.BlockSize / 0x8);
                        _AES.Mode = CipherMode.ECB;
                        _AES.Padding = PaddingMode.PKCS7;

                        return _AES.CreateEncryptor().TransformFinalBlock(_Bytes, 0x0, _Bytes.Length);
                    }
                }
            }
        }
    }
}