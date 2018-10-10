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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    [VhdEntity(Size = 4)]
    public class DiskGeometry
    {
        public static DiskGeometry CreateFromVirtualSize(long size)
        {
            long totalSectors = size / VhdConstants.VHD_SECTOR_LENGTH;
            if (totalSectors > 65535 * 16 * 255)
            {
                totalSectors = 65535 * 16 * 255;
            }

            int sectorsPerTrack;
            int heads;
            long cylinderTimesHeads;
            if (totalSectors >= 65535 * 16 * 63)
            {
                sectorsPerTrack = 255;
                heads = 16;
                cylinderTimesHeads = totalSectors / sectorsPerTrack;
            }
            else
            {
                sectorsPerTrack = 17;
                cylinderTimesHeads = totalSectors / sectorsPerTrack;

                heads = (int)((cylinderTimesHeads + 1023) / 1024);

                if (heads < 4)
                {
                    heads = 4;
                }
                if (cylinderTimesHeads >= (heads * 1024) || heads > 16)
                {
                    sectorsPerTrack = 31;
                    heads = 16;
                    cylinderTimesHeads = totalSectors / sectorsPerTrack;
                }
                if (cylinderTimesHeads >= (heads * 1024))
                {
                    sectorsPerTrack = 63;
                    heads = 16;
                    cylinderTimesHeads = totalSectors / sectorsPerTrack;
                }
            }
            long cylinders = cylinderTimesHeads / heads;

            return new DiskGeometry
            {
                Cylinder = (short)cylinders,
                Heads = (byte)heads,
                Sectors = (byte)sectorsPerTrack
            };
        }

        [VhdProperty(Offset = 0, Size = 2)]
        public short Cylinder { get; set; }

        [VhdProperty(Offset = 2, Size = 1)]
        public byte Heads { get; set; }

        [VhdProperty(Offset = 3, Size = 1)]
        public byte Sectors { get; set; }

        public DiskGeometry CreateCopy()
        {
            return new DiskGeometry
            {
                Cylinder = this.Cylinder,
                Heads = this.Heads,
                Sectors = this.Sectors
            };
        }

        public override string ToString()
        {
            return String.Format("Cylinder:{0}, Heads:{1}, Sector:{2}", Cylinder, Heads, Sectors);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(DiskGeometry)) return false;
            return Equals((DiskGeometry)obj);
        }

        private bool Equals(DiskGeometry other)
        {
            return other.Cylinder == Cylinder && other.Heads == Heads && other.Sectors == Sectors;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Cylinder.GetHashCode();
                result = (result * 397) ^ Heads.GetHashCode();
                result = (result * 397) ^ Sectors.GetHashCode();
                return result;
            }
        }
    }
}