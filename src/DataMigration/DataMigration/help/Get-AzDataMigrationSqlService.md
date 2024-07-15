---
external help file: Az.DataMigration-help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/get-azdatamigrationsqlservice
schema: 2.0.0
---

# Get-AzDataMigrationSqlService

## SYNOPSIS
Retrieve the Database Migration Service.

## SYNTAX

### List1 (Default)
```
Get-AzDataMigrationSqlService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataMigrationSqlService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzDataMigrationSqlService -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataMigrationSqlService -InputObject <IDataMigrationIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the Database Migration Service.

## EXAMPLES

### Example 1: Get the details of a given Sql Migration Service
```powershell
Get-AzDataMigrationSqlService  -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
```

```output
Location  Name                   Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                   ----                                         ----------------- -----------------------
eastus2   MySqlMigrationService  Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command gets the details of a given Sql Migration Service.

### Example 2: Get all Sql Migration Services in a given Resource Group
```powershell
Get-AzDataMigrationSqlService  -ResourceGroupName "MyResourceGroup"
```

```output
Location  Name                   Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                   ----                                         ----------------- -----------------------
eastus    MySqlMigrationService1 Microsoft.DataMigration/sqlMigrationServices Succeeded
eastus2   MySqlMigrationService  Microsoft.DataMigration/sqlMigrationServices Succeeded
```

This command gets all Sql Migration Services in a given Resource Group.

### Example 3: Get all Sql Migration Services in a given Subscription
```powershell
Get-AzDataMigrationSqlService
```

```output
Location  Name                      Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                      ----                                         ----------------- -----------------------
eastus    MySqlMigrationService1    Microsoft.DataMigration/sqlMigrationServices Succeeded
eastus2   MySqlMigrationService     Microsoft.DataMigration/sqlMigrationServices Succeeded
uksouth   MySqlMigrationService-UK  Microsoft.DataMigration/sqlMigrationServices Succeeded
```

This command gets all Sql Migration Services in a given Subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the SQL Migration Service.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SqlMigrationServiceName

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group that contains the resource.
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
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlMigrationService

## NOTES

## RELATED LINKS
