using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    internal class NodeCounter
    {
        private long _nodes;

        public long Count(IDirectoryInfo root)
        {
            _nodes = 1;
            Enumerate(root);

            return _nodes;
        }

        private void Enumerate(IDirectoryInfo root)
        {
            IEnumerable<IDirectoryInfo> dirs;
            try
            {
                dirs = root.EnumerateDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            foreach (IDirectoryInfo dir in dirs)
            {
                _nodes += 1;
                Enumerate(dir);
            }

            _nodes += root.EnumerateFiles().Count();
        }
        
    }
}