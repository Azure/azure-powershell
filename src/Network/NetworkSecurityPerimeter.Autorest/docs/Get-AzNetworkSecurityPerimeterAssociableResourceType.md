---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterassociableresourcetype
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterAssociableResourceType

## SYNOPSIS
Gets the list of resources that are onboarded with NSP.
These resources can be associated with a network security perimeter

## SYNTAX

```
Get-AzNetworkSecurityPerimeterAssociableResourceType -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of resources that are onboarded with NSP.
These resources can be associated with a network security perimeter

## EXAMPLES

### Example 1: List Perimeter Associable Resource Types
```powershell
 Get-AzNetworkSecurityPerimeterAssociableResourceType -Location eastus2euap
```

```output
Location Name
-------- ----
         Microsoft.Sql.servers
         Microsoft.Storage.storageAccounts
         Microsoft.EventHub.namespaces
         Microsoft.CognitiveServices.accounts
         Microsoft.Search.searchServices
         Microsoft.Purview.accounts
         Microsoft.ContainerService.managedClusters
         Microsoft.KeyVault.vaults
         Microsoft.OperationalInsights.workspaces
         Microsoft.Insights.dataCollectionEndpoints
         Microsoft.ServiceBus.namespaces
```

List Perimeter Associable Resource Types

## PARAMETERS

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

### -Location
The location of network security perimeter.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.IPerimeterAssociableResource

## NOTES

ALIASES

## RELATED LINKS

