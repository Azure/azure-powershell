---
external help file: Microsoft.Azure.Commands.Kubernetes.dll-Help.xml
Module Name: AzureRM.Kubernetes
online version: https://docs.microsoft.com/en-us/powershell/
schema: 2.0.0
---

# Get-AzureRmKubernetes

## SYNOPSIS
List Kubernetes managed clusters.

## SYNTAX

### IdParameterSet
```
Get-AzureRmKubernetes [-Id] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NameParameterSet
```
Get-AzureRmKubernetes [-Name] <String> [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceGroupParameterSet
```
Get-AzureRmKubernetes [[-ResourceGroupName] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
List Kubernetes managed clusters.

## EXAMPLES

### List all Kubernetes clusters
```
PS C:\> Get-AzureRmKubernetes
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

### -Name
Name of your managed Kubernetes cluster

```yaml
Type: String
Parameter Sets: NameParameterSet
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
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## OUTPUTS

### Microsoft.Azure.Commands.Kubernetes.Models.PSKubernetesCluster
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Kubernetes.Models.PSKubernetesCluster]]

## NOTES

## RELATED LINKS
