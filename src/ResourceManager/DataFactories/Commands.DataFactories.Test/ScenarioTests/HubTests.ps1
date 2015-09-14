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
Create a hub and then do a Get to compare the results are identical.
Delete the created hub after the test finishes.
#>
function Test-Hub
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRMResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzureRMDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $hubname = "SampleHub"
   
        $actual = New-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname -File .\Resources\hub.json -Force
        $expected = Get-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.HubName $actual.HubName

        Remove-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a hub and then do a Get to compare the results are identical.
Delete the created hub after the test finishes.
Use -DataFactory parameter in all cmdlets.
#>
function Test-HubWithDataFactoryParameter
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRMResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = New-AzureRMDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $hubname = "SampleHub"
   
        $actual = New-AzureRMDataFactoryHub -DataFactory $df -Name $hubname -File .\Resources\hub.json -Force
        $expected = Get-AzureRMDataFactoryHub -DataFactory $df -Name $hubname

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.HubName $actual.HubName

        Remove-AzureRMDataFactoryHub -DataFactory $df -Name $hubname -Force
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
function Test-HubPiping
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRMResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        New-AzureRMDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $hubname = "SampleHub"
   
        New-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname -File .\Resources\hub.json -Force
        
        Get-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname | Remove-AzureRMDataFactoryHub -Force

        # Test the hub no longer exists
        Assert-ThrowsContains { Get-AzureRMDataFactoryHub -ResourceGroupName $rgname -DataFactoryName $dfname -Name $hubname } "HubNotFound"
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}