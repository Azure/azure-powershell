---
external help file: Microsoft.Azure.Commands.AnalysisServices.Dataplane.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.analysisservices/export-azureanalysisservicesinstancelog
schema: 2.0.0
---

# Export-AzureAnalysisServicesInstance

## SYNOPSIS
Exports a log from an instance of Analysis Services server in the currently logged in Environment as specified in Add-AzureAnalysisServicesAccount command

## SYNTAX

```
Export-AzureAnalysisServicesInstanceLog [-Instance] <String> [-OutputPath] <String> [-WhatIf] [-Force]
```

## DESCRIPTION
The Export-AzureAnalysisServicesInstance cmdlet exports log from an instance of Azure Analysis Services server to file

## EXAMPLES

### Example 1
```
PS C:\>Export-AzureAnalysisServicesInstanceLog -Instance testserver -OuptutPath C:\path\to\log\testserver.log
```

This command will export log from the server 'testserver' in the environment specified in the Add-AzureAnalysisServicesAccount command
and save it to file specified in OutputPath 'C:\path\to\log\testserver.log'

## PARAMETERS

### -Instance
Name of the Analysis Services server instance

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

### -OutputPath
Output path to file to export log

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

### -Force
Overwrite file if exists without asking

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

## NOTES
Alias: Export-AzureAsInstanceLog

## RELATED LINKS

