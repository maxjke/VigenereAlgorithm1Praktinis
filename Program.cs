using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenerePraktinis1
{
    class VigenereCipher
    {
        static char[] Alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
            'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] ASCII = Enumerable.Range('!', '~' - '!' + 1).Select(i => (char)i).ToArray();
        static int ASCIIlen = ASCII.Length;
        static void Main(string[] args)
        {
            Console.WriteLine("Iveskite teksta :");
            string word = Console.ReadLine();

            Console.WriteLine("Iveskite rakta :");
            string key = Console.ReadLine();

            if (word != null && key != null)
            {
                string encryptedText = Encrypt(word.ToUpper(), key.ToUpper());
                Console.WriteLine($"Uzsifruotas tekstas: {encryptedText}");
                string decryptedText = Decrypt(word.ToUpper(), key.ToUpper());
                Console.WriteLine($"Desifruotas tekstas: {decryptedText}");
                string encryptedTextASCII = EncryptASCII(word, key);
                Console.WriteLine($"Sifruotas tekstas su ASCII naudojant masyvus: {encryptedTextASCII}");
                string decryptedTextASCII = DecryptASCII(word, key);
                Console.WriteLine($"Desifruotas tekstas su ASCII naudojant masyvus: {decryptedTextASCII}");
                string encryptedTextASCII2 = EncryptASCII2(word, key);
                Console.WriteLine($"Sifruotas tekstas su ASCII nenaudojant masyvus: {encryptedTextASCII2}");
                string decryptedTextASCII2 = DecryptASCII2(word, key);
                Console.WriteLine($"Desifruotas tekstas su ASCII nenaudojant masyvus: {decryptedTextASCII2}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static string Encrypt(string word, string key)
        {
            string result = "";
            int keyIndex = 0;

            foreach (char c in word)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    int cIndex = Array.IndexOf(Alphabet, c);
                    int kIndex = Array.IndexOf(Alphabet, key[keyIndex]);
                    int letterIndex = (cIndex + kIndex) % Alphabet.Length;
                    result += Alphabet[letterIndex];
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public static string Decrypt(string result, string key)
        {
            string decrypted = "";
            int keyIndex = 0;

            foreach (char c in result)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    int cIndex = Array.IndexOf(Alphabet, c);
                    int kIndex = Array.IndexOf(Alphabet, key[keyIndex]);
                    int letterIndex = (cIndex - kIndex + Alphabet.Length) % Alphabet.Length;
                    decrypted += Alphabet[letterIndex];
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    decrypted += c;
                }
            }

            return decrypted;
        }

        public static string EncryptASCII(string word, string key)
        {
            string result = "";
            int keyIndex = 0;


            foreach (char c in word)
            {
                if (c >= '!' && c <= '~') 
                {
                    int cIndex = Array.IndexOf(ASCII, c); 
                    int kIndex = Array.IndexOf(ASCII, key[keyIndex]); 
                    int letterIndex = (cIndex + kIndex) % ASCIIlen; 
                    result += ASCII[letterIndex]; 
                    keyIndex = (keyIndex + 1) % key.Length; 
                }
                else
                {
                    result += c; 
                }
            }

            return result;
        }

        public static string EncryptASCII2(string word, string key)
        {
            string result = "";
            int keyIndex = 0;
            int alphabetSize = '~' - '!' + 1; 

            foreach (char c in word)
            {
                if (c >= '!' && c <= '~') 
                {
                    int cIndex = c - '!'; 
                    int kIndex = key[keyIndex] - '!'; 
                    int letterIndex = (cIndex + kIndex) % alphabetSize; 
                    result += (char)('!' + letterIndex); 
                    keyIndex = (keyIndex + 1) % key.Length; 
                }
                else
                {
                    result += c; 
                }
            }

            return result;
        }

        public static string DecryptASCII(string word, string key)
        {
            string result = "";
            int keyIndex = 0;


            foreach (char c in word)
            {
                if (c >= '!' && c <= '~') 
                {
                    int cIndex = Array.IndexOf(ASCII, c); 
                    int kIndex = Array.IndexOf(ASCII, key[keyIndex]); 
                    int letterIndex = (cIndex - kIndex + ASCIIlen) % ASCIIlen; 
                    result += ASCII[letterIndex]; 
                    keyIndex = (keyIndex + 1) % key.Length; 
                }
                else
                {
                    result += c; 
                }
            }

            return result;
        }

        public static string DecryptASCII2(string word, string key)
        {
            string result = "";
            int keyIndex = 0;
            int alphabetSize = '~' - '!' + 1;

            foreach (char c in word)
            {
                if (c >= '!' && c <= '~')
                {
                    int cIndex = c - '!';
                    int kIndex = key[keyIndex] - '!';
                    int letterIndex = (cIndex - kIndex + alphabetSize) % alphabetSize;
                    result += (char)('!' + letterIndex);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }

    
}

