---
external help file: Microsoft.Azure.Commands.Kubernetes.dll-Help.xml
Module Name: AzureRM.Kubernetes
online version: https://docs.microsoft.com/en-us/powershell/
schema: 2.0.0
---

# Import-AzureRmKubernetesCredential

## SYNOPSIS
Import and merge Kubectl config for a managed Kubernetes Cluster.

## SYNTAX

### InputObjectParameterSet
```
Import-AzureRmKubernetesCredential -InputObject <PSKubernetesCluster> [-Admin] [[-ConfigPath] <String>]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IdParameterSet
```
Import-AzureRmKubernetesCredential [-Id] <String> [-Admin] [[-ConfigPath] <String>] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GroupNameParameterSet
```
Import-AzureRmKubernetesCredential [-Name] <String> [-ResourceGroupName] <String> [-Admin]
 [[-ConfigPath] <String>] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Import and merge Kubectl config for a managed Kubernetes Cluster.

## EXAMPLES

### Import and merge Kubectl config
```
PS C:\> Import-AzureRmKubernetesCredential -ResourceGroupName group -Name myCluster
```

## PARAMETERS

### -Admin
Get the 'clusterAdmin' kubectl config instead of the default 'clusterUser'.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigPath
A kubectl config file to create or update.
Use '-' to print YAML to stdout instead.
Default: %Home%/.kube/config.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Import Kubernetes config even if it is the defualt

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## OUTPUTS

### System.String
The Kubernetes config file as a string

## NOTES

## RELATED LINKS
