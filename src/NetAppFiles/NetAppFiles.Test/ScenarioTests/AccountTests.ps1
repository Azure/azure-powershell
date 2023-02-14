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
Test Account Active Directory
#>
function Test-AccountActiveDirectory
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $accName3 = Get-ResourceName
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $resourceLocation = 'westus2'

    $activeDirectory1 = @{
        Username = "sdkuser"
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
        Password = "sdkpass"
        Domain = "sdkdomain"
        Dns = "192.0.2.2"
        SmbServerName = "PSMBSName1"
    }
    $activeDirectory2 = @{
        Username = "sdkuser1"
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
        Password = "sdkpass2"
        Domain = "sdkdomain"
        Dns = "192.0.2.2"
        SmbServerName = "PSMBSName2"
    }

    try
    {
        # create the resource group
        $groupTagName = "owner"
        $groupTagValue = "b-aubald"
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{$groupTagName = $groupTagValue}

        # check multiple ADs are captured
        # currently this is not permitted and throws a message
        try
        {
            $activedirectories = @( $activeDirectory1, $activeDirectory2 )

            # create and check account 1
            $newTagName = "tag1"
            $newTagValue = "tagValue1"
            #$retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirector $activeDirectories

            Assert-ThrowsContains{  New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirectory $activeDirectories} 'Only one active directory allowed';
            #Assert-True { $false }
        }
        catch
        {
            $ErrorMessage = $_.Exception.Message
            #Assert-True { ($ErrorMessage -contains 'Only one active directory allowed') }
            Assert-True { ($ErrorMessage -contains 'Only one') }
            #Assert-AreEqual $accName1 $retrievedAcc.Name
        }

        # try creating an AD -

        $activedirectories = @( $activeDirectory1 )

        # create and check account 1
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirectory $activeDirectories
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual $activeDirectory1.SmbServerName $retrievedAcc.ActiveDirectories[0].SmbServerName
        Assert-AreEqual $activeDirectory1.Username $retrievedAcc.ActiveDirectories[0].Username

        # patch an Active Directory with no active directory. Should be no change
        # except for the tag update
        $newTagName = "tag1"
        $newTagValue = "tagValue2"
        $retrievedAcc = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual $activeDirectory1.SmbServerName $retrievedAcc.ActiveDirectories[0].SmbServerName
        Assert-AreEqual $activeDirectory1.Username $retrievedAcc.ActiveDirectories[0].Username
        Assert-AreEqual 1 $retrievedAcc.ActiveDirectories.Length
        Assert-AreEqual "tagValue2" $retrievedAcc.Tags[$newTagName].ToString()

        # update (put) the account. The absence of an active directory should result in the removal of any currently associated. Also tags
        $retrievedAcc = Set-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName1 -Location $resourceLocation
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-Null $retrievedAcc.Tags
        Assert-Null $retrievedAcc.ActiveDirectories

        # patch an Active Directory. Should be updated to contain only the new one
        $activedirectories = @( $activeDirectory2 )
        $retrievedAcc = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -ActiveDirectory $activedirectories
        Assert-AreEqual $accName1 $retrievedAcc.Name
        # correction to (wildcard values in) returned password expected in RP
        # add this check back in at that time since username/password are the two fields of concern
        # Assert-AreEqual $activeDirectory2.Password $retrievedAcc.ActiveDirectories[0].Password
        Assert-AreEqual $activeDirectory2.Username $retrievedAcc.ActiveDirectories[0].Username
        Assert-AreEqual 1 $retrievedAcc.ActiveDirectories.Length

        # update (put) the account. The absence of an active directory should result in the removal of any currently associated. Also tags
        $retrievedAcc = Set-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName1 -Location $resourceLocation
        Assert-AreEqual $accName1 $retrievedAcc.Name

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    
<#
.SYNOPSIS
Test Account CRUD operations
#>
function Test-AccountCrud
{
    #$resourceGroup = "somename2"
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $accName3 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        #New-AzResourceGroup -Name $resourceGroup -Tags @{Owner = 'b-aubald'} -Location $resourceLocation 
      
        # create and check account 1
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual True $retrievedAcc.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedAcc.Tags[$newTagName].ToString()

        # create and check account 2 using the Confirm flag
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName2 -Confirm:$false
        Assert-AreEqual $accName2 $retrievedAcc.Name
		
        # create and check account 3 using the WhatIf - it should not be created
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName3 -WhatIf

        # get and check accounts by group (list)
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-True {"$accName1" -eq $retrievedAcc[0].Name -or "$accName2" -eq $retrievedAcc[0].Name}
        Assert-True {"$accName1" -eq $retrievedAcc[1].Name -or "$accName2" -eq $retrievedAcc[1].Name}
        Assert-AreEqual 2 $retrievedAcc.Length

        # get and check an account by name
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1
        Assert-AreEqual $accName1 $retrievedAcc.Name

        # get and check the account again using the resource id just obtained
        $retrievedAccById = Get-AzNetAppFilesAccount -ResourceId $retrievedAcc.Id
        Assert-AreEqual $accName1 $retrievedAccById.Name

        # update and check the account (tags) - the active directory test chceks this stuff

        # delete one account retrieved by id and one by name and check removed
        Remove-AzNetAppFilesAccount -ResourceId $retrievedAccById.Id

        # but test the WhatIf first
        Remove-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName2 -WhatIf
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        Assert-AreEqual 1 $retrievedAcc.Length

        Remove-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName2
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        Assert-AreEqual 0 $retrievedAcc.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Account Pipeline operations (uses command aliases)
#>
function Test-AccountPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"

    try
    {
        # create the resource group
        $groupTagName = "owner"
        $groupTagValue = "b-aubald"
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tag @{$groupTagName = $groupTagValue}


        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 | Remove-AnfAccount

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName2

        Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName2 | Remove-AnfAccount
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
