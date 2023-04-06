---
external help file:
Module Name: Az.ManagementGroupsApi
online version: https://learn.microsoft.com/powershell/module/az.managementgroupsapi/get-azmanagementgroupsapihierarchysetting
schema: 2.0.0
---

# Get-AzManagementGroupsApiHierarchySetting

## SYNOPSIS
Gets the hierarchy settings defined at the Management Group level.
Settings can only be set on the root Management Group of the hierarchy.\n

## SYNTAX

### Get (Default)
```
Get-AzManagementGroupsApiHierarchySetting -GroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzManagementGroupsApiHierarchySetting -InputObject <IManagementGroupsApiIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzManagementGroupsApiHierarchySetting -GroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the hierarchy settings defined at the Management Group level.
Settings can only be set on the root Management Group of the hierarchy.\n

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Management Group ID.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.IManagementGroupsApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.IManagementGroupsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.Api20210401.IHierarchySettings

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.Api20210401.IHierarchySettingsList

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IManagementGroupsApiIdentity>`: Identity Parameter
  - `[GroupId <String>]`: Management Group ID.
  - `[Id <String>]`: Resource identity path
  - `[SubscriptionId <String>]`: Subscription ID.

## RELATED LINKS

