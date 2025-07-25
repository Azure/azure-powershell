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
	$HubResourceId = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/IOT-ResourceGroup-CUS/providers/Microsoft.Devices/IotHubs/SDK-IotHub-CUS"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId
	 $groups = Get-AzDeviceSecurityGroup -HubResourceId $HubResourceId
	Validate-Groups $groups
}
<#
.SYNOPSIS
Get device security group by its name
#>
function Get-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
	$HubResourceId = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/IOT-ResourceGroup-CUS/providers/Microsoft.Devices/IotHubs/SDK-IotHub-CUS"
	$Name = "samplesecuritygroup"
	Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId
	 $group = Get-AzDeviceSecurityGroup -HubResourceId $HubResourceId -Name $Name
	Validate-Group $group
}
<#
.SYNOPSIS
Set device security group
#>
function Set-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
	$HubResourceId = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/IOT-ResourceGroup-CUS/providers/Microsoft.Devices/IotHubs/SDK-IotHub-CUS"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId
	Validate-Group $group
}
<#
.SYNOPSIS
Delete device security group
#>
function Remove-AzureRmDeviceSecurityGroup-ResourceIdLevelResource
{
	$HubResourceId = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/IOT-ResourceGroup-CUS/providers/Microsoft.Devices/IotHubs/SDK-IotHub-CUS"
	$Name = "samplesecuritygroup"
	$group = Set-AzDeviceSecurityGroup -Name $Name -HubResourceId $HubResourceId
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