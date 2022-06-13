using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tourist__Office
{
    class Verification
    {

        public static string GetSHA256Hash(string input) // Хэширует входную строку и возвращает хеш в виде шестнадцатеричной строки из 128 символов
        {
            //// Создаем новый экземпляр объекта MD5CryptoServiceProvider.
            //SHA256CryptoServiceProvider SHA256Hasher = new SHA256CryptoServiceProvider();

            //// Преобразуем входную строку в байтовый массив и вычисляем хеш.
            //byte[] data = SHA256Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            //// Создаем новый Stringbuilder для сбора байтов и создания строки.
            //StringBuilder sBuilder = new StringBuilder();

            //// Перебираем каждый байт хэшированных данных 
            //// и форматируем каждый как шестнадцатеричную строку.
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sBuilder.Append(data[i].ToString());
            //    //sBuilder.Append(data[i].ToString("x2"));
            //}

            //// Возвращаем шестнадцатеричную строку.
            //return sBuilder.ToString();

            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    //From String to byte array
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    return hash;
                }

            }
        }


        public static bool VerifySHA256Hash(string input, string hash) // Проверяет хэш (из базы данных) на соответствие строке (из поля ввода)
        {
            // Хэшируем ввод.
            string hashOfInput = GetSHA256Hash(input);

            // Создаем StringComparer для сравнения хэшей.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            // Сравниваем два хэша.
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true; // Хэши равны.
            }
            else
            {
                return false; // Не равны.
            }
        }
    }

}

