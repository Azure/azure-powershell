---
external help file:
Module Name: HpcCache
online version: https://docs.microsoft.com/powershell/module//az.HpcCache/new-AzHpcCacheNfsAccessPolicyObject
schema: 2.0.0
---

# New-AzHpcCacheNfsAccessPolicyObject

## SYNOPSIS
Create a in-memory object for NfsAccessPolicy

## SYNTAX

```
New-AzHpcCacheNfsAccessPolicyObject -AccessRule <INfsAccessRule[]> -Name <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NfsAccessPolicy

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

### -AccessRule
The set of rules describing client accesses allowed under this policy.
To construct, see NOTES section for ACCESSRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.INfsAccessRule[]
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

### Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NfsAccessPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ACCESSRULE <INfsAccessRule[]>: The set of rules describing client accesses allowed under this policy.
  - `Access <NfsAccessRuleAccess>`: Access allowed by this rule.
  - `Scope <NfsAccessRuleScope>`: Scope for this rule. The scope and filter determine which clients match the rule.
  - `[AnonymousGid <String>]`: GID value that replaces 0 when rootSquash is true. This will use the value of anonymousUID if not provided.
  - `[AnonymousUid <String>]`: UID value that replaces 0 when rootSquash is true. 65534 will be used if not provided.
  - `[Filter <String>]`: Filter applied to the scope for this rule. The filter's format depends on its scope. 'default' scope matches all clients and has no filter value. 'network' scope takes a filter in CIDR format (for example, 10.99.1.0/24). 'host' takes an IP address or fully qualified domain name as filter. If a client does not match any filter rule and there is no default rule, access is denied.
  - `[RootSquash <Boolean?>]`: Map root accesses to anonymousUID and anonymousGID.
  - `[SubmountAccess <Boolean?>]`: For the default policy, allow access to subdirectories under the root export. If this is set to no, clients can only mount the path '/'. If set to yes, clients can mount a deeper path, like '/a/b'.
  - `[Suid <Boolean?>]`: Allow SUID semantics.

## RELATED LINKS

