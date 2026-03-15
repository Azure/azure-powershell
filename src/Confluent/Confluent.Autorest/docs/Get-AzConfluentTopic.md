---
external help file:
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluenttopic
schema: 2.0.0
---

# Get-AzConfluentTopic

## SYNOPSIS
Get confluent topic by Name

## SYNTAX

### List (Default)
```
Get-AzConfluentTopic -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-PageSize <Int32>] [-PageToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConfluentTopic -ClusterId <String> -EnvironmentId <String> -Name <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConfluentTopic -InputObject <IConfluentIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzConfluentTopic -ClusterInputObject <IConfluentIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityEnvironment
```
Get-AzConfluentTopic -ClusterId <String> -EnvironmentInputObject <IConfluentIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzConfluentTopic -ClusterId <String> -EnvironmentId <String> -Name <String>
 -OrganizationInputObject <IConfluentIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get confluent topic by Name

## EXAMPLES

### Example 1: List Topics in a cluster
```powershell
Get-AzConfluentTopic -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
cosmos.metadata.topic.lcc-stgc1vpmx5                                                                                                                                                sharedrp-confluent
cosmos.metadata.topic.lcc-stgcm9kon1                                                                                                                                                sharedrp-confluent
cosmos.metadata.topic.lcc-stgcq309wp                                                                                                                                                sharedrp-confluent
dlq-lcc-stgc3xwgpm                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc5jmo38                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc62rn93                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc80v17q                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcdn1njo                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcdnvydz                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcgokr23                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcgow69m                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcm92vnw                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcm9g1zq                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcn8j9gk                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcp2kpgk                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcydg857                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcydyj1o                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyv2666                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyvd3ok                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyvg91k                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgczxdz73                                                                                                                                                                  sharedrp-confluent
testtopic1                                                                                                                                                                          sharedrp-confluent
topic_1                                                                                                                                                                             sharedrp-confluent
topic_2                                                                                                                                                                             sharedrp-confluent
topic_3                                                                                                                                                                             sharedrp-confluent
```

This command lists all topics in cluster

### Example 2: Get Topic by topic name
```powershell
Get-AzConfluentTopic -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -Name <String> -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
ConfigRelated                :
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-examplekafka1/topics/topic_1
InputConfig                  : {}
Kind                         :
MetadataResourceName         :
MetadataSelf                 : Self
Name                         : topic_1
PartitionReassignmentRelated :
PartitionRelated             :
PartitionsCount              : 6
ReplicationFactor            : 3
ResourceGroupName            : sharedrp-confluent
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TopicId                      :
Type                         : microsoft.confluent/organizations/environments/clusters/topics
```

This command fetches topic details by topic name

## PARAMETERS

### -ClusterId
Confluent kafka or schema registry cluster id

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityEnvironment, GetViaIdentityOrganization, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -EnvironmentId
Confluent environment id

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentityEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Confluent kafka or schema registry topic name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster, GetViaIdentityEnvironment, GetViaIdentityOrganization
Aliases: TopicName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
Pagination size

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageToken
An opaque pagination token to fetch the next set of records

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.ITopicRecord

## NOTES

## RELATED LINKS

