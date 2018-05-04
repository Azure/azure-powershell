using System;
using System.Collections.Generic;

namespace AFSEvaluationTool
{
    public class NamespaceEnumerator
    {
        private readonly IEnumerable<INamespaceEnumeratorListener> _listeners;

        public NamespaceEnumerator(IEnumerable<INamespaceEnumeratorListener> listeners)
        {
            _listeners = listeners;
        }

        public void Run(IDirectoryInfo root)
        {
            NotifyBeginDir(root);
            Enumerate(root);
            NotifyEndDir(root);
            NotifyEndOfEnumeration();
        }

        private void NotifyEndOfEnumeration()
        {
            foreach (INamespaceEnumeratorListener listener in _listeners)
            {
                listener.EndOfEnumeration();
            }
        }

        private void Enumerate(IDirectoryInfo root)
        {
            IEnumerable<IDirectoryInfo> dirs;
            try
            {
                dirs = root.EnumerateDirectories();
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                Console.WriteLine(unauthorizedAccessException);
                return;
            }
            
            foreach (IDirectoryInfo dir in dirs)
            {
                NotifyBeginDir(dir);
                Enumerate(dir);
                NotifyEndDir(dir);
            }

            IEnumerable<IFileInfo> files = root.EnumerateFiles();
            foreach (IFileInfo file in files)
            {
                NotifyNextFile(file);
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
