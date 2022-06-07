---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-azstackhciremotesupportsessionhistory
schema: 2.0.0
---

# Get-AzStackHCIRemoteSupportSessionHistory

## SYNOPSIS
Gets Remote Support Session History Details.

## SYNTAX

```
Get-AzStackHCIRemoteSupportSessionHistory [[-SessionId] <String>] [[-FromDate] <DateTime>]
 [-IncludeSessionTranscript] [<CommonParameters>]
```

## DESCRIPTION
Session history represents all remote accesses made by Microsoft Support for either Diagnostics or DiagnosticsRepair based on the Access Level granted.

## EXAMPLES

### Example 1:
```powershell
Get-AzStackHCIRemoteSupportSessionHistory 
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Listing Session History for last '7' days.
No remote support session exists.
```

Gets Session Transcript for the particular session Id when access was made by Microsoft Support for either Diagnostics or DiagnosticsRepair based on the Access Level granted.

## PARAMETERS

### -FromDate
Optional.
Defaults to last 7 days.
Indicates date from where to start listing sessions from until now.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeSessionTranscript
Optional.
Defaults to false.
Indicates whether to include complete session transcript.
Transcript provides details on all operations performed during the session.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionId
Optional.
Session Id to get details for a specific session.
If omitted then lists all sessions starting from date 'FromDate'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

