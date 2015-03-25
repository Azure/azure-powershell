// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library
{
    /// <summary>
    /// represents the different outcomes of a persist/retrieve key operation on a keystore
    /// </summary>
    public enum KeyStoreOperationStatus
    {
        PERSIST_EMPTY_KEY,
        PERSIST_EMPTY_FILENAME,
        PERSIST_FILE_ALREADY_EXISTS,
        PERSIST_SUCCESS,

        RETRIEVE_EMPTY_FILENAME,
        RETRIEVE_FILE_DOES_NOT_EXIST,
        RETRIEVE_FILESTREAM_INVALID,
        RETRIEVE_FILESREAM_EMPTY,
        RETRIEVE_EMPTY_KEY,
        RETRIEVE_SUCCESS,

        VALIDATE_FAILED,

        FAILED,
        SUCCESS
    }
    public class LocalKeyStoreManager : IKeyManager
    {
        #region properties
        private string KeyStorefilePath { get; set; }
        private bool OverwriteFileIfExists { get; set; }
        #endregion

        #region ctor
        public LocalKeyStoreManager(string keyStorefilePath, bool overwriteFileIfExists = true)
        {
            if (string.IsNullOrEmpty(keyStorefilePath))
            {
                throw new ArgumentNullException("keyStorefilePath");
            }

            this.KeyStorefilePath = keyStorefilePath;
            this.OverwriteFileIfExists = overwriteFileIfExists;
        }
        #endregion

        #region interface implementation

        /// <summary>
        /// This method encrypts and saves the given string with the given filename in the appdata folder
        /// </summary>
        /// <param name="keyValue">the string that needs to be encrypted</param>
        /// <param name="fileName">the filename that can be used</param>
        /// <returns></returns>
        public KeyStoreOperationStatus PersistKey(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
                return KeyStoreOperationStatus.PERSIST_EMPTY_KEY;

            if (File.Exists(KeyStorefilePath) && !OverwriteFileIfExists)
                return KeyStoreOperationStatus.PERSIST_FILE_ALREADY_EXISTS;

            var keyValueToEncrypt = UnicodeEncoding.ASCII.GetBytes(keyValue);
            byte[] entropy = GenerateEntropy();

            using (FileStream outputStream = new FileStream(KeyStorefilePath, FileMode.Create))
            {
                // Encrypt a copy of the data to the stream. 
                int bytesWritten = EncryptDataToStream(keyValueToEncrypt, entropy, DataProtectionScope.CurrentUser, outputStream);
            }

            return KeyStoreOperationStatus.PERSIST_SUCCESS;
        }

        /// <summary>
        /// Method to retrieve a key from an existing key store
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KeyStoreOperationStatus RetrieveKey(out string key)
        {
            key = null;
            if (!File.Exists(KeyStorefilePath))
            {
                return KeyStoreOperationStatus.RETRIEVE_FILE_DOES_NOT_EXIST;   
            }

            using(FileStream fStream = new FileStream(KeyStorefilePath, FileMode.Open))
            {
                if (Convert.ToInt32(fStream.Length) <= 0)
                    return KeyStoreOperationStatus.RETRIEVE_FILESREAM_EMPTY;

                if (!fStream.CanRead)
                {
                    return KeyStoreOperationStatus.RETRIEVE_FILESTREAM_INVALID;
                }

                byte[] decryptData = DecryptDataFromStream(fStream, GenerateEntropy(), DataProtectionScope.CurrentUser);
                string decryptedData = UnicodeEncoding.ASCII.GetString(decryptData);

                key = decryptedData;
            }

            return KeyStoreOperationStatus.RETRIEVE_SUCCESS;
        }
        #endregion interface implementation

        #region private
        /// <summary>
        /// Generate secondary entropy using a Math constant
        /// </summary>
        /// <returns></returns>
        private byte[] GenerateEntropy()
        {
            byte[] entropy = BitConverter.GetBytes(Math.PI);
            return entropy;
        }
        
        /// <summary>
        /// Method that encrypts the key on the user's machine
        /// </summary>
        /// <param name="inputBytes"></param>
        /// <param name="Entropy"></param>
        /// <param name="Scope"></param>
        /// <param name="outputFileStream"></param>
        /// <returns></returns>
         private int EncryptDataToStream(byte[] inputBytes, byte[] Entropy, DataProtectionScope Scope, Stream outputFileStream)
        {
            int length = 0;
            // Encrypt the data in memory. The result is stored in the same same array as the original data. 
            byte[] encrptedData = ProtectedData.Protect(inputBytes, Entropy, Scope);
            // Write the encrypted data to a stream. 
            if (outputFileStream.CanWrite && encrptedData != null)
            {
                outputFileStream.Write(encrptedData, 0, encrptedData.Length);
                length = encrptedData.Length;
            }
            // Return the length that was written to the stream.  
            return length;

        }


        /// <summary>
        /// This method reads data from an input stream and returns the decrypted format
        /// </summary>
        /// <param name="Entropy">entropy bytes that were used for encryption. If no entropy was used, please pass null here. otherwise it will fail</param>
        /// <param name="Scope">User scope of local machine scope</param>
        /// <param name="inputStream">the input stream</param>
        /// <returns></returns>
        private byte[] DecryptDataFromStream(Stream inputStream, byte[] Entropy, DataProtectionScope Scope = DataProtectionScope.CurrentUser)
        {
            int length = Convert.ToInt32(inputStream.Length);
            byte[] inBuffer = new byte[length];
            byte[] outBuffer;

            // Read the encrypted data from a stream. 
            if (inputStream.CanRead)
            {
                inputStream.Read(inBuffer, 0, length);

                outBuffer = ProtectedData.Unprotect(inBuffer, Entropy, Scope);
            }
            else
            {
                throw new IOException("Could not read the stream.");
            }

            return outBuffer;
        }
        #endregion private

   }
}
