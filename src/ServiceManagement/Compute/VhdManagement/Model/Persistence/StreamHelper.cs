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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class StreamHelper
    {
        public static IAsyncResult BeginReadBytes(Stream stream, long offset, int length, AsyncCallback callback, object state)
        {
            stream.Seek(offset, SeekOrigin.Begin);
            return AsyncMachine<byte[]>.BeginAsyncMachine(ReadBytesAsync, stream, length, callback, state);
        }

        public static IAsyncResult BeginReadBytes(Stream stream, long offset, int length, SeekOrigin origin, AsyncCallback callback, object state)
        {
            stream.Seek(-offset, SeekOrigin.End);
            return AsyncMachine<byte[]>.BeginAsyncMachine(ReadBytesAsync, stream, length, callback, state);
        }

        public static byte[] EndReadBytes(IAsyncResult result)
        {
            return AsyncMachine<byte[]>.EndAsyncMachine(result);
        }

        public static IEnumerable<CompletionPort> ReadBytesAsync(AsyncMachine<byte[]> machine, Stream stream, int length)
        {
            var attributeHelper = new AttributeHelper<VhdHeader>();
            var buffer = new byte[length];

            int readCount = 0;
            int remaining = length;
            while (remaining > 0)
            {
                stream.BeginRead(buffer, readCount, remaining, machine.CompletionCallback, null);
                yield return CompletionPort.SingleOperation;
                var currentRead = stream.EndRead(machine.CompletionResult);
                if (currentRead == 0)
                {
                    break;
                }
                readCount += currentRead;
                remaining -= currentRead;
            }
            machine.ParameterValue = buffer;
            yield break;
        }

        public static byte[] ReadBytes(Stream stream, long offset, int length)
        {
            stream.Seek(offset, SeekOrigin.Begin);
            return ReadBytes(stream, length);
        }

        public static byte[] ReadBytes(Stream stream, long offset, int length, SeekOrigin origin)
        {
            stream.Seek(-offset, origin);
            return ReadBytes(stream, length);
        }

        private static byte[] ReadBytes(Stream stream, int length)
        {
            var buffer = new byte[length];
            int readCount = 0;
            int remaining = length;
            while (remaining > 0)
            {
                var currentRead = stream.Read(buffer, readCount, remaining);
                if (currentRead == 0)
                {
                    break;
                }
                readCount += currentRead;
                remaining -= currentRead;
            }

            return buffer;
        }
    }
}