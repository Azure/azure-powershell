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
using System.IO;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class VhdDataWriter
    {
        private readonly BinaryWriter writer;

        public VhdDataWriter(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public long Size
        {
            get { return this.writer.BaseStream.Length; }
        }

        public void WriteBoolean(long offset, bool value)
        {
            this.SetPosition(offset);
            this.writer.Write(value);
        }

        public void WriteInt(long offset, int value)
        {
            this.SetPosition(offset);
            this.writer.Write((uint)IPAddress.HostToNetworkOrder(value));
        }

        public void WriteInt16(long offset, Int16 value)
        {
            this.SetPosition(offset);
            this.writer.Write(IPAddress.HostToNetworkOrder((short)value));
        }

        public void WriteInt16(Int16 value)
        {
            this.writer.Write(IPAddress.HostToNetworkOrder((short)value));
        }

        public void WriteUInt(long offset, uint value)
        {
            this.SetPosition(offset);
            this.writer.Write((uint)IPAddress.HostToNetworkOrder((int)value));
        }

        public void WriteUInt(uint value)
        {
            this.writer.Write((uint)IPAddress.HostToNetworkOrder((int)value));
        }

        public void WriteLong(long offset, long value)
        {
            this.SetPosition(offset);
            var result = (ulong)IPAddress.HostToNetworkOrder(value);
            this.writer.Write(result);
        }

        public void WriteBytes(long offset, byte[] value)
        {
            this.SetPosition(offset);
            this.writer.Write(value);
        }

        public void WriteByte(long offset, byte value)
        {
            this.SetPosition(offset);
            this.writer.Write(value);
        }

        public void WriteByte(byte value)
        {
            this.writer.Write(value);
        }

        public void WriteGuid(long offset, Guid value)
        {
            this.SetPosition(offset);
            this.writer.Write(value.ToByteArray());
        }

        public void WriteTimeStamp(long offset, DateTime value)
        {
            this.SetPosition(offset);
            var timeStamp = new VhdTimeStamp(value);
            uint result = (uint)IPAddress.HostToNetworkOrder((int)timeStamp.TotalSeconds);
            this.writer.Write(result);
        }

        public void SetPosition(long batOffset)
        {
            this.writer.BaseStream.Seek(batOffset, SeekOrigin.Begin);
        }
    }
}