---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsResourceHealth

## SYNOPSIS

## SYNTAX

### ResourceHealths_List (Default)
```
Get-AzsResourceHealth -ServiceRegistrationId <String> [-Filter <String>] [-Skip <Int32>] -Location <String>
 [-Top <Int32>]
```

### ResourceHealths_Get
```
Get-AzsResourceHealth -ServiceRegistrationId <String> [-Filter <String>] -ResourceRegistrationId <String>
 -Location <String>
```

## DESCRIPTION
Get a list of resources?.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRegistrationId
Resource registration id.

```yaml
Type: String
Parameter Sets: ResourceHealths_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceRegistrationId
Service registration id.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: ResourceHealths_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: ResourceHealths_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth

## NOTES

## RELATED LINKS

