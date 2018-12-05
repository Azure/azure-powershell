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
    public class VhdFooterFactory
    {
        public const string WindowsAzureCreatorApplicationName = "wa";

        public static VhdFooter CreateFixedDiskFooter(long virtualSize)
        {
            var helper = new AttributeHelper<VhdFooter>();
            var footer = new VhdFooter();
            var reservedAttribute = helper.GetAttribute(() => footer.Reserved);

            footer.Cookie = VhdCookie.CreateFooterCookie();
            footer.Features = VhdFeature.Reserved;
            footer.FileFormatVersion = VhdFileFormatVersion.DefaultFileFormatVersion;
            footer.HeaderOffset = VhdConstants.VHD_NO_DATA_LONG;
            footer.TimeStamp = DateTime.UtcNow;
            footer.CreatorApplication = WindowsAzureCreatorApplicationName;
            footer.CreatorVersion = VhdCreatorVersion.CSUP2011;
            footer.CreatorHostOsType = HostOsType.Windows;
            footer.PhsyicalSize = virtualSize;
            footer.VirtualSize = virtualSize;
            footer.DiskGeometry = DiskGeometry.CreateFromVirtualSize(virtualSize);
            footer.DiskType = DiskType.Fixed;
            footer.UniqueId = Guid.NewGuid();
            footer.SavedState = false;
            footer.Reserved = new byte[reservedAttribute.Size];

            var footerSerializer = new VhdFooterSerializer(footer);
            var byteArray = footerSerializer.ToByteArray();

            using (var memoryStream = new MemoryStream(byteArray))
            {
                var binaryReader = new BinaryReader(memoryStream);
                var vhdDataReader = new VhdDataReader(binaryReader);
                var footerFactory = new VhdFooterFactory(vhdDataReader);
                var vhdFooter = footerFactory.CreateFooter();
                return vhdFooter;
            }
        }

        private readonly VhdDataReader dataReader;
        private readonly DiskTypeFactory diskTypeFactory;

        public VhdFooterFactory(VhdDataReader dataReader)
        {
            this.dataReader = dataReader;
            this.diskTypeFactory = new DiskTypeFactory();
        }

        public VhdFooter CreateFooter()
        {
            try
            {
                ValidateVhdSize();
                var attributeHelper = new AttributeHelper<VhdFooter>();
                var footer = new VhdFooter();
                footer.Cookie = ReadVhdCookie(attributeHelper.GetAttribute(() => footer.Cookie));
                footer.Features = ReadFeatures(attributeHelper.GetAttribute(() => footer.Features));
                footer.FileFormatVersion = ReadVhdFileFormatVersion(attributeHelper.GetAttribute(() => footer.FileFormatVersion));
                footer.HeaderOffset = ReadHeaderOffset(attributeHelper.GetAttribute(() => footer.HeaderOffset));
                footer.TimeStamp = ReadTimeStamp(attributeHelper.GetAttribute(() => footer.TimeStamp));
                footer.CreatorApplication = ReadCreatorApplication(attributeHelper.GetAttribute(() => footer.CreatorApplication));
                footer.CreatorVersion = ReadCreatorVersion(attributeHelper.GetAttribute(() => footer.CreatorVersion));
                footer.CreatorHostOsType = ReadCreatorHostOsType(attributeHelper.GetAttribute(() => footer.CreatorHostOsType));
                footer.PhsyicalSize = ReadPhysicalSize(attributeHelper.GetAttribute(() => footer.PhsyicalSize));
                footer.VirtualSize = ReadVirtualSize(attributeHelper.GetAttribute(() => footer.VirtualSize));
                footer.DiskGeometry = ReadDiskGeometry(attributeHelper.GetAttribute(() => footer.DiskGeometry));
                footer.DiskType = ReadDiskType(attributeHelper.GetAttribute(() => footer.DiskType));
                footer.CheckSum = ReadCheckSum(attributeHelper.GetAttribute(() => footer.CheckSum));
                footer.UniqueId = ReadUniqueId(attributeHelper.GetAttribute(() => footer.UniqueId));
                footer.SavedState = ReadSavedState(attributeHelper.GetAttribute(() => footer.SavedState));
                footer.Reserved = ReadReserved(attributeHelper.GetAttribute(() => footer.Reserved));
                footer.RawData = ReadWholeFooter(attributeHelper.GetAttribute(() => footer.RawData));
                return footer;
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

        public IAsyncResult BeginCreateFooter(AsyncCallback callback, object state)
        {
            return AsyncMachine<VhdFooter>.BeginAsyncMachine(CreateFooterAsync, callback, state);
        }

        public VhdFooter EndCreateFooter(IAsyncResult result)
        {
            return AsyncMachine<VhdFooter>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> CreateFooterAsync(AsyncMachine<VhdFooter> machine)
        {
            ValidateVhdSize();
            var attributeHelper = new AttributeHelper<VhdFooter>();
            var footer = new VhdFooter();

            BeginReadVhdCookie(attributeHelper.GetAttribute(() => footer.Cookie), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.Cookie = TryCatch<VhdCookie>(EndReadVhdCookie, machine.CompletionResult);

            BeginReadFeatures(attributeHelper.GetAttribute(() => footer.Features), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.Features = TryCatch<VhdFeature>(EndReadFeatures, machine.CompletionResult);

            BeginReadVhdFileFormatVersion(attributeHelper.GetAttribute(() => footer.FileFormatVersion), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.FileFormatVersion = TryCatch<VhdFileFormatVersion>(EndReadVhdFileFormatVersion, machine.CompletionResult);

            BeginReadHeaderOffset(attributeHelper.GetAttribute(() => footer.HeaderOffset), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.HeaderOffset = TryCatch<long>(EndReadHeaderOffset, machine.CompletionResult);

            BeginReadTimeStamp(attributeHelper.GetAttribute(() => footer.TimeStamp), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.TimeStamp = TryCatch<DateTime>(EndReadTimeStamp, machine.CompletionResult);

            BeginReadCreatorApplication(attributeHelper.GetAttribute(() => footer.CreatorApplication), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.CreatorApplication = TryCatch<string>(EndReadCreatorApplication, machine.CompletionResult);

            BeginReadCreatorVersion(attributeHelper.GetAttribute(() => footer.CreatorVersion), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.CreatorVersion = TryCatch<VhdCreatorVersion>(EndReadCreatorVersion, machine.CompletionResult);

            BeginReadCreatorHostOsType(attributeHelper.GetAttribute(() => footer.CreatorHostOsType), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.CreatorHostOsType = TryCatch<HostOsType>(EndReadCreatorHostOsType, machine.CompletionResult);

            BeginReadPhysicalSize(attributeHelper.GetAttribute(() => footer.PhsyicalSize), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.PhsyicalSize = TryCatch<long>(EndReadPhysicalSize, machine.CompletionResult);

            BeginReadVirtualSize(attributeHelper.GetAttribute(() => footer.VirtualSize), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.VirtualSize = TryCatch<long>(EndReadVirtualSize, machine.CompletionResult);

            BeginReadDiskGeometry(attributeHelper.GetAttribute(() => footer.DiskGeometry), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.DiskGeometry = TryCatch<DiskGeometry>(EndReadDiskGeometry, machine.CompletionResult);

            BeginReadDiskType(attributeHelper.GetAttribute(() => footer.DiskType), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.DiskType = TryCatch<DiskType>(EndReadDiskType, machine.CompletionResult);

            BeginReadCheckSum(attributeHelper.GetAttribute(() => footer.CheckSum), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.CheckSum = TryCatch<uint>(EndReadCheckSum, machine.CompletionResult);

            BeginReadUniqueId(attributeHelper.GetAttribute(() => footer.UniqueId), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.UniqueId = TryCatch<Guid>(EndReadUniqueId, machine.CompletionResult);

            BeginReadSavedState(attributeHelper.GetAttribute(() => footer.SavedState), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.SavedState = TryCatch<bool>(EndReadSavedState, machine.CompletionResult);

            BeginReadReserved(attributeHelper.GetAttribute(() => footer.Reserved), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.Reserved = TryCatch<byte[]>(EndReadReserved, machine.CompletionResult);

            BeginReadWholeFooter(attributeHelper.GetAttribute(() => footer.RawData), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            footer.RawData = TryCatch<byte[]>(EndReadWholeFooter, machine.CompletionResult);

            machine.ParameterValue = footer;
        }

        private long ReadPhysicalSize(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(this.GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadPhysicalSize(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private long EndReadPhysicalSize(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt64(result);
            return (long)value;
        }

        private byte[] ReadWholeFooter(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadBytes(GetFooterOffset() + attribute.Offset, attribute.Size);
        }

        private IAsyncResult BeginReadWholeFooter(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(this.GetFooterOffset() + attribute.Offset, attribute.Size, callback, state);
        }

        private byte[] EndReadWholeFooter(IAsyncResult result)
        {
            var value = dataReader.EndReadBytes(result);
            return (byte[])value;
        }

        private byte[] ReadReserved(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadBytes(GetFooterOffset() + attribute.Offset, attribute.Size);
        }

        private IAsyncResult BeginReadReserved(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(this.GetFooterOffset() + attribute.Offset, attribute.Size, callback, state);
        }

        private byte[] EndReadReserved(IAsyncResult result)
        {
            var value = dataReader.EndReadBytes(result);
            return (byte[])value;
        }

        private bool ReadSavedState(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadBoolean(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadSavedState(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBoolean(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private bool EndReadSavedState(IAsyncResult result)
        {
            var value = dataReader.EndReadBoolean(result);
            return (bool)value;
        }

        private uint ReadCheckSum(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadUInt32(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadCheckSum(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private uint EndReadCheckSum(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (uint)value;
        }

        private DiskGeometry ReadDiskGeometry(VhdPropertyAttribute attribute)
        {
            long offset = GetFooterOffset() + attribute.Offset;

            var attributeHelper = new AttributeHelper<DiskGeometry>();
            var diskGeometry = new DiskGeometry();
            diskGeometry.Cylinder = dataReader.ReadInt16(offset + attributeHelper.GetAttribute(() => diskGeometry.Cylinder).Offset);
            diskGeometry.Heads = dataReader.ReadByte(offset + attributeHelper.GetAttribute(() => diskGeometry.Heads).Offset);
            diskGeometry.Sectors = dataReader.ReadByte(offset + attributeHelper.GetAttribute(() => diskGeometry.Sectors).Offset);
            return diskGeometry;
        }

        private IAsyncResult BeginReadDiskGeometry(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return AsyncMachine<DiskGeometry>.BeginAsyncMachine(ReadDiskGeometryAsync, attribute, callback, state);
        }

        private DiskGeometry EndReadDiskGeometry(IAsyncResult result)
        {
            return AsyncMachine<DiskGeometry>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> ReadDiskGeometryAsync(AsyncMachine<DiskGeometry> machine, VhdPropertyAttribute attribute)
        {
            long offset = GetFooterOffset() + attribute.Offset;

            var attributeHelper = new AttributeHelper<DiskGeometry>();
            var diskGeometry = new DiskGeometry();
            dataReader.BeginReadInt16(offset + attributeHelper.GetAttribute(() => diskGeometry.Cylinder).Offset, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            diskGeometry.Cylinder = dataReader.EndReadInt16(machine.CompletionResult);

            dataReader.BeginReadByte(offset + attributeHelper.GetAttribute(() => diskGeometry.Heads).Offset, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            diskGeometry.Heads = dataReader.EndReadByte(machine.CompletionResult);

            dataReader.BeginReadByte(offset + attributeHelper.GetAttribute(() => diskGeometry.Sectors).Offset, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            diskGeometry.Sectors = dataReader.EndReadByte(machine.CompletionResult);

            machine.ParameterValue = diskGeometry;
        }

        private HostOsType ReadCreatorHostOsType(VhdPropertyAttribute attribute)
        {
            var hostOs = dataReader.ReadUInt32(GetFooterOffset() + attribute.Offset);
            return (HostOsType)hostOs;
        }

        private IAsyncResult BeginReadCreatorHostOsType(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private HostOsType EndReadCreatorHostOsType(IAsyncResult result)
        {
            var version = dataReader.EndReadUInt32(result);
            return (HostOsType)version;
        }

        private VhdCreatorVersion ReadCreatorVersion(VhdPropertyAttribute attribute)
        {
            var version = dataReader.ReadUInt32(GetFooterOffset() + attribute.Offset);
            return new VhdCreatorVersion(version);
        }

        private IAsyncResult BeginReadCreatorVersion(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private VhdCreatorVersion EndReadCreatorVersion(IAsyncResult result)
        {
            var version = dataReader.EndReadUInt32(result);
            return new VhdCreatorVersion(version);
        }

        private string ReadCreatorApplication(VhdPropertyAttribute attribute)
        {
            var creatorApplication = dataReader.ReadBytes(GetFooterOffset() + attribute.Offset, attribute.Size);
            return Encoding.ASCII.GetString(creatorApplication);
        }

        private IAsyncResult BeginReadCreatorApplication(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(this.GetFooterOffset() + attribute.Offset, attribute.Size, callback, state);
        }

        private string EndReadCreatorApplication(IAsyncResult result)
        {
            var creatorApplication = dataReader.EndReadBytes(result);
            return Encoding.ASCII.GetString(creatorApplication);
        }

        private VhdFeature ReadFeatures(VhdPropertyAttribute attribute)
        {
            return (VhdFeature)dataReader.ReadUInt32(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadFeatures(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private VhdFeature EndReadFeatures(IAsyncResult result)
        {
            return (VhdFeature)dataReader.EndReadUInt32(result);
        }

        private Guid ReadUniqueId(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadGuid(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadUniqueId(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadGuid(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private Guid EndReadUniqueId(IAsyncResult result)
        {
            return dataReader.EndReadGuid(result);
        }

        private DateTime ReadTimeStamp(VhdPropertyAttribute attribute)
        {
            return dataReader.ReadDateTime(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadTimeStamp(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadDateTime(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private DateTime EndReadTimeStamp(IAsyncResult result)
        {
            return dataReader.EndReadDateTime(result);
        }

        private long ReadHeaderOffset(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadHeaderOffset(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private long EndReadHeaderOffset(IAsyncResult result)
        {
            return (long)dataReader.EndReadUInt64(result);
        }

        private DiskType ReadDiskType(VhdPropertyAttribute attribute)
        {
            var readDiskType = dataReader.ReadUInt32(GetFooterOffset() + attribute.Offset);
            return diskTypeFactory.Create(readDiskType);
        }

        private IAsyncResult BeginReadDiskType(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private DiskType EndReadDiskType(IAsyncResult result)
        {
            var readDiskType = dataReader.EndReadUInt32(result);
            return diskTypeFactory.Create(readDiskType);
        }

        private long ReadVirtualSize(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(this.GetFooterOffset() + attribute.Offset);
        }

        private IAsyncResult BeginReadVirtualSize(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private long EndReadVirtualSize(IAsyncResult result)
        {
            return (long)dataReader.EndReadUInt64(result);
        }

        private void ValidateVhdSize()
        {
            // all VHDs are a multiple of 512 bytes.  Note that Azure page blobs must 
            // be a multiple of 512 bytes also.
            var streamLength = dataReader.Size;
            if (streamLength == 0 || streamLength < VhdConstants.VHD_FOOTER_SIZE || streamLength % VhdConstants.VHD_PAGE_SIZE != 0)
                throw new VhdParsingException(String.Format("Invalid file Size: {0}", streamLength));
        }

        private VhdFileFormatVersion ReadVhdFileFormatVersion(VhdPropertyAttribute attribute)
        {
            var version = dataReader.ReadUInt32(this.GetFooterOffset() + attribute.Offset);
            return CreateVhdFileFormatVersion(version);
        }

        private VhdFileFormatVersion CreateVhdFileFormatVersion(uint version)
        {
            var formatVersion = new VhdFileFormatVersion(version);
            if (!formatVersion.IsSupported())
                throw new VhdParsingException(String.Format("Invalid file format version: {0}", formatVersion.Data));
            return formatVersion;
        }

        private IAsyncResult BeginReadVhdFileFormatVersion(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(this.GetFooterOffset() + attribute.Offset, callback, state);
        }

        private VhdFileFormatVersion EndReadVhdFileFormatVersion(IAsyncResult result)
        {
            uint value = dataReader.EndReadUInt32(result);
            return CreateVhdFileFormatVersion(value);
        }

        private VhdCookie ReadVhdCookie(VhdPropertyAttribute attribute)
        {
            byte[] value = dataReader.ReadBytes(this.GetFooterOffset() + attribute.Offset, attribute.Size);
            return CreateVhdCookie(value);
        }

        private VhdCookie CreateVhdCookie(byte[] cookie)
        {
            var vhdCookie = new VhdCookie(VhdCookieType.Footer, cookie);
            if (!vhdCookie.IsValid())
                throw new VhdParsingException(String.Format("Invalid Vhd footer cookie:{0}", vhdCookie.StringData));
            return vhdCookie;
        }

        private IAsyncResult BeginReadVhdCookie(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(this.GetFooterOffset() + attribute.Offset, attribute.Size, callback, state);
        }

        private VhdCookie EndReadVhdCookie(IAsyncResult result)
        {
            byte[] cookie = dataReader.EndReadBytes(result);
            return CreateVhdCookie(cookie);
        }

        long GetFooterOffset()
        {
            return dataReader.Size - VhdConstants.VHD_FOOTER_SIZE;
        }
    }
}