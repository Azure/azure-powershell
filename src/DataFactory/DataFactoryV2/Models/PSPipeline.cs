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
    public class PSPipeline : AdfSubResource
    {
        private PipelineResource _pipeline;

        public PSPipeline()
        {
            this._pipeline = new PipelineResource();
        }

        public PSPipeline(PipelineResource pipeline, string resourceGroupName, string factoryName)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException("pipeline");
            }

            this._pipeline = pipeline;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return this._pipeline.Name;
            }
        }

        public IList<Activity> Activities
        {
            get
            {
                return this._pipeline.Activities;
            }
            set
            {
                this._pipeline.Activities = value;
            }
        }

        public IDictionary<string, ParameterSpecification> Parameters
        {
            get
            {
                return this._pipeline.Parameters;
            }
            set
            {
                this._pipeline.Parameters = value;
            }
        }

        public override string Id
        {
            get
            {
                return this._pipeline.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this._pipeline.Etag;
            }
        }
    }
}
