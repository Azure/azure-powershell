---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module/az.containerinstance/invoke-azcontainerinstancecommand
schema: 2.0.0
---

# Invoke-AzContainerInstanceCommand

## SYNOPSIS
Executes a command for a specific container instance in a specified resource group and container group.

## SYNTAX

```
Invoke-AzContainerInstanceCommand -ContainerGroupName <String> -ContainerName <String>
 -ResourceGroupName <String> -Command <String> -TerminalSizeCol <Int32> -TerminalSizeRow <Int32>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Executes a command for a specific container instance in a specified resource group and container group.

## EXAMPLES

### Example 1: Execute a command in a specific container instance
```powershell
PS C:\> Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello" -TerminalSizeCol 12 -TerminalSizeRow 12

Password                                           WebSocketUri
--------                                           ------------
****************** wss://bridge-linux-xx.eastus.management.azurecontainer.io/exec/caas-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/bridge-xxxxxxxxxxxxxxx?rows=12&cols=12api-version=2018-02-01-preview
```

Executes command "echo hello" in a container instance `test-container`.

## PARAMETERS

### -Command
The command to be executed.

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

### -ContainerGroupName
The name of the container group.

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

### -ContainerName
The name of the container instance.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ResourceGroupName
The name of the resource group.

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminalSizeCol
The column size of the terminal

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminalSizeRow
The row size of the terminal

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecResponse

## NOTES

ALIASES

## RELATED LINKS

