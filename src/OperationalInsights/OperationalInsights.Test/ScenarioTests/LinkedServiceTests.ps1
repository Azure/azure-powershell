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
	$rgNameExisting = "azps-test-group"
	$clusterNameExisting = "yabocluster7"
	$workspaceNameExisting = "yabo-test-la4"


	try
	{
		# cluster to be linked need to have provisioning state "Succeeded" and valid key vault properties
		
		$cluster = Get-AzOperationalInsightsCluster -ResourceGroupName $rgNameExisting -ClusterName $clusterNameExisting
		$id = $cluster.Id

		$job = Set-AzOperationalInsightsLinkedService -ResourceGroupName $rgNameExisting -WorkspaceName $workspaceNameExisting -LinkedServiceName cluster -WriteAccessResourceId $id -AsJob
		$job | Wait-Job
		$link = $job | Receive-Job

		Assert-NotNull $link
		Assert-AreEqual "Succeeded" $link.ProvisioningState
		Assert-AreEqual $id $link.WriteAccessResourceId
	}
	finally
	{
		
	}
}