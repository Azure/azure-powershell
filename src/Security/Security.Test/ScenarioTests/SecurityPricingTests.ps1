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
Get Azure Security Center pricing settings on a subscription and its overrides
#>
function Get-AzureRmSecurityPricing-SubscriptionScope
{
    $pricings = Get-AzureRmSecurityPricing
	Validate-Pricings $pricings
}

<#
.SYNOPSIS
Get Azure Security Center pricing settings override on a resource group
#>
function Get-AzureRmSecurityPricing-ResourceGroupScope
{
	$rgName = Get-TestResourceGroupName

    $pricings = Get-AzureRmSecurityPricing -ResourceGroupName $rgName
	Validate-Pricings $pricings
}

<#
.SYNOPSIS
Get Azure Security Center pricing settings on a subscription
#>
function Get-AzureRmSecurityPricing-SubscriptionLevelResource
{
    $pricings = Get-AzureRmSecurityPricing -Name "default"
	Validate-Pricings $pricings
}

<#
.SYNOPSIS
Get Azure Security Center pricing settings override on a resource group
#>
function Get-AzureRmSecurityPricing-ResourceGroupLevelResource
{
	$rgName = Get-TestResourceGroupName

    $pricings = Get-AzureRmSecurityPricing -ResourceGroupName $rgName -Name $rgName
	Validate-Pricings $pricings
}

<#
.SYNOPSIS
Get Azure Security Center pricing settings by a resource ID
#>
function Get-AzureRmSecurityPricing-ResourceId
{
	$pricing = Get-AzureRmSecurityPricing | Select -First 1

    $fetchedPricing = Get-AzureRmSecurityPricing -ResourceId $pricing.Id
	Validate-Pricing $fetchedPricing
}

<#
.SYNOPSIS
Set an Azure Security Center pricing setting
#>
function Set-AzureRmSecurityPricing-SubscriptionLevelResource
{
    Set-AzureRmSecurityPricing -Name "default" -PricingTier "Standard"
}

<#
.SYNOPSIS
Set an Azure Security Center pricing setting override
#>
function Set-AzureRmSecurityPricing-ResourceGroupLevelResource
{
	$rgName = Get-TestResourceGroupName

    Set-AzureRmSecurityPricing -ResourceGroupName $rgName -Name $rgName -PricingTier "Standard"
}

<#
.SYNOPSIS
Validates a list of security pricings
#>
function Validate-Pricings
{
	param($pricings)

    Assert-True { $pricings.Count -gt 0 }

	Foreach($pricing in $pricings)
	{
		Validate-Pricing $pricing
	}
}

<#
.SYNOPSIS
Validates a single pricing
#>
function Validate-Pricing
{
	param($pricing)

	Assert-NotNull $pricing
}