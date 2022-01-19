---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-azstackhciremotesupportsessionhistory
schema: 2.0.0
---

# Get-AzStackHCIRemoteSupportSessionHistory

## SYNOPSIS
Gets Remote Support Session History Details.

## SYNTAX

```
Get-AzStackHCIRemoteSupportSessionHistory [[-SessionId] <String>] [-IncludeSessionTranscript] [[FromDate] <DateTime>]
```

## DESCRIPTION
Session history represents all remote accesses made by Microsoft Support for either Diagnostics or DiagnosticsRepair based on the Access Level granted.

## EXAMPLES

### EXAMPLE 1
```poweshell
PS C:\> Get-AzStackHCIRemoteSupportSessionHistory -SessionId 467e3234-13f4-42f2-9422-81db248930fa -IncludeSessionTranscript $true
```

## PARAMETERS

### -SessionId
Session Id to get details for a specific session. If omitted then lists all sessions starting from date 'FromDate'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: [System.String]::Empty
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeSessionTranscript
Indicates whether to include complete session transcript. Transcript provides details on all operations performed during the session.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromDate
Indicates date from where to start listing sessions from until now.

```yaml
Type: Microsoft.PowerShell.Utility.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

## INPUTS

## OUTPUTS

## RELATED LINKS
