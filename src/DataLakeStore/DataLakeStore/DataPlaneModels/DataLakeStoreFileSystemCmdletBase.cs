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
        private DataLakeStoreFileSystemClient _dataLakeFileSystemClient;

        public DataLakeStoreFileSystemClient DataLakeStoreFileSystemClient
        {
            get {
            return _dataLakeFileSystemClient ??
                   (_dataLakeFileSystemClient = new DataLakeStoreFileSystemClient(DefaultProfile.DefaultContext, this));
        }


            set { _dataLakeFileSystemClient = value; }
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
        /// Checks whether type is ByteEncoding
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        internal static bool UsingByteEncoding(Encoding encoding)
        {
            return encoding.GetType() == typeof(ByteEncoding);
        }
        /// <summary>
        /// Converts the stream type string into an Encoding
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="encoding"></param>
        /// <returns>
        /// The encoding that was represented by the string
        /// </returns>
        /// <throws>
        /// ArgumentException if type is null, empty, or does not represent one
        /// of the known encoding types.
        /// </throws>
        private static byte[] GetBytes(string content, Encoding encoding)
        {
            return encoding.GetBytes(content);
        }

        internal static byte[] GetBytes(object content, Encoding encoding)
        {
            if (UsingByteEncoding(encoding))
            {
                // first attempt to convert it directly into a byte array	
                var byteArray = content as byte[];
                if (byteArray != null)
                {
                    return byteArray;
                }
                /*
                 *  [byte[]] $byteData = 1,2,3,4,5
                 * $MyList = [System.Collections.Generic.List[object]]::new()
                 * $MyList.Add($byteData[0])
                 * $MyList.Add($byteData[1])
                 * And then pass $MyList.ToArray() this will pass object[] containing bytes
                 */
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
            else
            {
                var contentString = content as string;
                if (contentString == null)
                {
                    throw new CloudException(Resources.InvalidContent);
                }

                return GetBytes(contentString, encoding);
            }
        }

        internal static string BytesToString(byte[] content, Encoding encoding)
        {
            return encoding.GetString(content);
        }

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected CancellationToken CmdletCancellationToken;
    }


    #endregion
}