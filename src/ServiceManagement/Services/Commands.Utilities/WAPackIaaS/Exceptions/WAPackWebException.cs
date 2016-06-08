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
using System.Net;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions
{
    [Serializable]
    public class WAPackWebException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        private const string StatusCodeName = "StatusCode";

        public WAPackWebException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public WAPackWebException(HttpStatusCode statusCode, string message, Exception exception)
            : base(message, exception)
        {
            this.StatusCode = statusCode;
        }

        public WAPackWebException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.StatusCode = (HttpStatusCode)info.GetValue(WAPackWebException.StatusCodeName,
                typeof(HttpStatusCode));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(WAPackWebException.StatusCodeName, this.StatusCode);
        }
    }
}
