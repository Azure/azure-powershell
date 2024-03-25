---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksavailableclusterversion
schema: 2.0.0
---

# Get-AzHdInsightOnAksAvailableClusterVersion

## SYNOPSIS
Returns a list of available cluster versions.

## SYNTAX

```
Get-AzHdInsightOnAksAvailableClusterVersion -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of available cluster versions.

## EXAMPLES

### Example 1: Returns all cluster type versions in a region.
```powershell
$location = "west us 2"
Get-AzHdInsightOnAksAvailableClusterVersion -Location $location
```

```output
ClusterPoolVersion           : 1.0
ClusterType                  : Flink
ClusterVersionValue          : 1.0.5
Component                    : {Flink, Hive Metastore}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/flink_1.16.0-1.0.5
IsPreview                    : False
Name                         : flink_1.16.0-1.0.5
OssVersion                   : 1.16.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Flink
ClusterVersionValue          : 1.0.6
Component                    : {Flink, Hive Metastore}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/flink_1.16.0-1.0.6
IsPreview                    : False
Name                         : flink_1.16.0-1.0.6
OssVersion                   : 1.16.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Spark
ClusterVersionValue          : 1.0.5
Component                    : {Yarn, Spark, Hive Metastore, Zookeeper}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/spark_3.3.1-1.0.5
IsPreview                    : False
Name                         : spark_3.3.1-1.0.5
OssVersion                   : 3.3.1
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Spark
ClusterVersionValue          : 1.0.6
Component                    : {Yarn, Spark, Hive Metastore, Zookeeper}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/spark_3.3.1-1.0.6
IsPreview                    : False
Name                         : spark_3.3.1-1.0.6
OssVersion                   : 3.3.1
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Stub
ClusterVersionValue          : 1.0.0
Component                    : {ResourceManager}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/stub_2.4.1-1.0.0
IsPreview                    : False
Name                         : stub_2.4.1-1.0.0
OssVersion                   : 2.4.1
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Stub
ClusterVersionValue          : 1.0.1
Component                    : {ResourceManager}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/stub_2.4.1-1.0.1
IsPreview                    : False
Name                         : stub_2.4.1-1.0.1
OssVersion                   : 2.4.1
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Stub
ClusterVersionValue          : 1.0.0
Component                    : {ResourceManager}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/stub_2.4.2-1.0.0
IsPreview                    : False
Name                         : stub_2.4.2-1.0.0
OssVersion                   : 2.4.2
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           :
ClusterType                  : Stub
ClusterVersionValue          : 1.1.0
Component                    : {ResourceManager}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/stub_2.4.3-1.1.0
IsPreview                    : False
Name                         : stub_2.4.3-1.1.0
OssVersion                   : 2.4.3
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Trino
ClusterVersionValue          : 1.0.6
Component                    : {Trino, Hive metastore}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/trino_0.410.0-1.0.6
IsPreview                    : False
Name                         : trino_0.410.0-1.0.6
OssVersion                   : 0.410.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :

ClusterPoolVersion           : 1.0
ClusterType                  : Trino
ClusterVersionValue          : 1.0.5
Component                    : {Trino, Hive metastore}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterversions/trino_0.410.0-1.0.5
IsPreview                    : False
Name                         : trino_0.410.0-1.0.5
OssVersion                   : 0.410.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

Get all available cluster versions in West US 2

## PARAMETERS

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

### -Location
The name of the Azure region.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterVersion

## NOTES

## RELATED LINKS
