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
	$SasTokenPrefix = 'SharedAccessSignature'
	$device1 = getAssetName
	$device2 = getAssetName
	$module1 = getAssetName
	$module2 = getAssetName
	$primaryThumbprint = '38303FC7371EC78DDE3E18D732C8414EE50969C7'
	$secondaryThumbprint = 'F54465586FBAF4AC269851424A592254C8861BE7'
	$modulesContent = '{"$edgeAgent":{"properties.desired":{"modules":{},"runtime":{"settings":{"minDockerVersion":"v1.25"},"type":"docker"},"schemaVersion":"1.0","systemModules":{"edgeAgent":{"settings":{"image":"mcr.microsoft.com/azureiotedge-agent:1.0","createOptions":""},"type":"docker"},"edgeHub":{"settings":{"image":"mcr.microsoft.com/azureiotedge-hub:1.0","createOptions":"{\"HostConfig\":{\"PortBindings\":{\"8883/tcp\":[{\"HostPort\":\"8883\"}],\"5671/tcp\":[{\"HostPort\":\"5671\"}],\"443/tcp\":[{\"HostPort\":\"443\"}]}}}"},"type":"docker","status":"running","restartPolicy":"always"}}}},"$edgeHub":{"properties.desired":{"routes":{},"schemaVersion":"1.0","storeAndForwardConfiguration":{"timeToLiveSecs":7200}}},"filtermodule":{"properties.desired":{"schemaVersion":"1.0","TemperatureThreshold":21}}}'

	# Create Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Generate SAS token for IotHub
	$token = New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName
	Assert-StartsWith $SasTokenPrefix $token

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
	
	# Generate SAS token for module
	$moduleToken = New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1
	Assert-StartsWith $SasTokenPrefix $moduleToken

	# Expected error while generating SAS token for module
	$errorMessage = "You are unable to get sas token for module without device information."
	Assert-ThrowsContains { New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -ModuleId $module1 } $errorMessage

	# Expected error while generating SAS token for module
	$errorMessage = "This module does not support SAS auth."
	Assert-ThrowsContains { New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module2 } $errorMessage

	# Expected error while generating SAS token for module
	$errorMessage = "The entered module ""fakeModule"" doesn't exist."
	Assert-ThrowsContains { New-AzIotHubSasToken -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId "fakeModule" } $errorMessage

	# Count device modules
	$totalModules = Invoke-AzIotHubQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Query "select * from devices.modules where devices.Id='$device1'"
	Assert-True { $totalModules.Count -eq 2}

	# Get module twin
	$module1twin = Get-AzIotHubModuleTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1
	Assert-True { $module1twin.DeviceId -eq $device1}
	Assert-True { $module1twin.ModuleId -eq $module1}

	# Partial update module twin
	$tags1 = @{}
	$tags1.Add('Test1', '1')
	$updatedmodule1twin1 = Update-AzIotHubModuleTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -tag $tags1 -Partial
	Assert-True { $updatedmodule1twin1.DeviceId -eq $device1}
	Assert-True { $updatedmodule1twin1.ModuleId -eq $module1}
	Assert-True { $updatedmodule1twin1.tags.Count -eq 1}

	$tags2 = @{}
	$tags2.Add('Test2', '2')
	$updatedmodule1twin2 = Update-AzIotHubModuleTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -tag $tags2 -Partial
	Assert-True { $updatedmodule1twin2.DeviceId -eq $device1}
	Assert-True { $updatedmodule1twin2.ModuleId -eq $module1}
	Assert-True { $updatedmodule1twin2.tags.Count -eq 2}

	# Update module twin
	$tags3 = @{}
	$tags3.Add('Test3', '3')
	$updatedmodule1twin3 = Update-AzIotHubModuleTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -tag $tags3
	Assert-True { $updatedmodule1twin3.DeviceId -eq $device1}
	Assert-True { $updatedmodule1twin3.ModuleId -eq $module1}
	Assert-True { $updatedmodule1twin3.tags.Count -eq 1}

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

	# Invoke direct method on device module
	$errorMessage = "The operation failed because the requested device isn't online. To learn more, see https://aka.ms/iothub404103"
	Assert-ThrowsContains { Invoke-AzIotHubModuleMethod -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -ModuleId $module1 -Name "SetTelemetryInterval" } $errorMessage

	# Update Module
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

	# Add iot edge device 
	$newDevice2 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device2 -AuthMethod 'shared_private_key' -EdgeEnabled
	Assert-True { $newDevice2.Id -eq $device2 }
	Assert-True { $newDevice2.Capabilities.IotEdge }

	# Get all edge's modules
	$edgeModules1 = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device2
	Assert-True { $edgeModules1.Count -eq 2}

	# Apply configuration content to edge device
	$content = $modulesContent | ConvertFrom-Json -AsHashtable
	$edgeModules2 = Set-AzIotHubEdgeModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device2 -ModulesContent $content
	Assert-True { $edgeModules2.Count -eq 3}

	# Delete all modules
	$result = Remove-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -Passthru
	Assert-True { $result }

	# Get all modules
	$modules = Get-AzIotHubModule -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $modules.Count -eq 0}
}