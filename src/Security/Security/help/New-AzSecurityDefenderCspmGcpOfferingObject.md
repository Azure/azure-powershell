---
external help file: Az.Security-help.xml
Module Name: Az.security
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

### EXAMPLE 1
```
$emailSuffix = "myproject.iam.gserviceaccount.com"
```

New-AzSecurityDefenderCspmGcpOfferingObject \`
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationExclusionTag @{key="value"} \`
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" \`
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix" -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" \`
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryServiceAccountEmailAddress "mdc-data-sec-posture-storage@$emailSuffix" -DataSensitivityDiscoveryWorkloadIdentityProviderId "data-security-posture-storage" \`
    -CiemDiscoveryServiceAccountEmailAddress "microsoft-defender-ciem@$emailSuffix" -CiemDiscoveryAzureActiveDirectoryAppName "mciem-gcp-oidc-app" -CiemDiscoveryWorkloadIdentityProviderId "ciem-discovery"

## PARAMETERS

### -CiemDiscoveryAzureActiveDirectoryAppName
the azure active directory app name used of authenticating against GCP workload identity federation.

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

### -CiemDiscoveryServiceAccountEmailAddress
The service account email address in GCP for CIEM discovery offering.

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

### -CiemDiscoveryWorkloadIdentityProviderId
The GCP workload identity provider id for CIEM discovery offering.

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

### -ConfigurationExclusionTag
VM tags that indicates that VM should not be scanned.
.

```yaml
Type: IDefenderCspmGcpOfferingVMScannersConfigurationExclusionTags
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
Type: String
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
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSensitivityDiscoveryServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -DataSensitivityDiscoveryWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -MdcContainerAgentlessDiscoveryK8SEnabled
Is Microsoft Defender container agentless discovery enabled.

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

### -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -MdcContainerImageAssessmentEnabled
Is Microsoft Defender container image assessment enabled.

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

### -MdcContainerImageAssessmentServiceAccountEmailAddress
The service account email address in GCP for this feature.

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

### -MdcContainerImageAssessmentWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

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

### -VMScannerEnabled
Is Microsoft Defender for Server VM scanning enabled.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderCspmGcpOffering
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

CONFIGURATIONEXCLUSIONTAG \<IDefenderCspmGcpOfferingVMScannersConfigurationExclusionTags\>: VM tags that indicates that VM should not be scanned.
  \[(Any) \<String\>\]: This indicates any property can be added to this object.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmgcpofferingobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmgcpofferingobject)

