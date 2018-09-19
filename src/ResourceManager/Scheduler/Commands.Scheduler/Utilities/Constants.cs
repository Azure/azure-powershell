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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;

    public static class Constants
    {
        #region Resource provider info

        /// <summary>
        /// Scheduler namespace.
        /// </summary>
        public static readonly string ProviderNamespace = "Microsoft.Scheduler";

        /// <summary>
        /// Scheduler Resource type.
        /// </summary>
        public static readonly string ResourceType = "JobCollections";

        /// <summary>
        /// Sheduler full resourse provide namespace.
        /// </summary>
        public static readonly string FullResourceProviderNamespace = "Microsoft.Scheduler/JobCollections";

        #endregion

        #region Job count quota.

        /// <summary>
        /// Maximum jobs for Free plan.
        /// </summary>
        public static readonly int MaxJobCountQuotaFree = 5;

        /// <summary>
        /// Maximum jobs for Standard plan.
        /// </summary>
        public static readonly int MaxJobCountQuotaStandard = 50;

        /// <summary>
        /// Maximum jobs for P10Premium plan.
        /// </summary>
        public static readonly int MaxJobCountQuotaP10Premium = 50;

        /// <summary>
        /// Maximum jobs for P20Premium plan
        /// </summary>
        public static readonly int MaxJobCountQuotaP20Premium = 1000;

        #endregion

        #region Job collection quota.

        /// <summary>
        /// Maximum job collection count for Free plan.
        /// </summary>
        public static readonly int MaxJobCollectionQuotaFree = 1;

        #endregion

        #region Recurrence quota.

        /// <summary>
        /// Minimum recurrence quota for Free plan.
        /// </summary>
        public static readonly TimeSpan MinRecurrenceQuotaFree = new TimeSpan(hours: 1, minutes: 0, seconds: 0);

        /// <summary>
        /// Minimum recurrence quota for Standard plan.
        /// </summary>
        public static readonly TimeSpan MinRecurrenceQuotaStandard = new TimeSpan(hours: 0, minutes: 1, seconds: 0);

        /// <summary>
        /// Minimum recurrence quota for P10Premium plan.
        /// </summary>
        public static readonly TimeSpan MinRecurrenceQuotaP10Premium = new TimeSpan(hours: 0, minutes: 1, seconds: 0);

        /// <summary>
        /// Minimum recurrence quota for P20Premium plan.
        /// </summary>
        public static readonly TimeSpan MinRecurrenceQuotaP20Premium = new TimeSpan(hours: 0, minutes: 1, seconds: 0);

        #endregion

        #region Plan type.

        /// <summary>
        /// Free plan type.
        /// </summary>
        public const string FreePlan = "Free";

        /// <summary>
        /// Standard plan type.
        /// </summary>
        public const string StandardPlan = "Standard";

        /// <summary>
        /// P10Premium plan type.
        /// </summary>
        public const string P10PremiumPlan = "P10Premium";

        /// <summary>
        /// P20Premium plan type.
        /// </summary>
        public const string P20PremiumPlan = "P20Premium";

        #endregion

        #region Frequency type.

        /// <summary>
        /// Recurrence every minute.
        /// </summary>
        public const string FrequencyTypeMinute = "Minute";

        /// <summary>
        /// Recurrence every hour.
        /// </summary>
        public const string FrequencyTypeHour = "Hour";

        /// <summary>
        /// Recurrence every day.
        /// </summary>
        public const string FrequencyTypeDay = "Day";

        /// <summary>
        /// Recurrence every week.
        /// </summary>
        public const string FrequencyTypeWeek = "Week";

        /// <summary>
        /// Recurrence every month.
        /// </summary>
        public const string FrequencyTypeMonth = "Month";

        #endregion

        #region JobState

        /// <summary>
        /// Job is enabled and active.
        /// </summary>
        public const string JobStateEnabled = "Enabled";

        /// <summary>
        /// Job is disabled and inactive.
        /// </summary>
        public const string JobStateDisabled = "Disabled";

        /// <summary>
        /// Job has faulted and inactive.
        /// </summary>
        public const string JobStateFaulted = "Faulted";

        /// <summary>
        /// Job has completed and inactive.
        /// </summary>
        public const string JobStateCompleted = "Completed";

        #endregion

        #region JobExecutionStatus

        /// <summary>
        /// Job instance executed succesfully.
        /// </summary>
        public const string JobCompleted = "Completed";

        /// <summary>
        /// Job instance execution failed.
        /// </summary>
        public const string JobFailed = "Failed";

        /// <summary>
        /// Job instance execution postponed.
        /// </summary>
        public const string JobPostponed = "Postponed";

        #endregion

        #region HttpMethods

        /// <summary>
        /// Get http method.
        /// </summary>
        public const string HttpMethodGET = "GET";

        /// <summary>
        /// Put http method.
        /// </summary>
        public const string HttpMethodPUT = "PUT";

        /// <summary>
        /// Post http method.
        /// </summary>
        public const string HttpMethodPOST = "POST";

        /// <summary>
        /// Delete http method.
        /// </summary>
        public const string HttpMethodDELETE = "DELETE";

        #endregion

        #region HttpScheme

        /// <summary>
        /// Http scheme.
        /// </summary>
        public const string HttpScheme = "http";

        /// <summary>
        /// Https scheme.
        /// </summary>
        public const string HttpsScheme = "https";

        #endregion

        #region HttpAuthenticationType

        /// <summary>
        /// Http authentication type None.
        /// </summary>
        public const string HttpAuthenticationNone = "None";
        
        /// <summary>
        /// Http authentication type Basic.
        /// </summary>
        public const string HttpAuthenticationBasic = "Basic";

        /// <summary>
        /// Http authentication type ClientCertificate.
        /// </summary>
        public const string HttpAuthenticationClientCertificate = "ClientCertificate";

        /// <summary>
        /// Http authentication type ActiveDirectoryOAuth.
        /// </summary>
        public const string HttpAuthenticationActiveDirectoryOAuth = "ActiveDirectoryOAuth";

        #endregion

        #region ActionSettings

        /// <summary>
        /// Http job action.
        /// </summary>
        public const string HttpAction = "Http";

        /// <summary>
        /// Https job action.
        /// </summary>
        public const string HttpsAction = "Https";

        /// <summary>
        /// Storage queue job action.
        /// </summary>
        public const string StorageQueueAction = "StorageQueue";

        /// <summary>
        /// Service bus queue job action.
        /// </summary>
        public const string ServiceBusQueueAction = "ServiceBusQueue";

        /// <summary>
        /// Service bus topic job action.
        /// </summary>
        public const string ServiceBusTopicAction = "ServiceBusTopic";

        #endregion

        #region ServiceBus Transport type
        
        /// <summary>
        /// Net messaging transport type. 
        /// </summary>
        public const string NetMessaging = "NetMessaging";

        /// <summary>
        /// AMQP transport type.
        /// </summary>
        public const string AMQP = "AMQP";

        #endregion

        #region ServiceBus SAS Authentication types

        /// <summary>
        /// Shared access key service bus authentiation type. 
        /// </summary>
        public const string SharedAccessKey = "SharedAccessKey";

        #endregion

        #region Separators

        /// <summary>
        /// Comma separator definition.
        /// </summary>
        public const char ApostropheSeparator = '\'';

        /// <summary>
        /// Colon separator definition.
        /// </summary>
        public const char ColonSeparator = ':';

        /// <summary>
        /// Comma semicolon separator definition.
        /// </summary>
        public static char[] ApostropheSemicolonSeparator = new char[] { '\'', ';' };

        #endregion
    }
}
