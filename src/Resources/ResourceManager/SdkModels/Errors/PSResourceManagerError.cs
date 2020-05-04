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

using System.Collections.Generic;
using System.Text;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSResourceManagerError
    {
        private const char Whitespace = ' ';

        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public List<PSResourceManagerError> Details { get; set; }

        public string ToFormattedString(int level = 0)
        {
            if (this.Details == null)
            {
                return string.Format(ProjectResources.DeploymentOperationErrorMessageNoDetails, this.Message, this.Code);
            }

            string errorDetail = null;

            foreach (PSResourceManagerError detail in this.Details)
            {
                errorDetail += GetIndentation(level) + detail.ToFormattedString(level + 1) + System.Environment.NewLine;
            }

            return string.Format(ProjectResources.DeploymentOperationErrorMessage, this.Message, this.Code, errorDetail);
        }

        private static string GetIndentation(int l)
        {
            return new StringBuilder().Append(Whitespace, l * 2).Append(" - ").ToString();
        }
    }
}
