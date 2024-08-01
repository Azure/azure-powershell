---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoraclednsprivatezone
schema: 2.0.0
---

# Get-AzOracleDnsPrivateZone

## SYNOPSIS
Get a DnsPrivateZone

## SYNTAX

### List (Default)
```
Get-AzOracleDnsPrivateZone -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDnsPrivateZone -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDnsPrivateZone -Name <String> -LocationInputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDnsPrivateZone -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a DnsPrivateZone

## EXAMPLES

### Example 1: Get a list of the DNS Private Zones by location
```powershell
Get-AzOracleDnsPrivateZone -Location "eastus"
```

```output
Name                                                                      SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                      ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
byui3zo3.ocidelegated.ocipstestvnet.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                       
byui3zo3.adb.us-ashburn-1.oraclevcn.com                                                                                                                                                                                  
byui3zo3.adbapps.us-ashburn-1.oraclevcn.com
```

Get a list of the DNS Private Zones by location.
For more information, execute `Get-Help Get-AzOracleDnsPrivateZone`.

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

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### -Name
DnsPrivateZone name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: Dnsprivatezonename

Required: True
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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDnsPrivateZone

## NOTES

## RELATED LINKS
