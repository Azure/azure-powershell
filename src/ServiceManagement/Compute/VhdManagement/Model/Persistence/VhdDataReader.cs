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
using System.Net;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class VhdDataReader
    {
        private readonly BinaryReader reader;
        private byte[] m_buffer;

        public VhdDataReader(BinaryReader reader)
        {
            this.reader = reader;
            this.m_buffer = new byte[16];
        }

        public long Size
        {
            get { return this.reader.BaseStream.Length; }
        }

        public bool ReadBoolean(long offset)
        {
            this.SetPosition(offset);
            return this.reader.ReadBoolean();
        }

        public IAsyncResult BeginReadBoolean(long offset, AsyncCallback callback, object state)
        {
            this.SetPosition(offset);
            return AsyncMachine.BeginAsyncMachine(FillBuffer, 1, callback, state);
        }

        public bool EndReadBoolean(IAsyncResult result)
        {
            AsyncMachine.EndAsyncMachine(result);
            return (m_buffer[0] != 0);
        }

        IEnumerable<CompletionPort> FillBuffer(AsyncMachine machine, int numBytes)
        {
            if (m_buffer != null && (numBytes < 0 || numBytes > m_buffer.Length))
            {
                throw new ArgumentOutOfRangeException("numBytes", String.Format("Expected (0-16) however found: {0}", numBytes));
            }
            int bytesRead = 0;
            int n = 0;

            // Need to find a good threshold for calling ReadByte() repeatedly 
            // vs. calling Read(byte[], int, int) for both buffered & unbuffered 
            // streams.
            if (numBytes == 1)
            {
                this.reader.BaseStream.BeginRead(m_buffer, 0, numBytes, machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                n = this.reader.BaseStream.EndRead(machine.CompletionResult);
                if (n == -1)
                {
                    throw new EndOfStreamException();
                }
                m_buffer[0] = (byte)n;
            }

            do
            {
                this.reader.BaseStream.BeginRead(m_buffer, bytesRead, numBytes - bytesRead, machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                n = this.reader.BaseStream.EndRead(machine.CompletionResult);

                if (n == 0)
                {
                    throw new EndOfStreamException();
                }
                bytesRead += n;
            } while (bytesRead < numBytes);
        }

        public short ReadInt16(long offset)
        {
            this.SetPosition(offset);
            return IPAddress.NetworkToHostOrder((short)this.reader.ReadUInt16());
        }

        public IAsyncResult BeginReadInt16(long offset, AsyncCallback callback, object state)
        {
            this.SetPosition(offset);
            return AsyncMachine.BeginAsyncMachine(FillBuffer, 2, callback, state);
        }

        public short EndReadInt16(IAsyncResult result)
        {
            AsyncMachine.EndAsyncMachine(result);
            short value = (short)(m_buffer[0] | m_buffer[1] << 8);
            return IPAddress.NetworkToHostOrder(value);
        }

        public uint ReadUInt32(long offset)
        {
            this.SetPosition(offset);
            return (uint)IPAddress.NetworkToHostOrder((int)this.reader.ReadUInt32());
        }

        public IAsyncResult BeginReadUInt32(long offset, AsyncCallback callback, object state)
        {
            this.SetPosition(offset);
            return AsyncMachine.BeginAsyncMachine(FillBuffer, 4, callback, state);
        }

        public uint EndReadUInt32(IAsyncResult result)
        {
            AsyncMachine.EndAsyncMachine(result);
            var value = (m_buffer[0] | m_buffer[1] << 8 | m_buffer[2] << 16 | m_buffer[3] << 24);
            return (uint)IPAddress.NetworkToHostOrder(value);
        }

        public uint ReadUInt32()
        {
            return (uint)IPAddress.NetworkToHostOrder((int)this.reader.ReadUInt32());
        }

        public IAsyncResult BeginReadUInt32(AsyncCallback callback, object state)
        {
            return AsyncMachine.BeginAsyncMachine(FillBuffer, 4, callback, state);
        }

        public ulong ReadUInt64(long offset)
        {
            this.SetPosition(offset);
            var value = (long)this.reader.ReadUInt64();
            return (ulong)IPAddress.NetworkToHostOrder(value);
        }

        public IAsyncResult BeginReadUInt64(long offset, AsyncCallback callback, object state)
        {
            this.SetPosition(offset);
            return AsyncMachine.BeginAsyncMachine(FillBuffer, 8, callback, state);
        }

        public ulong EndReadUInt64(IAsyncResult result)
        {
            AsyncMachine.EndAsyncMachine(result);
            uint lo = (uint)(m_buffer[0] | m_buffer[1] << 8 |
                             m_buffer[2] << 16 | m_buffer[3] << 24);
            uint hi = (uint)(m_buffer[4] | m_buffer[5] << 8 |
                             m_buffer[6] << 16 | m_buffer[7] << 24);
            ulong value = ((ulong)hi) << 32 | lo;
            return (ulong)IPAddress.NetworkToHostOrder((long)value);
        }

        public byte[] ReadBytes(long offset, int count)
        {
            this.SetPosition(offset);
            return this.reader.ReadBytes(count);
        }

        public IAsyncResult BeginReadBytes(long offset, int count, AsyncCallback callback, object state)
        {
            this.SetPosition(offset);
            return AsyncMachine<byte[]>.BeginAsyncMachine(ReadBytesAsync, offset, count, callback, state);
        }

        public byte[] EndReadBytes(IAsyncResult result)
        {
            return AsyncMachine<byte[]>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> ReadBytesAsync(AsyncMachine<byte[]> machine, long offset, int count)
        {
            StreamHelper.BeginReadBytes(this.reader.BaseStream, offset, count, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            byte[] values = StreamHelper.EndReadBytes(machine.CompletionResult);
            machine.ParameterValue = values;
        }

        public byte[] ReadBytes(int count)
        {
            return this.reader.ReadBytes(count);
        }

        public IAsyncResult BeginReadBytes(int count, AsyncCallback callback, object state)
        {
            return AsyncMachine<byte[]>.BeginAsyncMachine(ReadBytesAsync, this.reader.BaseStream.Position, count, callback, state);
        }

        public string ReadString(int count)
        {
            return Encoding.ASCII.GetString(this.reader.ReadBytes(count));
        }

        public IAsyncResult BeginReadString(int count, AsyncCallback callback, object state)
        {
            return AsyncMachine<string>.BeginAsyncMachine(ReadStringAsync, this.reader.BaseStream.Position, count, callback, state);
        }

        public string EndReadString(IAsyncResult result)
        {
            return AsyncMachine<string>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> ReadStringAsync(AsyncMachine<string> machine, long offset, int count)
        {
            BeginReadBytes(offset, count, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            byte[] values = EndReadBytes(machine.CompletionResult);
            machine.ParameterValue = Encoding.ASCII.GetString(values);
        }

        public byte ReadByte(long offset)
        {
            this.SetPosition(offset);
            return this.reader.ReadByte();
        }

        public IAsyncResult BeginReadByte(long offset, AsyncCallback callback, object state)
        {
            return BeginReadBytes(offset, 1, callback, state);
        }

        public byte EndReadByte(IAsyncResult result)
        {
            return EndReadBytes(result)[0];
        }

        public Guid ReadGuid(long offset)
        {
            return new Guid(this.ReadBytes(offset, 16));
        }

        public IAsyncResult BeginReadGuid(long offset, AsyncCallback callback, object state)
        {
            return BeginReadBytes(offset, 16, callback, state);
        }

        public Guid EndReadGuid(IAsyncResult result)
        {
            byte[] guidValue = EndReadBytes(result);
            return new Guid(guidValue);
        }

        public DateTime ReadDateTime(long offset)
        {
            var timeStamp = new VhdTimeStamp(this.ReadUInt32(offset));
            return timeStamp.ToDateTime();
        }

        public IAsyncResult BeginReadDateTime(long offset, AsyncCallback callback, object state)
        {
            return BeginReadUInt32(offset, callback, state);
        }

        public DateTime EndReadDateTime(IAsyncResult result)
        {
            uint value = EndReadUInt32(result);
            var timeStamp = new VhdTimeStamp(value);
            return timeStamp.ToDateTime();
        }

        public DateTime ReadDateTime()
        {
            var timeStamp = new VhdTimeStamp(this.ReadUInt32());
            return timeStamp.ToDateTime();
        }

        public IAsyncResult BeginReadDateTime(AsyncCallback callback, object state)
        {
            return BeginReadUInt32(callback, state);
        }

        public void SetPosition(long batOffset)
        {
            this.reader.BaseStream.Seek(batOffset, SeekOrigin.Begin);
        }
    }
}