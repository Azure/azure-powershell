---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistrywebhook
schema: 2.0.0
---

# Get-AzContainerRegistryWebhook

## SYNOPSIS
Gets the properties of the specified webhook.

## SYNTAX

### List (Default)
```
Get-AzContainerRegistryWebhook -RegistryName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerRegistryWebhook -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByRegistry
```
Get-AzContainerRegistryWebhook -Registry <IRegistry> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistryWebhook -InputObject <IContainerRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified webhook.

## EXAMPLES

### Example 1: Gets a container registry webhook.
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
```

Gets a container registry webhook.

### Example 2: Get all the webhooks of a container registry
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"

```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
webhook002 eastus2  enabled       Succeeded
webhook003 eastus   enabled foo:* Succeeded
```

Get all the webhooks of a container registry

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the webhook.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WebhookName, ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Registry
The Registry Object.
To construct, see NOTES section for REGISTRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry
Parameter Sets: GetByRegistry
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: ContainerRegistryName

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerRegistryIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[CacheRuleName <String>]`: The name of the cache rule.
  - `[ConnectedRegistryName <String>]`: The name of the connected registry.
  - `[CredentialSetName <String>]`: The name of the credential set.
  - `[ExportPipelineName <String>]`: The name of the export pipeline.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[ImportPipelineName <String>]`: The name of the import pipeline.
  - `[PipelineRunName <String>]`: The name of the pipeline run.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[RegistryName <String>]`: The name of the container registry.
  - `[ReplicationName <String>]`: The name of the replication.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RunId <String>]`: The run ID.
  - `[ScopeMapName <String>]`: The name of the scope map.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[TaskName <String>]`: The name of the container registry task.
  - `[TaskRunName <String>]`: The name of the task run.
  - `[TokenName <String>]`: The name of the token.
  - `[WebhookName <String>]`: The name of the webhook.

`REGISTRY <IRegistry>`: The Registry Object.
  - `Location <String>`: The location of the resource. This cannot be changed after the resource is created.
  - `SkuName <SkuName>`: The SKU name of the container registry. Required for registry creation.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource modification (UTC).
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <LastModifiedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <IResourceTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AdminUserEnabled <Boolean?>]`: The value that indicates whether the admin user is enabled.
  - `[AnonymousPullEnabled <Boolean?>]`: Enables registry-wide pull from unauthenticated clients.
  - `[AzureAdAuthenticationAsArmPolicyStatus <AzureAdAuthenticationAsArmPolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[DataEndpointEnabled <Boolean?>]`: Enable a single data endpoint per region for serving data.
  - `[EncryptionStatus <EncryptionStatus?>]`: Indicates whether or not the encryption is enabled for container registry.
  - `[ExportPolicyStatus <ExportPolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[IdentityPrincipalId <String>]`: The principal ID of resource identity.
  - `[IdentityTenantId <String>]`: The tenant ID of resource.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type.
  - `[IdentityUserAssignedIdentity <IIdentityPropertiesUserAssignedIdentities>]`: The list of user identities associated with the resource. The user identity         dictionary key references will be ARM resource ids in the form:         '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/             providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    - `[(Any) <IUserIdentityProperties>]`: This indicates any property can be added to this object.
  - `[KeyVaultPropertyIdentity <String>]`: The client id of the identity which will be used to access key vault.
  - `[KeyVaultPropertyKeyIdentifier <String>]`: Key vault uri to access the encryption key.
  - `[NetworkRuleBypassOption <NetworkRuleBypassOptions?>]`: Whether to allow trusted Azure services to access a network restricted registry.
  - `[NetworkRuleSetDefaultAction <DefaultAction?>]`: The default action of allow or deny when no other rules match.
  - `[NetworkRuleSetIPRule <IIPRule[]>]`: The IP ACL rules.
    - `IPAddressOrRange <String>`: Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
    - `[Action <Action?>]`: The action of IP ACL rule.
  - `[PublicNetworkAccess <PublicNetworkAccess?>]`: Whether or not public network access is allowed for the container registry.
  - `[QuarantinePolicyStatus <PolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[RetentionPolicyDay <Int32?>]`: The number of days to retain an untagged manifest after which it gets purged.
  - `[RetentionPolicyStatus <PolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[SoftDeletePolicyRetentionDay <Int32?>]`: The number of days after which a soft-deleted item is permanently deleted.
  - `[SoftDeletePolicyStatus <PolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[TrustPolicyStatus <PolicyStatus?>]`: The value that indicates whether the policy is enabled or not.
  - `[TrustPolicyType <TrustPolicyType?>]`: The type of trust policy.
  - `[ZoneRedundancy <ZoneRedundancy?>]`: Whether or not zone redundancy is enabled for this container registry

## RELATED LINKS

