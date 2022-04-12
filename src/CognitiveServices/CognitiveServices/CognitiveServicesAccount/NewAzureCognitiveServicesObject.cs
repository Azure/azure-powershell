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

using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Generate Cognitive Services Object by Type.
    /// Some commands need complex objects, this command is used to generate these objects with default parameters.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesObject", SupportsShouldProcess = true), OutputType(typeof(DeploymentProperties), typeof(CommitmentPlanProperties))]
    public class NewAzureCognitiveServicesObjectCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
               Position = 0,
               Mandatory = true,
               HelpMessage = "Cognitive Services Object Type.")]
        public CognitiveServicesObjectType Type { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (Type)
            {
                case CognitiveServicesObjectType.DeploymentProperties:
                    {
                        var obj = new DeploymentProperties();
                        obj.Model = new DeploymentModel();
                        obj.ScaleSettings = new DeploymentScaleSettings();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.CommitmentPlanProperties:
                    {
                        var obj = new CommitmentPlanProperties();
                        obj.Current = new CommitmentPeriod();
                        obj.Next = new CommitmentPeriod();
                        WriteObject(obj);
                    }
                    break;
            }
        }
    }

    public enum CognitiveServicesObjectType
    {
        DeploymentProperties,
        CommitmentPlanProperties
    }
}
