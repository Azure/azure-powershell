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

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the LogProfileResource, but in the old namespace
    /// </summary>
    public class LogProfileResource : Monitor.Models.LogProfileResource
    {
        /// <summary>
        /// Initializes a new instance of the LogProfileResource class.
        /// </summary>
        public LogProfileResource()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogProfileResource class.
        /// </summary>
        /// <param name="logProfileResource">The log profile</param>
        public LogProfileResource(Monitor.Models.LogProfileResource logProfileResource)
            : base(
                  location: logProfileResource?.Location,
                  id: logProfileResource?.Id,
                  name: logProfileResource?.Name,
                  type: logProfileResource?.Type,
                  tags: logProfileResource?.Tags,
                  categories: logProfileResource?.Categories,
                  retentionPolicy: logProfileResource?.RetentionPolicy,
                  storageAccountId: logProfileResource?.StorageAccountId,
                  serviceBusRuleId: logProfileResource?.ServiceBusRuleId,
                  locations: logProfileResource?.Locations)
        {
        }
    }
}
