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

function Get-BandwidthScheduleName
{
	return getAssetName
}

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingBandwidthSchedule
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$bwname = Get-BandwidthScheduleName
	
	
	# Test
	Assert-ThrowsContains { Get-AzStackEdgeBandwidthSchedule -ResourceGroupName $rgname -DeviceName $dfname -Name $bwname } "not find"	
}

<#
.SYNOPSIS
Create Bandwidth schedule
#>
function Test-CreateBandwidthSchedule
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$bwname = Get-BandwidthScheduleName
	$bwRateInMbps = 65
	$bwStartTime = "11:00:00"
	$bwStopTime = "13:00:00"
	$bwDaysOfWeek = ("Sunday","Saturday")

	# Test
	try
	{
		$expected = New-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname -DaysOfWeek $bwDaysOfWeek -StartTime $bwStartTime -StopTime $bwStopTime -Bandwidth $bwRateInMbps
		Assert-AreEqual $expected.Name $bwname
	}
	finally
	{
		Remove-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname
	}  
}

<#
.SYNOPSIS
Update Bandwidth schedule
#>
function Test-UpdateBandwidthSchedule
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$bwname = Get-BandwidthScheduleName
	$bwRateInMbps = 65
	$bwStartTime = "14:00:00"
	$bwStopTime = "15:00:00"
	$bwDaysOfWeek =( "Sunday","Saturday")
	$bwNewRateInMbps = 95
	
	# Test
	try
	{
		New-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname -DaysOfWeek $bwDaysOfWeek -StartTime $bwStartTime -StopTime $bwStopTime -Bandwidth $bwRateInMbps
		$expected = Set-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname -Bandwidth $bwNewRateInMbps
		Assert-AreEqual $expected.BandwidthSchedule.RateInMbps $bwNewRateInMbps
	}
	finally
	{
		Remove-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname
	}  
}


<#
.SYNOPSIS
Unlimited Bandwidth schedule
#>
function Test-CreateUnlimitedBandwidthSchedule
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$bwname = Get-BandwidthScheduleName
	$bwStartTime = "17:00:00"
	$bwStopTime = "19:00:00"
	$bwDaysOfWeek = ("Sunday","Saturday")
	$bwUnlimitedRateInMbps = 0
	
	# Test
	try
	{
		$expected  = New-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname -DaysOfWeek $bwDaysOfWeek -StartTime $bwStartTime -StopTime $bwStopTime -UnlimitedBandwidth
		Assert-AreEqual $expected.BandwidthSchedule.RateInMbps $bwUnlimitedRateInMbps
	}
	finally
	{
		Remove-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname
	}  
}


<#
.SYNOPSIS
Test Remove BandwidthSchedule
#>
function Test-RemoveBandwidthSchedule
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$bwname = Get-BandwidthScheduleName
	$bwRateInMbps = 65
	$bwStartTime = "11:00:00"
	$bwStopTime = "13:00:00"
	$bwDaysOfWeek = ("Sunday","Saturday")

	# Test
	try
	{
		$expected = New-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname -DaysOfWeek $bwDaysOfWeek -StartTime $bwStartTime -StopTime $bwStopTime -Bandwidth $bwRateInMbps
		Assert-AreEqual $expected.Name $bwname
		Remove-AzStackEdgeBandwidthSchedule $rgname $dfname $bwname
	}
	finally
	{
		Assert-ThrowsContains { Get-AzStackEdgeBandwidthSchedule -ResourceGroupName $rgname -DeviceName $dfname -Name $bwname } "not find"	
	}  
}
