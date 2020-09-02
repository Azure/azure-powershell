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
### [Get-AzMigrateDiskMapping](Get-AzMigrateDiskMapping.md)
The New-AzMigrateDiskMapping cmdlet creates a mapping of the source disk attached to the server to be migrated

### [Get-AzmigrateJob](Get-AzmigrateJob.md)
Get job.

### [Get-AzMigrateReplicationItem](Get-AzMigrateReplicationItem.md)
Get Replication items.

### [Initialize-AzMigrateReplicationInfrastructure](Initialize-AzMigrateReplicationInfrastructure.md)
The Initialize-AzMigrateReplicationInfrastructure deploys and configures the replication infrastructure used for server migration in the Azure Migrate project Resource Group.

### [Mock-AzMigrateGetRunAsAccountId](Mock-AzMigrateGetRunAsAccountId.md)
Mock

### [Mock-AzMigrateGetSite](Mock-AzMigrateGetSite.md)
Mock

### [Mock-AzMigrateGetSolution](Mock-AzMigrateGetSolution.md)
Mock

### [New-AzMigrateServerReplication](New-AzMigrateServerReplication.md)
The New-AzMigrateServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.

### [Remove-AzMigrateServerReplication](Remove-AzMigrateServerReplication.md)
Remove Migration item.

### [Restart-AzMigrateServerReplication](Restart-AzMigrateServerReplication.md)
Restart job.

### [Set-AzMigrateServerReplication](Set-AzMigrateServerReplication.md)
# TODO PLEASE FIX BEFORE RELEASE
Create a deployment in the specified subscription and resource group.
This has to be done only once, before enabling replication for first 
VmWare virtual machine.
Initialize-AzMigrateReplicationInfrastructure -ProjectName a -ResourceGroupName b -SubscriptionId c -Vmwareagentless

### [Start-AzMigrateServerMigration](Start-AzMigrateServerMigration.md)
Migrates a VM.

### [Start-AzMigrateTestMigration](Start-AzMigrateTestMigration.md)
Test Migrate a protected VM.

### [Start-AzMigrateTestMigrationCleanup](Start-AzMigrateTestMigrationCleanup.md)
Cleanup Test Migrate a protected VM.

