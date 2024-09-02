---
external help file:
Module Name: Az.Advisor
online version: https://learn.microsoft.com/powershell/module/az.advisor/Disable-AzAdvisorRecommendation
schema: 2.0.0
---

# Disable-AzAdvisorRecommendation

## SYNOPSIS
Disable an Azure Advisor recommendation.

## SYNTAX

### IdParameterSet (Default)
```
Disable-AzAdvisorRecommendation -ResourceId <String> [-SubscriptionId <String[]>] [-Day <Object>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InputObjectParameterSet
```
Disable-AzAdvisorRecommendation -InputObject <IAdvisorIdentity> [-SubscriptionId <String[]>] [-Day <Object>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### NameParameterSet
```
Disable-AzAdvisorRecommendation -RecommendationName <String> [-SubscriptionId <String[]>] [-Day <Object>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Disable an Azure Advisor recommendation.

## EXAMPLES

### Example 1: Disable recommendation by recommendation name
```powershell
Disable-AzAdvisorRecommendation -RecommendationName 42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation name

### Example 2: Disable recommendation by recommendation resource id
```powershell
Disable-AzAdvisorRecommendation -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/automanagehcrprg/providers/microsoft.compute/virtualmachines/arcbox-capi-mgmt/providers/Microsoft.Advisor/recommendations/42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation resource id

## PARAMETERS

### -Day
Days to disable.

```yaml
Type: System.Object
Parameter Sets: (All)
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

### -InputObject
The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzAdvisorRecommendation call.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecommendationName
ResourceName of the recommendation.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Id of the recommendation to be suppressed.

```yaml
Type: System.String
Parameter Sets: IdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase

## NOTES

## RELATED LINKS

