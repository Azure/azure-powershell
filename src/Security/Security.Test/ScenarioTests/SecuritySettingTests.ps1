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
Get Azure Security Center settings on a subscription and its overrides
#>
function Get-AzureRmSecuritySetting-SubscriptionScope
{
    $settings = Get-AzSecuritySetting

	Validate-Settings $settings
}

<#
.SYNOPSIS
Get Azure Security Center setting on a subscription
#>
function Get-AzureRmSecuritySetting-SubscriptionLevelResource
{
    $setting = Get-AzSecuritySetting -SettingName "MCAS"

	Validate-Setting $setting
}

<#
.SYNOPSIS
Set an Azure Security Center setting
#>
function Set-AzureRmSecuritySetting-SubscriptionLevelResource
{
    $setting1 = Get-AzSecuritySetting -SettingName "MCAS"

	Validate-Setting $setting1

    $setting2 = Set-AzSecuritySetting -SettingName "MCAS" -Setting $setting1

	Validate-Setting $setting2
}

<#
.SYNOPSIS
Validates a list of security pricings
#>
function Validate-Settings
{
	param($settings)

    Assert-True { $settings.Count -gt 0 }

	Foreach($setting in $settings)
	{
		Validate-Setting $setting
	}
}

<#
.SYNOPSIS
Validates a single setting
#>
function Validate-Setting
{
	param($setting)

	Assert-NotNull $setting
}