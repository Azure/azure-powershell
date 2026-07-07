---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/set-azautomationruntimeenvironment
schema: 2.0.0
---

# Set-AzAutomationRuntimeEnvironment

## SYNOPSIS
Updates a Runtime Environment in Azure Automation.

## SYNTAX

### ByName (Default)
```
Set-AzAutomationRuntimeEnvironment [-Name] <String> [-DefaultPackages <Hashtable>] [-Description <String>]
 [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzAutomationRuntimeEnvironment** cmdlet updates an existing Runtime Environment in an Azure Automation account. You can update the default packages and description of the runtime environment. The language and version cannot be changed after creation.

## EXAMPLES

### Example 1: Update the default packages of a runtime environment
```powershell
$packages = @{"Az"="12.4.0"; "Az.Accounts"="3.0.0"}
Set-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-7.4-Prod" -DefaultPackages $packages
```

This command updates the default packages of the runtime environment named "PowerShell-7.4-Prod".

### Example 2: Update the description of a runtime environment
```powershell
Set-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "Python-3.10-DataOps" -Description "Updated Python environment for data operations and analytics"
```

This command updates the description of the runtime environment named "Python-3.10-DataOps".

### Example 3: Update both packages and description
```powershell
$packages = @{"requests"="2.31.0"; "pandas"="2.0.0"}
Set-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "Python-3.10-DataOps" -DefaultPackages $packages -Description "Analytics runtime with updated packages"
```

This command updates both the default packages and description of the runtime environment.

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

### -DefaultPackages
The default packages for the runtime environment as a hashtable of package name to version.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### -Description
The description of the runtime environment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.RuntimeEnvironment

## NOTES

## RELATED LINKS

[Get-AzAutomationRuntimeEnvironment](./Get-AzAutomationRuntimeEnvironment.md)

[New-AzAutomationRuntimeEnvironment](./New-AzAutomationRuntimeEnvironment.md)

[Remove-AzAutomationRuntimeEnvironment](./Remove-AzAutomationRuntimeEnvironment.md)
