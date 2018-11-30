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


using Microsoft.WindowsAzure.Commands.Sync.IO;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    [DataContract]
    public class FileMetaData
    {
        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string FileFullName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        private string InternalCreatedDateUtc { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 30)]
        private string InternalLastModifiedDateUtc { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 40)]
        public long Size { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 50)]
        public long VhdSize { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 60)]
        public byte[] MD5Hash { get; set; }

        public DateTime CreatedDateUtc
        {
            get { return DateTime.Parse(this.InternalCreatedDateUtc, DateTimeFormatInfo.InvariantInfo); }
            set { this.InternalCreatedDateUtc = value.ToString(DateTimeFormatInfo.InvariantInfo); }
        }

        public DateTime LastModifiedDateUtc
        {
            get { return DateTime.Parse(this.InternalLastModifiedDateUtc, DateTimeFormatInfo.InvariantInfo); }
            set { this.InternalLastModifiedDateUtc = value.ToString(DateTimeFormatInfo.InvariantInfo); }
        }

        public static FileMetaData Create(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException(filePath);
            }

            using (var stream = new VirtualDiskStream(filePath))
            {
                return new FileMetaData
                {
                    FileFullName = fileInfo.FullName,
                    CreatedDateUtc = DateTime.SpecifyKind(fileInfo.CreationTimeUtc, DateTimeKind.Utc),
                    LastModifiedDateUtc = DateTime.SpecifyKind(fileInfo.LastWriteTimeUtc, DateTimeKind.Utc),
                    Size = fileInfo.Length,
                    VhdSize = stream.Length,
                    MD5Hash = CalculateMd5Hash(stream, filePath)
                };
            }
        }

        private static byte[] CalculateMd5Hash(Stream stream, string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var swrp = new StreamWithReadProgress(stream, TimeSpan.FromSeconds(1)))
                {
                    var bs = new BufferedStream(swrp);
                    Program.SyncOutput.MessageCalculatingMD5Hash(filePath);
                    var md5Hash = md5.ComputeHash(bs);
                    Program.SyncOutput.MessageMD5HashCalculationFinished();
                    return md5Hash;
                }
            }
        }
    }

    [DataContract]
    public class SystemInformation
    {
        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string MachineName { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public int CsUploadProcessId { get; set; }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static SystemInformation Create()
        {
            return new SystemInformation
            {
                MachineName = Environment.MachineName,
                CsUploadProcessId = Process.GetCurrentProcess().Id
            };
        }
    }


    [DataContract]
    public class LocalMetaData
    {
        public static string MetaDataKey = "localmetadata";

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public FileMetaData FileMetaData { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public SystemInformation SystemInformation { get; set; }
    }

    [DataContract]
    public class LeaseMetaData
    {
        public static string MetaDataKey = "leasemetadata";

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public Guid LeaseId { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public DateTime LeaseExpirationDateUtc { get; set; }
    }

    [DataContract]
    public class BlobMetaData
    {
        public static string MetaDataKey = "blobmetadata";

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string ETag { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public DateTime LastModifiedUtc { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 30)]
        public byte[] MD5Hash { get; set; }
    }
}