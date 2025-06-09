---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/set-azhdinsightgatewaycredential
schema: 2.0.0
---

# Set-AzHDInsightGatewayCredential

## SYNOPSIS
Sets the gateway HTTP credentials of an Azure HDInsight cluster.

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzHDInsightGatewayCredential [-Name] <String> [[-HttpCredential] <PSCredential>]
 [-ResourceGroupName <String>] [-EntraUserIdentity <String>] [-EntraUserFullInfo <Hashtable[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzHDInsightGatewayCredential [[-HttpCredential] <PSCredential>] [-EntraUserIdentity <String>]
 [-EntraUserFullInfo <Hashtable[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 -InputObject <AzureHDInsightCluster> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzHDInsightGatewayCredential [[-HttpCredential] <PSCredential>] [-EntraUserIdentity <String>]
 [-EntraUserFullInfo <Hashtable[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] -ResourceId <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzHDInsightGatewayCredential** cmdlet sets gateway credential of an Azure HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$clusterCreds = Get-Credential

Set-AzHDInsightGatewayCredential `
            -ClusterName $clusterName `
            -HttpCredential $clusterCreds
```

This command sets gateway credential of the cluster named your-hadoop-001 by name parameter set.

### Example 2
```powershell
Set-AzHDInsightGatewayCredential `
            -ResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/your-hadoop-001" `
            -HttpCredential $clusterCreds
```

This command sets gateway credential of the cluster named your-hadoop-001 by ResourceId parameter set.

### Example 3
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$clusterCreds = Get-Credential

Get-AzHDInsightCluster -ClusterName $clusterName | Set-AzHDInsightGatewayCredential `
            -HttpCredential $clusterCreds
```

This command sets gateway credential of the cluster named your-hadoop-001 by InputObject parameter set.

### Example 4 
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$entraUserFullInfo = @(@{ObjectId = "your-ObjectId"; Upn = "your-Upn"; DisplayName = "your-DisplayName" })

Set-AzHDInsightGatewayCredential `
            -ClusterName $clusterName `
            -EntraUserFullInfo $entraUserFullInfo
```

This command sets gateway EntraUser of the cluster named your-hadoop-001 by EntraUser Full Info.

### Example 5
```powershell
# Cluster info
$clusterName = "your-hadoop-001"
$entraUserIdentity = "your-ObjectId or your-Upn"

Set-AzHDInsightGatewayCredential `
            -ClusterName $clusterName `
            -EntraUserIdentity $entraUserIdentity
```

This command sets gateway EntraUser of the cluster named your-hadoop-001 by ObjectId Or Upn.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -EntraUserFullInfo
Gets or sets a list of Entra users as an array of hashtables. Each hashtable should contain keys such as ObjectId, UPN, and DisplayName.

```yaml
Type: System.Collections.Hashtable[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntraUserIdentity
Gets or sets the Entra user data. Accepts one or more ObjectId/UPN separated by ','.

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

### -HttpCredential
Gets or sets the login for the cluster's user.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Gets or sets the input object.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases: ClusterName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Gets or sets the resource id.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.HDInsight.Models.Management.AzureHDInsightGatewaySettings

## NOTES

## RELATED LINKS
