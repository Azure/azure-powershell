---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/new-azconfluentcluster
schema: 2.0.0
---

# New-AzConfluentCluster

## SYNOPSIS
Create confluent clusters

## SYNTAX

### CreateExpanded (Default)
```
New-AzConfluentCluster -EnvironmentId <String> -Id <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Kind <String>] [-MetadataCreatedTimestamp <String>]
 [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>] [-MetadataSelf <String>]
 [-MetadataUpdatedTimestamp <String>] [-Spec <IScClusterSpecEntity>] [-StatusCku <Int32>]
 [-StatusPhase <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzConfluentCluster -EnvironmentInputObject <IConfluentIdentity> -Id <String> [-Kind <String>]
 [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>]
 [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>] [-Spec <IScClusterSpecEntity>]
 [-StatusCku <Int32>] [-StatusPhase <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityOrganizationExpanded
```
New-AzConfluentCluster -EnvironmentId <String> -Id <String> -OrganizationInputObject <IConfluentIdentity>
 [-Kind <String>] [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>]
 [-MetadataResourceName <String>] [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>]
 [-Spec <IScClusterSpecEntity>] [-StatusCku <Int32>] [-StatusPhase <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConfluentCluster -EnvironmentId <String> -Id <String> -OrganizationName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConfluentCluster -EnvironmentId <String> -Id <String> -OrganizationName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create confluent clusters

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IScClusterSpecEntity
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IScClusterRecord

## NOTES

## RELATED LINKS

