---
external help file:
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentconnector
schema: 2.0.0
---

# Get-AzConfluentConnector

## SYNOPSIS
Get confluent connector by Name

## SYNTAX

### List (Default)
```
Get-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-PageSize <Int32>] [-PageToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -Name <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConfluentConnector -InputObject <IConfluentIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzConfluentConnector -ClusterInputObject <IConfluentIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityEnvironment
```
Get-AzConfluentConnector -ClusterId <String> -EnvironmentInputObject <IConfluentIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -Name <String>
 -OrganizationInputObject <IConfluentIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get confluent connector by Name

## EXAMPLES

### Example 1: List all connectors under the cluster in the Environment of an Organization in the Resource Group
```powershell
Get-AzConfluentConnector -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
conn_1
conn_2
```

This command list all connectors under the cluster in the environment of an organization in the resource group

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
Confluent connector name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster, GetViaIdentityEnvironment, GetViaIdentityOrganization
Aliases: ConnectorName

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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConnectorResource

## NOTES

## RELATED LINKS

