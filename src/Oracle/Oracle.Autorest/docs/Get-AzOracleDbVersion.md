---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracledbversion
schema: 2.0.0
---

# Get-AzOracleDbVersion

## SYNOPSIS
Get a DbVersion

## SYNTAX

### List (Default)
```
Get-AzOracleDbVersion -Location <String> [-SubscriptionId <String[]>] [-DbSystemId <String>]
 [-DbSystemShape <String>] [-IsDatabaseSoftwareImageSupported] [-IsUpgradeSupported] [-ShapeFamily <String>]
 [-StorageManagement <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDbVersion -Location <String> -Sname <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDbVersion -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDbVersion -LocationInputObject <IOracleIdentity> -Sname <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DbVersion

## EXAMPLES

### Example 1: List available Oracle Database versions in a region
```powershell
Get-AzOracleDbVersion -Location eastus2
```

```output
...
Version                                       : 19c
VersionFull                                   : 19.22.0.0
IsDefault                                     : True
IsPreview                                     : False

Version                                       : 21c
VersionFull                                   : 21.10.0.0
IsDefault                                     : False
IsPreview                                     : True
```

Lists the available Oracle Database versions for **eastus2**.
For more information, execute `Get-Help Get-AzOracleDbVersion`.

## PARAMETERS

### -DbSystemId
The DB system AzureId.
If provided, filters the results to the set of database versions which are supported for the DB system.

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

### -DbSystemShape
If provided, filters the results to the set of database versions which are supported for the given shape.
e.g., VM.Standard.E5.Flex

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

### -IsDatabaseSoftwareImageSupported
If true, filters the results to the set of Oracle Database versions that are supported for the database software images.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsUpgradeSupported
If true, filters the results to the set of database versions which are supported for Upgrade.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ShapeFamily
If provided, filters the results to the set of database versions which are supported for the given shape family.

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

### -Sname
DbVersion name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: Dbversionsname

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageManagement
The DB system storage management option.
Used to list database versions available for that storage manager.
Valid values are ASM and LVM.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbVersion

## NOTES

## RELATED LINKS

