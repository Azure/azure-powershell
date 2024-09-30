---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkfunctionvendor
schema: 2.0.0
---

# Get-AzConnectedNetworkFunctionVendor

## SYNOPSIS
Lists all the available vendor and sku information.

## SYNTAX

```
Get-AzConnectedNetworkFunctionVendor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all the available vendor and sku information.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkFunctionVendor
```powershell
Get-AzConnectedNetworkFunctionVendor
```

```output
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor-sku, vendor-sku1, vendor-sku2, vendor-sku3, vendor-sku4, vendor-sku4, vendor-sku5...}   myVendor
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Getting information about the vendors and their skus

### Example 2: Get-AzConnectedNetworkFunctionVendor via Subscription Id
```powershell
Get-AzConnectedNetworkFunctionVendor -SubscriptionId "xxxxx-00000-xxxxx-00000"
```

```output
SkuList                                                                                         VendorName
-------                                                                                         ----------
{vendor1-sku, vendor1-sku2}                                                                     myVendor1
{vendor2-sku1}                                                                                  myVendor2
```

Gets information about the vendors and their skus in the given subscription.

## PARAMETERS

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunctionVendor

## NOTES

## RELATED LINKS

