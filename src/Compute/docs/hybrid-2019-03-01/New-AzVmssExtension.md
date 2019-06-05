---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/new-azvmssextension
schema: 2.0.0
---

# New-AzVmssExtension

## SYNOPSIS
The operation to create or update an extension.

## SYNTAX

### Create (Default)
```
New-AzVmssExtension -ResourceGroupName <String> -SubscriptionId <String> -VmssExtensionName <String>
 -VmssName <String> [-ExtensionParameter <IVirtualMachineScaleSetExtension>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzVmssExtension -ResourceGroupName <String> -SubscriptionId <String> -VmssExtensionName <String>
 -VmssName <String> [-AutoUpgradeMinorVersion] [-ForceUpdateTag <String>] [-Name <String>]
 [-ProtectedSetting <IVirtualMachineScaleSetExtensionPropertiesProtectedSettings>] [-Publisher <String>]
 [-Setting <IVirtualMachineScaleSetExtensionPropertiesSettings>] [-Type <String>]
 [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVmssExtension -InputObject <IComputeIdentity> [-AutoUpgradeMinorVersion] [-ForceUpdateTag <String>]
 [-Name <String>] [-ProtectedSetting <IVirtualMachineScaleSetExtensionPropertiesProtectedSettings>]
 [-Publisher <String>] [-Setting <IVirtualMachineScaleSetExtensionPropertiesSettings>] [-Type <String>]
 [-TypeHandlerVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVmssExtension -InputObject <IComputeIdentity> [-ExtensionParameter <IVirtualMachineScaleSetExtension>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update an extension.

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Describes a Virtual Machine Scale Set Extension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetExtension
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ForceUpdateTag
If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the extension.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProtectedSetting
The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetExtensionPropertiesProtectedSettings
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetExtensionPropertiesSettings
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VmssExtensionName
The name of the VM scale set extension.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VmssName
The name of the VM scale set where the extension should be create or updated.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetExtension

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineScaleSetExtension

## ALIASES

## RELATED LINKS

