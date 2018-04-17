---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsRPHealth

## SYNOPSIS
Returns a list of each service's health.

## SYNTAX

### List (Default)
```
Get-AzsRPHealth [-Location <String>] [-ResourceGroupName <String>] [-Filter <String>] [-Skip <Int32>]
 [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsRPHealth [-Name] <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsRPHealth -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of each service's health. 
The AlertSummary property includes details on warning/error counts.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsRPHealth
```

AlertSummary      : Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.AlertSummary
HealthState       : Unknown
NamespaceProperty : Microsoft.Update.Admin
RegistrationId    : 217c3a8e-b6f1-4c80-b92b-83e92bc65342
RoutePrefix       : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Update.Admin/updateLocations/local
DisplayName       : Updates
ServiceLocation   : local
InfraURI          : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Update.Admin/updateLocations/local/infraRoles/Upd
                    ates
Id                : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionHealths/local/
                    serviceHealths/217c3a8e-b6f1-4c80-b92b-83e92bc65342
Name              : 217c3a8e-b6f1-4c80-b92b-83e92bc65342
Type              : Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths
Location          : local
Tags              : {}

Returns a list of each service's health.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsRPHealth -Name "e56bc7b8-c8b5-4e25-b00c-4f951effb22c"
```

AlertSummary      : Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.AlertSummary
HealthState       : Critical
NamespaceProperty : Microsoft.Fabric.Admin
RegistrationId    : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
RoutePrefix       : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local
DisplayName       : Capacity
ServiceLocation   : local
InfraURI          : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/infraRoles/Cap
                    acity
Id                : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionHealths/local/
                    serviceHealths/e56bc7b8-c8b5-4e25-b00c-4f951effb22c
Name              : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
Type              : Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths
Location          : local
Tags              : {}

Returns a service's health.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Name of the region

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Service Health name.

```yaml
Type: String
Parameter Sets: Get
Aliases: ServiceHealth

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
{{Fill ResourceGroupName Description}}

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
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

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth

## NOTES

## RELATED LINKS

