---
external help file: Microsoft.Azure.Commands.Kubernetes.dll-Help.xml
Module Name: AzureRM.Kubernetes
online version: https://docs.microsoft.com/en-us/powershell/
schema: 2.0.0
---

# Start-AzureRmKubernetesDashboard

## SYNOPSIS
Create a Kubectl SSH tunnel to the managed cluster's dashboard.

## SYNTAX

### InputObjectParameterSet
```
Start-AzureRmKubernetesDashboard -InputObject <PSKubernetesCluster> [-DisableBrowser]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IdParameterSet
```
Start-AzureRmKubernetesDashboard [-Id] <String> [-DisableBrowser] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GroupNameParameterSet
```
Start-AzureRmKubernetesDashboard [-Name] <String> [-ResourceGroupName] <String> [-DisableBrowser]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create a Kubectl SSH tunnel to the managed cluster's dashboard. The SSH tunnel is setup in a PowerShell job called Kubectl-Tunnel and can be found by running `Get-Job`. The tunnel should be accessable via [http://127.0.0.1:8001](http://127.0.0.1:8001).

## EXAMPLES

### Start an SSH tunnel and open a browser to the Kubernetes dashboard
```
PS C:\> Start-AzureRmKubernetesDashboard -ResourceGroupName group -Name myCluster
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableBrowser
Do not pop open a browser after establising the kubectl port-forward.

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
Aliases:

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
Position: 0
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
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Kubernetes.Models.PSKubernetesCluster

## OUTPUTS

### Microsoft.Azure.Commands.Kubernetes.KubeTunnelJob

## NOTES

## RELATED LINKS
