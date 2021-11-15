---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
ms.assetid: 2DC97415-D59A-428E-8FFE-56B17B320DAF
online version: https://docs.microsoft.com/powershell/module/az.automation/new-azautomationmodule
schema: 2.0.0
---

# New-AzAutomationModule

## SYNOPSIS
Imports a module into Automation.

## SYNTAX

```
New-AzAutomationModule [-Name] <String> [-ContentLinkUri] <Uri> [-ResourceGroupName] <String>
 [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzAutomationModule** cmdlet imports a module into Azure Automation.
This command accepts a compressed file that has a .zip file name extension.
The file contains a folder that includes a file that is one of the following types: 
- Windows PowerShell module, which has a .psm1 or .dll file name extension 
- Windows PowerShell module manifest, which has a .psd1 file name extension
The name of the .zip file, the name of the folder, and the name of the file in the folder must be the same.
Specify the .zip file as a URL that the Automation service can access.
If you import a Windows PowerShell module into Automation by using this cmdlet or the Set-AzAutomationModule cmdlet, the operation is asynchronous.
The command finishes whether the import succeeds or fails.
To check whether it succeeded, run the following command:
`PS C:\\\> $ModuleInstance = Get-AzAutomationModule -Name `ModuleName
Check the **ProvisioningState** property for a value of Succeeded.

## EXAMPLES

### Example 1: Import a module
```
PS C:\>New-AzAutomationModule -AutomationAccountName "Contoso17" -Name "ContosoModule" -ContentLink "http://contosostorage.blob.core.windows.net/modules/ContosoModule.zip" -ResourceGroupName "ResourceGroup01"
```

This command imports a module named ContosoModule into the Automation account named Contoso17.
The module is stored in an Azure blob in a storage account named contosostorage and a container named modules.

## PARAMETERS

### -AutomationAccountName
Specifies the name of the Automation account for which this cmdlet imports a module.

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

### -ContentLinkUri
The url to a module zip package

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases: ContentLink

Required: True
Position: 3
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
Specifies the name of the module that this cmdlet imports.

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
Specifies the name of a resource group for which this cmdlet imports a module.

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

### System.Uri

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.Module

## NOTES

## RELATED LINKS

[Get-AzAutomationModule](./Get-AzAutomationModule.md)

[Remove-AzAutomationModule](./Remove-AzAutomationModule.md)

[Set-AzAutomationModule](./Set-AzAutomationModule.md)


