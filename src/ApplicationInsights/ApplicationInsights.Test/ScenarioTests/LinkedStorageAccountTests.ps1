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
Test LinkedStorageAccountCRUD
#>
function Test-LinkedStorageAccountCRUD
{
	# setup
    $rgname = "azps-test-group-mock"
    $appName = "azps-test-ai-mock";
    $loc = Get-ProviderLocation ResourceManagement;
    $kind = "web";

    $accountName1 = "azpstestaccountamock"
    $accountName2 = "azpstestaccountbmock"

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc;

        $app = New-AzApplicationInsights -ResourceGroupName $rgname -ComponentName $appName -Location $loc -Kind $kind

        $account1 = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName1 -SkuName "Standard_LRS" -Location $loc
        $account2 = New-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -SkuName "Standard_LRS" -Location $loc

        New-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName $rgname -ComponentName $appName -LinkedStorageAccountResourceId $account1.Id
        $linkedAccount = Get-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName $rgname -ComponentName $appName

        Assert-NotNull $linkedAccount
        Assert-AreEqual $account1.Id $linkedAccount.linkedStorageAccount
        Assert-AreEqual "serviceprofiler" $linkedAccount.Name

        Update-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName $rgname -ComponentName $appName -LinkedStorageAccountResourceId $account2.Id
        $linkedAccount = Get-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName $rgname -ComponentName $appName

        Assert-NotNull $linkedAccount
        Assert-AreEqual $account2.Id $linkedAccount.linkedStorageAccount

        Remove-AzApplicationInsightsLinkedStorageAccount -ResourceGroupName $rgname -ComponentName $appName

        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName1 -force
        Remove-AzStorageAccount -ResourceGroupName $rgname -Name $accountName2 -force

        Remove-AzApplicationInsights -ResourceGroupName $rgname -Name $appName

        Remove-AzResourceGroup -Name $rgname
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}