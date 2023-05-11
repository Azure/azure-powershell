---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/set-azservicebusnamespace
schema: 2.0.0
---

# Set-AzServiceBusNamespace

## SYNOPSIS
Updates a ServiceBus namespace

## SYNTAX

### SetExpanded (Default)
```
Set-AzServiceBusNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AlternateName <String>] [-DisableLocalAuth] [-IdentityType <ManagedServiceIdentityType>]
 [-KeyVaultProperty <IKeyVaultProperties[]>] [-MinimumTlsVersion <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-RequireInfrastructureEncryption] [-SkuCapacity <Int32>]
 [-SkuName <SkuName>] [-Tag <Hashtable>] [-UserAssignedIdentityId <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzServiceBusNamespace [-InputObject <IServiceBusIdentity>] [-AlternateName <String>] [-DisableLocalAuth]
 [-IdentityType <ManagedServiceIdentityType>] [-KeyVaultProperty <IKeyVaultProperties[]>]
 [-MinimumTlsVersion <String>] [-PublicNetworkAccess <PublicNetworkAccess>] [-RequireInfrastructureEncryption]
 [-SkuCapacity <Int32>] [-SkuName <SkuName>] [-Tag <Hashtable>] [-UserAssignedIdentityId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a ServiceBus namespace

## EXAMPLES

### Example 1: Add a KeyVaultProperty to an existing ServiceBus Namespace
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$newKeyVaultProperty = New-AzServiceBusKeyVaultPropertiesObject -KeyName key6 -KeyVaultUri https://testkeyvault.vault.azure.net -UserAssignedIdentity "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$serviceBusNamespace.KeyVaultProperty += $newKeyVaultProperty
Set-AzServiceBusNamespace -InputObject $serviceBusNamespace -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 5:51:52 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    :
KeySource                       :
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key5",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/use
                                  rAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key6",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : 000000000000:myNamespace
MinimumTlsVersion               : 1.1
Name                            : myNamespace
PrincipalId                     :
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 16
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
UpdatedAt                       : 11/21/2022 5:01:22 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Adds a new KeyVaultProperty to ServiceBus namespace `myNamespace`.

### Example 2: Remove a KeyVaultProperty from an existing ServiceBus Namespace
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$serviceBusNamespace.KeyVaultProperty = $serviceBusNamespace.KeyVaultProperty[0,2]
Set-AzServiceBusNamespace -InputObject $serviceBusNamespace -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
```

```output
AlternateName                   :
CreatedAt                       : 11/21/2022 5:15:41 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : UserAssigned
KeySource                       : Microsoft.KeyVault
KeyVaultProperty                : {{
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                      userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key4",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }, {
                                    "identity": {
                                      "userAssignedIdentity": "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                      userAssignedIdentities/myFirstIdentity"
                                    },
                                    "keyName": "key6",
                                    "keyVaultUri": "https://testkeyvault.vault.azure.net",
                                    "keyVersion": ""
                                  }}
Location                        : North Europe
MetricId                        : 000000000000:myNamespace
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
UpdatedAt                       : 11/21/2022 8:52:02 AM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/myFirstIdentity": {
                                    },
                                    "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/mySecondIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Remove the second KeyVaultProperty from the list of KeyVaultProperties.

### Example 3: Add UserAssigned Identity to Namespace with IdentityType SystemAssigned to test for SystemAssigned and UserAssigned
```powershell
$serviceBusNamespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -NamespaceName myNamespace
$id1 = "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$id2 = "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"
Set-AzServiceBusNamespace -InputObject $serviceBusNamespace -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentityId $id1, $id2
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 3:54:50 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace
IdentityType                    : SystemAssigned, UserAssigned
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : 000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000
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
                                  }
TenantId                        : 0000000000000000
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 9:15:53 AM
UserAssignedIdentity            : {
                                    "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/mySecondIdentity": {
                                    },
                                    "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/
                                    userAssignedIdentities/myFirstIdentity": {
                                    }
                                  }
ZoneRedundant                   : False
```

Added UserAssigned Identity to Namespace with IdentityType SystemAssigned to test for SystemAssigned and UserAssigned.

### Example 4: # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.
```powershell
$id1 = "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity" 
$id2 = "/subscriptions/000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"
$serviceBusNamespace = New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityId $id1,$id2
$serviceBusNamespace = Set-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -IdentityType None -UserAssignedIdentityId @()
```

```output
AlternateName                   :
CreatedAt                       : 11/17/2022 3:54:50 AM
DisableLocalAuth                : False
Id                              : /subscriptions/000000000000/resourceGroups/myResourceGroup/providers/M
                                  icrosoft.ServiceBus/namespaces/myNamespace
IdentityType                    :
KeySource                       :
KeyVaultProperty                :
Location                        : North Europe
MetricId                        : 000000000000:myNamespace
MinimumTlsVersion               : 1.2
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
                                  }
TenantId                        :
Type                            : Microsoft.ServiceBus/Namespaces
UpdatedAt                       : 11/21/2022 9:42:32 AM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : False
```

Created a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None.

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

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: SetViaIdentityExpanded
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
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
Aliases:

Required: True
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

Set-AzServiceBusNamespaceV2

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceBusIdentity>`: Identity parameter.
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ConfigName <MigrationConfigurationName?>]`: The configuration name. Should always be "$default".
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[QueueName <String>]`: The queue name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RuleName <String>]`: The rule name.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SubscriptionName <String>]`: The subscription name.
  - `[TopicName <String>]`: The topic name.

`KEYVAULTPROPERTY <IKeyVaultProperties[]>`: Properties of KeyVault
  - `[KeyName <String>]`: Name of the Key from KeyVault
  - `[KeyVaultUri <String>]`: Uri of KeyVault
  - `[KeyVersion <String>]`: Version of KeyVault
  - `[UserAssignedIdentity <String>]`: ARM ID of user Identity selected for encryption

## RELATED LINKS

