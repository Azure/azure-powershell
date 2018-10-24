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
Test RegisteredServer
.DESCRIPTION
SmokeTest
#>
function Test-RegisteredServer
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
        New-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName -Location $resourceLocation -RegisteredServerName $storageSyncServiceName
        
        Write-Verbose "List RegisteredServers by ResourceGroup"
        $storageSyncServices = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List RegisteredServers by Name"
        $storageSyncService = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName -RegisteredServerName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List RegisteredServers by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating RegisteredServer Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.RegisteredServerName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing RegisteredServer: $storageSyncServiceName"
        Remove-AzureRmRegisteredServer -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
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
Test NewRegisteredServer
.DESCRIPTION
SmokeTest
#>
function Test-NewRegisteredServer
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
        New-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName -Location $resourceLocation -RegisteredServerName $storageSyncServiceName
        
        Write-Verbose "List RegisteredServers by ResourceGroup"
        $storageSyncServices = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName
        $storageSyncServices
        Write-Verbose "List RegisteredServers by Name"
        $storageSyncService = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName -RegisteredServerName $storageSyncServiceName -Verbose
        $storageSyncService
        
        Write-Verbose "List RegisteredServers by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmRegisteredServer -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }
        Write-Verbose "Validating RegisteredServer Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.RegisteredServerName
        Assert-AreEqual $resourceLocation.ToLower().Replace(" ", "") $storageSyncService.Location
        
        Write-Verbose "Removing RegisteredServer: $storageSyncServiceName"
        Remove-AzureRmRegisteredServer -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}