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
	Assert-AreEqual $name $subscription.SubscriptionName
	$subscription = Get-AzureRmSubscription -SubscriptionName $name
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.SubscriptionName
	$subscription = Get-AzureRmSubscription -SubscriptionName $name.ToUpper()
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.SubscriptionName
	$mostSubscriptions = Get-AzureRmSubscription
	Assert-True {$mostSubscriptions.Count -gt 0}
	$tenantSubscriptions = Get-AzureRmSubscription -Tenant $tenant
	Assert-True {$tenantSubscriptions.Count -gt 0}
}

function Test-PipingWithContext
{
    $allSubscriptions = Get-AzureRmSubscription
	$firstSubscription = $allSubscriptions[0]
	$id = $firstSubscription.SubscriptionId
	$name = $firstSubscription.SubscriptionName
	$nameContext = Get-AzureRmSubscription -SubscriptionName $name | Set-AzureRmContext
	$idContext = Get-AzureRmSubscription -SubscriptionId $id | Set-AzureRmContext
	Assert-True { $nameContext -ne $null }
	Assert-True { $nameContext.Subscription -ne $null }
	Assert-True { $nameContext.Subscription.SubscriptionId -ne $null }
	Assert-True { $nameContext.Subscription.SubscriptionName -ne $null }
	Assert-True { $idContext -ne $null }
	Assert-True { $idContext.Subscription -ne $null }
	Assert-True { $idContext.Subscription.SubscriptionId -ne $null }
	Assert-True { $idContext.Subscription.SubscriptionName -ne $null }
	Assert-AreEqual $idContext.Subscription.SubscriptionId  $nameContext.Subscription.SubscriptionId
	Assert-AreEqual $idContext.Subscription.SubscriptionName  $nameContext.Subscription.SubscriptionName
}

function Test-SetAzureRmContextEndToEnd
{
    # This test requires that the tenant contains atleast two subscriptions
	$allSubscriptions = Get-AzureRmSubscription
    $secondSubscription = $allSubscriptions[1]
    Assert-True { $allSubscriptions[0] -ne $null }
	Assert-True { $secondSubscription -ne $null }
    Set-AzureRmContext -SubscriptionId $secondSubscription.SubscriptionId
    $context = Get-AzureRmContext
    Assert-AreEqual $context.Subscription.SubscriptionId $secondSubscription.SubscriptionId
    Assert-ThrowsContains {Set-AzureRmContext -SubscriptionId 'junk-subscription-id'} "does not exist under current tenant"
}