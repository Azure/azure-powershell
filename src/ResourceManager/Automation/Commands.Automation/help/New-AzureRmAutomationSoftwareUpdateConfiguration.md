---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
Module Name: AzureRM.Automation
online version:
schema: 2.0.0
---

# New-AzureRmAutomationSoftwareUpdateConfiguration

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### Windows
```
New-AzureRmAutomationSoftwareUpdateConfiguration -Schedule <Schedule> [-Windows]
 [-AzureVMResourceIds <String[]>] [-NonAzureComputers <String[]>] [-Duration <TimeSpan>]
 [-IncludedUpdateClassifications <WindowsUpdateClasses[]>] [-ExcludedKbNumbers <String[]>]
 [-IncludedKbNumbers <String[]>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Linux
```
New-AzureRmAutomationSoftwareUpdateConfiguration -Schedule <Schedule> [-Linux] [-AzureVMResourceIds <String[]>]
 [-NonAzureComputers <String[]>] [-Duration <TimeSpan>]
 [-IncludedPackageClassifications <LinuxPackageClasses[]>] [-ExcludedPackageNameMasks <String[]>]
 [-IncludedPackageNameMasks <String[]>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AutomationAccountName
The automation account name.

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

### -AzureVMResourceIds
Resource Ids for azure virtual machines.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Duration
Maximum duration for the update.

```yaml
Type: TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExcludedKbNumbers
KB numbers of excluded updates.

```yaml
Type: String[]
Parameter Sets: Windows
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExcludedPackageNameMasks
Excluded Linux package masks.

```yaml
Type: String[]
Parameter Sets: Linux
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludedKbNumbers
KB numbers of included updates.

```yaml
Type: String[]
Parameter Sets: Windows
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludedPackageClassifications
Included Linux package classifications.

```yaml
Type: LinuxPackageClasses[]
Parameter Sets: Linux
Aliases:
Accepted values: Unclassified, Critical, Security, Other

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludedPackageNameMasks
Included Linux package masks.

```yaml
Type: String[]
Parameter Sets: Linux
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludedUpdateClassifications
Included Windows Update classifications.

```yaml
Type: WindowsUpdateClasses[]
Parameter Sets: Windows
Aliases:
Accepted values: Unclassified, Critical, Security, UpdateRollup, FeaturePack, ServicePack, Definition, Tools, Updates

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Linux
Indicates that the software update configuration targeting Linux operating system machines.

```yaml
Type: SwitchParameter
Parameter Sets: Linux
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NonAzureComputers
Non-Azure computer names.

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

### -ResourceGroupName
The resource group name.

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

### -Schedule
Schedule object used for software update configuration.

```yaml
Type: Schedule
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Windows
Indicates that the software update configuration targeting windows operating system machines.

```yaml
Type: SwitchParameter
Parameter Sets: Windows
Aliases:

Required: True
Position: Named
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Automation.Model.Schedule

### System.Management.Automation.SwitchParameter

### System.String[]

### System.TimeSpan

### Microsoft.Azure.Commands.Automation.Model.UpdateManagement.WindowsUpdateClasses[]

### Microsoft.Azure.Commands.Automation.Model.UpdateManagement.LinuxPackageClasses[]

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.UpdateManagement.SoftwareUpdateConfiguration

## NOTES

## RELATED LINKS
