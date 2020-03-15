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

<#
.SYNOPSIS
Get device security groups by the IoT hub resource Id
#>
function Get-AzureRmDeviceSecurityGroups-ResourceIdScope
{
	$TimeWindowRule = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule
	$TimeWindowRule.TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule.MinThreshold = 0
	$TimeWindowRule.MaxThreshold = 30
	$TimeWindowRule.DisplayName = "Number of active connections is not in allowed range"
	$TimeWindowRule.Description = "Get an alert when the number of active connections of a device in the time window is not in the allowed range"
	$TimeWindowRule.IsEnabled = $true
	$TimeWindowRule.RuleType = "ActiveConnectionsNotInAllowedRange"

	$TimeWindowRules = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule]
	$TimeWindowRules.Add($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroups -Name $Name -HubResourceId $HubResourceId -TimeWindowRules $TimeWindowRules

    $groups = Get-AzDeviceSecurityGroups -HubResourceId $HubResourceId
	Validate-Groups $groups
}

<#
.SYNOPSIS
Get device security group by its name
#>
function Get-AzureRmDeviceSecurityGroups-ResourceIdLevelResource
{
	
	$TimeWindowRule = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule
	$TimeWindowRule.TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule.MinThreshold = 0
	$TimeWindowRule.MaxThreshold = 30
	$TimeWindowRule.DisplayName = "Number of active connections is not in allowed range"
	$TimeWindowRule.Description = "Get an alert when the number of active connections of a device in the time window is not in the allowed range"
	$TimeWindowRule.IsEnabled = $true
	$TimeWindowRule.RuleType = "ActiveConnectionsNotInAllowedRange"

	$TimeWindowRules = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule]
	$TimeWindowRules.Add($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroups -Name $Name -HubResourceId $HubResourceId -TimeWindowRules $TimeWindowRules

    $group = Get-AzDeviceSecurityGroups -HubResourceId $HubResourceId -Name $Name 
	Validate-Group $group
}

<#
.SYNOPSIS
Set device security group
#>
function Set-AzureRmDeviceSecurityGroups-ResourceIdLevelResource
{
    $TimeWindowRule = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule
	$TimeWindowRule.TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule.MinThreshold = 0
	$TimeWindowRule.MaxThreshold = 30
	$TimeWindowRule.DisplayName = "Number of active connections is not in allowed range"
	$TimeWindowRule.Description = "Get an alert when the number of active connections of a device in the time window is not in the allowed range"
	$TimeWindowRule.IsEnabled = $true
	$TimeWindowRule.RuleType = "ActiveConnectionsNotInAllowedRange"

	$TimeWindowRules = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule]
	$TimeWindowRules.Add($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroups -Name $Name -HubResourceId $HubResourceId -TimeWindowRules $TimeWindowRules
	Validate-Group $group
}

<#
.SYNOPSIS
Delete device security group
#>
function Remove-AzureRmDeviceSecurityGroups-ResourceIdLevelResource
{
	$TimeWindowRule = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule
	$TimeWindowRule.TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule.MinThreshold = 0
	$TimeWindowRule.MaxThreshold = 30
	$TimeWindowRule.DisplayName = "Number of active connections is not in allowed range"
	$TimeWindowRule.Description = "Get an alert when the number of active connections of a device in the time window is not in the allowed range"
	$TimeWindowRule.IsEnabled = $true
	$TimeWindowRule.RuleType = "ActiveConnectionsNotInAllowedRange"

	$TimeWindowRules = New-Object System.Collections.Generic.List[Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups.PSTimeWindowCustomAlertRule]
	$TimeWindowRules.Add($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroups -Name $Name -HubResourceId $HubResourceId -TimeWindowRules $TimeWindowRules
	Remove-AzDeviceSecurityGroups -Name $Name -HubResourceId $HubResourceId
	Validate-Group $group
}

<#
.SYNOPSIS
Validates a list of iot security solutions
#>
function Validate-Groups
{
	param($groups)

    Assert-True { $groups.Count -gt 0 }

	Foreach($group in $groups)
	{
		Validate-Group $group
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Group
{
	param($group)

	Assert-NotNull $group
}