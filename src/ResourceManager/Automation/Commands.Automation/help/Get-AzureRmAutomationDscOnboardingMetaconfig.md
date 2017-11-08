---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
Module Name: AzureRM.Automation
ms.assetid: FB331566-AC13-4751-A600-3A0E576308C7
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.automation/get-azurermautomationdsconboardingmetaconfig
schema: 2.0.0
---

# Get-AzureRmAutomationDscOnboardingMetaconfig

## SYNOPSIS
Creates meta-configuration .mof files.

## SYNTAX

```
Get-AzureRmAutomationDscOnboardingMetaconfig [-OutputFolder <String>] [-ComputerName <String[]>] [-Force]
 [-ResourceGroupName] <String> [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmAutomationDscOnboardingMetaconfig** cmdlet creates APS Desired State Configuration (DSC) meta-configuration Managed Object Format (MOF) files.
This cmdlet creates a .mof file for each computer name that you specify.
The cmdlet creates a folder for the .mof files.
You can run the Set-DscLocalConfigurationManager cmdlet for this folder to onboard these computers into an Azure Automation account as DSC nodes.

## EXAMPLES

### Example 1: Onboard servers to Automation DSC
```
PS C:\>Get-AzureRmAutomationDscOnboardingMetaconfig -ResourceGroupName "ResourceGroup03" -AutomationAccountName "Contoso17" -ComputerName "Server01", "Server02" -OutputFolder "C:\Users\PattiFuller\Desktop" 
PS C:\> Set-DscLocalConfigurationManager -Path "C:\Users\PattiFuller\Desktop\DscMetaConfigs" -ComputerName "Server01", "Server02"
```

The first command creates DSC meta-configuration files for two servers for the Automation account named Contoso17.
The command saves these files on a desktop.

The second command uses the **Set-DscLocalConfigurationManager** cmdlet to apply the meta-configuration to the specified computers to onboard them as DSC nodes.

## PARAMETERS

### -AutomationAccountName
Specifies the name of an Automation account.
You can onboard the computers that the *ComputerName* parameter specifies to the account that this parameter specifies.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ComputerName
Specifies an array of names of computers for which this cmdlet generates .mof files.
If you do not specify this parameter, the cmdlet generates an .mof file for the current computer (localhost).

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without prompting you for confirmation, and to replace existing .mof files that have the same name.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputFolder
Specifies the name of a folder where this cmdlet stores .mof files.

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

### -ResourceGroupName
Specifies the name of a resource group.
This cmdlet creates .mof files to onboard computers in the resource group that this parameter specifies.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.DscOnboardingMetaconfig

## NOTES

## RELATED LINKS

