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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    /// <summary>
    /// Interface INamespaceEnumeratorListener
    /// </summary>
    public interface INamespaceEnumeratorListener
    {
        /// <summary>
        /// Nexts the file.
        /// </summary>
        /// <param name="node">The node.</param>
        void NextFile(IFileInfo node);
        /// <summary>
        /// Begins the dir.
        /// </summary>
        /// <param name="node">The node.</param>
        void BeginDir(IDirectoryInfo node);
        /// <summary>
        /// Ends the dir.
        /// </summary>
        /// <param name="node">The node.</param>
        void EndDir(IDirectoryInfo node);
        /// <summary>
        /// Ends the of enumeration.
        /// </summary>
        /// <param name="namespaceInfo">The namespace information.</param>
        void EndOfEnumeration(INamespaceInfo namespaceInfo);
        /// <summary>
        /// Unauthorizeds the dir.
        /// </summary>
        /// <param name="dir">The dir.</param>
        void UnauthorizedDir(IDirectoryInfo dir);
        /// <summary>
        /// Namespaces the hint.
        /// </summary>
        /// <param name="directoryCount">The directory count.</param>
        /// <param name="fileCount">The file count.</param>
        void NamespaceHint(long directoryCount, long fileCount);
    }
}