﻿<#
.SYNOPSIS
Tests Synapse Workspace Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseWorkspace
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $storageGen2AccountName = (Get-DataLakeStorageAccountName),
        $storageFileSystemName = (getAssetName),
        $location = "North Europe"
    )

    try
    {
        # Creating Workspace and initial setup
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # Test to make sure the Workspace doesn't exist
        Assert-False {Test-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName}

        New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageGen2AccountName -Location $location -SkuName Standard_GRS -Kind StorageV2 -EnableHierarchicalNamespace $true
        $password = "Syn" + (getAssetName) + "!"
        $password = ConvertTo-SecureString $password -AsPlainText -Force
        $creds = New-Object System.Management.Automation.PSCredential ("psuser", $password)
        $workspaceCreated = New-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -Location $location -DefaultDataLakeStorageAccountName $storageGen2AccountName -DefaultDataLakeStorageFilesystem $storageFileSystemName -SqlAdministratorLoginCredential $creds
    
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
        $newPassword = ConvertTo-SecureString $password -AsPlainText -Force
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
        Assert-True {Remove-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -PassThru} "Remove Workspace failed."

        # Verify that it is gone by trying to get it again
        Assert-Throws {Get-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName}
    }
    finally
    {
        # cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
        Invoke-HandledCmdlet -Command {Remove-AzSynapseWorkspace -ResourceGroupName $resourceGroupName -Name $workspaceName -ErrorAction SilentlyContinue} -IgnoreFailures
        Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue} -IgnoreFailures
    }
}