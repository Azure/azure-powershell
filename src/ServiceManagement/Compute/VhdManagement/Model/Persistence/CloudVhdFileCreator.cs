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
    public class VhdFileCreator
    {
        public static void CreateFixedVhdFile(Stream destination, long virtualSize)
        {
            var footer = VhdFooterFactory.CreateFixedDiskFooter(virtualSize);
            var serializer = new VhdFooterSerializer(footer);
            var buffer = serializer.ToByteArray();
            destination.SetLength(virtualSize + VhdConstants.VHD_FOOTER_SIZE);
            destination.Seek(-VhdConstants.VHD_FOOTER_SIZE, SeekOrigin.End);

            destination.Write(buffer, 0, buffer.Length);
            destination.Flush();
        }

        public static IAsyncResult BeginCreateFixedVhdFile(Stream destination, long size, AsyncCallback callback, object state)
        {
            return AsyncMachine.BeginAsyncMachine(CreateFixedVhdFileAtAsync, destination, size, callback, state);
        }

        public static void EndCreateFixedVhdFile(IAsyncResult result)
        {
            AsyncMachine.EndAsyncMachine(result);
        }

        private static IEnumerable<CompletionPort> CreateFixedVhdFileAtAsync(AsyncMachine machine, Stream destination, long virtualSize)
        {
            var footer = VhdFooterFactory.CreateFixedDiskFooter(virtualSize);
            var serializer = new VhdFooterSerializer(footer);
            var buffer = serializer.ToByteArray();
            destination.SetLength(virtualSize + VhdConstants.VHD_FOOTER_SIZE);
            destination.Seek(-VhdConstants.VHD_FOOTER_SIZE, SeekOrigin.End);

            destination.BeginWrite(buffer, 0, buffer.Length, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            destination.EndWrite(machine.CompletionResult);
            destination.Flush();
        }
    }
}