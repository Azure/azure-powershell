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
Create a dataset and the linked service which it depends on. Then do a Get to compare the result are identical.
Delete the created dataset after test finishes.
#>
function Test-Table
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzureRmDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        New-AzureRmDataFactoryLinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Force
   
        $datasetname = "foo2"
        $actual = New-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -File .\Resources\dataset.json -Force
        $expected = Get-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.DatasetName $actual.DatasetName

        Remove-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a dataset and the linked service which it depends on. Then do a Get to compare the result are identical.
Delete the created dataset after test finishes.
Use -DataFactory parameter in all cmdlets.
#>
function Test-TableWithDataFactoryParameter
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = New-AzureRmDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        New-AzureRmDataFactoryLinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Force
   
        $datasetname = "foo2"
        $actual = New-AzureRmDataFactoryDataset -DataFactory $df -Name $datasetname -File .\Resources\dataset.json -Force
        $expected = Get-AzureRmDataFactoryDataset -DataFactory $df -Name $datasetname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.DatasetName $actual.DatasetName

        Remove-AzureRmDataFactoryDataset -DataFactory $df -Name $datasetname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Test piping support.
#>
function Test-TablePiping
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzureRmDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        New-AzureRmDataFactoryLinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Force
   
        $datasetname = "foo2"
        New-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname -File .\Resources\dataset.json -Force
        
        Get-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname | Remove-AzureRmDataFactoryDataset -Force

        # Test the dataset no longer exists
		# TODO bgold09: change expected error message to "DatasetNotFound" after service error messages have been updated
        Assert-ThrowsContains { Get-AzureRmDataFactoryDataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name $datasetname } "TableNotFound"
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}