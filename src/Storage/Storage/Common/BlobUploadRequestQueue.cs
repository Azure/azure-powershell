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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class BlobUploadRequestQueue
    {
        private string root;
        private Queue<string> Requests;

        private BlobType Type { get; set; }
        private CloudBlobContainer Container { get; set; }
        private string BlobName { get; set; }

        public BlobUploadRequestQueue()
        {
            root = string.Empty;
            Requests = new Queue<string>();
        }

        public void SetDestinationContainer(IStorageBlobManagement channel, string containerName)
        {
            if (Container == null)
            {
                if (!NameUtil.IsValidContainerName(containerName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
                }

                Container = channel.GetContainerReference(containerName);
            }
        }

        public bool EnqueueRequest(string absoluteFilePath, BlobType type, string blobName)
        {
            absoluteFilePath = Path.GetFullPath(absoluteFilePath);
            if (!string.IsNullOrEmpty(blobName) && Requests.Count > 0)
            {
                throw new ArgumentException(Resources.BlobNameShouldBeEmptyWhenUploading);
            }
            else
            {
                BlobName = blobName;
                Type = type;
            }

            if (!System.IO.File.Exists(absoluteFilePath))
            {
                if (System.IO.Directory.Exists(absoluteFilePath))
                {
                    return false;
                }
                else
                {
                    throw new ArgumentException(String.Format(Resources.FileNotFound, absoluteFilePath));
                }
            }

            string dirPath = Path.GetDirectoryName(absoluteFilePath).ToLower();

            if (string.IsNullOrEmpty(root) || !dirPath.StartsWith(root))
            {
                root = GetCommonDirectory(root, dirPath);
            }

            Requests.Enqueue(absoluteFilePath);

            return true;
        }

        public bool IsEmpty()
        {
            return Requests.Count == 0;
        }

        public Tuple<string, CloudBlob> DequeueRequest()
        {
            string filePath = Requests.Dequeue();
            string blobName = string.Empty;

            if (!string.IsNullOrEmpty(BlobName))
            {
                blobName = BlobName;
            }
            else
            {
                blobName = filePath.Substring(root.Length);
            }

            blobName = NameUtil.ResolveBlobName(blobName);

            CloudBlob blob = Util.GetBlobReference(Container, blobName, Type);

            return new Tuple<string, CloudBlob>(filePath, blob);
        }

        private string GetCommonDirectory(string dir1, string dir2)
        {
            string commonDir = string.Empty;
            if (string.IsNullOrEmpty(dir1) || string.IsNullOrEmpty(dir2))
            {
                commonDir = string.IsNullOrEmpty(dir2) ? dir1 : dir2;
            }
            else
            {
                string[] path1 = dir1.Split(Path.DirectorySeparatorChar);
                string[] path2 = dir2.Split(Path.DirectorySeparatorChar);
                commonDir = GetCommonDirectory(path1, path2);
            }

            if (string.IsNullOrEmpty(commonDir))
            {
                throw new ArgumentException(Resources.InvalidFileName);
            }

            if (!commonDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                commonDir += Path.DirectorySeparatorChar;
            }

            return commonDir;
        }

        private string GetCommonDirectory(string[] path1, string[] path2)
        {
            if (path1.Length > path2.Length)
            {
                return GetCommonDirectory(path2, path1);
            }

            string prefix = string.Empty;

            for (int i = 0; i < path1.Length; i++)
            {
                if (path1[i] == path2[i])
                {
                    prefix += path1[i] + Path.DirectorySeparatorChar;
                }
                else
                {
                    break;
                }
            }

            return prefix;
        }
    }
}
