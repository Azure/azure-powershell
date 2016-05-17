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

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    /// <summary>
    /// A PowerShell wrapper class on top of the DataSlice type.
    /// </summary>
    public class PSDataSlice
    {
        private DataSlice dataSlice;

        public PSDataSlice()
        {
            dataSlice = new DataSlice();
        }

        public PSDataSlice(DataSlice dataSlice)
        {
            if (dataSlice == null)
            {
                throw new ArgumentNullException("dataSlice");
            }

            this.dataSlice = dataSlice;
        }

        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public string DatasetName { get; set; }

        public DateTime Start
        {
            get
            {
                return dataSlice.Start;
            }
            internal set
            {
                dataSlice.Start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return dataSlice.End;
            }
            internal set
            {
                dataSlice.End = value;
            }
        }

        public int RetryCount
        {
            get
            {
                return dataSlice.RetryCount;
            }
            internal set
            {
                dataSlice.RetryCount = value;
            }
        }

        public string State
        {
            get
            {
                return dataSlice.State;
            }
            internal set
            {
                dataSlice.State = value;
            }
        }

        public string SubState
        {
            get
            {
                return dataSlice.Substate;
            }
            internal set
            {
                dataSlice.Substate = value;
            }
        }

        public string LatencyStatus
        {
            get
            {
                return dataSlice.LatencyStatus;
            }
            internal set
            {
                dataSlice.LatencyStatus = value;
            }
        }

        public int LongRetryCount
        {
            get
            {
                return dataSlice.LongRetryCount;
            }
            internal set
            {
                dataSlice.LongRetryCount = value;
            }
        }
    }
}
