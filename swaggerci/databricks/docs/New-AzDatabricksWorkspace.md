---
external help file:
Module Name: Az.Databricks
online version: https://docs.microsoft.com/en-us/powershell/module/az.databricks/new-azdatabricksworkspace
schema: 2.0.0
---

# New-AzDatabricksWorkspace

## SYNOPSIS
Creates a new workspace.

## SYNTAX

```
New-AzDatabricksWorkspace -Name <String> -ResourceGroupName <String> -Location <String>
 -ManagedResourceGroupId <String> [-SubscriptionId <String>]
 [-Authorization <IWorkspaceProviderAuthorization[]>] [-KeyVaultPropertyKeyName <String>]
 [-KeyVaultPropertyKeyVaultUri <String>] [-KeyVaultPropertyKeyVersion <String>]
 [-Parameter <IWorkspaceCustomParameters>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RequiredNsgRule <RequiredNsgRules>] [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-UiDefinitionUri <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new workspace.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -Authorization
The workspace provider authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20210401Preview.IWorkspaceProviderAuthorization[]
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

### -KeyVaultPropertyKeyName
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

### -KeyVaultPropertyKeyVaultUri
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

### -KeyVaultPropertyKeyVersion
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

### -ManagedResourceGroupId
The managed resource group Id.

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

### -Parameter
The workspace's custom parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20210401Preview.IWorkspaceCustomParameters
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

### -SkuName
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

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20210401Preview.IWorkspace

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AUTHORIZATION <IWorkspaceProviderAuthorization[]>: The workspace provider authorizations.
  - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace resources.
  - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the workspace's container resource group. This role definition cannot have permission to delete the resource group.

PARAMETER <IWorkspaceCustomParameters>: The workspace's custom parameters.
  - `[AmlWorkspaceIdValue <String>]`: The value which should be used for this field.
  - `[CustomPrivateSubnetNameValue <String>]`: The value which should be used for this field.
  - `[CustomPublicSubnetNameValue <String>]`: The value which should be used for this field.
  - `[CustomVirtualNetworkIdValue <String>]`: The value which should be used for this field.
  - `[EnableNoPublicIPValue <Boolean?>]`: The value which should be used for this field.
  - `[LoadBalancerBackendPoolNameValue <String>]`: The value which should be used for this field.
  - `[LoadBalancerIdValue <String>]`: The value which should be used for this field.
  - `[NatGatewayNameValue <String>]`: The value which should be used for this field.
  - `[PrepareEncryptionValue <Boolean?>]`: The value which should be used for this field.
  - `[PublicIPNameValue <String>]`: The value which should be used for this field.
  - `[RequireInfrastructureEncryptionValue <Boolean?>]`: The value which should be used for this field.
  - `[ResourceTagValue <IAny>]`: The value which should be used for this field.
  - `[StorageAccountNameValue <String>]`: The value which should be used for this field.
  - `[StorageAccountSkuNameValue <String>]`: The value which should be used for this field.
  - `[ValueKeyName <String>]`: The name of KeyVault key.
  - `[ValueKeySource <KeySource?>]`: The encryption keySource (provider). Possible values (case-insensitive):  Default, Microsoft.Keyvault
  - `[ValueKeyVaultUri <String>]`: The Uri of KeyVault.
  - `[ValueKeyVersion <String>]`: The version of KeyVault key.
  - `[VnetAddressPrefixValue <String>]`: The value which should be used for this field.

## RELATED LINKS

