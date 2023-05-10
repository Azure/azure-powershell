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

using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.Properties;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    public class CommonUtils
    {
        /// <summary>
        /// Extracts the GUID from ARM id
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static string GetIdFromARMResourceId(string resourceId)
        {
            string[] tokens = resourceId.Split('/');
            if (tokens.Length == 1)
            {
                return resourceId;
            }
            else if (tokens.Length == 7)
            {
                return tokens[tokens.Length-1];
            }
            else
            {
                throw new PSArgumentException(string.Format(Resources.InvalidId, resourceId));
            }
        }

        /// <summary>
        /// Extracts resource and resource group from ARM Id
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static ExtractedInfo ExtractFromActionRuleResourceId(string resourceId)
        {
            ExtractedInfo info = new ExtractedInfo();
            string[] tokens = resourceId.Split('/');
            if (tokens.Length == 9)
            {
                info.ResourceGroupName = tokens[4];
                info.Resource = tokens[8];
                return info;
            }
            else
            {
                throw new PSArgumentException(string.Format(Resources.InvalidResourceId, resourceId));
            }
        }
    }
}