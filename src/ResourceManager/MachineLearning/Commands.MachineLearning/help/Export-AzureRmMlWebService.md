---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-help.xml
online version: 
schema: 2.0.0
---

# Export-AzureRmMlWebService

## SYNOPSIS
Exports the web service definition object as a JSON formatted string.

## SYNTAX

### Export to file.
```
Export-AzureRmMlWebService -WebService <WebService> -OutputFile <String> [-Force] [-WhatIf] [-Confirm]
```

### Export to JSON string.
```
Export-AzureRmMlWebService -WebService <WebService> [-ToJsonString] [-Force] [-WhatIf] [-Confirm]
```

## DESCRIPTION
Exports the definition object for the specified web servive as a JSON formatted string.
You can return the string immediately or save it to a file.

## EXAMPLES

### --------------------------  Example 1: Export as string  --------------------------
@{paragraph=PS C:\\\>}

```
Export-AzureRmMlWebService -WebService $svc -ToJsonString
```

### --------------------------  Example 2: Export to file  --------------------------
@{paragraph=PS C:\\\>}

```
Export-AzureRmMlWebService -WebService $svc -OutputFile "C:\mlservice.json"
```

## PARAMETERS

### -Force
Do not ask for confirmation.

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

### -OutputFile
The file path for exported definition.

```yaml
Type: String
Parameter Sets: Export to file.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToJsonString
Specifies that the definition will be exported as a JSON string.

```yaml
Type: SwitchParameter
Parameter Sets: Export to JSON string.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebService
The web service definition object to be exported.

```yaml
Type: WebService
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

## OUTPUTS

### None

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS

