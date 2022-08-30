---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/invoke-azvminstallpatch
schema: 2.0.0
---

# Invoke-AzVMInstallPatch

## SYNOPSIS
Installs patches on the VM

## SYNTAX

### WindowsDefaultParameterSet (Default)
```
Invoke-AzVMInstallPatch -ResourceGroupName <String> -VMName <String> [-Windows] -RebootSetting <String>
 -MaximumDuration <String> [-KBNumberToInclude <String[]>] [-KBNumberToExclude <String[]>]
 [-ExcludeKBsRequiringReboot] [-ClassificationToIncludeForWindows <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinuxDefaultParameterSet
```
Invoke-AzVMInstallPatch -ResourceGroupName <String> -VMName <String> [-Linux] -RebootSetting <String>
 -MaximumDuration <String> [-PackageNameMaskToInclude <String[]>] [-PackageNameMaskToExclude <String[]>]
 [-ClassificationToIncludeForLinux <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### WindowsResourceIDParameterSet
```
Invoke-AzVMInstallPatch -ResourceId <String> [-Windows] -RebootSetting <String> -MaximumDuration <String>
 [-KBNumberToInclude <String[]>] [-KBNumberToExclude <String[]>] [-ExcludeKBsRequiringReboot]
 [-ClassificationToIncludeForWindows <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### LinuxResourceIDParameterSet
```
Invoke-AzVMInstallPatch -ResourceId <String> [-Linux] -RebootSetting <String> -MaximumDuration <String>
 [-PackageNameMaskToInclude <String[]>] [-PackageNameMaskToExclude <String[]>]
 [-ClassificationToIncludeForLinux <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### WindowsInputObjectParameterSet
```
Invoke-AzVMInstallPatch [-VM] <PSVirtualMachine> [-Windows] -RebootSetting <String> -MaximumDuration <String>
 [-KBNumberToInclude <String[]>] [-KBNumberToExclude <String[]>] [-ExcludeKBsRequiringReboot]
 [-ClassificationToIncludeForWindows <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### LinuxInputObjectParameterSet
```
Invoke-AzVMInstallPatch [-VM] <PSVirtualMachine> [-Linux] -RebootSetting <String> -MaximumDuration <String>
 [-PackageNameMaskToInclude <String[]>] [-PackageNameMaskToExclude <String[]>]
 [-ClassificationToIncludeForLinux <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Installs patches on the VM

## EXAMPLES

### Example 1
```powershell
Invoke-AzVmInstallPatch -ResourceGroupName 'MyRG' -VmName 'MyVM' -Windows -RebootSetting 'never' -MaximumDuration PT2H -ClassificationToIncludeForWindows Critical
```

This example installs critical patches on the VM. 

### Example 2
```powershell
$myVM = Get-AzVM -ResourceGroupName 'MyRG' -Name 'MyVM'
Invoke-AzVmInstallPatch -VM $myVM -MaximumDuration "PT90M" -RebootSetting "Always" -Windows -ClassificationToIncludeForWindows "Security" -KBNumberToInclude "KB1234567", "KB123567" -KBNumberToExclude "KB1234702", "KB1234802" -ExcludeKBsRequiringReboot
```

This example passes a PSVirtualMachine object to '-VM' parameter. It also installs security patches while including and excluding certain KBs by using '-KBNumberToExclude' and '-KBNumberToInclude'. It also excludes KBs that require reboot by using '-ExcludeKBsRequiringReboot'.

### Example 3
```powershell
$myLinuxVM = Get-AzVM -ResourceGroupName 'MyRG' -Name 'MyLinuxVM'
Invoke-AzVMInstallPatch -ResourceId $myLinuxVM.id -MaximumDuration "PT90M" -RebootSetting "Always" -Linux -ClassificationToIncludeForLinux "Security" -PackageNameMaskToInclude "package123" -PackageNameMaskToExclude "package567"
```

This example installs certain packages to the Linux VM provided by Resource ID. 

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationToIncludeForLinux
The update classifications to select when installing patches.
Possible values differ for Windows and Linux.

```yaml
Type: System.String[]
Parameter Sets: LinuxDefaultParameterSet, LinuxResourceIDParameterSet, LinuxInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationToIncludeForWindows
The update classifications to select when installing patches.
Possible values differ for Windows and Linux.

```yaml
Type: System.String[]
Parameter Sets: WindowsDefaultParameterSet, WindowsResourceIDParameterSet, WindowsInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -ExcludeKBsRequiringReboot
Filters out KBs that don't have a reboot behavior of 'NeverReboots' when this is set.
This parameter is only available for Windows VM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsDefaultParameterSet, WindowsResourceIDParameterSet, WindowsInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KBNumberToExclude
KBs to exclude in the patch operation.
This parameter is only available for Windows VM.

```yaml
Type: System.String[]
Parameter Sets: WindowsDefaultParameterSet, WindowsResourceIDParameterSet, WindowsInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KBNumberToInclude
KBs to include in the patch operation.
This parameter is only available for Windows VM.

```yaml
Type: System.String[]
Parameter Sets: WindowsDefaultParameterSet, WindowsResourceIDParameterSet, WindowsInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Linux
For Linux VM

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LinuxDefaultParameterSet, LinuxResourceIDParameterSet, LinuxInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumDuration
Specifies the maximum amount of time that the operation will run.
It must be an ISO 8601-compliant duration string such as PT2H (2 hours).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageNameMaskToExclude
Packages to exclude in the patch operation.
Format: packageName_packageVersion.
This parameter is only available for Linux VM.

```yaml
Type: System.String[]
Parameter Sets: LinuxDefaultParameterSet, LinuxResourceIDParameterSet, LinuxInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageNameMaskToInclude
Packages to include in the patch operation.
Format: packageName_packageVersion.
This parameter is only available for Linux VM.

```yaml
Type: System.String[]
Parameter Sets: LinuxDefaultParameterSet, LinuxResourceIDParameterSet, LinuxInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RebootSetting
Defines when it is acceptable to reboot a VM during a software update operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: WindowsDefaultParameterSet, LinuxDefaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource ID for your virtual machine.

```yaml
Type: System.String
Parameter Sets: WindowsResourceIDParameterSet, LinuxResourceIDParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -VM
PowerShell Virtual Machine Object

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: WindowsInputObjectParameterSet, LinuxInputObjectParameterSet
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -VMName
Virtual Machine name

```yaml
Type: System.String
Parameter Sets: WindowsDefaultParameterSet, LinuxDefaultParameterSet
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Windows
For Windows VM

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsDefaultParameterSet, WindowsResourceIDParameterSet, WindowsInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineInstallPatchesResult

## NOTES

## RELATED LINKS
