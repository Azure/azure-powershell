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
        private StreamingJob streamingJob;

        public PSJob()
        {
            streamingJob = new StreamingJob();
        }

        public PSJob(StreamingJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            this.streamingJob = job;
        }

        public string JobName
        {
            get
            {
                return streamingJob.Name;
            }
        }

        public string ResourceGroupName { get; set; }

        public string JobId
        {
            get
            {
                return streamingJob.JobId;
            }
        }

        public string Location
        {
            get
            {
                return streamingJob.Location;
            }
            internal set
            {
                streamingJob.Location = value;
            }
        }

        public DateTime? CreatedDate
        {
            get
            {
                return streamingJob.CreatedDate;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return streamingJob.ProvisioningState;
            }
        }

        public string JobState
        {
            get
            {
                return streamingJob.JobState;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return streamingJob.Tags;
            }
            internal set
            {
                streamingJob.Tags = value;
            }
        }

        public StreamingJob Properties
        {
            get
            {
                return streamingJob;
            }
            internal set
            {
                streamingJob = value;
            }
        }

        public string PropertiesInJson
        {
            get { return streamingJob.ToFormattedString(); }
        }
    }
}
