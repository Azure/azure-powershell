---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Get-AzManagedNetworkPolicy

## SYNOPSIS
Gets a managednetwork network policy.

## SYNTAX

###ByName(Default)
```
 $managedNetworkPeeringPolicy = Get-AzManagedNetworkPeeringPolicy -ResourceGroupName <String> -ManagedNetworkName <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```

###ByResourceId
```
$managedNetworkPeeringPolicy = Get-AzManagedNetworkPeeringPolicy -ResourceId <String> [-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```

###ByManagedNetworkObject
```
$managedNetworkPeeringPolicy = Get-AzManagedNetworkPeeringPolicy -ManagedNetwork <PSManagedNetwork> [-Name <String>] [-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagedNetworkPolicy** cmdlet gets managednewtork policies.

## EXAMPLES

### 1: Retrieve a managednetwork policy by Name
```
Get-AzManagedNetworkPolicy -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestPolicy -Location userregion
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -Spokes $list

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
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -Spokes $list

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
-PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -Spokes $list

Properties : Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPeeringPolicyProperties
Id         : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedNetwork
             /managedNetworks/TestMN/managedNetworkPeeringPolicies/TestPolicy
Name       : TestPolicy
Type       : Microsoft.ManagedNetwork/managedNetworkPeeringPolicies
Location   : {userregion}
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
Specifies the name of the managednetwork policy that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ManagedNetworkObjectParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource policy that managed network belongs to.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -ManagedNetworkName
Specifies the name of the managed network name that policies belong to.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -ResourceId
Specifies the resourceId of the managedNetwork policy that this cmdlet gets.

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

### -ManagedNetwork
Specifies the the managedNetwork that the policy belongs to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSManagedNetwork
Parameter Sets: ManagedNetworkObjectParameterSet
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


