﻿# ----------------------------------------------------------------------------------
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
Creates a self-hosted integration runtime and then does operations.
Deletes the created integration runtime at the end.
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

        $linkedIrName = 'LinkedIntegrationRuntime'
        $authKeys = Get-AzureRmDataFactoryV2IntegrationRuntimeKey -InputObject $actual
        $authKey = ConvertTo-SecureString $authKeys.AuthKey1 -AsPlainText -Force
        $actualShared = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $linkedIrName `
            -Type 'SelfHosted' `
            -AuthKey $authKey `
            -Force
        Assert-AreEqual $actualShared.Name $linkedIrName

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actualShared.Id -Force
        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a SSIS-Azure integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-SsisAzure-IntegrationRuntime
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
     
        $irname = "ssis-azure-ir"
        $description = "SSIS-Azure integration runtime"

        # Replace the following three variables to real values in record mode
        $catalogServerEndpoint = 'fakeserver'
        $catalogAdminUsername = 'fakeuser'
        $catalogAdminPassword = 'fakepassord'

        $secpasswd = ConvertTo-SecureString $catalogAdminPassword -AsPlainText -Force
        $mycreds = New-Object System.Management.Automation.PSCredential($catalogAdminUsername, $secpasswd)
        $sasuri = "https://ssisazurefileshare.blob.core.windows.net/privatepreview?st=2018-02-04T05%3A08%3A00Z&se=2020-02-05T05%3A08%3A00Z&sp=rwl&sv=2017-04-17&sr=c&sig=*******"
   
        $actual = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Description $description `
            -Type Managed `
            -Location 'East US' `
            -NodeSize Standard_A4_v2 `
            -NodeCount 1 `
            -CatalogServerEndpoint $catalogServerEndpoint `
            -CatalogAdminCredential $mycreds `
            -CatalogPricingTier 'S1' `
            -MaxParallelExecutionsPerNode 1 `
            -LicenseType LicenseIncluded `
            -Edition Enterprise `
            -SetupScriptContainerSasUri $sasuri `
            -Force

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        Start-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
        $status = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Stop-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force

        Start-Sleep -Seconds 15
        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates an azure integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-Azure-IntegrationRuntime
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
        CleanUp $rgname $dfname
    }
}


<#
.SYNOPSIS
Creates a self-hosted integration runtime and then does piping operations.
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
        CleanUp $rgname $dfname
    }
}