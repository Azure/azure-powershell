---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
ms.assetid: 32CF9BF7-519F-4B5D-9F2B-3CC556A77A48
online version: https://docs.microsoft.com/powershell/module/az.automation/start-azautomationdsccompilationjob
schema: 2.0.0
---

# Start-AzAutomationDscCompilationJob

## SYNOPSIS
Compiles a DSC configuration in Automation.

## SYNTAX

```
Start-AzAutomationDscCompilationJob [-ConfigurationName] <String> [-Parameters <IDictionary>]
 [-ConfigurationData <IDictionary>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-IncrementNodeConfigurationBuild] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzAutomationDscCompilationJob** cmdlet compiles an APS Desired State Configuration (DSC) configuration in Azure Automation.

## EXAMPLES

### Example 1: Compile an Azure DSC configuration in Automation
```
PS C:\>$Params = @{"StringParam"="Hello World";"IntegerParam"=32}
PS C:\> Start-AzAutomationDscCompilationJob -ConfigurationName "Config01" -Parameters $Params -ResourceGroupName "ResourceGroup01"
```

The first command creates a dictionary of parameters, and stores them in the $Params variable.
The second command compiles the DSC configuration named Config01.
The command includes the values in $Params for DSC configuration parameters.

### Example 2: Compile an Azure DSC configuration in Automation with a new Node Configuration build version.
```
PS C:\>$Params = @{"StringParam"="Hello World";"IntegerParam"=32}
PS C:\> Start-AzAutomationDscCompilationJob -ConfigurationName "Config01" -Parameters $Params -ResourceGroupName "ResourceGroup01" -IncrementNodeConfigurationBuild
```

Similar to the first example, the first command creates a dictionary of parameters, and stores them in the $Params variable.
The second command compiles the DSC configuration named Config01.
The command includes the values in $Params for DSC configuration parameters.
It does not override the earlier existing Node Configuration by creating a new Node Configuration with the name Config01[<2>].<NodeName>. 
The version number is incremented based on the existing version number already present.

## PARAMETERS

### -AutomationAccountName
Specifies the name of the Automation account that contains the DSC configuration that this cmdlet compiles.

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

### -ConfigurationData
Specifies a dictionary of configuration data for DSC configuration.

```yaml
Type: System.Collections.IDictionary
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationName
Specifies the name of the DSC configuration that this cmdlet compiles.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 2
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

### -IncrementNodeConfigurationBuild
Creates a new Node Configuration build version.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Specifies a dictionary of parameters that this cmdlet uses to compile the DSC configuration.

```yaml
Type: System.Collections.IDictionary
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group in which this cmdlet compiles a configuration.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.CompilationJob

## NOTES

## RELATED LINKS

[Get-AzAutomationDscCompilationJob](./Get-AzAutomationDscCompilationJob.md)

[Get-AzAutomationDscCompilationJobOutput](./Get-AzAutomationDscCompilationJobOutput.md)


