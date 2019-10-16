---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Update-AzManagedNetworkGroup

## SYNOPSIS
Update a managedNetworkGroup.

## SYNTAX

### NameParameterSet (Default)
```
Update-AzManagedNetworkGroup [-ResourceGroupName] <String> [-ManagedNetworkName] <String> [-Name] <String>
 [-ManagementGroupIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubscriptionIdList <System.Collections.Generic.List`1[System.String]>]
 [-VirtualNetworkIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubnetIdList <System.Collections.Generic.List`1[System.String]>] [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
Update-AzManagedNetworkGroup [-Name] <String> -ManagedNetworkObject <PSManagedNetwork>
 [-ManagementGroupIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubscriptionIdList <System.Collections.Generic.List`1[System.String]>]
 [-VirtualNetworkIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubnetIdList <System.Collections.Generic.List`1[System.String]>] [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzManagedNetworkGroup -ResourceId <String>
 [-ManagementGroupIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubscriptionIdList <System.Collections.Generic.List`1[System.String]>]
 [-VirtualNetworkIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubnetIdList <System.Collections.Generic.List`1[System.String]>] [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzManagedNetworkGroup -InputObject <PSManagedNetworkGroup>
 [-ManagementGroupIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubscriptionIdList <System.Collections.Generic.List`1[System.String]>]
 [-VirtualNetworkIdList <System.Collections.Generic.List`1[System.String]>]
 [-SubnetIdList <System.Collections.Generic.List`1[System.String]>] [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzManagedNetworkGroup** cmdlet updates a managed network group.

## EXAMPLES

### 1: Updates a managed network group by name
```
Update-AzManagedNetworkGroup -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestGroup -VirtualNetworkIdList $VirtualNetworkIdList
```

### 2: Updates a managed network group by resourceid
```
Update-AzManagedNetworkGroup -ResourceId $resourceId -VirtualNetworkIdList $VirtualNetworkIdList
```

### 3: Updates a managed network group by input object
```
Update-AzManagedNetworkGroup -InputObject $managedNetworkgroup -VirtualNetworkIdList $VirtualNetworkIdList
```

### 3: Updates a managed network group by managednetwork object
```
Update-AzManagedNetworkGroup -ManagedNetwork $managedNetwork -Name TestGroup -VirtualNetworkIdList $VirtualNetworkIdList
```

## PARAMETERS

### -AsJob
Run in the background.

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

### -Force
Force the operation to complete

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

### -InputObject
The Input Object.

```yaml
Type: Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkGroup
Parameter Sets: InputObjectParameterSet
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

### -ManagedNetworkObject
The object of Managed Network.

```yaml
Type: Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetwork
Parameter Sets: ManagedNetworkObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupIdList
Azure ManagedNetwork management group ids.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return true if complete

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

### -SubnetIdList
Azure ManagedNetwork subnet ids.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionIdList
Azure ManagedNetwork subscription ids.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkIdList
Azure ManagedNetwork virtual network ids.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### System.String

### System.Collections.Generic.List<String>

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkGroup

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkGroup

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkGroup](./Get-AzManagedNetworkGroup.md)

[Remove-AzManagedNetworkGroup](./Remove-AzManagedNetworkGroup.md)

[New-AzManagedNetworkGroup](./New-AzManagedNetworkGroup.md)