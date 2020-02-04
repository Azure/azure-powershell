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
	Create tests for Availability Group Listener
#>
function Test-CreateAvailabilityGroupListener
{
	# Setup
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"
	$loadBalancer = Get-LoadBalancerResourceId
	$subnetId = Get-SubnetId
	$probePort = Get-ProbePort
	$sqlVMIds = Get-SqlVirtualMachineId
	$name = Get-AGListenerName
	$rgName = Get-AGListenerResourceGroup
	$groupName = Get-AgListenerGroupName
	$ipAddress = Get-IpAddress
	$port = Get-DefaultPort
	$agName = Get-AgName

	try
	{
		# Create Sql VM with parameters
		$listener = New-AzAvailabilityGroupListener -AvailabilityGroupName $agName -LoadBalancerResourceId $loadBalancer -SubnetId $subnetId `
					-ProbePort $probePort -SqlVirtualMachineId $sqlVMIds -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName -IpAddress $ipAddress
		Assert-NotNull $listener
		Assert-AreEqual $listener.Name $name
		Assert-AreEqual $listener.Port $port
	}
	finally
	{
		Remove-AzAvailabilityGroupListener -ResourceGroupName $rgName -SqlVMGroupName $groupName -Name $name
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Get\list tests for Availability Group Listener
#>
function Test-GetAvailabilityGroupListener
{
	#Setup
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"
	$loadBalancer = Get-LoadBalancerResourceId
	$subnetId = Get-SubnetId
	$probePort = Get-ProbePort
	$sqlVMIds = Get-SqlVirtualMachineId
	$name = Get-AGListenerName
	$rgName = Get-AGListenerResourceGroup
	$groupName = Get-AgListenerGroupName
	$ipAddress = Get-IpAddress
	$port = Get-DefaultPort
	$agName = Get-AgName
	
	try 
	{
		$listener1 = New-AzAvailabilityGroupListener -AvailabilityGroupName $agName -LoadBalancerResourceId $loadBalancer -SubnetId $subnetId `
					-ProbePort $probePort -SqlVirtualMachineId $sqlVMIds -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName -IpAddress $ipAddress
		$listener2 = Get-AzAvailabilityGroupListener -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName
		Assert-NotNull $listener1
		Assert-NotNull $listener1
		Assert-AreEqual $listener1.Name $listener2.Name
		Assert-AreEqual $listener1.AvailabilityGroupName $listener2.AvailabilityGroupName
		Assert-AreEqual $listener1.Port $listener2.Port
		Assert-AreEqual $listener1.GroupName $listener2.GroupName
	}
	finally
	{
		Remove-AzAvailabilityGroupListener -ResourceGroupName $rgName -SqlVMGroupName $groupName -Name $name
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Update tests for Availability Group Listener
#>
function Test-UpdateAvailabilityGroupListener
{
	#Setup
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"
	$loadBalancer = Get-LoadBalancerResourceId
	$subnetId = Get-SubnetId
	$probePort = Get-ProbePort
	$sqlVMIds = Get-SqlVirtualMachineId
	$name = Get-AGListenerName
	$rgName = Get-AGListenerResourceGroup
	$groupName = Get-AgListenerGroupName
	$ipAddress = Get-IpAddress
	$port = Get-DefaultPort
	$agName = Get-AgName
	
	try 
	{
		$listener1 = New-AzAvailabilityGroupListener -AvailabilityGroupName $agName -LoadBalancerResourceId $loadBalancer -SubnetId $subnetId `
					-ProbePort $probePort -SqlVirtualMachineId $sqlVMIds -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName -IpAddress $ipAddress
		$listener1 = Get-AzAvailabilityGroupListener -ResourceId $listener1.ResourceId
		$listener2 = Update-AzAvailabilityGroupListener -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName -SqlVirtualMachineId $sqlVMIds
		Assert-NotNull $listener1
		Assert-NotNull $listener1
		Assert-AreEqual $listener1.Name $listener2.Name
		Assert-AreEqual $listener1.AvailabilityGroupName $listener2.AvailabilityGroupName
		Assert-AreEqual $listener1.Port $listener2.Port
		Assert-AreEqual $listener1.GroupName $listener2.GroupName
		Assert-AreEqual $listener1.LoadBalancerConfigurations[0].SqlVirtualMachineInstances.count $listener2.LoadBalancerConfigurations[0].SqlVirtualMachineInstances.count
	}
	finally
	{
		Remove-AzAvailabilityGroupListener -ResourceGroupName $rgName -SqlVMGroupName $groupName -Name $name
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Remove tests for Availability Group Listener
#>
function Test-RemoveAvailabilityGroupListener
{
	#Setup
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"
	$loadBalancer = Get-LoadBalancerResourceId
	$subnetId = Get-SubnetId
	$probePort = Get-ProbePort
	$sqlVMIds = Get-SqlVirtualMachineId
	$name = Get-AGListenerName
	$rgName = Get-AGListenerResourceGroup
	$groupName = Get-AgListenerGroupName
	$ipAddress = Get-IpAddress
	$port = Get-DefaultPort
	$agName = Get-AgName
	
	try 
	{
		$listener1 = New-AzAvailabilityGroupListener -AvailabilityGroupName $agName -LoadBalancerResourceId $loadBalancer -SubnetId $subnetId `
					-ProbePort $probePort -SqlVirtualMachineId $sqlVMIds -Name $name -ResourceGroupName $rgName -SqlVMGroupName $groupName -IpAddress $ipAddress
		Assert-NotNull $listener1

		$listener1 = Remove-AzAvailabilityGroupListener -ResourceGroupName $rgName -SqlVMGroupName $groupName -Name $name
		$listenerList = Get-AzAvailabilityGroupListener -ResourceGroupName $rgName -SqlVMGroupName $groupName
		Assert-False {$listener1.Name -in $listenerList.Name}
	}
	finally
	{
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}
