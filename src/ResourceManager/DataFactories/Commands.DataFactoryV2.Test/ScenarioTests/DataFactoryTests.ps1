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
Nagative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingDataFactory
{	
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force
    
    # Test
    Assert-ThrowsContains { Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"   
}

<#
.SYNOPSIS
Create a data factory and then do a Get to compare the result are identical.
The datafactory will be removed when the test finishes.
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
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a data factory and then delete it with -DataFactory parameter.
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
Test piping support.
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

    # Test the data factory no longer exists
    Assert-ThrowsContains { Get-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname } "NotFound"  
}