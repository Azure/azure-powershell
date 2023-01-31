---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/new-azcontainerregistry
schema: 2.0.0
---

# New-AzContainerRegistry

## SYNOPSIS
Creates a container registry with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerRegistry -Name <String> -ResourceGroupName <String> -Location <String> -SkuName <SkuName>
 [-SubscriptionId <String>] [-AdminUserEnabled] [-AnonymousPullEnabled]
 [-AzureAdAuthenticationAsArmPolicyStatus <AzureAdAuthenticationAsArmPolicyStatus>] [-DataEndpointEnabled]
 [-EncryptionStatus <EncryptionStatus>] [-ExportPolicyStatus <ExportPolicyStatus>]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyVaultPropertyIdentity <String>]
 [-KeyVaultPropertyKeyIdentifier <String>] [-NetworkRuleBypassOption <NetworkRuleBypassOptions>]
 [-NetworkRuleSetDefaultAction <DefaultAction>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-QuarantinePolicyStatus <PolicyStatus>]
 [-RetentionPolicyDay <Int32>] [-RetentionPolicyStatus <PolicyStatus>] [-SoftDeletePolicyRetentionDay <Int32>]
 [-SoftDeletePolicyStatus <PolicyStatus>] [-Tag <Hashtable>] [-TrustPolicyStatus <PolicyStatus>]
 [-TrustPolicyType <TrustPolicyType>] [-ZoneRedundancy <ZoneRedundancy>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzContainerRegistry -Name <String> -ResourceGroupName <String> -Registry <IRegistry>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzContainerRegistry -InputObject <IContainerRegistryIdentity> -Registry <IRegistry>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerRegistry -InputObject <IContainerRegistryIdentity> -Location <String> -SkuName <SkuName>
 [-AdminUserEnabled] [-AnonymousPullEnabled]
 [-AzureAdAuthenticationAsArmPolicyStatus <AzureAdAuthenticationAsArmPolicyStatus>] [-DataEndpointEnabled]
 [-EncryptionStatus <EncryptionStatus>] [-ExportPolicyStatus <ExportPolicyStatus>]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyVaultPropertyIdentity <String>]
 [-KeyVaultPropertyKeyIdentifier <String>] [-NetworkRuleBypassOption <NetworkRuleBypassOptions>]
 [-NetworkRuleSetDefaultAction <DefaultAction>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-QuarantinePolicyStatus <PolicyStatus>]
 [-RetentionPolicyDay <Int32>] [-RetentionPolicyStatus <PolicyStatus>] [-SoftDeletePolicyRetentionDay <Int32>]
 [-SoftDeletePolicyStatus <PolicyStatus>] [-Tag <Hashtable>] [-TrustPolicyStatus <PolicyStatus>]
 [-TrustPolicyType <TrustPolicyType>] [-ZoneRedundancy <ZoneRedundancy>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a container registry with the specified parameters.

## EXAMPLES

### Example 1: Create a container registry with a new storage account.
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -Sku "Basic" -Location "west us"
```

```output
Name             SkuName LoginServer                 CreationDate         ProvisioningState AdminUserEnabled
----             ------- -----------                 ------------         ----------------- ----------------
RegistryExample Basic   registryexample.azurecr.io 1/19/2023 6:10:49 AM Succeeded         False
```

Create a container registry with a new storage account.

### Example 2: Create a container registry with admin user enabled.
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -Sku "Basic" -Location "west us" -AdminUserEnabled
```

```output
Name             SkuName LoginServer                 CreationDate         ProvisioningState AdminUserEnabled
----             ------- -----------                 ------------         ----------------- ----------------
RegistryExample Basic   registryexample.azurecr.io 1/19/2023 6:10:49 AM Succeeded         True
```

Create a container registry with admin user enabled.

## PARAMETERS

### -AdminUserEnabled
The value that indicates whether the admin user is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnonymousPullEnabled
Enables registry-wide pull from unauthenticated clients.
It's in preview and available in the Standard and Premium service tiers.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -AzureAdAuthenticationAsArmPolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.AzureAdAuthenticationAsArmPolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEndpointEnabled
Enable a single data endpoint per region for serving data.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EncryptionStatus
Indicates whether or not the encryption is enabled for container registry.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.EncryptionStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportPolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.ExportPolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityPrincipalId
The principal ID of resource identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityTenantId
The tenant ID of resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.ResourceIdentityType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/ providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultPropertyIdentity
The client id of the identity which will be used to access key vault.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyIdentifier
Key vault uri to access the encryption key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.
This cannot be changed after the resource is created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: RegistryName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleBypassOption
Whether to allow trusted Azure services to access a network restricted registry.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.NetworkRuleBypassOptions
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetDefaultAction
The default action of allow or deny when no other rules match.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.DefaultAction
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetIPRule
The IP ACL rules.
To construct, see NOTES section for NETWORKRULESETIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IIPRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -PublicNetworkAccess
Whether or not public network access is allowed for the container registry.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.PublicNetworkAccess
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuarantinePolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.PolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Registry
An object that represents a container registry.
To construct, see NOTES section for REGISTRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IRegistry
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPolicyDay
The number of days to retain an untagged manifest after which it gets purged.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.PolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The SKU name of the container registry.
Required for registry creation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.SkuName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeletePolicyRetentionDay
The number of days after which a soft-deleted item is permanently deleted.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeletePolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.PolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustPolicyStatus
The value that indicates whether the policy is enabled or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.PolicyStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustPolicyType
The type of trust policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.TrustPolicyType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundancy
Whether or not zone redundancy is enabled for this container registry

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.ZoneRedundancy
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IRegistry

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IRegistry

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerRegistryIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[ConnectedRegistryName <String>]`: The name of the connected registry.
  - `[ExportPipelineName <String>]`: The name of the export pipeline.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[ImportPipelineName <String>]`: The name of the import pipeline.
  - `[PipelineRunName <String>]`: The name of the pipeline run.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[RegistryName <String>]`: The name of the container registry.
  - `[ReplicationName <String>]`: The name of the replication.
  - `[ResourceGroupName <String>]`: The name of the resource group to which the container registry belongs.
  - `[RunId <String>]`: The run ID.
  - `[ScopeMapName <String>]`: The name of the scope map.
  - `[SubscriptionId <String>]`: The Microsoft Azure subscription ID.
  - `[TaskName <String>]`: The name of the container registry task.
  - `[TaskRunName <String>]`: The name of the task run.
  - `[TokenName <String>]`: The name of the token.
  - `[WebhookName <String>]`: The name of the webhook.

`NETWORKRULESETIPRULE <IIPRule[]>`: The IP ACL rules.
  - `IPAddressOrRange <String>`: Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
  - `[Action <Action?>]`: The action of IP ACL rule.

`REGISTRY <IRegistry>`: An object that represents a container registry.
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
  - `[AnonymousPullEnabled <Boolean?>]`: Enables registry-wide pull from unauthenticated clients. It's in preview and available in the Standard and Premium service tiers.
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

