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
	$id = $firstSubscription.SubscriptionId
	$tenant = $firstSubscription.TenantId
	$name = $firstSubscription.SubscriptionName
	$subscription = $firstSubscription | Get-AzureRmSubscription
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.SubscriptionId
	$subscription = Get-AzureRmSubscription -SubscriptionId $id
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.SubscriptionId
	$subscription = Get-AzureRmSubscription -SubscriptionName $name -Tenant $tenant
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$subscription = Get-AzureRmSubscription -SubscriptionName $name
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$subscription = Get-AzureRmSubscription -SubscriptionName $name.ToUpper()
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$mostSubscriptions = Get-AzureRmSubscription
	Assert-True {$mostSubscriptions.Count -gt 0}
	$tenantSubscriptions = Get-AzureRmSubscription -Tenant $tenant
	Assert-True {$tenantSubscriptions.Count -gt 0}
}