---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/set-azeventhubnamespace
schema: 2.0.0
---

# Set-AzEventHubNamespace

## SYNOPSIS
Updates an EventHub Namespace

## SYNTAX

### SetExpanded (Default)
```
Set-AzEventHubNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AlternateName <String>] [-DisableLocalAuth] [-EnableAutoInflate]
 [-IdentityType <ManagedServiceIdentityType>] [-KeyVaultProperty <IKeyVaultProperties[]>]
 [-MaximumThroughputUnit <Int32>] [-MinimumTlsVersion <String>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RequireInfrastructureEncryption] [-SkuCapacity <Int32>] [-Tag <Hashtable>]
 [-UserAssignedIdentityId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzEventHubNamespace -InputObject <IEventHubIdentity> [-AlternateName <String>] [-DisableLocalAuth]
 [-EnableAutoInflate] [-IdentityType <ManagedServiceIdentityType>] [-KeyVaultProperty <IKeyVaultProperties[]>]
 [-MaximumThroughputUnit <Int32>] [-MinimumTlsVersion <String>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RequireInfrastructureEncryption] [-SkuCapacity <Int32>] [-Tag <Hashtable>]
 [-UserAssignedIdentityId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an EventHub Namespace

## EXAMPLES

### Example 1: Add a ManagedIdentity to an EventHub namespace
```powershell
$eventHubNamespace = Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace

$identityId = $eventHubNamespace.UserAssignedIdentity.Keys

$identityId += "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"

Set-AzEventHubNamespace -InputObject $eventHubNamespace -UserAssignedIdentityId $identityId
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net/",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key3",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net/",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnit           : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

The output type of New and Set cmdlets `IEhNamespace` has a property named `UserAssignedIdentity` which is a hashtable.
The keys
of this hastable are the resource ID's of the managed identities the namespace is part of.
To add or remove an IdentityId, extract the 
keys from the hashtable, which would result in an array of strings which can then be queried and fed as input to set cmdlet as shown above.

### Example 2: Add a KeyVaultProperty to an existing EventHub Namespace
```powershell
$eventHubNamespace = Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace

$newKeyVaultProperty = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaultUri https://testkeyvault.vault.azure.net -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"

$eventHubNamespace.KeyVaultProperty += $newKeyVaultProperty

Set-AzEventHubNamespace -InputObject $eventHubNamespace -KeyVaultProperty $eventHubNamespace.KeyVaultProperty
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key3",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnit           : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Adds a new KeyVaultProperty to EventHub namespace `myNamespace`.

### Example 3: Remove a KeyVaultProperty from an existing EventHub Namespace
```powershell
$eventHubNamespace = Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace

# Remove the last KeyVaultProperty from the list of KeyVaultProperties
$eventHubNamespace.KeyVaultProperty = $eventHubNamespace.KeyVaultProperty | Where-Object { $_ -ne $eventHubNamespace.KeyVaultProperty[2] }

Set-AzEventHubNamespace -InputObject $eventHubNamespace -KeyVaultProperty $eventHubNamespace.KeyVaultProperty
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnit           : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Removes a new KeyVaultProperty to EventHub namespace `myNamespace`.

### Example 4: Set DisableLocalAuth to true on an existing EventHub namespace
```powershell
Set-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace -DisableLocalAuth
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 2:56:32 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    : UserAssigned
KafkaEnabled                    : True
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key1",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key2",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MaximumThroughputUnit           : 0
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
Tag                             : {
                                  }
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:03:50 PM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : True
```

Sets `DisableLocalAuth` to true on an EventHub namespace `myNamespace`.

### Example 5: # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.
```powershell
$eventHubNamespace = New-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityId "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$eventHubNamespace = Set-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace -IdentityType None -UserAssignedIdentityId @()
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/21/2022 3:21:29 PM
DisableLocalAuth                : False
EnableAutoInflate               : False
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/provide
                                  rs/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    :
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MaximumThroughputUnit           : 0
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     :
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
TenantId                        :
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/21/2022 3:31:03 PM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : True
```

Created a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.

## PARAMETERS

### -AlternateName
Alternate name specified when alias and namespace names are same

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
This property disables SAS authentication for the Event Hubs namespace.

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

### -EnableAutoInflate
Value that indicates whether AutoInflate is enabled for eventhub namespace.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultProperty
Properties to configure Encryption
To construct, see NOTES section for KEYVAULTPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IKeyVaultProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumThroughputUnit
Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.
( '0' if AutoInflateEnabled = true)

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
The name of EventHub namespace.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.PublicNetworkAccess
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The Event Hubs throughput units for Basic or Standard tiers, where value should be 0 to 20 throughput units.
The Event Hubs premium units for Premium tier, where value should be 0 to 10 premium units.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tag of EventHub Namespace.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEhNamespace

## NOTES

ALIASES

Set-AzEventHubNamespaceV2

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEventHubIdentity>`: Identity parameter.
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[ApplicationGroupName <String>]`: The Application Group name 
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ClusterName <String>]`: The name of the Event Hubs Cluster.
  - `[ConsumerGroupName <String>]`: The consumer group name
  - `[EventHubName <String>]`: The Event Hub name
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The Namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[ResourceAssociationName <String>]`: The ResourceAssociation Name
  - `[ResourceGroupName <String>]`: Name of the resource group within the azure subscription.
  - `[SchemaGroupName <String>]`: The Schema Group name 
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

`KEYVAULTPROPERTY <IKeyVaultProperties[]>`: Properties to configure Encryption
  - `[KeyName <String>]`: Name of the Key from KeyVault
  - `[KeyVaultUri <String>]`: Uri of KeyVault
  - `[KeyVersion <String>]`: Key Version
  - `[UserAssignedIdentity <String>]`: ARM ID of user Identity selected for encryption

## RELATED LINKS

