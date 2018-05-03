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

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when the user requests a DMS object that does not exist
    /// </summary>
    [Serializable]
    class NotFoundException : DataMigrationServiceExceptionBase
    {
        public NotFoundException() { }

        public NotFoundException(string message)
        : base(message) { }

        public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
