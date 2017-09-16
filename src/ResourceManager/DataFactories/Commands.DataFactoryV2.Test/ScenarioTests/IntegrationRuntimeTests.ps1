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
Create an self-hosted integration runtime and then do operations.
Delete the created integration runtime after test finishes.
#>
function Test-SelfHosted-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "selfhosted-test-integrationruntime"
        $description = "description"
   
        $actual = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id
        Assert-AreEqual $actual.Name $expected.Name

        $key = Get-AzureRmDataFactoryV2IntegrationRuntimeKey -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-NotNull $key
        Assert-NotNull $key.AuthKey1
        Assert-NotNull $key.AuthKey2

        $key = New-AzureRmDataFactoryV2IntegrationRuntimeKey -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -KeyName authKey1 `
            -Force
        Assert-NotNull $key
        Assert-NotNull $key.AuthKey1

        $metric = Get-AzureRmDataFactoryV2IntegrationRuntimeMetric -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-NotNull $metric

        $result = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Description $description `
            -Force
        Assert-AreEqual $result.Description $description

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create an managed dedicated integration runtime and then do operations.
Delete the created integration runtime after test finishes.
#>
function Test-ManagedDedicated-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "managed-dedicated-test-ir"
        $description = "Managed dedicated integration runtime"
   
        $secpasswd = ConvertTo-SecureString "Passw0rd1" -AsPlainText -Force
        $mycreds = New-Object System.Management.Automation.PSCredential("yanzhang", $secpasswd)
        $actual = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Description $description `
            -Type Managed `
            -Location 'East US' `
            -NodeSize Standard_A4_v2 `
            -NodeCount 1 `
            -CatalogServerEndpoint 'yandongtestsvr.database.windows.net' `
            -CatalogAdminCredential $mycreds `
            -CatalogPricingTier 'S1' `
            -MaxParallelExecutionsPerNode 1 `
            -Force

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        Start-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
        $status = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Stop-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create an managed elastic integration runtime and then do operations.
Delete the created integration runtime after test finishes.
#>
function Test-ManagedElastic-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "test-ManagedElastic-integrationruntime"
        $description = "ManagedElastic"
   
        $actual = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Force

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}


<#
.SYNOPSIS
Create an self-hosted integration runtime and then do piping operations.
#>
function Test-IntegrationRuntime-Piping
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $datafactory = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "test-integrationruntime-for-piping"
   
        $result = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force | Get-AzureRmDataFactoryV2IntegrationRuntime
            
        $result | Get-AzureRmDataFactoryV2IntegrationRuntime
        $result | Get-AzureRmDataFactoryV2IntegrationRuntimeKey
        $result | New-AzureRmDataFactoryV2IntegrationRuntimeKey -KeyName AuthKey1 -Force
        $result | Get-AzureRmDataFactoryV2IntegrationRuntimeMetric
        $result | Remove-AzureRmDataFactoryV2IntegrationRuntime -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}