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
Get security auto provisioning settings on a subscription
#>
function Get-AzureRmSecurityAutoProvisioningSetting-SubscriptionScope
{
    $autoProvisioningSettings = Get-AzSecurityAutoProvisioningSetting
	Validate-AutoProvisioningSettings $autoProvisioningSettings
}

<#
.SYNOPSIS
Get a security auto provisioning setting
#>
function Get-AzureRmSecurityAutoProvisioningSetting-SubscriptionLevelResource
{
    $autoProvisioningSettings = Get-AzSecurityAutoProvisioningSetting -Name "default"
	Validate-AutoProvisioningSettings $autoProvisioningSettings
}

<#
.SYNOPSIS
Get security auto provisioning setting by a resource ID
#>
function Get-AzureRmSecurityAutoProvisioningSetting-ResourceId
{
	$autoProvisioningSetting = Get-AzSecurityAutoProvisioningSetting | Select -First 1

    $fetchedAutoProvisioningSetting = Get-AzSecurityAutoProvisioningSetting -ResourceId $autoProvisioningSetting.Id
	Validate-AutoProvisioningSetting $autoProvisioningSetting
}

<#
.SYNOPSIS
Set security auto provisioning setting
#>
function Set-AzureRmSecurityAutoProvisioningSetting-SubscriptionLevelResource
{
    Set-AzSecurityAutoProvisioningSetting -Name "default" -EnableAutoProvision
}

<#
.SYNOPSIS
Set security auto provisioning setting by resource ID
#>
function Set-AzureRmSecurityAutoProvisioningSetting-ResourceId
{
	$autoProvisioningSetting = Get-AzSecurityAutoProvisioningSetting | Select -First 1
    Set-AzSecurityAutoProvisioningSetting -ResourceId $autoProvisioningSetting.Id -EnableAutoProvision
}

<#
.SYNOPSIS
Validates a list of security autoProvisioningSettings
#>
function Validate-AutoProvisioningSettings
{
	param($autoProvisioningSettings)

    Assert-True { $autoProvisioningSettings.Count -gt 0 }

	Foreach($autoProvisioningSetting in $autoProvisioningSettings)
	{
		Validate-AutoProvisioningSetting $autoProvisioningSetting
	}
}

<#
.SYNOPSIS
Validates a single autoProvisioningSetting
#>
function Validate-AutoProvisioningSetting
{
	param($autoProvisioningSetting)

	Assert-NotNull $autoProvisioningSetting
}