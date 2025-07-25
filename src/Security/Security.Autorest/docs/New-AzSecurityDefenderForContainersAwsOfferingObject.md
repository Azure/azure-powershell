---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforcontainersawsofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForContainersAwsOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForContainersAwsOffering.

## SYNTAX

```
New-AzSecurityDefenderForContainersAwsOfferingObject [-AutoProvisioning <Boolean>]
 [-CloudWatchToKinesiCloudRoleArn <String>] [-ContainerVulnerabilityAssessmentCloudRoleArn <String>]
 [-ContainerVulnerabilityAssessmentTaskCloudRoleArn <String>]
 [-EnableContainerVulnerabilityAssessment <Boolean>] [-KinesiToS3CloudRoleArn <String>]
 [-KubeAuditRetentionTime <Int64>] [-KuberneteScubaReaderCloudRoleArn <String>]
 [-KuberneteServiceCloudRoleArn <String>] [-MdcContainerAgentlessDiscoveryK8SCloudRoleArn <String>]
 [-MdcContainerAgentlessDiscoveryK8SEnabled <Boolean>] [-MdcContainerImageAssessmentCloudRoleArn <String>]
 [-MdcContainerImageAssessmentEnabled <Boolean>] [-ScubaExternalId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForContainersAwsOffering.

## EXAMPLES

### Example 1: Create new DefenderForContainersAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForContainersAwsOfferingObject `
    -AutoProvisioning $true -KuberneteServiceCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s" -KuberneteScubaReaderCloudRoleArn "$arnPrefix/DefenderForCloud-DataCollection" `
    -KinesiToS3CloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-kinesis-to-s3" -CloudWatchToKinesiCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis" `
    -KubeAuditRetentionTime 30 -ScubaExternalId "a47ae0a2-7bf7-482a-897a-7a139d30736c" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -EnableContainerVulnerabilityAssessment $false
```

```output
AutoProvisioning                                 : True
CloudWatchToKinesiCloudRoleArn                   : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis
ContainerVulnerabilityAssessmentCloudRoleArn     : 
ContainerVulnerabilityAssessmentTaskCloudRoleArn : 
Description                                      : 
EnableContainerVulnerabilityAssessment           : False
KinesiToS3CloudRoleArn                           : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s-kinesis-to-s3
KubeAuditRetentionTime                           : 30
KuberneteScubaReaderCloudRoleArn                 : arn:aws:iam::123456789012:role/DefenderForCloud-DataCollection
KuberneteServiceCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-Containers-K8s
MdcContainerAgentlessDiscoveryK8SCloudRoleArn    : arn:aws:iam::123456789012:role/MDCContainersAgentlessDiscoveryK8sRole
MdcContainerAgentlessDiscoveryK8SEnabled         : True
MdcContainerImageAssessmentCloudRoleArn          : arn:aws:iam::123456789012:role/MDCContainersImageAssessmentRole
MdcContainerImageAssessmentEnabled               : True
OfferingType                                     : DefenderForContainersAws
ScubaExternalId                                  : a47ae0a2-7bf7-482a-897a-7a139d30736c
```



## PARAMETERS

### -AutoProvisioning
Is audit logs pipeline auto provisioning enabled.

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

### -CloudWatchToKinesiCloudRoleArn
The cloud role ARN in AWS used by CloudWatch to transfer data into Kinesis.

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

### -ContainerVulnerabilityAssessmentCloudRoleArn
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

### -ContainerVulnerabilityAssessmentTaskCloudRoleArn
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

### -EnableContainerVulnerabilityAssessment
Enable container vulnerability assessment feature.

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

### -KinesiToS3CloudRoleArn
The cloud role ARN in AWS used by Kinesis to transfer data into S3.

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

### -KubeAuditRetentionTime
The retention time in days of kube audit logs set on the CloudWatch log group.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KuberneteScubaReaderCloudRoleArn
The cloud role ARN in AWS for this feature used for reading data.

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

### -KuberneteServiceCloudRoleArn
The cloud role ARN in AWS for this feature used for provisioning resources.

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

### -MdcContainerAgentlessDiscoveryK8SCloudRoleArn
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

### -MdcContainerAgentlessDiscoveryK8SEnabled
Is Microsoft Defender container agentless discovery K8s enabled.

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

### -MdcContainerImageAssessmentCloudRoleArn
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

### -ScubaExternalId
The externalId used by the data reader to prevent the confused deputy attack.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForContainersAwsOffering

## NOTES

## RELATED LINKS

