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
        $actual = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force
        Assert-AreEqual $actual.Name $irname

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id
        Assert-AreEqual $actual.Name $expected.Name

        $status = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Assert-NotNull $status

        $metric = Get-AzureRmDataFactoryV2IntegrationRuntimeMetric -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-NotNull $metric

        $description = "description"
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
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a SSIS-Azure integration runtime and then does operations.
Deletes the created integration runtime at the end.

To record this test,
1. Prepare a Azure SQL Server, which will be used to create SSISDB during provisionning the SSIS-IR.
2. If you are using a existing Azure SQL Server, make sure there is no existed database with name 'SSISDB'.
3. Configure the Azure SQL Server with either way below:
    a. Set following environment variables:
        CatalogServerEndpoint: The catalog server endpoint for catalog database (SSISDB)
        CatalogAdminUsername: The admin user name on this server
        CatalogAdminPassword: The password of the admin user.
    b. Set the variables directly in script.

NOTE: this test will be running for 25 minutes to finish the SSIS-IR provision.
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
        $catalogServerEndpoint = $Env:CatalogServerEndpoint
        $catalogAdminUsername = $Env:CatalogAdminUsername
        $catalogAdminPassword = $Env:CatalogAdminPassword

        if ($catalogServerEndpoint -eq $null){
            $catalogServerEndpoint = 'fakeserver'
        }

        if ($catalogAdminUsername -eq $null){
            $catalogAdminUsername = 'fakeuser'
        }

        if ($catalogAdminPassword -eq $null){
		    <#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Fake password to resource that has been deleted.")]#>
            $catalogAdminPassword = 'fakepassord'
        }

        $secpasswd = ConvertTo-SecureString $catalogAdminPassword -AsPlainText -Force
        $mycreds = New-Object System.Management.Automation.PSCredential($catalogAdminUsername, $secpasswd)

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
            -CatalogPricingTier 'Basic' `
            -MaxParallelExecutionsPerNode 1 `
            -LicenseType LicenseIncluded `
            -Edition Enterprise `
            -Force

        $expected = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        Start-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
        $status = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Stop-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force

        Wait-Seconds 15
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

<#
.SYNOPSIS
Creates a self-hosted integration runtime and shares it with another data factory and does operations.
Deletes the created integration runtime at the end.
#>
function Test-Shared-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $linkeddfname = $dfname + '-linked'
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
     
        $linkeddf = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname `
            -Name $linkeddfname `
            -Location $dflocation `
            -Force

        Wait-Seconds 10
        
        $irname = "selfhosted-test-integrationruntime"
        $description = "description"
   
        $shared = Set-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force

        New-AzureRMRoleAssignmentWithId `
            -ObjectId $linkeddf.Identity.PrincipalId `
            -RoleDefinitionId 'b24988ac-6180-42a0-ab88-20f7382dd24c' `
            -Scope $shared.Id `
            -RoleAssignmentId 6558f9a7-689c-41d3-93bd-3281fbe3d26f

        Wait-Seconds 20

        $linkedIrName = 'LinkedIntegrationRuntime'
        $linked = Set-AzureRmDataFactoryV2IntegrationRuntime `
            -ResourceGroupName $rgname `
            -DataFactoryName $linkeddfname `
            -Name $linkedIrName `
            -Type SelfHosted `
            -Description 'This is a linked integration runtime' `
            -SharedIntegrationRuntimeResourceId $shared.Id `
            -Force

        $metric = Get-AzureRmDataFactoryV2IntegrationRuntimeMetric -ResourceGroupName $rgname `
            -DataFactoryName $linkeddfname `
            -Name $linkedIrName
        Assert-NotNull $metric

        $status = Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $linked.Id -Status
        Assert-NotNull $status

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $shared.Id -LinkedDataFactoryName $linkeddfname -Force

        Remove-AzureRmRoleAssignment `
            -ObjectId $linkeddf.Identity.PrincipalId `
            -RoleDefinitionId 'b24988ac-6180-42a0-ab88-20f7382dd24c' `
            -Scope $shared.Id

        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $linked.Id -Force
        Remove-AzureRmDataFactoryV2IntegrationRuntime -ResourceId $shared.Id -Force

        Remove-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $linkeddfname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
