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
    using System;
    using System.Collections.Generic;

    public class NamespaceEnumerator
    {
        #region Fields and Properties
        private NamespaceInfo _namespaceInfo;
        private readonly IList<INamespaceEnumeratorListener> _listeners;
        #endregion

        #region Constructors
        public NamespaceEnumerator() : this(new List<INamespaceEnumeratorListener> { })
        {
        }

        public NamespaceEnumerator(IList<INamespaceEnumeratorListener> listeners)
        {
            this._listeners = listeners;
            this._namespaceInfo = new NamespaceInfo();
        }
        #endregion

        #region Public methods
        public NamespaceInfo Run(IDirectoryInfo root)
        {
            this.EnumeratePostOrderNonRecursive(root);
            NotifyEndOfEnumeration();
            return this._namespaceInfo;
        }

        public NamespaceInfo Run(IDirectoryInfo root, TimeSpan maximumDuration)
        {
            DateTime endTime = DateTime.UtcNow + maximumDuration;
            Func<bool> shouldCancel = () => DateTime.UtcNow >= endTime;
            this.EnumeratePostOrderNonRecursive(root, shouldCancel);
            NotifyEndOfEnumeration();
            return this._namespaceInfo;
        }
        #endregion

        #region Private methods
        private void NotifyEndOfEnumeration()
        {
            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.EndOfEnumeration(this._namespaceInfo);
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
        private void EnumeratePostOrderNonRecursive(IDirectoryInfo root, Func<bool> cancelationCallback = null)
        {
            // handle the case than this is actually network share.
            if (!root.Exists())
            {
                throw new System.IO.DirectoryNotFoundException($"Cannot access directory: {root.FullName}. Ensure directory exists.");
            }

            this._namespaceInfo = new NamespaceInfo
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

            this._namespaceInfo.NumberOfDirectories++;

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

                this.NotifyNamespaceHints(subdirs.Count, 0);

                foreach (IDirectoryInfo subdir in subdirs)
                {
                    stack1.Push(subdir);
                    this._namespaceInfo.NumberOfDirectories++;
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

                this.NotifyNamespaceHints(0, files.Count);

                foreach (IFileInfo file in files)
                {
                    this._namespaceInfo.NumberOfFiles++;
                    this._namespaceInfo.TotalFileSizeInBytes += file.Length;

                    NotifyNextFile(file);
                }

                // notify we have finished processing directory
                NotifyEndDir(currentDirectory);
            }

            this._namespaceInfo.IsComplete = true;
        }

        private void NotifyUnauthorizedDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.UnauthorizedDir(dir);
            }
        }

        private void NotifyNextFile(IFileInfo file)
        {
            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.NextFile(file);
            }
        }

        private void NotifyNamespaceHints(long directoryCount, long fileCount)
        {
            if (directoryCount + fileCount == 0)
            {
                return;
            }

            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.NamespaceHint(directoryCount, fileCount);
            }
        }

        private void NotifyEndDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.EndDir(dir);
            }
        }

        private void NotifyBeginDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in this._listeners)
            {
                listener.BeginDir(dir);
            }
        }
        #endregion

    }
}
