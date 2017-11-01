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
Creates a dataset and the linked service which it depends on. Then does a Get to compare the results.
#>
function Test-Dataset
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $linkedServicename = "foo1"
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $linkedServicename -Force
   
        $datasetname = "foo2"
        $expected = Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -File .\Resources\dataset.json -Force
        $actual = Get-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname

        Verify-AdfSubResource $expected $actual $rgname $dfname $datasetname

        Remove-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a dataset and the linked service which it depends on.
Then does a Get using the resource id, compares the results, and then deletes the dataset using the resource id.
#>
function Test-DatasetWithResourceId
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
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $linkedServicename -Force
   
        $dsname = "foo2"
        $expected = Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $dsname -File .\Resources\dataset.json -Force
        $actual = Get-AzureRmDataFactoryV2Dataset -ResourceId $expected.Id

        Verify-AdfSubResource $expected $actual $rgname $dfname $dsname

        Remove-AzureRmDataFactoryV2Dataset -ResourceId $expected.Id -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a dataset and the linked service which it depends on. Then does a Get to compare the results, and then deletes the created dataset.
Uses -DataFactory parameter if available in cmdlet.
#>
function Test-DatasetWithDataFactoryParameter
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
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $linkedServicename -Force
   
        $datasetname = "foo2"
        $actual = Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -File .\Resources\dataset.json -Force
        $expected = Get-AzureRmDataFactoryV2Dataset -DataFactory $df -Name $datasetname

        Verify-AdfSubResource $expected $actual $rgname $dfname $datasetname

        Remove-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -Force
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
function Test-DatasetPiping
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        $linkedServicename = "foo1"
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $linkedServicename -Force
   
        $datasetname = "foo2"
        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -File .\Resources\dataset.json -Force
        
        Get-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname | Remove-AzureRmDataFactoryV2Dataset -Force

        # Test the dataset no longer exists
        Assert-ThrowsContains { Get-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname } "NotFound"
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
