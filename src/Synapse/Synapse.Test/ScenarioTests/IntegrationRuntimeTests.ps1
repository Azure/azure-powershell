<#
.SYNOPSIS
Creates a self-hosted integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-SelfHosted-IntegrationRuntime
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $irname = "selfhosted-test-integrationruntime"

    try
    {
        $actual = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force
        Assert-AreEqual $actual.Name $irname

        $expected = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        $expected = Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id
        Assert-AreEqual $actual.Name $expected.Name

        $status = Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Status
        Assert-NotNull $status

        $metric = Get-AzSynapseIntegrationRuntimeMetric -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-NotNull $metric

        $description = "description"
        $result = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Description $description `
            -Force
        Assert-AreEqual $result.Description $description

        $status = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Status
        Assert-NotNull $status.LatestVersion

        Remove-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Force
	}
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates an azure integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-Azure-IntegrationRuntime
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $irname = "test-ManagedElastic-integrationruntime"

    try
    {
        $description = "ManagedElastic"
   
        $actual = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Force

        $expected = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Status

        Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname -Force
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates a self-hosted integration runtime and then does piping operations.
#>
function Test-IntegrationRuntime-Piping
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $irname = "test-integrationruntime-for-piping"

    try
    {
        $result = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force 
            
        $result | Get-AzSynapseIntegrationRuntime
        $result | Get-AzSynapseIntegrationRuntimeKey
        $result | New-AzSynapseIntegrationRuntimeKey -KeyName AuthKey1 -Force
        $result | Get-AzSynapseIntegrationRuntimeMetric
        $result | Remove-AzSynapseIntegrationRuntime -Force
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates an azure SSIS integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-AzureSSIS-IntegrationRuntime
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $irname = "test-SSIS-integrationruntime"
	$location = $params.location
	$AzureSSISNodeSize = "Standard_D8_v3"
	$AzureSSISNodeNumber = 2
	$AzureSSISEdition = "Standard"
	$AzureSSISLicenseType = "LicenseIncluded"
	$AzureSSISMaxParallelExecutionsPerNode = 4

    try
    {
        $description = "Start/stop SSIS"
		$SSISIR = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
		-WorkspaceName $workspaceName `
		-Name $irname `
		-Description $description `
		-Type Managed `
		-Location $location `
		-NodeSize $AzureSSISNodeSize `
		-NodeCount $AzureSSISNodeNumber `
		-Edition $AzureSSISEdition `
		-LicenseType $AzureSSISLicenseType `
		-MaxParallelExecutionsPerNode $AzureSSISMaxParallelExecutionsPerNode `
		-Force
   
        $result = ($SSISIR | Start-AzSynapseIntegrationRuntime -Force)
        Assert-AreEqual $result.State 'Started'
		$SSISIR | Stop-AzSynapseIntegrationRuntime -Force

        Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname -Force
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-WorkspaceTestEnvironment ($testSuffix)
{
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-WorkspaceTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "ws-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "ws" +$testSuffix;
			  storageAccountName = "wsstorage" + $testSuffix;
			  fileSystemName = "wscmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "eastus";
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-WorkspaceTestEnvironment ($testSuffix)
{
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}