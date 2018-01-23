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
    
    New-AzureRmResourceGroup -Name $rgname1 -Location $rglocation -Force
    New-AzureRmResourceGroup -Name $rgname2 -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname1 -Name $dfname1 -Location $dflocation -Force
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname2 -Name $dfname2 -Location $dflocation -Force
        $fetcheFactories = Get-AzureRmDataFactoryV2

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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force
    
    Assert-ThrowsContains { Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"   
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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $actual = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $expected = Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.DataFactoryId $actual.DataFactoryId
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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    $df = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force        
    Remove-AzureRmDataFactoryV2 -InputObject $df -Force
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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

    Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname | Remove-AzureRmDataFactoryV2 -Force

    # Verify the data factory no longer exists
    Assert-ThrowsContains { Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"  
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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

    Assert-ThrowsContains { Get-AzureRmDataFactoryV2 -DataFactoryName $dfname } "ResourceGroupName"
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
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
		Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $actual = Update-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Tag @{newTag = "NewTagValue"}
        $expected = Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.DataFactoryId $actual.DataFactoryId
        Assert-AreEqual $expected.Tag $actual.Tag
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

