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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSPipelineRun
    {
        private PipelineRun pipelineRun;

        public PSPipelineRun()
        {
            this.pipelineRun = new PipelineRun();
        }

        public PSPipelineRun(PipelineRun pipelineRun, string resourceGroupName, string factoryName)
        {
            if (pipelineRun == null)
            {
                throw new ArgumentNullException("pipelineRun");
            }

            this.pipelineRun = pipelineRun;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string RunId
        {
            get
            {
                return this.pipelineRun.RunId;
            }
        }

        public string PipelineName
        {
            get
            {
                return this.pipelineRun.PipelineName;
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return this.pipelineRun.LastUpdated;
            }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                return this.pipelineRun.Parameters;
            }
        }
        
        public DateTime? RunStart
        {
            get
            {
                return this.pipelineRun.RunStart;
            }
        }

        public DateTime? RunEnd
        {
            get
            {
                return this.pipelineRun.RunEnd;
            }
        }

        public int? DurationInMs
        {
            get
            {
                return this.pipelineRun.DurationInMs;
            }
        }

        public string Status
        {
            get
            {
                return this.pipelineRun.Status;
            }
        }

        public string Message
        {
            get
            {
                return this.pipelineRun.Message;
            }
        }
    }
}
