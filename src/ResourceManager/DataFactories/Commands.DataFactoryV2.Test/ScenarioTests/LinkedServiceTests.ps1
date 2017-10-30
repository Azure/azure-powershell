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
Creates a linked service and then does a Get to compare the results.
Delete sthe created linked service at the end.
#>
function Test-LinkedService
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsname = "foo"
        $expected = Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname -File .\Resources\linkedService.json -Force
        $actual = Get-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname

        Verify-AdfSubResource $expected $actual $rgname $dfname $lsname

        Remove-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a dataset and the linked service which it depends on. Then does a Get with resource id parameter to compare the results.
Deletes the created dataset with resource id parameter at the end.
#>
function Test-LinkedServiceWithResourceId
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

        $linkedServicename = "foo1"
        $expected = Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $linkedServicename -Force
        $actual = Get-AzureRmDataFactoryV2LinkedService -ResourceId $expected.Id

        Verify-AdfSubResource $expected $actual $rgname $dfname $linkedServicename

        Remove-AzureRmDataFactoryV2LinkedService -ResourceId $expected.Id -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a linked service and then does a Get to compare the results.
Deletes the created linked service at the end.
Uses -DataFactory parameter if available in cmdlet.
#>
function Test-LinkedServiceWithDataFactoryParameter
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsname = "foo"
        $expected = Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DatafactoryName $dfname -Name $lsname -File .\Resources\linkedService.json -Force
        $actual = Get-AzureRmDataFactoryV2LinkedService -DataFactory $df -Name $lsname

        Verify-AdfSubResource $expected $actual $rgname $dfname $lsname

        Remove-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DatafactoryName $dfname -Name $lsname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Tests the piping support.
#>
function Test-LinkedServicePiping
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsname = "foo"
   
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname -File .\Resources\linkedService.json -Force
        
        Get-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname | Remove-AzureRmDataFactoryV2LinkedService -Force
                
        # Test the linked service no longer exists
        Assert-ThrowsContains { Get-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname } "NotFound"
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
