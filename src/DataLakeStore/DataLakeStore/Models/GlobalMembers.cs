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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// A Static class containing global members for these cmdlets.
    /// </summary>
    public static class GlobalMembers
    {
        /// <summary>
        /// The binary file extension list
        /// </summary>
        public static readonly HashSet<string> BinaryFileExtension = new HashSet<string>
        {
            ".exe",
            ".dll",
            ".bin",
            ".rtf",
            ".7z",
            ".7zip",
            ".doc",
            ".chm",
            ".docx",
            ".bmp",
            ".emf",
            ".wmf",
            ".jpg",
            ".jpeg",
            ".mp3",
            ".mp4",
            ".avi",
            ".wma",
            ".png",
            ".gif",
            ".pdb",
            ".baja",
            ".ico",
            ".wixlib",
            ".cub",
            ".com",
            ".obj",
            ".cab",
            ".gz",
            ".gzip",
            ".rar",
            ".iso",
            ".vhd",
            ".ost",
            ".pst",
            ".msg",
            ".lib",
            ".xml"
        };
    }
}