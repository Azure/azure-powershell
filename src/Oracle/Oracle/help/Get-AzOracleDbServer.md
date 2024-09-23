---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracledbserver
schema: 2.0.0
---

# Get-AzOracleDbServer

## SYNOPSIS
Get a DbServer

## SYNTAX

### List (Default)
```
Get-AzOracleDbServer -Cloudexadatainfrastructurename <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleDbServer -Cloudexadatainfrastructurename <String> -Ocid <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCloudExadataInfrastructure
```
Get-AzOracleDbServer -Ocid <String> -CloudExadataInfrastructureInputObject <IOracleIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDbServer -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DbServer

## EXAMPLES

### Example 1: Get a list of the Database Servers for a Cloud Exadata Infrastructure resource
```powershell
Get-AzOracleDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
```

```output
Name       SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----       ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
dbServer-2                                                                                                                                                PowerShellTestRg
dbServer-3                                                                                                                                                PowerShellTestRg
dbServer-1                                                                                                                                                PowerShellTestRg
```

Get a list of the Database Servers for a Cloud Exadata Infrastructure resource.
For more information, execute `Get-Help Get-AzOracleDbServer`.

## PARAMETERS

### -CloudExadataInfrastructureInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityCloudExadataInfrastructure
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Cloudexadatainfrastructurename
CloudExadataInfrastructure name

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

### -Ocid
DbServer OCID.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCloudExadataInfrastructure
Aliases: Dbserverocid

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbServer

## NOTES

## RELATED LINKS
