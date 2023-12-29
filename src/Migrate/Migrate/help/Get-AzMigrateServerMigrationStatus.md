---
external help file: Az.Migrate-help.xml
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
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 [-Filter <String>] [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByApplianceName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -ApplianceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByMachineName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetHealthByMachineName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-Health] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateServerMigrationStatus cmdlet retrieves the replication status for the replicating server.

## EXAMPLES

### EXAMPLE 1
```
Get-AzMigrateServerReplication -ResourceGroupName cbtpvtrg -ProjectName migpvt
```

### EXAMPLE 2
```
Get-AzMigrateServerMigrationStatus -ProjectName "migpvt-ecyproj" -ResourceGroupName "cbtprivatestamprg" -MachineName "CVM-Win2019"
```

### EXAMPLE 3
```
Get-AzMigrateServerMigrationStatus -ProjectName "migpvt-ecyproj" -ResourceGroupName "cbtprivatestamprg" -ApplianceName "migpvt"
```

## PARAMETERS

### -ApplianceName
Specifies the name of the appliance.

```yaml
Type: String
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter options.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: GetHealthByMachineName
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
\[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)\]
 Specifies the display name of the replicating machine.

```yaml
Type: String
Parameter Sets: GetByMachineName, GetHealthByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
\[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)\]
 Specifies the Azure Migrate project  in the current subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
\[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)\]
 Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

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

### System.Management.Automation.PSObject[]
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateservermigrationstatus](https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateservermigrationstatus)

