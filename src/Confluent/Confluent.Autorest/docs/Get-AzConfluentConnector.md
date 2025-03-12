---
external help file:
Module Name: Az.Confluent
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

## DESCRIPTION
Get confluent connector by Name

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Parameter Sets: Get
Aliases: ConnectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Microsoft Azure subscription id

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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20240701.IConnectorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IConfluentIdentity>: Identity Parameter
  - `[ApiKeyId <String>]`: Confluent API Key id
  - `[ClusterId <String>]`: Confluent kafka or schema registry cluster id
  - `[ConnectorName <String>]`: Confluent connector name
  - `[EnvironmentId <String>]`: Confluent environment id
  - `[Id <String>]`: Resource identity path
  - `[OrganizationName <String>]`: Organization resource name
  - `[ResourceGroupName <String>]`: Resource group name
  - `[RoleBindingId <String>]`: Confluent Role binding id
  - `[SubscriptionId <String>]`: Microsoft Azure subscription id
  - `[TopicName <String>]`: Confluent kafka or schema registry topic name

## RELATED LINKS

