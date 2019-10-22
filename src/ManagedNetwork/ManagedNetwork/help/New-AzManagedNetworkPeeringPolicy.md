---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# New-AzManagedNetworkPeeringPolicy

## SYNOPSIS
Creates a managedNetwork peering policy.

## SYNTAX

### NameParameterSet (Default)
```
New-AzManagedNetworkPeeringPolicy [-ResourceGroupName] <String> [-ManagedNetworkName] <String> [-Name] <String>
 -Location <String> -PeeringPolicyType <String> [-Hub <String>]
 [-SpokeList <String[]>]
 [-Mesh <String[]>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
New-AzManagedNetworkPeeringPolicy [-Name] <String> -ManagedNetworkObject <PSManagedNetwork> -Location <String>
 -PeeringPolicyType <String> [-Hub <String>] [-SpokeList <String[]>]
 [-Mesh <String[]>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedNetworkPeeringPolicy** cmdlet creates a managed network policy.

## EXAMPLES

### 1: Create a managed network policy by Name
```
$testmanagednetworkgroup = New-AzManagedNetworkPeeringPolicy -ResourceGroupName TestRG -ManagedNetworkName TestManagedNetwork -Name TestPolicy -Location exampleregion -PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -SpokeList $list
```

### 2: Create a managed network policy by ManagedNetwork Object
```
$testmanagednetworkgroup = New-AzManagedNetworkPeeringPolicy -ManagedNetwork $managednetwork -Name TestPolicy -Location exampleregion -PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -SpokeList $list
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

### -Hub
Azure ManagedNetwork Policy Hub id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Azure ManagedNetwork Policy location.

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

### -Mesh
Azure ManagedNetwork Policy Mesh Groups.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The unique name of the Managed Network Peering Policy.

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

### -PeeringPolicyType
Azure ManagedNetwork Policy type.

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

### -SpokeList
Azure ManagedNetwork Policy Spoke Groups.

```yaml
Type: String[]
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

### String[]

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkPeeringPolicy

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkPeeringPolicy](./Get-AzManagedNetworkPeeringPolicy.md)

[Remove-AzManagedNetworkPeeringPolicy](./Remove-AzManagedNetworkPeeringPolicy.md)

[update-AzManagedNetworkPeeringPolicy](./Update-AzManagedNetworkPeeringPolicy.md)