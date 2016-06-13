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

########################################################################### Remove-AzureSubscription Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Remove-AzureSubscription with valid subscription
#>
function Test-RemoveAzureSubscriptionWithDefaultSubscription
{
	# Setup
	$name = (Get-AzureSubscription -Default).SubscriptionName
	$expectedDefaultWarning = "The default subscription is being removed. Use Select-Subscription <subscriptionName> to select a new default subscription."
	$expectedCurrentWarning = "The current subscription is being removed. Use Select-Subscription <subscriptionName> to select a new current subscription."

	# Test
	Remove-AzureSubscription $name -Force -WarningVariable warning

	# Assert
	Assert-AreEqual $expectedDefaultWarning $warning[0]
	Assert-AreEqual $expectedCurrentWarning $warning[1]
	# Assert-Null $(Get-AzureSubscription $name)
}

<#
.SYNOPSIS
Tests Remove-AzureSubscription with non existing subscription
#>
function Test-RemoveAzureSubscriptionWithNonExistingSubscription
{
	# Setup
	$errorMessage = "The subscription named 'NotExisting' cannot be found. Use Set-AzureSubscription to initialize the subscription data."

	# Test
	Assert-Throws { Remove-AzureSubscription "NotExisting" -Force } $errorMessage
}

<#
.SYNOPSIS
Tests Remove-AzureSubscription with empty subscription
#>
function Test-RemoveAzureSubscriptionWithEmptySubscription
{
	# Setup
	$errorMessage = "Cannot validate argument on parameter 'SubscriptionName'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."

	# Test
	Assert-Throws { Remove-AzureSubscription "" } $errorMessage
}

<#
.SYNOPSIS
Tests Remove-AzureSubscription with WhatIf
#>
function Test-RemoveAzureSubscriptionWithWhatIf
{
	# Setup
	$name = (Get-AzureSubscription -Default).SubscriptionName

	# Test
	Remove-AzureSubscription $name -Force -WhatIf
	Remove-AzureSubscription $name -Force

	# Assert
	Assert-True { $true }
}