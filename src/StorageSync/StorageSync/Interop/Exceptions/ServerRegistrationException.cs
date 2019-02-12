﻿// ----------------------------------------------------------------------------------
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

    [Serializable]
    public sealed class ServerRegistrationException : Exception
    {
        public ServerRegistrationException()
        {
        }

        public ServerRegistrationException(int errorCode)
        {
            ExternalErrorCode = errorCode;
        }

        public ServerRegistrationException(int errorCode, ErrorCategory category)
        {
            ExternalErrorCode = errorCode;
            Category = category;
        }

        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode)
        {
            InternalErrorCode = internalErrorCode;
        }

        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, ErrorCategory category)
        {
            InternalErrorCode = internalErrorCode;
            Category = category;
        }

        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, int errorCode)
        {
            InternalErrorCode = internalErrorCode;
            ExternalErrorCode = errorCode;
        }

        public ServerRegistrationException(ServerRegistrationErrorCode internalErrorCode, int errorCode, ErrorCategory category)
        {
            InternalErrorCode = internalErrorCode;
            ExternalErrorCode = errorCode;
            Category = category;
        }

        public ServerRegistrationException(string message)
            : base(message)
        {
        }

        public ServerRegistrationException(string message, Exception innerException, ServerRegistrationErrorCode internalErrorCode = ServerRegistrationErrorCode.GenericError)
            : base(message, innerException)
        {
        }

        public ErrorCategory Category
        {
            get;
            private set;
        }

        public int ExternalErrorCode
        {
            get;
            private set;
        }

        public ServerRegistrationErrorCode InternalErrorCode
        {
            get;
            private set;
        }

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
