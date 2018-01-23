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

using System.IO;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class VhdFooterSerializer
    {
        private readonly VhdFooter vhdFooter;
        private AttributeHelper<VhdFooter> attributeHelper;

        public VhdFooterSerializer(VhdFooter vhdFooter)
        {
            this.vhdFooter = vhdFooter;
            this.attributeHelper = new AttributeHelper<VhdFooter>();
        }

        public byte[] ToByteArray()
        {
            var buffer = new byte[attributeHelper.GetEntityAttribute().Size];
            using (var stream = new MemoryStream(buffer))
            {
                var writer = new BinaryWriter(stream);
                var dataWriter = new VhdDataWriter(writer);
                dataWriter.WriteBytes(attributeHelper.GetAttribute(() => vhdFooter.Cookie).Offset, vhdFooter.Cookie.Data);

                dataWriter.WriteUInt(attributeHelper.GetAttribute(() => vhdFooter.Features).Offset, (uint)vhdFooter.Features);
                dataWriter.WriteInt(attributeHelper.GetAttribute(() => vhdFooter.FileFormatVersion).Offset,
                                    (int)vhdFooter.FileFormatVersion.Data);
                dataWriter.WriteLong(attributeHelper.GetAttribute(() => vhdFooter.HeaderOffset).Offset, vhdFooter.HeaderOffset);
                dataWriter.WriteTimeStamp(attributeHelper.GetAttribute(() => vhdFooter.TimeStamp).Offset, vhdFooter.TimeStamp);
                dataWriter.WriteBytes(attributeHelper.GetAttribute(() => vhdFooter.CreatorApplication).Offset,
                                      Encoding.ASCII.GetBytes(vhdFooter.CreatorApplication));
                dataWriter.WriteUInt(attributeHelper.GetAttribute(() => vhdFooter.CreatorVersion).Offset,
                                     vhdFooter.CreatorVersion.Data);
                dataWriter.WriteUInt(attributeHelper.GetAttribute(() => vhdFooter.CreatorHostOsType).Offset,
                                     (uint)vhdFooter.CreatorHostOsType);
                dataWriter.WriteLong(attributeHelper.GetAttribute(() => vhdFooter.PhsyicalSize).Offset, vhdFooter.PhsyicalSize);
                dataWriter.WriteLong(attributeHelper.GetAttribute(() => vhdFooter.VirtualSize).Offset, vhdFooter.VirtualSize);

                dataWriter.SetPosition(attributeHelper.GetAttribute(() => vhdFooter.DiskGeometry).Offset);
                WriteDiskGeometry(dataWriter, vhdFooter.DiskGeometry);

                dataWriter.WriteInt(attributeHelper.GetAttribute(() => vhdFooter.DiskType).Offset, (int)vhdFooter.DiskType);
                dataWriter.WriteGuid(attributeHelper.GetAttribute(() => vhdFooter.UniqueId).Offset, vhdFooter.UniqueId);
                dataWriter.WriteBoolean(attributeHelper.GetAttribute(() => vhdFooter.SavedState).Offset, vhdFooter.SavedState);
                dataWriter.WriteBytes(attributeHelper.GetAttribute(() => vhdFooter.Reserved).Offset, vhdFooter.Reserved);

                dataWriter.WriteUInt(attributeHelper.GetAttribute(() => vhdFooter.CheckSum).Offset, ComputeCheckSum(buffer));
            }
            return buffer;
        }

        public uint ComputeCheckSum(byte[] buffer)
        {
            uint checksum = 0;
            for (var i = 0; i < attributeHelper.GetEntityAttribute().Size; i++)
            {
                if (i < VhdConstants.VHD_FOOTER_OFFSET_CHECKSUM || i >= (VhdConstants.VHD_FOOTER_OFFSET_CHECKSUM + 4))
                {
                    checksum += buffer[i];
                }
            }
            return ~checksum;
        }

        private static void WriteDiskGeometry(VhdDataWriter dataWriter, DiskGeometry diskGeometry)
        {
            dataWriter.WriteInt16(diskGeometry.Cylinder);
            dataWriter.WriteByte(diskGeometry.Heads);
            dataWriter.WriteByte(diskGeometry.Sectors);
        }
    }
}