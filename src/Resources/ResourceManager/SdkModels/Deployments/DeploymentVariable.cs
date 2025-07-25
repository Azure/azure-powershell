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

using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class DeploymentVariable
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            int maxTypeLength = Math.Max(10, Type.Length + 2);
            string rowFormat = "{0, -" + maxTypeLength + "}  {1, -10}" + Environment.NewLine;
            result.AppendLine();
            result.AppendFormat(rowFormat, "Type", "Value");
            result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(maxTypeLength, "-"), GeneralUtilities.GenerateSeparator(10, "-"));
            result.AppendFormat(rowFormat, Type, Value.ToString().Indent(maxTypeLength + 2).Trim());
            return result.ToString();
        }
    }
}
