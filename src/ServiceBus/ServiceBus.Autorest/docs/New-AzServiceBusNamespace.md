---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/new-azservicebusnamespace
schema: 2.0.0
---

# New-AzServiceBusNamespace

## SYNOPSIS
Creates a new ServiceBus namespace.

## SYNTAX

```
New-AzServiceBusNamespace -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AlternateName <String>] [-DisableLocalAuth]
 [-IdentityType <ManagedServiceIdentityType>] [-KeyVaultProperty <IKeyVaultProperties[]>]
 [-MinimumTlsVersion <String>] [-PremiumMessagingPartition <Int32>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-RequireInfrastructureEncryption] [-SkuCapacity <Int32>]
 [-SkuName <SkuName>] [-Tag <Hashtable>] [-UserAssignedIdentityId <String[]>] [-ZoneRedundant]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new ServiceBus namespace.

## EXAMPLES

### Example 1: Create a new ServiceBus namespace with UserAssignedIdentity Encryption
```powershell
$id1 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$id2 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"
$keyVaultProperty1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$keyVaultProperty2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key5 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityID $id1,$id2 -KeyVaultProperty $keyVaultProperty1,$keyVaultProperty2
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:15:41 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/provide
                                  rs/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/reso
                                  urceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
                                     "
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/reso
                                  urceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
                                     "
                                    },
                                    "keyName": "key5",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption : False
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Premium
SkuTier                         : Premium
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 5:23:01 AM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/prov
                                  iders/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/prov
                                  iders/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Creates a new Premium ServiceBus namespace with UserAssignedIdentity encryption.

### Example 2: Create a new ServiceBus namespace with System Assigned Identity enabled.
```powershell
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType SystemAssigned
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:33:10 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/provide
                                  rs/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : SystemAssigned
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Premium
SkuTier                         : Premium
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                  }
TenantId                        : 000000000000000
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 5:40:18 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Create an ServiceBus namespace with SystemAssigned identity.

### Example 3: Create a new Standard ServiceBus namespace with DisableLocalAuth enabled 
```powershell
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -DisableLocalAuth
```

```output
AlternateName                   :
CreatedAt                       : 11/18/2022 6:06:22 AM
DisableLocalAuth                : True
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    :
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.1
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     :
SkuName                         : Standard
SkuTier                         : Standard
Status                          : Active
SystemDataCreatedAt             :
SystemDataCreatedBy             :
SystemDataCreatedByType         :
SystemDataLastModifiedAt        :
SystemDataLastModifiedBy        :
SystemDataLastModifiedByType    :
Tag                             : {
                                    "k1": "v1",
                                    "k2": "v2"
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/18/2022 6:07:06 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Create a standard ServiceBus namespace `myNamespace` with DisableLocalAuth enabled.

## PARAMETERS

### -AlternateName
Alternate name for namespace

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

### -DisableLocalAuth
This property disables SAS authentication for the Service Bus namespace.

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

### -IdentityType
Type of managed service identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultProperty
Properties of KeyVault
To construct, see NOTES section for KEYVAULTPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IKeyVaultProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource Location.

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

### -MinimumTlsVersion
The minimum TLS version for the cluster to support, e.g.
'1.2'

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
The name of ServiceBusNamespace

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

### -PremiumMessagingPartition
The number of partitions of a Service Bus namespace.
This property is only applicable to Premium SKU namespaces.
The default value is 1 and possible values are 1, 2 and 4

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireInfrastructureEncryption
Enable Infrastructure Encryption (Double Encryption)

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
The name of the ResourceGroupName.

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

### -SkuCapacity
The specified messaging units for the tier.
For Premium tier, capacity are 1,2 and 4.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of this SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
Properties for User Assigned Identities

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

### -ZoneRedundant
Enabling this property creates a Premium Service Bus Namespace in regions supported availability zones.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.ISbNamespace

## NOTES

ALIASES

New-AzServiceBusNamespaceV2

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`KEYVAULTPROPERTY <IKeyVaultProperties[]>`: Properties of KeyVault
  - `[KeyName <String>]`: Name of the Key from KeyVault
  - `[KeyVaultUri <String>]`: Uri of KeyVault
  - `[KeyVersion <String>]`: Version of KeyVault
  - `[UserAssignedIdentity <String>]`: ARM ID of user Identity selected for encryption

## RELATED LINKS

