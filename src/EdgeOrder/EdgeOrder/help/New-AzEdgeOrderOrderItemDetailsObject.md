---
external help file: Az.EdgeOrder-help.xml
Module Name: Az.EdgeOrder
online version: https://learn.microsoft.com/powershell/module/Az.EdgeOrder/new-AzEdgeOrderOrderItemDetailsObject
schema: 2.0.0
---

# New-AzEdgeOrderOrderItemDetailsObject

## SYNOPSIS
Create an in-memory object for OrderItemDetails.

## SYNTAX

```
New-AzEdgeOrderOrderItemDetailsObject -OrderItemType <OrderItemType> -ProductDetail <IProductDetails>
 [-NotificationEmailList <String[]>] [-Preference <IPreferences>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for OrderItemDetails.

## EXAMPLES

### Example 1: Creates orderItemDetails object.
```powershell
$HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
$details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation}
```

Create an in-memory object for OrderItemDetails.

## PARAMETERS

### -NotificationEmailList
Additional notification email list.

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

### -OrderItemType
Order item type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.OrderItemType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Preference
Customer notification Preferences.
To construct, see NOTES section for PREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IPreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductDetail
Unique identifier for configuration.
To construct, see NOTES section for PRODUCTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductDetails
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.OrderItemDetails

## NOTES

## RELATED LINKS
