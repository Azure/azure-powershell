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
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public class Constants
    {
        public class JobOutputParameter
        {
            public const string Any = "Any";

            public const string Progress = JobStreamType.Progress;

            public const string Output = JobStreamType.Output;

            public const string Warning = JobStreamType.Warning;

            public const string Error = JobStreamType.Error;

            public const string Debug = JobStreamType.Debug;

            public const string Verbose = JobStreamType.Verbose;
        }

        public class AutomationAccountState
        {
            public const string Ready = "Ready";

            public const string Suspended = "Suspended";
        }

        // default schedule expiry time for daily schedule, consistent with UX
        // 12/31/9999 12:00:00 AM
        public static readonly DateTime DefaultScheduleExpiryTime = new DateTime(9999, 12, 31, 0, 0, 0, DateTimeKind.Utc);

        public const string JobStartedByParameterName = "MicrosoftApplicationManagementStartedBy";

        public const string ClientIdentity = "PowerShell";

        public const char RunbookTagsSeparatorChar = ',';

        public const string RunbookTagsSeparatorString = ",";
    }
}
