---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/remove-azautomationruntimeenvironment
schema: 2.0.0
---

# Remove-AzAutomationRuntimeEnvironment

## SYNOPSIS
Removes a Runtime Environment from Azure Automation.

## SYNTAX

### ByName (Default)
```
Remove-AzAutomationRuntimeEnvironment [-Name] <String> [-Force] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzAutomationRuntimeEnvironment** cmdlet removes a Runtime Environment from an Azure Automation account. This operation cannot be undone, and any runbooks associated with this runtime environment will no longer be able to use it.

## EXAMPLES

### Example 1: Remove a runtime environment
```powershell
Remove-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-7.4-Prod"
```

```output
Confirm
Are you sure you want to remove RuntimeEnvironment 'PowerShell-7.4-Prod'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"):
```

This command prompts for confirmation and then removes the runtime environment named "PowerShell-7.4-Prod" from the automation account named Contoso17.

### Example 2: Remove a runtime environment without confirmation
```powershell
Remove-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-7.4-Prod" -Force
```

This command removes the runtime environment named "PowerShell-7.4-Prod" without prompting for confirmation.

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
Forces the command to run without asking for user confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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

[Get-AzAutomationRuntimeEnvironment](./Get-AzAutomationRuntimeEnvironment.md)

[New-AzAutomationRuntimeEnvironment](./New-AzAutomationRuntimeEnvironment.md)

[Set-AzAutomationRuntimeEnvironment](./Set-AzAutomationRuntimeEnvironment.md)
