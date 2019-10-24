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
Set HDInsight Cluster GatewayCredential
#>
function Test-SetGatewayCredential{

	# Create some resources that will be used throughout test 
	try
	{
		# create cluster that will be used throughout test
		$cluster= Create-Cluster

		$username = "admin"
		$textPassword= "YourPw!00953"
		$password = ConvertTo-SecureString $textPassword -AsPlainText -Force
		$credential = New-Object System.Management.Automation.PSCredential($username, $password)

		$gatewaySettings = Set-AzHDInsightGatewayCredential -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup -HttpCredential $credential

		Assert-True {$gatewaySettings.Password -eq $textPassword }
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
