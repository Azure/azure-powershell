---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmVMRunCommand

## SYNOPSIS
Get or list available Run command(s).

## SYNTAX

```
Get-AzureRmVMRunCommand [[-Location] <String>] [[-CommandId] <String>] [<CommonParameters>]
```

## DESCRIPTION
Get or list available Run command(s).

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVMRunCommand -Location $loc -CommandId $commandId
```

Get an available Run command with the given ID in the location.

## PARAMETERS

### -CommandId
The run command id.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the location of a Run command.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRunCommandDocument

## NOTES

## RELATED LINKS

