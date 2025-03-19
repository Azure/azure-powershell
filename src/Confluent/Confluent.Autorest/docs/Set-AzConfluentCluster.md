---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/set-azconfluentcluster
schema: 2.0.0
---

# Set-AzConfluentCluster

## SYNOPSIS
Create confluent clusters

## SYNTAX

```
Set-AzConfluentCluster -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Id <String>] [-Kind <String>]
 [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>]
 [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>] [-Name <String>] [-Spec <IScClusterSpecEntity>]
 [-StatusCku <Int32>] [-StatusPhase <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create confluent clusters

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ClusterId
Confluent kafka or schema registry cluster id

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Id of the cluster

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

### -Kind
Type of cluster

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

### -MetadataCreatedTimestamp
Created Date Time

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

### -MetadataDeletedTimestamp
Deleted Date time

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

### -MetadataResourceName
Resource name of the record

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

### -MetadataSelf
Self lookup url

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

### -MetadataUpdatedTimestamp
Updated Date time

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

### -Name
Display name of the cluster

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

### -OrganizationName
Organization resource name

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Spec
Specification of the cluster
To construct, see NOTES section for SPEC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IScClusterSpecEntity
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Microsoft Azure subscription id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of the resource

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IScClusterRecord

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SPEC <IScClusterSpecEntity>: Specification of the cluster
  - `[ApiEndpoint <String>]`: The Kafka API cluster endpoint
  - `[Availability <String>]`: The availability zone configuration of the cluster
  - `[ByokId <String>]`: ID of the referred resource
  - `[ByokRelated <String>]`: API URL for accessing or modifying the referred object
  - `[ByokResourceName <String>]`: CRN reference to the referred resource
  - `[Cloud <String>]`: The cloud service provider 
  - `[ConfigKind <String>]`: The lifecycle phase of the cluster
  - `[EnvironmentId <String>]`: ID of the referred resource
  - `[EnvironmentRelated <String>]`: API URL for accessing or modifying the referred object
  - `[EnvironmentResourceName <String>]`: CRN reference to the referred resource
  - `[HttpEndpoint <String>]`: The cluster HTTP request URL.
  - `[KafkaBootstrapEndpoint <String>]`: The bootstrap endpoint used by Kafka clients to connect to the cluster
  - `[Name <String>]`: The name of the cluster
  - `[NetworkEnvironment <String>]`: Environment of the referred resource
  - `[NetworkId <String>]`: ID of the referred resource
  - `[NetworkRelated <String>]`: API URL for accessing or modifying the referred object
  - `[NetworkResourceName <String>]`: CRN reference to the referred resource
  - `[Package <Package?>]`: Stream governance configuration
  - `[Region <String>]`: The cloud service provider region
  - `[ScClusterNetworkEnvironmentEntityEnvironment <String>]`: Environment of the referred resource
  - `[Zone <String>]`: type of zone availability

## RELATED LINKS

