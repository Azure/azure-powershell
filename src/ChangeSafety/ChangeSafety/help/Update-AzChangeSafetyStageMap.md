---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/update-azchangesafetystagemap
schema: 2.0.0
---

# Update-AzChangeSafetyStageMap

## SYNOPSIS
Update a StageMap

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] [-Parameter <Hashtable>]
 [-Stage <IStage[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzChangeSafetyStageMap -ManagementGroupName <String> -Name <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzChangeSafetyStageMap -ManagementGroupName <String> -Name <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzChangeSafetyStageMap -ManagementGroupName <String> -Name <String> [-Parameter <Hashtable>]
 [-Stage <IStage[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString2
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString1
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath2
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath1
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzChangeSafetyStageMap -Name <String> -ManagementGroupInputObject <IChangeSafetyIdentity>
 [-Parameter <Hashtable>] [-Stage <IStage[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded2
```
Update-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-Parameter <Hashtable>] [-Stage <IStage[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded2
```
Update-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-Parameter <Hashtable>] [-Stage <IStage[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-Parameter <Hashtable>] [-Stage <IStage[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzChangeSafetyStageMap -InputObject <IChangeSafetyIdentity> [-Parameter <Hashtable>] [-Stage <IStage[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a StageMap

## EXAMPLES

### Example 1: Update a StageMap with additional stages
```powershell
Update-AzChangeSafetyStageMap -Name "prod-deployment-stages" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ name = "canary"; sequence = 1 },
        @{ name = "staging"; sequence = 2 },
        @{ name = "production"; sequence = 3 }
    )
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Updates an existing StageMap to add a new staging stage between canary and production.

### Example 2: Update a StageMap stage variables
```powershell
Update-AzChangeSafetyStageMap -Name "regional-rollout" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ 
            name = "eastus-canary"
            sequence = 1
            stageVariables = @{
                region = "eastus"
                replicas = 2
                enableMonitoring = $true
                timeout = 3600
            }
        }
    )
```

Updates stage variables for an existing StageMap stage.

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
Parameter Sets: UpdateViaIdentityExpanded2, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath, UpdateViaJsonFilePath2, UpdateViaJsonFilePath1
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
Parameter Sets: UpdateViaJsonString, UpdateViaJsonString2, UpdateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: UpdateViaIdentityManagementGroupExpanded
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
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded
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
Parameter Sets: UpdateExpanded1, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded, UpdateViaJsonString2, UpdateViaJsonString1, UpdateViaJsonFilePath2, UpdateViaJsonFilePath1, UpdateViaIdentityManagementGroupExpanded, UpdateExpanded2
Aliases: StageMapName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
StageMap parameters schema for each stage.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateExpanded2, UpdateViaIdentityExpanded2, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateViaJsonString2, UpdateViaJsonFilePath2, UpdateExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stage
Array of stages objects.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IStage[]
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateExpanded2, UpdateViaIdentityExpanded2, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaJsonString2, UpdateViaJsonString1, UpdateViaJsonFilePath2, UpdateViaJsonFilePath1, UpdateExpanded2
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IStageMap

## NOTES

## RELATED LINKS
