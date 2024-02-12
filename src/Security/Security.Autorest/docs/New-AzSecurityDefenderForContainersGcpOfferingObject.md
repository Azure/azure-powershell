---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforcontainersgcpofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForContainersGcpOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForContainersGcpOffering.

## SYNTAX

```
New-AzSecurityDefenderForContainersGcpOfferingObject [-AuditLogsAutoProvisioningFlag <Boolean>]
 [-DataPipelineNativeCloudConnectionServiceAccountEmailAddress <String>]
 [-DataPipelineNativeCloudConnectionWorkloadIdentityProviderId <String>]
 [-DefenderAgentAutoProvisioningFlag <Boolean>] [-MdcContainerAgentlessDiscoveryK8SEnabled <Boolean>]
 [-MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress <String>]
 [-MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId <String>]
 [-MdcContainerImageAssessmentEnabled <Boolean>]
 [-MdcContainerImageAssessmentServiceAccountEmailAddress <String>]
 [-MdcContainerImageAssessmentWorkloadIdentityProviderId <String>]
 [-NativeCloudConnectionServiceAccountEmailAddress <String>]
 [-NativeCloudConnectionWorkloadIdentityProviderId <String>] [-PolicyAgentAutoProvisioningFlag <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForContainersGcpOffering.

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

### -AuditLogsAutoProvisioningFlag
Is audit logs data collection enabled.

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

### -DataPipelineNativeCloudConnectionServiceAccountEmailAddress
The data collection service account email address in GCP for this offering.

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

### -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId
The data collection GCP workload identity provider id for this offering.

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

### -DefenderAgentAutoProvisioningFlag
Is Microsoft Defender for Cloud Kubernetes agent auto provisioning enabled.

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
The GCP workload identity provider id for this offering.

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

### -PolicyAgentAutoProvisioningFlag
Is Policy Kubernetes agent auto provisioning enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForContainersGcpOffering

## NOTES

## RELATED LINKS

