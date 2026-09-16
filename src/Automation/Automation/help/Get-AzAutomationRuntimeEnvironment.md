---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/get-azautomationruntimeenvironment
schema: 2.0.0
---

# Get-AzAutomationRuntimeEnvironment

## SYNOPSIS
Gets a Runtime Environment from Azure Automation.

## SYNTAX

### ByAll (Default)
```
Get-AzAutomationRuntimeEnvironment [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzAutomationRuntimeEnvironment [-Name] <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAutomationRuntimeEnvironment** cmdlet gets a specific Runtime Environment or a list of all Runtime Environments in an Azure Automation account. Runtime Environments define the language runtime (PowerShell or Python) and version to use when executing runbooks.

## EXAMPLES

### Example 1: Get all runtime environments in an automation account
```powershell
Get-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01"
```

This command gets all runtime environments in the automation account named Contoso17.

### Example 2: Get a specific runtime environment by name
```powershell
Get-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-7.4"
```

This command gets the runtime environment named "PowerShell-7.4" from the automation account named Contoso17.

## PARAMETERS

### -AutomationAccountName
The automation account name.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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
The runtime environment name.

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
The resource group name.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.RuntimeEnvironment

## NOTES

## RELATED LINKS

[New-AzAutomationRuntimeEnvironment](./New-AzAutomationRuntimeEnvironment.md)

[Set-AzAutomationRuntimeEnvironment](./Set-AzAutomationRuntimeEnvironment.md)

[Remove-AzAutomationRuntimeEnvironment](./Remove-AzAutomationRuntimeEnvironment.md)
