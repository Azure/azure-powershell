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
.DESCRIPTION
SmokeTest
#>
function Test-GetSubscriptionsEndToEnd
{
	$allSubscriptions = Get-AzSubscription
	$firstSubscription = $allSubscriptions[0]
	$id = $firstSubscription.Id
	$tenant = $firstSubscription.HomeTenantId
	Assert-NotNull $tenant
	$name = $firstSubscription.Name
	$subscription = $firstSubscription | Get-AzSubscription
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.Id
	$subscription = Get-AzSubscription -SubscriptionId $id
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $id $subscription.Id
	$subscription = Get-AzSubscription -SubscriptionName $name -Tenant $tenant
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$subscription = Get-AzSubscription -SubscriptionName $name
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$subscription = Get-AzSubscription -SubscriptionName $name.ToUpper()
	Assert-True { $subscription -ne $null }
	Assert-AreEqual $name $subscription.Name
	$mostSubscriptions = Get-AzSubscription
	Assert-True {$mostSubscriptions.Count -gt 0}
	$tenantSubscriptions = Get-AzSubscription -Tenant $tenant
	Assert-True {$tenantSubscriptions.Count -gt 0}
	Assert-NotNull $subscription.SubscriptionPolicies
}

<#
.SYNOPSIS
Tests each of the major parts of retrieving subscriptions in ARM mode
.DESCRIPTION
SmokeTest
#>
function Test-PipingWithContext
{
    $allSubscriptions = Get-AzSubscription
	$firstSubscription = $allSubscriptions[0]
	$id = $firstSubscription.Id
	$name = $firstSubscription.Name
	$nameContext = Get-AzSubscription -SubscriptionName $name | Set-AzContext
	$idContext = Get-AzSubscription -SubscriptionId $id | Set-AzContext
	$contextByName = Set-AzContext -SubscriptionName $name
	Assert-True { $nameContext -ne $null }
	Assert-True { $nameContext.Subscription -ne $null }
	Assert-True { $nameContext.Subscription.Id -ne $null }
	Assert-True { $nameContext.Subscription.Name -ne $null }
	Assert-True { $idContext -ne $null }
	Assert-True { $idContext.Subscription -ne $null }
	Assert-True { $idContext.Subscription.Id -ne $null }
	Assert-True { $idContext.Subscription.Name -ne $null }
	Assert-AreEqual $idContext.Subscription.Id  $nameContext.Subscription.Id
	Assert-AreEqual $idContext.Subscription.Name  $nameContext.Subscription.Name
	Assert-True { $contextByName -ne $null }
	Assert-True { $contextByName.Subscription -ne $null }
	Assert-True { $contextByName.Subscription.Id -ne $null }
	Assert-True { $contextByName.Subscription.Name -ne $null }
	Assert-AreEqual $contextByName.Subscription.Name  $nameContext.Subscription.Name
}

<#
.SYNOPSIS
Tests each of the major parts of retrieving subscriptions in ARM mode
#>
function Test-SetAzureRmContextEndToEnd
{
    # This test requires that the tenant contains atleast two subscriptions
	$allSubscriptions = Get-AzSubscription
    $secondSubscription = $allSubscriptions[1]
    Assert-True { $allSubscriptions[0] -ne $null }
	Assert-True { $secondSubscription -ne $null }
    Set-AzContext -SubscriptionId $secondSubscription.Id
    $context = Get-AzContext
    Assert-AreEqual $context.Subscription.Id $secondSubscription.Id
    $junkSubscriptionId = "49BC3D95-9A30-40F8-81E0-3CDEF0C3F8A5"
    Assert-ThrowsContains {Set-AzContext -SubscriptionId $junkSubscriptionId} "provide a valid"
}

<#
.SYNOPSIS
Tests each of the major parts of retrieving subscriptions in ARM mode
.DESCRIPTION
SmokeTest
#>
function Test-SetAzureRmContextWithoutSubscription
{
    $allSubscriptions = Get-AzSubscription
    $firstSubscription = $allSubscriptions[0]
    $id = $firstSubscription.Id
    $tenantId = $firstSubscription.HomeTenantId

    Assert-True { $tenantId -ne $null }

    Set-AzContext -TenantId $tenantId
    $context = Get-AzContext

    Assert-True { $context.Subscription -ne $null }
    Assert-True { $context.Tenant -ne $null }
    Assert-AreEqual $context.Tenant.Id $firstSubscription.HomeTenantId
    Assert-AreEqual $context.Subscription.Id $firstSubscription.Id
}