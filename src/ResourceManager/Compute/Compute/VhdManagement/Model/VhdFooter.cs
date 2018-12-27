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

using System;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    [VhdEntity(Size = 512)]
    public class VhdFooter
    {
        [VhdProperty(Offset = 0, Size = 8)]
        public VhdCookie Cookie { get; set; }

        [VhdProperty(Offset = 8, Size = 4)]
        public VhdFeature Features { get; set; }

        [VhdProperty(Offset = 12, Size = 4)]
        public VhdFileFormatVersion FileFormatVersion { get; set; }

        [VhdProperty(Offset = 16, Size = 8)]
        public long HeaderOffset { get; set; }

        [VhdProperty(Offset = 24, Size = 4)]
        public DateTime TimeStamp { get; set; }

        [VhdProperty(Offset = 28, Size = 4)]
        public string CreatorApplication { get; set; }

        [VhdProperty(Offset = 32, Size = 4)]
        public VhdCreatorVersion CreatorVersion { get; set; }

        [VhdProperty(Offset = 36, Size = 4)]
        public HostOsType CreatorHostOsType { get; set; }

        [VhdProperty(Offset = 40, Size = 8)]
        public long PhsyicalSize { get; set; }

        [VhdProperty(Offset = 48, Size = 8)]
        public long VirtualSize { get; set; }

        [VhdProperty(Offset = 56, Size = 4)]
        public DiskGeometry DiskGeometry { get; set; }

        [VhdProperty(Offset = 60, Size = 4)]
        public DiskType DiskType { get; set; }

        [VhdProperty(Offset = 64, Size = 4)]
        public uint CheckSum { get; set; }

        [VhdProperty(Offset = 68, Size = 16)]
        public Guid UniqueId { get; set; }

        [VhdProperty(Offset = 84, Size = 1)]
        public bool SavedState { get; set; }

        [VhdProperty(Offset = 85, Size = 427)]
        public byte[] Reserved { get; set; }

        [VhdProperty(Offset = 0, Size = 512)]
        public byte[] RawData { get; set; }

        public VhdFooter CreateCopy()
        {
            return new VhdFooter
            {
                Cookie = this.Cookie.CreateCopy(),
                Features = this.Features,
                FileFormatVersion = this.FileFormatVersion,
                HeaderOffset = this.HeaderOffset,
                TimeStamp = this.TimeStamp,
                CreatorApplication = this.CreatorApplication,
                CreatorVersion = this.CreatorVersion,
                CreatorHostOsType = this.CreatorHostOsType,
                PhsyicalSize = this.PhsyicalSize,
                VirtualSize = this.VirtualSize,
                DiskGeometry = this.DiskGeometry.CreateCopy(),
                DiskType = this.DiskType,
                CheckSum = this.CheckSum,
                UniqueId = this.UniqueId,
                SavedState = this.SavedState,
                Reserved = CreateCopy(this.Reserved),
                RawData = CreateCopy(this.RawData),
            };
        }

        static byte[] CreateCopy(byte[] data)
        {
            var result = new byte[data.Length];
            Array.Copy(data, result, data.Length);
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as VhdFooter);
        }

        private bool Equals(VhdFooter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Cookie, Cookie) && Equals(other.Features, Features) && Equals(other.FileFormatVersion, FileFormatVersion) && other.HeaderOffset == HeaderOffset && other.TimeStamp.Equals(TimeStamp) && Equals(other.CreatorApplication, CreatorApplication) && Equals(other.CreatorVersion, CreatorVersion) && Equals(other.CreatorHostOsType, CreatorHostOsType) && other.PhsyicalSize == PhsyicalSize && other.VirtualSize == VirtualSize && Equals(other.DiskGeometry, DiskGeometry) && Equals(other.DiskType, DiskType) && other.CheckSum == CheckSum && other.UniqueId.Equals(UniqueId) && other.SavedState.Equals(SavedState) && Equals(other.Reserved, Reserved) && Equals(other.RawData, RawData);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Cookie != null ? Cookie.GetHashCode() : 0);
                result = (result * 397) ^ Features.GetHashCode();
                result = (result * 397) ^ (FileFormatVersion != null ? FileFormatVersion.GetHashCode() : 0);
                result = (result * 397) ^ HeaderOffset.GetHashCode();
                result = (result * 397) ^ TimeStamp.GetHashCode();
                result = (result * 397) ^ (CreatorApplication != null ? CreatorApplication.GetHashCode() : 0);
                result = (result * 397) ^ (CreatorVersion != null ? CreatorVersion.GetHashCode() : 0);
                result = (result * 397) ^ CreatorHostOsType.GetHashCode();
                result = (result * 397) ^ PhsyicalSize.GetHashCode();
                result = (result * 397) ^ VirtualSize.GetHashCode();
                result = (result * 397) ^ (DiskGeometry != null ? DiskGeometry.GetHashCode() : 0);
                result = (result * 397) ^ DiskType.GetHashCode();
                result = (result * 397) ^ CheckSum.GetHashCode();
                result = (result * 397) ^ UniqueId.GetHashCode();
                result = (result * 397) ^ SavedState.GetHashCode();
                result = (result * 397) ^ (Reserved != null ? Reserved.GetHashCode() : 0);
                result = (result * 397) ^ (RawData != null ? RawData.GetHashCode() : 0);
                return result;
            }
        }
    }
}