---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/Az.Datadog/new-AzDatadogFilteringTagObject
schema: 2.0.0
---

# New-AzDatadogFilteringTagObject

## SYNOPSIS
Create an in-memory object for FilteringTag.

## SYNTAX

```
New-AzDatadogFilteringTagObject [-Action <TagAction>] [-Name <String>] [-Value <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FilteringTag.

## EXAMPLES

### Example 1: Create a in-memory object for FilteringTag
```powershell
New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
```

This command Create a in-memory object for FilteringTag.

## PARAMETERS

### -Action
Valid actions for a filtering tag.
Exclusion takes priority over inclusion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name (also known as the key) of the tag.

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
The value of the tag.

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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTag

## NOTES

## RELATED LINKS
