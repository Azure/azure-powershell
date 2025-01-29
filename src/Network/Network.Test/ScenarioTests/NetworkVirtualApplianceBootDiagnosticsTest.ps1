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
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "ciscosdwan"
    $scaleunit = 20
    $version = 'latest'
    $asn = 65222
    $prefix = "10.0.0.0/16"
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

        #create SAS URL
	    $storetype = 'Standard_GRS'
        $containerName = "testcontainer"
        $blobName = "example"
        $storeName = 'sto' + $rgname;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $location -Type $storetype
        $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
        $context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
        New-AzStorageContainer -Name $containerName -Context $context
        $container = Get-AzStorageContainer -Name $containerName -Context $context
        # Upload an empty blob to the container
        $blob = Set-AzStorageBlobContent -Container $containerName -Blob $blobName -Context $context
        $now=get-date
        # Generate SAS token with read and write permissions for the blob
        $sasToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Context $context -Permission "rw" -ExpiryTime $now.AddDays(1) -StartTime $now.AddHours(-1) -FullUri

        $nvabootdiagnostics = Get-AzNetworkVirtualApplianceBootDiagnostics -ResourceGroupName $rgname -Name $nvaname -InstanceId 0 -SerialConsoleStorageSasUrl $sasToken
        Assert-AreEqual $nvabootdiagnostics.Status "Succeeded"
   	}   
    finally{
        # Clean up.
	}
}