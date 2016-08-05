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
using Microsoft.Azure.Commands.DataFactories.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsLifecycle.Resume, Constants.Pipeline, DefaultParameterSetName = ByFactoryName, 
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class ResumeAzureDataFactoryPipelineCommand : PipelineContextBaseCmdlet
    {
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Resuming pipeline '{0}' in data factory '{1}'.",
                    Name,
                    DataFactoryName),
                Name,
                () => DataFactoryClient.ResumePipeline(ResourceGroupName, DataFactoryName, Name));

            WriteObject(true);
        }
    }
}