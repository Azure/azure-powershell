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

function Get-Trigger
{
	return getAssetName
}

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingTrigger
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-Trigger
	
	# Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeTrigger -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"	
}


<#
.SYNOPSIS
Tests Create New User
#>
function Test-CreateNewTrigger
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-Trigger
	$schedule = "1.00:00"
	$startTime = "2022-10-28 12:00:00"
	$topic = "topic"

	
	$iotRole = Get-AzDataBoxEdgeRole -ResourceGroupName $rgname -DeviceName $dfname

	
	# Test
	try
	{
		$expected =  New-AzDataBoxEdgeTrigger -ResourceGroupName $rgname -DeviceName $dfname -Name $name -PeriodicTimerEvent -RoleName $iotRole.Name -Schedule $schedule -StartTime $startTime -Topic $topic
		Assert-AreEqual $expected.Name $name
	}
	finally
	{
		Remove-AzDataBoxEdgeTrigger $rgname $dfname $name
	}  
}


<#
.SYNOPSIS
Test remove User. Creates new user then removes user and try to get the user
#>
function Test-RemoveTrigger
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-Trigger
	$schedule = "1.00:00"
	$startTime = "2022-10-28 12:00:00"
	$topic = "topic"

	
	$iotRole = Get-AzDataBoxEdgeRole -ResourceGroupName $rgname -DeviceName $dfname

	
	# Test
	try
	{
		$expected =  New-AzDataBoxEdgeTrigger -ResourceGroupName $rgname -DeviceName $dfname -Name $name -PeriodicTimerEvent -RoleName $iotRole.Name -Schedule $schedule -StartTime $startTime -Topic $topic
		Assert-AreEqual $expected.Name $name
		Remove-AzDataBoxEdgeTrigger $rgname $dfname $name
	}
	finally
	{
		Assert-ThrowsContains { Get-AzDataBoxEdgeTrigger -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"	
	}  
}