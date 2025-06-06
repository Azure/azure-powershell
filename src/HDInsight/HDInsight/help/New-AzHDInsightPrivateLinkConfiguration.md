---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version: https://learn.microsoft.com/powershell/module/az.hdinsight/new-azhdinsightprivatelinkconfiguration
schema: 2.0.0
---

# New-AzHDInsightPrivateLinkConfiguration

## SYNOPSIS
Creates the private link configuration of the HDInsight cluster.

## SYNTAX

```
New-AzHDInsightPrivateLinkConfiguration [-Name <String>] [-GroupId <String>]
 [-IpConfiguration <AzureHDInsightIPConfiguration[]>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet **New-AzHDInsightPrivateLinkConfiguration** creates the private link configuration in memeory

## EXAMPLES

### Example 1
```powershell
$vnetId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testrg/providers/Microsoft.Network/virtualNetworks/testvnet"
$subnetName="default"
$ipConfigName="ipconfig"
$privateIPAllocationMethod="dynamic"
$subnetId=$vnetId+"/subnets/"+$subnetName
# Create Private IP configuration
$ipConfiguration= New-AzHDInsightIPConfiguration -Name $ipConfigName -PrivateIPAllocationMethod $privateIPAllocationMethod -SubnetId $subnetId -Primary

$privateLinkConfigurationName="plconfig"
$groupId="headnode"
# Create private link configuration
$privateLinkConfiguration= New-AzHDInsightPrivateLinkConfiguration -Name $privateLinkConfigurationName -GroupId $groupId -IPConfiguration $ipConfiguration
```

This cmdlet creates the private link configuration in memory.

## PARAMETERS

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

### -GroupId
Gets or sets the group id of the private link.

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

### -IpConfiguration
Gets or sets the ip configurations of the private link.

```yaml
Type: Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Gets or sets the private link configuration name.

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
{{ Fill ProgressAction Description }}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightPrivateLinkConfiguration

## NOTES

## RELATED LINKS
