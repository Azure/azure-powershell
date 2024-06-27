---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabaseautonomousdatabasenationalcharacterset
schema: 2.0.0
---

# Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet

## SYNOPSIS
Get a AutonomousDatabaseNationalCharacterSet

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet -Adbsncharsetname <String> -Location <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet -InputObject <IOracleDatabaseIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDatabaseAutonomousDatabaseNationalCharacterSet -Adbsncharsetname <String>
 -LocationInputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a AutonomousDatabaseNationalCharacterSet

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

### -Adbsncharsetname
AutonomousDatabaseNationalCharacterSets name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabaseNationalCharacterSet

## NOTES

## RELATED LINKS

