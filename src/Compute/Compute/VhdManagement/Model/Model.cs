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
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    [Flags]
    public enum VhdValidationType
    {
        None,
        IsVhd,
        FixedDisk,
    }

    public class VhdValidator
    {
        public static IList<VhdValidationResult> Validate(VhdValidationType validation, string path)
        {
            var fileFactory = new VhdFileFactory();
            VhdFile vhdFile = null;
            Exception exception = null;
            try
            {
                vhdFile = fileFactory.Create(path);
            }
            catch (VhdParsingException e)
            {
                exception = e;
            }

            return DoValidate(validation, vhdFile, exception);
        }

        public static IList<VhdValidationResult> Validate(VhdValidationType validation, Stream vhdStream)
        {

            var fileFactory = new VhdFileFactory();
            VhdFile vhdFile = null;
            Exception exception = null;
            try
            {
                vhdFile = fileFactory.Create(vhdStream);
            }
            catch (VhdParsingException e)
            {
                exception = e;
            }

            return DoValidate(validation, vhdFile, exception);
        }

        private static IList<VhdValidationResult> DoValidate(VhdValidationType validation, VhdFile vhdFile, Exception exception)
        {
            var result = new List<VhdValidationResult>();

            if ((validation & VhdValidationType.IsVhd) == VhdValidationType.IsVhd)
            {
                var validationResult = new VhdValidationResult
                {
                    ValidationType = VhdValidationType.IsVhd
                };
                if (vhdFile == null)
                {
                    validationResult.ErrorCode = 1000;
                    validationResult.Error = exception;
                }
                result.Add(validationResult);
            }

            if ((validation & VhdValidationType.FixedDisk) == VhdValidationType.FixedDisk)
            {
                var validationResult = new VhdValidationResult
                {
                    ValidationType = VhdValidationType.FixedDisk
                };
                if (vhdFile == null || vhdFile.Footer.DiskType != DiskType.Fixed)
                {
                    validationResult.ErrorCode = 1001;
                }
                result.Add(validationResult);
            }
            return result;
        }

        public static IAsyncResult BeginValidate(VhdValidationType validation, Stream vhdStream, AsyncCallback callback, object state)
        {
            return AsyncMachine<IList<VhdValidationResult>>.BeginAsyncMachine(ValidateAsync, validation, vhdStream, callback, state);
        }

        public static IList<VhdValidationResult> EndValidate(IAsyncResult result)
        {
            return AsyncMachine<IList<VhdValidationResult>>.EndAsyncMachine(result);
        }

        private static IEnumerable<CompletionPort> ValidateAsync(AsyncMachine<IList<VhdValidationResult>> machine, VhdValidationType validation, Stream vhdStream)
        {
            var result = new List<VhdValidationResult>();

            var fileFactory = new VhdFileFactory();

            fileFactory.BeginCreate(vhdStream, machine.CompletionCallback, null);
            yield return CompletionPort.SingleOperation;

            VhdFile vhdFile = null;
            Exception exception = null;
            try
            {
                vhdFile = fileFactory.EndCreate(machine.CompletionResult);
            }
            catch (VhdParsingException e)
            {
                exception = e;
            }

            machine.ParameterValue = DoValidate(validation, vhdFile, exception);
        }
    }

    public class VhdValidationResult
    {
        public int ErrorCode { get; set; }
        public VhdValidationType ValidationType { get; set; }
        public Exception Error { get; set; }
    }

    [Serializable]
    public class VhdParsingException : Exception
    {
        public VhdParsingException()
        {
        }

        public VhdParsingException(string message) : base(message)
        {
        }

        public VhdParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VhdParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
