using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public class NamespaceEnumerator
    {
        private NamespaceInfo _namespaceInfo;
        private readonly IEnumerable<INamespaceEnumeratorListener> _listeners;

        public NamespaceEnumerator(): this(new List<INamespaceEnumeratorListener> { })
        {
        }

        public NamespaceEnumerator(IEnumerable<INamespaceEnumeratorListener> listeners)
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

        private void NotifyEndOfEnumeration()
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.EndOfEnumeration(this._namespaceInfo);
            }
        }

        // implementation of post-order traversal of directory tree
        // it is done this way to guarantee that by the time we finish visiting directory
        // all of its subdirectories had been visited
        private void EnumeratePostOrderNonRecursive(IDirectoryInfo root)
        {
            _namespaceInfo = new NamespaceInfo {
                Path = root.FullName
            };

            Stack<IDirectoryInfo> stack1 = new Stack<IDirectoryInfo>();
            Stack<IDirectoryInfo> stack2 = new Stack<IDirectoryInfo>();

            stack1.Push(root);

            while (stack1.Count > 0)
            {
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

                foreach (IDirectoryInfo subdir in subdirs)
                {
                    stack1.Push(subdir);
                }
            }

            _namespaceInfo.NumberOfDirectories = stack2.Count - 1;

            while (stack2.Count > 0)
            {
                IDirectoryInfo currentDirectory = stack2.Pop();

                IEnumerable<IFileInfo> files = currentDirectory.EnumerateFiles();

                foreach (IFileInfo file in files)
                {
                    _namespaceInfo.NumberOfFiles += 1;
                    _namespaceInfo.TotalFileSizeInBytes += file.Length;

                    NotifyNextFile(file);
                }

                // notify we have finished processing directory
                NotifyEndDir(currentDirectory);
            }
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
