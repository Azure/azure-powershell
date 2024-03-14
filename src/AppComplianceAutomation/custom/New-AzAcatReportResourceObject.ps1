
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
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

<#
.Synopsis
Create an in-memory object for ReportResource.
.Description
Create an in-memory object for ReportResource.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatreportresourceobject
#>
function New-AzAcatReportResourceObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]]
        # List of resource data.
        ${Resource},

        [Parameter()]
        [System.String]
        # Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.An example of valid timezone id is "Pacific Standard Time".
        ${TimeZone},

        [Parameter()]
        [System.DateTime]
        # Report collection trigger time.
        ${TriggerTime},

        [Parameter()]
        [System.String]
        # Report offer Guid.
        ${OfferGuid}
    )

    process {
        $Object = @{}

        if ($PSBoundParameters.ContainsKey("Resource")) {
            $Object.Resource = $Resource
        }

        if ($PSBoundParameters.ContainsKey("TimeZone")) {
            $Object.TimeZone = $TimeZone
        }
        else {
            $TimeZone = (Get-TimeZone).StandardName
            $Object.TimeZone = $TimeZone
        }

        if ($PSBoundParameters.ContainsKey("TriggerTime")) {
            $Object.TriggerTime = $TriggerTime
        }
        else {
            $TriggerTime = Get-Nearest-Time
            $Object.TriggerTime = $TriggerTime
        }

        if ($PSBoundParameters.ContainsKey("OfferGuid")) {
            $Object.OfferGuid = $OfferGuid
        }
        return [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.ReportResource]::DeserializeFromDictionary($Object)
    }
}
