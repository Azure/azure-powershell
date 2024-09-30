---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendor
schema: 2.0.0
---

# New-AzConnectedNetworkVendor

## SYNOPSIS
Creates or updates a vendor.

## SYNTAX

```
New-AzConnectedNetworkVendor -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a vendor.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendor
```powershell
New-AzConnectedNetworkVendor -Name myVendor
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor
Name                         : myVendor
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 11/23/2021 6:18:55 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/23/2021 6:19:08 PM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors
```

Creating a vendor with name myVendor.

### Example 2: New-AzConnectedNetworkVendor with SubscriptionId 
```powershell
New-AzConnectedNetworkVendor -Name myVendor2 -SubscriptionId xxxxx-22222-xxxxx-22222
```

```output
Id                           : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor2
Name                         : myVendor2
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 11/23/2021 6:20:28 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/23/2021 6:20:32 PM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors
```

Creating a vendor with name myVendor2 in xxxxx-22222-xxxxx-22222 subscription.

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

### -Name
The name of the vendor.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VendorName

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendor

## NOTES

## RELATED LINKS

