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


########################################
## Manage IotDps Registration Cmdlets ##
########################################

<#
.SYNOPSIS
Test Iot Hub Device Provisioning Service Registration cmdlets
#>

function Test-AzIotDpsRegistrationLifeCycle
{
	$Location = Get-Location "Microsoft.Devices" "Device Provisioning Service" 
	$IotDpsName = getAssetName 
	$ResourceGroupName = getAssetName 
	$IotHubName = getAssetName
	$hubKeyName = "ServiceKey"
	$Sku = "S1"
	$symEnroll = getAssetName
	$symEnrollGroup = getAssetName

	# Constant variable
	$LinkedHubName = [string]::Format("{0}.azure-devices.net",$IotHubName)
	$AllocationWeight = 10

	# Create or Update Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub Device Provisioning Service
	$iotDps = New-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Location $Location
	Assert-True { $iotDps.Name -eq $IotDpsName }
	Assert-True { $iotDps.Properties.IotHubs.Count -eq 0 }

	# Create an Iot Hub
	$iotHub = New-AzIoTHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1
	Assert-True { $iotHub.Name -eq $IotHubName }

	# Add a key to IoT Hub
	$hubKeys = Add-AzIoTHubKey -Name $IotHubName -ResourceGroupName $ResourceGroupName -KeyName $hubKeyName -Rights ServiceConnect
	Assert-True { $hubKeys.Count -gt 1 }

	# Get key information from IoT Hub
	$hubKey = Get-AzIoTHubKey -Name $IotHubName -ResourceGroupName $ResourceGroupName -KeyName $hubKeyName

	$HubConnectionString = [string]::Format("HostName={0};SharedAccessKeyName={1};SharedAccessKey={2}",$iotHub.Properties.HostName,$hubKey.KeyName,$hubKey.PrimaryKey)

	# Link an Iot Hub to an Iot Hub Device Provisioning Service
	$linkedHub = Add-AzIoTDpsHub -ResourceGroupName $ResourceGroupName -Name $IotDpsName -IotHubConnectionString $HubConnectionString -IotHubLocation $iotHub.Location
	Assert-True { $linkedHub.Count -eq 1 }
	Assert-True { $linkedHub.LinkedHubName -eq $iotHub.Properties.HostName }
	Assert-True { $linkedHub.Location -eq $iotHub.Location }
	
	# Create enrollment with symmetrickey attestation
	$symEnrollment = Add-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -RegistrationId $symEnroll -AttestationType SymmetricKey 
	Assert-True { $symEnrollment.RegistrationId -eq $symEnroll }

	# Get Enrollment
	$enrollment = Get-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -RegistrationId $symEnroll
	Assert-True { $enrollment.RegistrationId -eq $symEnroll }

	# Create enrollment group with symmetrickey attestation
	$symEnrollmentGroup = Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnrollGroup -AttestationType SymmetricKey 
	Assert-True { $symEnrollmentGroup.EnrollmentGroupId -eq $symEnrollGroup }

	# Get enrollment group
	$enrollment = Get-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnrollGroup
	Assert-True { $enrollment.EnrollmentGroupId -eq $symEnrollGroup }
	
	# Error While invalid input
	$errorMessage = "Please provide either RegistrationId or EnrollmentId"
	Assert-ThrowsContains { Get-AzIoTDeviceProvisioningServiceRegistration -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName } $errorMessage
	Assert-ThrowsContains { Get-AzIoTDeviceProvisioningServiceRegistration -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -RegistrationId $symEnroll -EnrollmentId $symEnrollGroup} $errorMessage

	# Error While getting device registration
	$errorMessage = "Not Found"
	Assert-ThrowsContains { Get-AzIoTDeviceProvisioningServiceRegistration -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -RegistrationId $symEnroll } $errorMessage

	# Get Registrations
	$registrations = Get-AzIoTDeviceProvisioningServiceRegistration -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -EnrollmentId $symEnrollGroup
	Assert-True { $registrations.Count -eq 0 }

	# Error While deleting device registration
	$errorMessage = "Not Found"
	Assert-ThrowsContains { Remove-AzIoTDeviceProvisioningServiceRegistration -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -RegistrationId $symEnroll } $errorMessage

	# Remove enrollment group
	$result = Remove-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -PassThru
	Assert-True { $result }

	# Remove enrollment
	$result = Remove-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -PassThru
	Assert-True { $result }

	# Remove Linked Hub from Iot Hub Device Provisioning Service
	$result = Remove-AzIoTDpsHub -ResourceGroupName $ResourceGroupName -Name $IotDpsName -LinkedHubName $LinkedHubName -PassThru
	Assert-True { $result }

	# Remove IotHub
	Remove-AzIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName

	# Remove Resource Group
	Remove-AzResourceGroup -Name $ResourceGroupName -force
}
