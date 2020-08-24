---
Module Name: Az.Migrate
Module Guid: 52dd74b5-1c0f-469a-942e-508eb7375c81
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.migrate
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Migrate Module
## Description
Microsoft Azure PowerShell: Migrate cmdlets

## Az.Migrate Cmdlets
### [Clear-AzMigrateReplicationFabric](Clear-AzMigrateReplicationFabric.md)
The operation to purge(force delete) an Azure Site Recovery fabric.

### [Get-AzMigrateMigrationRecoveryPoint](Get-AzMigrateMigrationRecoveryPoint.md)
Gets a recovery point for a migration item.

### [Get-AzMigrateRecoveryPoint](Get-AzMigrateRecoveryPoint.md)
Get the details of specified recovery point.

### [Get-AzMigrateReplicationJob](Get-AzMigrateReplicationJob.md)
Get the details of an Azure Site Recovery job.

### [Get-AzMigrateReplicationProtectableItem](Get-AzMigrateReplicationProtectableItem.md)
The operation to get the details of a protectable item.

### [Initialize-AzMigrateReplicationInfrastructure](Initialize-AzMigrateReplicationInfrastructure.md)
# TODO PLEASE FIX BEFORE RELEASE
Create a deployment in the specified subscription and resource group.
This has to be done only once, before enabling replication for first 
VmWare virtual machine.
Initialize-AzMigrateReplicationInfrastructure -ProjectName a -ResourceGroupName b -SubscriptionId c -Vmwareagentless

### [Move-AzMigrateReplicationFabricGateway](Move-AzMigrateReplicationFabricGateway.md)
The operation to move replications from a process server to another process server.

### [Move-AzMigrateReplicationFabricToAad](Move-AzMigrateReplicationFabricToAad.md)
The operation to migrate an Azure Site Recovery fabric to AAD.

### [Move-AzMigrateReplicationMigrationItem](Move-AzMigrateReplicationMigrationItem.md)
The operation to initiate migration of the item.

### [New-AzMigrateReplicationFabric](New-AzMigrateReplicationFabric.md)
The operation to create an Azure Site Recovery fabric (for e.g.
Hyper-V site)

### [New-AzMigrateReplicationMigrationItem](New-AzMigrateReplicationMigrationItem.md)
The operation to create an ASR migration item (enable migration).

### [New-AzMigrateReplicationPolicy](New-AzMigrateReplicationPolicy.md)
The operation to create a replication policy

### [New-AzMigrateReplicationProtectionContainer](New-AzMigrateReplicationProtectionContainer.md)
Operation to create a protection container.

### [Remove-AzMigrateReplicationFabric](Remove-AzMigrateReplicationFabric.md)
The operation to delete or remove an Azure Site Recovery fabric.

### [Remove-AzMigrateReplicationMigrationItem](Remove-AzMigrateReplicationMigrationItem.md)
The operation to delete an ASR migration item.

### [Remove-AzMigrateReplicationPolicy](Remove-AzMigrateReplicationPolicy.md)
The operation to delete a replication policy.

### [Remove-AzMigrateReplicationProtectionContainer](Remove-AzMigrateReplicationProtectionContainer.md)
Operation to remove a protection container.

### [Restart-AzMigrateReplicationJob](Restart-AzMigrateReplicationJob.md)
The operation to restart an Azure Site Recovery job.

### [Resume-AzMigrateReplicationJob](Resume-AzMigrateReplicationJob.md)
The operation to resume an Azure Site Recovery job

### [Start-AzMigrateTestMigration](Start-AzMigrateTestMigration.md)
Test Migrate a protected VM.

Start-AzMigrateTestMigration -ProjectName a -ResourceGroupName b -SubscriptionId c -MachineName d -TestNetworkId e
Start-AzMigrateTestMigration -SubscriptionId c -MachineId d -TestNetworkId e

### [Start-AzMigrateTestMigrationCleanup](Start-AzMigrateTestMigrationCleanup.md)
Cleanup Test Migrate a protected VM.

Start-AzMigrateTestMigration -ProjectName a -ResourceGroupName b -SubscriptionId c -MachineName d -TestNetworkId e
Start-AzMigrateTestMigration -SubscriptionId c -MachineId d -TestNetworkId e

### [Stop-AzMigrateReplicationJob](Stop-AzMigrateReplicationJob.md)
The operation to cancel an Azure Site Recovery job.

### [Test-AzMigrateReplicationFabricConsistency](Test-AzMigrateReplicationFabricConsistency.md)
The operation to perform a consistency check on the fabric.

### [Test-AzMigrateReplicationMigrationItemMigrate](Test-AzMigrateReplicationMigrationItemMigrate.md)
The operation to initiate test migration of the item.

### [Test-AzMigrateReplicationMigrationItemMigrateCleanup](Test-AzMigrateReplicationMigrationItemMigrateCleanup.md)
The operation to initiate test migrate cleanup.

### [Update-AzMigrateReplicationMigrationItem](Update-AzMigrateReplicationMigrationItem.md)
The operation to update the recovery settings of an ASR migration item.

### [Update-AzMigrateReplicationPolicy](Update-AzMigrateReplicationPolicy.md)
The operation to update a replication policy.

