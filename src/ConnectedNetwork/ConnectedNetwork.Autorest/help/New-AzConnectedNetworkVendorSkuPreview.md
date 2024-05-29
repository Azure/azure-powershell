---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendorskupreview
schema: 2.0.0
---

# New-AzConnectedNetworkVendorSkuPreview

## SYNOPSIS
Creates or updates preview information of a vendor sku.

## SYNTAX

```
New-AzConnectedNetworkVendorSkuPreview -PreviewSubscription <String> -SkuName <String> -VendorName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates preview information of a vendor sku.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendorSkuPreview using preview subscription, sku name, vendor name and subscription
```powershell
New-AzConnectedNetworkVendorSkuPreview -PreviewSubscription xxxxx-00000-xxxxx-00000 -SkuName mySku -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222
```

```output
Id                           : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-00000-xxxxx-00000
Name                         : xxxxx-00000-xxxxx-00000
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 12/6/2021 5:37:35 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/6/2021 5:37:35 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Creating preview subscription for subscription xxxxx-00000-xxxxx-00000 of a vendor sku mySku with vendor name myVendor, which is allowed to deploy network function.

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

### -PreviewSubscription
Preview subscription ID.

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
The name of the vendor sku.

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

### -VendorName
The name of the vendor.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IPreviewSubscription

## NOTES

## RELATED LINKS

