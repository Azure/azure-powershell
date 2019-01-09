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

using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateWebAppNameAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var webAppName = arguments as string;
            if (CmdletHelpers.IsDeploymentSlot(webAppName))
            {
                throw new ValidationMetadataException(string.Format("Specified resource '{0}' is a non-production web app slot. Please use the AzureRMWebAppSlot cmdlets to manage this resource", webAppName));
            }
        }

        public override string ToString()
        {
            return "[ValidateWebAppName]";
        }
    }
}
