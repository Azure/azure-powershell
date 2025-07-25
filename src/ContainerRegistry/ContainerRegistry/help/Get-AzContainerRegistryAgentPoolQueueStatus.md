---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistryagentpoolqueuestatus
schema: 2.0.0
---

# Get-AzContainerRegistryAgentPoolQueueStatus

## SYNOPSIS
Gets the count of queued runs for a given agent pool.

## SYNTAX

### Get (Default)
```
Get-AzContainerRegistryAgentPoolQueueStatus -AgentPoolName <String> -RegistryName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistryAgentPoolQueueStatus -InputObject <IContainerRegistryIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets the count of queued runs for a given agent pool.

## EXAMPLES

### Example 1: Gets the count of queued runs for a given agent pool.
```powershell
Get-AzContainerRegistryAgentPoolQueueStatus -AgentPoolName agent -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
10
```

Gets the count of queued runs for a given agent pool.

## PARAMETERS

### -AgentPoolName
The name of the agent pool.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

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

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### System.Int32

## NOTES

## RELATED LINKS
