---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/search-azdataprotectionjobinazgraph
schema: 2.0.0
---

# Search-AzDataProtectionJobInAzGraph

## SYNOPSIS
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries

## SYNTAX

```
Search-AzDataProtectionJobInAzGraph -DatasourceType <DatasourceTypes> -Subscription <String[]>
 [-EndTime <DateTime>] [-Operation <JobOperation[]>] [-ResourceGroup <String[]>] [-StartTime <DateTime>]
 [-Status <JobStatus[]>] [-Vault <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries

## EXAMPLES

### Example 1: Get all jobs in a certain time range
```powershell
PS C:\> $endtime = get-date
PS C:\> $starttime = $endtime.AddHours(-5)
PS C:\> Search-AzDataProtectionJobInAzGraph -Subscription "xxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -StartTime $starttime -EndTime $endtime

Name                                 Type
----                                 ----
1c1d56c2-b21a-4038-ba46-3c1a0089e66a microsoft.dataprotection/backupvaults/backupjobs
79f2804d-a39d-487e-91b5-f2eceffcbb7a microsoft.dataprotection/backupvaults/backupjobs
96238abd-6ff3-48e0-8c07-0eabd6928a17 microsoft.dataprotection/backupvaults/backupjobs
```

This command gets all jobs in a vault in last 5 hours.

### Example 2: Get all jobs of a certain operation type
```powershell
PS C:\> Search-AzDataProtectionJobInAzGraph -Subscription "xxxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -Operation OnDemandBackup

Name                                 Type
----                                 ----
11bc277d-9448-446a-9e79-4721858524d6 microsoft.dataprotection/backupvaults/backupjobs
16d7b56a-e169-41d1-aa10-cafcc19c8e12 microsoft.dataprotection/backupvaults/backupjobs
1b0b17e3-398f-4265-9d03-ffc1e21fa73a microsoft.dataprotection/backupvaults/backupjobs
```

This command gets all ondemand backup jobs in a vault.

## PARAMETERS

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
End Time filter for the Backup Job

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Operation filter for the backup job

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobOperation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
Resource Group of Vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Start Time filter for the backup Job

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Status filter for the backup job

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobStatus[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
Subscription of Vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Name of the vault

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

ALIASES

## RELATED LINKS

