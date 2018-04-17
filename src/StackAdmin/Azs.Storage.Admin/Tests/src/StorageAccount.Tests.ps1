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
    Run AzureStack StorageAccounts admin tests

.DESCRIPTION
    Run AzureStack StorageAccounts admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\StorageAccount.Tests.ps1
    Describing StorageAccounts
	  [+] TestListAllStorageAccounts 4.43s
	  [+] TestGetStorageAccount 44.67s
	  [+] TestGetAllStorageAccounts 43.56s
.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 28, 2018
#>
param(
	[bool]$RunRaw = $false
)

$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Storage.Admin {

	Describe "StorageAccounts" -Tags @('StorageAccounts', 'Azs.Storage.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateStorageAccount {
				param(
					[Parameter(Mandatory=$true)]
					$storageAccount
				)
				# Resource
				$storageAccount								| Should Not Be $null

				# Validate Storage account properties
				$storageAccount.AccountStatus				| Should Not Be $null
				$storageAccount.AccountType					| Should Not Be $null
				$storageAccount.AcquisitionOperationCount	| Should Not Be $null
				$storageAccount.CreationTime				| Should Not Be $null
				$storageAccount.CurrentOperation			| Should Not Be $null
				$storageAccount.Id							| Should Not Be $null
				$storageAccount.Location					| Should Not Be $null
				$storageAccount.Name						| Should Not Be $null
				$storageAccount.PrimaryEndpoints			| Should Not Be $null
				$storageAccount.PrimaryLocation				| Should Not Be $null
				$storageAccount.ProvisioningState			| Should Not Be $null
				$storageAccount.StatusOfPrimary				| Should Not Be $null
				$storageAccount.TenantResourceGroupName		| Should Not Be $null
				$storageAccount.TenantStorageAccountName	| Should Not Be $null
				$storageAccount.TenantSubscriptionId		| Should Not Be $null
				$storageAccount.TenantViewId				| Should Not Be $null
				$storageAccount.Type						| Should Not Be $null
			}

			function AssertAreEqual {
				param(
					[Parameter(Mandatory=$true)]
					$expected,
					[Parameter(Mandatory=$true)]
					$found
				)
				# Resource
				if($expected -eq $null){
					$found												    | Should Be $null
				}
				else{
					$found												    | Should Not Be $null
					# Validate Storage account properties
					$expected.AccountId | Should Be $found.AccountId
					$expected.AccountStatus | Should Be $found.AccountStatus
					$expected.AccountType | Should Be $found.AccountType
					$expected.AcquisitionOperationCount | Should Be $found.AcquisitionOperationCount
					$expected.AlternateName | Should Be $found.AlternateName
					$expected.CurrentOperation | Should Be $found.CurrentOperation
					$expected.CustomDomain | Should Be $found.CustomDomain
				}
			}
		}

		It "TestListAllStorageAccounts" {
			$global:TestName = 'TestListAllStorageAccounts'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$storageAccounts = Get-AzsStorageAccount -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Summary:$false
				foreach($storageAccount in $storageAccounts) {
					ValidateStorageAccount -storageAccount $storageAccount
				}
			}
		}

		It "TestGetStorageAccount" {
			$global:TestName = 'TestGetStorageAccount'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$storageAccounts = Get-AzsStorageAccount -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Summary:$false
				foreach($storageAccount in $storageAccounts) {
				    $result = Get-AzsStorageAccount -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Name (Select-Name $storageAccount.Name)
					ValidateStorageAccount -storageAccount $result
					AssertAreEqual -expected $storageAccount -found $result
					return
				}
			}
		}

		It "TestGetAllStorageAccounts" {
			$global:TestName = 'TestGetAllStorageAccounts'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$storageAccounts = Get-AzsStorageAccount -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Summary:$false
				foreach($storageAccount in $storageAccounts) {
				    $result = Get-AzsStorageAccount -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Name (Select-Name $storageAccount.Name)
					ValidateStorageAccount -storageAccount $result
					AssertAreEqual -expected $storageAccount -found $result
				}
			}
		}
	}
}
