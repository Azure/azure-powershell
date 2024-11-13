---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azadserviceprincipalapproleassignment
schema: 2.0.0
---

# Update-AzADServicePrincipalAppRoleAssignment

## SYNOPSIS
update the navigation property appRoleAssignments in servicePrincipals

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId <String> -ServicePrincipalId <String>
 [-AdditionalProperties <Hashtable>] [-AppRoleId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId <String> -ServicePrincipalId <String>
 -Body <IMicrosoftGraphAppRoleAssignment> [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId <String> -ServicePrincipalId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId <String> -ServicePrincipalId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update the navigation property appRoleAssignments in servicePrincipals

## EXAMPLES

### Example 1: Update the AppRoleId
```powershell
Update-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId Zbm-cUeDXUmlicIc3eenIoFW9pZ_gRBIudKgu0gaMIw -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -AppRoleId 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83
```

Update the assigned App role id.

## PARAMETERS

### -AdditionalProperties
Additional Parameters

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppRoleAssignmentId
key: id of appRoleAssignment

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

### -AppRoleId
The identifier (id) for the app role which is assigned to the principal.
This app role must be exposed in the appRoles property on the resource application's service principal (resourceId).
If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles.
Required on create.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalId
key: id of servicePrincipal

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
