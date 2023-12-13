---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/remove-azservicebusnamespace
schema: 2.0.0
---

# Remove-AzServiceBusNamespace

## SYNOPSIS
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

## SYNTAX

### Delete (Default)
```
Remove-AzServiceBusNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzServiceBusNamespace -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes an existing namespace.
This operation also removes all associated resources under the namespace.

## EXAMPLES

### Example 1: Deletes an existing namespace.
```powershell
Remove-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup`.

### Example 2: Delete an ServiceBus namespace using InputObject parameter set
```powershell
$namespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzServiceBusNamespace -InputObject $namespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.

## PARAMETERS

### -AsJob
Run the command as a job

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The namespace name

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: NamespaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PassThru
Returns true when the command succeeds

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
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Remove-AzServiceBusNamespaceV2

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceBusIdentity>`: Identity Parameter
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ConfigName <MigrationConfigurationName?>]`: The configuration name. Should always be "$default".
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[QueueName <String>]`: The queue name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RuleName <String>]`: The rule name.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SubscriptionName <String>]`: The subscription name.
  - `[TopicName <String>]`: The topic name.

## RELATED LINKS

