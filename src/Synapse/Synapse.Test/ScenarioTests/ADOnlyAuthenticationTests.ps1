<#
.SYNOPSIS
Tests Synapse Active Directory only authentication (enable,disable).
#>
function Test-DisableSynapseADOnlyAuthentication
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix   

	$resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName

	try
	{
		$disabledADOnlyAuthentication = Disable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName		
		# Wait for 10 seconds for the completion
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(10000)
		$disabledAuthenticationProperty = $disabledADOnlyAuthentication.AzureADOnlyAuthenticationProperty

		Assert-NotNull {$disabledAuthenticationProperty}
		Assert-AreEqual $False $disabledAuthenticationProperty

		$getADOnlyAuthentication = Get-AzSynapseActiveDirectoryOnlyAuthentication -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName
		$acquiredAuthenticationProperty = $getADOnlyAuthentication.AzureADOnlyAuthenticationProperty

		Assert-NotNull {$acquiredAuthenticationProperty}
		Assert-AreEqual $False $acquiredAuthenticationProperty

		Assert-AreEqual $disabledAuthenticationProperty $acquiredAuthenticationProperty
	}
	finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

function Test-EnableSynapseADOnlyAuthentication
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
   
	$resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName

	try
	{
		$enabledADOnlyAuthentication = Enable-AzSynapseActiveDirectoryOnlyAuthentication -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName		
		# Wait for 10 seconds for the completion
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(10000)
		$enabledAuthenticationProperty = $enabledADOnlyAuthentication.AzureADOnlyAuthenticationProperty

		Assert-NotNull {$enabledADOnlyAuthentication}
		Assert-AreEqual $True $enabledAuthenticationProperty

		$getADOnlyAuthentication = Get-AzSynapseActiveDirectoryOnlyAuthentication -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName
		$acquiredAuthenticationProperty = $getADOnlyAuthentication.AzureADOnlyAuthenticationProperty

		Assert-NotNull {$acquiredAuthenticationProperty}
		Assert-AreEqual $True $acquiredAuthenticationProperty

		Assert-AreEqual $enabledAuthenticationProperty $acquiredAuthenticationProperty
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
	Create-WorkspaceTestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-WorkspaceTestEnvironmentWithParams ($params, $location, $denyAsNetworkRuleDefaultAction = $False)
{
	New-AzResourceGroup -Name $params.rgname -Location $location
    New-AzStorageAccount -ResourceGroupName $params.rgname -Name $params.storageAccountName -Location $location -SkuName Standard_GRS -Kind StorageV2 -EnableHierarchicalNamespace $true
	$workspaceName = $params.workspaceName
	$workspaceLogin = $params.loginName
	$workspacePassword = $params.pwd
	$credentials = new-object System.Management.Automation.PSCredential($workspaceLogin, ($workspacePassword | ConvertTo-SecureString -asPlainText -Force))
    New-AzSynapseWorkspace -ResourceGroupName  $params.rgname -WorkspaceName $params.workspaceName -Location $location -SqlAdministratorLoginCredential $credentials -DefaultDataLakeStorageAccountName $params.storageAccountName -DefaultDataLakeStorageFilesystem $params.fileSystemName -ManagedResourceGroupName $params.managedresourcegroupName
	Wait-Seconds 10
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-WorkspaceTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "adonly-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "adonly-ws" +$testSuffix;
              managedresourcegroupName = "mrg" + $testSuffix;
			  storageAccountName = "wsstorage" + $testSuffix;
			  fileSystemName = "wscmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "eastus2euap";
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