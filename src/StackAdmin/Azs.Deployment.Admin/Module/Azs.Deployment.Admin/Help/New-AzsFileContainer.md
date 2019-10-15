---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# New-AzsFileContainer

## SYNOPSIS
Creates a new file container.

## SYNTAX

```
New-AzsFileContainer [-FileContainerId] <String> [-SourceUri] <Uri> [[-PostCopyAction] <String>]
 [[-ApiVersion] <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new file container from a soucre Uri.

## EXAMPLES

### EXAMPLE 1
```
New-AzsFileContainer -FileContainerId $ContainerId -SourceUri $packageUri -PostCopyAction Unzip
```

Creates a new file container from the specified values.

## PARAMETERS

### -FileContainerId
Container ID to be given to the new container.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceUri
The remote file location URI for the container.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostCopyAction
The file post copy action.

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


### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
