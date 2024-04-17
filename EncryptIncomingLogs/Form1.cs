using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EncryptIncomingLogs
{
    public partial class EncryptIncomingLog : Form
    {
        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string EncrFolder = @"C:\test\Encrypt\";

        // AES - Key
        // Generate a random key
        private static readonly byte[] Key = new byte[32];
        private string publicKey;
        private string privateKey;
        // Public key file
        const string privateKeyFilePath = @"C:\test\Keys\rsaPrivateKey.txt";
        const string encryptedAESKeyPath = @"C:\test\Keys\encAESKey.txt";

        private void EncryptIncomingLog_Load(object sender, EventArgs e)
        {

        }
        public EncryptIncomingLog()
        {
            InitializeComponent();
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                Array.Copy(aes.Key, Key, aes.Key.Length);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Export the public key
                publicKey = rsa.ToXmlString(false);
                //Console.WriteLine("Public Key:");
                //Console.WriteLine(publicKey);

                // Export the private key
                privateKey = rsa.ToXmlString(true);
                //Console.WriteLine("\nPrivate Key:");
                //Console.WriteLine(privateKey);
            }
        }

        

        static byte[] EncryptAESWithPublicKey(byte[] plaintextBytes, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                return rsa.Encrypt(plaintextBytes, false);
            }
        }

        private void GetEncryptedKey_Click(object sender, EventArgs e)
        {
            byte[] encryptedKeyBytes = EncryptAESWithPublicKey(Key, publicKey);
            string encryptedBase64 = Convert.ToBase64String(encryptedKeyBytes);
            File.WriteAllText(encryptedAESKeyPath, encryptedBase64);
        }

        static void WritePrivateKeyToFile(string privateKey, string filePath)
        {
            File.WriteAllText(filePath, privateKey);
            //textBoxInput.Clear();
        }

        private void GetPrivateKey_Click(object sender, EventArgs e)
        {
            //string outFile = Path.Combine(EncrFolder, Path.ChangeExtension(file.Name, ".dat"));
            //string privateKeyFilePath = "privateKey.xml";
            WritePrivateKeyToFile(privateKey, privateKeyFilePath);
        }

        public static byte[] EncryptString(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream
                            swEncrypt.Write(plainText);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        private void EncryptLogAppendToFile(string inputText)
        {
            // Get the text from the TextBox
            //string inputText = textBoxInput.Text;
            // Do something with the input text (for example, log it)
            // Clear the TextBox
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                string outFile = Path.Combine(EncrFolder, "encrypted_log.dat");

                using (FileStream outputFileStream = new FileStream(outFile, FileMode.Append, FileAccess.Write))
                {
                    // Generate a random IV for each encryption operation
                    aes.GenerateIV();

                    // Encrypt the line
                    byte[] encryptedBytes = EncryptString(inputText, aes.Key, aes.IV);

                    // Write the IV to the OutputStream
                    outputFileStream.Write(aes.IV, 0, aes.IV.Length);
                    outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                    //outputFileStream.Write(encryptedBytes.Length, 0, aes.IV.Length)
                    // Write the encrypted text to the OutputStream
                    outputFileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                }
            } 
            textBoxInput.Clear();
            statusLabel.Text = "Submitted log";
        }

        private void SubmitLog_Click(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string inputText = textBoxInput.Text;
            // Do something with the input text (for example, log it)
            // Clear the TextBox
            EncryptLogAppendToFile(inputText);
            textBoxInput.Clear();
            statusLabel.Text = "Submitted log";
        }
    }
}
