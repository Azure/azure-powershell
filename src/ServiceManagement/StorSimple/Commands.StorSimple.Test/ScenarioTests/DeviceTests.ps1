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
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
}


<#
.SYNOPSIS
Tests creating new resource group and a simple resource.
#>
function Test-GetDevices
{
	# Setup
	Set-DefaultResource
	
	# Test
	$list = Get-AzureStorSimpleDevice

	# Assert
	Assert-AreNotEqual 0 @($list).Count	
}

function Test-GetDevices_ByDeviceId
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a deviceId and use it to make get device call with deviceId
	$deviceId = $deviceList[0].DeviceId
	$filteredDeviceList = Get-AzureStorSimpleDevice -DeviceId $deviceId

	Assert-AreEqual 1 @($filteredDeviceList).Count	
	Assert-AreEqual $deviceId $filteredDeviceList[0].DeviceId
}

function Test-GetDevices_ByDeviceName
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a deviceName and use it to make get device call
	$deviceName = $deviceList[0].FriendlyName
	$filteredDeviceList = Get-AzureStorSimpleDevice -DeviceName $deviceName

	Assert-AreEqual 1 @($filteredDeviceList).Count	
	Assert-AreEqual $deviceName $filteredDeviceList[0].FriendlyName
}

function Test-GetDevices_ByType
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a type and use it to make get device call
	$deviceType = $deviceList[0].Type
	$filteredDeviceList = Get-AzureStorSimpleDevice -Type $deviceType

	Assert-AreNotEqual 0 @($filteredDeviceList).Count	
}

function Test-GetDevices_ByModel
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a modelDescription
	$model = $deviceList[0].ModelDescription
	$filteredDeviceList = Get-AzureStorSimpleDevice -ModelId $model

	Assert-AreNotEqual 0 @($filteredDeviceList).Count
	Assert-AreEqual $model $filteredDeviceList[0].ModelDescription
}

function Test-GetDevices_IncorrectParameters
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice -DeviceName "someRandomName"
	
	Assert-AreEqual 0 @($deviceList).Count
}

function Test-GetDevices_DetailedResult
{
	# Selecting a resource
	Set-DefaultResource

	# Make get devices call
	$detailedList = Get-AzureStorSimpleDevice -Detailed
	
	# check for 2 sample properties in the result set
	Assert-NotNull $detailedList[0].AlertNotification "AlertNotification does not exist"
	Assert-NotNull $detailedList[0].Snapshot "SnapshotSettings does not exist"
}


<#
.SYNOPSIS
Tests creating a new network config object for Data0 interface
#>
function Test-NewNetworkConfigData0{
	$netConfig = New-AzureStorSimpleNetworkConfig -EnableCloud $true -Controller0IPv4Address 1.1.1.1 -Controller1IPv4Address 1.2.3.3
	Assert-AreEqual $netConfig.IsIscsiEnabled $null
	Assert-AreEqual $netConfig.IsCloudEnabled $true
	Assert-AreEqual $netConfig.Controller0IPv4Address.ToString() 1.1.1.1
	Assert-AreEqual $netConfig.Controller1IPv4Address.ToString() 1.2.3.3
	Assert-AreEqual $netConfig.IPv6Gateway null
    Assert-AreEqual $netConfig.IPv4Gateway $null
    Assert-AreEqual $netConfig.IPv4Address $null
    Assert-AreEqual $netConfig.IPv6Prefix $null
    Assert-AreEqual $netConfig.IPv4Netmask $null
	Assert-AreEqual $netConfig.InterfaceAlias.ToString() Data0
}

<#
.SYNOPSIS
Tests creating a new network config object for non data0 interface
#>
function Test-NewNetworkConfigOthers{
	$netConfig = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -IPv6Gateway 12c4:421e:9a8::a4:1c50 -IPv4Gateway 2.3.2.3 -IPv4Address 1.2.2.3 -IPv6Prefix 2001:db8:a::123/64 -IPv4Netmask 255.255.0.0 -InterfaceAlias Data1
	Assert-AreEqual $netConfig.IsIscsiEnabled $true
	Assert-AreEqual $netConfig.IsCloudEnabled $true
	Assert-AreEqual $netConfig.Controller0IPv4Address $null
	Assert-AreEqual $netConfig.Controller1IPv4Address $null
	Assert-AreEqual $netConfig.IPv6Gateway.ToString() 12c4:421e:9a8::a4:1c50
	Assert-AreEqual $netConfig.IPv4Gateway.ToString() 2.3.2.3
	Assert-AreEqual $netConfig.IPv4Address.ToString() 1.2.2.3
	Assert-AreEqual $netConfig.IPv6Prefix.ToString() 2001:db8:a::123/64
	Assert-AreEqual $netConfig.IPv4Netmask.ToString() 255.255.0.0
	Assert-AreEqual $netConfig.InterfaceAlias.ToString() Data1
}

