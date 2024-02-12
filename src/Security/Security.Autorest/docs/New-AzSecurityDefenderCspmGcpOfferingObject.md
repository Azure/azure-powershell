---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmgcpofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderCspmGcpOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderCspmGcpOffering.

## SYNTAX

```
New-AzSecurityDefenderCspmGcpOfferingObject [-CiemDiscoveryAzureActiveDirectoryAppName <String>]
 [-CiemDiscoveryServiceAccountEmailAddress <String>] [-CiemDiscoveryWorkloadIdentityProviderId <String>]
 [-ConfigurationExclusionTag <IDefenderCspmGcpOfferingVMScannersConfigurationExclusionTags>]
 [-ConfigurationScanningMode <String>] [-DataSensitivityDiscoveryEnabled <Boolean>]
 [-DataSensitivityDiscoveryServiceAccountEmailAddress <String>]
 [-DataSensitivityDiscoveryWorkloadIdentityProviderId <String>]
 [-MdcContainerAgentlessDiscoveryK8SEnabled <Boolean>]
 [-MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress <String>]
 [-MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId <String>]
 [-MdcContainerImageAssessmentEnabled <Boolean>]
 [-MdcContainerImageAssessmentServiceAccountEmailAddress <String>]
 [-MdcContainerImageAssessmentWorkloadIdentityProviderId <String>] [-VMScannerEnabled <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderCspmGcpOffering.

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

### -CiemDiscoveryAzureActiveDirectoryAppName
the azure active directory app name used of authenticating against GCP workload identity federation.

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

### -CiemDiscoveryServiceAccountEmailAddress
The service account email address in GCP for CIEM discovery offering.

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

### -CiemDiscoveryWorkloadIdentityProviderId
The GCP workload identity provider id for CIEM discovery offering.

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

### -ConfigurationExclusionTag
VM tags that indicates that VM should not be scanned.
To construct, see NOTES section for CONFIGURATIONEXCLUSIONTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IDefenderCspmGcpOfferingVMScannersConfigurationExclusionTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationScanningMode
The scanning mode for the VM scan.

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

### -DataSensitivityDiscoveryEnabled
Is Microsoft Defender Data Sensitivity discovery enabled.

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

### -DataSensitivityDiscoveryServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -DataSensitivityDiscoveryWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -MdcContainerAgentlessDiscoveryK8SEnabled
Is Microsoft Defender container agentless discovery enabled.

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

### -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -MdcContainerImageAssessmentEnabled
Is Microsoft Defender container image assessment enabled.

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

### -MdcContainerImageAssessmentServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -MdcContainerImageAssessmentWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -VMScannerEnabled
Is Microsoft Defender for Server VM scanning enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderCspmGcpOffering

## NOTES

## RELATED LINKS

