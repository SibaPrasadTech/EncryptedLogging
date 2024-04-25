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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EncryptionTools
{
    public partial class DecryptionTool : Form
    {
        // Path variables for base directory
        private string baseDirectory;
        // Keys
        private static readonly byte[] Key = new byte[32];
        private string encryptedAESKey;
        private string publicKey;
        private string privateKey;
        // Decrypted Key
        private static byte[] decryptedKey = new byte[32];
        private static readonly string ivBoundary = " #?* ";
        private static readonly string logBoundary = "\r\n#?*";

        private void DecryptionTool_Load(object sender, EventArgs e)
        {

        }
        public DecryptionTool()
        {
            InitializeComponent();
            /*using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                Array.Copy(aes.Key, Key, aes.Key.Length);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Export the public key
                publicKey = rsa.ToXmlString(false);

                // Export the private key
                privateKey = rsa.ToXmlString(true);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] encryptedKeyBytes = rsa.Encrypt(Key, false);
                encryptedAESKey = Convert.ToBase64String(encryptedKeyBytes);
            }*/
        }
        // Encryption Key Generation and Saving
        /*public void WriteKeysToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.Filter = "TKF Files|*.tkf|All Files|*.*"; // Set the filter
            saveFileDialog.Title = "Save Keys File";
            saveFileDialog.DefaultExt = "tkf";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                string filePath = saveFileDialog.FileName;
                baseDirectory = Path.GetDirectoryName(filePath);
                // Ensure the file ends with ".tkf"
                if (!filePath.ToLower().EndsWith(".tkf"))
                {
                    filePath += ".tkf";
                }

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("Keys");
                xmlDoc.AppendChild(root);

                // AES Key
                XmlElement aesKeyElement = xmlDoc.CreateElement("AESKey");
                aesKeyElement.InnerText = Convert.ToBase64String(Key);
                root.AppendChild(aesKeyElement);

                // RSA Private Key
                XmlElement privateKeyElement = xmlDoc.CreateElement("RSAPrivateKey");
                privateKeyElement.InnerText = privateKey;
                root.AppendChild(privateKeyElement);

                // Encrypted AES Key
                XmlElement encryptedAESKeyElement = xmlDoc.CreateElement("EncryptedAESKey");
                encryptedAESKeyElement.InnerText = encryptedAESKey;
                root.AppendChild(encryptedAESKeyElement);

                // Save the XML document to the file
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    xmlDoc.Save(sw);
                }
                textBoxInput.Clear();
                statusLabel.Text = "Generated Keys are saved to : " + filePath;
                MessageBox.Show("Keys saved successfully at : " + filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GetPrivateKey_Click(object sender, EventArgs e)
        {
            WriteKeysToFile();
        }
        */
        /*private void SubmitLog_Click(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string inputText = textBoxInput.Text;
            // Do something with the input text (for example, log it)
            // Clear the TextBox
            EncryptLogAppendToFile(inputText);
            textBoxInput.Clear();
            statusLabel.Text = "Submitted log";
        }*/
        public static byte[] FromHexString(string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }
        /*public static byte[] EncryptString(string plainText, byte[] key, byte[] iv)
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
            if (baseDirectory == null)
            {
                baseDirectory = "C:\\";
            }
            string outFile = Path.Combine(baseDirectory, "encrypted_log.dat");
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.GenerateIV();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (StreamWriter outputFileStream = new StreamWriter(outFile, true))
                {
                    // Encrypt the line
                    byte[] encryptedBytes = EncryptString(inputText, aes.Key, aes.IV);
                    string ivHexString = BitConverter.ToString(aes.IV).Replace("-", "");
                    outputFileStream.Write(ivHexString);
                    // Write the IV to the OutputStream
                    //outputFileStream.Write(aes.IV, 0, aes.IV.Length);
                    //outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                    outputFileStream.Write(ivBoundary);
                    //outputFileStream.Write(encryptedBytes.Length, 0, aes.IV.Length)
                    // Write the encrypted text to the OutputStream
                    outputFileStream.Write(BitConverter.ToString(encryptedBytes).Replace("-", ""));
                    outputFileStream.Write(logBoundary);
                    //outputFileStream.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Environment.NewLine.Length);
                }
            } 
            textBoxInput.Clear();
            statusLabel.Text = "Appended the encrypted log to : " + outFile;
        }*/

        // Decryption Process
        private void SelectKeyFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TKF Files|*.tkf|All Files|*.*";
            openFileDialog.Title = "Select Key File";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    XmlNodeList privateKeyNodeList = xmlDoc.GetElementsByTagName("RSAPrivateKey");
                    XmlNodeList encryptedAESKeyNodeList = xmlDoc.GetElementsByTagName("EncryptedAESKey");
                    //XmlNodeList AESKeyNodeList = xmlDoc.GetElementsByTagName("AESKey");
                    //Convert.FromBase64String(AESKeyNodeList[0].InnerText);

                    if (privateKeyNodeList.Count == 1 && encryptedAESKeyNodeList.Count == 1)
                    {
                        // Set RSA private key
                        privateKey = privateKeyNodeList[0].InnerText;
                        // Decrypt encrypted AES key
                        try
                        {
                            string encryptedAESKeyBase64 = encryptedAESKeyNodeList[0].InnerText;
                            byte[] encryptedAESKeyBytes = Convert.FromBase64String(encryptedAESKeyBase64);
                            byte[] decryptedAESKeyBytes = DecryptAESKeyWithPrivateKey(encryptedAESKeyBytes, privateKey);
                            Array.Copy(decryptedAESKeyBytes, decryptedKey, decryptedAESKeyBytes.Length);
                            keyLabel.Text = "Key file loaded successfully!";
                            MessageBox.Show("Key file loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //byte[] decryptedKeyBytes = _rsa.Decrypt(encryptedKeyBytes, false);
                            //Array.Copy(decryptedKeyBytes, Key, decryptedKeyBytes.Length);
                            //MessageBox.Show("AES key decrypted and set successfully.");
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Error decrypting AES key: " + ex.Message);
                            throw ex;
                        }
                        //string encryptedAESKeyBase64 = encryptedAESKeyNodeList[0].InnerText;
                        //byte[] encryptedAESKeyBytes = Convert.FromBase64String(encryptedAESKeyBase64);
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid key file format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading key file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DecryptButton_Click(object sender, EventArgs e)
        {

            if (Key is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select the encrypted file.
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.Filter = "Encrypted Log Files|*.enc|All Files|*.*";
                openFileDialog.Title = "Select Encrypted Log File";
                //openFileDialog.InitialDirectory = EncrFolder;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string encryptedFilePath = openFileDialog.FileName;

                    if (!string.IsNullOrEmpty(encryptedFilePath))
                    {
                        // Decrypt the file and display the decrypted content in the outputTextBox
                        try
                        {
                            string decryptedFilepath = DecryptFromFile(new FileInfo(encryptedFilePath));
                            //decryptPreview.Text = decryptedContent;
                            statusLabel.Text = "Decrypted Log is stored at : " + decryptedFilepath;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error decrypting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        public static string DecryptFromFile(FileInfo file)
        {
            // Construct the file name for the decrypted file.
            string outFile = Path.ChangeExtension(file.FullName.Replace("encrypted", "decrypted"), ".decryptedlog");
            //StringBuilder decryptedText = new StringBuilder();
            using (Aes aes = Aes.Create())
            {
                using (FileStream inputFileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                using (StreamWriter writer = new StreamWriter(outFile))
                {
                    while (inputFileStream.Position < inputFileStream.Length)
                    {
                        // Read the IV
                        byte[] iv = new byte[aes.IV.Length];
                        //inputFileStream.Read(iv, 0, iv.Length);
                        // Read the IV in hexadecimal string format
                        byte[] ivHexStringBytes = new byte[aes.IV.Length * 2]; // Each byte corresponds to 2 characters in the hex string
                        inputFileStream.Read(ivHexStringBytes, 0, ivHexStringBytes.Length);
                        string ivHexString = Encoding.UTF8.GetString(ivHexStringBytes);
                        iv = FromHexString(ivHexString);
                        // Check for the custom boundary
                        byte[] boundary = new byte[5];
                        inputFileStream.Read(boundary, 0, boundary.Length);
                        string boundaryString = Encoding.UTF8.GetString(boundary);
                        if (boundaryString != ivBoundary)
                        {
                            throw new InvalidOperationException("Invalid boundary in the encrypted file.");
                        }
                        // Read the encrypted data until newline or end of file
                        List<byte> encryptedDataList = new List<byte>();
                        int byteDat;
                        while ((byteDat = inputFileStream.ReadByte()) != -1)
                        {
                            if (byteDat == '\r')
                            {
                                // Reached end of line, stop reading
                                int nextByteDat = inputFileStream.ReadByte();
                                if (nextByteDat == '\n')
                                {
                                    byte[] boundaryEnd = new byte[3];
                                    inputFileStream.Read(boundaryEnd, 0, boundaryEnd.Length);
                                    string boundaryEndString = Encoding.UTF8.GetString(boundaryEnd);
                                    if (boundaryEndString == logBoundary.Substring(2,3))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        encryptedDataList.Add((byte)byteDat);
                                        encryptedDataList.Add((byte)nextByteDat);
                                        encryptedDataList.AddRange(boundaryEnd);
                                    }
                                }
                                else
                                {
                                    encryptedDataList.Add((byte)byteDat);
                                    encryptedDataList.Add((byte)nextByteDat);
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
                        string decryptedString = DecryptString(FromHexString(Encoding.UTF8.GetString(encryptedData)), iv);
                        // Append decrypted text to the StringBuilder
                        //decryptedText.AppendLine(decryptedString);
                        writer.WriteLine(decryptedString);
                    }
                }
            }
            return outFile;
        }
        public static string DecryptString(byte[] cipherText, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = decryptedKey;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

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
        private byte[] DecryptAESKeyWithPrivateKey(byte[] encryptedAESKeyBytes, string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                return rsa.Decrypt(encryptedAESKeyBytes, false);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rawXmlencryptedAESKey = textBox2.Text.Trim(); // Trim to remove leading/trailing whitespace
                string encryptedAESKeyBase64;
                if (!string.IsNullOrEmpty(rawXmlencryptedAESKey))
                {
                    try
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(rawXmlencryptedAESKey);
                        XmlNodeList encryptedAESKeyNodeList = xDoc.GetElementsByTagName("EncryptedAESKey");
                        //XmlNodeList privateKeyNodeList = xDoc.GetElementsByTagName("RSAPrivateKey");
                        // Set RSA private key
                        encryptedAESKeyBase64 = encryptedAESKeyNodeList[0].InnerText;
                        // Do something with xDoc...
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show("Invalid Key. Kindly paste a valid key in following xml format. <EncryptedAESKey>Your Key</EncryptedAESKey>" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }
                }
                else
                {
                    MessageBox.Show("Encrypted Key is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string rawXmlPrivateKey = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(rawXmlPrivateKey))
                {
                    try
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(rawXmlPrivateKey);
                        XmlNodeList privateKeyNodeList = xDoc.GetElementsByTagName("RSAPrivateKey");
                        // Set RSA private key
                        privateKey = privateKeyNodeList[0].InnerText;
                        // Do something with xDoc...
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show("Invalid Key. Kindly paste a valid key in following xml format. <RSAPrivateKey>Your Key</RSAPrivateKey>" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }
                }
                else
                {
                    MessageBox.Show("Private Key is empty");
                    return;
                }
                byte[] encryptedAESKeyBytes = Convert.FromBase64String(encryptedAESKeyBase64);
                byte[] decryptedAESKeyBytes = DecryptAESKeyWithPrivateKey(encryptedAESKeyBytes, privateKey);
                Array.Copy(decryptedAESKeyBytes, decryptedKey, decryptedAESKeyBytes.Length);
                keyLabel.Text = "Key file loaded successfully!";
                MessageBox.Show("Keys loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //byte[] decryptedKeyBytes = _rsa.Decrypt(encryptedKeyBytes, false);
                //Array.Copy(decryptedKeyBytes, Key, decryptedKeyBytes.Length);
                //MessageBox.Show("AES key decrypted and set successfully.");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error decrypting AES key: " + ex.Message);
                //throw ex;
            }
        }
        
    }
}
