### Example 1: List
```powershell
PS C:\> Get-AzMigrateJob -ResourceGroupName 'azmigratepwshtestasr13072020' -ProjectName 'AzMigrateTestProjectPWSH'

Location Name                                 Type                                                                                 
-------- ----                                 ----                                                                                          
	 71655abe-8551-4b6e-9ae1-2bef206c9e56 Microsoft.RecoveryServices/vaults/replicationJobs                                             
	 9c7416bd-0b6b-4ba5-a832-d2a0393bab0e Microsoft.RecoveryServices/vaults/replicationJobs                                             
	 0aaa4402-fe1f-40c9-9c71-c8520e5673c9 Microsoft.RecoveryServices/vaults/replicationJobs                                             
```

### Example 2: Get by job name
```powershell
PS C:\>  Get-AzMigrateJob -ResourceGroupName 'azmigratepwshtestasr13072020' -ProjectName 'AzMigrateTestProjectPWSH' -JobName '7ae1ee7c-442c-499d-8b0e-81d52a42b71e'

Location Name                                 Type                                                                                 
-------- ----                                 ----                                                                                          
	 7ae1ee7c-442c-499d-8b0e-81d52a42b71e Microsoft.RecoveryServices/vaults/replicationJobs 
```

### Example 3: Get by machine id
```powershell
PS C:\>  Get-AzMigrateJob -MachineId '/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationFabrics/AzMigratePWSHTc8d1replicationfabric/replicationProtectionContainers/AzMigratePWSHTc8d1replicationcontainer/replicationMigrationItems/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f'

Location Name                                 Type                                                                                 
-------- ----                                 ----                                                                                          
	 7ae1ee7c-442c-499d-8b0e-81d52a42b71e Microsoft.RecoveryServices/vaults/replicationJobs 
```

### Example 4: Get by machine Name
```powershell
PS C:\>  Get-AzMigrateJob -ResourceGroupName 'azmigratepwshtestasr13072020' -ProjectName 'AzMigrateTestProjectPWSH' -MachineName 'bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f'

Location Name                                 Type                                                                                 
-------- ----                                 ----                                                                                          
	 7ae1ee7c-442c-499d-8b0e-81d52a42b71e Microsoft.RecoveryServices/vaults/replicationJobs 
```
