---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/new-azconfluentcluster
schema: 2.0.0
---

# New-AzConfluentCluster

## SYNOPSIS
Create confluent clusters

## SYNTAX

### CreateExpanded (Default)
```
New-AzConfluentCluster -Id <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Kind <String>] [-MetadataCreatedTimestamp <String>]
 [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>] [-MetadataSelf <String>]
 [-MetadataUpdatedTimestamp <String>] [-Spec <IScClusterSpecEntity>] [-StatusCku <Int32>]
 [-StatusPhase <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConfluentCluster -Id <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConfluentCluster -Id <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityOrganizationExpanded
```
New-AzConfluentCluster -Id <String> -EnvironmentId <String> -OrganizationInputObject <IConfluentIdentity>
 [-Kind <String>] [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>]
 [-MetadataResourceName <String>] [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>]
 [-Spec <IScClusterSpecEntity>] [-StatusCku <Int32>] [-StatusPhase <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzConfluentCluster -Id <String> -EnvironmentInputObject <IConfluentIdentity> [-Kind <String>]
 [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>]
 [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>] [-Spec <IScClusterSpecEntity>]
 [-StatusCku <Int32>] [-StatusPhase <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create confluent clusters

## EXAMPLES

### Example 1: Create Confluent Cluster
```powershell
$spec = @{
    Name         = "cluster_4"
    Availability = "SINGLE_ZONE"
    Cloud        = "Azure"
    Region       = "centralus"
    ConfigKind   = "Basic"          # maps to spec.config.kind
    EnvironmentId = "env-exampleenv001" # maps to spec.environment.id
}

New-AzConfluentCluster `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -Id "lkc-xxxxx" `
    -Kind "Cluster" `
    -Spec $spec
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-xxxxx
Kind                         : Cluster
MetadataCreatedTimestamp     :
MetadataDeletedTimestamp     :
MetadataResourceName         :
MetadataSelf                 :
MetadataUpdatedTimestamp     :
Name                         : lkc-xxxxx
ResourceGroupName            : sharedrp-confluent
Spec                         : {
                                 "config": {
                                   "kind": "Basic"
                                 },
                                 "environment": {
                                   "id": "env-exampleenv001"
                                 },
                                 "name": "cluster_4",
                                 "availability": "SINGLE_ZONE",
                                 "cloud": "Azure",
                                 "region": "centralus"
                               }
StatusCku                    :
StatusPhase                  :
SystemDataCreatedAt          : 3/7/2026 2:07:47 PM
SystemDataCreatedBy          : user4@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/7/2026 2:07:47 PM
SystemDataLastModifiedBy     : user4@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.confluent/organizations/environments/clusters
```

This command create confluent clusters

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

### -EnvironmentId
Confluent environment id

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Id
Confluent kafka or schema registry cluster id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Type of cluster

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataCreatedTimestamp
Created Date Time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataDeletedTimestamp
Deleted Date time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataResourceName
Resource name of the record

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataSelf
Self lookup url

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataUpdatedTimestamp
Updated Date time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Spec
Specification of the cluster

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IScClusterSpecEntity
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusCku
The number of Confluent Kafka Units

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusPhase
The lifecycle phase of the cluster

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
Aliases:

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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IScClusterRecord

## NOTES

## RELATED LINKS
