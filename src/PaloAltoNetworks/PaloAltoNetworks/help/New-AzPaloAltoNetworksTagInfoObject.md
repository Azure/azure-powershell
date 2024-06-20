---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/Az.PaloAltoNetworks/new-azpaloaltonetworkstaginfoobject
schema: 2.0.0
---

# New-AzPaloAltoNetworksTagInfoObject

## SYNOPSIS
Create an in-memory object for TagInfo.

## SYNTAX

```
New-AzPaloAltoNetworksTagInfoObject -Key <String> -Value <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TagInfo.

## EXAMPLES

### Example 1: Create an in-memory object for TagInfo.
```powershell
New-AzPaloAltoNetworksTagInfoObject -Key "abc" -Value "123"
```

```output
Key Value
--- -----
abc 123
```

Create an in-memory object for TagInfo.

## PARAMETERS

### -Key
tag name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
tag value.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.TagInfo

## NOTES

## RELATED LINKS
