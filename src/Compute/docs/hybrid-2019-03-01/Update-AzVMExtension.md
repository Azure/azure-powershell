---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azvmextension
schema: 2.0.0
---

# Update-AzVMExtension

## SYNOPSIS
The operation to update the extension.

## SYNTAX

### Update (Default)
```
Update-AzVMExtension -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -VMName <String>
 [-ExtensionParameter <IVirtualMachineExtensionUpdate>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzVMExtension -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -VMName <String>
 [-AutoUpgradeMinorVersion] [-ForceRerun <String>]
 [-ProtectedSetting <IVirtualMachineExtensionUpdatePropertiesProtectedSettings>] [-Publisher <String>]
 [-Setting <IVirtualMachineExtensionUpdatePropertiesSettings>] [-Tag <IUpdateResourceTags>] [-Type <String>]
 [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVMExtension -InputObject <IComputeIdentity> [-AutoUpgradeMinorVersion] [-ForceRerun <String>]
 [-ProtectedSetting <IVirtualMachineExtensionUpdatePropertiesProtectedSettings>] [-Publisher <String>]
 [-Setting <IVirtualMachineExtensionUpdatePropertiesSettings>] [-Tag <IUpdateResourceTags>] [-Type <String>]
 [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzVMExtension -InputObject <IComputeIdentity> [-ExtensionParameter <IVirtualMachineExtensionUpdate>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update the extension.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoUpgradeMinorVersion
Indicates whether the extension should use a newer minor version if one is available at deployment time.
Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -ExtensionParameter
Describes a Virtual Machine Extension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtensionUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ForceRerun
How the extension handler should be forced to update even if the extension configuration has not changed.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the virtual machine extension.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProtectedSetting
The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtensionUpdatePropertiesProtectedSettings
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: ProtectedSettings

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Publisher
The name of the extension handler publisher.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Setting
Json formatted public settings for the extension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtensionUpdatePropertiesSettings
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: Settings

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IUpdateResourceTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Specifies the type of the extension; an example is "CustomScriptExtension".

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TypeHandlerVersion
Specifies the version of the script handler.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMName
The name of the virtual machine where the extension should be updated.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtensionUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtension

## ALIASES

## RELATED LINKS

