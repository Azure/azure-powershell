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


##############################################
## Manage IotDps Enrollment Group Cmdlets	##
##############################################

<#
.SYNOPSIS
Test Iot Hub Device Provisioning Service Enrollment Group cmdlets for CRUD operations 
#>

function Test-AzIotDpsEnrollmentGroupLifeCycle
{
	$Location = Get-Location "Microsoft.Devices" "Device Provisioning Service" 
	$IotDpsName = getAssetName 
	$ResourceGroupName = getAssetName 
	$IotHubName = getAssetName
	$hubKeyName = "ServiceKey"
	$PrimaryCertificateKey = "MIIBiDCCAS2gAwIBAgIFWks8LR4wCgYIKoZIzj0EAwIwNjEUMBIGA1UEAwwLcmlvdGNvcmVuZXcxETAPBgNVBAoMCE1TUl9URVNUMQswCQYDVQQGEwJVUzAgFw0xNzAxMDEwMDAwMDBaGA8zNzAxMDEzMTIzNTk1OVowNjEUMBIGA1UEAwwLcmlvdGNvcmVuZXcxETAPBgNVBAoMCE1TUl9URVNUMQswCQYDVQQGEwJVUzBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABLVS6bK+QMm+HZ0247Nm+JmnERuickBXTj6rydcP3WzVQNBNpvcQ/4YVrPp60oiYRxZbsPyBtHt2UCAC00vEXy+jJjAkMA4GA1UdDwEB/wQEAwIHgDASBgNVHRMBAf8ECDAGAQH/AgECMAoGCCqGSM49BAMCA0kAMEYCIQDEjs2PoZEi/yAQNj2Vji9RthQ33HG/QdL12b1ABU5UXgIhAPJujG/c/S+7vcREWI7bQcCb31JIBDhWZbt4eyCvXZtZ"
	$SecondaryCertificateKey = "MIIBiDCCAS2gAwIBAgIFWks8LR4wCgYIKoZIzj0EAwIwNjEUMBIGA1UEAwwLcmlvdGNvcmVuZXcxETAPBgNVBAoMCE1TUl9URVNUMQswCQYDVQQGEwJVUzAgFw0xNzAxMDEwMDAwMDBaGA8zNzAxMDEzMTIzNTk1OVowNjEUMBIGA1UEAwwLcmlvdGNvcmVuZXcxETAPBgNVBAoMCE1TUl9URVNUMQswCQYDVQQGEwJVUzBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IABLVS6bK+QMm+HZ0247Nm+JmnERuickBXTj6rydcP3WzVQNBNpvcQ/4YVrPp60oiYRxZbsPyBtHt2UCAC00vEXy+jJjAkMA4GA1UdDwEB/wQEAwIHgDASBgNVHRMBAf8ECDAGAQH/AgECMAoGCCqGSM49BAMCA0kAMEYCIQDEjs2PoZEi/yAQNj2Vji9RthQ33HG/QdL12b1ABU5UXgIhAPJujG/c/S+7vcREWI7bQcCb31JIBDhWZbt4eyCvXZtY"
	$Sku = "S1"
	$symEnroll = getAssetName
	$x509Enroll = getAssetName

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
	
	# Expecting error while creating enrollment group with invalid attestation mechanism
	$errorMessage = "Please provide valid attestation mechanism"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType None } $errorMessage
	$errorMessage = '"TPM" is not a valid attestation mechanism for an enrollment group'
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType Tpm } $errorMessage

	# Expecting error while creating enrollment group with symmetrickey attestation mechanism
	$errorMessage = "Please provide both primary and secondary key"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -PrimaryKey "123456" } $errorMessage

	# Expecting error while creating enrollment group with X509 attestation mechanism
	$errorMessage = "Please provide either CA reference or X509 certificate"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -AttestationType X509 -SecondaryCAName "valid-ca-name" -SecondaryCertificate "valid-certificate" } $errorMessage
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -AttestationType X509 } $errorMessage
	$errorMessage = "Primary CA reference cannot be null or empty"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -AttestationType X509 -SecondaryCAName "valid-ca-name" } $errorMessage
	$errorMessage = "Primary certificate cannot be null or empty"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -AttestationType X509 -SecondaryCertificate "valid-certificate" } $errorMessage

	# Expecting error while creating enrollment group with allocation policy and iothubhostname both defined.
	$errorMessage = '"IotHubHostName" is not required when allocation-policy is defined'
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -AllocationPolicy GeoLatency -IotHubHostName $LinkedHubName } $errorMessage

	# Expecting error while creating enrollment group with static allocation policy.
	$errorMessage = "Please provide only one hub when allocation-policy is defined as Static"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -AllocationPolicy Static -IotHub "hub1","hub2" } $errorMessage
	$errorMessage = "Please provide a hub to be assigned with device"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -AllocationPolicy Static } $errorMessage

	# Expecting error while creating enrollment group with custom allocation policy.
	$errorMessage = "Please provide an Azure function url when allocation-policy is defined as Custom"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -AllocationPolicy Custom } $errorMessage
	$errorMessage = "Please provide an Azure function api-version when allocation-policy is defined as Custom"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -AllocationPolicy Custom -WebhookUrl "azure-function-url" } $errorMessage

	# Expecting error while creating enrollment group without allocation policy.
	$errorMessage = "Please provide allocation policy"
	Assert-ThrowsContains { Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey -IotHub $LinkedHubName } $errorMessage

	# Create enrollment group with symmetrickey attestation
	$symEnrollment = Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -AttestationType SymmetricKey 
	Assert-True { $symEnrollment.EnrollmentGroupId -eq $symEnroll }
	Assert-True { $symEnrollment.AllocationPolicy -eq "Hashed" }
	Assert-False { $symEnrollment.Capabilities.IotEdge }
	Assert-True { $symEnrollment.ProvisioningStatus -eq "Enabled" }
	Assert-True { $symEnrollment.Attestation.Type -eq "SymmetricKey" }
	Assert-True { $symEnrollment.ReprovisionPolicy.UpdateHubAssignment }
	Assert-True { $symEnrollment.ReprovisionPolicy.MigrateDeviceData }

	# Create enrollment group with X509 attestation
	$x509Enrollment = Add-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -AttestationType X509 -PrimaryCertificate $PrimaryCertificateKey -RootCertificate -IotHubHostName $LinkedHubName -ReprovisionPolicy reprovisionandresetdata -ProvisioningStatus "Disabled"
	Assert-True { $x509Enrollment.EnrollmentGroupId -eq $x509Enroll }
	Assert-True { $x509Enrollment.IotHubHostName -eq $LinkedHubName }
	Assert-False { $x509Enrollment.Capabilities.IotEdge }
	Assert-True { $x509Enrollment.ProvisioningStatus -eq "Disabled" }
	Assert-True { $x509Enrollment.Attestation.Type -eq "X509" }
	Assert-True { $x509Enrollment.ReprovisionPolicy.UpdateHubAssignment }
	Assert-False { $x509Enrollment.ReprovisionPolicy.MigrateDeviceData }

	# Get enrollment group
	$enrollment = Get-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll
	Assert-True { $enrollment.EnrollmentGroupId -eq $symEnroll }
	
	# Get enrollment groups
	$enrollments = Get-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName
	Assert-True { $enrollments.Count -eq 2 }

	# Error While Updating enrollment group
	$errorMessage = "Not Found"
	Assert-ThrowsContains { Set-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name "Invalid" } $errorMessage

	# Update enrollment group
	$tag = @{}
	$tag.add("environment","test")
	$symEnrollmentUpdated = Set-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -Tag $tag -AllocationPolicy Custom -WebhookUrl "https://www.test.test" -ApiVersion "2018-09-01-preview"
	Assert-True { $symEnrollmentUpdated.EnrollmentGroupId -eq $symEnroll }
	Assert-True { $symEnrollmentUpdated.InitialTwinState.Tags.ToJson() -eq '{"environment":"test"}' }
	Assert-True { $symEnrollmentUpdated.AllocationPolicy -eq "Custom" }
	Assert-True { $symEnrollmentUpdated.CustomAllocationDefinition.WebhookUrl -eq "https://www.test.test" }
	Assert-True { $symEnrollmentUpdated.CustomAllocationDefinition.ApiVersion -eq "2018-09-01-preview" }

	$x509EnrollmentUpdated = Set-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -ProvisioningStatus "Enabled"
	Assert-True { $x509EnrollmentUpdated.EnrollmentGroupId -eq $x509Enroll }
	Assert-False { $x509EnrollmentUpdated.Capabilities.IotEdge }
	Assert-True { $x509EnrollmentUpdated.ProvisioningStatus -eq "Enabled" }
	Assert-True { $x509EnrollmentUpdated.Attestation.Type -eq "X509" }
	Assert-True { $x509EnrollmentUpdated.ReprovisionPolicy.UpdateHubAssignment }
	Assert-False { $x509EnrollmentUpdated.ReprovisionPolicy.MigrateDeviceData }

	# Update Enrollment attestation values

	# SymmetricKey (swap keys)
	$symEnrollmentUpdated = Set-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -PrimaryKey $symEnrollment.Attestation.SymmetricKey.SecondaryKey -SecondaryKey  $symEnrollment.Attestation.SymmetricKey.PrimaryKey
	Assert-True { $symEnrollmentUpdated.Attestation.Type -eq "SymmetricKey" }
	Assert-True { $symEnrollmentUpdated.Attestation.PrimaryKey -eq $symEnrollment.Attestation.SecondaryKey }
	Assert-True { $symEnrollmentUpdated.Attestation.SecondaryKey -eq $symEnrollment.Attestation.PrimaryKey }

	# X509 (change certs)
	$x509EnrollmentUpdated = Set-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $x509Enroll -PrimaryCertificate $SecondaryCertificateKey -SecondaryCertificate $PrimaryCertificateKey -RootCertificate
	# Remove enrollment group
	$result = Remove-AzIoTDPSEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -Name $symEnroll -PassThru
	Assert-True { $result }
	$result = Remove-AzIoTDeviceProvisioningServiceEnrollmentGroup -ResourceGroupName $ResourceGroupName -DpsName $IotDpsName -PassThru
	Assert-True { $result }

	# Remove Linked Hub from Iot Hub Device Provisioning Service
	$result = Remove-AzIoTDpsHub -ResourceGroupName $ResourceGroupName -Name $IotDpsName -LinkedHubName $LinkedHubName -PassThru
	Assert-True { $result }

	# Remove IotHub
	Remove-AzIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName

	# Remove Resource Group
	Remove-AzResourceGroup -Name $ResourceGroupName -force
}
