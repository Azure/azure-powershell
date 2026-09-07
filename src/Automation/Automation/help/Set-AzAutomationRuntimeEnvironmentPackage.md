---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version: https://learn.microsoft.com/powershell/module/az.automation/set-azautomationruntimeenvironmentpackage
schema: 2.0.0
---

# Set-AzAutomationRuntimeEnvironmentPackage

## SYNOPSIS
Updates a Package in a Runtime Environment in Azure Automation.

## SYNTAX

### ByName (Default)
```
Set-AzAutomationRuntimeEnvironmentPackage [-RuntimeEnvironmentName] <String> [-Name] <String> [-ContentUri <String>] [-ContentVersion <String>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzAutomationRuntimeEnvironmentPackage** cmdlet updates an existing Package in a Runtime Environment within an Azure Automation account. You can update the content URI and/or version of the package.

## EXAMPLES

### Example 1: Update the content URI of a package
```powershell
Set-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "PowerShell-7.4" -Name "MyModule" -ContentUri "https://mystorageaccount.blob.core.windows.net/modules/MyModule-v2.zip"
```

This command updates the content URI of the package named "MyModule" in the runtime environment named "PowerShell-7.4".

### Example 2: Update the version of a package
```powershell
Set-AzAutomationRuntimeEnvironmentPackage -AutomationAccountName "Contoso17" -ResourceGroupName "ResourceGroup01" -RuntimeEnvironmentName "Python-3.10" -Name "requests" -ContentUri "https://pypi.org/packages/requests-2.32.0.tar.gz" -ContentVersion "2.32.0"
```

This command updates the Python package named "requests" to version "2.32.0" in the runtime environment named "Python-3.10".

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

### -ContentUri
The URI to the package content. This can be a blob storage URL, PyPI URL, or PowerShell Gallery URL.

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

### -ContentVersion
The version of the package content.

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

### Microsoft.Azure.Commands.Automation.Model.RuntimeEnvironmentPackage

## NOTES

## RELATED LINKS

[Get-AzAutomationRuntimeEnvironmentPackage](./Get-AzAutomationRuntimeEnvironmentPackage.md)

[New-AzAutomationRuntimeEnvironmentPackage](./New-AzAutomationRuntimeEnvironmentPackage.md)

[Remove-AzAutomationRuntimeEnvironmentPackage](./Remove-AzAutomationRuntimeEnvironmentPackage.md)
