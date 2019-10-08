---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Update-AzManagedNetworkGroup

## SYNOPSIS
Update a managedNetworkGroup.

## SYNTAX

### Update ManagedNetworkGroup by name 
```
Update-AzManagedNetworkGroup -ResourceGroupName <String> -ManagedNetworkName <String> -Name <String> [-ManagementGroupIdList <String[]>] [-SubscriptionIdList <String[]>] [-VirtualNetworkIdList <String[]>] [-SubnetIdList <String[]>] [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Update ManagedNetworkGroup by resourceid 
```
Update-AzManagedNetworkGroup -ResourceId <String> [-ManagementGroupIdList <String[]>] [-SubscriptionIdList <String[]>] [-VirtualNetworkIdList <String[]>] [-SubnetIdList <String[]>] [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Update ManagedNetworkGroup by input object
```
 Update-AzManagedNetworkGroup -InputObject <PSManagedNetworkGroup> [-ManagementGroupIdList <String[]>] [-SubscriptionIdList <String[]>] [-VirtualNetworkIdList <String[]>] [-SubnetIdList <String[]>] [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Update ManagedNetworkGroup by managednetwork object
```
Update-AzManagedNetworkGroup -ManagedNetwork <PSManagedNetwork> -Name <String>  [-ManagementGroupIdList <String[]>] [-SubscriptionIdList <String[]>] [-VirtualNetworkIdList <String[]>] [-SubnetIdList <String[]>] [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
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

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -AsJob
Run cmdlet in the background

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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagedNetworkName
The managed network Name

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ManagedNetworkObjectParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Specifies the resourceId of the managedNetworkgroup that this cmdlet updates.

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

### -InputObject
Specifies the InputObject of the managedNetwork that this cmdlet updates.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSManagedNetworkGroup
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagedNetworkObject
Specifies the ManagedNetwork Object the group belongs to. 

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

### -ManagementGroupIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubnetIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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