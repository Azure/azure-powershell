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
function Get-AzureRmDeviceSecurityGroup-ResourceIdScope
{
	$RuleType = "ActiveConnectionsNotInAllowedRange"
	$TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule = New-AzDeviceSecurityGroupTimeWindowRuleObject -Type $RuleType -Enabled $true -MaxThreshold 30 -MinThreshold 0 -TimeWindowSize $TimeWindowSize
	$TimeWindowRules = @($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId -TimeWindowRule $TimeWindowRules

    $groups = Get-AzDeviceSecurityGroup -HubResourceId $HubResourceId
	Validate-Groups $groups
}

<#
.SYNOPSIS
Get device security group by its name
#>
function Get-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
	
	$RuleType = "ActiveConnectionsNotInAllowedRange"
	$TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule = New-AzDeviceSecurityGroupTimeWindowRuleObject -Type $RuleType -Enabled $true -MaxThreshold 30 -MinThreshold 0 -TimeWindowSize $TimeWindowSize
	$TimeWindowRules = @($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId -TimeWindowRule $TimeWindowRules

    $group = Get-AzDeviceSecurityGroup -HubResourceId $HubResourceId -Name $Name 
	Validate-Group $group
}

<#
.SYNOPSIS
Set device security group
#>
function Set-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
    $RuleType = "ActiveConnectionsNotInAllowedRange"
	$TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule = New-AzDeviceSecurityGroupTimeWindowRuleObject -Type $RuleType -Enabled $true -MaxThreshold 30 -MinThreshold 0 -TimeWindowSize $TimeWindowSize
	$TimeWindowRules = @($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId -TimeWindowRule $TimeWindowRules
	Validate-Group $group
}

<#
.SYNOPSIS
Delete device security group
#>
function Remove-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
	$RuleType = "ActiveConnectionsNotInAllowedRange"
	$TimeWindowSize = New-TimeSpan -Minutes 5
	$TimeWindowRule = New-AzDeviceSecurityGroupTimeWindowRuleObject -Type $RuleType -Enabled $true -MaxThreshold 30 -MinThreshold 0 -TimeWindowSize $TimeWindowSize
	$TimeWindowRules = @($TimeWindowRule);

	$HubResourceId = "/subscriptions/075423e9-7d33-4166-8bdf-3920b04e3735/resourceGroups/MichalResourceGroup/providers/Microsoft.Devices/IotHubs/MichalDemoHub"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId -TimeWindowRule $TimeWindowRules
	Remove-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId
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