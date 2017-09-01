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
Test New-AzureRmContainerGroup, Get-AzureRmContainerGroup, Remove-AzureRmContainerGroup
#>
function Test-AzureRmContainerGroup
{
    $resourceGroupName = Get-RandomResourceGroupName
    $containerGroupName = Get-RandomContainerGroupName
    $location = Get-ProviderLocation "Microsoft.ContainerInstance/ContainerGroups"
    $image = "nginx"
    $osType = "Linux"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -OsType $osType -IpAddressType "public" -Cpu 1 -Memory 1.5

        Assert-AreEqual $containerGroupCreated.ResourceGroupName $resourceGroupName
        Assert-AreEqual $containerGroupCreated.Name $containerGroupName
        Assert-AreEqual $containerGroupCreated.Location $location
        Assert-AreEqual $containerGroupCreated.OsType $osType
        Assert-NotNull $containerGroupCreated.IpAddress
        Assert-NotNull $containerGroupCreated.Containers
        Assert-AreEqual $containerGroupCreated.Containers[0].Image $image
        Assert-AreEqual $containerGroupCreated.Containers[0].Cpu 1
        Assert-AreEqual $containerGroupCreated.Containers[0].MemoryInGb 1.5

        $retrievedContainerGroup = Get-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName
        Assert-ContainerGroup $containerGroupCreated $retrievedContainerGroup

        $retrievedContainerGroupList = Get-AzureRmContainerGroup -ResourceGroupName $resourceGroupName
        Assert-AreEqual $retrievedContainerGroupList.Count 1
        Assert-ContainerGroup $containerGroupCreated $retrievedContainerGroupList[0]

        $retrievedContainerGroup | Remove-AzureRmContainerGroup
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test Get-AzureRmContainerGroupLogs
#>
function Test-AzureRmContainerGroupLogs
{
    $resourceGroupName = Get-RandomResourceGroupName
    $containerGroupName = Get-RandomContainerGroupName
    $location = Get-ProviderLocation "Microsoft.ContainerInstance/ContainerGroups"
    $image = "nginx"
    $osType = "Linux"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -OsType $osType -IpAddressType "public"

        Export-AzureRmContainerGroupLogs -ResourceGroupName $resourceGroupName -Name $containerGroupName -Dir "."
        $log = $containerGroupName + "_log"
        Assert-True {Test-Path $log}

        Remove-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Assert a container group object.

.PARAMETER expected
The expected container group object.

.PARAMETER actual
The actual container group object.
#>
function Assert-ContainerGroup
{
    Param
    (
        [parameter(position=0)]
        $Expected,
        [parameter(position=1)]
        $Actual
    )

    Assert-AreEqual $Actual.ResourceGroupName $Expected.ResourceGroupName
    Assert-AreEqual $Actual.Name $Expected.Name
    Assert-AreEqual $Actual.Location $Expected.Location
    Assert-AreEqual $Actual.OsType $Expected.OsType
    Assert-NotNull $Actual.IpAddress
    Assert-NotNull $Actual.Containers
    Assert-AreEqual $Actual.Containers[0].Image $Expected.Containers[0].Image
    Assert-AreEqual $Actual.Containers[0].Cpu $Expected.Containers[0].Cpu
    Assert-AreEqual $Actual.Containers[0].MemoryInGb $Expected.Containers[0].MemoryInGb
}