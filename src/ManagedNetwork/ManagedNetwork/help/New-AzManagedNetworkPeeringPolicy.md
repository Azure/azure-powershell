---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# New-AzManagedNetworkPeeringPolicy

## SYNOPSIS
Creates a managedNetwork peering policy.

## SYNTAX


### By Name
```
New-AzManagedNetworkPeeringPolicy -ResourceGroupName <String> -ManagedNetworkName <String> -Name <String> -PeeringPolicyType <String> -Location <String> [-Hub <String>] [-Spoke <String[]>] [-Mesh <String[]>] [-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### By ManagedNetwork Object
```
New-AzManagedNetworkPeeringPolicy -ManagedNetwork <PSManagedNetwork>  -Name <String> -PeeringPolicyType <String> -Location <String> [-Hub <String>] [-Spoke <String[]>] [-Mesh <String[]>] [-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedNetworkPeeringPolicy** cmdlet creates a managed network policy.

## EXAMPLES

### 1: Create a managed network policy by Name
```
$testmanagednetworkgroup = New-AzManagedNetworkPeeringPolicy -ResourceGroupName TestRG -ManagedNetworkName TestManagedNetwork -Name TestPolicy -Location exampleregion -PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -Spokes $list
```

### 2: Create a managed network policy by ManagedNetwork Object
```
$testmanagednetworkgroup = New-AzManagedNetworkPeeringPolicy -ManagedNetwork $managednetwork -Name TestPolicy -Location exampleregion -PeeringPolicyType "HubAndSpokeTopology" -Hub $hub -Spokes $list
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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
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

### -Location
location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -PeeringPolicyType
Peering Policy Type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -Hub
Hub Vnet Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept wildcard characters: False
```

### -Spoke 
Spoke List.

```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept wildcard characters: False
```

### -Mesh 
Mesh List.

```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkPeeringPolicy

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkPeeringPolicy](./Get-AzManagedNetworkPeeringPolicy.md)

[Remove-AzManagedNetworkPeeringPolicy](./Remove-AzManagedNetworkPeeringPolicy.md)

[update-AzManagedNetworkPeeringPolicy](./Update-AzManagedNetworkPeeringPolicy.md)