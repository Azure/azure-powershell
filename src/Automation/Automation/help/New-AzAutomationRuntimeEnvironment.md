---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/new-azautomationruntimeenvironment
schema: 2.0.0
---

# New-AzAutomationRuntimeEnvironment

## SYNOPSIS
Creates a new Runtime Environment in Azure Automation.

## SYNTAX

```
New-AzAutomationRuntimeEnvironment [-Name] <String> [-Language] <String> [-Version] <String>
 [-Location <String>] [-DefaultPackages <Hashtable>] [-Description <String>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzAutomationRuntimeEnvironment** cmdlet creates a new Runtime Environment in an Azure Automation account. A Runtime Environment defines the language runtime (PowerShell or Python) and version to use when executing runbooks, along with any default packages that should be available. The location is inherited from the parent Automation Account.

## EXAMPLES

### Example 1: Create a PowerShell 7.4 runtime environment
```powershell
New-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-7.4-Prod" -Language "PowerShell" -Version "7.4"
```

This command creates a new PowerShell 7.4 runtime environment named "PowerShell-7.4-Prod" in the automation account named Contoso17. The location is inherited from the Automation Account.

### Example 2: Create a Python runtime environment with default packages
```powershell
$packages = @{"azure-storage-blob"="12.14.0"; "requests"="2.28.1"}
New-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "Python-3.10-DataOps" -Language "Python" -Version "3.10" -DefaultPackages $packages -Description "Python environment for data operations"
```

This command creates a Python 3.10 runtime environment with pre-installed packages for data operations.

### Example 3: Create a PowerShell 5.1 runtime environment with Az module
```powershell
$packages = @{"Az"="12.3.0"}
New-AzAutomationRuntimeEnvironment -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -Name "PowerShell-5.1-Legacy" -Language "PowerShell" -Version "5.1" -DefaultPackages $packages
```

This command creates a PowerShell 5.1 runtime environment with the Az module pre-installed.

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

### -Language
The language of the runtime environment. Valid values are 'PowerShell' or 'Python'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: PowerShell, Python

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The Azure region for the runtime environment. If not specified, uses the Automation Account location.

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
Parameter Sets: (All)
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

### -Version
The version of the language runtime. For PowerShell: '7.4', '7.2', '5.1'. For Python: '3.10', '3.8'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 5
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

[Set-AzAutomationRuntimeEnvironment](./Set-AzAutomationRuntimeEnvironment.md)

[Remove-AzAutomationRuntimeEnvironment](./Remove-AzAutomationRuntimeEnvironment.md)
