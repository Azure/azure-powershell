---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Get-AzManagedNetworkGroup

## SYNOPSIS
Gets a managednetwork network group.

## SYNTAX

### NameParameterSet (Default)
```
Get-AzManagedNetworkGroup [-ResourceGroupName] <String> [-ManagedNetworkName] <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
Get-AzManagedNetworkGroup [-Name <String>] -ManagedNetworkObejct <PSManagedNetwork>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzManagedNetworkGroup -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
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
Get-AzManagedNetworkGroup -ManagedNetworkObejct $ManagedNetwork -Name TestGroup

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

### -ManagedNetworkName
The unique name of the Managed Network.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The unique name of the Managed Network Group.

```yaml
Type: System.String
Parameter Sets: NameParameterSet, ManagedNetworkObjectParameterSet
Aliases:

Required: False
Position: Named
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

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkGroup

## NOTES

## RELATED LINKS

[New-AzManagedNetworkGroup](./New-AzManagedNetworkGroup.md)

[Remove-AzManagedNetworkGroup](./Remove-AzManagedNetworkGroup.md)

[Update-AzManagedNetworkGroup](./Update-AzManagedNetworkGroup.md)


