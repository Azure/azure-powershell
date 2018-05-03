---
external help file: Microsoft.Azure.Commands.AnalysisServices.Dataplane.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.analysisservices/restart-azureanalysisservicesinstance
schema: 2.0.0
---

# Restart-AzureAnalysisServicesInstance

## SYNOPSIS
Restarts an instance of Analysis Services server in the currently logged in Environment as specified in Add-AzureAnalysisServicesAccount command

## SYNTAX

```
Restart-AzureAnalysisServicesInstance [-Instance] <String> [-PassThru] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Restart-AzureAnalysisServicesInstance cmdlet restarts an instance of Azure Analysis Services server

## EXAMPLES

### Example 1
```
PS C:\>Restart-AzureAnalysisServicesInstance
Instance: testserver
```

This command will restart the server 'testserver' in the environment specified in the Add-AzureAnalysisServicesAccount command

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

### -PassThru
Specifying this will return true if the command was successful.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### System.Boolean

## NOTES
Alias: Restart-AzureAsInstance

## RELATED LINKS

