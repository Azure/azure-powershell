---
external help file: Microsoft.Azure.Commands.AnalysisServices.Dataplane.dll-Help.xml
online version: 
schema: 2.0.0
---

# Show-AzureAnalysisServicesInstance

## SYNOPSIS
Shows a log from an instance of Analysis Services server in the currently logged in Environment as specified in Add-AzureAnalysisServicesAccount command

## SYNTAX

```
Show-AzureAnalysisServicesInstanceLog [-Instance] <String> [-WhatIf]
```

## DESCRIPTION
The Restart-AzureAnalysisServicesInstance cmdlet restarts an instance of Azure Analysis Services server

## EXAMPLES

### Example 1
```
PS C:\>Show-AzureAnalysisServicesInstanceLog
Instance: testserver
```

This command will fetch log from the server 'testserver' in the environment specified in the Add-AzureAnalysisServicesAccount command

## PARAMETERS

### -Instance
Name of the Analysis Services server instance to restart

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS
Log file

## NOTES
Alias: Show-AzureAsInstanceLog

## RELATED LINKS

