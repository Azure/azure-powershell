---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdsessionhostconfiguration
schema: 2.0.0
---

# Update-AzWvdSessionHostConfiguration

## SYNOPSIS
Update a SessionHostConfiguration.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdSessionHostConfiguration -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AvailabilityZone <Int32[]>] [-BootDiagnosticInfoEnabled]
 [-BootDiagnosticInfoStorageUri <String>] [-CustomConfigurationScriptUrl <String>]
 [-CustomInfoResourceId <String>] [-DiskInfoType <VirtualMachineDiskType>]
 [-DomainCredentialsPasswordKeyVaultSecretUri <String>] [-DomainCredentialsUsernameKeyVaultSecretUri <String>]
 [-FriendlyName <String>] [-ImageInfoType <Type>] [-MarketplaceInfoExactVersion <String>]
 [-MarketplaceInfoOffer <String>] [-MarketplaceInfoPublisher <String>] [-MarketplaceInfoSku <String>]
 [-NetworkInfoSecurityGroupId <String>] [-NetworkInfoSubnetId <String>] [-SecurityInfoSecureBootEnabled]
 [-SecurityInfoType <VirtualMachineSecurityType>] [-SecurityInfoVTpmEnabled]
 [-VMAdminCredentialsPasswordKeyVaultSecretUri <String>]
 [-VMAdminCredentialsUsernameKeyVaultSecretUri <String>] [-VMLocation <String>] [-VMNamePrefix <String>]
 [-VMResourceGroup <String>] [-VMSizeId <String>] [-VMTag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdSessionHostConfiguration -InputObject <IDesktopVirtualizationIdentity>
 [-AvailabilityZone <Int32[]>] [-BootDiagnosticInfoEnabled] [-BootDiagnosticInfoStorageUri <String>]
 [-CustomConfigurationScriptUrl <String>] [-CustomInfoResourceId <String>]
 [-DiskInfoType <VirtualMachineDiskType>] [-DomainCredentialsPasswordKeyVaultSecretUri <String>]
 [-DomainCredentialsUsernameKeyVaultSecretUri <String>] [-FriendlyName <String>] [-ImageInfoType <Type>]
 [-MarketplaceInfoExactVersion <String>] [-MarketplaceInfoOffer <String>] [-MarketplaceInfoPublisher <String>]
 [-MarketplaceInfoSku <String>] [-NetworkInfoSecurityGroupId <String>] [-NetworkInfoSubnetId <String>]
 [-SecurityInfoSecureBootEnabled] [-SecurityInfoType <VirtualMachineSecurityType>] [-SecurityInfoVTpmEnabled]
 [-VMAdminCredentialsPasswordKeyVaultSecretUri <String>]
 [-VMAdminCredentialsUsernameKeyVaultSecretUri <String>] [-VMLocation <String>] [-VMNamePrefix <String>]
 [-VMResourceGroup <String>] [-VMSizeId <String>] [-VMTag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a SessionHostConfiguration.

## EXAMPLES

### EXAMPLE 1
```
Update-AzWvdSessionHostConfiguration -ResourceGroupName ResourceGroupName `
                            -HostPoolName HostPoolName `
                            -DiskInfoType "Standard_LRS" `
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

Required: False
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
Parameter Sets: UpdateExpanded
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
Type: IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

Required: False
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMLocation
The Location for the session host to be created in

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

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.ISessionHostConfiguration
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDesktopVirtualizationIdentity\>: Identity Parameter
  \[AppAttachPackageName \<String\>\]: The name of the App Attach package arm object
  \[ApplicationGroupName \<String\>\]: The name of the application group
  \[ApplicationName \<String\>\]: The name of the application within the specified application group
  \[DesktopName \<String\>\]: The name of the desktop within the specified desktop group
  \[HostPoolName \<String\>\]: The name of the host pool within the specified resource group
  \[Id \<String\>\]: Resource identity path
  \[MsixPackageFullName \<String\>\]: The version specific package full name of the MSIX package within specified hostpool
  \[OperationId \<String\>\]: The Guid of the operation.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection associated with the Azure resource
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScalingPlanName \<String\>\]: The name of the scaling plan.
  \[ScalingPlanScheduleName \<String\>\]: The name of the ScalingPlanSchedule
  \[SessionHostName \<String\>\]: The name of the session host within the specified host pool
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[UserSessionId \<String\>\]: The name of the user session within the specified session host
  \[WorkspaceName \<String\>\]: The name of the workspace

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdsessionhostconfiguration](https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdsessionhostconfiguration)

