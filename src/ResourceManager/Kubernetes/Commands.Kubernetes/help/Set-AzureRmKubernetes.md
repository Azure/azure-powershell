---
external help file: Microsoft.Azure.Commands.Kubernetes.dll-Help.xml
Module Name: AzureRM.Kubernetes
online version: https://docs.microsoft.com/en-us/powershell/
schema: 2.0.0
---

# Set-AzureRmKubernetes

## SYNOPSIS
Update or create a managed Kubernetes cluster.

## SYNTAX

### defaultParameterSet (Default)
```
Set-AzureRmKubernetes [-ResourceGroupName] <String> [-Name] <String> [-Location <String>]
 [-AdminUserName <String>] [-DnsNamePrefix <String>] [-KubernetesVersion <String>] [-NodeCount <Int32>]
 [-NodeOsDiskSize <Int32>] [-NodeVmSize <String>] [-SshKeyValue <String>] [-Tags <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Set-AzureRmKubernetes -InputObject <PSKubernetesCluster> [-Location <String>] [-AdminUserName <String>]
 [-DnsNamePrefix <String>] [-KubernetesVersion <String>] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>]
 [-NodeVmSize <String>] [-SshKeyValue <String>] [-Tags <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### IdParameterSet
```
Set-AzureRmKubernetes [-Id] <String> [-Location <String>] [-AdminUserName <String>] [-DnsNamePrefix <String>]
 [-KubernetesVersion <String>] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>] [-NodeVmSize <String>]
 [-SshKeyValue <String>] [-Tags <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### servicePrincipalParameterSet
```
Set-AzureRmKubernetes [-ResourceGroupName] <String> [-Name] <String> [-ClientId] <String>
 [-ClientSecret] <String> [-Location <String>] [-AdminUserName <String>] [-DnsNamePrefix <String>]
 [-KubernetesVersion <String>] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>] [-NodeVmSize <String>]
 [-SshKeyValue <String>] [-Tags <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Update or create a managed Kubernetes cluster.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmKubernetes -ResourceGroupName group -Name myCluster | Set-AzureRmKubernetes -NodeCount 5
```

Set the number of nodes in the Kubernetes cluster to 5.

## PARAMETERS

### -AdminUserName
User name for the Linux Virtual Machines.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientIdAndSecret
The client ID of the AAD application / service principal used for cluster authentication to Azure APIs.

```yaml
Type: PSCredential
Parameter Sets: servicePrincipalParameterSet
Aliases:

Required: True
Position: 2
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

### -DnsNamePrefix
The DNS name prefix for the cluster.

```yaml
Type: String
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

### -KubernetesVersion
The version of Kubernetes to use for creating the cluster.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: 1.7.7, 1.8.1

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Azure location for the cluster.
Defaults to the location of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Kubernetes managed cluster Name.

```yaml
Type: String
Parameter Sets: defaultParameterSet, servicePrincipalParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The default number of nodes for the node pools.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeOsDiskSize
The default number of nodes for the node pools.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeVmSize
The size of the Virtual Machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: defaultParameterSet, servicePrincipalParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshKeyValue
SSH key file value or key file path.
Defaults to {HOME}/.ssh/id_rsa.pub.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Tags to be applied to the resource

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Kubernetes.Models.PSKubernetesCluster

## OUTPUTS

### Microsoft.Azure.Commands.Kubernetes.Models.PSKubernetesCluster

## NOTES

## RELATED LINKS
