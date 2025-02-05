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
    # Resource details
    $rgname = Get-ResourceGroupName
    $location = "australiaeast"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    # NVA sku details
    $vendor = "checkpoint"
    $scaleunit = 2
    $version = 'latest'
    $asn = 64512
    $prefix = "10.1.0.0/16"
    # Storage account details where logs will be copied
    $storetype = 'Standard_GRS'
    $containerName = "testcontainer"
    $serialConsoleLogsblobName = "example.txt"
    $consoleScreenshotblobName = "screenshot.png"
    $storeName = "nvabootdiagstorage";
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

        # Wait for Virtual Hub Routing State to become Provisioned or Failed
        while ($hub.RoutingState -eq "Provisioning")
        {
            Start-TestSleep -Seconds 30
            $hub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $hubname
        }
        Assert-AreEqual $hub.RoutingState "Provisioned"

        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" 
        Assert-NotNull $nva

        # Create a new storage account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $location -Type $storetype
        $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
        $context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
        # Create container within the storage
        New-AzStorageContainer -Name $containerName -Context $context
        $container = Get-AzStorageContainer -Name $containerName -Context $context
        # Upload an empty blob for storing serial console logs 
        $serialLogsBlob = Set-AzStorageBlobContent -Container $containerName -Blob $serialConsoleLogsblobName -Context $context
        # Upload an empty blob for storing console screen shot 
        $consoleScreenshotblob = Set-AzStorageBlobContent -Container $containerName -Blob $consoleScreenshotblobName -Context $context

        #Generate a sas url for both the blobs created above
        $serialConsoleLogsSasUrl = New-AzStorageBlobSASToken -Container $containerName -Blob $serialConsoleLogsblobName -Context $context -Permission "rw" -ExpiryTime ([System.DateTime]::UtcNow).AddDays(1) -StartTime ([System.DateTime]::UtcNow).AddHours(-1) -FullUri
        Assert-NotNull $serialConsoleLogsSasUrl
        $consoleScreenshotSasUrl = New-AzStorageBlobSASToken -Container $containerName -Blob $consoleScreenshotblobName -Context $context -Permission "rw" -ExpiryTime ([System.DateTime]::UtcNow).AddDays(1) -StartTime ([System.DateTime]::UtcNow).AddHours(-1) -FullUri
        Assert-NotNull $consoleScreenshotSasUrl

        # Call PS cmdlet to retrieve boot diagnostic logs for this NVA for VM instance 0
        $nvabootdiagnostics = Get-AzNetworkVirtualApplianceBootDiagnostics -ResourceGroupName $rgname -Name $nvaname -InstanceId 0 -SerialConsoleStorageSasUrl $serialConsoleLogsSasUrl -ConsoleScreenshotStorageSasUrl $consoleScreenshotSasUrl
        Assert-AreEqual $nvabootdiagnostics.Status "Succeeded"
   	} 
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	} 

}