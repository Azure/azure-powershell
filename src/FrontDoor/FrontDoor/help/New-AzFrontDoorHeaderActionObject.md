---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorheaderactionobject
schema: 2.0.0
---

# New-AzFrontDoorHeaderActionObject

## SYNOPSIS
Create an in-memory object for HeaderAction.

## SYNTAX

```
New-AzFrontDoorHeaderActionObject -HeaderActionType <String> -HeaderName <String> [-Value <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HeaderAction.

## EXAMPLES

### Example 1 :Creates PSHeaderAction object for the creation of PSRulesEngineAction object.
```powershell
New-AzFrontDoorHeaderActionObject -HeaderName headername -HeaderActionType Append
```

```output
HeaderActionType HeaderName Value
---------------- ---------- -----
Append           headername
```

Creates PSHeaderAction object for the creation of PSRulesEngineAction object.

## PARAMETERS

### -HeaderActionType
Which type of manipulation to apply to the header.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderName
The name of the header this action will apply to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The value to update the given header name with.
This value is not used if the actionType is Delete.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.HeaderAction

## NOTES

## RELATED LINKS
