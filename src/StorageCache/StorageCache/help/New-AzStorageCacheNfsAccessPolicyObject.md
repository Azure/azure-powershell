---
external help file: Az.StorageCache-help.xml
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCacheNfsAccessPolicyObject
schema: 2.0.0
---

# New-AzStorageCacheNfsAccessPolicyObject

## SYNOPSIS
Create an in-memory object for NfsAccessPolicy.

## SYNTAX

```
New-AzStorageCacheNfsAccessPolicyObject -AccessRule <INfsAccessRule[]> -Name <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NfsAccessPolicy.

## EXAMPLES

### Example 1: Create an in-memory object for NfsAccessPolicy.
```powershell
$objcet = New-AzStorageCacheNfsAccessRuleObject -Access 'rw' -Scope 'network' -AnonymousUid "65534" -AnonymousGid "65534" -SubmountAccess:$True -RootSquash:$True -Suid:$False -Filter "10.99.1.0/24"
New-AzStorageCacheNfsAccessPolicyObject -AccessRule $object -Name azps-nfsaccesspolicy
```

```output
Name
----
azps-nfsaccesspolicy
```

Create an in-memory object for NfsAccessPolicy.

## PARAMETERS

### -AccessRule
The set of rules describing client accesses allowed under this policy.
To construct, see NOTES section for ACCESSRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.INfsAccessRule[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name identifying this policy.
Access Policy names are not case sensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.NfsAccessPolicy

## NOTES

## RELATED LINKS
