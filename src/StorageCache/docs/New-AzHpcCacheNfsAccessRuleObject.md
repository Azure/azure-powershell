---
external help file:
Module Name: HpcCache
online version: https://docs.microsoft.com/powershell/module//az.HpcCache/new-AzHpcCacheNfsAccessRuleObject
schema: 2.0.0
---

# New-AzHpcCacheNfsAccessRuleObject

## SYNOPSIS
Create a in-memory object for NfsAccessRule

## SYNTAX

```
New-AzHpcCacheNfsAccessRuleObject -Access <NfsAccessRuleAccess> -Scope <NfsAccessRuleScope>
 [-AnonymousGid <String>] [-AnonymousUid <String>] [-Filter <String>] [-RootSquash <Boolean>]
 [-SubmountAccess <Boolean>] [-Suid <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NfsAccessRule

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Access
Access allowed by this rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.NfsAccessRuleAccess
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.NfsAccessRuleScope
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

### Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NfsAccessRule

## NOTES

ALIASES

## RELATED LINKS

