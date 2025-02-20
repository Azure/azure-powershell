---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappscaleruleobject
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
 [-Name <String>] [-TcpAuth <IScaleRuleAuth[]>] [-TcpMetadata <ITcpScaleRuleMetadata>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScaleRule.

## EXAMPLES

### Example 1: Create an in-memory object for ScaleRule.
```powershell
New-AzContainerAppScaleRuleObject -Name "httpscalingrule" -CustomType "http" -AzureQueueLength 30 -AzureQueueName azps-containerapp
```

```output
Name
----
httpscalingrule
```

Create an in-memory object for ScaleRule.

## PARAMETERS

### -AzureQueueAuth
Authentication secrets for the queue scale rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRuleAuth[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRuleAuth[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ICustomScaleRuleMetadata
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRuleAuth[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IHttpScaleRuleMetadata
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

### -TcpAuth
Authentication secrets for the tcp scale rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRuleAuth[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpMetadata
Metadata properties to describe tcp scale rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ITcpScaleRuleMetadata
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ScaleRule

## NOTES

## RELATED LINKS
