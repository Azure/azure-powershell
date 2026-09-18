---
external help file:
Module Name: Az.Marketplace
online version: https://learn.microsoft.com/powershell/module/az.marketplace/new-azmarketplaceprivatestorecollection
schema: 2.0.0
---

# New-AzMarketplacePrivateStoreCollection

## SYNOPSIS
Create private store collection

## SYNTAX

### CreateExpanded (Default)
```
New-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreId <String> [-AllSubscription]
 [-Claim <String>] [-CollectionName <String>] [-Enabled] [-SubscriptionsList <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityPrivateStore
```
New-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreInputObject <IMarketplaceIdentity>
 -Payload <ICollection> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityPrivateStoreExpanded
```
New-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreInputObject <IMarketplaceIdentity>
 [-AllSubscription] [-Claim <String>] [-CollectionName <String>] [-Enabled] [-SubscriptionsList <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreId <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMarketplacePrivateStoreCollection -CollectionId <String> -PrivateStoreId <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create private store collection

## EXAMPLES

### Example 1: Create or updates private store collection
```powershell
New-AzMarketplacePrivateStoreCollection -CollectionName test -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a -SubscriptionsList 7f5402e4-e8f4-46bd-9bd1-8d27866a606b
```

```output
Name                                 SystemDataCreatedAt    SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
----                                 -------------------    ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 12/13/2021 11:12:27 AM                     User                    12/13/2021 11:12:27 AM                            User
```

This command create or updates private store collection

## PARAMETERS

### -AllSubscription
Indicating whether all subscriptions are selected (=true) or not (=false).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Claim
Gets or sets the association with Commercial's Billing Account.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionId
The collection ID

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

### -CollectionName
Gets or sets collection name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStoreExpanded
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

### -Enabled
Indicating whether the collection is enabled or disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
The Collection data structure.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollection
Parameter Sets: CreateViaIdentityPrivateStore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateStoreId
The store ID - must use the tenant ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateStoreInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity
Parameter Sets: CreateViaIdentityPrivateStore, CreateViaIdentityPrivateStoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionsList
Gets or sets subscription ids list.
Empty list indicates all subscriptions are selected, null indicates no update is done, explicit list indicates the explicit selected subscriptions.
On insert, null is considered as bad request

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityPrivateStoreExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollection

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.ICollection

## NOTES

## RELATED LINKS

