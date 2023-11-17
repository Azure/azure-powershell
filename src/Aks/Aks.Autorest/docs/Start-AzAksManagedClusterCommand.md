---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/start-azaksmanagedclustercommand
schema: 2.0.0
---

# Start-AzAksManagedClusterCommand

## SYNOPSIS
AKS will create a pod to run the command.
This is primarily useful for private clusters.
For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).

## SYNTAX

### RunExpanded (Default)
```
Start-AzAksManagedClusterCommand -ResourceGroupName <String> -ResourceName <String> -Command <String>
 [-SubscriptionId <String>] [-ClusterToken <String>] [-Context <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunViaIdentityExpanded
```
Start-AzAksManagedClusterCommand -InputObject <IAksIdentity> -Command <String> [-ClusterToken <String>]
 [-Context <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
AKS will create a pod to run the command.
This is primarily useful for private clusters.
For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).

## EXAMPLES

### Example 1: Run AKS command
```powershell
Start-AzAksManagedClusterCommand -ResourceGroupName mygroup -ResourceName mycluster -Command "kubectl get nodes"
```

```output
ExitCode          : 0
FinishedAt        : 3/31/2023 8:52:17 AM
Id                : 0a3991475d9744fcbfdc2595b40e517f
Log               : NAME                              STATUS   ROLES   AGE   VERSION
                    aks-default-40136599-vmss000000   Ready    agent   46m   v1.24.9
                    aks-pool2-22198594-vmss000000     Ready    agent   43m   v1.24.9

ProvisioningState : Succeeded
Reason            :
StartedAt         : 3/31/2023 8:52:16 AM
```

AKS will create a pod to run the command.
This is primarily useful for private clusters.

### Example 2: Run AKS command via identity 
```powershell
$cluster = Get-AzAksCluster -ResourceGroupName mygroup -Name mycluster
$cluster | Start-AzAksManagedClusterCommand -Command "kubectl get nodes"
```

```output
ExitCode          : 0
FinishedAt        : 3/31/2023 8:54:17 AM
Id                : 0a3991475d9744fcbfdc2595b40e517f
Log               : NAME                              STATUS   ROLES   AGE   VERSION
                    aks-default-40136599-vmss000000   Ready    agent   46m   v1.24.9
                    aks-pool2-22198594-vmss000000     Ready    agent   43m   v1.24.9

ProvisioningState : Succeeded
Reason            :
StartedAt         : 3/31/2023 8:54:16 AM
```



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

### -ClusterToken
AuthToken issued for AKS AAD Server App.

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

### -Command
The command to run.

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

### -Context
A base64 encoded zip file containing the files required by the command.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: RunViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: RunExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: RunExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: RunExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IRunCommandResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAksIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[CommandId <String>]`: Id of the command.
  - `[ConfigName <String>]`: The name of the maintenance configuration.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

