// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// A helper class to pull files out of embedded resources and drop them
    /// onto disk. Helps ensure that needed files are present without having
    /// to use MSTest's unreliable deployment items.
    /// </summary>
    public static class EmbeddedFileWriter
    {
        /// <summary>
        /// Copy a resource to a disk file.
        /// </summary>
        /// <typeparam name="TResourceLocator">Type used to locate the assembly and namespace of the embedded resource.</typeparam>
        /// <param name="resourceName">Name of the embedded resource file.</param>
        /// <param name="filePath">Path to write to.</param>
        /// <returns>True if written, false if the file already exists.</returns>
        public static bool WriteResourceToDisk<TResourceLocator>(string resourceName, string filePath)
        {
            if (File.Exists(filePath))
            {
                return false;
            }
            using (Stream resourceStream = GetResourceStream<TResourceLocator>(resourceName))
            {
                WriteToDisk(filePath, resourceStream);
                return true;
            }
        }

        private static Stream GetResourceStream<TResourceLocator>(string resourceName)
        {
            string resourcePath = string.Format("{0}.{1}", GetResourceNamespace<TResourceLocator>(), resourceName);
            var resourceAssembly = typeof (TResourceLocator).Assembly;
            return resourceAssembly.GetManifestResourceStream(resourcePath);
        }

        private static string GetResourceNamespace<TResourceLocator>()
        {
            return typeof (TResourceLocator).Namespace;
        }

        private static void WriteToDisk(string filePath, Stream resourceStream)
        {
            EnsureDirectoryExists(Path.GetDirectoryName(filePath));
            using (Stream outputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                resourceStream.CopyTo(outputStream);
            }
        }

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                return;
            }
            EnsureDirectoryExists(Path.GetDirectoryName(directoryPath));
            Directory.CreateDirectory(directoryPath);
        }
    }
}
