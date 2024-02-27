---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnector
schema: 2.0.0
---

# New-AzSecurityConnector

## SYNOPSIS
Create a security connector.
If a security connector is already created and a subsequent request is issued for the same security connector id, then it will be updated.

## SYNTAX

```
New-AzSecurityConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnvironmentData <ISecurityConnectorEnvironment>] [-EnvironmentName <String>] [-Etag <String>]
 [-HierarchyIdentifier <String>] [-Kind <String>] [-Location <String>] [-Offering <ICloudOffering[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a security connector.
If a security connector is already created and a subsequent request is issued for the same security connector id, then it will be updated.

## EXAMPLES

### EXAMPLE 1
```
$account = "891376984375"
$arnPrefix = "arn:aws:iam::$($account):role"
```

$cspmMonitorOffering = New-AzSecurityCspmMonitorAwsOfferingObject -NativeCloudConnectionCloudRoleArn "$arnPrefix/CspmMonitorAws"

$dcspmOffering = New-AzSecurityDefenderCspmAwsOfferingObject \`
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" \`
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryCloudRoleArn "$arnPrefix/SensitiveDataDiscovery" \`
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB" \`
    -CiemDiscoveryCloudRoleArn "$arnPrefix/DefenderForCloud-Ciem" -CiemOidcAzureActiveDirectoryAppName "mciem-aws-oidc-connector" -CiemOidcCloudRoleArn "$arnPrefix/DefenderForCloud-OidcCiem" \`
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" \`
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole"

$defenderForContainersOffering = New-AzSecurityDefenderForContainersAwsOfferingObject \`
    -AutoProvisioning $true -KuberneteServiceCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s" -KuberneteScubaReaderCloudRoleArn "$arnPrefix/DefenderForCloud-DataCollection" \`
    -KinesiToS3CloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-kinesis-to-s3" -CloudWatchToKinesiCloudRoleArn "$arnPrefix/DefenderForCloud-Containers-K8s-cloudwatch-to-kinesis" \`
    -KubeAuditRetentionTime 30 -ScubaExternalId "a47ae0a2-7bf7-482a-897a-7a139d30736c" \`
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SCloudRoleArn "$arnPrefix/MDCContainersAgentlessDiscoveryK8sRole" \`
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentCloudRoleArn "$arnPrefix/MDCContainersImageAssessmentRole" \`
    -EnableContainerVulnerabilityAssessment $false

$environment = New-AzSecurityAwsEnvironmentObject -ScanInterval 24

New-AzSecurityConnector -Name "aws-sdktest01" -ResourceGroupName "securityConnectors-tests" \`
        -EnvironmentData $environment -EnvironmentName AWS -HierarchyIdentifier "$account" \`
        -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) \`
        -Location "CentralUS"

### EXAMPLE 2
```
$account = "843025268399"
$emailSuffix = "myproject.iam.gserviceaccount.com"
$cspmMonitorOffering = New-AzSecurityCspmMonitorGcpOfferingObject -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-cspm@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "cspm"
```

$dcspmOffering = New-AzSecurityDefenderCspmGcpOfferingObject \`
    -VMScannerEnabled $true -ConfigurationScanningMode Default -ConfigurationExclusionTag @{key="value"} \`
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" \`
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix" -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" \`
    -DataSensitivityDiscoveryEnabled $true -DataSensitivityDiscoveryServiceAccountEmailAddress "mdc-data-sec-posture-storage@$emailSuffix" -DataSensitivityDiscoveryWorkloadIdentityProviderId "data-security-posture-storage" \`
    -CiemDiscoveryServiceAccountEmailAddress "microsoft-defender-ciem@$emailSuffix" -CiemDiscoveryAzureActiveDirectoryAppName "mciem-gcp-oidc-app" -CiemDiscoveryWorkloadIdentityProviderId "ciem-discovery"

$defenderForContainersOffering = New-AzSecurityDefenderForContainersGcpOfferingObject \`
    -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-containers@$emailSuffix" -NativeCloudConnectionWorkloadIdentityProviderId "containers" \`
    -DataPipelineNativeCloudConnectionServiceAccountEmailAddress "ms-defender-containers-stream@$emailSuffix" -DataPipelineNativeCloudConnectionWorkloadIdentityProviderId "containers-streams" \`
    -AuditLogsAutoProvisioningFlag $true -DefenderAgentAutoProvisioningFlag $true -PolicyAgentAutoProvisioningFlag $true \`
    -MdcContainerAgentlessDiscoveryK8SEnabled $true -MdcContainerAgentlessDiscoveryK8SWorkloadIdentityProviderId "containers" -MdcContainerAgentlessDiscoveryK8SServiceAccountEmailAddress "mdc-containers-k8s-operator@$emailSuffix" \`
    -MdcContainerImageAssessmentEnabled $true -MdcContainerImageAssessmentWorkloadIdentityProviderId "containers" -MdcContainerImageAssessmentServiceAccountEmailAddress "mdc-containers-artifact-assess@$emailSuffix"

$environment = New-AzSecurityGcpProjectEnvironmentObject -ScanInterval 24 -ProjectDetailProjectId "asc-sdk-samples" -ProjectDetailProjectNumber "$account"

New-AzSecurityConnector -Name "gcp-sdktest01" -ResourceGroupName "securityConnectors-tests" -EnvironmentData $environment -EnvironmentName GCP -HierarchyIdentifier "$account" \`
    -Offering @($cspmMonitorOffering, $dcspmOffering, $defenderForContainersOffering) -Location "CentralUS"

### EXAMPLE 3
```
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "ado-sdk-pwsh-test03" `
    -EnvironmentName AzureDevOps -EnvironmentData (New-AzSecurityAzureDevOpsScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorAzureDevOpsOfferingObject)
```

### EXAMPLE 4
```
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "gh-sdk-pwsh-test03" `
    -EnvironmentName GitHub -EnvironmentData (New-AzSecurityGitHubScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorGithubOfferingObject)
```

### EXAMPLE 5
```
New-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "gl-sdk-pwsh-test03" `
    -EnvironmentName GitLab -EnvironmentData (New-AzSecurityGitLabScopeEnvironmentObject) `
    -HierarchyIdentifier ([guid]::NewGuid().ToString()) -Location "CentralUS" `
    -Offering @(New-AzSecurityCspmMonitorGitLabOfferingObject)
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentData
The security connector environment data.
.

```yaml
Type: ISecurityConnectorEnvironment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
The multi cloud resource's cloud name.

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

### -Etag
Entity tag is used for comparing two or more entities from the same requested resource.

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

### -HierarchyIdentifier
The multi cloud resource identifier (account id in case of AWS connector, project number in case of GCP connector).

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

### -Kind
Kind of the resource

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

### -Location
Location where the resource is stored

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

### -Name
The security connector name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: SecurityConnectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offering
A collection of offerings for the security connector.
.

```yaml
Type: ICloudOffering[]
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

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID

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

### -Tag
A list of key value pairs that describe the resource.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityConnector
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

ENVIRONMENTDATA \<ISecurityConnectorEnvironment\>: The security connector environment data.
  EnvironmentType \<String\>: The type of the environment data.

OFFERING \<ICloudOffering\[\]\>: A collection of offerings for the security connector.
  OfferingType \<String\>: The type of the security offering.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnector](https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnector)

