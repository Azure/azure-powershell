---
external help file: Az.DataMigration-help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/invoke-azdatamigrationretrytosqldb
schema: 2.0.0
---

# Invoke-AzDataMigrationRetryToSqlDb

## SYNOPSIS
Retry on going migration for the database.

## SYNTAX

### RetryExpanded (Default)
```
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String>
 [-SubscriptionId <String>] -TargetDbName <String> -MigrationOperationId <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RetryViaJsonString
```
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String>
 [-SubscriptionId <String>] -TargetDbName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RetryViaJsonFilePath
```
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String>
 [-SubscriptionId <String>] -TargetDbName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Retry
```
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String>
 [-SubscriptionId <String>] -TargetDbName <String> -MigrationOperationInput <IMigrationOperationInput>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RetryViaIdentityServerExpanded
```
Invoke-AzDataMigrationRetryToSqlDb -TargetDbName <String> -ServerInputObject <IDataMigrationIdentity>
 -MigrationOperationId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RetryViaIdentityServer
```
Invoke-AzDataMigrationRetryToSqlDb -TargetDbName <String> -ServerInputObject <IDataMigrationIdentity>
 -MigrationOperationInput <IMigrationOperationInput> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RetryViaIdentityExpanded
```
Invoke-AzDataMigrationRetryToSqlDb -InputObject <IDataMigrationIdentity> -MigrationOperationId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RetryViaIdentity
```
Invoke-AzDataMigrationRetryToSqlDb -InputObject <IDataMigrationIdentity>
 -MigrationOperationInput <IMigrationOperationInput> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Retry on going migration for the database.

## EXAMPLES

### Example 1: Retry an ongoing SQL DB migration
```powershell
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName myRG -SqlDbInstanceName sqldb -TargetDbName sqldb -MigrationOperationId migOpId
```

This command retries the specified failed migration to a SQL database.

## PARAMETERS

### -AsJob
Run the command as a job

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: RetryViaIdentityExpanded, RetryViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Retry operation

```yaml
Type: System.String
Parameter Sets: RetryViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Retry operation

```yaml
Type: System.String
Parameter Sets: RetryViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationOperationId
ID tracking migration operation.

```yaml
Type: System.String
Parameter Sets: RetryExpanded, RetryViaIdentityServerExpanded, RetryViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationOperationInput
Migration Operation Input

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IMigrationOperationInput
Parameter Sets: Retry, RetryViaIdentityServer, RetryViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: RetryExpanded, RetryViaJsonString, RetryViaJsonFilePath, Retry
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity
Parameter Sets: RetryViaIdentityServerExpanded, RetryViaIdentityServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SqlDbInstanceName
.

```yaml
Type: System.String
Parameter Sets: RetryExpanded, RetryViaJsonString, RetryViaJsonFilePath, Retry
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
Type: System.String
Parameter Sets: RetryExpanded, RetryViaJsonString, RetryViaJsonFilePath, Retry
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDbName
The name of the target database.

```yaml
Type: System.String
Parameter Sets: RetryExpanded, RetryViaJsonString, RetryViaJsonFilePath, Retry, RetryViaIdentityServerExpanded, RetryViaIdentityServer
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IDataMigrationIdentity

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.IMigrationOperationInput

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
