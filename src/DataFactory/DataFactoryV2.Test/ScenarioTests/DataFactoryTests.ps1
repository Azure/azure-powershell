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
Gets all factories in subscription across multiple resource groups.
#>
function Test-GetDataFactoriesInSubscription
{	
    $dfname1 = Get-DataFactoryName + "df1"
    $dfname2 = Get-DataFactoryName + "df2"
    $rgname1 = Get-ResourceGroupName + "rg1"
    $rgname2 = Get-ResourceGroupName + "rg2"
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname1 -Location $rglocation -Force
    New-AzResourceGroup -Name $rgname2 -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname1 -Name $dfname1 -Location $dflocation -Force
        Set-AzDataFactoryV2 -ResourceGroupName $rgname2 -Name $dfname2 -Location $dflocation -Force
        $fetcheFactories = Get-AzDataFactoryV2

        Assert-NotNull $fetcheFactories
        $foundDf1 = $false
        $foundDf2 = $false
        $fetcheFactories|ForEach-Object {If ($_.DataFactoryName -eq $dfname1) {$foundDf1 = $true} Else {If ($_.DataFactoryName -eq $dfname2) {$foundDf2 = $true}}}
        Assert-True { $foundDf1 }
        Assert-True { $foundDf2 }
    }
    finally
    {
        CleanUp $rgname1 $dfname1
        CleanUp $rgname2 $dfname2
    }
}

<#
.SYNOPSIS
Negative test. Tries to get a non-existing factory.
#>
function Test-GetNonExistingDataFactory
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force
    
    Assert-ThrowsContains { Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"   
}

<#
.SYNOPSIS
Gets and updates a Data Factory global parameters object.
#>
function Test-UpdateFactoryGlobalParameters
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

        if($actual.GlobalParameters -eq $null) {
            $actual.GlobalParameters = New-Object 'system.collections.generic.dictionary[string,Microsoft.Azure.Management.DataFactory.Models.GlobalParameterSpecification]'
		}

        $actual.GlobalParameters.add("paramFromPs", @{ Type="String"; Value="String param from PS"})

        $expected = Set-AzDataFactoryV2 -InputObject $actual -Force

		ValidateFactoryProperties $expected $actual
		ValidateFactoryProperties $expected.GlobalParameters $actual.GlobalParameters

        $actual.GlobalParameters.GetEnumerator() | ForEach-Object {
            ValidateFactoryProperties $_.Value $expected.GlobalParameters[$_.Key]
        }
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a data factory and then does a Get to verify that both are identical.
#>
function Test-CreateDataFactory
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a data factory and then deletes it with -InputObject parameter.
#>
function Test-DeleteDataFactoryWithDataFactoryParameter
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    $df = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force        
    Remove-AzDataFactoryV2 -InputObject $df -Force
}

<#
.SYNOPSIS
Tests the piping support.
#>
function Test-DataFactoryPiping
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

    Get-AzDataFactoryV2 -ResourceGroupName $rgname | Remove-AzDataFactoryV2 -Force

    # Verify the data factory no longer exists
    Assert-ThrowsContains { Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"  
}

<#
.SYNOPSIS
Tests that if the DataFactoryName is specified in Get-, the ResourceGroupName also must be specified.
#>
function Test-GetFactoryByNameParameterSet
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

    Assert-ThrowsContains { Get-AzDataFactoryV2 -DataFactoryName $dfname } "ResourceGroupName"
}

<#
.SYNOPSIS
Updates a data factory and then does a Get to verify that both are identical.
#>
function Test-UpdateDataFactory
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
		Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $actual = Update-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Tag @{newTag = "NewTagValue"}
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOOSIS
Verifies factory proepties
#>
function ValidateFactoryProperties ($expected, $actual)
{
    Assert-AreEqualObjectProperties $expected $actual
}

<#
.SYNOPSIS
Creates a data factory with VSTS repo config and then does a Get to verify that both are identical.
#>
function Test-CreateDataFactoryV2WithVSTSRepoConfig
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force -AccountName  "an" -RepositoryName "rn" -CollaborationBranch "cb" -RootFolder  "rf" -LastCommitId "lci" -ProjectName "pn" 
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a data factory with VSTS repo config and then does a Get to verify that both are identical.
#>
function Test-CreateDataFactoryV2WithGitHubRepoConfig
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force -AccountName  "an" -RepositoryName "rn" -CollaborationBranch "cb" -RootFolder  "rf" -LastCommitId "lci" -HostName "hn" 
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a data factory with User assigned identity and then does a Get to verify that both are identical.
#>
function Test-CreateDataFactoryV2WithUserAssignedIdentity
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    $userAssignedIdentities = New-Object 'system.collections.generic.dictionary[string,object]'
    $userAssignedIdentities.add("/subscriptions/1e42591f-1f0c-4c5a-b7f2-a268f6105ec5/resourcegroups/ADF/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PacoTestUAMI2", @{})
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force -UserAssignedIdentity $userAssignedIdentities
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a data factory with User assigned identity and then does a Get to verify that both are identical.
#>
function Test-CreateDataFactoryV2WithCMK
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
    $encryptionVaultBaseUrl = "https://pacotestcmkkv.vault.azure.net"
    $encryptionKeyName = "PacoTestCMK"
    $encryptionKeyVersion = "b57994d085814d0f9fe2c38c2e5136fe"
    $encryptionUserAssignedIdentity = "/subscriptions/1e42591f-1f0c-4c5a-b7f2-a268f6105ec5/resourcegroups/ADF/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PAcotestUAMI"
    
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force -EncryptionVaultBaseUrl $encryptionVaultBaseUrl -EncryptionKeyName $encryptionKeyName -EncryptionKeyVersion $encryptionKeyVersion -EncryptionUserAssignedIdentity $encryptionUserAssignedIdentity
        $expected = Get-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

		ValidateFactoryProperties $expected $actual
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

