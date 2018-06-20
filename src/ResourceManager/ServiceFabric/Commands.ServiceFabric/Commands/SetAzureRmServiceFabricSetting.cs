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
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, CmdletNoun.AzureRmServiceFabricSetting, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class SetAzureRmServiceFabricSetting : ServiceFabricSettingsCmdletBase
    {            
        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var settings = FabricSettingsToDictionary(cluster.FabricSettings);

            foreach (var setting in this.UpdatedSettingsSectionDescriptionList)
            {
                if (!settings.ContainsKey(setting.Name))
                {
                    settings[setting.Name] = new System.Collections.Generic.Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                }

                foreach (var ps in setting.Parameters)
                {
                    settings[setting.Name][ps.Name] = ps.Value;
                }
            }

            var fabricSettings = DictionaryToFabricSettings(settings);

            if (ShouldProcess(target: this.Name, action: string.Format("Set fabric settings of {0} ", this.Name)))
            {
                cluster = SendPatchRequest(new ClusterUpdateParameters()
                {
                    FabricSettings = fabricSettings
                });

                WriteObject((PSCluster) cluster, true);
            }
        }               
    }
}