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
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to upload a file to Azure Storage
    /// </summary>
    [Serializable]
    internal sealed class UploadApplicationPackageException : Exception
    {
        public UploadApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        private UploadApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}