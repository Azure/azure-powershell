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
Test CloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-CloudEndpoint
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName -Location $resourceLocation -CloudEndpointName $storageSyncServiceName
        
        Write-Verbose "List CloudEndpoints by ResourceGroup"
        $storageSyncServices = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List CloudEndpoints by Name"
        $storageSyncService = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName -CloudEndpointName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List CloudEndpoints by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.CloudEndpointName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing CloudEndpoint: $storageSyncServiceName"
        Remove-AzureRmCloudEndpoint -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test NewCloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-NewCloudEndpoint
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName -Location $resourceLocation -CloudEndpointName $storageSyncServiceName
        
        Write-Verbose "List CloudEndpoints by ResourceGroup"
        $storageSyncServices = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List CloudEndpoints by Name"
        $storageSyncService = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName -CloudEndpointName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List CloudEndpoints by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmCloudEndpoint -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.CloudEndpointName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing CloudEndpoint: $storageSyncServiceName"
        Remove-AzureRmCloudEndpoint -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}