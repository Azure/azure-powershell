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
    $locationMap = Get-AzureRmLocation| select location,displayName
    $provider = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.RecoveryServices"
    
    $resourceTypes = $provider[0].ResourceTypes | Where-Object { $_.ResourceTypeName -eq "vaults"}
    $resourceLocation = $resourceTypes.Locations[0]
    return $resourceLocation
}

function getVaultLocation{
    $locationMap = Get-AzureRmLocation| select location,displayName
    $provider = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.RecoveryServices"
    
    $resourceTypes = $provider[0].ResourceTypes | Where-Object { $_.ResourceTypeName -eq "vaults"}
    $resourceLocation = $resourceTypes.Locations[0]
    foreach($location in $locationMap){
        if($location.DisplayName -eq $resourceLocation){
            return $location.Location
        }
    }
}

function getPrimaryLocation
{
    $locationMap = Get-AzureRmLocation| select location,displayName
    $provider = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.RecoveryServices"

    $resourceTypes = $provider[0].ResourceTypes | Where-Object { $_.ResourceTypeName -eq "vaults"}
    $resourceLocation = $resourceTypes.Locations[1]
    foreach($location in $locationMap){
        if($location.DisplayName -eq $resourceLocation){
            return $location.Location
        }
    }
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

function getAzureVm{
    param([string]$primaryLocation)
    
        $VMLocalAdminUser = "adminUser"
        $VMLocalAdminSecurePassword = "password"
        $password=$VMLocalAdminSecurePassword|ConvertTo-SecureString -AsPlainText -Force
        $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $password);
        New-AzureRmVM -Name MyVm -Credential $Credential -location getPrimaryLocation
    

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
    param([string] $location , [string] $resourceGroup)

    
}

function getRecoveryNetworkId{
    param([string] $location , [string] $resourceGroup)

    $primaryNetworkName = "recoveryNetwork"+ $location + $seed;
    $virtualNetwork = New-AzureRmVirtualNetwork `
          -ResourceGroupName $resourceGroup `
          -Location $location `
          -Name $primaryNetworkName `
          -AddressPrefix 10.0.0.0/16
    $virtualNetwork.id
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
        [int] $JobQueryWaitTimeInSeconds = 60,
        [string] $Message = "NA"
        )
        $isJobLeftForProcessing = $true;
        do
        {
            $Job = Get-AzureRmRecoveryServicesAsrJob -Name $JobId
            Write-Host $("Job Status:") -ForegroundColor Green
            $Job

            if($Job.State -eq "InProgress" -or $Job.State -eq "NotStarted")
            {
                $isJobLeftForProcessing = $true
            }
            else
            {
                $isJobLeftForProcessing = $false
            }

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
                [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }else
            {
                if( !(($job.State -eq "Succeeded") -or ($job.State -eq "CompletedWithInformation")))
                {
                    throw "Job " + $JobId + "failed."
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
            $IRjobs = Get-AzureRmRecoveryServicesAsrJob -TargetObjectId $affectedObjectId | Sort-Object StartTime -Descending | select -First 2 | Where-Object{$_.JobType -eq "SecondaryIrCompletion"}
            if($IRjobs -eq $null -or $IRjobs.Count -ne 1)
            {
                $isProcessingLeft = $true
            }
            else
            {
                $isProcessingLeft = $false
            }

            if($isProcessingLeft)
            {
                Write-Host $("IR in Progress...") -ForegroundColor Yellow
                Write-Host $("Waiting for: " + $JobQueryWaitTimeInSeconds.ToString + " Seconds") -ForegroundColor Yellow
                [Microsoft.Azure.Test.TestUtilities]::Wait($JobQueryWaitTimeInSeconds * 1000)
            }
        }While($isProcessingLeft)

        Write-Host $("Finalize IR jobs:") -ForegroundColor Green
        $IRjobs
        WaitForJobCompletion -JobId $IRjobs[0].Name -JobQueryWaitTimeInSeconds $JobQueryWaitTimeInSeconds -Message $("Finalize IR in Progress...")
}
