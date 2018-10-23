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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class VhdFile : IDisposable
    {
        private BinaryReader reader;
        private bool disposed;

        public VhdFile(VhdFooter footer, VhdHeader header, BlockAllocationTable bat, VhdFile parent, Stream stream)
        {
            this.Footer = footer;
            this.Header = header;
            this.BlockAllocationTable = bat;
            this.Parent = parent;
            this.reader = new BinaryReader(stream, Encoding.Unicode);
            DataReader = new VhdDataReader(this.reader);
        }

        // These properties, and all others on this object, must remain immutable for certain FxCop suppressions to be allowed. 
        // If at any time this class is changed, please revisit all suppressions of the DoNotDeclareReadOnlyMutableReferenceTypes
        // rule where VhdFile is declared as a readonly object. Otherwise it is always safe to suppress the rule DoNotDeclareReadOnlyMutableReferenceTypes
        public VhdDataReader DataReader { get; private set; }
        public VhdFooter Footer { get; private set; }
        public VhdHeader Header { get; private set; }
        public BlockAllocationTable BlockAllocationTable { get; private set; }
        public DiskType DiskType { get { return Footer.DiskType; } }
        public VhdFile Parent { get; private set; }

        public IEnumerable<Block> GetBlocks()
        {
            var blockFactory = this.GetBlockFactory();
            for (long index = 0; index < blockFactory.BlockCount; index++)
            {
                yield return blockFactory.Create((uint)index);
            }
        }

        public IBlockFactory GetBlockFactory()
        {
            switch (this.DiskType)
            {
                case DiskType.Fixed:
                    return new FixedDiskBlockFactory(this);
                case DiskType.Dynamic:
                    return new DynamicDiskBlockFactory(this);
                case DiskType.Differencing:
                    return new DifferencingDiskBlockFactory(this);
                default:
                    throw new InvalidOperationException(String.Format("Unsupported DiskType:{0}", this.DiskType));
            }
        }

        public IEnumerable<Guid> GetIdentityChain()
        {
            var identities = new List<Guid> { this.Footer.UniqueId };
            var currentFile = this.Parent;
            while (currentFile != null)
            {
                identities.Add(currentFile.Footer.UniqueId);
                currentFile = currentFile.Parent;
            }
            return identities;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.reader.Close();
                }
                if (Parent != null)
                {
                    Parent.Dispose();
                }
                disposed = true;
            }
        }
    }
}