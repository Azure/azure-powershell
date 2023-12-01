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
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Generate Cognitive Services Object by Type.
    /// Some commands need complex objects, this command is used to generate these objects with default parameters.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesObject", SupportsShouldProcess = true), OutputType(typeof(DeploymentProperties), typeof(CommitmentPlanProperties), typeof(MultiRegionSettings), typeof(RegionSetting), typeof(Sku), typeof(RaiPolicyProperties), typeof(RaiBlocklistProperties), typeof(RaiBlocklistItemProperties), typeof(RaiBlocklistConfig), typeof(RaiPolicyContentFilter), typeof(List<RaiBlocklistConfig>))]
    public class NewAzureCognitiveServicesObjectCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
               Position = 0,
               Mandatory = true,
               HelpMessage = "Cognitive Services Object Type.")]
        public CognitiveServicesObjectType Type { get; set; }

        [Parameter(
               Position = 1,
               Mandatory = false,
               HelpMessage = "Return the object as a List.")]
        public SwitchParameter AsList { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (AsList.IsPresent)
            {
                switch (Type)
                {
                    case CognitiveServicesObjectType.RaiBlocklistConfig:
                        {
                            var obj = new List<RaiBlocklistConfig>();
                            WriteObject(obj);
                        }
                        break;
                    default:
                        WriteError(new ErrorRecord(new Exception($"ObjectType {Type} not supported for -AsList parameter"), string.Empty, ErrorCategory.NotSpecified, null));
                        break;
                }

                return;
            }

            switch (Type)
            {
                case CognitiveServicesObjectType.DeploymentProperties:
                    {
                        var obj = new DeploymentProperties();
                        obj.Model = new DeploymentModel();
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
                case CognitiveServicesObjectType.MultiRegionSettings:
                    {
                        var obj = new MultiRegionSettings();
                        obj.Regions = new List<RegionSetting>();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RegionSetting:
                    {
                        var obj = new RegionSetting();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.Sku:
                    {
                        var obj = new Sku();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RaiPolicyProperties:
                    {
                        var obj = new RaiPolicyProperties();
                        obj.PromptBlocklists = new List<RaiBlocklistConfig>();
                        obj.CompletionBlocklists = new List<RaiBlocklistConfig>();
                        obj.ContentFilters = new List<RaiPolicyContentFilter>();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RaiBlocklistProperties:
                    {
                        var obj = new RaiBlocklistProperties();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RaiBlocklistItemProperties:
                    {
                        var obj = new RaiBlocklistItemProperties();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RaiBlocklistConfig:
                    {
                        var obj = new RaiBlocklistConfig();
                        WriteObject(obj);
                    }
                    break;
                case CognitiveServicesObjectType.RaiPolicyContentFilter:
                    {
                        var obj = new RaiPolicyContentFilter();
                        WriteObject(obj);
                    }
                    break;
            }
        }
    }

    public enum CognitiveServicesObjectType
    {
        DeploymentProperties,
        CommitmentPlanProperties,
        MultiRegionSettings,
        RegionSetting,
        Sku,
        RaiPolicyProperties,
        RaiBlocklistProperties,
        RaiBlocklistItemProperties,
        RaiBlocklistConfig,
        RaiPolicyContentFilter
    }
}
