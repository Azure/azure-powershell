<#
.SYNOPSIS
Tests Synapse SqlPool Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolTestEnvironment $testSuffix
	$params = Get-SqlPoolTestEnvironmentParameters $testSuffix

    try
    {
        $resourceGroupName = $params.rgname
        $workspaceName = $params.WorkspaceName
        $location = $params.location
        $sqlPoolName = $params.sqlPoolName

        # In loop to check if SQL pool exists
        for ($i = 0; $i -le 60; $i++)
        {
            [array]$sqlPoolGet = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName
            if ($sqlPoolGet[0].ProvisioningState -like "Succeeded")
            {
                Assert-AreEqual $sqlPoolName $sqlPoolGet[0].Name
                Assert-AreEqual $location $sqlPoolGet[0].Location
                Assert-AreEqual "Microsoft.Synapse/Workspaces/sqlPools" $sqlPoolGet[0].Type
                Assert-True {$sqlPoolGet.Id -like "*$resourceGroupName*"}
                break
            }

            Write-Host "SqlPool not yet provisioned. current state: $($sqlPoolGet[0].ProvisioningState)"
            [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(30000)
            Assert-False {$i -eq 60} "Synapse SqlPool is not in succeeded state even after 30 min."
        }

        # Test to make sure the SqlPool does exist now
        Assert-True {Test-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName}

        # Updating SqlPool
        $tagsToUpdate = @{"TestTag" = "TestUpdate"}
        Update-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -Tag $tagsToUpdate
 
		# Wait for 3 minutes for the update completion
		# Without this, the test will pass non-deterministically
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(180000)
        $sqlPoolUpdated = Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $sqlPoolName $sqlPoolUpdated.Name
        Assert-AreEqual $location $sqlPoolUpdated.Location
        Assert-AreEqual "Microsoft.Synapse/workspaces/sqlPools" $sqlPoolUpdated.Type
        Assert-True {$sqlPoolUpdated.Id -like "*$resourceGroupName*"}
    
        Assert-NotNull $sqlPoolUpdated.Tags "Tags do not exists"
        Assert-NotNull $sqlPoolUpdated.Tags["TestTag"] "The updated tag 'TestTag' does not exist"

        # List all SqlPools in workspace
        [array]$sqlPoolsInWorkspace = Get-AzSynapseSqlPool -resourceGroupName $resourceGroupName -WorkspaceName $workspaceName
        Assert-True {$sqlPoolsInWorkspace.Count -ge 1}
    
        $found = 0
        for ($i = 0; $i -lt $sqlPoolsInWorkspace.Count; $i++)
        {
            if ($sqlPoolsInWorkspace[$i].Name -eq $sqlPoolName)
            {
                $found = 1
                Assert-AreEqual $location $sqlPoolsInWorkspace[$i].Location
                Assert-AreEqual "Microsoft.Synapse/workspaces/sqlPools" $sqlPoolsInWorkspace[$i].Type
                Assert-True {$sqlPoolsInWorkspace[$i].Id -like "*$resourceGroupName*"}
                break
            }
        }
        Assert-True {$found -eq 1} "SqlPool created earlier is not found when listing all in resource group: $resourceGroupName."

        # Suspend SqlPool
        $sqlPoolSuspended = Suspend-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual "Paused" $sqlPoolSuspended.Status

        # Resume SqlPool
        $sqlPoolResumed = Resume-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual "Online" $sqlPoolResumed.Status

        # Delete SqlPool
        Assert-True {Remove-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru -Force} "Remove SqlPool failed."

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseSqlPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName}
    }
    finally
    {
		# Cleanup
		Remove-SqlPoolTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Tests Synapse SQL Pool Security settings.
Including SQL Pool Auditing settings, Advanced threat protection settings, Vulnerability assessment settings and Transparent Data Encryption.
#>
function Test-SynapseSqlPool-Security
{
    param
    (
        $storageGen2AccountName = (Get-DataLakeStorageAccountName)
    )

	# Setup
	$testSuffix = getAssetName
	Create-SqlPoolTestEnvironment $testSuffix
	$params = Get-SqlPoolTestEnvironmentParameters $testSuffix

    try
    {
        $resourceGroupName = $params.rgname
        $workspaceName = $params.WorkspaceName
        $sqlPoolName = $params.sqlPoolName
        $account = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageGen2AccountName -Location $params.location -SkuName Standard_LRS -Kind StorageV2
        
        # Set SQL Pool Auditing
        Set-AzSynapseSqlPoolAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -BlobStorageTargetState Enabled -StorageAccountResourceId $account.id -StorageKeyType Primary

        # Get SQL Pool Auditing
        $auditing = Get-AzSynapseSqlPoolAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $auditing.BlobStorageTargetState Enabled
        Assert-AreEqual $auditing.StorageAccountResourceId $account.id

        # Set SQL Pool Advanced threat protection
        $threatProtectionSet = Update-AzSynapseSqlPoolAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -NotificationRecipientsEmails "mail1@mail.com;mail2@mail.com" `
        -EmailAdmins $False -ExcludedDetectionType "Sql_Injection","Unsafe_Action" -StorageAccountName $storageGen2AccountName

        Assert-AreEqual $threatProtectionSet.ThreatDetectionState Enabled
        Assert-AreEqual $threatProtectionSet.StorageAccountName $storageGen2AccountName

        # Set SQL Pool Vulnerability assessment
        $vulnerabilityAssessmentSet = Update-AzSynapseSqlPoolVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -StorageAccountName $storageGen2AccountName `
        -RecurringScansInterval Weekly -EmailAdmins $False -NotificationEmail "mail1@mail.com","mail2@mail.com"

        Assert-AreEqual $vulnerabilityAssessmentSet.StorageAccountName $storageGen2AccountName
        Assert-AreEqual $vulnerabilityAssessmentSet.RecurringScansInterval Weekly

        # Remove SQL Pool Vulnerability assessment
        Assert-True {Clear-AzSynapseSqlPoolVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru}

        # Verify that SQL Pool Vulnerability assessment was deleted
        $vulnerabilityAssessmentGet = Get-AzSynapseSqlPoolVulnerabilityAssessmentSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $vulnerabilityAssessmentGet.RecurringScansInterval None

        # Remove SQL Pool Advanced threat protection
        Assert-True {Clear-AzSynapseSqlPoolAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru}

        # Verify that SQL Pool Advanced threat protection was deleted
        $threatProtectionGet = Get-AzSynapseSqlPoolAdvancedThreatProtectionSetting -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $threatProtectionGet.ThreatDetectionState Disabled

        # Remove SQL Pool Auditing
        Assert-True {Remove-AzSynapseSqlPoolAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -PassThru}

        # Verify that SQL Pool Auditing was deleted
        $auditing = Get-AzSynapseSqlPoolAudit -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $auditing.BlobStorageTargetState Disabled

        # Set SQL Pool Transparent Data Encryption
        $tdeSet = Set-AzSynapseSqlPoolTransparentDataEncryption -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName -State Enabled

        Assert-AreEqual $tdeSet.State Enabled

        # Get SQL Pool Transparent Data Encryption
        $tdeGet = Get-AzSynapseSqlPoolTransparentDataEncryption -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $sqlPoolName

        Assert-AreEqual $tdeGet.State Enabled
    }
    finally
    {
		# Cleanup
		Remove-SqlPoolTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlPoolTestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlPoolTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "sqlws" +$testSuffix;
			  sqlPoolName = "sqlpool" + $testSuffix;
			  storageAccountName = "sqlstorage" + $testSuffix;
			  fileSystemName = "sqlcmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
			  perfLevel = 'DW200c';
              location = "westcentralus";
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-SqlPoolTestEnvironment ($testSuffix)
{
	$params = Get-SqlPoolTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}