# encoding: utf-8
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

########################## Site Recovery Tests #############################

##Default Value ##
$seed = "98"
function getVaultName{
    return "A2APowershellTest" + $seed;
}

function getVaultRg{
    return "A2APowershellTestRg" + $seed;
}


function getVaultRgLocation{
    return "eastus"
}

function getVaultLocation{
     return "eastus"
}

function getPrimaryLocation
{
    return "westus"
}

function getPrimaryZoneLocation
{
    return "southeastasia"
}

function getPrimaryZone
{
    return "1"
}

function getRecoveryZone
{
    return "2"
}

function getRecoveryLocation{
  return getVaultLocation
}

function getPrimaryFabric{
    return  "a2aPrimaryFabric"+$seed

}

function getRecoveryFabric{
    return  "a2aRecoveryFabric"+$seed

}

function getAzureVmName{
    return  "a2aVM"+$seed
}

function getAzureDataDiskName{
    return  "a2aDataDisk"+$seed
}

function getPrimaryPolicy{
    return "TestA2APolicy1" + $seed;
}

function getRecoveryPolicy{
    return "TestA2APolicy1" + $seed;
}

function getPrimaryContainer{
    return "A2APrimaryContainer"+ $seed;
}


function getRecoveryContainer{
    return "A2ARecoveryContainer"+ $seed;
}


function getPrimaryContainerMapping{
    return "A2APCM"+ $seed;
}

function getRecoveryPlanName{
    return "A2ARP"+ $seed;
}

function getRecoveryContainerMapping{
    return "A2ARCM"+ $seed;
}

function getPrimaryNetworkMapping{
    return "A2ANetworkMapping"+ $seed;
}

function getRecoveryNetworkMapping{
    return "A2ARecoveryNetworkMapping"+ $seed;
}

function getPrimaryNetworkId{
}

function getRecoveryNetworkName{
   return "A2ARecoveryNetwork"+ $seed;
}

function getCacheStorageAccountName{
     return "cache"+ $seed;
}

function getRecoveryCacheStorageAccountName{
     return "rlog"+ $seed;
}

function getRecoveryResourceGroupName{
       return "recRG"+ $seed;
}
function Get-RandomSuffix(
	[int] $size = 8)
{
	$variableName = "NamingSuffix"
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName))
		{
			$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
		}
		else
		{
			$suffix = @((New-Guid).Guid)

			[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $suffix
		}
	}
	else
	{
		$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
	}

	return $suffix.Substring(0, $size)
}

function createAzureVm{
    param([string]$primaryLocation)
    
        $VMLocalAdminUser = "adminUser"
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
        $VMLocalAdminSecurePassword = $Password
		$VMLocation = getPrimaryLocation
		$VMName = getAzureVmName
		$domain = "domain"+ $seed
        $password=$VMLocalAdminSecurePassword|ConvertTo-SecureString -AsPlainText -Force
        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $password);
        $vm = New-AzVM -Name $VMName -Credential $Credential -location $VMLocation -Image RHEL -DomainNameLabel $domain
		return $vm.Id
}

function createAzureVmInProximityPlacementgroup{
    param([string]$primaryLocation)
    
        $VMLocalAdminUser = "adminUser"
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
        $VMLocalAdminSecurePassword = $Password
		$VMLocation = getPrimaryLocation
		$VMName = getAzureVmName
		$domain = "domain"+ $seed
        $password=$VMLocalAdminSecurePassword|ConvertTo-SecureString -AsPlainText -Force
        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $password);
		$ppg =  New-AzProximityPlacementGroup -ResourceGroupName $vmName -Name $VMName -Location $VMLocation
        $vm = New-AzVM -Name $VMName -Credential $Credential -location $VMLocation -Image RHEL -DomainNameLabel $domain -ProximityPlacementGroupId $ppg.Id
		return $vm.Id
}

function createAzureVmInAvailabilityZone{
    param([string]$primaryLocation)
    
        $VMLocalAdminUser = "adminUser"
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
        $VMLocalAdminSecurePassword = $Password
		$VMLocation = getPrimaryZoneLocation
		$VMZone = getPrimaryZone
		$VMName = getAzureVmName
		$domain = "domain"+ $seed
        $password=$VMLocalAdminSecurePassword|ConvertTo-SecureString -AsPlainText -Force
        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $password);
        $vm = New-AzVM -Name $VMName -Credential $Credential -location $VMLocation -Image RHEL -DomainNameLabel $domain -Zone $VMZone
		return $vm.Id
}

function createRecoveryNetworkId{
    param([string] $location , [string] $resourceGroup)

	$NetworkName = getRecoveryNetworkName
	$NetworkLocation = getRecoveryLocation
	$ResourceGroupName = getRecoveryResourceGroupName
	$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
    $virtualNetwork = New-AzVirtualNetwork `
          -ResourceGroupName $ResourceGroupName `
          -Location $NetworkLocation `
          -Name $NetworkName `
          -AddressPrefix 10.0.0.0/16 -Subnet $frontendSubnet
    return $virtualNetwork.Id
}

function createRecoveryNetworkIdForZone{
    param([string] $location , [string] $resourceGroup)

	$NetworkName = getRecoveryNetworkName
	$NetworkLocation = getPrimaryZoneLocation
	$ResourceGroupName = getRecoveryResourceGroupName
	$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
    $virtualNetwork = New-AzVirtualNetwork `
          -ResourceGroupName $ResourceGroupName `
          -Location $NetworkLocation `
          -Name $NetworkName `
          -AddressPrefix 10.0.0.0/16 -Subnet $frontendSubnet
    return $virtualNetwork.Id
}

