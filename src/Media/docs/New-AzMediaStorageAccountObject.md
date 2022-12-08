---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaStorageAccountObject
schema: 2.0.0
---

# New-AzMediaStorageAccountObject

## SYNOPSIS
Create an in-memory object for StorageAccount.

## SYNTAX

```
New-AzMediaStorageAccountObject -Type <StorageAccountType> [-Id <String>] [-UserAssignedIdentity <String>]
 [-UseSystemAssignedIdentity <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageAccount.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Id
The ID of the storage account resource.
Media Services relies on tables and queues as well as blobs, so the primary storage account must be a Standard Storage account (either Microsoft.ClassicStorage or Microsoft.Storage).
Blob only storage accounts can be added as secondary storage accounts.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Support.StorageAccountType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The user assigned managed identity's ARM ID to use when accessing a resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSystemAssignedIdentity
Indicates whether to use System Assigned Managed Identity.
Mutual exclusive with User Assigned Managed Identity.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20211101.StorageAccount

## NOTES

ALIASES

## RELATED LINKS

