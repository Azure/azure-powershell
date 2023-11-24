---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateservermigrationstatus
schema: 2.0.0
---

# Get-AzMigrateServerMigrationStatus

## SYNOPSIS
Retrieves the details of the replicating server status.

## SYNTAX

### ListByName (Default)
```
Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Filter <String>] [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByApplianceName
```
Get-AzMigrateServerMigrationStatus -ApplianceName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByMachineName
```
Get-AzMigrateServerMigrationStatus -MachineName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetBySRSID
```
Get-AzMigrateServerMigrationStatus -Expedite [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetHealthByMachineName
```
Get-AzMigrateServerMigrationStatus -Health -MachineName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateServerMigrationStatus cmdlet retrieves the replication status for the replicating server.

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

### -ApplianceName
Specifies the name of the appliance.

```yaml
Type: System.String
Parameter Sets: GetByApplianceName
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

### -Expedite
[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
 Specifies list of steps customers can take to prioritize the migration operation of the given server.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetBySRSID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter options.

```yaml
Type: System.String
Parameter Sets: ListByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Health
Specifies whether the health issues to show for replicating server.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetHealthByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
 Specifies the display name of the replicating machine.

```yaml
Type: System.String
Parameter Sets: GetByMachineName, GetHealthByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
 Specifies the Azure Migrate project  in the current subscription.

```yaml
Type: System.String
Parameter Sets: GetByApplianceName, GetByMachineName, GetHealthByMachineName, ListByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
 Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: GetByApplianceName, GetByMachineName, GetHealthByMachineName, ListByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
The pagination token.

```yaml
Type: System.String
Parameter Sets: ListByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

