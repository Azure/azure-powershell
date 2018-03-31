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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSActivityRun
    {
        private ActivityRun activityRun;

        public PSActivityRun()
        {
            this.activityRun = new ActivityRun();
        }

        public PSActivityRun(ActivityRun activityRun, string resourceGroupName, string factoryName)
        {
            if (activityRun == null)
            {
                throw new ArgumentNullException("activityRun");
            }

            this.activityRun = activityRun;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string ActivityName
        {
            get
            {
                return this.activityRun.ActivityName;
            }
        }

        public string PipelineRunId
        {
            get
            {
                return this.activityRun.PipelineRunId;
            }
        }

        public string PipelineName
        {
            get
            {
                return this.activityRun.PipelineName;
            }
        }

        public object Input
        {
            get
            {
                return this.activityRun.Input;
            }
        }

        public object Output
        {
            get
            {
                return this.activityRun.Output;
            }
        }

        public string LinkedServiceName
        {
            get
            {
                return this.activityRun.LinkedServiceName;
            }
        }

        public DateTime? ActivityRunStart
        {
            get
            {
                return this.activityRun.ActivityRunStart;
            }
        }

        public DateTime? ActivityRunEnd
        {
            get
            {
                return this.activityRun.ActivityRunEnd;
            }
        }

        public int? DurationInMs
        {
            get
            {
                return this.activityRun.DurationInMs;
            }
        }

        public string Status
        {
            get
            {
                return this.activityRun.Status;
            }
        }

        public object Error
        {
            get
            {
                return this.activityRun.Error;
            }
        }
    }
}
