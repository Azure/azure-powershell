---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdsessionhostconfiguration
schema: 2.0.0
---

# Update-AzWvdSessionHostConfiguration

## SYNOPSIS
update a SessionHostConfiguration.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdSessionHostConfiguration -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AvailabilityZone <Int32[]>] [-BootDiagnosticInfoEnabled]
 [-BootDiagnosticInfoStorageUri <String>] [-CustomConfigurationScriptUrl <String>]
 [-CustomInfoResourceId <String>] [-DiffDiskSettingOption <String>] [-DiffDiskSettingPlacement <String>]
 [-DomainCredentialsPasswordKeyVaultSecretUri <String>] [-DomainCredentialsUsernameKeyVaultSecretUri <String>]
 [-FriendlyName <String>] [-ImageInfoImageType <String>] [-ManagedDiskType <String>]
 [-MarketplaceInfoExactVersion <String>] [-MarketplaceInfoOffer <String>] [-MarketplaceInfoPublisher <String>]
 [-MarketplaceInfoSku <String>] [-NetworkInfoSecurityGroupId <String>] [-NetworkInfoSubnetId <String>]
 [-SecurityInfoSecureBootEnabled] [-SecurityInfoType <String>] [-SecurityInfoVTpmEnabled]
 [-VMAdminCredentialsPasswordKeyVaultSecretUri <String>]
 [-VMAdminCredentialsUsernameKeyVaultSecretUri <String>] [-VMLocation <String>] [-VMNamePrefix <String>]
 [-VMResourceGroup <String>] [-VMSizeId <String>] [-VMTag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzWvdSessionHostConfiguration -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzWvdSessionHostConfiguration -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdSessionHostConfiguration -InputObject <IDesktopVirtualizationIdentity>
 [-AvailabilityZone <Int32[]>] [-BootDiagnosticInfoEnabled] [-BootDiagnosticInfoStorageUri <String>]
 [-CustomConfigurationScriptUrl <String>] [-CustomInfoResourceId <String>] [-DiffDiskSettingOption <String>]
 [-DiffDiskSettingPlacement <String>] [-DomainCredentialsPasswordKeyVaultSecretUri <String>]
 [-DomainCredentialsUsernameKeyVaultSecretUri <String>] [-FriendlyName <String>] [-ImageInfoImageType <String>]
 [-ManagedDiskType <String>] [-MarketplaceInfoExactVersion <String>] [-MarketplaceInfoOffer <String>]
 [-MarketplaceInfoPublisher <String>] [-MarketplaceInfoSku <String>] [-NetworkInfoSecurityGroupId <String>]
 [-NetworkInfoSubnetId <String>] [-SecurityInfoSecureBootEnabled] [-SecurityInfoType <String>]
 [-SecurityInfoVTpmEnabled] [-VMAdminCredentialsPasswordKeyVaultSecretUri <String>]
 [-VMAdminCredentialsUsernameKeyVaultSecretUri <String>] [-VMLocation <String>] [-VMNamePrefix <String>]
 [-VMResourceGroup <String>] [-VMSizeId <String>] [-VMTag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a SessionHostConfiguration.

## EXAMPLES

### Example 1: Update a Azure Virtual Desktop SessionHostConfiguration by HostPool Name
```powershell
Update-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -DiskInfoType "Standard_LRS" `
                            -ImageInfoImageType "Marketplace" `
                            -NetworkInfoSubnetId "/subscriptions/{subscriptionId}/resourceGroups/resourceGrouName/providers/Microsoft.Network/virtualNetworks/{vNetName}/subnets/default" `
                            -VMAdminCredentialsPasswordKeyvaultSecretUri "PasswordSecretUri" `
                            -VMAdminCredentialsUserNameKeyvaultSecretUri "PasswordUsernameUri" `
                            -VMNamePrefix "createTest" `
                            -VMSizeId "Standard_D2s_v3" `
                            -MarketplaceInfoExactVersion "22631.2715.231114" `
                            -MarketplaceInfoOffer "office-365" `
                            -MarketplaceInfoPublisher "microsoftwindowsdesktop" `
                            -MarketplaceInfoSku "win11-23h2-avd-m365" `
                            -SecurityInfoSecureBootEnabled `
                            -SecurityInfoType "TrustedLaunch" `
                            -SecurityInfoVTpmEnabled `
                            -VmLocation westus2 `
                            -VmResourceGroup ResourceGroupName
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     default Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations
```

This command uodates a Azure Virtual Desktop SessionHostConfiguration on a HostPool.

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

### -AvailabilityZone
Value for availability zones to be used by the session host.
Should be from [1,2,3].

```yaml
Type: System.Int32[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BootDiagnosticInfoEnabled
Whether boot diagnostics should be enabled on the Virtual Machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BootDiagnosticInfoStorageUri
Uri of the storage account to use for placing the console output and screenshot.


If storageUri is not specified while enabling boot diagnostics, managed storage will be used.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomConfigurationScriptUrl
The uri to the storage blob containing the arm template to be run on the virtual machine after provisioning.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomInfoResourceId
The resource id of the custom image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -DiffDiskSettingOption
Specifies the ephemeral disk settings for operating system disk.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiffDiskSettingPlacement
Gets or sets specifies the ephemeral disk placement for operating system disk.
The defaulting behavior is: CacheDisk if one is configured for the VM size otherwise ResourceDisk is used.
Refer to the VM size documentation for Windows VM at https://docs.microsoft.com/azure/virtual-machines/windows/sizes and Linux VM at https://docs.microsoft.com/azure/virtual-machines/linux/sizes to check which VM sizes exposes a cache disk.
Possible values include: 'CacheDisk', 'ResourceDisk'

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainCredentialsPasswordKeyVaultSecretUri
The uri to access the secret that the password is stored in.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainCredentialsUsernameKeyVaultSecretUri
The uri to access the secret that the username is stored in.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Friendly name to describe this version of the SessionHostConfiguration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageInfoImageType
The type of image session hosts use in the hostpool.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedDiskType
The disk type used by virtual machine in hostpool session host.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceInfoExactVersion
The exact version of the image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceInfoOffer
The offer of the image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceInfoPublisher
The publisher of the image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceInfoSku
The sku of the image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInfoSecurityGroupId
The resource ID of the security group.
Any allowable/open ports should be specified in the Network Security Group(NSG).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInfoSubnetId
The resource ID of the subnet.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityInfoSecureBootEnabled
Whether to use secureBoot on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityInfoType
The security type used by virtual machine in hostpool session host.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityInfoVTpmEnabled
Whether to use vTPM on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMAdminCredentialsPasswordKeyVaultSecretUri
The uri to access the secret that the password is stored in.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMAdminCredentialsUsernameKeyVaultSecretUri
The uri to access the secret that the username is stored in.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMLocation
The Location for the session host to be created in

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMNamePrefix
The prefix that should be associated with session host names

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMResourceGroup
The ResourceGroup for the session hosts to be created in.
It will default to the ResourceGroup of the hostpool if not provided.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSizeId
The id of the size of a virtual machine connected to a hostpool.
Example: Standard_D2as_v6

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMTag
Hashtable that lists key/value pair tags to apply to the VMs

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.ISessionHostConfiguration

## NOTES

## RELATED LINKS