<#
.SYNOPSIS
Tests creating a new network config with invalid params ( should get null)
#>
function Test-NetworkConfigInvalidParams{
	$netConfigData0 = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -Controller0IPv4Address 1.1.1.1 -Controller1IPv4Address 1.2.3.3 -IPv6Gateway 12c4:421e:9a8::a4:1c50 -IPv4Gateway 2.3.2.3 -IPv4Address 1.2.2.3 -IPv6Prefix 2001:db8:a::123/64 -IPv4Netmask 255.255.0.0 -InterfaceAlias Data0
	Assert-AreEqual $netConfigData0 $null
	$netConfigData1 = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -Controller0IPv4Address 1.1.1.1 -Controller1IPv4Address 1.2.3.3 -IPv6Gateway 12c4:421e:9a8::a4:1c50 -IPv4Gateway 2.3.2.3 -IPv4Address 1.2.2.3 -IPv6Prefix 2001:db8:a::123/64 -IPv4Netmask 255.255.0.0 -InterfaceAlias Data1
	Assert-AreEqual $netConfigData1 $null
}


<#
.SYNOPSIS
Tests setting up mandatory settings on first time device setup
#>
function Test-DeviceConfigFirstTimeSetup{
	# Selecting a resource
	Set-DefaultResource

    # Get an online device in current resource.
    $onlineDevices = @(Get-AzureStorSimpleDevice -Detailed | Where { $_.DeviceProperties.Status -eq "Online"})

    Assert-AreNotEqual $onlineDevices.Count 0 "No online devices found."

    $onlineDeviceDetails = $onlineDevices[0]
	$onlineDeviceInfo = $onlineDeviceDetails.DeviceProperties

	# The test assumes that there is a new device in the resource.
	$data0 = $onlineDeviceDetails.NetInterfaceList | where {$_.InterfaceId.ToString() -eq "Data0"}
	Assert-AreEqual $true (($data0.NicIPv4Settings.Controller0IPv4Address -eq $null) -or ($data0.NicIPv4Settings.Controller0IPv4Address -eq "")) "Need an unconfigured device (should also have been registered latest in the resource) in the resource to test first time setup"

	# Since the tests are run only on appliance vms, we can set only data0
	$netConfig0 = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -Controller0IPv4Address 10.67.64.48 -Controller1IPv4Address 10.67.64.49 -InterfaceAlias Data0
    [NetworkConfig[]] $configs = @($netConfig0)

    $pst = [System.TimeZoneInfo]::GetSystemTimeZones() | where { $_.Id -eq "Pacific Standard Time" }
	$newName = "$($onlineDeviceInfo.FriendlyName)_1"
    # Try and set the device configuration
    $updatedDetails = Set-AzureStorSimpleDevice -DeviceId $onlineDeviceInfo.DeviceId -NewName $newName -TimeZone $pst -PrimaryDnsServer 8.8.8.8 -SecondaryDnsServer 8.8.4.4 -StorSimpleNetworkConfig $configs
    
	# Get new deviceDetails again
	$newDetailsList = Get-AzureStorSimpleDevice -DeviceId $onlineDeviceInfo.DeviceId -Detailed
	$newDetails = $newDetailsList[0]

	#assert stuff on updated details.
	Assert-AreEqual $newDetails.DeviceProperties.FriendlyName $newName
	$newData0 = $newDetails.NetInterfaceList | where {$_.InterfaceId.ToString() -eq "Data0"}
	Assert-AreEqual $newData0.NicIPv4Settings.Controller0IPv4Address 10.67.64.48
	Assert-AreEqual $newData0.NicIPv4Settings.Controller1IPv4Address 10.67.64.49
}

<#
.SYNOPSIS
Tests comfiguring all allowed settings for a device.
#>
function Test-DeviceConfigFullSetup{
	# Selecting a resource
	Set-DefaultResource

    # Get an online device in current resource.
    $onlineDevices = @(Get-AzureStorSimpleDevice | Where { $_.Status -eq "Online"})

    Assert-AreNotEqual $onlineDevices.Count 0 "No online devices found"

    $onlineDevice = $onlineDevices[-1]

	# Since the tests are run only on appliance vms, we cant set multiple nics.
    $netConfig0 = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -Controller0IPv4Address 10.67.64.48 -Controller1IPv4Address 10.67.64.49 -InterfaceAlias Data0
    [NetworkConfig[]] $configs = @($netConfig0)

    $pst = [System.TimeZoneInfo]::GetSystemTimeZones() | where { $_.Id -eq "Pacific Standard Time" }
	$newName = "$($onlineDevice.FriendlyName)_1"
    # Try and set the device configuration
    $updatedDetails = Set-AzureStorSimpleDevice -DeviceId $onlineDevice.DeviceId -NewName $newName -TimeZone $pst -PrimaryDnsServer 8.8.8.8 -SecondaryDnsServer 8.8.4.4 -StorSimpleNetworkConfig $configs
    
	# Get new deviceDetails again
	$newDetailsList = Get-AzureStorSimpleDevice -DeviceId $onlineDevice.DeviceId -Detailed
	$newDetails = $newDetailsList[0]

	#assert stuff on updated details.
	Assert-AreEqual $newDetails.DeviceProperties.FriendlyName $newName
	$newData0 = $newDetails.NetInterfaceList | where {$_.InterfaceId.ToString() -eq "Data0"}
	Assert-AreEqual $newData0.NicIPv4Settings.Controller0IPv4Address 10.67.64.48
	Assert-AreEqual $newData0.NicIPv4Settings.Controller1IPv4Address 10.67.64.49
}


