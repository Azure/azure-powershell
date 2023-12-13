# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# Regex for ResourceId verification and parsing
$labPlanRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labPlans/(?<labPlanName>[-\w\._\(\)]{1,100})$"
$labRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labs/(?<labName>[-\w\._\(\)]{1,100})$"
$userRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labs/(?<labName>[-\w\._\(\)]{1,100})/users/(?<userName>[-\w\._\(\)]{1,100})$"
$vmRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labs/(?<labName>[-\w\._\(\)]{1,100})/virtualMachines/(?<vmName>[-\w\._\(\)]{1,100})$"
$scheduleRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labs/(?<labName>[-\w\._\(\)]{1,100})/schedules/(?<scheduleName>[-\w\._\(\)]{1,100})$"
$imageRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.LabServices/labPlans/(?<labPlanName>[-\w\._\(\)]{1,100})/images/(?<imageName>[-\w\._\(\)]{1,100})$"