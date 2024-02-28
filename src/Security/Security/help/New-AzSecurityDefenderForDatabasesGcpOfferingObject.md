---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderfordatabasesgcpofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForDatabasesGcpOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForDatabasesGcpOffering.

## SYNTAX

```
New-AzSecurityDefenderForDatabasesGcpOfferingObject [-ArcAutoProvisioningEnabled <Boolean>]
 [-ConfigurationPrivateLinkScope <String>] [-ConfigurationProxy <String>]
 [-DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress <String>]
 [-DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForDatabasesGcpOffering.

## EXAMPLES

### Example 1
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForDatabasesGcpOfferingObject `
    -ArcAutoProvisioningEnabled $true `
    -DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress "microsoft-databases-arc-ap@" -DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId "defender-for-databases-arc-ap"
```

## PARAMETERS

### -ArcAutoProvisioningEnabled
Is arc auto provisioning enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationPrivateLinkScope
Optional Arc private link scope resource id to link the Arc agent.

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

### -ConfigurationProxy
Optional http proxy endpoint to use for the Arc agent.

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

### -DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress
The service account email address in GCP for this offering.

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

### -DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId
The GCP workload identity provider id for this offering.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForDatabasesGcpOffering
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderfordatabasesgcpofferingobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderfordatabasesgcpofferingobject)

