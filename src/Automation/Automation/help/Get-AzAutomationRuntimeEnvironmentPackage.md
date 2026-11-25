---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/get-azautomationruntimeenvironmentpackage
schema: 2.0.0
---

# Get-AzAutomationRuntimeEnvironmentPackage

## SYNOPSIS
Gets a Package from a Runtime Environment in Azure Automation.

## SYNTAX

### ByAll (Default)
```
Get-AzAutomationRuntimeEnvironmentPackage [-RuntimeEnvironmentName] <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzAutomationRuntimeEnvironmentPackage [-RuntimeEnvironmentName] <String> [-Name] <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAutomationRuntimeEnvironmentPackage** cmdlet gets a specific Package or a list of all Packages in a Runtime Environment within an Azure Automation account. Packages are PowerShell modules or Python packages that are available for runbooks executing in the specified Runtime Environment.

## EXAMPLES

### Example 1: Get all packages in a runtime environment
```powershell
Get-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "PowerShell-7.4"
```

This command gets all packages in the runtime environment named "PowerShell-7.4" in the automation account named Contoso17.

### Example 2: Get a specific package by name
```powershell
Get-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "PowerShell-7.4" -Name "Az.Accounts"
```

This command gets the package named "Az.Accounts" from the runtime environment named "PowerShell-7.4" in the automation account named Contoso17.

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
The package name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: 3
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

### -RuntimeEnvironmentName
The runtime environment name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.RuntimeEnvironmentPackage

## NOTES

## RELATED LINKS

[New-AzAutomationRuntimeEnvironmentPackage](./New-AzAutomationRuntimeEnvironmentPackage.md)

[Set-AzAutomationRuntimeEnvironmentPackage](./Set-AzAutomationRuntimeEnvironmentPackage.md)

[Remove-AzAutomationRuntimeEnvironmentPackage](./Remove-AzAutomationRuntimeEnvironmentPackage.md)
