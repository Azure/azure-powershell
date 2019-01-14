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


##########################################
## Manage IotDps Access Policy Cmdlets	##
##########################################

<#
.SYNOPSIS
Test Iot Hub Device Provisioning Service Access Policy cmdlets for CRUD operations 
#>

function Test-AzureIotDpsAccessPolicyLifeCycle
{
	$Location = Get-Location "Microsoft.Devices" "Device Provisioning Service" 
	$IotDpsName = getAssetName 
	$ResourceGroupName = getAssetName 

	# Constant variable
	$AccessPolicyDefaultKeyName = "provisioningserviceowner"
	$AccessPolicyDefaultRights = "ServiceConfig, DeviceConnect, EnrollmentWrite"
	$NewAccessPolicyKeyName = "Access1"
	$NewAccessPolicyRights = "ServiceConfig"

	# Create or Update Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub Device Provisioning Service
	$iotDps = New-AzureRmIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Location $Location
	Assert-True { $iotDps.Name -eq $IotDpsName }

	# Get Iot Hub Device Provisioning Service Access Policy
	$iotDpsAccessPolicy1 = Get-AzureRmIoTDpsAccessPolicy -ResourceGroupName $ResourceGroupName -Name $IotDpsName
	Assert-True { $iotDpsAccessPolicy1.Count -eq 1 }
	Assert-True { $iotDpsAccessPolicy1.KeyName -eq $AccessPolicyDefaultKeyName }
	Assert-True { $iotDpsAccessPolicy1.Rights -eq $AccessPolicyDefaultRights }

	# Add Iot Hub Device Provisioning Service Access Policy
	$iotDpsAccessPolicy2 = Add-AzureRmIoTDpsAccessPolicy -ResourceGroupName $ResourceGroupName -Name $IotDpsName -KeyName $NewAccessPolicyKeyName -Permissions $NewAccessPolicyRights
	Assert-True { $iotDpsAccessPolicy2.Count -eq 2 }
	Assert-True { $iotDpsAccessPolicy2[1].KeyName -eq $NewAccessPolicyKeyName }
	Assert-True { $iotDpsAccessPolicy2[1].Rights -eq $NewAccessPolicyRights }

	# Delete Iot Hub Device Provisioning Service Access Policy
	$result = Remove-AzureRmIoTDpsAccessPolicy -ResourceGroupName $ResourceGroupName -Name $IotDpsName -KeyName $NewAccessPolicyKeyName -PassThru
	Assert-True { $result }

	# Update Iot Hub Device Provisioning Service Access Policy
	$iotDpsAccessPolicy3 = Update-AzureRmIoTDpsAccessPolicy -ResourceGroupName $ResourceGroupName -Name $IotDpsName -KeyName $AccessPolicyDefaultKeyName -Permissions $NewAccessPolicyRights
	Assert-True { $iotDpsAccessPolicy3.Count -eq 1 }
	Assert-True { $iotDpsAccessPolicy3.KeyName -eq $AccessPolicyDefaultKeyName }
	Assert-True { $iotDpsAccessPolicy3.Rights -eq $NewAccessPolicyRights }

	# Remove Iot Hub Device Provisioning Service
	$result = Remove-AzureRmIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -PassThru
	Assert-True { $result }

	# Remove Resource Group
	Remove-AzureRmResourceGroup -Name $ResourceGroupName -force
}
