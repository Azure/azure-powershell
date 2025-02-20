---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritycspmmonitorgcpofferingobject
schema: 2.0.0
---

# New-AzSecurityCspmMonitorGcpOfferingObject

## SYNOPSIS
Create an in-memory object for CspmMonitorGcpOffering.

## SYNTAX

```
New-AzSecurityCspmMonitorGcpOfferingObject [-NativeCloudConnectionServiceAccountEmailAddress <String>]
 [-NativeCloudConnectionWorkloadIdentityProviderId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CspmMonitorGcpOffering.

## EXAMPLES

### Example 1: Create new CspmMonitorGcpOffering object
```powershell
New-AzSecurityCspmMonitorGcpOfferingObject -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-cspm@asc-sdk-samples.iam.gserviceaccount.com" -NativeCloudConnectionWorkloadIdentityProviderId "cspm"
```

```output
Description NativeCloudConnectionServiceAccountEmailAddress                 NativeCloudConnectionWorkloadIdentityProviderId OfferingType
----------- -----------------------------------------------                 ----------------------------------------------- ------------
            microsoft-defender-cspm@asc-sdk-samples.iam.gserviceaccount.com cspm                                            CspmMonitorGcp
```



## PARAMETERS

### -NativeCloudConnectionServiceAccountEmailAddress
The service account email address in GCP for this offering.

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

### -NativeCloudConnectionWorkloadIdentityProviderId
The GCP workload identity provider id for the offering.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.CspmMonitorGcpOffering

## NOTES

## RELATED LINKS

