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

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Creates a resource group to use in tests.
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = getAssetName
    $rgLocation = "West US"
    $resourceGroup = New-AzureRmResourceGroup -Name $resourceGroupName -Location $rgLocation -Force

    return $resourceGroup
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup([String]$rgname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}


