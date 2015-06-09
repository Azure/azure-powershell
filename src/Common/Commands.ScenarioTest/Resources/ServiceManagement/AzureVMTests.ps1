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

########################################################################### Create-AzureVM Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Create-AzureVM with valid information.
#>
function Test-GetAzureVM
{
	# Setup

	$location = Get-DefaultLocation
	$imgName = Get-DefaultImage $location


	$storageName = getAssetName
	New-AzureStorageAccount -StorageAccountName $storageName -Location $location

	Set-CurrentStorageAccountName $storageName

	$vmName = "vm1"
	$svcName = Get-CloudServiceName

	# Test
	New-AzureService -ServiceName $svcName -Location $location
	New-AzureQuickVM -Windows -ImageName $imgName -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password "p@ssw0rd"

	Get-AzureVM -ServiceName $svcName -Name $vmName


	# Cleanup
	Cleanup-CloudService $svcName
}