function createCacheStorageAccount{
    param([string] $location , [string] $resourceGroup)

	$StorageAccountName = getCacheStorageAccountName
	$cacheLocation = getPrimaryLocation
	$storageRes = getAzureVmName
    $storageAccount = New-AzStorageAccount `
          -ResourceGroupName $storageRes `
          -Location $cacheLocation `
          -Name $StorageAccountName `
          -Type 'Standard_LRS'
    return $storageAccount.Id
}

function createCacheStorageAccountForZone{
    param([string] $location , [string] $resourceGroup)

	$StorageAccountName = getCacheStorageAccountName
	$cacheLocation = getPrimaryZoneLocation
	$storageRes = getAzureVmName
    $storageAccount = New-AzStorageAccount `
          -ResourceGroupName $storageRes `
          -Location $cacheLocation `
          -Name $StorageAccountName `
          -Type 'Standard_LRS'
    return $storageAccount.Id
}



function createRecoveryCacheStorageAccount{
    param([string] $location , [string] $resourceGroup)

	$StorageAccountName = getRecoveryCacheStorageAccountName
	$cacheLocation = getRecoveryLocation
	$storageRes = getRecoveryResourceGroupName
    $storageAccount = New-AzStorageAccount `
          -ResourceGroupName $storageRes `
          -Location $cacheLocation `
          -Name $StorageAccountName `
          -Type 'Standard_LRS'
    return $storageAccount.Id
}

function createRecoveryResourceGroup{
    param([string] $location)

	$ResourceGroupName = getRecoveryResourceGroupName
	$ResourceLocation = getRecoveryLocation
    $ResourceGroup = New-AzResourceGroup `
          -Name $ResourceGroupName `
          -Location $ResourceLocation  -force
	[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(20 * 1000)
    $ResourceGroup = Get-AzResourceGroup `
          -Name $ResourceGroupName 
	return $ResourceGroup.ResourceId
}

##

<#
.SYNOPSIS
Wait for job completion
Usage:
    WaitForJobCompletion -JobId $Job.ID
    WaitForJobCompletion -JobId $Job.ID -NumOfSecondsToWait 10
#>
function WaitForJobCompletion
{ 
    param(
        [string] $JobId,
        [int] $JobQueryWaitTimeInSeconds = 20,
        [string] $Message = "NA",
		[bool] $IsExpectedToPass = $true
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzRecoveryServicesAsrJob -Name $JobId
            Write-Host $("Job Status:") -ForegroundColor Green
            $Job

            $isJobLeftForProcessing = ($Job.State -eq 'InProgress' -or $Job.State -eq 'NotStarted')
            
            if($isJobLeftForProcessing)
            {
                if($Message -ne "NA")
                {
                    Write-Host $Message -ForegroundColor Yellow
                }
                else
                {
                    Write-Host $($($Job.JobType) + " in Progress...") -ForegroundColor Yellow
                }
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }else
            {
			    if($IsExpectedToPass)
				{
					if( !(($job.State -eq "Succeeded") -or ($job.State -eq "CompletedWithInformation")))
					{
						throw "Job " + $JobId + "failed."
					}
				}
            }
        }While($isJobLeftForProcessing)
}

<#
.SYNOPSIS
Wait for IR job completion
Usage:
    WaitForJobCompletion -VM $VM
    WaitForJobCompletion -VM $VM -NumOfSecondsToWait 10
#>
Function WaitForIRCompletion
{ 
    param(
        [PSObject] $affectedObjectId,
        [int] $JobQueryWaitTimeInSeconds = 10
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        Write-Host $("IR in Progress...") -ForegroundColor Yellow
        do
        {
            $IRjobs = Get-AzRecoveryServicesAsrJob -TargetObjectId $affectedObjectId | Sort-Object StartTime -Descending | select -First 2 | Where-Object{$_.JobType -eq "SecondaryIrCompletion"}
            $isProcessingLeft = ($IRjobs -eq $null -or $IRjobs.Count -ne 1)

            if($isProcessingLeft)
            {
                Write-Host $("IR in Progress...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        Write-Host $("Finalize IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...")
}

<#
.SYNOPSIS
Wait for Add disks IR job completion
Usage:
    WaitForAddDisksIRCompletion -$affectedObjectId $VM
    WaitForAddDisksIRCompletion -$affectedObjectId $VM -$JobQueryWaitTimeInSeconds 10
#>
Function WaitForAddDisksIRCompletion
{ 
    param(
        [PSObject] $affectedObjectId,
        [int] $JobQueryWaitTimeInSeconds = 10,
		[bool] $IsExpectedToPass = $true
        )
        $isProcessingLeft = $true
        $IRjobs = $null

        Write-Host $("Add-Disk IR in Progress...") -ForegroundColor Yellow
        do
        {
            $IRjobs = Get-AzRecoveryServicesAsrJob -TargetObjectId $affectedObjectId | Sort-Object StartTime -Descending | select -First 2 | Where-Object{$_.JobType -eq "AddDisksIrCompletion"}
            $isProcessingLeft = ($IRjobs -eq $null -or $IRjobs.Count -ne 1)

            if($isProcessingLeft)
            {
                Write-Host $("Add disk IR in Progress...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
                [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        Write-Host $("Finalize Add disk IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...") -IsExpectedToPass $IsExpectedToPass
}
