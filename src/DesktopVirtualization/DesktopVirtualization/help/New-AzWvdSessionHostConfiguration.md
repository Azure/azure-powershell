---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdsessionhostconfiguration
schema: 2.0.0
---

# New-AzWvdSessionHostConfiguration

## SYNOPSIS
Create or update a SessionHostConfiguration.

## SYNTAX

```
New-AzWvdSessionHostConfiguration -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -DiskInfoType <VirtualMachineDiskType> -DomainInfoJoinType <DomainJoinType> -ImageInfoType <Type>
 -NetworkInfoSubnetId <String> -VMAdminCredentialsPasswordKeyVaultSecretUri <String>
 -VMAdminCredentialsUsernameKeyVaultSecretUri <String> -VMNamePrefix <String> -VMSizeId <String>
 [-ActiveDirectoryInfoDomainName <String>] [-ActiveDirectoryInfoOuPath <String>] [-AvailabilityZone <Int32[]>]
 [-AzureActiveDirectoryInfoMdmProviderGuid <String>] [-BootDiagnosticInfoEnabled]
 [-BootDiagnosticInfoStorageUri <String>] [-CustomConfigurationScriptUrl <String>]
 [-CustomInfoResourceId <String>] [-DomainCredentialsPasswordKeyVaultSecretUri <String>]
 [-DomainCredentialsUsernameKeyVaultSecretUri <String>] [-FriendlyName <String>]
 [-MarketplaceInfoExactVersion <String>] [-MarketplaceInfoOffer <String>] [-MarketplaceInfoPublisher <String>]
 [-MarketplaceInfoSku <String>] [-NetworkInfoSecurityGroupId <String>] [-SecurityInfoSecureBootEnabled]
 [-SecurityInfoType <VirtualMachineSecurityType>] [-SecurityInfoVTpmEnabled] [-VMLocation <String>]
 [-VMResourceGroup <String>] [-VMTag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a SessionHostConfiguration.

## EXAMPLES

### EXAMPLE 1
```
New-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -DiskInfoType "Standard_LRS" `
                            -DomainInfoJoinType "AzureActiveDirectory" `
                            -ImageInfoType "Marketplace" `
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

## PARAMETERS

### -ActiveDirectoryInfoDomainName
The domain a virtual machine connected to a hostpool will join.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryInfoOuPath
The ou path.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Value for availability zones to be used by the session host.
Should be from \[1,2,3\].

```yaml
Type: Int32[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureActiveDirectoryInfoMdmProviderGuid
The mdm guid.

```yaml
Type: String
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -BootDiagnosticInfoStorageUri
Uri of the storage account to use for placing the console output and screenshot.


If storageUri is not specified while enabling boot diagnostics, managed storage will be used.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
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
Type: String
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskInfoType
The disk type used by virtual machine in hostpool session host.

```yaml
Type: VirtualMachineDiskType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainCredentialsPasswordKeyVaultSecretUri
The uri to access the secret that the password is stored in.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainInfoJoinType
The type of domain join done by the virtual machine.

```yaml
Type: DomainJoinType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Friendly name to describe this version of the SessionHostConfiguration.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageInfoType
The type of image session hosts use in the hostpool.

```yaml
Type: Type
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceInfoExactVersion
The exact version of the image.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInfoSecurityGroupId
The resource ID of the security group.
Any allowable/open ports should be specified in the NSG.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: String
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityInfoType
The security type used by virtual machine in hostpool session host.
Default is Standard.

```yaml
Type: VirtualMachineSecurityType
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMAdminCredentialsPasswordKeyVaultSecretUri
The uri to access the secret that the password is stored in.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMAdminCredentialsUsernameKeyVaultSecretUri
The uri to access the secret that the username is stored in.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMLocation
The Location for the session host to be created in.
It will default to the location of the hostpool if not provided.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMResourceGroup
The ResourceGroup for the session hosts to be created in.
It will default to the ResourceGroup of the hostpool if not provided.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSizeId
The id of the size of a virtual machine connected to a hostpool.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMTag
Hashtable that lists key/value pair tags to apply to the VMs

```yaml
Type: Hashtable
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.ISessionHostConfiguration
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdsessionhostconfiguration](https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdsessionhostconfiguration)

