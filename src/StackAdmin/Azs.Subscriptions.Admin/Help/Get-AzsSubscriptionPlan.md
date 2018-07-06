---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version:
schema: 2.0.0
---

# Get-AzsSubscriptionPlan

## SYNOPSIS
Get a collection of all acquired plans that subscription has access to.

## SYNTAX

### List (Default)
```
Get-AzsSubscriptionPlan -TargetSubscriptionId <Guid> [-Top <Int32>] [-Skip <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsSubscriptionPlan -AcquisitionId <Guid> -TargetSubscriptionId <Guid> [<CommonParameters>]
```

### ResourceId
```
Get-AzsSubscriptionPlan -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Get a collection of all acquired plans that subscription has access to.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsSubscriptionPlan -TargetSubscriptionId "c90173b1-de7a-4b1d-8600-b832b0e65946"
```

Get a collection of all acquired plans that subscription has access to.

## PARAMETERS

### -AcquisitionId
The plan acquisition Identifier

```yaml
Type: Guid
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubscriptionId
The target subscription ID.

```yaml
Type: Guid
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.PlanAcquisition

## NOTES

## RELATED LINKS
