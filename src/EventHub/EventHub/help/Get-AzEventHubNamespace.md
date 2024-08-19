---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubnamespace
schema: 2.0.0
---

# Get-AzEventHubNamespace

## SYNOPSIS
Gets the description of the specified namespace.

## SYNTAX

### List (Default)
```
Get-AzEventHubNamespace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzEventHubNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzEventHubNamespace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventHubNamespace -InputObject <IEventHubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the description of the specified namespace.

## EXAMPLES

### Example 1: Get an EventHub namespace
```powershell
Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

```output
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 3:14:09 PM
DisableLocalAuth                : True
EnableAutoInflate               : True
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    :
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MaximumThroughputUnit           : 0
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Standard
SkuTier                         : Standard
Status                          : Active
Tag                             : {
                                  }
TenantId                        : 00000000000
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:21:19 PM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : True
```

Gets details of an EventHub namespace `myNamespace` in resource group `myResourceGroup`.

### Example 2: List all EventHub namespaces in a resource group
```powershell
Get-AzEventHubNamespace -ResourceGroupName myResourceGroup
```

Lists all EventHub namespaces under resource group `myResourceGroup`.

### Example 3: List all EventHub namespaces in a subscription
```powershell
Get-AzEventHubNamespace
```

Lists all EventHub namespaces in the current subscription context.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Namespace name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NamespaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

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
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEhNamespace

## NOTES

ALIASES

Get-AzEventHubNamespaceV2

## RELATED LINKS
