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
## IotHub Module Cmdlets	   ##
#################################

<#
.SYNOPSIS
Test all iothub device module cmdlets
#>
function Test-AzureRmIotHubModuleLifecycle
{
	$Location = Get-Location "Microsoft.Devices" "IotHubs"
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$Sku = "S1"
	$device1 = getAssetName
	$module1 = getAssetName
	$module2 = getAssetName
	$primaryThumbprint = '38303FC7371EC78DDE3E18D732C8414EE50969C7'
	$secondaryThumbprint = 'F54465586FBAF4AC269851424A592254C8861BE7'

	# Create Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Add iot device with symmetric authentication
	$newDevice1 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -AuthMethod 'shared_private_key'
	Assert-True { $newDevice1.Id -eq $device1 }
	Assert-True { $newDevice1.Authentication.Type -eq 'Sas' }
	Assert-False { $newDevice1.Capabilities.IotEdge }

	# Get all devices
	$modules = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $modules.Count -eq 0}

	# Add module on a Iot device
	$newModule1 = Add-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -AuthMethod 'shared_private_key'
	Assert-True { $newModule1.Id -eq $module1 }
	Assert-True { $newModule1.DeviceId -eq $device1 }
	Assert-True { $newModule1.Authentication.Type -eq 'Sas' }

	# Add module on a Iot device with selfsigned authentication
	$newModule2 = Add-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module2 -AuthMethod 'x509_thumbprint' -PrimaryThumbprint $primaryThumbprint -SecondaryThumbprint $secondaryThumbprint
	Assert-True { $newModule2.Id -eq $module2 }
	Assert-True { $newModule2.DeviceId -eq $device1 }
	Assert-True { $newModule2.Authentication.Type -eq 'SelfSigned' }
	
	# Get all modules
	$modules = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $modules.Count -eq 2}

	# Get module connection string
	$moduleCS = Get-AzIotHubMCS -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module2
	Assert-True { $moduleCS.ModuleId -eq $module2 }
	Assert-True { $moduleCS.ConnectionString -eq "HostName=$IotHubName.azure-devices.net;DeviceId=$device1;ModuleId=$module2;x509=true" }

	# Get module detail
	$module = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module2
	Assert-True { $module.Id -eq $module2 }
	Assert-True { $module.DeviceId -eq $device1 }
	Assert-True { $module.Authentication.Type -eq 'SelfSigned' }

	# Update Device
	$updatedModule1 = Set-AzIoTHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -AuthMethod 'x509_ca'
	Assert-True { $updatedModule1.Id -eq $module1 }
	Assert-True { $updatedModule1.DeviceId -eq $device1 }
	Assert-True { $updatedModule1.Authentication.Type -eq 'CertificateAuthority' }

	# Delete iot device module
	$result = Remove-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module2 -Passthru
	Assert-True { $result }

	# Get all modules
	$modules = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $modules.Count -eq 1}

	# Delete all modules
	$result = Remove-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Passthru
	Assert-True { $result }

	# Get all modules
	$modules = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $modules.Count -eq 0}
}