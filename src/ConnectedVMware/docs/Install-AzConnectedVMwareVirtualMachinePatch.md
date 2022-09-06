---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/install-azconnectedvmwarevirtualmachinepatch
schema: 2.0.0
---

# Install-AzConnectedVMwareVirtualMachinePatch

## SYNOPSIS
The operation to install patches on a vSphere VMware machine identity in Azure.

## SYNTAX

### InstallExpanded (Default)
```
Install-AzConnectedVMwareVirtualMachinePatch -Name <String> -ResourceGroupName <String>
 -MaximumDuration <String> -RebootSetting <VMGuestPatchRebootSetting> [-SubscriptionId <String>]
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Install
```
Install-AzConnectedVMwareVirtualMachinePatch -Name <String> -ResourceGroupName <String>
 -InstallPatchesInput <IVirtualMachineInstallPatchesParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InstallViaIdentity
```
Install-AzConnectedVMwareVirtualMachinePatch -InputObject <IConnectedVMwareIdentity>
 -InstallPatchesInput <IVirtualMachineInstallPatchesParameters> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InstallViaIdentityExpanded
```
Install-AzConnectedVMwareVirtualMachinePatch -InputObject <IConnectedVMwareIdentity> -MaximumDuration <String>
 -RebootSetting <VMGuestPatchRebootSetting>
 [-LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]
 [-LinuxParameterPackageNameMasksToExclude <String[]>] [-LinuxParameterPackageNameMasksToInclude <String[]>]
 [-WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]
 [-WindowParameterExcludeKbsRequiringReboot] [-WindowParameterKbNumbersToExclude <String[]>]
 [-WindowParameterKbNumbersToInclude <String[]>] [-WindowParameterMaxPatchPublishDate <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to install patches on a vSphere VMware machine identity in Azure.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: InstallViaIdentity, InstallViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstallPatchesInput
Input for InstallPatches as directly received by the API
To construct, see NOTES section for INSTALLPATCHESINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IVirtualMachineInstallPatchesParameters
Parameter Sets: Install, InstallViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.VMGuestPatchClassificationLinux[]
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the vSphere VMware machine.

```yaml
Type: System.String
Parameter Sets: Install, InstallExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.VMGuestPatchRebootSetting
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: Install, InstallExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: Install, InstallExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Support.VMGuestPatchClassificationWindows[]
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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
Parameter Sets: InstallExpanded, InstallViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IVirtualMachineInstallPatchesParameters

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IVirtualMachineInstallPatchesResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IConnectedVMwareIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: Name of the cluster.
  - `[DatastoreName <String>]`: Name of the datastore.
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[HostName <String>]`: Name of the host.
  - `[Id <String>]`: Resource identity path
  - `[InventoryItemName <String>]`: Name of the inventoryItem.
  - `[MetadataName <String>]`: Name of the hybridIdentityMetadata.
  - `[Name <String>]`: The name of the vSphere VMware machine.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourcePoolName <String>]`: Name of the resourcePool.
  - `[SubscriptionId <String>]`: The Subscription ID.
  - `[VcenterName <String>]`: Name of the vCenter.
  - `[VirtualMachineName <String>]`: Name of the virtual machine resource.
  - `[VirtualMachineTemplateName <String>]`: Name of the virtual machine template resource.
  - `[VirtualNetworkName <String>]`: Name of the virtual network resource.

`INSTALLPATCHESINPUT <IVirtualMachineInstallPatchesParameters>`: Input for InstallPatches as directly received by the API
  - `MaximumDuration <String>`: Specifies the maximum amount of time that the operation will run. It must be an ISO 8601-compliant duration string such as PT4H (4 hours)
  - `RebootSetting <VMGuestPatchRebootSetting>`: Defines when it is acceptable to reboot a VM during a software update operation.
  - `[LinuxParameterClassificationsToInclude <VMGuestPatchClassificationLinux[]>]`: The update classifications to select when installing patches for Linux.
  - `[LinuxParameterPackageNameMasksToExclude <String[]>]`: packages to exclude in the patch operation. Format: packageName_packageVersion
  - `[LinuxParameterPackageNameMasksToInclude <String[]>]`: packages to include in the patch operation. Format: packageName_packageVersion
  - `[WindowParameterClassificationsToInclude <VMGuestPatchClassificationWindows[]>]`: The update classifications to select when installing patches for Windows.
  - `[WindowParameterExcludeKbsRequiringReboot <Boolean?>]`: Filters out Kbs that don't have an InstallationRebootBehavior of 'NeverReboots' when this is set to true.
  - `[WindowParameterKbNumbersToExclude <String[]>]`: Kbs to exclude in the patch operation
  - `[WindowParameterKbNumbersToInclude <String[]>]`: Kbs to include in the patch operation
  - `[WindowParameterMaxPatchPublishDate <DateTime?>]`: This is used to install patches that were published on or before this given max published date.

## RELATED LINKS

