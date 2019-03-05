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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Properties;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class NamespaceEnumerator.
    /// </summary>
    public class NamespaceEnumerator
    {
        #region Fields and Properties
        /// <summary>
        /// The namespace information
        /// </summary>
        private NamespaceInfo _namespaceInfo;
        /// <summary>
        /// The listeners
        /// </summary>
        private readonly IList<INamespaceEnumeratorListener> _listeners;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceEnumerator" /> class.
        /// </summary>
        public NamespaceEnumerator() : this(new List<INamespaceEnumeratorListener> { })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceEnumerator" /> class.
        /// </summary>
        /// <param name="listeners">The listeners.</param>
        public NamespaceEnumerator(IList<INamespaceEnumeratorListener> listeners)
        {
            _listeners = listeners;
            _namespaceInfo = new NamespaceInfo();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Runs the specified root.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>NamespaceInfo.</returns>
        public NamespaceInfo Run(IDirectoryInfo root)
        {
            EnumeratePostOrderNonRecursive(root);
            NotifyEndOfEnumeration();
            return _namespaceInfo;
        }

        /// <summary>
        /// Runs the specified root.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="maximumDuration">The maximum duration.</param>
        /// <returns>NamespaceInfo.</returns>
        public NamespaceInfo Run(IDirectoryInfo root, TimeSpan maximumDuration)
        {
            DateTime endTime = DateTime.UtcNow + maximumDuration;
            Func<bool> shouldCancel = () => DateTime.UtcNow >= endTime;
            EnumeratePostOrderNonRecursive(root, shouldCancel);
            NotifyEndOfEnumeration();
            return _namespaceInfo;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Notifies the end of enumeration.
        /// </summary>
        private void NotifyEndOfEnumeration()
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.EndOfEnumeration(_namespaceInfo);
            }
        }

        /// <summary>
        /// implementation of post-order traversal of directory tree
        /// it is done this way to guarantee that by the time we finish any directory
        /// all of its subdirectories/files had been visited
        /// Note:
        /// if operaiton is cancelled - not all notifications will be emited,
        /// and namespace information will be partial.
        /// </summary>
        /// <param name="root">directory to scan</param>
        /// <param name="cancelationCallback">function to consult with for cancelation</param>
        /// <exception cref="System.IO.DirectoryNotFoundException">Cannot access directory: {root.FullName}</exception>
        private void EnumeratePostOrderNonRecursive(IDirectoryInfo root, Func<bool> cancelationCallback = null)
        {
            // handle the case than this is actually network share.
            if (!root.Exists())
            {
                throw new System.IO.DirectoryNotFoundException(string.Format(StorageSyncResources.NamespaceEnumeratorErrorFormat, root.FullName));
            }

            _namespaceInfo = new NamespaceInfo
            {
                Path = root.FullName,
                IsComplete = false
            };

            Stack<IDirectoryInfo> stack1 = new Stack<IDirectoryInfo>(5000);
            Stack<IDirectoryInfo> stack2 = new Stack<IDirectoryInfo>(5000);

            Func<bool> shouldCancel = () =>
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    return false;
                }

                return cancelationCallback == null ? false : cancelationCallback.Invoke();
            };

            stack1.Push(root);

            _namespaceInfo.NumberOfDirectories++;

            while (stack1.Count > 0)
            {
                if (shouldCancel())
                {
                    return;
                }

                IDirectoryInfo currentDirectory = stack1.Pop();

                stack2.Push(currentDirectory);

                // notify we have started processing directory
                // processing means accessing subdirectories and files
                NotifyBeginDir(currentDirectory);

                IList<IDirectoryInfo> subdirs = null;

                try
                {
                    subdirs = new List<IDirectoryInfo>(currentDirectory.EnumerateDirectories());
                }
                catch (UnauthorizedAccessException)
                {
                    NotifyUnauthorizedDir(currentDirectory);
                    continue;
                }

                NotifyNamespaceHints(subdirs.Count, 0);

                foreach (IDirectoryInfo subdir in subdirs)
                {
                    stack1.Push(subdir);
                    _namespaceInfo.NumberOfDirectories++;
                }
            }

            while (stack2.Count > 0)
            {
                if (shouldCancel())
                {
                    return;
                }

                IDirectoryInfo currentDirectory = stack2.Pop();

                IList<IFileInfo> files = new List<IFileInfo>(currentDirectory.EnumerateFiles());

                NotifyNamespaceHints(0, files.Count);

                foreach (IFileInfo file in files)
                {
                    _namespaceInfo.NumberOfFiles++;
                    _namespaceInfo.TotalFileSizeInBytes += file.Length;

                    NotifyNextFile(file);
                }

                // notify we have finished processing directory
                NotifyEndDir(currentDirectory);
            }

            _namespaceInfo.IsComplete = true;
        }

        /// <summary>
        /// Notifies the unauthorized dir.
        /// </summary>
        /// <param name="dir">The dir.</param>
        private void NotifyUnauthorizedDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.UnauthorizedDir(dir);
            }
        }

        /// <summary>
        /// Notifies the next file.
        /// </summary>
        /// <param name="file">The file.</param>
        private void NotifyNextFile(IFileInfo file)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.NextFile(file);
            }
        }

        /// <summary>
        /// Notifies the namespace hints.
        /// </summary>
        /// <param name="directoryCount">The directory count.</param>
        /// <param name="fileCount">The file count.</param>
        private void NotifyNamespaceHints(long directoryCount, long fileCount)
        {
            if (directoryCount + fileCount == 0)
            {
                return;
            }

            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.NamespaceHint(directoryCount, fileCount);
            }
        }

        /// <summary>
        /// Notifies the end dir.
        /// </summary>
        /// <param name="dir">The dir.</param>
        private void NotifyEndDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.EndDir(dir);
            }
        }

        /// <summary>
        /// Notifies the begin dir.
        /// </summary>
        /// <param name="dir">The dir.</param>
        private void NotifyBeginDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.BeginDir(dir);
            }
        }
        #endregion

    }
}
