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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    internal class CmdletWarningAndErrorMessages
    {
        internal class Job
        {
            public const string RefineFilters = "There are more than 1000 jobs for the filter combination you have provided. Kindly refine your filters to fetch the job you want.";
            public const string AllowedDateTimeRangeExceeded = "To filter should not be more than 30 days away from From filter.";
            public const string JobIdAndJobMismatch = "JobID and Job object provided don't match each other";
            public const string ToShouldBeLessThanFrom = "To filter should not less than From filter.";
            public const string WaitJobInvalidInput = "Please pass Job or List of Jobs as input. Your input is of type: ";
        }
    }
}
