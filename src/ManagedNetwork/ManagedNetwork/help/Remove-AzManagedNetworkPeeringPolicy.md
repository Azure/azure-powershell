---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Remove-AzManagedNetworkPeeringPolicy

## SYNOPSIS
Removes a Managed Network Peering Policy.

## SYNTAX

### NameParameterSet (Default)
```
Remove-AzManagedNetworkPeeringPolicy [-ResourceGroupName] <String> [-ManagedNetworkName] <String>
 [-Name] <String> [-PassThru] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ManagedNetworkObjectParameterSet
```
Remove-AzManagedNetworkPeeringPolicy [-Name] <String> -ManagedNetworkObject <PSManagedNetwork> [-PassThru]
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzManagedNetworkPeeringPolicy -ResourceId <String> [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzManagedNetworkPeeringPolicy -InputObject <PSManagedNetworkPeeringPolicy> [-PassThru] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```


## DESCRIPTION
The **Remove-AzManagedNetworkPeeringPolicy** cmdlet removes a managed Network Peering Policy.

## EXAMPLES

### 1:  delete a Managed Network Peering Policy by name
```
Remove-AzManagedNetworkPeeringPolicy -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestMNPolicy
```

### 2:  delete a Managed Network Peering Policy by resourceId
```
Remove-AzManagedNetworkPeeringPolicy -ResourceId $resourceId
```


### 3:  delete a Managed Network Peering Policy by InputObject
```
Remove-AzManagedNetworkPeeringPolicy -InputObject $managedNetworkPolicy
```

### 3:  delete a Managed Network Peering Policy by managednetwork Object
```
Remove-AzManagedNetworkPeeringPolicy -ManagedNetwork $managedNetwork -Name TestMNPolicy
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
Type: Microsoft.Azure.Commands.ManagedNetwork.Models.PSManagedNetworkPeeringPolicy
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The unique name of the Managed Network Peering Policy.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkPeeringPolicy

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkPeeringPolicy](./Get-AzManagedNetworkPeeringPolicy.md)

[New-AzManagedNetworkPeeringPolicy](./New-AzManagedNetworkPeeringPolicy.md)

[Update-AzManagedNetworkPeeringPolicy](./Update-AzManagedNetworkPeeringPolicy.md)


