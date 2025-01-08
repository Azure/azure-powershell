---
external help file: Az.Databricks-help.xml
Module Name: Az.Databricks
online version: https://learn.microsoft.com/powershell/module/az.databricks/new-azdatabricksworkspace
schema: 2.0.0
---

# New-AzDatabricksWorkspace

## SYNOPSIS
Creates a new workspace.

## SYNTAX

```
New-AzDatabricksWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ManagedResourceGroupName <String>] [-AmlWorkspaceId <String>]
 [-Authorization <IWorkspaceProviderAuthorization[]>] [-DefaultCatalogInitialType <InitialType>]
 [-EnableNoPublicIP] [-EncryptionKeyName <String>] [-EncryptionKeySource <KeySource>]
 [-EncryptionKeyVaultUri <String>] [-EncryptionKeyVersion <String>] [-LoadBalancerBackendPoolName <String>]
 [-LoadBalancerId <String>] [-ManagedDiskKeySource <EncryptionKeySource>]
 [-ManagedDiskKeyVaultPropertiesKeyName <String>] [-ManagedDiskKeyVaultPropertiesKeyVaultUri <String>]
 [-ManagedDiskKeyVaultPropertiesKeyVersion <String>] [-ManagedDiskRotationToLatestKeyVersionEnabled]
 [-ManagedServiceKeySource <EncryptionKeySource>] [-ManagedServicesKeyVaultPropertiesKeyName <String>]
 [-ManagedServicesKeyVaultPropertiesKeyVaultUri <String>]
 [-ManagedServicesKeyVaultPropertiesKeyVersion <String>] [-NatGatewayName <String>] [-PrepareEncryption]
 [-PrivateSubnetName <String>] [-PublicIPName <String>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-PublicSubnetName <String>] [-RequireInfrastructureEncryption] [-RequiredNsgRule <RequiredNsgRules>]
 [-Sku <String>] [-SkuTier <String>] [-StorageAccountName <String>] [-StorageAccountSku <String>]
 [-Tag <Hashtable>] [-UiDefinitionUri <String>] [-VirtualNetworkId <String>] [-VnetAddressPrefix <String>]
 [-EnhancedSecurityMonitoring <EnhancedSecurityMonitoringValue>]
 [-AutomaticClusterUpdate <AutomaticClusterUpdateValue>] [-ComplianceStandard <ComplianceStandard[]>]
 [-EnhancedSecurityCompliance <ComplianceSecurityProfileValue>] [-AccessConnectorId <String>]
 [-AccessConnectorIdentityType <IdentityType>] [-AccessConnectorUserAssignedIdentityId <String>]
 [-DefaultStorageFirewall <DefaultStorageFirewall>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new workspace.

## EXAMPLES

### Example 1: Create a Databricks workspace.
```powershell
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t1 -ResourceGroupName azps_test_gp_db -Location eastus -ManagedResourceGroupName azps_test_gp_kv_t1 -Sku Premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t1 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t1
```

This command creates a Databricks workspace.

### Example 2: Create a Databricks workspace with a customized virtual network.
```powershell
$dlg = New-AzDelegation -Name dbrdl -ServiceName "Microsoft.Databricks/workspaces"
$rdpRule = New-AzNetworkSecurityRuleConfig -Name azps-network-security-rule -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
$networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName azps_test_gp_db -Location eastus -Name azps-network-security-group -SecurityRules $rdpRule
$kvSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-kv -AddressPrefix "110.0.1.0/24" -ServiceEndpoint "Microsoft.KeyVault"
$priSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-pri -AddressPrefix "110.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
$pubSubnet = New-AzVirtualNetworkSubnetConfig -Name azps-vnetwork-sub-pub -AddressPrefix "110.0.3.0/24" -NetworkSecurityGroup $networkSecurityGroup -Delegation $dlg
$testVN = New-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_db -Location eastus -AddressPrefix "110.0.0.0/16" -Subnet $kvSubnet,$priSubnet,$pubSubnet
$vNetResId = (Get-AzVirtualNetwork -Name azps-virtual-network -ResourceGroupName azps_test_gp_db).Subnets[0].Id
$ruleSet = New-AzKeyVaultNetworkRuleSetObject -DefaultAction Allow -Bypass AzureServices -IpAddressRange "110.0.1.0/24" -VirtualNetworkResourceId $vNetResId
New-AzKeyVault -ResourceGroupName azps_test_gp_db -VaultName azps-keyvault -NetworkRuleSet $ruleSet -Location eastus -Sku 'Premium' -EnablePurgeProtection
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t2 -ResourceGroupName azps_test_gp_db -Location eastus -ManagedResourceGroupName azps_test_gp_kv_t2 -VirtualNetworkId $testVN.Id -PrivateSubnetName $priSubnet.Name -PublicSubnetName $pubSubnet.Name -Sku Premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
```

This command creates a Databricks workspace with customized virtual network in a resource group.

### Example 3: Create a Databricks workspace with enable encryption.
```powershell
New-AzDatabricksWorkspace -Name azps-databricks-workspace-t3 -ResourceGroupName azps_test_gp_db -Location eastus -PrepareEncryption -ManagedResourceGroupName azps_test_gp_kv_t3 -Sku premium
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

