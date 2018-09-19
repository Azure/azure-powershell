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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Define constants that are common for all DataService models.
    /// </summary>
    public static class DataServiceConstants
    {
        /// <summary>
        /// The service endpoint for management service.
        /// </summary>
        public static readonly string ManagementServiceUri = "v1/ManagementService.svc/";

        /// <summary>
        /// The name of the Header that holds the session tracing activityId.
        /// </summary>
        public static readonly string SessionTraceActivityHeader = "x-ms-client-session-id";

        /// <summary>
        /// The name of the Header that holds the access token.
        /// </summary>
        public static readonly string AccessTokenHeader = "AccessToken";

        /// <summary>
        /// The name of the access cookie.
        /// </summary>
        public static readonly string AccessCookie = ".SQLSERVERMANAGEMENT";

        /// <summary>
        /// The relative <see cref="Uri"/> to the GetAccessToken operation.
        /// </summary>
        public static readonly string AccessTokenOperation = "GetAccessToken";
        
        /// <summary>
        /// The name of a supplemental property added to the Exception.Data property bag when an exception should be 
        /// mapped to a SQL Server error. Identifies one of the message_id values in sys.messages. 
        /// </summary>
        public static readonly string SqlMessageIdKey = "Microsoft.SqlServer.MessageId";

        /// <summary>
        /// The name of a supplemental property added to the Exception.Data property bag when an exception should be 
        /// mapped to a SQL Server error. Determines the severity level that is associated with the error. 
        /// </summary>
        public static readonly string SqlMessageSeverityKey = "Microsoft.SqlServer.MessageSeverity";

        /// <summary>
        /// The name of a supplemental property added to the Exception.Data property bag when an
        /// exception should be mapped to a SQL Server error. Identifies the text of a message in
        /// sys.messages. 
        /// </summary>
        public static readonly string SqlMessageTextKey = "Microsoft.SqlServer.MessageText";
    }
}
