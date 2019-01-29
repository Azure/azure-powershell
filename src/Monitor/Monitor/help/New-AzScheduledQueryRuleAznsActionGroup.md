---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version:
schema: 2.0.0
---

# New-AzScheduledQueryRuleAznsActionGroup

## SYNOPSIS
Creates an object of type Azns Action Group

## SYNTAX

```
New-AzScheduledQueryRuleAznsActionGroup [-ActionGroup <System.Collections.Generic.IList`1[System.String]>]
 [-EmailSubject <String>] [-CustomWebhookPayload <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates an object of type Azns Action Group.
This object is to be passed to the command that creates Log Alert Rule.

## EXAMPLES

### Example 1
```powershell
PS C:\> $aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup [] -EmailSubject "Email subject" -CustomWebhookPayload "{}"
```

## PARAMETERS

### -ActionGroup
The list of action groups to send notification to

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomWebhookPayload
The customized webhook payload

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

### -EmailSubject
The email subject of alert notification

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. 
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleAznsAction

## NOTES

## RELATED LINKS
