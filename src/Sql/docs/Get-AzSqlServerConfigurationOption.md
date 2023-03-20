---
external help file:
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlserverconfigurationoption
schema: 2.0.0
---

# Get-AzSqlServerConfigurationOption

## SYNOPSIS
Gets managed instance server configuration option.

## SYNTAX

### Get (Default)
```
Get-AzSqlServerConfigurationOption -ManagedInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSqlServerConfigurationOption -InputObject <ISqlIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### List
```
Get-AzSqlServerConfigurationOption -ManagedInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Gets managed instance server configuration option.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sql.Models.ISqlIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedInstanceName
The name of the managed instance.

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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
The subscription ID that identifies an Azure subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.Sql.Models.ISqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sql.Models.Api20220801Preview.IServerConfigurationOption

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISqlIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagedInstanceName <String>]`: The name of the managed instance.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ServerConfigurationOptionName <ServerConfigurationOptionName?>]`: The name of the server configuration option.
  - `[SubscriptionId <String>]`: The subscription ID that identifies an Azure subscription.

## RELATED LINKS

