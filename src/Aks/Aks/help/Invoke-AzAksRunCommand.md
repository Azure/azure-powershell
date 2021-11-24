---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Aks.dll-Help.xml
Module Name: Az.Aks
online version: https://docs.microsoft.com/powershell/module/az.aks/invoke-azaksruncommand
schema: 2.0.0
---

# Invoke-AzAksRunCommand

## SYNOPSIS
Run a shell command (with kubectl, helm) on your aks cluster, support attaching files as well.

## SYNTAX

### GroupNameParameterSet (Default)
```
Invoke-AzAksRunCommand [-ResourceGroupName] <String> [-Name] <String> -CommandString <String>
 [-CommandFile <String[]>] [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Invoke-AzAksRunCommand -InputObject <PSKubernetesCluster> -CommandString <String> [-CommandFile <String[]>]
 [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### IdParameterSet
```
Invoke-AzAksRunCommand [-Id] <String> -CommandString <String> [-CommandFile <String[]>] [-AsJob]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-SubscriptionId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Run a shell command (with kubectl, helm) on your aks cluster, support attaching files as well.

## EXAMPLES

### Example 1
```powershell
Invoke-AzAksRunCommand -ResourceGroupName $resourceGroup -Name $clusterName -CommandString "kubectl get pods"

Id                : a887ecf432ad4e22a517cf4b5fb4e194
ProvisioningState : Succeeded
ExitCode          : 0
StartedAt         : 11/24/2021 04:43:28
FinishedAt        : 11/24/2021 04:43:30
Logs              : No resources found in default namespace.

Reason            :
```

Get the pods in Aks cluster.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommandFile
Gets or sets a base64 encoded zip file containing the files required by the command.

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

### -CommandString
Gets or sets the command to run.

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Remove managed Kubernetes cluster without prompt

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of a managed Kubernetes cluster

```yaml
Type: String
Parameter Sets: IdParameterSet
Aliases: ResourceId

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
A PSKubernetesCluster object, normally passed through the pipeline.

```yaml
Type: PSKubernetesCluster
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of your managed Kubernetes cluster

```yaml
Type: String
Parameter Sets: GroupNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name

```yaml
Type: String
Parameter Sets: GroupNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.

By default, cmdlets are executed in the subscription that is set in the current context.
If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.

Overriding subscriptions only take effect during the lifecycle of the current cmdlet.
It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Aks.Models.PSRunCommandResult

## NOTES

## RELATED LINKS
