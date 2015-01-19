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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal static class KeyVaultExceptionHandler
    {
        /// <summary>
        /// TODO: refine exception 
        /// </summary>
        /// <param name="exception">exception to be processed</param>
        /// <returns></returns>
        public static ErrorRecord RetrieveExceptionDetails(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }
            ErrorRecord errorRecord = null;

            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                exception = innerException;
                innerException = innerException.InnerException;
            }

            errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null);           
            return errorRecord;
        }
    }
}
