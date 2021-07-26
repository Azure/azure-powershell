---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module/az.ContainerInstance/new-AzContainerInstancePortObject
schema: 2.0.0
---

# New-AzContainerInstancePortObject

## SYNOPSIS
Create a in-memory object for ContainerPort

## SYNTAX

```
New-AzContainerInstancePortObject -Port <Int32> [-Protocol <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ContainerPort

## EXAMPLES

### Example 1: Specify port 8000 exposed on a container instance with TCP protocol
```powershell
PS C:\> New-AzContainerInstancePortObject -Port 8000 -Protocol TCP

Port Protocol
----- --------
8000  TCP
```

This command specifies port 8000 exposed on the container instance with TCP protocol.

## PARAMETERS

### -Port
The port number exposed within the container group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
The protocol associated with the port.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPort

## NOTES

ALIASES

## RELATED LINKS

