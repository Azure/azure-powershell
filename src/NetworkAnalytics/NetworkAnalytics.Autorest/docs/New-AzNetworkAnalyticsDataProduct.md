---
external help file:
Module Name: Az.NetworkAnalytics
online version: https://learn.microsoft.com/powershell/module/az.networkanalytics/new-aznetworkanalyticsdataproduct
schema: 2.0.0
---

# New-AzNetworkAnalyticsDataProduct

## SYNOPSIS
Create data product resource.

## SYNTAX

```
New-AzNetworkAnalyticsDataProduct -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CurrentMinorVersion <String>] [-CustomerEncryptionKeyName <String>]
 [-CustomerEncryptionKeyVaultUri <String>] [-CustomerEncryptionKeyVersion <String>]
 [-CustomerManagedKeyEncryptionEnabled <ControlState>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MajorVersion <String>]
 [-ManagedResourceGroupConfigurationLocation <String>] [-ManagedResourceGroupConfigurationName <String>]
 [-NetworkaclAllowedQueryIPRangeList <String[]>] [-NetworkaclDefaultAction <DefaultAction>]
 [-NetworkaclIPRule <IIPRules[]>] [-NetworkaclVirtualNetworkRule <IVirtualNetworkRule[]>] [-Owner <String[]>]
 [-PrivateLinksEnabled <ControlState>] [-Product <String>] [-PublicNetworkAccess <ControlState>]
 [-Publisher <String>] [-PurviewAccount <String>] [-PurviewCollection <String>] [-Redundancy <ControlState>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create data product resource.

## EXAMPLES

### Example 1: Create data product resource.
```powershell
 New-AzNetworkAnalyticsDataProduct -Name "pwshdp01" -Product "MCC" -MajorVersion "2.0.0" -Publisher "Microsoft" -Location "southcentralus" -ResourceGroupName "ResourceGroupName"
```

```output
Location       Name     SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----     -------------------    -------------------    ----------------------- ------------------------ -------------
southcentralus pwshdp01 10/13/2023 11:22:54 AM user1@microsoft.com User                    10/13/2023 11:22:54 AM   user1@microsoft.com
```

Create data product resource.

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

### -CurrentMinorVersion
Current configured minor version of the data product resource.

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

### -CustomerEncryptionKeyName
The name of the key vault key.

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

### -CustomerEncryptionKeyVaultUri
The Uri of the key vault.

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

### -CustomerEncryptionKeyVersion
The version of the key vault key.

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

### -CustomerManagedKeyEncryptionEnabled
Flag to enable customer managed key encryption for data product.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.ControlState
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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -MajorVersion
Major version of data product.

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

### -ManagedResourceGroupConfigurationLocation
Managed Resource Group location

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

### -ManagedResourceGroupConfigurationName
Name of managed resource group

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
The data product resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataProductName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkaclAllowedQueryIPRangeList
The list of query ips in the format of CIDR allowed to connect to query/visualization endpoint.

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

### -NetworkaclDefaultAction
Default Action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.DefaultAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkaclIPRule
IP rule with specific IP or IP range in CIDR format.
To construct, see NOTES section for NETWORKACLIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IIPRules[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkaclVirtualNetworkRule
Virtual Network Rule
To construct, see NOTES section for NETWORKACLVIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IVirtualNetworkRule[]
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

### -Owner
List of name or email associated with data product resource deployment.

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

### -PrivateLinksEnabled
Flag to enable or disable private link for data product resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.ControlState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Product
Product name of data product.

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
Flag to enable or disable public access of data product resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.ControlState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
Data product publisher name.

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

### -PurviewAccount
Purview account url for data product to connect to.

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

### -PurviewCollection
Purview collection url for data product to connect to.

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

### -Redundancy
Flag to enable or disable redundancy for data product.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Support.ControlState
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IDataProduct

## NOTES

## RELATED LINKS

