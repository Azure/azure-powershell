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

using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public class PSJob
    {
        private Job job;

        public PSJob()
        {
            job = new Job();
        }

        public PSJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            this.job = job;
        }

        public string JobName
        {
            get
            {
                return job.Name;
            }
            set
            {
                job.Name = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string JobId
        {
            get
            {
                return job.Properties.JobId;
            }
            internal set
            {
                job.Properties.JobId = value;
            }
        }

        public string Location
        {
            get
            {
                return job.Location;
            }
            internal set
            {
                job.Location = value;
            }
        }

        public DateTime? CreatedDate
        {
            get
            {
                return job.Properties.CreatedDate;
            }
            internal set
            {
                job.Properties.CreatedDate = value;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return job.Properties.ProvisioningState;
            }
            internal set
            {
                job.Properties.ProvisioningState = value;
            }
        }

        public string JobState
        {
            get
            {
                return job.Properties.JobState;
            }
            internal set
            {
                job.Properties.JobState = value;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return job.Tags;
            }
            internal set
            {
                job.Tags = value;
            }
        }

        public JobProperties Properties
        {
            get
            {
                return job.Properties;
            }
            internal set
            {
                job.Properties = value;
            }
        }

        public string PropertiesInJson
        {
            get { return job.ToFormattedString(); }
        }
    }
}
