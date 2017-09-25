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

using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// An abstraction over the file system
    /// </summary>
    public interface IDataStore
    {
        /// <summary>
        /// Write the given contents to the specified file
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="contents">The fiel contents</param>
        void WriteFile(string path, string contents);

        /// <summary>
        /// Write the given contents to the specified file, using the specified encoding
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="content">The file contents</param>
        /// <param name="encoding">The encoding to use</param>
        void WriteFile(string path, string content, Encoding encoding);

        /// <summary>
        /// Write the given binary contents to the specified file
        /// </summary>
        /// <param name="path">The file path</param>
        /// <param name="contents">The binary contents</param>
        void WriteFile(string path, byte[] contents);

        /// <summary>
        /// Return the contents of the given file as a text string
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a string.  Throws an exception if the file is not found.</returns>
        string ReadFileAsText(string path);

        /// <summary>
        /// Return the contents of the given file as a stream
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a stream.  Throws an exception if the file is not found.</returns>
        Stream ReadFileAsStream(string path);

        /// <summary>
        /// Return the contents of the given file as a byte array
        /// </summary>
        /// <param name="path">The file path</param>
        /// <returns>The contents of the given file as a byte array.  Throws an exception if the file is not found.</returns>
        byte[] ReadFileAsBytes(string path);

        /// <summary>
        /// Move the file to the specified location.  Overwrites the file if it exists
        /// </summary>
        /// <param name="oldPath">Source file path</param>
        /// <param name="newPath">Target file path</param>
        void RenameFile(string oldPath, string newPath);

        /// <summary>
        /// Open the file for shared Read access
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>A FileSTream poiinting to the beginning of the file</returns>
        Stream OpenForSharedRead(string path);

        /// <summary>
        /// Open the file for exclusive read/write access
        /// </summary>
        /// <param name="path">Path to the file to open</param>
        /// <returns>A FileSTream pointing to the beginning of the file</returns>
        Stream OpenForExclusiveWrite(string path);

        /// <summary>
        /// Copy the given file to the target path.  Overwirtes the file if it exists
        /// </summary>
        /// <param name="oldPath">Source file path</param>
        /// <param name="newPath">Target file path</param>
        void CopyFile(string oldPath, string newPath);

        /// <summary>
        /// Checks if the given file exists
        /// </summary>
        /// <param name="path">The file path to check</param>
        /// <returns>True if the file exists, false otherwise</returns>
        bool FileExists(string path);

        /// <summary>
        /// Remove the given file
        /// </summary>
        /// <param name="path">The path of the file to delete</param>
        void DeleteFile(string path);

        /// <summary>
        /// Remove the given directory
        /// </summary>
        /// <param name="dir">The directory path</param>
        void DeleteDirectory(string dir);

        /// <summary>
        /// Remove all files from the given directory
        /// </summary>
        /// <param name="dirPath">The directory to empty</param>
        void EmptyDirectory(string dirPath);

        /// <summary>
        /// Check for existence of the given directory
        /// </summary>
        /// <param name="path">The directory path to check</param>
        /// <returns>True if the directory exists, otherwise false</returns>
        bool DirectoryExists(string path);

        /// <summary>
        /// Create a directory at the given path
        /// </summary>
        /// <param name="path">The directory path</param>
        void CreateDirectory(string path);

        /// <summary>
        /// Get the set of directories inside the given directory path
        /// </summary>
        /// <param name="sourceDirName">The directory to list directory contents of</param>
        /// <returns></returns>
        string[] GetDirectories(string sourceDirName);

        /// <summary>
        /// Get directories at the given path matchign the givven pattern and search options
        /// </summary>
        /// <param name="startDirectory">The directory to list directory contents of</param>
        /// <param name="filePattern">The pattern of directory naems to include</param>
        /// <param name="options">Directory search options</param>
        /// <returns>The path to all contained directories</returns>
        string[] GetDirectories(string startDirectory, string filePattern, SearchOption options);

        /// <summary>
        /// Get the files in the given directory
        /// </summary>
        /// <param name="sourceDirName">The directory path to check</param>
        /// <returns>The list of file paths in the given directory</returns>
        string[] GetFiles(string sourceDirName);

        /// <summary>
        /// Get files at the given path matchign the givven pattern and search options
        /// </summary>
        /// <param name="startDirectory">The directory to list file contents of</param>
        /// <param name="filePattern">The pattern of file naems to include</param>
        /// <param name="options">File search options</param>
        /// <returns>The path to all contained files</returns>
        string[] GetFiles(string startDirectory, string filePattern, SearchOption options);

        /// <summary>
        /// Get the file system attributes for the given file
        /// </summary>
        /// <param name="path">The fiel path</param>
        /// <returns>The file system attributes associated with the file</returns>
        FileAttributes GetFileAttributes(string path);

        /// <summary>
        /// Search for the given certificate from the CurrentUser and LocalSystem 'My' directory stores
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to look for</param>
        /// <returns>The certificate matching the given thumbprint</returns>
        X509Certificate2 GetCertificate(string thumbprint);

        /// <summary>
        /// Add the given certificate to the CurrentUser 'My ' store
        /// </summary>
        /// <param name="cert">The certificate to add</param>
        void AddCertificate(X509Certificate2 cert);

        /// <summary>
        /// Remove the given certificate from the CurrentUser 'My' directory store
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the certificate to look for</param>
        void RemoveCertificate(string thumbprint);
    }
}
