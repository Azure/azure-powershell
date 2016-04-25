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
Sleeps but only during recording.
#>
function Start-TestSleep($milliseconds)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        Start-Sleep -Milliseconds $milliseconds
    }
}

<#
.SYNOPSIS
Gets a Batch account name for testing.
#>
function Get-BatchAccountName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a resource group name for testing.
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the location for the Batch account provider. Default to West US if none found.
#>
function Get-BatchAccountProviderLocation($index)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = "Microsoft.Batch"
        $type = "batchAccounts"
        $r = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}  
        $location = $r.Locations
  
        if ($location -eq $null) 
        {  
            return "West US"  
        } 
        else 
        {  
            if ($index -eq $null)
            {
                return "West US"
            }
            else
            {
                return $location[$index]  
            }
        }  
    }

    return "West US"
}

<#
.SYNOPSIS
Cleans the created Batch account and resource group
#>
function Clean-BatchAccountAndResourceGroup($accountName,$resourceGroup)
{
    Clean-BatchAccount $accountName $resourceGroup
    Clean-ResourceGroup $resourceGroup
}

<#
.SYNOPSIS
Cleans the created Batch account
#>
function Clean-BatchAccount($accountName,$resourceGroup)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) 
    {
        Remove-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Force
    }
}

<#
.SYNOPSIS
Cleans the created resource group
#>
function Clean-ResourceGroup($resourceGroup)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) 
    {
        Remove-AzureRmResourceGroup -Name $resourceGroup -Force
    }
}