---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-Help.xml
Module Name: Az.ServiceFabric
online version: https://docs.microsoft.com/powershell/module/az.servicefabric/get-azservicefabricmanagedclusterapplicationtypeversion
schema: 2.0.0
---

# Get-AzServiceFabricManagedClusterApplicationTypeVersion

## SYNOPSIS
Get Service Fabric managed application type version details. Only supports ARM deployed application type versions.

## SYNTAX

### ByResourceGroupAndCluster (Default)
```
Get-AzServiceFabricManagedClusterApplicationTypeVersion [-ResourceGroupName] <String> [-ClusterName] <String>
 [-Name] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVersion
```
Get-AzServiceFabricManagedClusterApplicationTypeVersion [-ResourceGroupName] <String> [-ClusterName] <String>
 [-Name] <String> [-Version] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Use this cmdlet to get the managed application type version details in the specified resource group and cluster.

## EXAMPLES

### Example 1
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appTypeName = "testAppType"
$appTypeVersion = "v1"
Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $appTypeVersion
```

This example gets the managed application type "testAppType" with version "v1", if it doesn't find the resource it will throw an exception.

### Example 2
```powershell
$resourceGroupName = "testRG"
$clusterName = "testCluster"
$appTypeName = "testAppType"
Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName
```

This example gets a list of the managed application type versions defined under the specified cluster and type.

### Example 3
```powershell
$resourceId = "/subscriptions/13ad2c84-84fa-4798-ad71-e70c07af873f/resourcegroups/testRG/providers/Microsoft.ServiceFabric/managedClusters/testCluster/applicationTypes/testAppType/versions/v1"
Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceId $resourceId
```

This example will get the managed application type version details with the ARM Resource ID specified, if it doesn't find the resource it will throw an exception.

## PARAMETERS

### -ClusterName
Specify the name of the cluster.

```yaml
Type: System.String
Parameter Sets: ByResourceGroupAndCluster, ByVersion
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specify the name of the managed application type.

```yaml
Type: System.String
Parameter Sets: ByResourceGroupAndCluster, ByVersion
Aliases: ApplicationTypeName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specify the name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByResourceGroupAndCluster, ByVersion
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of the managed application type version.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Specify the version of the managed application type.

```yaml
Type: System.String
Parameter Sets: ByVersion
Aliases: ApplicationTypeVersion

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedApplicationTypeVersion

## NOTES

## RELATED LINKS
