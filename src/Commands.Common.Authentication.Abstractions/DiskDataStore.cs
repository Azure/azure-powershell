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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Properties;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// A ddata store based on the managed windows file system functions (System.IO)
    /// </summary>
    public class DiskDataStore : IDataStore
    {
        // <summary>
        /// Write the given contents to the specified file
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="contents">The fiel contents</param>
        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        /// <summary>
        /// Write the given contents to the specified file, using the specified encoding
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="content">The file contents</param>
        /// <param name="encoding">The encoding to use</param>
        public void WriteFile(string path, string contents, Encoding encoding)
        {
            File.WriteAllText(path, contents, encoding);
        }

        /// <summary>
        /// Write the given binary contents to the specified file
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="contents">The binary contents</param>
        public void WriteFile(string path, byte[] contents)
        {
            File.WriteAllBytes(path, contents);
        }

        /// <summary>
        /// Return the contents of the given file as a text string
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a string.  Throws an exception if the file is not found.</returns>
        public string ReadFileAsText(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Return the contents of the given file as a byte array
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a byte array.  Throws an exception if the file is not found.</returns>
        public byte[] ReadFileAsBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Return the contents of the given file as a stream
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a stream.  Throws an exception if the file is not found.</returns>
        public Stream ReadFileAsStream(string path)
        {
            return File.Open(path, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// Move the file to the specified location.  Overwrites the file if it exists
        /// </summary>
        /// <param name="oldPath">Source file path</param>
        /// <param name="newPath">Target file path</param>
        public void RenameFile(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }

        /// <summary>
        /// Copy the given file to the target path.  Overwirtes the file if it exists
        /// </summary>
        /// <param name="oldPath">Source file path</param>
        /// <param name="newPath">Target file path</param>
        public void CopyFile(string oldPath, string newPath)
        {
            File.Copy(oldPath, newPath, true);
        }

        /// <summary>
        /// Checks if the given file exists
        /// </summary>
        /// <param name="path">The file path to check</param>
        /// <returns>True if the file exists, false otherwise</returns>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Remove the given file
        /// </summary>
        /// <param name="path">The path of the file to delete</param>
        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Remove the given directory
        /// </summary>
        /// <param name="dir">The directory path</param>
        public void DeleteDirectory(string dir)
        {
            Directory.Delete(dir, true);
        }

        /// <summary>
        /// Remove all files from the given directory
        /// </summary>
        /// <param name="dirPath">The directory to empty</param>
        public void EmptyDirectory(string dirPath)
        {
            foreach (var filePath in Directory.GetFiles(dirPath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Get the files in the given directory
        /// </summary>
        /// <param name="sourceDirName">The directory path to check</param>
        /// <returns>The list of file paths in the given directory</returns>
        public string[] GetFiles(string sourceDirName)
        {
            return Directory.GetFiles(sourceDirName);
        }

        /// <summary>
        /// Get files at the given path matchign the givven pattern and search options
        /// </summary>
        /// <param name="startDirectory">The directory to list file contents of</param>
        /// <param name="filePattern">The pattern of file naems to include</param>
        /// <param name="options">File search options</param>
        /// <returns>The path to all contained files</returns>
        public string[] GetFiles(string startDirectory, string filePattern, SearchOption options)
        {
            return Directory.GetFiles(startDirectory, filePattern, options);
        }

        /// <summary>
        /// Get the file system attributes for the given file
        /// </summary>
        /// <param name="path">The fiel path</param>
        /// <returns>The file system attributes associated with the file</returns>
        public FileAttributes GetFileAttributes(string path)
        {
            return File.GetAttributes(path);
        }

        /// <summary>
        /// Search for the given certificate from the CurrentUser and LocalSystem 'My' directory stores
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to look for</param>
        /// <returns>The certificate matching the given thumbprint</returns>
        public X509Certificate2 GetCertificate(string thumbprint)
        {
            if (thumbprint == null)
            {
                return null;
            }
            else
            {
                if (string.IsNullOrEmpty(thumbprint))
                {
                    throw new ArgumentException(string.Format(Resources.InvalidOrEmptyArgumentMessage, "certificate thumbprint"));
                }

                X509Certificate2Collection certificates;
                if (TryFindCertificatesInStore(thumbprint, StoreLocation.CurrentUser, out certificates) ||
                    TryFindCertificatesInStore(thumbprint, StoreLocation.LocalMachine, out certificates))
                {
                    return certificates[0];
                }
                else
                {
                    throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, thumbprint));
                }
            }
        }

        /// <summary>
        /// Add the given certificate to the CurrentUser 'My ' store
        /// </summary>
        /// <param name="cert">The certificate to add</param>
        public void AddCertificate(X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentException(Resources.InvalidCertificate);
            }

            X509StoreWrapper(StoreName.My, StoreLocation.CurrentUser, (store) =>
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
            });
        }

        /// <summary>
        /// Remove the given certificate from the CurrentUser 'My' directory store
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to look for</param>
        public void RemoveCertificate(string thumbprint)
        {
            if (thumbprint != null)
            {
                var certificate = GetCertificate(thumbprint);
                if (certificate != null)
                {
                    X509StoreWrapper(StoreName.My, StoreLocation.CurrentUser, (store) =>
                    {
                        store.Open(OpenFlags.ReadWrite);
                        store.Remove(certificate);
                    });
                }
            }
        }

        /// <summary>
        /// Check for existence of the given directory
        /// </summary>
        /// <param name="path">The directory path to check</param>
        /// <returns>True if the directory exists, otherwise false</returns>
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Create a directory at the given path
        /// </summary>
        /// <param name="path">The directory path</param>
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Get the set of directories inside the given directory path
        /// </summary>
        /// <param name="sourceDirName">The directory to list directory contents of</param>
        /// <returns></returns>
        public string[] GetDirectories(string sourceDirName)
        {
            return Directory.GetDirectories(sourceDirName);
        }

        /// <summary>
        /// Get directories at the given path matchign the givven pattern and search options
        /// </summary>
        /// <param name="startDirectory">The directory to list directory contents of</param>
        /// <param name="filePattern">The pattern of directory naems to include</param>
        /// <param name="options">Directory search options</param>
        /// <returns>The path to all contained directories</returns>
        public string[] GetDirectories(string startDirectory, string filePattern, SearchOption options)
        {
            return Directory.GetDirectories(startDirectory, filePattern, options);
        }

        private static bool TryFindCertificatesInStore(string thumbprint,
            StoreLocation location, out X509Certificate2Collection certificates)
        {
            X509Certificate2Collection found = null;
            X509StoreWrapper(StoreName.My, location, (store) =>
            {
                store.Open(OpenFlags.ReadOnly);
                found = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            });
            certificates = found;
            return certificates.Count > 0;
        }
		
        public static void X509StoreWrapper(StoreName storeName, StoreLocation storeLocation, Action<X509Store> action)
        {
#if !NETSTANDARD
            X509Store store = new X509Store(storeName, storeLocation);
            action(store);
            store.Close();
#else
            using (X509Store store = new X509Store(storeName, storeLocation))
            {
                action(store);
            }
#endif
        }
        public Stream OpenForSharedRead(string path)
        {
            return File.Open(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        }

        public Stream OpenForExclusiveWrite(string path)
        {
            return File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        }
    }
}
