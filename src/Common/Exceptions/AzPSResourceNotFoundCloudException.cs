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
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Common.Exceptions
{
    public class AzPSResourceNotFoundCloudException : AzPSCloudException
    {
        public AzPSResourceNotFoundCloudException(
            string message,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : this(message, ErrorKind.UserError, desensitizedMessage, innerException, lineNumber, filePath)
        {
        }

        public AzPSResourceNotFoundCloudException(
            string message,
            ErrorKind errorKind,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(message, errorKind, desensitizedMessage, innerException, lineNumber, filePath)
        {
        }
    }
}
