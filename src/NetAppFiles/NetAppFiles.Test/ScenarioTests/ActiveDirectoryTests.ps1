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
Test Active Directory cmdLet CRUD operations
#>
function Test-ActiveDirectoryCrud
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $activeDirectoryName1 = Get-ResourceName
    $activeDirectoryName2 = Get-ResourceName
    $accName2 = Get-ResourceName
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    $resourceLocation = 'westus2'
    $adUsername = "sdkuser"    
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
    $adPassword = "sdkpass"
    $adDomain = "sdkdomain"
    $adDns = "192.0.2.2"
    $adSmbServerName = "PSSMBSName"
    $adSmbServerName2 = "PSMBSName2"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        $sPass = ConvertTo-SecureString $adPassword -AsPlainText -Force
        # create and check ActiveDirectory
        $retrievedAd = New-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1 -AdName $activeDirectoryName1 -Username $adUsername -Password $sPass -Domain $adDomain -Dns $adDns -SmbServerName $adSmbServerName
        $activeDirectoryId = $retrievedAd.ActiveDirectoryId
        Assert-AreEqual $adDomain $retrievedAd.Domain        
        Assert-AreEqual $adUsername $retrievedAd.Username
        Assert-AreEqual $adDns $retrievedAd.Dns
        Assert-AreEqual $adSmbServerName $retrievedAd.SmbServerName
        
        # get and check account
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1
        Assert-AreEqual $adSmbServerName $retrievedAcc.ActiveDirectories[0].SmbServerName
        Assert-AreEqual $adUsername $retrievedAcc.ActiveDirectories[0].Username

        # get and check a ActiveDirectory by id and check again
        $getRetrievedAd = Get-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1 -ActiveDirectoryId $activeDirectoryId
        Assert-AreEqual $activeDirectoryName1 $getRetrievedAd.AdName        
        Assert-AreEqual $adDomain $getRetrievedAd.Domain        
        Assert-AreEqual $adUsername $getRetrievedAd.Username
        Assert-AreEqual $adDns $getRetrievedAd.Dns
        Assert-AreEqual $adSmbServerName $getRetrievedAd.SmbServerName       
        
        #update AD 
        $getUpdateddAd = Update-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1 -ActiveDirectoryId $getRetrievedAd.ActiveDirectoryId -SmbServerName $adSmbServerName2 -Password $sPass
        Assert-AreEqual $adSmbServerName2 $getUpdateddAd.SmbServerName

        # delete activeDirectory retrieved   
        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1 -ActiveDirectoryId $getRetrievedAd.ActiveDirectoryId -WhatIf
        $retrievedActiveDirectoryList = Get-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 1 $retrievedActiveDirectoryList.Length
                              
        #remove by name
        Remove-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1 -ActiveDirectoryId $getRetrievedAd.ActiveDirectoryId
        Start-TestSleep -Seconds 15
        $retrievedActiveDirectoryList = Get-AzNetAppFilesActiveDirectory -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 0 $retrievedActiveDirectoryList.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    
<#
.SYNOPSIS
Test activeDirectory Pipeline operations (uses command aliases)
#>
function Test-ActiveDirectoryPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName        
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $resourceLocation = 'westus2'
    $activeDirectoryName1 = Get-ResourceName    
    $adUsername = "sdkuser"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
    $adPassword = "sdkpass"
    $adDomain = "sdkdomain"
    $adDns = "192.0.2.2"
    $adSmbServerName = "PSSMBSName"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1
        $sPass = ConvertTo-SecureString $adPassword -AsPlainText -Force
        #create AD piping in Account
        $retrievedAd = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1 | New-AzNetAppFilesActiveDirectory -AdName $activeDirectoryName1 -Username $adUsername -Password $sPass -Domain $adDomain -Dns $adDns -SmbServerName $adSmbServerName

        $getRetrievedAd = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1 | Get-AzNetAppFilesActiveDirectory -ActiveDirectoryId $retrievedAd.ActiveDirectoryId
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
