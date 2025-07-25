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


#################################
## IotHub Device Cmdlets	   ##
#################################

<#
.SYNOPSIS
Test all iothub device cmdlets
#>
function Test-AzureRmIotHubDeviceLifecycle
{
	$Location = Get-Location "Microsoft.Devices" "IotHubs"
	$dataplaneApiVersion = '2020-03-13'
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$Sku = "S1"
	$SasTokenPrefix = 'SharedAccessSignature'
	$device1 = getAssetName
	$device2 = getAssetName
	$device3 = getAssetName
	$device4 = getAssetName
	$device5 = getAssetName
	$device6 = getAssetName
	$primaryThumbprint = '38303FC7371EC78DDE3E18D732C8414EE50969C7'
	$secondaryThumbprint = 'F54465586FBAF4AC269851424A592254C8861BE7'

	# Create Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Generate SAS token for IotHub
	$token = New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName
	Assert-StartsWith $SasTokenPrefix $token

	# Get all devices
	$devices = Get-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName
	Assert-True { $devices.Count -eq 0 }

	# Add iot device with symmetric authentication
	$newDevice1 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -AuthMethod 'shared_private_key'
	Assert-True { $newDevice1.Id -eq $device1 }
	Assert-True { $newDevice1.Authentication.Type -eq 'Sas' }
	Assert-False { $newDevice1.Capabilities.IotEdge }

	# Send Device-to-Cloud Message
	$result = Send-AzIotHubDevice2CloudMessage -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Message "Ping from PS" -Passthru
	Assert-False { $result }

	# Add iot device with selfsigned authentication
	$newDevice2 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device2 -AuthMethod 'x509_thumbprint' -PrimaryThumbprint $primaryThumbprint -SecondaryThumbprint $secondaryThumbprint
	Assert-True { $newDevice2.Id -eq $device2 }
	Assert-True { $newDevice2.Authentication.Type -eq 'SelfSigned' }
	Assert-False { $newDevice2.Capabilities.IotEdge }

	# Add iot device with certificate authority authentication
	$newDevice3 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3 -AuthMethod 'x509_ca'
	Assert-True { $newDevice3.Id -eq $device3 }
	Assert-True { $newDevice3.Authentication.Type -eq 'CertificateAuthority' }
	Assert-False { $newDevice3.Capabilities.IotEdge }

	# Add edge device with symmetric authentication
	$newDevice6 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device6 -AuthMethod 'shared_private_key' -EdgeEnabled
	Assert-True { $newDevice6.Id -eq $device6 }
	Assert-True { $newDevice6.Authentication.Type -eq 'Sas' }
	Assert-True { $newDevice6.Capabilities.IotEdge }

	# Generate SAS token for device
	$deviceToken = New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-StartsWith $SasTokenPrefix $deviceToken

	# Test SAS token validity
	$hostname = $iothub.Properties.HostName
	$deviceMessageUri = "https://$hostname/devices/$device1/messages/events?api-version=$dataplaneApiVersion"
	$deviceMessageResult = Invoke-WebRequest -Uri $deviceMessageUri -Method Post -Body "test" -Headers @{Authorization = $deviceToken}
	Assert-True { $deviceMessageResult.StatusCode -eq 204 }

	# Expected error while generating SAS token for device
	$errorMessage = "This device does not support SAS auth."
	Assert-ThrowsContains { New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3 } $errorMessage

	# Invoke direct method on device
	$errorMessage = "The entered device ""fakeDevice"" doesn't exist."
	Assert-ThrowsContains { New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId "fakeDevice" } $errorMessage

	Wait-Seconds 15

	# Count devices
	$totalDevices = Invoke-AzIotHubQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Query "select * from devices"
	Assert-True { $totalDevices.Count -eq 4}

	# Get device twin
	$device1twin = Get-AzIotHubDeviceTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $device1twin.DeviceId -eq $device1}

	# Partial update device twin
	$tags1 = @{}
	$tags1.Add('Test1', '1')
	$updateddevice1twin1 = Update-AzIotHubDeviceTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -tag $tags1 -Partial
	Assert-True { $updateddevice1twin1.DeviceId -eq $device1}
	Assert-True { $updateddevice1twin1.tags.Count -eq 1}

	$tags2 = @{}
	$tags2.Add('Test2', '2')
	$updateddevice1twin2 = Update-AzIotHubDeviceTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -tag $tags2 -Partial
	Assert-True { $updateddevice1twin2.DeviceId -eq $device1}
	Assert-True { $updateddevice1twin2.tags.Count -eq 2}

	# Update device twin
	$tags3 = @{}
	$tags3.Add('Test3', '3')
	$updateddevice1twin3 = Update-AzIotHubDeviceTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -tag $tags3
	Assert-True { $updateddevice1twin3.DeviceId -eq $device1}
	Assert-True { $updateddevice1twin3.tags.Count -eq 1}

	# Invoke direct method on device
	$errorMessage = "The operation failed because the requested device isn't online. To learn more, see https://aka.ms/iothub404103"
	Assert-ThrowsContains { Invoke-AzIotHubDeviceMethod -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Name "SetTelemetryInterval" } $errorMessage
	
	# Get all devices
	$devices = Get-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName
	Assert-True { $devices.Count -eq 4}

	# Get device connection string
	$deviceCS = Get-AzIotHubDCS -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3
	Assert-True { $deviceCS.DeviceId -eq $device3 }
	Assert-True { $deviceCS.ConnectionString -eq "HostName=$IotHubName.azure-devices.net;DeviceId=$device3;x509=true" }

	# Update Device
	$updatedDevice1 = Set-AzIoTHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Status 'Disabled' -StatusReason 'Reason1'
	Assert-True { $updatedDevice1.Id -eq $device1 }
	Assert-True { $updatedDevice1.Status -eq 'Disabled' }
	Assert-True { $updatedDevice1.StatusReason -eq 'Reason1' }

	# Update iot device to edge device
	$updatedDevice3 = Set-AzIoTHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3 -EdgeEnabled $true
	Assert-True { $updatedDevice3.Capabilities.IotEdge }

	# Set parent device Id
	$updatedChildDevice = Set-AzIotHubDeviceParent -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ParentDeviceId $device3
	Assert-False { $updatedChildDevice.Capabilities.IotEdge }
	Assert-True { $updatedChildDevice.Id -eq $device1 }
	Assert-True { $updatedChildDevice.Scope -eq $updatedDevice3.Scope }

	# Get parent device Id
	$parentDevice = Get-AzIotHubDeviceParent -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $parentDevice.Capabilities.IotEdge }
	Assert-True { $parentDevice.Id -eq $device3 }
	Assert-True { $updatedChildDevice.Scope -eq $updatedDevice3.Scope }

	# Add Device with children Device
	$newDevice4 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device4 -AuthMethod 'shared_private_key' -EdgeEnabled -Children $device1,$device2 -Force
	Assert-True { $newDevice4.Capabilities.IotEdge }
	Assert-True { $newDevice4.Id -eq $device4 }
	Assert-True { $newDevice4.Authentication.Type -eq 'Sas' }

	# Get device detail
	$iotDevice = Get-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $iotDevice.Id -eq $device1 }
	Assert-True { $iotDevice.Authentication.Type -eq 'Sas' }
	Assert-False { $iotDevice.Capabilities.IotEdge }
	Assert-True { $iotDevice.Status -eq 'Disabled' }
	Assert-True { $iotDevice.StatusReason -eq 'Reason1' }
	Assert-True { $iotDevice.Scope -eq $newDevice4.Scope }

	# Add Device with parent Device
	$newDevice5 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device5 -AuthMethod 'shared_private_key' -ParentDeviceId $device4
	Assert-True { $newDevice5.Id -eq $device5 }
	Assert-True { $newDevice5.Authentication.Type -eq 'Sas' }
	Assert-False { $newDevice5.Capabilities.IotEdge }
	Assert-True { $newDevice5.Scope -eq $newDevice4.Scope }

	Wait-Seconds 15

	# Get all device children
	$devices = Get-AzIotHubDCL -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName
	Assert-True { $devices.Count -eq 3}

	# Get device children
	$deviceChildren1 = Get-AzIotHubDCL -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device4
	Assert-True { $deviceChildren1[0].DeviceId -eq $device4}
	Assert-True { $deviceChildren1[0].ChildrenDeviceId.split().Count -eq 3}
	
	# Add Children Device to Edge Device
	$deviceChildren2 = Add-AzIotHubDeviceChildren -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3 -Children $device1,$device2 -Force
	Assert-True { $deviceChildren2.DeviceId -eq $device3}
	Assert-True { $deviceChildren2.ChildrenDeviceId.split().Count -eq 2}

	# Remove device children
	$result = Remove-AzIotHubDeviceChildren -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3 -Children $device1 -Passthru
	Assert-True { $result }

	# Get device children
	$device = Get-AzIotHubDCL -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device3
	Assert-True { $device[0].DeviceId -eq $device3}
	Assert-True { $device[0].ChildrenDeviceId.split().Count -eq 1}

	# Delete iot device
	$result = Remove-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Passthru
	Assert-True { $result }

	Wait-Seconds 15

	# Delete all devices
	$result = Remove-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Passthru
	Assert-True { $result }
}