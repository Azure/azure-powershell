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
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Common.Exceptions
{
    public class AzPSFileNotFoundException : FileNotFoundException, IContainsAzPSErrorData
    {
        private string NotFoundFileName
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.FileNameKey);
            set => Data.SetValue(AzurePSErrorDataKeys.FileNameKey, value);
        }

        public ErrorKind ErrorKind
        {
            get => Data.GetValue<ErrorKind>(AzurePSErrorDataKeys.ErrorKindKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorKindKey, value);
        }

        public string DesensitizedErrorMessage
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.DesensitizedErrorMessageKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.DesensitizedErrorMessageKey, value);
        }

        public int? ErrorLineNumber
        {
            get => Data.GetNullableValue<int>(AzurePSErrorDataKeys.ErrorLineNumberKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorLineNumberKey, value);
        }

        public string ErrorFileName
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.ErrorFileNameKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorFileNameKey, value);
        }

        public AzPSFileNotFoundException(
            string message,
            string notFoundFileName,
            Exception innerException = null,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : this(message, notFoundFileName, ErrorKind.UserError, innerException, desensitizedMessage, lineNumber, filePath)
        {
        }

        public AzPSFileNotFoundException(
            string message,
            string notFoundFileName,
            ErrorKind errorKind,
            Exception innerException = null,
            string desensitizedMessage = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(message, notFoundFileName, innerException)
        {
            ErrorKind = errorKind;
            DesensitizedErrorMessage = desensitizedMessage;
            ErrorLineNumber = lineNumber;
            if(!string.IsNullOrEmpty(notFoundFileName))
            {
                NotFoundFileName = Path.GetFileName(notFoundFileName);
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                ErrorFileName = Path.GetFileNameWithoutExtension(filePath);
            }
        }
    }
}
