---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteruserdevboxcustomizationgroup
schema: 2.0.0
---

# New-AzDevCenterUserDevBoxCustomizationGroup

## SYNOPSIS
Applies customizations to the Dev Box.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -CustomizationGroupName <String>
 -DevBoxName <String> -ProjectName <String> [-UserId <String>] [-Task <ICustomizationTask[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpandedByDevCenter
```
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName <String> -CustomizationGroupName <String>
 -DevBoxName <String> -ProjectName <String> [-UserId <String>] [-Task <ICustomizationTask[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpandedByDevCenter
```
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-Task <ICustomizationTask[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Applies customizations to the Dev Box.

## EXAMPLES

### Example 1: Create a customization groupby endpoint
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -DevBoxName myDevBox -CustomizationGroupName Provisioning -Task $tasks
```

This command creates the customization group "Provisoning" for the dev box "myDevBox".

### Example 2: Create a customization groupby dev center
```powershell
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -UserId "me" -DevBoxName myDevBox -CustomizationGroupName Provisioning -Task $tasks
```

This command creates the customization group "Provisoning" for the dev box "myDevBox".

### Example 3: Create a customization groupby endpoint and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationGroupInput -Task $tasks
```

This command creates the customization group "Provisoning" for the dev box "myDevBox".

### Example 4: Create a customization groupby dev center and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -InputObject $customizationGroupInput -Task $tasks
```

This command creates the customization group "Provisoning" for the dev box "myDevBox".

## PARAMETERS

### -CustomizationGroupName
A customization group name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -DevBoxName
The name of a Dev Box.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: CreateExpandedByDevCenter, CreateViaIdentityExpandedByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentityExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Task
Tasks to apply.
Note by default tasks are excluded from the response whenlisting customization groups.
To include them, use the `include=tasks` queryparameter.
To construct, see NOTES section for TASK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ICustomizationTask[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the 
 authentication context.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpandedByDevCenter
Aliases:

Required: False
Position: Named
Default value: "me"
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ICustomizationGroup

## NOTES

## RELATED LINKS

