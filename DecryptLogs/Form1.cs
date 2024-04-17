using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecryptLogs
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider _rsa;
        const string EncrFolder = @"C:\test\Encrypt\";
        const string KeysFolder = @"C:\test\Keys\";
        // Key
        private static readonly byte[] Key = new byte[32];
        // Encrypted Key

        // Private Key

        public Form1()
        {
            InitializeComponent();
        }
        private void ReadPrivateKeyFromFile(FileInfo file)
        {
            try
            {
                string privateKey = File.ReadAllText(file.FullName);
                _rsa = new RSACryptoServiceProvider();
                _rsa.FromXmlString(privateKey);
                MessageBox.Show("Private key uploaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading private key: " + ex.Message);
            }
        }
        private void ReadAESencKeyFromFile(FileInfo file)
        {
            try
            {
                string encryptedKeyBase64 = File.ReadAllText(file.FullName);
                byte[] encryptedKeyBytes = Convert.FromBase64String(encryptedKeyBase64);
                byte[] decryptedKeyBytes = _rsa.Decrypt(encryptedKeyBytes, false);
                Array.Copy(decryptedKeyBytes, Key, decryptedKeyBytes.Length);
                MessageBox.Show("AES key decrypted and set successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error decrypting AES key: " + ex.Message);
            }
        }
        private void uploadPrivateKeyBtn_Click(object sender, EventArgs e)
        {
            _privateOpenFileDialog.InitialDirectory = KeysFolder;
            if (_decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = _decryptOpenFileDialog.FileName;
                if (fName != null)
                {
                    //DecryptFile(new FileInfo(fName));
                    ReadPrivateKeyFromFile(new FileInfo(fName));
                }
                privateKeyLabel.Text = "Private Key Status : Uploaded";
            }
        }
        private void uploadAESencBtn_Click(object sender, EventArgs e)
        {
            _privateOpenFileDialog.InitialDirectory = KeysFolder;
            if (_decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = _decryptOpenFileDialog.FileName;
                if (fName != null)
                {
                    //DecryptFile(new FileInfo(fName));
                    ReadAESencKeyFromFile(new FileInfo(fName));
                }
                aesKeyLabel.Text = "AES Key Status : Uploaded";
            }
        }
        private void decryptFileBtn_Click(object sender, EventArgs e)
        {
            
            if (_rsa is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select the encrypted file.
                _decryptOpenFileDialog.InitialDirectory = EncrFolder;
                if (_decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = _decryptOpenFileDialog.FileName;
                    if (fName != null)
                    {
                        //DecryptFile(new FileInfo(fName));
                        outputTextBox.Text = DecryptFromFile(new FileInfo(fName),this);
                        decryptionStatusLabel.Text = "Decryption Status : Logs decrypted successfully and stored in the log file path";
                    }
                }
            }
        }
        public static string DecryptFromFile(FileInfo file, Form form)
        {
            // Construct the file name for the decrypted file.
            string outFile = Path.ChangeExtension(file.FullName.Replace("encrypted", "decrypted"), ".txt");
            StringBuilder decryptedText = new StringBuilder();

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;

                using (FileStream inputFileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                using (StreamWriter writer = new StreamWriter(outFile))
                {
                    while (inputFileStream.Position < inputFileStream.Length)
                    {
                        // Read the IV
                        byte[] iv = new byte[aes.IV.Length];
                        inputFileStream.Read(iv, 0, iv.Length);
                        int firstBreak = inputFileStream.ReadByte();
                        int secondBreak = inputFileStream.ReadByte();
                        if (firstBreak == '\r' && secondBreak == '\n')
                        {

                        }

                        // Read the encrypted data until newline or end of file
                        List<byte> encryptedDataList = new List<byte>(); // Use a list to collect all bytes
                        int byteDat;
                        while ((byteDat = inputFileStream.ReadByte()) != -1)
                        {
                            if (byteDat == '\r')
                            {
                                // Reached end of line, stop reading
                                int nextByteDat = inputFileStream.ReadByte();
                                if (nextByteDat == '\n')
                                {
                                    break;
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                encryptedDataList.Add((byte)byteDat); // Add each byte to the list
                            }

                        }

                        // Convert list to byte array
                        byte[] encryptedData = encryptedDataList.ToArray();

                        // Decrypt the encrypted data
                        string decryptedString = DecryptString(encryptedData, iv);
                        // Append decrypted text to the StringBuilder
                        decryptedText.AppendLine(decryptedString);
                        writer.WriteLine(decryptedString);
                    }
                }
            }
            return decryptedText.ToString();
        }
        public static string DecryptString(byte[] cipherText, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cryptoStream))
                {
                    try
                    {
                        return reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        // Handle decryption exception here (e.g., log error, return null)
                        Console.WriteLine("Decryption failed: " + ex.Message);
                        return null; // Or any other appropriate value based on your needs
                    }
                }
            }
        }

        private void privateKeyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
