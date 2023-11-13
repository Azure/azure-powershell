---
external help file:
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/new-azelasticsanvolumegroup
schema: 2.0.0
---

# New-AzElasticSanVolumeGroup

## SYNOPSIS
Create a Volume Group.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Encryption <String>] [-EncryptionUserAssignedIdentity <String>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>]
 [-KeyVaultUri <String>] [-KeyVersion <String>] [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-ProtocolType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityElasticSanExpanded
```
New-AzElasticSanVolumeGroup -ElasticSanInputObject <IElasticSanIdentity> -Name <String> [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-Encryption <String>]
 [-EncryptionUserAssignedIdentity <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentityId <String>] [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a Volume Group.

## EXAMPLES

### Example 1: Create a volume group with network rule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This example creates two VirtualNetworkRule objects and then input the objects and other variables to create a volume group.

### Example 2: Create a volume group with network rule JSON input 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' `
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command creates a volume group with the NetworkAclsVirtualNetworkRule input in json format.

### Example 3: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType SystemAssigned -ProtocolType Iscsi -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    : 00000000-0000-0000-0000-000000000000
IdentityTenantId                                       : 00000000-0000-0000-0000-000000000000
IdentityType                                           : SystemAssigned
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
SystemDataCreatedAt                                    : 10/7/2023 6:20:55 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:20:55 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".

### Example 4: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
$useridentity = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai

New-AzElasticSanVolumeGroup -ResourceGroupName myresoucegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentityId $useridentity.Id -Encryption EncryptionAtRestWithCustomerManagedKey -KeyName mykey -KeyVaultUri "https://mykeyvault.vault.azure.net:443" -EncryptionUserAssignedIdentity $useridentity.Id -ProtocolType Iscsi
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 6:32:28 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : a000255f-5f09-45e0-a970-9d9ed9cc6453
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:32:27 AM
SystemDataLastModifiedBy                               : a000255f-5f09-45e0-a970-9d9ed9cc6453
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".

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
Parameter Sets: CreateViaIdentityElasticSanExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityElasticSanExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

