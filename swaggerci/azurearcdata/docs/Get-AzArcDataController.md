---
external help file:
Module Name: Az.Arc
online version: https://docs.microsoft.com/en-us/powershell/module/az.arc/get-azarcdatacontroller
schema: 2.0.0
---

# Get-AzArcDataController

## SYNOPSIS
Retrieves a dataController resource

## SYNTAX

### List (Default)
```
Get-AzArcDataController [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzArcDataController -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcDataController -InputObject <IArcIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzArcDataController -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves a dataController resource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the data controller

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DataControllerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the Azure subscription

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IDataControllerResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IArcIdentity>: Identity Parameter
  - `[ActiveDirectoryConnectorName <String>]`: The name of the Active Directory connector instance
  - `[DataControllerName <String>]`: The name of the data controller
  - `[Id <String>]`: Resource identity path
  - `[PostgresInstanceName <String>]`: Name of Postgres Instance
  - `[ResourceGroupName <String>]`: The name of the Azure resource group
  - `[SqlManagedInstanceName <String>]`: Name of SQL Managed Instance
  - `[SqlServerInstanceName <String>]`: Name of SQL Server Instance
  - `[SubscriptionId <String>]`: The ID of the Azure subscription

## RELATED LINKS

