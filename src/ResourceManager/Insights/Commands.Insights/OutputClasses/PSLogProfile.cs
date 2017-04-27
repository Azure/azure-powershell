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

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSLogProfile : LogProfileResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLogProfile"/> class.
        /// </summary>
        /// <param name="logProfile">The input logProfile</param>
        public PSLogProfile(LogProfileResource logProfile)
            : base(
                id: logProfile.Id, 
                name: logProfile.Name,
                location: logProfile.Location, 
                locations: logProfile.Locations, 
                categories: logProfile.Categories,
                retentionPolicy: new PSRetentionPolicy(logProfile.RetentionPolicy))
        {
            this.ServiceBusRuleId = logProfile.ServiceBusRuleId;
            this.StorageAccountId = logProfile.StorageAccountId;
        }
    }
}
