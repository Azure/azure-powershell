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
    /// The exception that is thrown when failing to activate an application package
    /// </summary>
    [Serializable]
    internal sealed class ActivateApplicationPackageException : Exception
    {
        public ActivateApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        private ActivateApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}