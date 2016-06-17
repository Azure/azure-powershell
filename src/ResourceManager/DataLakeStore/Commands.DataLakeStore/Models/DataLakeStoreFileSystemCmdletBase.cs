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

using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.PowerShell.Commands;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure DataLakeStoreFileSystem Management cmdlets
    /// </summary>
    public abstract class DataLakeStoreFileSystemCmdletBase : AzureRMCmdlet
    {
        private DataLakeStoreFileSystemClient dataLakeFileSystemClient;

        public DataLakeStoreFileSystemClient DataLakeStoreFileSystemClient
        {
            get
            {
                return dataLakeFileSystemClient ??
                       (dataLakeFileSystemClient = new DataLakeStoreFileSystemClient(DefaultProfile.Context));
            }

            set { dataLakeFileSystemClient = value; }
        }

        /// <summary>
        /// Cmdlet begin process
        /// </summary>
        protected override void BeginProcessing()
        {
            CmdletCancellationToken = cancellationTokenSource.Token;
            base.BeginProcessing();
        }

        /// <summary>
        /// stop processing
        /// time-consuming operation should work with ShouldForceQuit
        /// </summary>
        protected override void StopProcessing()
        {
            // ctrl + c and etc
            cancellationTokenSource.Cancel();
            base.StopProcessing();
        }

        #region cmdlet helpers from the FilesystemProvider

        /// <summary>
        /// Converts the stream type string into an Encoding
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="type">
        /// This is a string representation of the encoding. It can be
        /// "string", "unicode", "bigendianunicode", "ascii", "utf7", or "utf8"
        /// Note, a ToLowerInvariant is done to the type before comparison is made.
        /// </param>
        /// <returns>
        /// The encoding that was represented by the string
        /// </returns>
        /// <throws>
        /// ArgumentException if type is null, empty, or does not represent one
        /// of the known encoding types.
        /// </throws>
        private static byte[] GetBytes(string content, FileSystemCmdletProviderEncoding type)
        {
            switch (type)
            {
                case FileSystemCmdletProviderEncoding.String:
                    return Encoding.UTF8.GetBytes(content);
                case FileSystemCmdletProviderEncoding.Unicode:
                    return Encoding.Unicode.GetBytes(content);
                case FileSystemCmdletProviderEncoding.BigEndianUnicode:
                    return Encoding.BigEndianUnicode.GetBytes(content);
                case FileSystemCmdletProviderEncoding.UTF8:
                    return Encoding.UTF8.GetBytes(content);
                case FileSystemCmdletProviderEncoding.UTF7:
                    return Encoding.UTF7.GetBytes(content);
                case FileSystemCmdletProviderEncoding.UTF32:
                    return Encoding.UTF32.GetBytes(content);
                case FileSystemCmdletProviderEncoding.Ascii:
                    return Encoding.ASCII.GetBytes(content);
                case FileSystemCmdletProviderEncoding.Default:
                    return Encoding.UTF8.GetBytes(content);
                case FileSystemCmdletProviderEncoding.Oem:
                    {
                        var oemCP = NativeMethods.GetOEMCP();
                        return Encoding.GetEncoding((int)oemCP).GetBytes(content);
                    }
                default:
                    // Default to unicode encoding
                    return Encoding.UTF8.GetBytes(content);
            }
        }

        /// <summary>
        /// Gets the Byte Encoding status of the StreamType parameter.  Returns true
        /// if the stream was opened with "Byte" encoding, false otherwise.
        /// </summary>
        internal static bool UsingByteEncoding(FileSystemCmdletProviderEncoding encoding)
        {
            return encoding == FileSystemCmdletProviderEncoding.Byte;
        } // UsingByteEncoding

        internal static byte[] GetBytes(object content, FileSystemCmdletProviderEncoding encoding)
        {
            if (UsingByteEncoding(encoding))
            {
                // first attempt to convert it directly into a byte array
                var byteArray = content as byte[];
                if (byteArray != null)
                {
                    return byteArray;
                }

                // attempt to convert the object into an object array
                var contentArray = content as object[];
                if (contentArray == null)
                {
                    throw new CloudException(Resources.InvalidEncoding);
                }

                // now, for each element in the content array, ensure it is of type byte
                var byteList = new List<byte>();
                foreach (var entry in contentArray)
                {
                    if (!(entry is byte))
                    {
                        throw new CloudException(Resources.InvalidEncoding);
                    }

                    byteList.Add((byte)entry);
                }

                return byteList.ToArray();
            }

            var contentString = content as string;
            if (contentString == null)
            {
                throw new CloudException(Resources.InvalidContent);
            }

            return GetBytes(contentString, encoding);
        }

        internal static string BytesToString(byte[] content, FileSystemCmdletProviderEncoding type)
        {
            switch (type)
            {
                case FileSystemCmdletProviderEncoding.String:
                    return Encoding.UTF8.GetString(content);
                case FileSystemCmdletProviderEncoding.Unicode:
                    return Encoding.Unicode.GetString(content);
                case FileSystemCmdletProviderEncoding.BigEndianUnicode:
                    return Encoding.BigEndianUnicode.GetString(content);
                case FileSystemCmdletProviderEncoding.UTF8:
                    return Encoding.UTF8.GetString(content);
                case FileSystemCmdletProviderEncoding.UTF7:
                    return Encoding.UTF7.GetString(content);
                case FileSystemCmdletProviderEncoding.UTF32:
                    return Encoding.UTF32.GetString(content);
                case FileSystemCmdletProviderEncoding.Ascii:
                    return Encoding.ASCII.GetString(content);
                case FileSystemCmdletProviderEncoding.Default:
                    return Encoding.UTF8.GetString(content);
                case FileSystemCmdletProviderEncoding.Oem:
                    {
                        var oemCP = NativeMethods.GetOEMCP();
                        return Encoding.GetEncoding((int)oemCP).GetString(content);
                    }
                default:
                    // Default to unicode encoding
                    return Encoding.UTF8.GetString(content);
            }
        }

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected CancellationToken CmdletCancellationToken;
    }

    internal static class NativeMethods
    {
        [DllImport("api-ms-win-core-localization-l1-2-1.dll", SetLastError = false, CharSet = CharSet.Unicode)]
        internal static extern uint GetOEMCP();
    }

    #endregion
}