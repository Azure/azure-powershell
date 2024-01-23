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
	Tests refresh external governance status
#>

function Test-RefreshSqlInstanceExternalGovernanceCmdlet ($location = "eastus2euap")
{
	#Test scenario
	try
	{
		# ------------------------------ Setup
		Write-Debug "Creating test MI"
		$rg = Create-ResourceGroupForTest
		$rgName = $rg.ResourceGroupName
		$managedInstance = Create-ManagedInstanceForTest $rg
		$managedInstanceName = $managedInstance.ManagedInstanceName
		
		# ------------------------------ Get the MI

		Write-Debug "Getting the created MI $managedInstanceName"
		$instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $managedInstanceName
		$instanceId = $instance.Id
		$instanceName = $instance.ManagedInstanceName
		
		Assert-AreEqual $instance.ExternalGovernanceStatus "Disabled"

		# ------------------------------ Test by passing in the instance object

		Write-Debug "Test by passing in the instance object"
		$result = Get-AzSqlInstance -ResourceGroupName $rgName -Name $managedInstanceName | Invoke-AzSqlInstanceExternalGovernanceStatusRefresh

		Write-Debug ('$result is ' + (ConvertTo-Json $result))
		Assert-NotNull $result
		
		Assert-AreEqual $result.Status "Succeeded"
		Assert-AreEqual $result.InstanceName $instanceName

		# ------------------------------ Test by passing in the resource id
		Write-Debug "Test by passing in the resource id"
		$result = Invoke-AzSqlInstanceExternalGovernanceStatusRefresh -ResourceId $instanceId
		
		Write-Debug ('$result is ' + (ConvertTo-Json $result))
		Assert-NotNull $result

		Assert-AreEqual $result.Status "Succeeded"
		Assert-AreEqual $result.InstanceName $instanceName

		# ------------------------------ Test by passing in the resource group name and instance name
		Write-Debug "Test by passing in the name and resource group"
		$result = Invoke-AzSqlInstanceExternalGovernanceStatusRefresh -ResourceGroupName $rgName -InstanceName $instanceName
		Write-Debug ('$result is ' + (ConvertTo-Json $result))
		Assert-NotNull $result

		Assert-AreEqual $result.Status "Succeeded"
		Assert-AreEqual $result.InstanceName $instanceName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
