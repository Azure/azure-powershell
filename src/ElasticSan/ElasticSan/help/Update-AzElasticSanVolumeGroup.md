---
external help file: Az.ElasticSan-help.xml
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/update-azelasticsanvolumegroup
schema: 2.0.0
---

# Update-AzElasticSanVolumeGroup

## SYNOPSIS
Update an VolumeGroup.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnforceDataIntegrityCheckForIscsi <Boolean>] [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>]
 [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityElasticSanExpanded
```
Update-AzElasticSanVolumeGroup -Name <String> -ElasticSanInputObject <IElasticSanIdentity>
 [-EnforceDataIntegrityCheckForIscsi <Boolean>] [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>]
 [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity>
 [-EnforceDataIntegrityCheckForIscsi <Boolean>] [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>]
 [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an VolumeGroup.

## EXAMPLES

### Example 1: Update a volume group
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi      : True
Id                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                   : myvolumegroup
NetworkAclsVirtualNetworkRule          : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                           : iSCSI
ProvisioningState                      : Succeeded
SystemDataCreatedAt                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                : Application
SystemDataLastModifiedAt               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType           : Application
Type                                   : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type and virtual network rules of a volume gorup

### Example 2: Update a volume group virtual network rule with JSON input
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi'`
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi      : True
Id                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                   : myvolumegroup
NetworkAclsVirtualNetworkRule          : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                           : iSCSI
ProvisioningState                      : Succeeded
SystemDataCreatedAt                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                : Application
SystemDataLastModifiedAt               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType           : Application
Type                                   : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type, virtual network rules, and tag of a volume group.
It takes in the virtual network rules in JSON format.

### Example 3: Update a volume group from CMK to PMK
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 2:31:45 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:47:24 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command updates a volume group from CMK to PMK.

### Example 4: Update a volume group to a new user assigned identity
```powershell
$useridentity2 = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai2

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentityId $useridentity2.Id -EncryptionUserAssignedIdentity $useridentity2.Id
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 7:03:27 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 7:03:27 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command updates a volume group's user assigned identity.

### Example 5: Update a volume group to disable EnforceDataIntegrityCheckForIscsi
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -EnforceDataIntegrityCheckForIscsi $false
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : False
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           :
IdentityUserAssignedIdentity                           : {
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 9/18/2024 3:20:40 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : User
SystemDataLastModifiedAt                               : 9/18/2024 3:23:34 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : User
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command disables EnforceDataIntegrityCheckForIscsi on a volume group.

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

### -ElasticSanInputObject
Identity Parameter
To construct, see NOTES section for ELASTICSANINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: UpdateViaIdentityElasticSanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Encryption
Type of encryption

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionUserAssignedIdentity
Resource identifier of the UserAssigned identity to be associated with server-side encryption on the volume group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnforceDataIntegrityCheckForIscsi
A boolean indicating whether or not Data Integrity Check is enabled

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentityId
Gets or sets a list of key value pairs that describe the set of User Assigned identities that will be used with this volume group.
The key is the ARM resource identifier of the identity.

```yaml
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyName
The name of KeyVault key.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
The Uri of KeyVault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVersion
The version of KeyVault key.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityElasticSanExpanded
Aliases: VolumeGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsVirtualNetworkRule
The list of virtual network rules.
To construct, see NOTES section for NETWORKACLSVIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVirtualNetworkRule[]
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtocolType
Type of storage target

```yaml
Type: System.String
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVolumeGroup

## NOTES

## RELATED LINKS
