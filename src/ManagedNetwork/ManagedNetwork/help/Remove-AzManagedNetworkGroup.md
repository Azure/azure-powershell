---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# Remove-AzManagedNetworkGroup

## SYNOPSIS
Removes a Managed Network Group.

## SYNTAX

### Remove by Name
```
Remove-AzManagedNetworkGroup -ResourceGroupName <String> -ManagedNetworkName <String> -Name <String> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Remove by ResourceId
```
Remove-AzManagedNetworkGroup -ResourceId <String> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Remove by Input Object
```
Remove-AzManagedNetworkGroup -InputObject <PSManagedNetworkGroup> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Remove by managednetwork Object
```
Remove-AzManagedNetworkGroup -ManagedNetwork <PSManagedNetwork> -Name <String> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```


## DESCRIPTION
The **Remove-AzManagedNetworkGroup** cmdlet removes a managed Network Group.

## EXAMPLES

### 1:  delete a Managed Network Group by name
```
Remove-AzManagedNetworkGroup -ResourceGroupName TestRG -ManagedNetworkName TestMN -Name TestMNGroup
```

### 2:  delete a Managed Network Group by resourceId
```
Remove-AzManagedNetworkGroup -ResourceId $resourceId
```


### 3:  delete a Managed Network Group by InputObject
```
Remove-AzManagedNetworkGroup -InputObject $managedNetworkGroup
```

### 3:  delete a Managed Network Group by managednetwork Object
```
Remove-AzManagedNetworkGroup -ManagedNetwork $managedNetwork -Name TestMNGroup
```

## PARAMETERS

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

### -Force
Forces the command to run without asking for user confirmation.

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
Specifies the name of the resource group that contains the managedNetworkgroup that this cmdlet removes.

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
Specifies the name of the managedNetworkgroup that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Specifies the resourceId of the managedNetworkgroup that this cmdlet removes.

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
Specifies the InputObject of the managedNetworkgroup that this cmdlet removes.

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

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

### Microsoft.Azure.Commands.Network.Models.PSManagedNetworkGroup

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzManagedNetworkGroup](./Get-AzManagedNetworkGroup.md)

[New-AzManagedNetworkGroup](./New-AzManagedNetworkGroup.md)

[Update-AzManagedNetworkGroup](./Update-AzManagedNetworkGroup.md)


