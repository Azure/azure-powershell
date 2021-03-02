<#
.SYNOPSIS
Tests Synapse Workspace Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseWorkspace
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $storageGen2AccountName = $params.storageAccountName
    $storageFileSystemName = $params.fileSystemName
    $location = $params.location

    try
    {
        $workspaceCreated = Get-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName
    
        Assert-AreEqual $workspaceName $workspaceCreated.Name
        Assert-AreEqual $location $workspaceCreated.Location
        Assert-AreEqual "Microsoft.Synapse/Workspaces" $workspaceCreated.Type
        Assert-True {$workspaceCreated.Id -like "*$resourceGroupName*"}

        # In loop to check if workspace exists
        for ($i = 0; $i -le 60; $i++)
        {
            [array]$workspaceGet = Get-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName
            if ($workspaceGet[0].ProvisioningState -like "Succeeded")
            {
                Assert-AreEqual $workspaceName $workspaceGet[0].Name
                Assert-AreEqual $location $workspaceGet[0].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces" $workspaceGet[0].Type
                Assert-True {$workspaceCreated.Id -like "*$resourceGroupName*"}
                break
            }

            Write-Host "workspace not yet provisioned. current state: $($workspaceGet[0].ProvisioningState)"
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
            Assert-False {$i -eq 60} "Synapse Workspace is not in succeeded state even after 30 min."
        }

        # Test to make sure the Workspace does exist now
        Assert-True {Test-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName}

        # Updating Workspace
        $tagsToUpdate = @{"TestTag" = "TestUpdate"}
        $workspaceUpdated = Update-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -Tag $tagsToUpdate
    
        Assert-AreEqual $workspaceName $workspaceUpdated.Name
        Assert-AreEqual $location $workspaceUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces" $workspaceUpdated.Type
        Assert-True {$workspaceUpdated.Id -like "*$resourceGroupName*"}
    
        Assert-NotNull $workspaceUpdated.Tags "Tags do not exists"
        Assert-NotNull $workspaceUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

        # Reset SQL administrator password
        $newPassword = "Syn" + (getAssetName) + "!"
        $newPassword = ConvertTo-SecureString $params.pwd -AsPlainText -Force
        $workspaceUpdated = Update-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -SqlAdministratorLoginPassword $newPassword

        Assert-AreEqual $workspaceName $workspaceUpdated.Name
        Assert-AreEqual $location $workspaceUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces" $workspaceUpdated.Type
        Assert-True {$workspaceUpdated.Id -like "*$resourceGroupName*"}
        Assert-AreEqual "Succeeded" $workspaceUpdated.ProvisioningState

        # List all workspaces in resource group
        [array]$workspacesInResourceGroup = Get-AzSynapseWorkspace -ResourceGroupName $resourceGroupName
        Assert-True {$workspacesInResourceGroup.Count -ge 1}
    
        $found = 0
        for ($i = 0; $i -lt $workspacesInResourceGroup.Count; $i++)
        {
            if ($workspacesInResourceGroup[$i].Name -eq $workspaceName)
            {
                $found = 1
                Assert-AreEqual $location $workspacesInResourceGroup[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces" $workspacesInResourceGroup[$i].Type
                Assert-True {$workspacesInResourceGroup[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }
        Assert-True {$found -eq 1} "Workspace created earlier is not found when listing all in resource group: $resourceGroupName."

        # List all Workspaces in subscription
        [array]$workspacesInSubscription = Get-AzSynapseWorkspace
        Assert-True {$workspacesInSubscription.Count -ge 1}
        Assert-True {$workspacesInSubscription.Count -ge $workspacesInResourceGroup.Count}
    
        $found = 0
        for ($i = 0; $i -lt $workspacesInSubscription.Count; $i++)
        {
            if ($workspacesInSubscription[$i].Name -eq $workspaceName)
            {
                $found = 1
                Assert-AreEqual $location $workspacesInSubscription[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces" $workspacesInSubscription[$i].Type
                Assert-True {$workspacesInSubscription[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }
        Assert-True {$found -eq 1} "Workspace created earlier is not found when listing all in subscription."

        # Delete workspace
        Assert-True {Remove-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -PassThru -Force} "Remove Workspace failed."

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName}
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Tests Synapse Workspace SQL Active Directory Administrator
#>
function Test-SynapseWorkspaceActiveDirectoryAdministrator
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $activeDirectoryGroup = "testAADaccount"
    $activeDirectoryGroupObjectId = "41732a4a-e09e-4b18-9624-38e252d68bbf"
    $activeDirectoryUser = "Test User 2"
    $activeDirectoryUserObjectId = "e87332b2-e3ed-480a-9723-e9b3611268f8"

    try
    {
        # Set SQL Active Directory Administrator Group
        $activeDirectoryAdminGroupSet = Set-AzSynapseSqlActiveDirectoryAdministrator -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName `
		-DisplayName $activeDirectoryGroup

        Assert-AreEqual $activeDirectoryAdminGroupSet.DisplayName $activeDirectoryGroup
		Assert-AreEqual $activeDirectoryAdminGroupSet.ObjectId $activeDirectoryGroupObjectId

        # Get SQL Server Active Directory Administrator
        $activeDirectoryAdminGroupGet = Get-AzSynapseSqlActiveDirectoryAdministrator -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName

        Assert-AreEqual $activeDirectoryAdminGroupGet.DisplayName $activeDirectoryGroup
		Assert-AreEqual $activeDirectoryAdminGroupGet.ObjectId $activeDirectoryGroupObjectId

        # Set SQL Active Directory Administrator User
		$activeDirectoryAdminUser = Set-AzSynapseSqlActiveDirectoryAdministrator -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName `
		-DisplayName $activeDirectoryUser

        Assert-AreEqual $activeDirectoryAdminUser.DisplayName $activeDirectoryUser
		Assert-AreEqual $activeDirectoryAdminUser.ObjectId $activeDirectoryUserObjectId

        # Remove SQL Active Directory Administrator User
		Assert-True {Remove-AzSynapseSqlActiveDirectoryAdministrator -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -PassThru -Force}

        # Verify that SQL Active Directory Administrator was deleted
		Assert-Throws {Get-AzSynapseSqlActiveDirectoryAdministrator -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName}
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Tests Synapse Workspace Security settings.
Including SQL Auditing settings, Advanced threat protection settings and Vulnerability assessment settings.
#>
function Test-SynapseWorkspaceSecurity
{
	# Setup
	$testSuffix = getAssetName
	Create-WorkspaceTestEnvironment $testSuffix
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName
    $storageGen2AccountName = "sqlauditstorage" + (getAssetName)
    $location = $params.location

    try
    {
        $account = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageGen2AccountName -Location $location -SkuName Standard_LRS -Kind StorageV2
        
        # Set SQL Auditing
        Set-AzSynapseSqlAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -BlobStorageTargetState Enabled -StorageAccountResourceId $account.id -StorageKeyType Primary

        # Get SQL Auditing
        $auditing = Get-AzSynapseSqlAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName

        Assert-AreEqual $auditing.BlobStorageTargetState Enabled
        Assert-AreEqual $auditing.StorageAccountResourceId $account.id
        
        # Enable SQL Data Security
        $dataSecurityEnable = Enable-AzSynapseSqlAdvancedDataSecurity -WorkspaceName $workspaceName -DoNotConfigureVulnerabilityAssessment

        Assert-True {$dataSecurityEnable.IsEnabled}

        # Get SQL Data Security Policy
        $dataSecurityGet = Get-AzSynapseSqlAdvancedDataSecurityPolicy -WorkspaceName $workspaceName

        Assert-True {$dataSecurityGet.IsEnabled}

        # Set SQL Advanced threat protection
        $threatProtectionSet = Update-AzSynapseSqlAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -NotificationRecipientsEmails "mail1@mail.com;mail2@mail.com" `
        -EmailAdmins $False -ExcludedDetectionType "Sql_Injection","Unsafe_Action" -StorageAccountName $storageGen2AccountName

        Assert-AreEqual $threatProtectionSet.ThreatDetectionState Enabled
        Assert-AreEqual $threatProtectionSet.StorageAccountName $storageGen2AccountName

        # Set SQL Vulnerability assessment
        $vulnerabilityAssessmentSet = Update-AzSynapseSqlVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -StorageAccountName $storageGen2AccountName `
        -RecurringScansInterval Weekly -EmailAdmins $False -NotificationEmail "mail1@mail.com","mail2@mail.com"

        Assert-AreEqual $vulnerabilityAssessmentSet.StorageAccountName $storageGen2AccountName
        Assert-AreEqual $vulnerabilityAssessmentSet.RecurringScansInterval Weekly

        # Remove SQL Vulnerability assessment
        Assert-True {Clear-AzSynapseSqlVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -PassThru}

        # Verify that SQL Vulnerability assessment was deleted
        $vulnerabilityAssessmentGet = Get-AzSynapseSqlVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName

        Assert-AreEqual $vulnerabilityAssessmentGet.RecurringScansInterval None

        # Remove SQL Advanced threat protection
        Assert-True {Clear-AzSynapseSqlAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -PassThru}

        # Verify that SQL Advanced threat protection was deleted
        $threatProtectionGet = Get-AzSynapseSqlAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName

        Assert-AreEqual $threatProtectionGet.ThreatDetectionState Disabled

        # Disable SQL Data Security
        $dataSecurityDisable = Disable-AzSynapseSqlAdvancedDataSecurity -WorkspaceName $workspaceName

        Assert-False {$dataSecurityDisable.IsEnabled}

        # Remove SQL Auditing
        Assert-True {Remove-AzSynapseSqlAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -PassThru}

        # Verify that SQL Auditing was deleted
        $auditing = Get-AzSynapseSqlAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName

        Assert-AreEqual $auditing.BlobStorageTargetState Disabled
    }
    finally
    {
		# Cleanup
		Remove-WorkspaceTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-WorkspaceEncryptionTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "ws-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "ws" +$testSuffix;
			  storageAccountName = "wsstorage" + $testSuffix;
			  fileSystemName = "wscmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "westcentralus";
              encryptionKeyIdentifier = "<your-encryptionKeyIdentifier>";
		}
}

<#
.SYNOPSIS
Creates the basic test environment needed to perform the Sql data security tests - resource group, server and database
#>
function Create-WorkspaceEncryptionTestEnvironmentWithParams ($params, $location)
{
	New-AzResourceGroup -Name $params.rgname -Location $location
    New-AzStorageAccount -ResourceGroupName $params.rgname -Name $params.storageAccountName -Location $location -SkuName Standard_GRS -Kind StorageV2 -EnableHierarchicalNamespace $true
	$workspaceName = $params.workspaceName
	$workspaceLogin = $params.loginName
	$workspacePassword = $params.pwd
	$credentials = new-object System.Management.Automation.PSCredential($workspaceLogin, ($workspacePassword | ConvertTo-SecureString -asPlainText -Force))
    New-AzSynapseWorkspace -ResourceGroupName  $params.rgname -WorkspaceName $params.workspaceName -Location $location -SqlAdministratorLoginCredential $credentials -DefaultDataLakeStorageAccountName $params.storageAccountName -DefaultDataLakeStorageFilesystem $params.fileSystemName -EncrytionKeyIdentifier $params.encryptionKeyIdentifier
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-WorkspaceEncryptionTestEnvironment ($testSuffix)
{
	$params = Get-WorkspaceTestEnvironmentParameters $testSuffix
	Create-WorkspaceEncryptionTestEnvironmentWithParams $params $params.location
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
              location = "westcentralus";
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
