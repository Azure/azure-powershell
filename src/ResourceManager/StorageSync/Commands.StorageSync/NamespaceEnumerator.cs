using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public class NamespaceEnumerator
    {
        private NamespaceInfo _namespaceInfo;
        private readonly IList<INamespaceEnumeratorListener> _listeners;

        public NamespaceEnumerator(): this(new List<INamespaceEnumeratorListener> { })
        {
        }

        public NamespaceEnumerator(IList<INamespaceEnumeratorListener> listeners)
        {
            _listeners = listeners;
            _namespaceInfo = new NamespaceInfo();
        }

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

        private void NotifyEndOfEnumeration()
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
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
            _namespaceInfo = new NamespaceInfo {
                Path = root.FullName,
                IsComplete = false
            };

            Stack<IDirectoryInfo> stack1 = new Stack<IDirectoryInfo>(5000);
            Stack<IDirectoryInfo> stack2 = new Stack<IDirectoryInfo>(5000);

            Func<bool> shouldCancel = () => cancelationCallback == null ? false : cancelationCallback.Invoke();

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

                this.NotifyNamespaceHints(subdirs.Count, 0);

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

                this.NotifyNamespaceHints(0, files.Count);

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

        private void NotifyUnauthorizedDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.UnauthorizedDir(dir);
            }
        }

        private void NotifyNextFile(IFileInfo file)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
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

            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.NamespaceHint(directoryCount, fileCount);
            }
        }

        private void NotifyEndDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.EndDir(dir);
            }
        }

        private void NotifyBeginDir(IDirectoryInfo dir)
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.BeginDir(dir);
            }
        }
        
    }
}
