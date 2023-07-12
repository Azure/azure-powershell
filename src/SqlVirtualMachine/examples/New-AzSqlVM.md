### Example 1
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```
Create a SQL virtual machine with default settings.

### Example 2
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -Sku 'Developer' -LicenseType 'PAYG'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine with specific sku type and license type.

### Example 3
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -LicenseType 'AHUB'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine with AHUB billing tag.

### Example 4
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -LicenseType 'DR'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine with DR billing tag.

### Example 5
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -AutoBackupSettingEnable `
-AutoBackupSettingBackupScheduleType manual -AutoBackupSettingFullBackupFrequency Weekly -AutoBackupSettingFullBackupStartTime 5 ` 
-AutoBackupSettingFullBackupWindowHour 2 -AutoBackupSettingStorageAccessKey 'keyvalue' -AutoBackupSettingStorageAccountUrl ` 
'https://storagename1.blob.core.windows.net/' -AutoBackupSettingRetentionPeriod 10 -AutoBackupSettingLogBackupFrequency 60 ` 
-AutoBackupSettingStorageContainerName 'storagecontainer1'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine and configure auto backup settings.

### Example 6
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -AutoPatchingSettingDayOfWeek Thursday ` 
-AutoPatchingSettingMaintenanceWindowDuration 120 -AutoPatchingSettingMaintenanceWindowStartingHour 3 -AutoPatchingSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine and configure auto patching settings.

### Example 7
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -AssessmentSettingEnable
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine and configure assessment settings.

### Example 8
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -AsJob
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Create a SQL virtual machine as a background job.