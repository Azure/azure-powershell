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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for storage client lib.
    /// </summary>
    internal static class StorageClientExtensions
    {
        /// <summary>
        /// Stores the separator for uri path as a string.
        /// </summary>
        private const string UriPathSeparator = "/";

        /// <summary>
        /// Gets the reference to a cloud file directory object from the
        /// provided base folder and the given path.
        /// </summary>
        /// <param name="currentDirectory">
        /// Indicating the base directory.
        /// </param>
        /// <param name="path">
        /// Indicating the path to the target folder in the form of a
        /// collection of strings which indicated each sub folder.
        /// </param>
        /// <returns>Returns the generated instance.</returns>
        public static CloudFileDirectory GetDirectoryReferenceByPath(this CloudFileDirectory currentDirectory, string[] path)
        {
            foreach (var subFolder in path)
            {
                currentDirectory = currentDirectory.GetDirectoryReference(subFolder);
            }

            return new CloudFileDirectory(currentDirectory.Uri, currentDirectory.Share.ServiceClient.Credentials);
        }

        /// <summary>
        /// Gets the reference to a cloud file object from the provided base
        /// folder and the given path.
        /// </summary>
        /// <param name="currentDirectory">
        /// Indicating the base directory.
        /// </param>
        /// <param name="path">
        /// Indicating the path to the target file in the form of a
        /// collection of strings which indicated each sub folder and the file
        /// name.
        /// </param>
        /// <returns>Returns the generated instance.</returns>
        public static CloudFile GetFileReferenceByPath(this CloudFileDirectory currentDirectory, string[] path)
        {
            for (int i = 0; i < path.Length - 1; i++)
            {
                currentDirectory = currentDirectory.GetDirectoryReference(path[i]);
            }

            CloudFile file = currentDirectory.GetFileReference(path.Last());

            return new CloudFile(file.Uri, file.Share.ServiceClient.Credentials);
        }

        /// <summary>
        /// Gets the full path of a file/directory.
        /// </summary>
        /// <param name="item">Indicating the file/directory object.</param>
        /// <returns>Returns the full path.</returns>
        public static string GetFullPath(this IListFileItem item)
        {
            // We need to make sure the share uri ends with "/" in order to
            // let MakeRelativeUri work properly.
            UriBuilder shareUri = new UriBuilder(item.Share.Uri);
            if (!shareUri.Path.EndsWith(UriPathSeparator, StringComparison.Ordinal))
            {
                shareUri.Path = string.Concat(shareUri.Path, UriPathSeparator);
            }

            return shareUri.Uri.MakeRelativeUri(item.Uri).ToString();
        }

        /// <summary>
        /// Gets the base name of a CloudFile item.
        /// </summary>
        /// <param name="file">Indicating the CloudFile item.</param>
        /// <returns>Returns the base name.</returns>
        /// <remarks>
        /// This is to work around XSCL bug 1391878 where CloudFile.Name
        /// sometimes returns base name and sometimes returns full path.
        /// </remarks>
        public static string GetBaseName(this CloudFile file)
        {
            Debug.Assert(!string.IsNullOrEmpty(file.Name), "CloudFile.Name should never return null.");
            return file.Name.Split(UriPathSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last();
        }
    }
}
