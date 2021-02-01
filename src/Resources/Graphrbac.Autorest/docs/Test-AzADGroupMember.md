---
external help file:
Module Name: Az.AD
online version: https://docs.microsoft.com/en-us/powershell/module/az.ad/test-azadgroupmember
schema: 2.0.0
---

# Test-AzADGroupMember

## SYNOPSIS
Checks whether the specified user, group, contact, or service principal is a direct or transitive member of the specified group.

## SYNTAX

### IsExpanded (Default)
```
Test-AzADGroupMember -TenantId <String> -GroupId <String> -MemberId <String>
 [-AdditionalProperties <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Is
```
Test-AzADGroupMember -TenantId <String> -Parameter <ICheckGroupMembershipParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IsViaIdentity
```
Test-AzADGroupMember -InputObject <IAdIdentity> -Parameter <ICheckGroupMembershipParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IsViaIdentityExpanded
```
Test-AzADGroupMember -InputObject <IAdIdentity> -GroupId <String> -MemberId <String>
 [-AdditionalProperties <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks whether the specified user, group, contact, or service principal is a direct or transitive member of the specified group.

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

### -AdditionalProperties
Additional Parameters

```yaml
Type: System.Collections.Hashtable
Parameter Sets: IsExpanded, IsViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupId
The object ID of the group to check.

```yaml
Type: System.String
Parameter Sets: IsExpanded, IsViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity
Parameter Sets: IsViaIdentity, IsViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MemberId
The object ID of the contact, group, user, or service principal to check for membership in the specified group.

```yaml
Type: System.String
Parameter Sets: IsExpanded, IsViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Request parameters for IsMemberOf API call.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipParameters
Parameter Sets: Is, IsViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TenantId
The tenant ID.

```yaml
Type: System.String
Parameter Sets: Is, IsExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ICheckGroupMembershipParameters

### Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAdIdentity>: Identity Parameter
  - `[ApplicationId <String>]`: The application ID.
  - `[ApplicationObjectId <String>]`: The object ID of the application for which to get owners.
  - `[DomainName <String>]`: name of the domain.
  - `[GroupObjectId <String>]`: The object ID of the group from which to remove the member.
  - `[Id <String>]`: Resource identity path
  - `[MemberObjectId <String>]`: Member object id
  - `[NextLink <String>]`: Next link for the list operation.
  - `[ObjectId <String>]`: The object ID of the group whose members should be retrieved.
  - `[OwnerObjectId <String>]`: Owner object id
  - `[TenantId <String>]`: The tenant ID.
  - `[UpnOrObjectId <String>]`: The object ID or principal name of the user for which to get information.

PARAMETER <ICheckGroupMembershipParameters>: Request parameters for IsMemberOf API call.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `GroupId <String>`: The object ID of the group to check.
  - `MemberId <String>`: The object ID of the contact, group, user, or service principal to check for membership in the specified group.

## RELATED LINKS

