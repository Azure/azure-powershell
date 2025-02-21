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
Test getting the boot diagnostic logs for an existing NetworkVirtualAppliance VM instance
#>
function Test-NetworkVirtualApplianceBootDiagnostics
{
    $rgname = "nashoktest"
    $location = "australiaeast"
    $nvaname = "chkptbd1031"
    $wanname = "sctestvwan"
    $hubname = "sctesthub"
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "checkpoint"
    $scaleunit = 2
    $version = 'latest'
    $asn = 64512
    $prefix = "10.1.0.0/16"
    $storetype = 'Standard_GRS'
    $containerName = "testcontainer"
    $blobName = "example.txt"
    $storeName = "stonashoktest";
    try{
        # Retrieve the Resource Group
        $resourceGroup = Get-AzResourceGroup -Name $rgname
        Assert-NotNull $resourceGroup

        # Retrieve the Virtual WAN
        $virtualWan = Get-AzVirtualWan -ResourceGroupName $rgname -Name $wanname
        Assert-NotNull $virtualWan

        # Retrieve the Virtual Hub within the Virtual WAN
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $hubname
        Assert-NotNull $virtualHub

        # Retrieve the Network Virtual Appliance (NVA) within the Virtual WAN
        $nva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $nva

        # Retrieve the Storage Account
        $storageAccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $storeName
        Assert-NotNull $storageAccount

        # Get the storage account context
        $storageAccountContext = $storageAccount.Context
        Assert-NotNull $storageAccountContext

        # Generate SAS token for the existing Blob
        #$sasToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Context $storageAccountContext -Permission "rw" -ExpiryTime ([System.DateTime]::UtcNow).AddDays(1) -StartTime ([System.DateTime]::UtcNow).AddHours(-1) -FullUri
        $sasToken = "******"
        Assert-NotNull $sasToken
        Write-Host "SAS uri for the blob '$blobName' is: $sasToken"
        $sasTokenEncrypt = ConvertTo-SecureString -String $sasToken -AsPlainText -Force

        $sasUrlScreenShot = "******"
        $sasUrlScreenShotEncrypt = ConvertTo-SecureString -String $sasUrlScreenShot -AsPlainText -Force

        $nvabootdiagnostics = Get-AzNetworkVirtualApplianceBootDiagnostics -ResourceGroupName $rgname -Name $nvaname -InstanceId 0 -SerialConsoleStorageSasUrl $sasTokenEncrypt -ConsoleScreenshotStorageSasUrl $sasUrlScreenShotEncrypt
        Assert-AreEqual $nvabootdiagnostics.Status "Succeeded"
   	} 
    finally{
        # Clean up.
	} 

}