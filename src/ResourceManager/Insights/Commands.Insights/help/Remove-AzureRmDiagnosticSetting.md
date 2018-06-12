---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
Module Name: AzureRM.Insights
ms.assetid: B5F2388E-0136-4F8A-8577-67CE2A45671E
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.insights/set-azurermdiagnosticsetting
schema: 2.0.0
---

# Set-AzureRmDiagnosticSetting

## SYNOPSIS
Remove a diagnostic setting for the a resource.

## SYNTAX

```
Remove-AzureRmDiagnosticSetting -ResourceId <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmDiagnosticSetting** cmdlet removes the diagnostic setting for the particular resource.

This cmdlet implements the ShouldProcess pattern, i.e. it might request confirmation from the user before actually creating, modifying, or removing the resource.

## EXAMPLES

### Example 1: Remove the default diagnostic setting (service) for a resource
```
PS C:\>Remove-AzureRmDiagnosticSetting -ResourceId "Resource01"
```

This command removes the default diagnostic setting (service) for the resource called Resource01.

### Example 2: Remove the default diagnostic setting identified by the given name for a resource
```
PS C:\>Remove-AzureRmDiagnosticSetting -ResourceId "Resource01" -Name myDiagSetting
```

This command removes the diagnostic setting called myDiagSetting for the resource called Resource01.

## PARAMETERS

### -Name
The name of the diagnostic setting. If not given the call default to "service" as it was in the previous API

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Specifies the ID of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.OperationResponse

## NOTES

## RELATED LINKS

[Get-AzureRmDiagnosticSetting](./Get-AzureRmDiagnosticSetting.md)
[Set-AzureRmDiagnosticSetting](./Set-AzureRmDiagnosticSetting.md)

