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
Get an Azure Security Center setting on a subscription
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
function Set-AzureRmSecuritySetting-SettingsScope
{
    $updatedSetting = Set-AzSecuritySetting -SettingName "MCAS" -SettingKind "DataExportSettings" -Enabled $true

	Validate-Setting $updatedSetting
	Validate-EnabledProperty $updatedSetting
}

<#
.SYNOPSIS
Validates a list of security settings
#>
function Validate-Settings
{
	param($settings)

    Assert-True { $settings.Count -eq 4 }

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

<#
.SYNOPSIS
Validates the enabled property in a setting
#>
function Validate-EnabledProperty
{
	param($setting)

	Assert-True { $setting.Enabled -eq $true }
}