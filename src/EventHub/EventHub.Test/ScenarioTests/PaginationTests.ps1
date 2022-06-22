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
Tests pagination of various resources
#>

function ApplicationGroupPagination{
	# Max allowed application groups in a namespace is 100
	# Pagination does not really come into picture
	# But for any list call that gives a ListNext function we have to take pagination into account in the code
	# This is because if tommorrow, the server allows more than 100 app groups
	# We do not need any effort here to keep the code updated

	$resourceGroupName = "ps-testing"
	$namespaceName = "ps-pagination-testing"

	$listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
	Assert-AreEqual 100 $listOfAppGroups.Count

	$namespaceId = Get-AzEventHubNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
	
	$listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceId $namespaceId.Id
	Assert-AreEqual 100 $listOfAppGroups.Count

	$t1 = New-AzEventHubThrottlingPolicyConfig -Name t1 -MetricId IncomingMessages -RateLimitThreshold 10000

	Assert-ThrowsContains { New-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name test -ClientAppGroupIdentifier SASKeyName=test -ThrottlingPolicyConfig $t1 }  "Operation returned an invalid status code 'BadRequest'"
}
