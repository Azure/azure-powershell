---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/install-azconnectedmachinepatch
schema: 2.0.0
---

# Install-AzConnectedMachinePatch

## SYNOPSIS
The operation to install patches on a hybrid machine identity in Azure.

## SYNTAX

### InstallExpanded (Default)
```
Install-AzConnectedMachinePatch -Name <String> -ResourceGroupName <String> -MaximumDuration <String>
 -RebootSetting <VMGuestPatchRebootSetting> [-SubscriptionId <String>]
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InstallViaIdentityExpanded
```
Install-AzConnectedMachinePatch -InputObject <IConnectedMachineIdentity> -MaximumDuration <String>
 -RebootSetting <VMGuestPatchRebootSetting>
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to install patches on a hybrid machine identity in Azure.

## EXAMPLES

### Example 1: Install assess patches
```powershell
Install-AzConnectedMachinePatch -ResourceGroupName az-sdk-test -Name testMachine -MaximumDuration 'PT4H' -RebootSetting 'IfRequired' -WindowParameterClassificationsToInclude 'Critical'
```

```output
ExcludedPatchCount FailedPatchCount InstallationActivityId               InstalledPatchCount LastModifiedDateTime Maint
                                                                                                                  enanc
                                                                                                                  eWind
                                                                                                                  owExc
                                                                                                                  eeded
------------------ ---------------- ----------------------               ------------------- -------------------- -----
0                  0                cd3c2d11-2852-4558-8497-f6c805aa4361 0                   7/28/2023 7:55:08 AM  False
```

Install machine patches.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: InstallViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinuxParameterClassificationsToInclude
The update classifications to select when installing patches for Linux.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.VMGuestPatchClassificationLinux[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMasksToExclude
packages to exclude in the patch operation.
Format: packageName_packageVersion

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMasksToInclude
packages to include in the patch operation.
Format: packageName_packageVersion

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumDuration
Specifies the maximum amount of time that the operation will run.
It must be an ISO 8601-compliant duration string such as PT4H (4 hours)

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

### -Name
The name of the hybrid machine.

```yaml
Type: System.String
Parameter Sets: InstallExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -RebootSetting
Defines when it is acceptable to reboot a VM during a software update operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.VMGuestPatchRebootSetting
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: InstallExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: InstallExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterClassificationsToInclude
The update classifications to select when installing patches for Windows.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.VMGuestPatchClassificationWindows[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterExcludeKbsRequiringReboot
Filters out Kbs that don't have an InstallationRebootBehavior of 'NeverReboots' when this is set to true.

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

### -WindowParameterKbNumbersToExclude
Kbs to exclude in the patch operation

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterKbNumbersToInclude
Kbs to include in the patch operation

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterMaxPatchPublishDate
This is used to install patches that were published on or before this given max published date.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineInstallPatchesResult

## NOTES

## RELATED LINKS

