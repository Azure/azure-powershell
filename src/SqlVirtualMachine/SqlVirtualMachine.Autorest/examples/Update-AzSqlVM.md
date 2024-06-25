### Example 1
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -LicenseType 'AHUB' -Tag @{'newkey'='newvalue'}
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine with AHUB billing and add a tag.

### Example 2
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Update-AzSqlVM -Sku 'Standard' -LicenseType 'AHUB'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine's sku and license type via identity.

### Example 3
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoBackupSettingEnable `
-AutoBackupSettingBackupScheduleType manual -AutoBackupSettingFullBackupFrequency Weekly -AutoBackupSettingFullBackupStartTime 5 `
-AutoBackupSettingFullBackupWindowHour 2 -AutoBackupSettingStorageAccessKey 'keyvalue' -AutoBackupSettingStorageAccountUrl `
'https://storagename.blob.core.windows.net/' -AutoBackupSettingRetentionPeriod 10 -AutoBackupSettingLogBackupFrequency 60 `
-AutoBackupSettingStorageContainerName 'storagecontainername'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable auto backup.

### Example 4
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoBackupSettingEnable:$false
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to disable auto backup.

### Example 5
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' `
-AutoPatchingSettingDayOfWeek Thursday `
-AutoPatchingSettingMaintenanceWindowDuration 120 -AutoPatchingSettingMaintenanceWindowStartingHour 3 -AutoPatchingSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable auto patching.

### Example 6
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AutoPatchingSettingEnable:$false
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to disable auto patching.

### Example 7
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AssessmentSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable assessment.

### Example 8
```powershell
# $pwd is the password for cluster accounts
$securepwd = ConvertTo-SecureString -String $pwd -AsPlainText -Force
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' `
-SqlVirtualMachineGroupResourceId '<group resource id>' `
-WsfcDomainCredentialsClusterBootstrapAccountPassword $securepwd `
-WsfcDomainCredentialsClusterOperatorAccountPassword $securepwd `
-WsfcDomainCredentialsSqlServiceAccountPassword $securepwd 
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to add it to a SQL VM group.

### Example 9
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -SqlVirtualMachineGroupResourceId ''
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to remove it from a SQL VM group.

### Example 10
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'  -Tag @{'newkey'='newvalue'} -AsJob
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine's tag as a background job.

### Example 11
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'SystemAssigned'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable Microsoft Entra authentication using "System-assigned managed identity"

### Example 12
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'UserAssigned' -ManagedIdentityClientId '11111111-2222-3333-4444-555555555555'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Update a SQL virtual machine to enable Microsoft Entra authentication using "User-assigned managed identity"