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

using Microsoft.WindowsAzure.Commands.Tools.Common.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class VhdFileFactory
    {
        public VhdFile Create(string path)
        {
            var streamSource = new StreamSource
            {
                Stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1024),
                VhdDirectory = Path.GetDirectoryName(path),
                DisposeOnException = true
            };
            return Create(streamSource);
        }

        public VhdFile Create(Stream stream)
        {
            return Create(new StreamSource { Stream = stream });
        }

        private VhdFile Create(StreamSource streamSource)
        {
            var disposer = new Action(() => { if (streamSource.DisposeOnException) streamSource.Stream.Dispose(); });
            bool throwing = false;
            try
            {
                var reader = new BinaryReader(streamSource.Stream, Encoding.Unicode);
                var dataReader = new VhdDataReader(reader);
                var footer = new VhdFooterFactory(dataReader).CreateFooter();

                VhdHeader header = null;
                BlockAllocationTable blockAllocationTable = null;
                VhdFile parent = null;
                if (footer.DiskType != DiskType.Fixed)
                {
                    header = new VhdHeaderFactory(dataReader, footer).CreateHeader();
                    blockAllocationTable = new BlockAllocationTableFactory(dataReader, header).Create();
                    if (footer.DiskType == DiskType.Differencing)
                    {
                        var parentPath = streamSource.VhdDirectory == null ? header.ParentPath : Path.Combine(streamSource.VhdDirectory, header.GetRelativeParentPath());
                        parent = Create(parentPath);
                    }
                }
                return new VhdFile(footer, header, blockAllocationTable, parent, streamSource.Stream);
            }
            catch (Exception e)
            {
                throwing = true;
                throw new VhdParsingException("unsupported format", e);
            }
            finally
            {
                if (throwing)
                {
                    disposer();
                }
            }
        }

        private T TryCatch<T>(Func<IAsyncResult, T> method, IAsyncResult result)
        {
            try
            {
                return method(result);
            }
            catch (EndOfStreamException e)
            {
                throw new VhdParsingException("unsupported format", e);
            }
        }

        private T TryCatch<T>(Func<IAsyncResult, T> method, Action disposer, IAsyncResult result)
        {
            bool throwing = true;
            T methodResult = default(T);
            try
            {
                methodResult = method(result);
                throwing = false;
            }
            catch (EndOfStreamException e)
            {
                throw new VhdParsingException("unsupported format", e);
            }
            finally
            {
                if (throwing)
                {
                    disposer();
                }
            }
            return methodResult;
        }

        private T TryCatch<T>(Func<T> method, Action disposer)
        {
            bool throwing = true;
            T methodResult = default(T);
            try
            {
                methodResult = method();
                throwing = false;
            }
            catch (EndOfStreamException e)
            {
                throw new VhdParsingException("unsupported format", e);
            }
            finally
            {
                if (throwing)
                {
                    disposer();
                }
            }
            return methodResult;
        }

        public IAsyncResult BeginCreate(string path, AsyncCallback callback, object state)
        {
            var streamSource = new StreamSource
            {
                Stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1024),
                VhdDirectory = Path.GetDirectoryName(path),
                DisposeOnException = true
            };
            return AsyncMachine<VhdFile>.BeginAsyncMachine(this.CreateAsync, streamSource, callback, state);
        }

        public IAsyncResult BeginCreate(Stream stream, AsyncCallback callback, object state)
        {
            var streamSource = new StreamSource { Stream = stream };
            return AsyncMachine<VhdFile>.BeginAsyncMachine(this.CreateAsync, streamSource, callback, state);
        }

        public VhdFile EndCreate(IAsyncResult result)
        {
            return AsyncMachine<VhdFile>.EndAsyncMachine(result);
        }

        class StreamSource
        {
            public Stream Stream { get; set; }
            public string VhdDirectory { get; set; }
            public bool DisposeOnException { get; set; }

            public StreamSource()
            {
                this.DisposeOnException = false;
            }
        }

        private IEnumerable<CompletionPort> CreateAsync(AsyncMachine<VhdFile> machine, StreamSource streamSource)
        {
            var disposer = new Action(() => { if (streamSource.DisposeOnException) streamSource.Stream.Dispose(); });

            var reader = TryCatch(() => new BinaryReader(streamSource.Stream, Encoding.Unicode), disposer);
            var dataReader = TryCatch(() => new VhdDataReader(reader), disposer);
            var footerFactory = TryCatch(() => new VhdFooterFactory(dataReader), disposer);

            footerFactory.BeginCreateFooter(machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            var footer = TryCatch<VhdFooter>(footerFactory.EndCreateFooter, disposer, machine.CompletionResult);

            VhdHeader header = null;
            BlockAllocationTable blockAllocationTable = null;
            VhdFile parent = null;
            if (footer.DiskType != DiskType.Fixed)
            {
                var headerFactory = new VhdHeaderFactory(dataReader, footer);

                headerFactory.BeginCreateHeader(machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                header = TryCatch<VhdHeader>(headerFactory.EndCreateHeader, disposer, machine.CompletionResult);

                var tableFactory = new BlockAllocationTableFactory(dataReader, header);
                tableFactory.BeginCreate(machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                blockAllocationTable = TryCatch<BlockAllocationTable>(tableFactory.EndCreate, disposer, machine.CompletionResult);

                if (footer.DiskType == DiskType.Differencing)
                {
                    var parentPath = streamSource.VhdDirectory == null ? header.ParentPath : Path.Combine(streamSource.VhdDirectory, header.GetRelativeParentPath());

                    BeginCreate(parentPath, machine.CompletionCallback, null);
                    yield return CompletionPort.SingleOperation;
                    parent = TryCatch<VhdFile>(EndCreate, disposer, machine.CompletionResult);
                }
            }
            machine.ParameterValue = new VhdFile(footer, header, blockAllocationTable, parent, streamSource.Stream);
        }
    }
}