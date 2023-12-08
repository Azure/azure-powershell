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
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "selfhosted-test-integrationruntime"   
        $actual = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force
        Assert-AreEqual $actual.Name $irname

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id
        Assert-AreEqual $actual.Name $expected.Name

        $status = Get-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Assert-NotNull $status

        $metric = Get-AzDataFactoryV2IntegrationRuntimeMetric -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-NotNull $metric

        $description = "description"
        $result = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Description $description `
            -Force
        Assert-AreEqual $result.Description $description

        $status = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Status
        Assert-NotNull $status.LatestVersion

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
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
1. Prepare a Azure SQL Server, which will be used to create SSISDB during provisionning the SSIS-IR. Besides, Prepare an ARM VNet
   and two public IPs (which should be in standard SKU and should have DNS names) in the same subscription and region as the SSIS-IR.
2. If you are using a existing Azure SQL Server, make sure there is no existed database with name 'SSISDB'.
3. Configure the Azure SQL Server and the network resources with either way below:
    a. Set following environment variables:
        CatalogServerEndpoint: The catalog server endpoint for catalog database (SSISDB)
        CatalogAdminUsername: The admin user name on this server
        CatalogAdminPassword: The password of the admin user.
        VnetId: The resource id of the vnet.
        FirstPublicIpId: The resource id of the first public IP address.
        SecondPublicIpId: The resource id of the second public IP address.
    b. Set the variables directly in script.

NOTE: this test will be running for 25 minutes to finish the SSIS-IR provision.
#>
function Test-SsisAzure-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force

        # Prepare proxy selfhsoted IR
        $proxyIrName = "proxy-selfhosted-integrationruntime"   
        $actualProxyIr = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $proxyIrName `
            -Type 'SelfHosted' `
            -Force
        Assert-AreEqual $actualProxyIr.Name $proxyIrName

        # Prepare proxy linked service
        $lsname = "proxy-linkedservice"
        $actualProxyLs = Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname -File .\Resources\linkedService.json -Force
        Assert-AreEqual $actualProxyLs.Name $lsname

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

		# Prepare express custom setup
		# Create setup for cmdkey
		$targetName = 'fakeserver'
		$userName = 'fakeuser'
		$password = New-Object Microsoft.Azure.Management.DataFactory.Models.SecureString('fakepassword')
		$setup1 = New-Object Microsoft.Azure.Management.DataFactory.Models.CmdkeySetup($targetName, $userName, $password)

		# Create setup for environment variable
		$variableName = 'name'
		$variableValue = 'value'
		$setup2 = New-Object Microsoft.Azure.Management.DataFactory.Models.EnvironmentVariableSetup($variableName, $variableValue)

		# Create setup for 3rd party component without license Key
		$componentName1 = 'componentName1'
		$setup3 = New-Object Microsoft.Azure.Management.DataFactory.Models.ComponentSetup($componentName1)

		# Create setup for 3rd party component with license Key
		$componentName2 = 'componentName2'
		$licenseKey = New-Object Microsoft.Azure.Management.DataFactory.Models.SecureString('fakelicensekey')
		$setup4 = New-Object Microsoft.Azure.Management.DataFactory.Models.ComponentSetup($componentName2, $licenseKey)

        # Create setup for Azure PowerShell
        $version = '4.5.0'
        $setup5 = New-Object Microsoft.Azure.Management.DataFactory.Models.AzPowerShellSetup($version)

        $setups = New-Object System.Collections.ArrayList
        $setups.Add($setup1)
        $setups.Add($setup2)
        # Disable these two setup as it cannot be faked and the other two have already covered the function test
        # $setups.Add($setup3)
        # $setups.Add($setup4)
        $setups.Add($setup5)

        # Replace following variables with network resource ids
        $vnetId = $Env:VnetId
        $firstPublicIpId = $Env:FirstPublicIpId
        $secondPublicIpId = $Env:SecondPublicIpId
        
        if ($vnetId -eq $null){
            $vnetId = 'fakeid'
        }

        if ($firstPublicIpId -eq $null){
            $firstPublicIpId = 'fakeid'
        }

        if ($secondPublicIpId -eq $null){
            $secondPublicIpId = 'fakeid'
        }

        $actual = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
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
            -DataProxyIntegrationRuntimeName $proxyIrName `
            -DataProxyStagingLinkedServiceName $lsname `
            -ExpressCustomSetup $setups `
            -VNetId $vnetId `
            -Subnet "default" `
            -PublicIPs @($firstPublicIpId, $secondPublicIpId) `
            -Force

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        Get-AzDataFactoryV2IntegrationRuntimeOutboundNetworkDependenciesEndpoint -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname

        Start-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force
        $status = Get-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status
        Stop-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Force

        Wait-Seconds 15
        Remove-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force

        Remove-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -Name $lsname -Force

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceId $actualProxyIr.Id -Force
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
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force

        $irname = "test-ManagedElastic-integrationruntime"
        $description = "ManagedElastic"

        $actual = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Force

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        Get-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates an azure integration runtime with subnetId.
Deletes the created integration runtime at the end.

To record this test, please prepare a subnet, to which the Azure SSIS IR could join.
#>
function Test-Azure-IntegrationRuntime-SubnetId
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force

        $irname = "test-Azure-SSIS-IR-subnetId"
        $description = "Managed SSIS IR"

        # Get SubnetId from environment variable.
        $IsSubnetIdSet = Test-Path env:SSIS_IR_SUBNETID
        if ($IsSubnetIdSet) {
            $subnetId = $Env:SSIS_IR_SUBNETID
        } else {
            $subnetId = "fakeId"
        }

        $actual = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Location $dflocation `
            -NodeSize Standard_A4_v2 `
            -NodeCount 1 `
            -MaxParallelExecutionsPerNode 1 `
            -Edition standard `
            -subnetId $subnetId `
            -Force

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        if ($IsSubnetIdSet) {
            Assert-AreEqual $subnetId $expected.SubnetId
        }
        Get-AzDataFactoryV2IntegrationRuntime -ResourceId $actual.Id -Status

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a express azure integration runtime with subnetId.
Deletes the created integration runtime at the end.

To record this test, please prepare a subnet, to which the Azure SSIS IR could join.
#>
function Test-Azure-Express-IntegrationRuntime
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force

        $irname = "test-Azure-Express-SSIS-IR"
        $description = "Managed SSIS IR"
        $VNetInjectionMethod = "Express"

        # Get SubnetId from environment variable.
        $IsSubnetIdSet = Test-Path env:SSIS_IR_SUBNETID
        if ($IsSubnetIdSet) {
            $subnetId = $Env:SSIS_IR_SUBNETID
        } else {
            $subnetId = "fakeId"
        }

        $actual = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Location $dflocation `
            -NodeSize Standard_A4_v2 `
            -NodeCount 1 `
            -MaxParallelExecutionsPerNode 1 `
            -Edition standard `
            -subnetId $subnetId `
            -VNetInjectionMethod $VNetInjectionMethod `
            -Force

        $expected = Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        if ($IsSubnetIdSet) {
            Assert-AreEqual $subnetId $expected.SubnetId
        }

        Assert-AreEqual $expected.VNetInjectionMethod $VNetInjectionMethod

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname -DataFactoryName $dfname -Name $irname -Force
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
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $datafactory = Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $irname = "test-integrationruntime-for-piping"
   
        $result = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force | Get-AzDataFactoryV2IntegrationRuntime
            
        $result | Get-AzDataFactoryV2IntegrationRuntime
        $result | Get-AzDataFactoryV2IntegrationRuntimeKey
        $result | New-AzDataFactoryV2IntegrationRuntimeKey -KeyName AuthKey1 -Force
        $result | Get-AzDataFactoryV2IntegrationRuntimeMetric
        $result | Remove-AzDataFactoryV2IntegrationRuntime -Force
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
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $dfname `
            -Location $dflocation `
            -Force
     
        $linkeddf = Set-AzDataFactoryV2 -ResourceGroupName $rgname `
            -Name $linkeddfname `
            -Location $dflocation `
            -Force

        Wait-Seconds 10
        
        $irname = "selfhosted-test-integrationruntime"
        $description = "description"
   
        $shared = Set-AzDataFactoryV2IntegrationRuntime -ResourceGroupName $rgname `
            -DataFactoryName $dfname `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force

        New-AzRoleAssignmentWithId `
            -ObjectId $linkeddf.Identity.PrincipalId `
            -RoleDefinitionId 'b24988ac-6180-42a0-ab88-20f7382dd24c' `
            -Scope $shared.Id `
            -RoleAssignmentId 6558f9a7-689c-41d3-93bd-3281fbe3d26f

        Wait-Seconds 20

        $linkedIrName = 'LinkedIntegrationRuntime'
        $linked = Set-AzDataFactoryV2IntegrationRuntime `
            -ResourceGroupName $rgname `
            -DataFactoryName $linkeddfname `
            -Name $linkedIrName `
            -Type SelfHosted `
            -Description 'This is a linked integration runtime' `
            -SharedIntegrationRuntimeResourceId $shared.Id `
            -Force

        $metric = Get-AzDataFactoryV2IntegrationRuntimeMetric -ResourceGroupName $rgname `
            -DataFactoryName $linkeddfname `
            -Name $linkedIrName
        Assert-NotNull $metric

        $status = Get-AzDataFactoryV2IntegrationRuntime -ResourceId $linked.Id -Status
        Assert-NotNull $status

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceId $shared.Id -LinkedDataFactoryName $linkeddfname -Force

        Remove-AzRoleAssignment `
            -ObjectId $linkeddf.Identity.PrincipalId `
            -RoleDefinitionId 'b24988ac-6180-42a0-ab88-20f7382dd24c' `
            -Scope $shared.Id

        Remove-AzDataFactoryV2IntegrationRuntime -ResourceId $linked.Id -Force
        Remove-AzDataFactoryV2IntegrationRuntime -ResourceId $shared.Id -Force

        Remove-AzDataFactoryV2 -ResourceGroupName $rgname -Name $linkeddfname -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
