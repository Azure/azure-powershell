---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Get-AzManagedNetworkPolicy

## SYNOPSIS
Gets a managednetwork network policy.

## SYNTAX

### NameParameterSet (Default)
```
Get-AzManagedNetworkPeeringPolicy [-ResourceGroupName] <String> [-ManagedNetworkName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ListParameterSet
```
Get-AzManagedNetworkPeeringPolicy [[-ResourceGroupName] <String>] [-ManagedNetworkName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
Get-AzManagedNetworkPeeringPolicy [[-Name] <String>] -ManagedNetworkObject <PSManagedNetwork>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzManagedNetworkPeeringPolicy -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagedNetworkPolicy** cmdlet gets managednewtork policies.

## EXAMPLES

### 1: Retrieve a managednetwork policy by Name
```
Get-AzManagedNetworkPolicy -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestPolicy -Location userregion
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -SpokeList $list

Properties : Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPeeringPolicyProperties
Id         : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwork
             /managedNetworks/TestMN/managedNetworkPeeringPolicies/TestPolicy
Name       : TestPolicy
Type       : Microsoft.ManagedNetwork/managedNetworkPeeringPolicies
Location   : userregion
```

### 2: Retrieve a managednetwork policy by resource id
```
Get-AzManagedNetworkPolicy -ResourceGroupid $resourceId  -Location userregion
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -SpokeList $list

Properties : Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPeeringPolicyProperties
Id         : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwork
             /managedNetworks/TestMN/managedNetworkPeeringPolicies/TestPolicy
Name       : TestPolicy
Type       : Microsoft.ManagedNetwork/managedNetworkPeeringPolicies
Location   : {userregion}
```

### 3: Retrieve a managednetwork by ManagedNetwork Object
```
Get-AzManagedNetworkPolicy -ManagedNetwork $ManagedNetwork -Name TestPolicy  -Location userregion
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -SpokeList $list

Properties : Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPeeringPolicyProperties
Id         : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwork
             /managedNetworks/TestMN/managedNetworkPeeringPolicies/TestPolicy
Name       : TestPolicy
Type       : Microsoft.ManagedNetwork/managedNetworkPeeringPolicies
Location   : {userregion}
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedNetworkName
The unique name of the Managed Network.

```yaml
Type: System.String
Parameter Sets: NameParameterSet, ListParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedNetworkObject
The object of Managed Network.

```yaml
Type: Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetwork
Parameter Sets: ManagedNetworkObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The unique name of the Managed Network Peering Policy.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ManagedNetworkObjectParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The create or use an existing resource group name.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The unique ARM id of an existing resource.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetwork

## OUTPUTS

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPolicy

## NOTES

## RELATED LINKS

[New-AzManagedNetworkPolicy](./New-AzManagedNetworkPolicy.md)

[Remove-AzManagedNetworkPolicy](./Remove-AzManagedNetworkPolicy.md)

[Update-AzManagedNetworkPolicy](./Update-AzManagedNetworkPolicy.md)


