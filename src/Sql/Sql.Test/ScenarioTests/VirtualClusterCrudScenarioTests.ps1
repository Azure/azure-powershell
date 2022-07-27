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
	Tests Getting a VirtualCluster
	.DESCRIPTION
	SmokeTest
#>
function Test-GetVirtualCluster
{
	# Setup
	$params = Get-DefaultManagedInstanceParameters

	Write-Debug $params.rg

	# Test using all parameters
	$virtualClusterList = Get-AzSqlVirtualCluster
	$virtualCluster = $virtualClusterList.where({$_.SubnetId -eq $params.subnet})[0]
	Assert-AreEqual $params.rg $virtualCluster.ResourceGroupName
	$virtualClusterName = $virtualCluster.VirtualClusterName

	$virtualClusterList = Get-AzSqlVirtualCluster -ResourceGroupName $params.rg
	$virtualCluster = $virtualClusterList.where({$_.SubnetId -eq $params.subnet})[0]
	Assert-AreEqual $params.rg $virtualCluster.ResourceGroupName
	Assert-AreEqual $virtualClusterName $virtualCluster.VirtualClusterName

	$virtualCluster = Get-AzSqlVirtualCluster -ResourceGroupName $params.rg -Name $virtualClusterName
	Assert-AreEqual $params.rg $virtualCluster.ResourceGroupName
	Assert-AreEqual $virtualClusterName $virtualCluster.VirtualClusterName
	Assert-AreEqual $params.subnet $virtualCluster.SubnetId
}
