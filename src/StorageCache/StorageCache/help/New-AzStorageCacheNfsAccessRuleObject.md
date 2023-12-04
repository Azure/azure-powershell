---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/Az.StorageCache/new-AzStorageCacheNfsAccessRuleObject
schema: 2.0.0
---

# New-AzStorageCacheNfsAccessRuleObject

## SYNOPSIS
Create an in-memory object for NfsAccessRule.

## SYNTAX

```
New-AzStorageCacheNfsAccessRuleObject -Access <NfsAccessRuleAccess> -Scope <NfsAccessRuleScope>
 [-AnonymousGid <String>] [-AnonymousUid <String>] [-Filter <String>] [-RootSquash <Boolean>]
 [-SubmountAccess <Boolean>] [-Suid <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NfsAccessRule.

## EXAMPLES

### Example 1: Create an in-memory object for NfsAccessRule.
```powershell
New-AzStorageCacheNfsAccessRuleObject -Access 'rw' -Scope 'network' -AnonymousUid "65534" -AnonymousGid "65534" -SubmountAccess:$True -RootSquash:$True -Suid:$False -Filter "10.99.1.0/24"
```

```output
Access AnonymousGid AnonymousUid Filter       RootSquash Scope   SubmountAccess Suid
------ ------------ ------------ ------       ---------- -----   -------------- ----
rw     65534        65534        10.99.1.0/24 True       network True           False
```

Create an in-memory object for NfsAccessRule.

## PARAMETERS

### -Access
Access allowed by this rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.NfsAccessRuleAccess
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnonymousGid
GID value that replaces 0 when rootSquash is true.
This will use the value of anonymousUID if not provided.

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

### -AnonymousUid
UID value that replaces 0 when rootSquash is true.
65534 will be used if not provided.

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

### -Filter
Filter applied to the scope for this rule.
The filter's format depends on its scope.
'default' scope matches all clients and has no filter value.
'network' scope takes a filter in CIDR format (for example, 10.99.1.0/24).
'host' takes an IP address or fully qualified domain name as filter.
If a client does not match any filter rule and there is no default rule, access is denied.

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

### -RootSquash
Map root accesses to anonymousUID and anonymousGID.

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

### -Scope
Scope for this rule.
The scope and filter determine which clients match the rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.NfsAccessRuleScope
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubmountAccess
For the default policy, allow access to subdirectories under the root export.
If this is set to no, clients can only mount the path '/'.
If set to yes, clients can mount a deeper path, like '/a/b'.

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

### -Suid
Allow SUID semantics.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.NfsAccessRule

## NOTES

ALIASES

## RELATED LINKS

