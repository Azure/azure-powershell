---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappscaleruleobject
schema: 2.0.0
---

# New-AzContainerAppScaleRuleObject

## SYNOPSIS
Create an in-memory object for ScaleRule.

## SYNTAX

```
New-AzContainerAppScaleRuleObject [-AzureQueueAuth <IScaleRuleAuth[]>] [-AzureQueueLength <Int32>]
 [-AzureQueueName <String>] [-CustomAuth <IScaleRuleAuth[]>] [-CustomMetadata <ICustomScaleRuleMetadata>]
 [-CustomType <String>] [-HttpAuth <IScaleRuleAuth[]>] [-HttpMetadata <IHttpScaleRuleMetadata>]
 [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScaleRule.

## EXAMPLES

### Example 1: Create a ScaleRule object for ContainerApp.
```powershell
$scaleRule = @()
$scaleRule += New-AzContainerAppScaleRuleObject -Name scaleRuleName1 -AzureQueueLength 30 -AzureQueueName azps_containerapp -CustomType "azure-servicebus"
$scaleRule += New-AzContainerAppScaleRuleObject -Name scaleRuleName2 -AzureQueueLength 30 -AzureQueueName azps_containerapp -CustomType "azure-servicebus"
```

```output
Name
----
scaleRuleName
```

Create a ScaleRule object for ContainerApp.
The ScaleRule object as value of the `ScaleRule` parameter in the cmdlet `New-AzContainerApp`.

## PARAMETERS

### -AzureQueueAuth
Authentication secrets for the queue scale rule.
To construct, see NOTES section for AZUREQUEUEAUTH properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IScaleRuleAuth[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureQueueLength
Queue length.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureQueueName
Queue name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomAuth
Authentication secrets for the custom scale rule.
To construct, see NOTES section for CUSTOMAUTH properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IScaleRuleAuth[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomMetadata
Metadata properties to describe custom scale rule.
To construct, see NOTES section for CUSTOMMETADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ICustomScaleRuleMetadata
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomType
Type of the custom scale rule
        eg: azure-servicebus, redis etc.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpAuth
Authentication secrets for the custom scale rule.
To construct, see NOTES section for HTTPAUTH properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IScaleRuleAuth[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpMetadata
Metadata properties to describe http scale rule.
To construct, see NOTES section for HTTPMETADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IHttpScaleRuleMetadata
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Scale Rule Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ScaleRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AZUREQUEUEAUTH <IScaleRuleAuth[]>`: Authentication secrets for the queue scale rule.
  - `[SecretRef <String>]`: Name of the Container App secret from which to pull the auth params.
  - `[TriggerParameter <String>]`: Trigger Parameter that uses the secret

`CUSTOMAUTH <IScaleRuleAuth[]>`: Authentication secrets for the custom scale rule.
  - `[SecretRef <String>]`: Name of the Container App secret from which to pull the auth params.
  - `[TriggerParameter <String>]`: Trigger Parameter that uses the secret

`CUSTOMMETADATA <ICustomScaleRuleMetadata>`: Metadata properties to describe custom scale rule.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`HTTPAUTH <IScaleRuleAuth[]>`: Authentication secrets for the custom scale rule.
  - `[SecretRef <String>]`: Name of the Container App secret from which to pull the auth params.
  - `[TriggerParameter <String>]`: Trigger Parameter that uses the secret

`HTTPMETADATA <IHttpScaleRuleMetadata>`: Metadata properties to describe http scale rule.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

