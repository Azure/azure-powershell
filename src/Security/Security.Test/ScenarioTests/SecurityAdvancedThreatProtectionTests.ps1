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
Get a security contact by resource ID
#>
function Test-AzSecurityThreatProtection-ResourceId
{
	# Setup
	$testPrefix = "psstorage"
	$testParams = Get-AdvancedThreatProtectionTestEnvironmentParameters $testPrefix
	$resourceId = "/subscriptions/" + $testParams.subscriptionId + "/resourceGroups/" + $testParams.rgName + "/providers/Microsoft.Storage/storageAccounts/" + $testParams.accountName
	Create-TestEnvironmentWithParams $testParams

	#Enable
	$policy = Set-AzSecurityThreatProtection -ResourceId $resourceId -Enable
    $fetchedPolicy = Get-AzSecurityThreatProtection -ResourceId $resourceId
	Assert-AreEqual $policy.IsEnabled $True
	Assert-AreEqual $True $fetchedPolicy.IsEnabled

	#Disable
	$policy = Set-AzSecurityThreatProtection -ResourceId $resourceId -Disable
    $fetchedPolicy = Get-AzSecurityThreatProtection -ResourceId $resourceId
	Assert-AreEqual $policy.IsEnabled $False
	Assert-AreEqual $False $fetchedPolicy.IsEnabled
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-AdvancedThreatProtectionTestEnvironmentParameters ($testPrefix)
{
	return @{ subscriptionId =  (Get-AzContext).Subscription.Id;
			rgName = getAssetName ($testPrefix);
			accountName = getAssetName ($testPrefix);
			storageSku = "Standard_GRS";
			location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
			}
}

	<#
.SYNOPSIS
Creates the basic test environment needed to perform the threat protection tests - resource group and storage account
#>
function Create-TestEnvironmentWithParams ($testParams)
{
	# Create a new resource group.
	New-AzResourceGroup -Name $testParams.rgName -Location $testParams.location

	# Create the storage account.
	$storageAccount = New-AzStorageAccount -ResourceGroupName $testParams.rgName -Name $testParams.accountName -Location $testParams.location -Type $testParams.storageSku
}