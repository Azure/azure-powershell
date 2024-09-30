---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderfordatabasesawsofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForDatabasesAwsOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForDatabasesAwsOffering.

## SYNTAX

```
New-AzSecurityDefenderForDatabasesAwsOfferingObject [-ArcAutoProvisioningCloudRoleArn <String>]
 [-ArcAutoProvisioningEnabled <Boolean>] [-ConfigurationPrivateLinkScope <String>]
 [-ConfigurationProxy <String>] [-DatabaseDspmCloudRoleArn <String>] [-DatabaseDspmEnabled <Boolean>]
 [-RdCloudRoleArn <String>] [-RdEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForDatabasesAwsOffering.

## EXAMPLES

### Example 1: Create new DefenderForDatabasesAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForDatabasesAwsOfferingObject `
    -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB"
        
```

```output
ArcAutoProvisioningCloudRoleArn : arn:aws:iam::123456789012:role/DefenderForCloud-ArcAutoProvisioning
ArcAutoProvisioningEnabled      : True
ConfigurationPrivateLinkScope   : 
ConfigurationProxy              : 
DatabaseDspmCloudRoleArn        : arn:aws:iam::123456789012:role/DefenderForCloud-DataSecurityPostureDB
DatabaseDspmEnabled             : True
Description                     : 
OfferingType                    : DefenderForDatabasesAws
RdCloudRoleArn                  : 
RdEnabled                       : 
```



## PARAMETERS

### -ArcAutoProvisioningCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcAutoProvisioningEnabled
Is arc auto provisioning enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationPrivateLinkScope
Optional Arc private link scope resource id to link the Arc agent.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationProxy
Optional http proxy endpoint to use for the Arc agent.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseDspmCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseDspmEnabled
Is databases data security posture management (DSPM) protection enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RdCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RdEnabled
Is RDS protection enabled.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForDatabasesAwsOffering

## NOTES

## RELATED LINKS

