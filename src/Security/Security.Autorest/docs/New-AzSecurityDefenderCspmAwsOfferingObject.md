---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmawsofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderCspmAwsOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderCspmAwsOffering.

## SYNTAX

```
New-AzSecurityDefenderCspmAwsOfferingObject [-CiemDiscoveryCloudRoleArn <String>]
 [-CiemOidcAzureActiveDirectoryAppName <String>] [-CiemOidcCloudRoleArn <String>]
 [-ConfigurationCloudRoleArn <String>]
 [-ConfigurationExclusionTag <IDefenderCspmAwsOfferingVMScannersConfigurationExclusionTags>]
 [-ConfigurationScanningMode <String>] [-DatabaseDspmCloudRoleArn <String>] [-DatabaseDspmEnabled <Boolean>]
 [-DataSensitivityDiscoveryCloudRoleArn <String>] [-DataSensitivityDiscoveryEnabled <Boolean>]
 [-MdcContainerAgentlessDiscoveryK8SCloudRoleArn <String>]
 [-MdcContainerAgentlessDiscoveryK8SEnabled <Boolean>] [-MdcContainerImageAssessmentCloudRoleArn <String>]
 [-MdcContainerImageAssessmentEnabled <Boolean>] [-VMScannerEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderCspmAwsOffering.

## EXAMPLES

### Example 1: Create new DefenderCspmAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderCspmAwsOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationExclusionTag @{key="value"} `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" `
    -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"
```

```output
CiemDiscoveryCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-Ciem
CiemOidcAzureActiveDirectoryAppName           : mciem-aws-oidc-connector
CiemOidcCloudRoleArn                          : arn:aws:iam::123456789012:role/DefenderForCloud-OidcCiem
ConfigurationCloudRoleArn                     : arn:aws:iam::123456789012:role/DefenderForCloud-AgentlessScanner
ConfigurationExclusionTag                     : {
                                                  "key": "value"
                                                }
ConfigurationScanningMode                     : Default
DataSensitivityDiscoveryCloudRoleArn          : arn:aws:iam::123456789012:role/SensitiveDataDiscovery
DataSensitivityDiscoveryEnabled               : True
DatabaseDspmCloudRoleArn                      : arn:aws:iam::123456789012:role/DefenderForCloud-DataSecurityPostureDB
DatabaseDspmEnabled                           : True
Description                                   : 
MdcContainerAgentlessDiscoveryK8SCloudRoleArn : arn:aws:iam::123456789012:role/MDCContainersAgentlessDiscoveryK8sRole
MdcContainerAgentlessDiscoveryK8SEnabled      : True
MdcContainerImageAssessmentCloudRoleArn       : arn:aws:iam::123456789012:role/MDCContainersImageAssessmentRole
MdcContainerImageAssessmentEnabled            : True
OfferingType                                  : DefenderCspmAws
VMScannerEnabled                              : True
```



## PARAMETERS

### -CiemDiscoveryCloudRoleArn
The cloud role ARN in AWS for CIEM discovery.

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

### -CiemOidcAzureActiveDirectoryAppName
the azure active directory app name used of authenticating against AWS.

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

### -CiemOidcCloudRoleArn
The cloud role ARN in AWS for CIEM oidc connection.

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

### -ConfigurationCloudRoleArn
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

### -ConfigurationExclusionTag
VM tags that indicates that VM should not be scanned.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IDefenderCspmAwsOfferingVMScannersConfigurationExclusionTags
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
Is databases DSPM protection enabled.

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

### -DataSensitivityDiscoveryCloudRoleArn
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderCspmAwsOffering

## NOTES

## RELATED LINKS

