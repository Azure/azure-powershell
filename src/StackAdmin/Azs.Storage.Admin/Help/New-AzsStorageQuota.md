---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# New-AzsStorageQuota

## SYNOPSIS
Create a new storage quota.

## SYNTAX

```
New-AzsStorageQuota -QuotaName <String> [-CapacityInGb <Int32>] [-NumberOfStorageAccounts <Int32>]
 [-Location <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a new storage quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsStorageQuota -CapacityInGb 1000 -NumberOfStorageAccounts 100 -Location local -QuotaName 'TestCreateStorageQuota'
```

Name       Location   CapacityInGb	NumberOfStorageAccounts
----       --------   ----------	----------
   local/T...
local      1000			100

   Create a new storage quota.

## PARAMETERS

### -CapacityInGb
Maxium capacity (GB).

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 500
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfStorageAccounts
Total number of storage accounts.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 20
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaName
The name of the storage quota.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota

## NOTES

## RELATED LINKS