This command creates a Databricks workspace and sets it to prepare for encryption.
Please refer to the examples of Update-AzDatabricksWorkspace for more settings to encryption.

## PARAMETERS

### -AccessConnectorId
The resource ID of Azure Databricks Access Connector Resource.

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

### -AccessConnectorIdentityType
The identity type of the Access Connector Resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.IdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccessConnectorUserAssignedIdentityId
The resource ID of the User Assigned Identity associated with the Access Connector Resource.
This is required for type 'UserAssigned' and not valid for type 'SystemAssigned'.

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

### -AmlWorkspaceId
The value which should be used for this field.

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

### -Authorization
The workspace provider authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IWorkspaceProviderAuthorization[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticClusterUpdate
Status of automated cluster updates feature.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.AutomaticClusterUpdateValue
Parameter Sets: (All)
Aliases: AutomaticClusterUpdateValue

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComplianceStandard
Compliance standards associated with the workspace.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ComplianceStandard[]
Parameter Sets: (All)
Aliases: ComplianceSecurityProfileComplianceStandard

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultCatalogInitialType
Defines the initial type of the default catalog.
Possible values (case-insensitive): HiveMetastore, UnityCatalog

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.InitialType
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

### -DefaultStorageFirewall
Gets or Sets Default Storage Firewall configuration information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.DefaultStorageFirewall
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNoPublicIP
The value which should be used for this field.

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

### -EncryptionKeyName
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

### -EncryptionKeySource
The encryption keySource (provider).
Possible values (case-insensitive): Default, Microsoft.Keyvault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyVaultUri
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

### -EncryptionKeyVersion
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

### -EnhancedSecurityCompliance
Status of Compliance Security Profile feature.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ComplianceSecurityProfileValue
Parameter Sets: (All)
Aliases: ComplianceSecurityProfileValue

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnhancedSecurityMonitoring
Status of Enhanced Security Monitoring feature.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.EnhancedSecurityMonitoringValue
Parameter Sets: (All)
Aliases: EnhancedSecurityMonitoringValue

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancerBackendPoolName
The value which should be used for this field.

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

### -LoadBalancerId
The value which should be used for this field.

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

### -Location
The geo-location where the resource lives

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

### -ManagedDiskKeySource
The encryption keySource (provider).
Possible values (case-insensitive): Microsoft.Keyvault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.EncryptionKeySource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedDiskKeyVaultPropertiesKeyName
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

### -ManagedDiskKeyVaultPropertiesKeyVaultUri
The URI of KeyVault.

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

### -ManagedDiskKeyVaultPropertiesKeyVersion
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

### -ManagedDiskRotationToLatestKeyVersionEnabled
Indicate whether the latest key version should be automatically used for Managed Disk Encryption.

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

### -ManagedResourceGroupName
The managed resource group Id.

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

### -ManagedServiceKeySource
The encryption keySource (provider).
Possible values (case-insensitive): Microsoft.Keyvault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.EncryptionKeySource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedServicesKeyVaultPropertiesKeyName
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

### -ManagedServicesKeyVaultPropertiesKeyVaultUri
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

### -ManagedServicesKeyVaultPropertiesKeyVersion
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
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NatGatewayName
The value which should be used for this field.

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

### -PrepareEncryption
The value which should be used for this field.

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

### -PrivateSubnetName
The value which should be used for this field.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIPName
The value which should be used for this field.

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

### -PublicNetworkAccess
The network access type for accessing workspace.
Set value to disabled to access workspace only via private link.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicSubnetName
The value which should be used for this field.

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

### -RequiredNsgRule
Gets or sets a value indicating whether data plane (clusters) to control plane communication happen over private endpoint.
Supported values are 'AllRules' and 'NoAzureDatabricksRules'.
'NoAzureServiceRules' value is for internal use only.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.RequiredNsgRules
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireInfrastructureEncryption
The value which should be used for this field.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU name.

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

### -SkuTier
The SKU tier.

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

### -StorageAccountName
The value which should be used for this field.

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

### -StorageAccountSku
The value which should be used for this field.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -UiDefinitionUri
The blob URI where the UI definition file is located.

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

### -VirtualNetworkId
The value which should be used for this field.

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

### -VnetAddressPrefix
The value which should be used for this field.

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

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IWorkspace

## NOTES

## RELATED LINKS
