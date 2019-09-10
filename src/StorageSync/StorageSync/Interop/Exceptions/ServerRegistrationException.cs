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

namespace Commands.StorageSync.Interop.Exceptions
{
    using Enums;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text;

    /// <summary>
    /// Class ServerRegistrationException. This class cannot be inherited.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public sealed class ServerRegistrationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        public ServerRegistrationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public ServerRegistrationException(int errorCode)
        {
            ExternalErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="category">The category.</param>
        public ServerRegistrationException(int errorCode, ErrorCategory category)
        {
            ExternalErrorCode = errorCode;
            Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="internalErrorCode">The internal error code.</param>
        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode)
        {
            InternalErrorCode = internalErrorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="internalErrorCode">The internal error code.</param>
        /// <param name="category">The category.</param>
        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, ErrorCategory category)
        {
            InternalErrorCode = internalErrorCode;
            Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="internalErrorCode">The internal error code.</param>
        /// <param name="errorCode">The error code.</param>
        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, int errorCode)
        {
            InternalErrorCode = internalErrorCode;
            ExternalErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="internalErrorCode">The internal error code.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="category">The category.</param>
        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, int errorCode, ErrorCategory category)
        {
            InternalErrorCode = internalErrorCode;
            ExternalErrorCode = errorCode;
            Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServerRegistrationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRegistrationException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="internalErrorCode">The internal error code.</param>
        public ServerRegistrationException(string message, Exception innerException, ServerRegistrationErrorCode internalErrorCode = ServerRegistrationErrorCode.GenericError)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        public ErrorCategory Category
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the external error code.
        /// </summary>
        /// <value>The external error code.</value>
        public int ExternalErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the internal error code.
        /// </summary>
        /// <value>The internal error code.</value>
        public ServerRegistrationErrorCode InternalErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat(CultureInfo.InvariantCulture, "Category: {0}{1}", Category, Environment.NewLine);
            sb.AppendFormat(CultureInfo.InvariantCulture, "ErrorCode: {0}{1}", ExternalErrorCode, Environment.NewLine);
            sb.AppendFormat(CultureInfo.InvariantCulture, "RegistrationErrorCode: {0}{1}", InternalErrorCode, Environment.NewLine);

            return sb.ToString();
        }
    }
}
