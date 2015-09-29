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
Tests each of the major parts of retrieving subscriptions in ARM mode
#>
function Test-GetSubscriptionsEndToEnd
{
	$allSubscriptions = Get-AzureRmSubscription -All
	$firstSubscription = $allSubscriptions[0]
	$id = $firstSubscription.Id
	$tenant = $firstSubscription.GetProperty([Microsoft.Azure.Common.Authentication.Models.AzureSubscription+Property]::Tenants)
	$subscription = Get-AzureRmSubscription -SubscriptionId $id -Tenant $tenant
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.Id
	$subscription = Get-AzureRmSubscription -SubscriptionId $id
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.Id
	$mostSubscriptions = Get-AzureRmSubscription
	Assert-True {$mostSubscriptions.Count -gt 0}
	$tenantSubscriptions = Get-AzureRmSubscription -Tenant $tenant
	Assert-True {$tenantSubscriptions.Count -gt 0}
}