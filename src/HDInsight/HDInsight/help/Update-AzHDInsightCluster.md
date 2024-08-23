---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/update-azhdinsightcluster
schema: 2.0.0
---

# Update-AzHDInsightCluster

## SYNOPSIS
Update tags or managed identities for a HDInsight cluster.

## SYNTAX

```
Update-AzHDInsightCluster [-ClusterName] <String> [-IdentityType <String>] [-IdentityId <String>]
 [-Tag <System.Collections.Generic.Dictionary`2[System.String,System.String]>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This **Update-AzHDInsightCluster** cmdlet update  the tags or managed identity of HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
$clusterName = "your-hadoop-001"
$tags = New-Object 'System.Collections.Generic.Dictionary[System.String,System.String]'
$tags.Add('Tag1', 'Value1')
$tags.Add('Tag2', 'Value2')

Update-AzHDInsightCluster -ClusterName $clusterName -Tag $tags
```

Update tags for the cluster.

### Example 2
```powershell
$clusterName = "your-hadoop-001"
$identityId = "/subscriptions/00000000-0000-0000-0000-000000000000
/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-msi"

Update-AzHDInsightCluster -ClusterName $clusterName -IdentityType UserAssigned -IdentityId $identityId
```

Update UserAssigned identity for the cluster.

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### -IdentityId
Gets or sets the list of user identities associated with the cluster.

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

### -IdentityType
Gets or sets the type of identity used for the cluster.
Possible values include: SystemAssigned, UserAssigned.

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

### -ProgressAction

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

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

### -Tag
The resource tags.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster

## NOTES

## RELATED LINKS
