---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.containerinstance/get-azcontainerinstancecontainergroupoutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint

## SYNOPSIS
Gets all the network dependencies for this container group to allow complete control of network setting and configuration.
For container groups, this will always be an empty list.

## SYNTAX

### Get (Default)
```
Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -ContainerGroupName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint
 -InputObject <IContainerInstanceIdentity> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets all the network dependencies for this container group to allow complete control of network setting and configuration.
For container groups, this will always be an empty list.

## EXAMPLES

### Example 1: Get a list of the outbound network dependencies
```powershell
Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -ResourceGroupName test-rg -ContainerGroupName test-cg
```

```output
[]
```

This command returns a list of the outbound network dependencies for Container Instances.
Container Instances does not have any outbound network dependencies, so this list will be empty.

## PARAMETERS

### -ContainerGroupName
The name of the container group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IContainerInstanceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IContainerInstanceIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

Get-AzContainerGroupOutboundNetworkDependencyEndpoint

## RELATED LINKS
