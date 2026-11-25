---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/remove-azautomationruntimeenvironmentpackage
schema: 2.0.0
---

# Remove-AzAutomationRuntimeEnvironmentPackage

## SYNOPSIS
Removes a Package from a Runtime Environment in Azure Automation.

## SYNTAX

### ByName (Default)
```
Remove-AzAutomationRuntimeEnvironmentPackage [-RuntimeEnvironmentName] <String> [-Name] <String> [-Force] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzAutomationRuntimeEnvironmentPackage** cmdlet removes a Package from a Runtime Environment within an Azure Automation account. Once removed, the package will no longer be available for runbooks executing in the specified Runtime Environment.

## EXAMPLES

### Example 1: Remove a package from a runtime environment
```powershell
Remove-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "PowerShell-7.4" -Name "MyModule"
```

This command removes the package named "MyModule" from the runtime environment named "PowerShell-7.4" in the automation account named Contoso17.

### Example 2: Remove a package without confirmation
```powershell
Remove-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "Python-3.10" -Name "requests" -Force
```

This command removes the Python package named "requests" from the runtime environment named "Python-3.10" without prompting for confirmation.

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

### -Force
Confirm the removal of the package without prompting.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The package name.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Get-AzAutomationRuntimeEnvironmentPackage](./Get-AzAutomationRuntimeEnvironmentPackage.md)

[New-AzAutomationRuntimeEnvironmentPackage](./New-AzAutomationRuntimeEnvironmentPackage.md)

[Set-AzAutomationRuntimeEnvironmentPackage](./Set-AzAutomationRuntimeEnvironmentPackage.md)
