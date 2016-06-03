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
    /// A PowerShell wrapper class on top of the Pipeline type.
    /// </summary>
    public class PSPipeline
    {
        private Pipeline _pipeline;

        public PSPipeline()
        {
            this._pipeline = new Pipeline();
        }

        public PSPipeline(Pipeline pipeline)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException("pipeline");
            }

            this._pipeline = pipeline;
        }

        public string PipelineName
        {
            get
            {
                return this._pipeline.Name;
            }
            set
            {
                this._pipeline.Name = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public PipelineProperties Properties
        {
            get
            {
                return this._pipeline.Properties;
            }
            set
            {
                this._pipeline.Properties = value;
            }
        }

        public string ProvisioningState
        {
            get { return Properties == null ? string.Empty : Properties.ProvisioningState; }
        }
    }
}
