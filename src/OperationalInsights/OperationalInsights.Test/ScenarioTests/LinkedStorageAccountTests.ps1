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
Test LinkedStorageAccount
#>
function Test-LinkedStorageAccount
{
	# setup
	$rgname = Get-ResourceGroupName
	$workspaceName = Get-ResourceName
	$loc = Get-ProviderLocation

	$accountName1 = "azpstestaccountmock11"
    $accountName2 = "azpstestaccountmock21"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $loc

		$workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $workspaceName -Location $loc

		$account1 = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName1 -SkuName "Standard_LRS" -Location $loc
        $account2 = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -SkuName "Standard_LRS" -Location $loc

		New-AzOperationalInsightsLinkedStorageAccount -ResourceGroupName $rgname -WorkspaceName $workspaceName -DataSourceType "CustomLogs" -StorageAccountId $account1.Id

		$linkedAccount = Get-AzOperationalInsightsLinkedStorageAccount -ResourceGroupName $rgname -WorkspaceName $workspaceName -DataSourceType "CustomLogs"

		Assert-NotNull $linkedAccount
		Assert-AreEqual "CustomLogs" $linkedAccount.DataSourceType
		Assert-AreEqual $account1.Id $linkedAccount.StorageAccountIds[0]

		$linkedAccount = Set-AzOperationalInsightsLinkedStorageAccount -ResourceGroupName $rgname -WorkspaceName $workspaceName -DataSourceType "CustomLogs" -StorageAccountId $account2.Id

		Assert-NotNull $linkedAccount
		Assert-AreEqual "CustomLogs" $linkedAccount.DataSourceType
		Assert-AreEqual $account2.Id $linkedAccount.StorageAccountIds[0]

		$delete = Remove-AzOperationalInsightsLinkedStorageAccount -ResourceGroupName $rgname -WorkspaceName $workspaceName -DataSourceType "CustomLogs"

		Assert-AreEqual $true $delete

		Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName1 -force
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -force
		Remove-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $workspaceName -force
	}
	finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname 
	}
}