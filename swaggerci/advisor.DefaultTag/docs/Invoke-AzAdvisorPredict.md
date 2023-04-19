---
external help file:
Module Name: Az.Advisor
online version: https://learn.microsoft.com/powershell/module/az.advisor/invoke-azadvisorpredict
schema: 2.0.0
---

# Invoke-AzAdvisorPredict

## SYNOPSIS
Predicts a recommendation.

## SYNTAX

### PredictExpanded (Default)
```
Invoke-AzAdvisorPredict [-SubscriptionId <String>] [-ExtendedProperty <IAny>]
 [-PredictionType <PredictionType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Predict
```
Invoke-AzAdvisorPredict -PredictionRequest <IPredictionRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PredictViaIdentity
```
Invoke-AzAdvisorPredict -InputObject <IAdvisorIdentity> -PredictionRequest <IPredictionRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PredictViaIdentityExpanded
```
Invoke-AzAdvisorPredict -InputObject <IAdvisorIdentity> [-ExtendedProperty <IAny>]
 [-PredictionType <PredictionType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Predicts a recommendation.

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

### -ExtendedProperty
Extended properties are arguments specific for each prediction type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAny
Parameter Sets: PredictExpanded, PredictViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity
Parameter Sets: PredictViaIdentity, PredictViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PredictionRequest
Parameters for predict recommendation.
To construct, see NOTES section for PREDICTIONREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202301.IPredictionRequest
Parameter Sets: Predict, PredictViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PredictionType
Type of the prediction.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Support.PredictionType
Parameter Sets: PredictExpanded, PredictViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Predict, PredictExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202301.IPredictionRequest

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202301.IPredictionResponseProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAdvisorIdentity>`: Identity Parameter
  - `[ConfigurationName <ConfigurationName?>]`: Advisor configuration name. Value must be 'default'
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: Name of metadata entity.
  - `[OperationId <String>]`: The operation ID, which can be found from the Location field in the generate recommendation response header.
  - `[RecommendationId <String>]`: The recommendation ID.
  - `[ResourceGroup <String>]`: The name of the Azure resource group.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource Manager identifier of the resource to which the recommendation applies.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

`PREDICTIONREQUEST <IPredictionRequest>`: Parameters for predict recommendation.
  - `[ExtendedProperty <IAny>]`: Extended properties are arguments specific for each prediction type.
  - `[PredictionType <PredictionType?>]`: Type of the prediction.

## RELATED LINKS

