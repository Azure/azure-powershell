---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedprivatelinkscope
schema: 2.0.0
---

# Get-AzConnectedPrivateLinkScope

## SYNOPSIS
Returns a Azure Arc PrivateLinkScope.

## SYNTAX

### List (Default)
```
Get-AzConnectedPrivateLinkScope [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedPrivateLinkScope -ResourceGroupName <String> -ScopeName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzConnectedPrivateLinkScope -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a Azure Arc PrivateLinkScope.

## EXAMPLES

### Example 1: get all private link scope of a resource group
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName 'ytongtest'
```

```output
Id                           : /subscriptions/subcriptionid/resourceGroups/ytongtest/providers/M
                               icrosoft.HybridCompute/privateLinkScopes/myScope
Location                     : centraluseuap
Name                         : myScope
PrivateEndpointConnection    : {}
PrivateLinkScopeId           : scopeId
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/privateLinkScopes
```

get all private link scope of a resource group

### Example 2: get specific private link scope
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName 'ytongtest' -ScopeName 'myScope'
```

```output
Id                           : /subscriptions/********-****-****-****-**********/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/privateLinkScopes/myScope
Location                     : centraluseuap
Name                         : myScope
PrivateEndpointConnection    : {}
PrivateLinkScopeId           : ********-****-****-****-**********
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/privateLinkScopes
```

get specific private link scope

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ScopeName
The name of the Azure Arc PrivateLinkScope resource.

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IHybridComputePrivateLinkScope

## NOTES

## RELATED LINKS

