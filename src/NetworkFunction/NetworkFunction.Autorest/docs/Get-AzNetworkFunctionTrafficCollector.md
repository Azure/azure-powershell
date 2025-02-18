---
external help file:
Module Name: Az.NetworkFunction
online version: https://learn.microsoft.com/powershell/module/az.networkfunction/get-aznetworkfunctiontrafficcollector
schema: 2.0.0
---

# Get-AzNetworkFunctionTrafficCollector

## SYNOPSIS
Gets the specified Azure Traffic Collector in a specified resource group

## SYNTAX

### List (Default)
```
Get-AzNetworkFunctionTrafficCollector [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFunctionTrafficCollector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFunctionTrafficCollector -InputObject <INetworkFunctionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified Azure Traffic Collector in a specified resource group

## EXAMPLES

### Example 1: Get list of traffic collectors in selected subscription
```powershell
Get-AzNetworkFunctionTrafficCollector | Format-List
```

```output
CollectorPolicies : {}
Etag              : cf0336a2-7454-4aa4-add9-1de3e2291143
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/atcTest/providers/Microsoft.NetworkFunction/azureTrafficCollectors/pstestjuly18
Location          : eastus
Name              : pstestjuly18
ProvisioningState : Failed
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors

CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/atcTest/providers/Microsoft.NetworkFunction/azureTrafficCollectors/newpsatc
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors in selected subscription.

### Example 2: Get list of traffic collectors by resource group
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test | Format-List
```

```output
CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/newpsatc
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors by resource group.

### Example 3: Get list of traffic collectors by name
```powershell
Get-AzNetworkFunctionTrafficCollector -ResourceGroupName test -name test | Format-List
```

```output
CollectorPolicies : {}
Etag              : cedea0e9-e9e4-4b2e-816f-dad184d6b424
Id                : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/test/providers/Microsoft.NetworkFunction/azureTrafficCollectors/test
Location          : eastus
Name              : newpsatc
ProvisioningState : Succeeded
Tags              : Microsoft.Azure.PowerShell.Cmdlets.AzureTrafficCollector.Models.ResourceTags
Type              : Microsoft.NetworkFunction/AzureTrafficCollectors
```

This cmdlet gets list of traffic collectors by name.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.INetworkFunctionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Azure Traffic Collector name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AzureTrafficCollectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.INetworkFunctionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20221101.IAzureTrafficCollector

## NOTES

## RELATED LINKS

