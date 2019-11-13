---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsFileContainer

## SYNOPSIS
Lists file containers or gets a file container properties.

## SYNTAX

```
Get-AzsFileContainer [[-FileContainerId] <String>] [[-ApiVersion] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Lists file containers or gets a file container properties.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsFileContainer
```

Lists the available file containers in the subscription.

### EXAMPLE 2
```
Get-AzsFileContainer -FileContainerId <ContainerID>
```

Get the file container with id \<ContainerID\>.

## PARAMETERS

### -FileContainerId
Container ID to fetch the properties for.

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


### -AsJson
Outputs the result in Json format.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
