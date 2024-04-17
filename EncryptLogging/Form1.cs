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

namespace EncryptLogging
{
    public partial class encryptForm : Form
    {
        // Declare CspParameters and RsaCryptoServiceProvider
        // objects with global scope of your Form class.
        readonly CspParameters _cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
        // Key
        private static readonly byte[] Key = new byte[32];
        // Generate a random key
        


        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string EncrFolder = @"C:\test\Encrypt\";
        const string DecrFolder = @"C:\test\Decrypt\";
        const string SrcFolder = @"C:\test\Docs\";

        // Public key file
        const string PubKeyFile = @"C:\test\Keys\rsaPublicKey.txt";
        

        // Key container name for
        // private/public key value pair.
        const string KeyName = "Key01";

        public encryptForm()
        {
            InitializeComponent();
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                Array.Copy(aes.Key, Key, aes.Key.Length);
            }
        }

        public static void EncryptAndAppendToFile(FileInfo file)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                string outFile = Path.Combine(EncrFolder, Path.ChangeExtension(file.Name, ".dat"));

                using (FileStream outputFileStream = new FileStream(outFile, FileMode.Append, FileAccess.Write))
                {
                   
                        
                            foreach (string line in File.ReadLines(file.FullName))
                            {
                                // Generate a random IV for each encryption operation
                                aes.GenerateIV();

                                // Encrypt the line
                                byte[] encryptedBytes = EncryptString(line, aes.Key, aes.IV);

                                // Write the IV to the CryptoStream
                                outputFileStream.Write(aes.IV, 0, aes.IV.Length);
                                outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                                //outputFileStream.Write(encryptedBytes.Length, 0, aes.IV.Length);

                                // Write the encrypted text to the CryptoStream
                                outputFileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                                outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                            }
                        
                    
                }
            }
        }

        // Helper method to encrypt a string
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

        public static void DecryptFromFile(FileInfo file)
        {
            // Construct the file name for the decrypted file.
            string outFile = Path.ChangeExtension(file.FullName.Replace("Encrypt", "Decrypt"), ".txt");

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
                        if(firstBreak == '\r' && secondBreak == '\n')
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
                        writer.WriteLine(decryptedString);
                    }
                }
            }
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

        private void buttonDecryptFile_Click(object sender, EventArgs e)
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
                        DecryptFromFile(new FileInfo(fName));
                    }
                }
            }
        }

        void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            // Save the public key created by the RSA
            // to a file. Caution, persisting the
            // key to a file is a security risk.
            Directory.CreateDirectory(EncrFolder);
            using (var sw = new StreamWriter(PubKeyFile, false))
            {
                sw.Write(_rsa.ToXmlString(false));
            }
        }

        void buttonImportPublicKey_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(PubKeyFile))
            {
                _cspp.KeyContainerName = KeyName;
                _rsa = new RSACryptoServiceProvider(_cspp);

                string keytxt = sr.ReadToEnd();
                _rsa.FromXmlString(keytxt);
                _rsa.PersistKeyInCsp = true;

                label1.Text = _rsa.PublicOnly
                    ? $"Key: {_cspp.KeyContainerName} - Public Only"
                    : $"Key: {_cspp.KeyContainerName} - Full Key Pair";
            }
        }

        private void buttonGetPrivateKey_Click(object sender, EventArgs e)
        {
            _cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };

            label1.Text = _rsa.PublicOnly
                ? $"Key: {_cspp.KeyContainerName} - Public Only"
                : $"Key: {_cspp.KeyContainerName} - Full Key Pair";
        }

        private void buttonCreateAsmKeys_Click(object sender, EventArgs e)
        {
            // Stores a key pair in the key container.
            _cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };

            label1.Text = _rsa.PublicOnly
                ? $"Key: {_cspp.KeyContainerName} - Public Only"
                : $"Key: {_cspp.KeyContainerName} - Full Key Pair";
        }

        private void buttonEncryptFile_Click(object sender, EventArgs e)
        {
            if (_rsa is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select a file to encrypt.
                _encryptOpenFileDialog.InitialDirectory = SrcFolder;
                if (_encryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = _encryptOpenFileDialog.FileName;
                    if (fName != null)
                    {
                        // Pass the file name without the path.
                        EncryptAndAppendToFile(new FileInfo(fName));
                    }
                }
            }
        }

        private void EncryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric encryption of the data.
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform transform = aes.CreateEncryptor();

                // Use RSACryptoServiceProvider to
                // encrypt the AES key.
                // rsa is previously instantiated:
                //    rsa = new RSACryptoServiceProvider(cspp);
                byte[] keyEncrypted = _rsa.Encrypt(aes.Key, false);

                // Create byte arrays to contain
                // the length values of the key and IV.
                int lKey = keyEncrypted.Length;
                byte[] LenK = BitConverter.GetBytes(lKey);
                int lIV = aes.IV.Length;
                byte[] LenIV = BitConverter.GetBytes(lIV);

                // Write the following to the FileStream
                // for the encrypted file (outFs):
                // - length of the key
                // - length of the IV
                // - encrypted key
                // - the IV
                // - the encrypted cipher content

                // Change the file's extension to ".enc"
                string outFile =
                    Path.Combine(EncrFolder, Path.ChangeExtension(file.Name, ".enc"));

                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    outFs.Write(LenK, 0, 4);
                    outFs.Write(LenIV, 0, 4);
                    outFs.Write(keyEncrypted, 0, lKey);
                    outFs.Write(aes.IV, 0, lIV);

                    // Now write the cipher text using
                    // a CryptoStream for encrypting.
                    using (var outStreamEncrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        // By encrypting a chunk at
                        // a time, you can save memory
                        // and accommodate large files.
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes can be any arbitrary size.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (var inFs = new FileStream(file.FullName, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamEncrypted.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            } while (count > 0);
                        }
                        outStreamEncrypted.FlushFinalBlock();
                    }
                }
            }
        }

        private void DecryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric decryption of the data.
            Aes aes = Aes.Create();

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construct the file name for the decrypted file.
            string outFile =
                Path.ChangeExtension(file.FullName.Replace("Encrypt", "Decrypt"), ".txt");

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (var inFs = new FileStream(file.FullName, FileMode.Open))
            {
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start position of
                // the cipher text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Aes key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                Directory.CreateDirectory(DecrFolder);
                // Use RSACryptoServiceProvider
                // to decrypt the AES key.
                byte[] KeyDecrypted = _rsa.Decrypt(KeyEncrypted, false);

                // Decrypt the key.
                ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];

                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (var outStreamDecrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);
                        } while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                    }
                }
            }
        }

        private void _decryptOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
