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

using Microsoft.Azure.Management.ResourceManager.Models;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsDeploymentScriptLog : PsAzureResourceBase
    {
        public string Log { get; set; }

        public string DeploymentScriptName
        {
            get
            {
                if (string.IsNullOrEmpty(this.Id)) return null;
                Regex r = new Regex(@"(.*?)/deploymentScripts/(?<dsname>\S+)/logs(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(this.Id);
                return m.Success ? m.Groups["dsname"].Value : null;
            }
        }

        internal static PsDeploymentScriptLog ToPsDeploymentScriptLog(ScriptLog scriptLog)
        {
            return new PsDeploymentScriptLog
            {
                Log = scriptLog.Log,
                Id = scriptLog.Id,
                Type = scriptLog.Type,
                Name = scriptLog.Name
            };
        }
    }
}
