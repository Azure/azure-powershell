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

using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages
{
    internal class PackageUploadRequestQueue
    {
        private string root;
        private ConcurrentQueue<string> requests;

        public PackageUploadRequestQueue()
        {
            root = string.Empty;
            requests = new ConcurrentQueue<string>();
        }

        public bool EnqueueRequest(string absoluteFilePath)
        {
            absoluteFilePath = Path.GetFullPath(absoluteFilePath);
            if (!System.IO.File.Exists(absoluteFilePath))
            {
                if (System.IO.Directory.Exists(absoluteFilePath))
                {
                    return false;
                }
                else
                {
                    throw new ArgumentException(String.Format(Resources.FilePathDoesNotExist, absoluteFilePath));
                }
            }

            string dirPath = Path.GetDirectoryName(absoluteFilePath).ToLower();

            if (string.IsNullOrEmpty(root) || !dirPath.StartsWith(root))
            {
                root = GetCommonDirectory(root, dirPath);
            }

            requests.Enqueue(absoluteFilePath);

            return true;
        }

        public bool IsEmpty()
        {
            return requests.Count == 0;
        }

        public bool TryDequeueRequest(out PackageUploadRequest request)
        {
            if (!requests.TryDequeue(out string filePath))
            {
                request = null;
                return false;
            }

            string packageName = filePath.Substring(root.Length);
            request = new PackageUploadRequest
            {
                FilePath = filePath,
                PackageName = packageName
            };

            return true;
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
