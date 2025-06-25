---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracleautonomousdatabasebackup
schema: 2.0.0
---

# Get-AzOracleAutonomousDatabaseBackup

## SYNOPSIS
Get a AutonomousDatabaseBackup

## SYNTAX

### List (Default)
```
Get-AzOracleAutonomousDatabaseBackup -Autonomousdatabasename <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleAutonomousDatabaseBackup -Adbbackupid <String> -Autonomousdatabasename <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleAutonomousDatabaseBackup -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAutonomousDatabase
```
Get-AzOracleAutonomousDatabaseBackup -Adbbackupid <String> -AutonomousDatabaseInputObject <IOracleIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a AutonomousDatabaseBackup

## EXAMPLES

### Example 1: Get a list of the Autonomous Database Backups for an Autonomous Database resource
```powershell
Get-AzOracleAutonomousDatabaseBackup -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

```output
Name                                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
Jul 06, 2024 01:54:13 UTC                                                                                                                                                             PowerShellTestRg
Jul 05, 2024 15:26:01 UTC                                                                                                                                                             PowerShellTestRg
autonomousdatabasebackup20240705141147                                                                                                                                                PowerShellTestRg
autonomousdatabasebackup20240705135809                                                                                                                                                PowerShellTestRg
Jul 04, 2024 12:00:52 UTC                                                                                                                                                             PowerShellTestRg
```

Get a list of the Autonomous Database Backups for an Autonomous Database resource.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabaseBackup`

## PARAMETERS

### -Adbbackupid
AutonomousDatabaseBackup id

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAutonomousDatabase
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutonomousDatabaseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityAutonomousDatabase
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Autonomousdatabasename
The database name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IAutonomousDatabaseBackup

## NOTES

## RELATED LINKS

