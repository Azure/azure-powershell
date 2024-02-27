---
external help file: Az.Security-help.xml
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
 [-ConfigurationScanningMode <String>] [-DataSensitivityDiscoveryCloudRoleArn <String>]
 [-DataSensitivityDiscoveryEnabled <Boolean>] [-DatabaseDspmCloudRoleArn <String>]
 [-DatabaseDspmEnabled <Boolean>] [-MdcContainerAgentlessDiscoveryK8SCloudRoleArn <String>]
 [-MdcContainerAgentlessDiscoveryK8SEnabled <Boolean>] [-MdcContainerImageAssessmentCloudRoleArn <String>]
 [-MdcContainerImageAssessmentEnabled <Boolean>] [-VMScannerEnabled <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderCspmAwsOffering.

## EXAMPLES

### EXAMPLE 1
```
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderCspmAwsOfferingObject `
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationExclusionTag @{key="value"} `
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" `
    -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" `
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" `
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"
```

## PARAMETERS

### -CiemDiscoveryCloudRoleArn
The cloud role ARN in AWS for CIEM discovery.

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

### -CiemOidcAzureActiveDirectoryAppName
the azure active directory app name used of authenticating against AWS.

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

### -CiemOidcCloudRoleArn
The cloud role ARN in AWS for CIEM oidc connection.

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

### -ConfigurationCloudRoleArn
The cloud role ARN in AWS for this feature.

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
Type: IDefenderCspmAwsOfferingVMScannersConfigurationExclusionTags
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

### -DatabaseDspmCloudRoleArn
The cloud role ARN in AWS for this feature.

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

### -DatabaseDspmEnabled
Is databases DSPM protection enabled.

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

### -DataSensitivityDiscoveryCloudRoleArn
The cloud role ARN in AWS for this feature.

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

### -MdcContainerAgentlessDiscoveryK8SCloudRoleArn
The cloud role ARN in AWS for this feature.

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
Is Microsoft Defender container agentless discovery K8s enabled.

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

### -MdcContainerImageAssessmentCloudRoleArn
The cloud role ARN in AWS for this feature.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderCspmAwsOffering
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

CONFIGURATIONEXCLUSIONTAG \<IDefenderCspmAwsOfferingVMScannersConfigurationExclusionTags\>: VM tags that indicates that VM should not be scanned.
  \[(Any) \<String\>\]: This indicates any property can be added to this object.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmawsofferingobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefendercspmawsofferingobject)

