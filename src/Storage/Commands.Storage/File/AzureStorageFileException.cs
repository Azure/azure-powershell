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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using System;
    using System.Management.Automation;
    using System.Runtime.Serialization;

    /// <summary>
    /// Provides the exception object thrown by AzureStorageFile cmdlets.
    /// </summary>
    [Serializable]
    public class AzureStorageFileException : Exception
    {
        /// <summary>
        /// Stores the error record.
        /// </summary>
        private ErrorRecord record;

        /// <summary>
        /// Initializes a new instance of the AzureStorageFileException class.
        /// </summary>
        /// <param name="category">Indicating the error cateogory.</param>
        /// <param name="errorId">Indicating the error id.</param>
        /// <param name="errorDetails">Indicating the error message.</param>
        /// <param name="targetObject">Indicating the target object.</param>
        public AzureStorageFileException(ErrorCategory category, string errorId, string errorDetails, object targetObject)
            : base(errorDetails)
        {
            this.record = new ErrorRecord(this, errorId, category, targetObject);
            this.record.ErrorDetails = new ErrorDetails(errorDetails);
        }

        /// <summary>
        /// Initializes a new instance of the AzureStorageFileException class from the serialization info.
        /// </summary>
        /// <param name="info">Indicating the serialization info.</param>
        /// <param name="context">Indicating the streaming context.</param>
        protected AzureStorageFileException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.record = (ErrorRecord)info.GetValue("Record", typeof(ErrorRecord));
        }

        /// <summary>
        /// Gets the serialization info for serialization.
        /// </summary>
        /// <param name="info">Indicating the serialization info.</param>
        /// <param name="context">Indicating the streaming context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Record", record);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Gets the error record represents this exception.
        /// </summary>
        /// <returns>Returns an instance of ErrorRecord.</returns>
        internal ErrorRecord GetErrorRecord()
        {
            return this.record;
        }
    }
}
