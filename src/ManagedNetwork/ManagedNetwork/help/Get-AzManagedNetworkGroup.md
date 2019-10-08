---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Get-AzManagedNetworkGroup

## SYNOPSIS
Gets a managednetwork network group.

## SYNTAX

###ByName(Default)
```
Get-AzManagedNetworkGroup -ResourceGroupName <String> -ManagedNetworkName <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

###ByResourceId
```
Get-AzManagedNetworkGroup -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

###ByManagedNetworkObject
```
Get-AzManagedNetworkGroup -ManagedNetwork <PSManagedNetwork> [-Name <String>][-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagedNetworkGroup** cmdlet gets managednewtork groups.

## EXAMPLES

### 1: Retrieve a managednetwork group by Name
```
Get-AzManagedNetworkGroup -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestGroup

ManagementGroups : {}
Subscriptions    : {}
VirtualNetworks  : {{vnetId1}, {vnetId2}}
Subnets          : {}
Id               : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedN
                   etwork/managedNetworks/TestMN/managedNetworkGroups/TestGroup
Name             : TestGroup
Type             : Microsoft.ManagedNetwork/managedNetworkGroups
Location         : {userregion}
```

### 2: Retrieve a managednetwork group by resource id
```
Get-AzManagedNetworkGroup -ResourceGroupid $resourceId

ManagementGroups : {}
Subscriptions    : {}
VirtualNetworks  : {{vnetId1}, {vnetId2}}
Subnets          : {}
Id               : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedN
                   etwork/managedNetworks/TestMN/managedNetworkGroups/TestGroup
Name             : TestGroup
Type             : Microsoft.ManagedNetwork/managedNetworkGroups
Location         : {userregion}
```

### 3: Retrieve a managednetwork by ManagedNetwork Object
```
Get-AzManagedNetworkGroup -ManagedNetwork $ManagedNetwork -Name TestGroup

ManagementGroups : {}
Subscriptions    : {}
VirtualNetworks  : {{vnetId1}, {vnetId2}}
Subnets          : {}
Id               : subscriptions/{usersubscriptionId}/resourceGroups/TestRG/providers/Microsoft.ManagedN
                   etwork/managedNetworks/TestMN/managedNetworkGroups/TestGroup
Name             : TestGroup
Type             : Microsoft.ManagedNetwork/managedNetworkGroups
Location         : {userregion}
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
Specifies the name of the managednetwork group that this cmdlet gets.

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
Specifies the name of the resource group that managed network belongs to.

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
Specifies the name of the managed network that groups belong to.

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
Specifies the resourceId of the managedNetworkgroup that this cmdlet gets.

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
Specifies the the managedNetwork that the group belongs to.

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

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkGroup

## NOTES

## RELATED LINKS

[New-AzManagedNetworkGroup](./New-AzManagedNetworkGroup.md)

[Remove-AzManagedNetworkGroup](./Remove-AzManagedNetworkGroup.md)

[Update-AzManagedNetworkGroup](./Update-AzManagedNetworkGroup.md)