<#
.SYNOPSIS
Tests setting up a device for the first time with missing/invalid mandatory settings.
#>
function Test-DeviceConfigInvalidFirstTimeSetup{
	Set-DefaultResource


    #Get hold of an online device that has not been configured yet
    $onlineDevices = @(Get-AzureStorSimpleDevice -Detailed | Where { $_.DeviceProperties.Status -eq "Online"})

    Assert-AreNotEqual $onlineDevices.Count 0 "No online devices found."

    $onlineDeviceDetails = $onlineDevices[0]
	$onlineDeviceInfo = $onlineDeviceDetails.DeviceProperties

	# The test assumes that there is a new device in the resource.
	$data0 = $onlineDeviceDetails.NetInterfaceList | where {$_.InterfaceId.ToString() -eq "Data0"}
	Assert-AreEqual $true (($data0.NicIPv4Settings.Controller0IPv4Address -eq $null) -or ($data0.NicIPv4Settings.Controller0IPv4Address -eq "")) "Need an unconfigured device (should also have been registered latest in the resource) in the resource to test first time setup"

	$pst = [System.TimeZoneInfo]::GetSystemTimeZones() | where { $_.Id -eq "Pacific Standard Time" }

    # Case when Data0 details are not supplied
	$netConfig = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -IPv6Gateway 12c4:421e:9a8::a4:1c50 -IPv4Gateway 2.3.2.3 -IPv4Address 1.2.2.3 -IPv6Prefix 2001:db8:a::123/64 -IPv4Netmask 255.255.0.0 -InterfaceAlias Data1
    $updatedDetails = Set-AzureStorSimpleDevice -DeviceId $onlineDeviceInfo.DeviceId -NewName "TestNewName" -TimeZone $pst -PrimaryDnsServer 8.8.8.8 -SecondaryDnsServer 8.8.4.4 -StorSimpleNetworkConfig [NetworkConfig[]]@($netConfig)
    Assert-Null $updatedDetails "Device should not be configurable for the first time if Data0 details are not provided."
    
    # Case when Controller0IPAddress is not provided on first time setup
    $netConfig = New-AzureStorSimpleNetworkConfig -EnableIscsi $true -EnableCloud $true -Controller1IPv4Address 10.67.64.49 -InterfaceAlias Data0
    $updatedDetails = Set-AzureStorSimpleDevice -DeviceId $onlineDeviceInfo.DeviceId -NewName "TestNewName" -TimeZone $pst -PrimaryDnsServer 8.8.8.8 -SecondaryDnsServer 8.8.4.4 -StorSimpleNetworkConfig [NetworkConfig[]]@($netConfig)
    Assert-Null $updatedDetails "Device should not be configurable for the first time if Data0 details are not provided."    
}

<#
.SYNOPSIS
Tests configuring a Virtual Appliance
#>
function Test-VirtualDeviceConfig{
	Set-DefaultResource

	# Get hold of an online azure cis
	$onlineVirtualDevices =  @(Get-AzureStorSimpleDevice -Detailed | Where { $_.DeviceProperties.Status -eq "Online" -and $_.Type.ToString() -eq "VirtualAppliance"})
	Assert-AreNotEqual $onlineVirtualDevices.Count 0 "No online virtual devices found"
	$onlineVd = $onlineVirtualDevices[-1]

    $pst = [System.TimeZoneInfo]::GetSystemTimeZones() | where { $_.Id -eq "Pacific Standard Time" }

	$newName = "testNewName"

	$updatedDetails = Set-AzureStorSimpleVirtualDevice -DeviceName $onlineVd.DeviceProperties.FriendlyName -NewName $newName -TimeZone $pst -SecretKey "IsZHy9F2vQ2iD27JhE6vdg=="

	$newSek = $updatedDetails.VirtualApplianceProperties.EncodedServiceEncryptionKey

	Assert-AreEqual $updatedDetails.DeviceProperties.FriendlyName $newName
	Assert-AreEqual $updatedDetails.DeviceProperties.DeviceId $onlineVd.DeviceProperties.DeviceId
	Assert-AreEqual $false (($newSek -eq $null) -or ($newSek -eq ""))
}
