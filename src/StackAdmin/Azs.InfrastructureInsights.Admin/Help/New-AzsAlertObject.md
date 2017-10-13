---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# New-AzsAlertObject

## SYNOPSIS
This class models an alert resource.

## SYNTAX

```
New-AzsAlertObject [[-FaultTypeId] <String>]
 [[-Tags] <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [[-ClosedTimestamp] <String>]
 [[-ClosedByUserAlias] <String>] [[-Name] <String>] [[-ResourceRegistrationId] <String>] [[-Severity] <String>]
 [[-CreatedTimestamp] <String>] [[-LastUpdatedTimestamp] <String>] [[-ResourceProviderRegistrationId] <String>]
 [[-Type] <String>] [[-Remediation] <Dictionary`2[]>] [[-ImpactedResourceId] <String>] [[-Title] <String>]
 [[-ImpactedResourceDisplayName] <String>]
 [[-AlertProperties] <System.Collections.Generic.Dictionary`2[System.String,System.String]>]
 [[-Description] <Dictionary`2[]>] [[-Id] <String>] [[-State] <String>] [[-Location] <String>]
 [[-FaultId] <String>] [[-AlertId] <String>] [<CommonParameters>]
```

## DESCRIPTION
This class models an alert resource.

## EXAMPLES

## PARAMETERS

### -AlertId
Gets or sets the id of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 22
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertProperties
Gets or sets properties of the alert.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 16
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClosedByUserAlias
Gets or sets the user alias who closed the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClosedTimestamp
Gets or sets the closed timestamp of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreatedTimestamp
Gets or sets the created timestamp of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Gets or sets the description of the alert.

```yaml
Type: Dictionary`2[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 17
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FaultId
Gets or sets the fault id of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 21
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FaultTypeId
Gets or sets the fault type id of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
URI of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 18
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImpactedResourceDisplayName
Gets or sets the display name for the impacted item.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 15
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImpactedResourceId
Gets or sets the ResourceId for the impacted item.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 13
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastUpdatedTimestamp
Gets or sets last updated timestamp of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location where resource is location.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 20
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Remediation
Gets or sets the admin friendly remediation instructions for the alert.

```yaml
Type: Dictionary`2[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 12
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderRegistrationId
Gets or sets the registration id of the service the alert belongs to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRegistrationId
Gets or sets the registration id of the atomic component the alert belongs to. 
This is null if not associated with a resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
Gets or sets the severity of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Gets or sets the state of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 19
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
List of key value pairs.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
Gets or sets the ResourceId for the impacted item.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 14
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 11
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

