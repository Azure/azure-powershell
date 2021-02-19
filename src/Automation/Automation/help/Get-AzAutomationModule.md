---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
ms.assetid: A73B388A-E859-40D3-BA63-0E231CF1E81D
online version: https://docs.microsoft.com/powershell/module/az.automation/get-azautomationmodule
schema: 2.0.0
---

# Get-AzAutomationModule

## SYNOPSIS
Gets metadata for modules from Automation.

## SYNTAX

### ByAll (Default)
```
Get-AzAutomationModule [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzAutomationModule [-Name] <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAutomationModule** cmdlet gets metadata for modules from Azure Automation.

## EXAMPLES

### Example 1: Get all modules
```
PS C:\>Get-AzAutomationModule -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01"
```

This command gets all modules in the Automation account named Contoso17.

### Example 2: Get a module
```
PS C:\>Get-AzAutomationModule -AutomationAccountName "Contoso17" -Name "ContosoModule" -ResourceGroupName "ResourceGroup01"
```

This command gets a module named ContosoModule in the Automation account named Contoso17.

## PARAMETERS

### -AutomationAccountName
Specifies the name of the Automation account for which this cmdlet gets module metadata.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the module for which this cmdlet gets metadata.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group for which this cmdlet gets module metadata.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.Module

## NOTES

## RELATED LINKS

[New-AzAutomationModule](./New-AzAutomationModule.md)

[Remove-AzAutomationModule](./Remove-AzAutomationModule.md)

[Set-AzAutomationModule](./Set-AzAutomationModule.md)


