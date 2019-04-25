---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azadgroupmember
schema: 2.0.0
---

# Test-AzADGroupMember

## SYNOPSIS
Checks whether the specified user, group, contact, or service principal is a direct or transitive member of the specified group.

## SYNTAX

### Is (Default)
```
Test-AzADGroupMember -TenantId <String> [-Parameters <ICheckGroupMembershipParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IsExpanded
```
Test-AzADGroupMember -TenantId <String> -GroupId <String> -MemberId <String> [-Properties <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks whether the specified user, group, contact, or service principal is a direct or transitive member of the specified group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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
Parameter Sets: IsExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberId
The object ID of the contact, group, user, or service principal to check for membership in the specified group.

```yaml
Type: System.String
Parameter Sets: IsExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Request parameters for IsMemberOf API call.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.ICheckGroupMembershipParameters
Parameter Sets: Is
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Properties
Additional Parameters

```yaml
Type: System.Collections.Hashtable
Parameter Sets: IsExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant ID.

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

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azadgroupmember](https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azadgroupmember)

