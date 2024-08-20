---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradmindevboxdefinition
schema: 2.0.0
---

# Get-AzDevCenterAdminDevBoxDefinition

## SYNOPSIS
Gets a Dev Box definition

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminDevBoxDefinition -DevCenterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminDevBoxDefinition -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzDevCenterAdminDevBoxDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminDevBoxDefinition -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDevCenterAdminDevBoxDefinition -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Dev Box definition

## EXAMPLES

### Example 1: List dev box definitions in a dev center
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -DevCenterName Contoso
```

This command lists the dev box definitions in the dev center "Contoso" under the resource group "testRg".

### Example 2: List dev box definitions in a project
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -ProjectName DevProject
```

This command lists the dev box definitions in the project "DevProject" under the resource group "testRg".

### Example 3: Get a dev center dev box definition
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -DevCenterName Contoso -Name WebDevBoxDef
```

This command gets the dev box definition "WebDevBoxDef" in the dev center "Contoso" under the resource group "testRg".

### Example 4: Get a project dev box definition
```powershell
Get-AzDevCenterAdminDevBoxDefinition -ResourceGroupName testRg -ProjectName DevProject -Name WebDevBoxDef
```

This command gets the dev box definition "WebDevBoxDef" in the project "DevProject" under the resource group "testRg".

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

### -DevCenterName
The name of the devcenter.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Dev Box definition.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases: DevBoxDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the project.

```yaml
Type: System.String
Parameter Sets: Get1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, Get1, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevBoxDefinition

## NOTES

## RELATED LINKS

