---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# New-AzManagedNetworkGroup

## SYNOPSIS
Creates a managedNetworkGroup.

## SYNTAX

### NameParameterSet (Default)
```
New-AzManagedNetworkGroup [-ResourceGroupName] <String> [-ManagedNetworkName] <String> [-Name] <String>
 -Location <String> [-ManagementGroupIdList <String[]>]
 [-SubscriptionIdList <String[]>]
 [-VirtualNetworkIdList <String[]>]
 [-SubnetIdList <String[]> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
New-AzManagedNetworkGroup [-Name] <String> -ManagedNetworkObject <PSManagedNetwork> -Location <String>
 [-ManagementGroupIdList <String[]>]
 [-SubscriptionIdList <String[]>]
 [-VirtualNetworkIdList <String[]>]
 [-SubnetIdList <String[]>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedNetworkGroup** cmdlet creates a managed network group.

## EXAMPLES

### 1: Create a managed network group by Name
```
$testmanagednetworkgroup = New-AzManagedNetworkGroup -ResourceGroupName TestRG -ManagedNetworkName TestManagedNetwork -Name TestGroup -Location exampleregion -VirtualNetworkIdList $VirtualNetworkIdList
```

### 2: Create a managed network group by ManagedNetwork Object
```
$testmanagednetworkgroup = New-AzManagedNetworkGroup -ManagedNetwork $managednetwork -Name TestGroup -Location exampleregion -VirtualNetworkIdList $VirtualNetworkIdList
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

### -Location
The Location assigned to a Managed Network.

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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupIdList
Azure ManagedNetwork management group ids.

```yaml
Type: System.String[]
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
Parameter Sets: (All)
Aliases:

Required: True
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

### -SubnetIdList
Azure ManagedNetwork subnet ids.

```yaml
Type: System.String[]
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
Type: System.String[]
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
Type: System.String[]
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

### System.String[]

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkGroup

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkGroup](./Get-AzManagedNetworkGroup.md)

[Remove-AzManagedNetworkGroup](./Remove-AzManagedNetworkGroup.md)

[update-AzManagedNetworkGroup](./Update-AzManagedNetworkGroup.md)