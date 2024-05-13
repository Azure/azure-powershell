---
external help file: Az.Security-help.xml
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
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForContainersGcpOffering.

## EXAMPLES

### Example 1: Create new DefenderForContainersGcpOffering object
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForContainersGcpOfferingObject `
    -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-containers@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "containers" `
    -DataPipelineNativeCloudConnectionServiceAccountEmailAddress "ms-defender-containers-stream@$emailSuffix" -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId "containers-streams" `
    -AuditLogsAutoProvisioningFlag $true -DefenderAgentAutoProvisioningFlag $true -PolicyAgentAutoProvisioningFlag $true `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix"
```

```output
AuditLogsAutoProvisioningFlag                               : True
DataPipelineNativeCloudConnectionServiceAccountEmailAddress : ms-defender-containers-stream@myproject.iam.gserviceaccount.com
DataPipelineNativeCloudConnectionWorkloadIdentityProviderId : containers-streams
DefenderAgentAutoProvisioningFlag                           : True
Description                                                 : 
MdcContainerAgentlessDiscoveryK8SEnabled                    : True
MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress : mdc-containers-k8s-operator@myproject.iam.gserviceaccount.com
MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId : containers
MdcContainerImageAssessmentEnabled                          : True
MdcContainerImageAssessmentServiceAccountEmailAddress       : mdc-containers-artifact-assess@myproject.iam.gserviceaccount.com
MdcContainerImageAssessmentWorkloadIdentityProviderId       : containers
NativeCloudConnectionServiceAccountEmailAddress             : microsoft-defender-containers@myproject.iam.gserviceaccount.com
NativeCloudConnectionWorkloadIdentityProviderId             : containers
OfferingType                                                : DefenderForContainersGcp
PolicyAgentAutoProvisioningFlag                             : True
```

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForContainersGcpOffering

## NOTES

## RELATED LINKS
