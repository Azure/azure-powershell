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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd
{
    /// <summary>
    /// Provides a logical stream over a virtual hard disk (VHD).
    /// </summary>
    /// <remarks>
    /// This stream implementation provides a "view" over a VHD, such that the 
    /// VHD appears to be an ordinary fixed VHD file, regardless of the true physical layout.
    /// This stream supports any combination of differencing, dynamic disks, and fixed disks.
    /// </remarks>
    public class VirtualDiskStream : SparseStream
    {
        private long position;
        private VhdFile vhdFile;
        private IBlockFactory blockFactory;
        private IndexRange footerRange;
        private IndexRange fileDataRange;
        private bool isDisposed;

        public VirtualDiskStream(string vhdPath)
        {
            this.vhdFile = new VhdFileFactory().Create(vhdPath);
            this.blockFactory = vhdFile.GetBlockFactory();
            footerRange = this.blockFactory.GetFooterRange();
            fileDataRange = IndexRange.FromLength(0, this.Length - footerRange.Length);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
        }

        public override sealed long Length
        {
            get { return this.footerRange.EndIndex + 1; }
        }

        public override long Position
        {
            get { return this.position; }
            set
            {
                if (value < 0) throw new ArgumentException();
                if (value >= this.Length) throw new EndOfStreamException();
                this.position = value;
            }
        }

        /// <summary>
        /// Gets the extents of the stream that contain data.
        /// </summary>
        public override IEnumerable<StreamExtent> Extents
        {
            get
            {
                for (uint index = 0; index < blockFactory.BlockCount; index++)
                {
                    var block = blockFactory.Create(index);
                    if (!block.Empty)
                    {
                        yield return new StreamExtent
                        {
                            Owner = block.VhdUniqueId,
                            StartOffset = block.LogicalRange.StartIndex,
                            EndOffset = block.LogicalRange.EndIndex,
                            Range = block.LogicalRange
                        };
                    }
                }
                yield return new StreamExtent
                {
                    Owner = vhdFile.Footer.UniqueId,
                    StartOffset = this.footerRange.StartIndex,
                    EndOffset = this.footerRange.EndIndex,
                    Range = this.footerRange
                };
            }
        }

        public DiskType DiskType
        {
            get { return this.vhdFile.DiskType; }
        }

        public DiskType RootDiskType
        {
            get
            {
                var diskType = this.vhdFile.DiskType;
                for (var parent = this.vhdFile.Parent; parent != null; parent = parent.Parent)
                {
                    diskType = parent.DiskType;
                }
                return diskType;
            }
        }
        /// <summary>
        /// Reads the specified number of bytes from the current position.
        /// </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (count <= 0)
            {
                return 0;
            }

            try
            {
                var rangeToRead = IndexRange.FromLength(this.position, count);

                int writtenCount = 0;
                if (fileDataRange.Intersection(rangeToRead) == null)
                {
                    int readCountFromFooter;
                    if (TryReadFromFooter(rangeToRead, buffer, offset, out readCountFromFooter))
                    {
                        writtenCount += readCountFromFooter;
                    }
                    return writtenCount;
                }

                rangeToRead = fileDataRange.Intersection(rangeToRead);

                var startingBlock = ByteToBlock(rangeToRead.StartIndex);
                var endingBlock = ByteToBlock(rangeToRead.EndIndex);

                for (var blockIndex = startingBlock; blockIndex <= endingBlock; blockIndex++)
                {
                    var currentBlock = blockFactory.Create(blockIndex);
                    var rangeToReadInBlock = currentBlock.LogicalRange.Intersection(rangeToRead);

                    var copyStartIndex = rangeToReadInBlock.StartIndex % blockFactory.GetBlockSize();
                    Buffer.BlockCopy(currentBlock.Data, (int)copyStartIndex, buffer, offset + writtenCount, (int)rangeToReadInBlock.Length);

                    writtenCount += (int)rangeToReadInBlock.Length;
                }
                this.position += writtenCount;

                return writtenCount;
            }
            catch (Exception e)
            {
                throw new VhdParsingException("Invalid or Corrupted VHD file", e);
            }
        }

        public bool TryReadFromFooter(IndexRange rangeToRead, byte[] buffer, int offset, out int readCount)
        {
            readCount = 0;
            var rangeToReadFromFooter = this.footerRange.Intersection(rangeToRead);
            if (rangeToReadFromFooter != null)
            {
                var footerData = GenerateFooter();
                var copyStartIndex = rangeToReadFromFooter.StartIndex - footerRange.StartIndex;
                Buffer.BlockCopy(footerData, (int)copyStartIndex, buffer, offset, (int)rangeToReadFromFooter.Length);
                this.position += (int)rangeToReadFromFooter.Length;
                readCount = (int)rangeToReadFromFooter.Length;
                return true;
            }
            return false;
        }

        private uint ByteToBlock(long position)
        {
            uint sectorsPerBlock = (uint)(this.blockFactory.GetBlockSize() / VhdConstants.VHD_SECTOR_LENGTH);
            return (uint)Math.Floor((position / VhdConstants.VHD_SECTOR_LENGTH) * 1.0m / sectorsPerBlock);
        }

        private byte[] GenerateFooter()
        {
            var footer = vhdFile.Footer.CreateCopy();
            if (vhdFile.Footer.DiskType != DiskType.Fixed)
            {
                footer.HeaderOffset = VhdConstants.VHD_NO_DATA_LONG;
                footer.DiskType = DiskType.Fixed;
                footer.CreatorApplication = VhdFooterFactory.WindowsAzureCreatorApplicationName;
            }
            var serializer = new VhdFooterSerializer(footer);
            return serializer.ToByteArray();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    this.Position = offset;
                    break;
                case SeekOrigin.Current:
                    this.Position += offset;
                    break;
                case SeekOrigin.End:
                    this.Position -= offset;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return this.Position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    this.vhdFile.Dispose();
                    isDisposed = true;
                }
            }
        }
    }
}
