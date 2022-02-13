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
Test Vault CRUD operations
#>
function Test-VaultCrud
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName

    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $backupLocation = "eastus2euap"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupLocation -Tags @{Owner = 'b-aubald'}

        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVault = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedVault.Name
        
        # get and check Vaults 
        $retrievedVaultsList = Get-AzNetAppFilesVault -ResourceGroupName $resourceGroup -AccountName $accName1 
        # check the Vault
        Assert-AreEqual 1 $retrievedVaultsList.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }    
}
