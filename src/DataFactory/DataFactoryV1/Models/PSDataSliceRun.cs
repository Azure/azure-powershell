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

using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    /// <summary>
    /// A PowerShell wrapper class on top of the DataSlice type.
    /// </summary>
    public class PSDataSliceRun
    {
        private DataSliceRun dataSliceRun;

        public PSDataSliceRun()
        {
            dataSliceRun = new DataSliceRun();
        }

        public PSDataSliceRun(DataSliceRun dataSliceRun)
        {
            if (dataSliceRun == null)
            {
                throw new ArgumentNullException("dataSliceRun");
            }

            this.dataSliceRun = dataSliceRun;
        }

        public string Id
        {
            get
            {
                return dataSliceRun.Id;
            }
            internal set
            {
                dataSliceRun.Id = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public string DatasetName { get; set; }

        public DateTime ProcessingStartTime
        {
            get
            {
                return dataSliceRun.ProcessingStartTime;
            }
            internal set
            {
                dataSliceRun.ProcessingStartTime = value;
            }
        }

        public DateTime ProcessingEndTime
        {
            get
            {
                return dataSliceRun.ProcessingEndTime;
            }
            internal set
            {
                dataSliceRun.ProcessingEndTime = value;
            }
        }

        public int PercentComplete
        {
            get
            {
                return dataSliceRun.PercentComplete;
            }
            internal set
            {
                dataSliceRun.PercentComplete = value;
            }
        }

        public DateTime DataSliceStart
        {
            get
            {
                return dataSliceRun.DataSliceStart;
            }
            internal set
            {
                dataSliceRun.DataSliceStart = value;
            }
        }

        public DateTime DataSliceEnd
        {
            get
            {
                return dataSliceRun.DataSliceEnd;
            }
            internal set
            {
                dataSliceRun.DataSliceEnd = value;
            }
        }

        public string Status
        {
            get
            {
                return dataSliceRun.Status;
            }
            internal set
            {
                dataSliceRun.Status = value;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return dataSliceRun.Timestamp;
            }
            internal set
            {
                dataSliceRun.Timestamp = value;
            }
        }

        public int RetryAttempt
        {
            get
            {
                return dataSliceRun.RetryAttempt;
            }
            internal set
            {
                dataSliceRun.RetryAttempt = value;
            }
        }

        public IDictionary<string, string> Properties
        {
            get
            {
                return dataSliceRun.Properties;
            }
            internal set
            {
                dataSliceRun.Properties = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return dataSliceRun.ErrorMessage;
            }
            internal set
            {
                dataSliceRun.ErrorMessage = value;
            }
        }

        public string ActivityName
        {
            get
            {
                return dataSliceRun.ActivityName;
            }
            internal set
            {
                dataSliceRun.ActivityName = value;
            }
        }

        public string PipelineName
        {
            get
            {
                return dataSliceRun.PipelineName;
            }
            internal set
            {
                dataSliceRun.PipelineName = value;
            }
        }

        public string Type
        {
            get
            {
                return dataSliceRun.Type;
            }
            internal set
            {
                dataSliceRun.Type = value;
            }
        }
    }
}
