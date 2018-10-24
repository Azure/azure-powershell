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
Test ServerEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-ServerEndpoint
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
        New-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName -Location $resourceLocation -ServerEndpointName $storageSyncServiceName
        
        Write-Verbose "List ServerEndpoints by ResourceGroup"
        $storageSyncServices = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List ServerEndpoints by Name"
        $storageSyncService = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName -ServerEndpointName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List ServerEndpoints by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating ServerEndpoint Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.ServerEndpointName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing ServerEndpoint: $storageSyncServiceName"
        Remove-AzureRmServerEndpoint -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
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
Test NewServerEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-NewServerEndpoint
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
        New-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName -Location $resourceLocation -ServerEndpointName $storageSyncServiceName
        
        Write-Verbose "List ServerEndpoints by ResourceGroup"
        $storageSyncServices = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List ServerEndpoints by Name"
        $storageSyncService = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName -ServerEndpointName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List ServerEndpoints by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmServerEndpoint -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating ServerEndpoint Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.ServerEndpointName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing ServerEndpoint: $storageSyncServiceName"
        Remove-AzureRmServerEndpoint -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}