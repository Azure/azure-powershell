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
Test linked service CRD
#>
function Test-LinkedServiceCRD
{
	# setup
	$rgNameExisting = "dabenham-dev"
	$clusterNameExisting = "dabenhamCluster-dev"
	$workspaceNameExisting = "dabenham-eus"
	$workspaceNameExistingAnother = "dabenham-eusAlt"

	try
	{
		# cluster to be linked need to have provisioning state "Succeeded" and valid key vault properties
		
		$cluster = Get-AzOperationalInsightsCluster -ResourceGroupName $rgNameExisting -ClusterName $clusterNameExisting
		Assert-NotNull $cluster
		Assert-NotNull $cluster.Id

		$setLinkedServiceJob = Set-AzOperationalInsightsLinkedService -ResourceGroupName $rgNameExisting -WorkspaceName $workspaceNameExisting -LinkedServiceName cluster -WriteAccessResourceId $cluster.Id -AsJob
		$setLinkedServiceJob | Wait-Job
		$link = $setLinkedServiceJob | Receive-Job

		Assert-NotNull $link
		Assert-AreEqual "Succeeded" $link.ProvisioningState
		Assert-AreEqual $cluster.Id $link.WriteAccessResourceId

		$removeLinkedServiceJob = Remove-AzOperationalInsightsLinkedService -ResourceGroupName $rgNameExisting -WorkspaceName $workspaceNameExisting -LinkedServiceName cluster -AsJob
		$removeLinkedServiceJob | Wait-Job
		$removeState = $removeLinkedServiceJob | Receive-Job
		Assert-True {$removeState}
	}
	finally
	{
		
	}
}