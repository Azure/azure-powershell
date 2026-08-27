---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/get-azchangesafetystagemap
schema: 2.0.0
---

# Get-AzChangeSafetyStageMap

## SYNOPSIS
Get a StageMap

## SYNTAX

### List1 (Default)
```
Get-AzChangeSafetyStageMap [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzChangeSafetyStageMap -ManagementGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzChangeSafetyStageMap -ManagementGroupName <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzChangeSafetyStageMap -Name <String> -ManagementGroupInputObject <IChangeSafetyIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get2
```
Get-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List2
```
Get-AzChangeSafetyStageMap [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity2
```
Get-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a StageMap

## EXAMPLES

### Example 1: Get a specific StageMap by name
```powershell
Get-AzChangeSafetyStageMap -Name "prod-deployment-stages" -ResourceGroupName "rg-changeops"
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Retrieves a specific StageMap by its name from the specified resource group.

### Example 2: List all StageMaps in a resource group
```powershell
Get-AzChangeSafetyStageMap -ResourceGroupName "rg-changeops"
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
regional-rollout       rg-changeops      Succeeded
```

Lists all StageMaps in the specified resource group.

### Example 3: List all StageMaps in the current subscription
```powershell
Get-AzChangeSafetyStageMap
```

Lists all StageMaps across all resource groups in the current subscription.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: GetViaIdentity2, GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: GetViaIdentityManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupName
The name of the management group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the StageMap

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagementGroup, Get2, Get1
Aliases: StageMapName

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
Parameter Sets: Get2, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get2, Get1, List2
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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IStageMap

## NOTES

## RELATED LINKS
