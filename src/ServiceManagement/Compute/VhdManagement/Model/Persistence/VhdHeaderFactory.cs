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
    public class VhdHeaderFactory
    {
        private readonly VhdDataReader dataReader;
        private readonly VhdFooter footer;
        private long headerOffset;

        public VhdHeaderFactory(VhdDataReader dataReader, VhdFooter footer)
        {
            this.dataReader = dataReader;
            this.footer = footer;
            headerOffset = this.footer.HeaderOffset;
        }

        public VhdHeader CreateHeader()
        {
            if (footer.DiskType != DiskType.Dynamic && footer.DiskType != DiskType.Differencing)
                return null;

            try
            {
                var attributeHelper = new AttributeHelper<VhdHeader>();
                var header = new VhdHeader();
                header.Cookie = ReadHeaderCookie(attributeHelper.GetAttribute(() => header.Cookie));
                header.DataOffset = ReadDataOffset(attributeHelper.GetAttribute(() => header.DataOffset));
                header.TableOffset = ReadBATOffset(attributeHelper.GetAttribute(() => header.TableOffset));
                header.HeaderVersion = ReaderHeaderVersion(attributeHelper.GetAttribute(() => header.HeaderVersion));
                header.MaxTableEntries = ReadMaxTableEntries(attributeHelper.GetAttribute(() => header.MaxTableEntries));
                header.BlockSize = ReadBlockSize(attributeHelper.GetAttribute(() => header.BlockSize));
                header.CheckSum = ReadCheckSum(attributeHelper.GetAttribute(() => header.CheckSum));
                header.ParentUniqueId = ReadParentUniqueId(attributeHelper.GetAttribute(() => header.ParentUniqueId));
                header.ParentTimeStamp = ReadParentTimeStamp(attributeHelper.GetAttribute(() => header.ParentTimeStamp));
                header.Reserverd1 = ReadReserved1(attributeHelper.GetAttribute(() => header.Reserverd1));
                header.ParentPath = ReadParentPath(attributeHelper.GetAttribute(() => header.ParentPath));
                header.ParentLocators = ReadParentLocators(attributeHelper.GetAttribute(() => header.ParentLocators));
                header.RawData = ReadRawData(attributeHelper.GetAttribute(() => header.RawData));
                return header;
            }
            catch (EndOfStreamException e)
            {
                throw new VhdParsingException("unsupported format", e);
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

        public IAsyncResult BeginCreateHeader(AsyncCallback callback, object state)
        {
            return AsyncMachine<VhdHeader>.BeginAsyncMachine(CreateVhdHeader, callback, state);
        }

        public VhdHeader EndCreateHeader(IAsyncResult result)
        {
            return AsyncMachine<VhdHeader>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> CreateVhdHeader(AsyncMachine<VhdHeader> machine)
        {
            if (footer.DiskType != DiskType.Dynamic && footer.DiskType != DiskType.Differencing)
            {
                machine.ParameterValue = null;
                yield break;
            }

            var attributeHelper = new AttributeHelper<VhdHeader>();
            var header = new VhdHeader();

            BeginReadHeaderCookie(attributeHelper.GetAttribute(() => header.Cookie), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.Cookie = TryCatch<VhdCookie>(EndReadHeaderCookie, machine.CompletionResult);

            BeginReadDataOffset(attributeHelper.GetAttribute(() => header.DataOffset), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.DataOffset = TryCatch<long>(EndReadDataOffset, machine.CompletionResult);

            BeginReadBATOffset(attributeHelper.GetAttribute(() => header.TableOffset), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.TableOffset = TryCatch<long>(EndReadBATOffset, machine.CompletionResult);

            BeginReadHeaderVersion(attributeHelper.GetAttribute(() => header.HeaderVersion), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.HeaderVersion = TryCatch<VhdHeaderVersion>(EndReadHeaderVersion, machine.CompletionResult);

            BeginReadMaxTableEntries(attributeHelper.GetAttribute(() => header.MaxTableEntries), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.MaxTableEntries = TryCatch<uint>(EndReadMaxTableEntries, machine.CompletionResult);

            BeginReadBlockSize(attributeHelper.GetAttribute(() => header.BlockSize), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.BlockSize = TryCatch<uint>(EndReadBlockSize, machine.CompletionResult);

            BeginReadCheckSum(attributeHelper.GetAttribute(() => header.CheckSum), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.CheckSum = TryCatch<uint>(EndReadCheckSum, machine.CompletionResult);

            BeginReadParentUniqueId(attributeHelper.GetAttribute(() => header.ParentUniqueId), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.ParentUniqueId = TryCatch<Guid>(EndReadParentUniqueId, machine.CompletionResult);

            BeginReadParentTimeStamp(attributeHelper.GetAttribute(() => header.ParentTimeStamp), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.ParentTimeStamp = TryCatch<DateTime>(EndReadParentTimeStamp, machine.CompletionResult);

            BeginReadReserved1(attributeHelper.GetAttribute(() => header.Reserverd1), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.Reserverd1 = TryCatch<uint>(EndReadReserved1, machine.CompletionResult);

            BeginReadParentPath(attributeHelper.GetAttribute(() => header.ParentPath), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.ParentPath = TryCatch<string>(EndReadParentPath, machine.CompletionResult);

            BeginReadParentLocators(attributeHelper.GetAttribute(() => header.ParentLocators), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.ParentLocators = TryCatch<IList<ParentLocator>>(EndReadParentLocators, machine.CompletionResult);

            BeginReadRawData(attributeHelper.GetAttribute(() => header.RawData), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            header.RawData = TryCatch<byte[]>(EndReadRawData, machine.CompletionResult);

            machine.ParameterValue = header;
        }

        private byte[] ReadRawData(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadBytes(headerOffset + attribute.Offset, attribute.Size);
        }

        private IAsyncResult BeginReadRawData(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(headerOffset + attribute.Offset, attribute.Size, callback, state);
        }

        private byte[] EndReadRawData(IAsyncResult result)
        {
            var value = dataReader.EndReadBytes(result);
            return (byte[])value;
        }

        private IList<ParentLocator> ReadParentLocators(VhdPropertyAttribute attribute)
        {
            var parentLocators = new List<ParentLocator>();
            var attributeHelper = new AttributeHelper<ParentLocator>();
            var entityAttribute = attributeHelper.GetEntityAttribute();

            long baseOffset = headerOffset + attribute.Offset;

            for (int i = 0; i < attribute.Count; i++)
            {
                var parentLocatorFactory = new VhdParentLocatorFactory(dataReader, baseOffset);
                parentLocators.Add(parentLocatorFactory.Create());
                baseOffset += entityAttribute.Size;
            }
            return parentLocators;
        }

        private IAsyncResult BeginReadParentLocators(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return AsyncMachine<IList<ParentLocator>>.BeginAsyncMachine(CreateParentLocators, attribute, callback, state);
        }

        private IEnumerable<CompletionPort> CreateParentLocators(AsyncMachine<IList<ParentLocator>> machine, VhdPropertyAttribute attribute)
        {
            var parentLocators = new List<ParentLocator>();
            var attributeHelper = new AttributeHelper<ParentLocator>();
            var entityAttribute = attributeHelper.GetEntityAttribute();

            long baseOffset = headerOffset + attribute.Offset;

            for (int i = 0; i < attribute.Count; i++)
            {
                var parentLocatorFactory = new VhdParentLocatorFactory(dataReader, baseOffset);

                parentLocatorFactory.BeginReadCreate(machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                ParentLocator parentLocator = parentLocatorFactory.EndReadCreate(machine.CompletionResult);

                parentLocators.Add(parentLocator);
                baseOffset += entityAttribute.Size;
            }
            machine.ParameterValue = parentLocators;
        }

        private IList<ParentLocator> EndReadParentLocators(IAsyncResult result)
        {
            return AsyncMachine<IList<ParentLocator>>.EndAsyncMachine(result);
        }

        private uint ReadReserved1(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadUInt32(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadReserved1(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(headerOffset + attribute.Offset, callback, state);
        }

        private uint EndReadReserved1(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (uint)value;
        }

        private uint ReadCheckSum(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadUInt32(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadCheckSum(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(headerOffset + attribute.Offset, callback, state);
        }

        private uint EndReadCheckSum(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (uint)value;
        }

        private long ReadDataOffset(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadDataOffset(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(headerOffset + attribute.Offset, callback, state);
        }

        private long EndReadDataOffset(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt64(result);
            return (long)value;
        }


        private string ReadParentPath(VhdPropertyAttribute attribute)
        {
            var parentNameBytes = dataReader.ReadBytes(headerOffset + attribute.Offset, attribute.Size);
            return Encoding.BigEndianUnicode.GetString(parentNameBytes).TrimEnd('\0');
        }

        private IAsyncResult BeginReadParentPath(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(headerOffset + attribute.Offset, attribute.Size, callback, state);
        }

        private string EndReadParentPath(IAsyncResult result)
        {
            var value = dataReader.EndReadBytes(result);
            return Encoding.BigEndianUnicode.GetString(value).TrimEnd('\0');
        }

        private DateTime ReadParentTimeStamp(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadDateTime(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadParentTimeStamp(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadDateTime(headerOffset + attribute.Offset, callback, state);
        }

        private DateTime EndReadParentTimeStamp(IAsyncResult result)
        {
            var value = dataReader.EndReadDateTime(result);
            return (DateTime)value;
        }

        private Guid ReadParentUniqueId(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadGuid(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadParentUniqueId(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadGuid(headerOffset + attribute.Offset, callback, state);
        }

        private Guid EndReadParentUniqueId(IAsyncResult result)
        {
            var value = dataReader.EndReadGuid(result);
            return (Guid)value;
        }

        private uint ReadBlockSize(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadUInt32(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadBlockSize(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(headerOffset + attribute.Offset, callback, state);
        }

        private uint EndReadBlockSize(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (uint)value;
        }

        private uint ReadMaxTableEntries(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadUInt32(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadMaxTableEntries(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(headerOffset + attribute.Offset, callback, state);
        }

        private uint EndReadMaxTableEntries(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (uint)value;
        }

        private long ReadBATOffset(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(headerOffset + attribute.Offset);
        }

        private IAsyncResult BeginReadBATOffset(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(headerOffset + attribute.Offset, callback, state);
        }

        private long EndReadBATOffset(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt64(result);
            return (long)value;
        }

        private VhdHeaderVersion ReaderHeaderVersion(VhdPropertyAttribute attribute)
        {
            var version = dataReader.ReadUInt32(headerOffset + attribute.Offset);
            var headerVersion = new VhdHeaderVersion(version);
            if (!headerVersion.IsSupported())
                throw new VhdParsingException("unsupported format");
            return headerVersion;
        }

        private IAsyncResult BeginReadHeaderVersion(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(headerOffset + attribute.Offset, callback, state);
        }

        private VhdHeaderVersion EndReadHeaderVersion(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            var headerVersion = new VhdHeaderVersion(value);
            if (!headerVersion.IsSupported())
                throw new VhdParsingException("unsupported format");
            return headerVersion;
        }

        private VhdCookie ReadHeaderCookie(VhdPropertyAttribute attribute)
        {
            var cookie = dataReader.ReadBytes(headerOffset + attribute.Offset, attribute.Size);
            var vhdCookie = new VhdCookie(VhdCookieType.Header, cookie);
            if (!vhdCookie.IsValid())
                throw new VhdParsingException(String.Format("unsupported format, Cookie:{0}", vhdCookie));
            return vhdCookie;
        }

        private IAsyncResult BeginReadHeaderCookie(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(headerOffset + attribute.Offset, attribute.Size, callback, state);
        }

        private VhdCookie EndReadHeaderCookie(IAsyncResult result)
        {
            var value = dataReader.EndReadBytes(result);
            var vhdCookie = new VhdCookie(VhdCookieType.Header, value);
            if (!vhdCookie.IsValid())
                throw new VhdParsingException(String.Format("unsupported format, Cookie:{0}", vhdCookie));
            return vhdCookie;
        }


    }
}