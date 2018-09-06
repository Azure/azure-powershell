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
    $restartPolicy = "Never"
    $port1 = 8000
    $port2 = 8001

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -OsType $osType -RestartPolicy $restartPolicy -IpAddressType "public" -Port @($port1, $port2) -Cpu 1 -Memory 1.5

        Assert-AreEqual $containerGroupCreated.ResourceGroupName $resourceGroupName
        Assert-AreEqual $containerGroupCreated.Name $containerGroupName
        Assert-AreEqual $containerGroupCreated.Location $location
        Assert-AreEqual $containerGroupCreated.OsType $osType
        Assert-AreEqual $containerGroupCreated.RestartPolicy $restartPolicy
        Assert-NotNull $containerGroupCreated.IpAddress
        Assert-AreEqual $containerGroupCreated.Ports.Count 2
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
Test Get-AzureRmContainerInstanceLog
#>
function Test-AzureRmContainerInstanceLog
{
    $resourceGroupName = Get-RandomResourceGroupName
    $containerGroupName = Get-RandomContainerGroupName
    $location = Get-ProviderLocation "Microsoft.ContainerInstance/ContainerGroups"
    $image = "alpine"
    $osType = "Linux"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -OsType $osType -IpAddressType "Public" -RestartPolicy "Never" -Command "echo hello"
        $containerInstanceName = $containerGroupName

        $log = $containerGroupCreated | Get-AzureRmContainerInstanceLog -Name $containerInstanceName
        Assert-NotNull $log

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
Test New-AzureRmContainerGroup with Azure File volume mount.
#>
function Test-AzureRmContainerGroupWithVolumeMount
{
    $resourceGroupName = Get-RandomResourceGroupName
    $containerGroupName = Get-RandomContainerGroupName
    $location = Get-ProviderLocation "Microsoft.ContainerInstance/ContainerGroups"
    $image = "acc.azurecr.io/alpine"
    $shareName = "acipstestshare"
    $accountName = "acipstest"
    $accountKey = "password"
    $secureAccountKey = ConvertTo-SecureString $accountKey -AsPlainText -Force
    $accountCredential = New-Object System.Management.Automation.PSCredential ($accountName, $secureAccountKey)
    $registryUsername = "acc"
    $registryPassword = "password"
    $secureRegistryPassword = ConvertTo-SecureString $registryPassword -AsPlainText -Force
    $registryCredential = New-Object System.Management.Automation.PSCredential ($registryUsername, $secureRegistryPassword)
    $mountPath = "/mnt/azfile"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -RegistryCredential $registryCredential -RestartPolicy "Never" -Command "ls $mountPath" -AzureFileVolumeShareName $shareName -AzureFileVolumeAccountCredential $accountCredential -AzureFileVolumeMountPath $mountPath

        Assert-NotNull $containerGroupCreated.Volumes
        Assert-NotNull $containerGroupCreated.Volumes[0].AzureFile
        Assert-AreEqual $containerGroupCreated.Volumes[0].AzureFile.ShareName $shareName
        Assert-AreEqual $containerGroupCreated.Volumes[0].AzureFile.StorageAccountName $accountName
        Assert-NotNull $containerGroupCreated.Containers[0].VolumeMounts
        Assert-AreEqual $containerGroupCreated.Containers[0].VolumeMounts[0].MountPath $mountPath

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
Test New-AzureRmContainerGroup with DNS name label.
#>
function Test-AzureRmContainerGroupWithDnsNameLabel
{
    $resourceGroupName = Get-RandomResourceGroupName
    $containerGroupName = Get-RandomContainerGroupName
	$fqdn = $containerGroupName + ".westus.azurecontainer.io"
    $location = Get-ProviderLocation "Microsoft.ContainerInstance/ContainerGroups"
    $image = "nginx"
    $osType = "Linux"
    $restartPolicy = "Never"
    $port1 = 8000
    $port2 = 8001

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        $containerGroupCreated = New-AzureRmContainerGroup -ResourceGroupName $resourceGroupName -Name $containerGroupName -Image $image -OsType $osType -RestartPolicy $restartPolicy -DnsNameLabel $containerGroupName -Port @($port1, $port2) -Cpu 1 -Memory 1.5

        Assert-AreEqual $containerGroupCreated.ResourceGroupName $resourceGroupName
        Assert-AreEqual $containerGroupCreated.Name $containerGroupName
        Assert-AreEqual $containerGroupCreated.Location $location
        Assert-AreEqual $containerGroupCreated.OsType $osType
        Assert-AreEqual $containerGroupCreated.RestartPolicy $restartPolicy
        Assert-NotNull $containerGroupCreated.IpAddress
        Assert-AreEqual $containerGroupCreated.DnsNameLabel $containerGroupName
        Assert-AreEqual $containerGroupCreated.Fqdn $fqdn
        Assert-AreEqual $containerGroupCreated.Ports.Count 2
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
    Assert-AreEqual $Actual.RestartPolicy $Expected.RestartPolicy
    Assert-NotNull $Actual.IpAddress
    Assert-AreEqual $Actual.Ports.Count $Expected.Ports.Count
	Assert-AreEqual $Actual.DnsNameLabel $Expected.DnsNameLabel
    Assert-NotNull $Actual.Containers
    Assert-AreEqual $Actual.Containers[0].Image $Expected.Containers[0].Image
    Assert-AreEqual $Actual.Containers[0].Cpu $Expected.Containers[0].Cpu
    Assert-AreEqual $Actual.Containers[0].MemoryInGb $Expected.Containers[0].MemoryInGb
}