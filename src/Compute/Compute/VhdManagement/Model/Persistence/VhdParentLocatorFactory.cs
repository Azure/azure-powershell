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
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence
{
    public class VhdParentLocatorFactory
    {
        private readonly VhdDataReader dataReader;
        private readonly long offset;
        private AttributeHelper<ParentLocator> attributeHelper;

        public VhdParentLocatorFactory(VhdDataReader dataReader, long offset)
        {
            this.dataReader = dataReader;
            this.offset = offset;
            attributeHelper = new AttributeHelper<ParentLocator>();
        }

        public ParentLocator Create()
        {
            var locator = new ParentLocator();
            locator.PlatformCode = ReadPlaformCode(attributeHelper.GetAttribute(() => locator.PlatformCode));
            locator.PlatformDataSpace = ReadPlatformDataSpace(attributeHelper.GetAttribute(() => locator.PlatformDataSpace));
            locator.PlatformDataLength = ReadPlatformDataLength(attributeHelper.GetAttribute(() => locator.PlatformDataLength));
            locator.Reserved = ReadReserved(attributeHelper.GetAttribute(() => locator.Reserved));
            locator.PlatformDataOffset = ReadPlatformDataOffset(attributeHelper.GetAttribute(() => locator.PlatformDataOffset));
            locator.PlatformSpecificFileLocator = ReadFileLocator(locator);
            return locator;
        }

        public IAsyncResult BeginReadCreate(AsyncCallback callback, object state)
        {
            return AsyncMachine<ParentLocator>.BeginAsyncMachine(CreateParentLocator, callback, state);
        }

        public ParentLocator EndReadCreate(IAsyncResult result)
        {
            return AsyncMachine<ParentLocator>.EndAsyncMachine(result);
        }

        private IEnumerable<CompletionPort> CreateParentLocator(AsyncMachine<ParentLocator> machine)
        {
            var locator = new ParentLocator();

            BeginReadPlatformCode(attributeHelper.GetAttribute(() => locator.PlatformCode), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.PlatformCode = EndReadPlatformCode(machine.CompletionResult);

            BeginReadPlatformDataSpace(attributeHelper.GetAttribute(() => locator.PlatformDataSpace), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.PlatformDataSpace = EndReadPlatformDataSpace(machine.CompletionResult);

            BeginReadPlatformDataLength(attributeHelper.GetAttribute(() => locator.PlatformDataLength), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.PlatformDataLength = EndReadPlatformDataLength(machine.CompletionResult);

            BeginReadReserved(attributeHelper.GetAttribute(() => locator.Reserved), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.Reserved = EndReadReserved(machine.CompletionResult);

            BeginReadPlatformDataOffset(attributeHelper.GetAttribute(() => locator.PlatformDataOffset), machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.PlatformDataOffset = EndReadPlatformDataOffset(machine.CompletionResult);

            BeginReadFileLocator(locator, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;
            locator.PlatformSpecificFileLocator = EndReadFileLocator(machine.CompletionResult);

            machine.ParameterValue = locator;
        }

        private string ReadFileLocator(ParentLocator locator)
        {
            var fileLocator = dataReader.ReadBytes(locator.PlatformDataOffset, locator.PlatformDataLength);
            return CreateFileLocator(locator, fileLocator);
        }

        private string CreateFileLocator(ParentLocator locator, byte[] fileLocator)
        {
            switch (locator.PlatformCode)
            {
                case PlatformCode.None:
                    return String.Empty;
                case PlatformCode.Wi2R:
                case PlatformCode.Wi2K:
                    throw new VhdParsingException(String.Format("Deprecated PlatformCode:{0}", locator.PlatformCode));
                case PlatformCode.W2Ru:
                    //TODO: Add differencing disks path name, this is relative path
                    return Encoding.Unicode.GetString(fileLocator);
                case PlatformCode.W2Ku:
                    return Encoding.Unicode.GetString(fileLocator);
                case PlatformCode.Mac:
                    //TODO: Mac OS alias stored as a blob?
                    throw new NotImplementedException(String.Format("PlatformCode: {0}", locator.PlatformCode));
                case PlatformCode.MacX:
                    return Encoding.UTF8.GetString(fileLocator);
            }
            return Encoding.BigEndianUnicode.GetString(fileLocator).TrimEnd('\0');
        }

        private IAsyncResult BeginReadFileLocator(ParentLocator locator, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadBytes(locator.PlatformDataOffset, locator.PlatformDataLength, callback, locator);
        }

        private string EndReadFileLocator(IAsyncResult result)
        {
            var fileLocator = dataReader.EndReadBytes(result);
            var locator = (ParentLocator)result.AsyncState;
            return CreateFileLocator(locator, fileLocator);
        }

        private PlatformCode ReadPlaformCode(VhdPropertyAttribute attribute)
        {
            return (PlatformCode)dataReader.ReadUInt32(offset + attribute.Offset);
        }

        private IAsyncResult BeginReadPlatformCode(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(offset + attribute.Offset, callback, state);
        }

        private PlatformCode EndReadPlatformCode(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (PlatformCode)value;
        }

        private int ReadPlatformDataSpace(VhdPropertyAttribute attribute)
        {
            return (int)dataReader.ReadUInt32(offset + attribute.Offset);
        }

        private IAsyncResult BeginReadPlatformDataSpace(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(offset + attribute.Offset, callback, state);
        }

        private int EndReadPlatformDataSpace(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (int)value;
        }

        private int ReadPlatformDataLength(VhdPropertyAttribute attribute)
        {
            return (int)dataReader.ReadUInt32(offset + attribute.Offset);
        }

        private IAsyncResult BeginReadPlatformDataLength(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(offset + attribute.Offset, callback, state);
        }

        private int EndReadPlatformDataLength(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (int)value;
        }

        private int ReadReserved(VhdPropertyAttribute attribute)
        {
            return (int)dataReader.ReadUInt32(offset + attribute.Offset);
        }

        private IAsyncResult BeginReadReserved(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt32(offset + attribute.Offset, callback, state);
        }

        private int EndReadReserved(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt32(result);
            return (int)value;
        }

        private long ReadPlatformDataOffset(VhdPropertyAttribute attribute)
        {
            return (long)dataReader.ReadUInt64(offset + attribute.Offset);
        }

        private IAsyncResult BeginReadPlatformDataOffset(VhdPropertyAttribute attribute, AsyncCallback callback, object state)
        {
            return dataReader.BeginReadUInt64(offset + attribute.Offset, callback, state);
        }

        private long EndReadPlatformDataOffset(IAsyncResult result)
        {
            var value = dataReader.EndReadUInt64(result);
            return (long)value;
        }

    }
}