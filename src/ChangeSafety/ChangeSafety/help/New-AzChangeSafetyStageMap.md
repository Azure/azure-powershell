---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/new-azchangesafetystagemap
schema: 2.0.0
---

# New-AzChangeSafetyStageMap

## SYNOPSIS
Create a StageMap

## SYNTAX

### CreateExpanded1 (Default)
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] [-Parameter <Hashtable>]
 [-Stage <IStage[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChangeSafetyStageMap -Name <String> -ManagementGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChangeSafetyStageMap -Name <String> -ManagementGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzChangeSafetyStageMap -Name <String> -ManagementGroupName <String> [-Parameter <Hashtable>]
 [-Stage <IStage[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString2
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString1
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath2
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath1
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded2
```
New-AzChangeSafetyStageMap -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-Parameter <Hashtable>] [-Stage <IStage[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a StageMap

## EXAMPLES

### Example 1: Create a simple two-stage StageMap
```powershell
New-AzChangeSafetyStageMap -Name "prod-deployment-stages" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ name = "canary"; sequence = 1 },
        @{ name = "production"; sequence = 2 }
    )
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Creates a StageMap with two stages: canary (runs first) and production (runs second).

### Example 2: Create a StageMap with stage variables
```powershell
New-AzChangeSafetyStageMap -Name "regional-rollout" `
    -ResourceGroupName "rg-changeops" `
    -Stage @(
        @{ 
            name = "eastus-canary"
            sequence = 1
            stageVariables = @{
                region = "eastus"
                replicas = 1
                enableMonitoring = $true
            }
        },
        @{ 
            name = "eastus-prod"
            sequence = 2
            stageVariables = @{
                region = "eastus"
                replicas = 3
                enableMonitoring = $true
            }
        },
        @{ 
            name = "westus-prod"
            sequence = 3
            stageVariables = @{
                region = "westus"
                replicas = 3
                enableMonitoring = $true
            }
        }
    )
```

```output
Name             ResourceGroupName ProvisioningState
----             ----------------- -----------------
regional-rollout rg-changeops      Succeeded
```

Creates a StageMap with three stages for regional rollout, each with stage-specific variables.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath, CreateViaJsonFilePath2, CreateViaJsonFilePath1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonString2, CreateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupName
The name of the management group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded1, CreateExpanded, CreateExpanded2
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
Parameter Sets: CreateViaJsonString2, CreateViaJsonFilePath2, CreateExpanded2
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
Parameter Sets: CreateExpanded1, CreateExpanded, CreateExpanded2
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
Parameter Sets: CreateExpanded1, CreateViaJsonString2, CreateViaJsonString1, CreateViaJsonFilePath2, CreateViaJsonFilePath1, CreateExpanded2
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IStageMap

## NOTES

## RELATED LINKS
