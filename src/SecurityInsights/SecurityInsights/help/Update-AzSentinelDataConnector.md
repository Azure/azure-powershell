---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentineldataconnector
schema: 2.0.0
---

# Update-AzSentinelDataConnector

## SYNOPSIS
Updates the data connector.

## SYNTAX

### UpdateAADAATP (Default)
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Alerts <String>] [-DefaultProfile <PSObject>]
 [-AzureADorAATP] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateAmazonWebServicesCloudTrail
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-AWSRoleArn <String>] [-Log <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-AWSCloudTrail] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateAmazonWebServicesS3
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-AWSRoleArn <String>] [-Log <String>] [-SQSURL <String[]>]
 [-DetinationTable <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-AWSS3]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateAzureSecurityCenter
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-Alerts <String>] [-ASCSubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-AzureSecurityCenter] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateDynamics365
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-CommonDataServiceActivity <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Dynamics365] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateMicrosoftCloudAppSecurity
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Alerts <String>] [-DiscoveryLog <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-CloudAppSecurity] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateMicrosoftDefenderAdvancedThreatProtection
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Alerts <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-DefenderATP] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateMicrosoftThreatIntelligence
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-BingSafetyPhishinURL <String>]
 [-BingSafetyPhishingUrlLookbackPeriod <String>] [-MicrosoftEmergingThreatFeed <String>]
 [-MicrosoftEmergingThreatFeedLookbackPeriod <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-MicrosoftTI] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateMicrosoftThreatProtection
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Incident <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-MicrosoftThreatProtection] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateOffice365
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Exchange <String>] [-SharePoint <String>] [-Teams <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Office365] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateOfficeATP
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Alerts <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-OfficeATP] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateOfficeIRM
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Alerts <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-OfficeIRM] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateThreatIntelligence
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] [-Indicator <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ThreatIntelligence] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateThreatIntelligenceTaxii
```
Update-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Id <String>
 [-SubscriptionId <String>] [-TenantId <String>] -APIRootURL <String> [-WorkspaceId <String>]
 [-FriendlyName <String>] [-CollectionId <String>] [-UserName <String>] [-Password <String>]
 [-TaxiiLookbackPeriod <String>] [-PollingFrequency <PollingFrequency>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ThreatIntelligenceTaxii] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityAmazonWebServicesCloudTrail
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-AWSRoleArn <String>] [-Log <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-AWSCloudTrail]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityAmazonWebServicesS3
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-AWSRoleArn <String>] [-Log <String>] [-SQSURL <String[]>] [-DetinationTable <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-AWSS3] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityAADAATP
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-DefaultProfile <PSObject>] [-AzureADorAATP] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityAzureSecurityCenter
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-ASCSubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-AzureSecurityCenter]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityDynamics365
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-CommonDataServiceActivity <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Dynamics365]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftCloudAppSecurity
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-DiscoveryLog <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-CloudAppSecurity]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-DefenderATP] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftThreatIntelligence
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-BingSafetyPhishinURL <String>] [-BingSafetyPhishingUrlLookbackPeriod <String>]
 [-MicrosoftEmergingThreatFeed <String>] [-MicrosoftEmergingThreatFeedLookbackPeriod <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-MicrosoftTI] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftThreatProtection
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-Incident <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-MicrosoftThreatProtection]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityOffice365
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-Exchange <String>] [-SharePoint <String>] [-Teams <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Office365] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityOfficeATP
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-OfficeATP] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityOfficeIRM
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>] [-Alerts <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-OfficeIRM] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityThreatIntelligence
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-Indicator <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ThreatIntelligence]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityThreatIntelligenceTaxii
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> [-TenantId <String>]
 [-WorkspaceId <String>] [-FriendlyName <String>] [-CollectionId <String>] [-UserName <String>]
 [-Password <String>] [-TaxiiLookbackPeriod <String>] [-PollingFrequency <PollingFrequency>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ThreatIntelligenceTaxii]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateGenericUI
```
Update-AzSentinelDataConnector [-UiConfigTitle <String>] [-UiConfigPublisher <String>]
 [-UiConfigDescriptionMarkdown <String>] [-UiConfigCustomImage <String>]
 [-UiConfigGraphQueriesTableName <String>] [-UiConfigGraphQuery <GraphQueries[]>]
 [-UiConfigSampleQuery <SampleQueries[]>] [-UiConfigDataType <LastDataReceivedDataType[]>]
 [-UiConfigConnectivityCriterion <ConnectivityCriteria[]>] [-AvailabilityIsPreview <Boolean>]
 [-AvailabilityStatus <Int32>] [-PermissionResourceProvider <PermissionsResourceProviderItem[]>]
 [-PermissionCustom <PermissionsCustomsItem[]>] [-UiConfigInstructionStep <InstructionSteps[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityGenericUI
```
Update-AzSentinelDataConnector [-UiConfigTitle <String>] [-UiConfigPublisher <String>]
 [-UiConfigDescriptionMarkdown <String>] [-UiConfigCustomImage <String>]
 [-UiConfigGraphQueriesTableName <String>] [-UiConfigGraphQuery <GraphQueries[]>]
 [-UiConfigSampleQuery <SampleQueries[]>] [-UiConfigDataType <LastDataReceivedDataType[]>]
 [-UiConfigConnectivityCriterion <ConnectivityCriteria[]>] [-AvailabilityIsPreview <Boolean>]
 [-AvailabilityStatus <Int32>] [-PermissionResourceProvider <PermissionsResourceProviderItem[]>]
 [-PermissionCustom <PermissionsCustomsItem[]>] [-UiConfigInstructionStep <InstructionSteps[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the data connector.

## EXAMPLES

### Example 1: Update a Sentinel data connector
```powershell
Update-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id  3bd6c555-1412-4103-9b9d-2b0b40cda6b6 -SharePoint "Enabled"
```

This command updates a Sentinel data connector

## PARAMETERS

### -Alerts

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOfficeATP, UpdateOfficeIRM, UpdateViaIdentityAADAATP, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityOfficeATP, UpdateViaIdentityOfficeIRM
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -APIRootURL

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ASCSubscriptionId
ASC Subscription Id.

```yaml
Type: System.String
Parameter Sets: UpdateAzureSecurityCenter, UpdateViaIdentityAzureSecurityCenter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityIsPreview

```yaml
Type: System.Boolean
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityStatus

```yaml
Type: System.Int32
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: 1
Accept pipeline input: False
Accept wildcard characters: False
```

### -AWSCloudTrail

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesCloudTrail
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AWSRoleArn

```yaml
Type: System.String
Parameter Sets: UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesS3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AWSS3

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateAmazonWebServicesS3, UpdateViaIdentityAmazonWebServicesS3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureADorAATP

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateAADAATP, UpdateViaIdentityAADAATP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureSecurityCenter

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateAzureSecurityCenter, UpdateViaIdentityAzureSecurityCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BingSafetyPhishingUrlLookbackPeriod

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BingSafetyPhishinURL

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudAppSecurity
[Parameter(ParameterSetName = 'UpdateGenericUI', Mandatory)]
[Parameter(ParameterSetName = 'UpdateViaIdentityGenericUI', Mandatory)]
[Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
[System.Management.Automation.SwitchParameter]
${GenericUI},

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftCloudAppSecurity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionId

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDataServiceActivity

```yaml
Type: System.String
Parameter Sets: UpdateDynamics365, UpdateViaIdentityDynamics365
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefenderATP

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DetinationTable

```yaml
Type: System.String
Parameter Sets: UpdateAmazonWebServicesS3, UpdateViaIdentityAmazonWebServicesS3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveryLog

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftCloudAppSecurity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dynamics365

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateDynamics365, UpdateViaIdentityDynamics365
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exchange

```yaml
Type: System.String
Parameter Sets: UpdateOffice365, UpdateViaIdentityOffice365
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
[Parameter(ParameterSetName = 'UpdateGenericUI', Mandatory)]
 The Id of the Data Connector.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateAzureSecurityCenter, UpdateDynamics365, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateMicrosoftThreatIntelligence, UpdateMicrosoftThreatProtection, UpdateOffice365, UpdateOfficeATP, UpdateOfficeIRM, UpdateThreatIntelligence, UpdateThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Incident

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftThreatProtection, UpdateViaIdentityMicrosoftThreatProtection
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Indicator

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligence, UpdateViaIdentityThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
[Parameter(ParameterSetName = 'UpdateViaIdentityGenericUI', Mandatory, ValueFromPipeline)]
 Identity Parameter

To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesS3, UpdateViaIdentityAADAATP, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityDynamics365, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatProtection, UpdateViaIdentityOffice365, UpdateViaIdentityOfficeATP, UpdateViaIdentityOfficeIRM, UpdateViaIdentityThreatIntelligence, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Log

```yaml
Type: System.String
Parameter Sets: UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesS3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftEmergingThreatFeed

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftEmergingThreatFeedLookbackPeriod

```yaml
Type: System.String
Parameter Sets: UpdateMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftThreatProtection

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftThreatProtection, UpdateViaIdentityMicrosoftThreatProtection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftTI

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatIntelligence
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Office365

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateOffice365, UpdateViaIdentityOffice365
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfficeATP

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateOfficeATP, UpdateViaIdentityOfficeATP
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfficeIRM

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateOfficeIRM, UpdateViaIdentityOfficeIRM
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionCustom
To construct, see NOTES section for PERMISSIONCUSTOM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.PermissionsCustomsItem[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionResourceProvider
To construct, see NOTES section for PERMISSIONRESOURCEPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.PermissionsResourceProviderItem[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PollingFrequency

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.PollingFrequency
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
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

### -ResourceGroupName
[Parameter(ParameterSetName = 'UpdateGenericUI', Mandatory)]
 The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateAzureSecurityCenter, UpdateDynamics365, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateMicrosoftThreatIntelligence, UpdateMicrosoftThreatProtection, UpdateOffice365, UpdateOfficeATP, UpdateOfficeIRM, UpdateThreatIntelligence, UpdateThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePoint

```yaml
Type: System.String
Parameter Sets: UpdateOffice365, UpdateViaIdentityOffice365
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SQSURL

```yaml
Type: System.String[]
Parameter Sets: UpdateAmazonWebServicesS3, UpdateViaIdentityAmazonWebServicesS3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
[Parameter(ParameterSetName = 'UpdateGenericUI')]
 Gets subscription credentials which uniquely identify Microsoft Azure subscription.
 The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateAzureSecurityCenter, UpdateDynamics365, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateMicrosoftThreatIntelligence, UpdateMicrosoftThreatProtection, UpdateOffice365, UpdateOfficeATP, UpdateOfficeIRM, UpdateThreatIntelligence, UpdateThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaxiiLookbackPeriod

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Teams

```yaml
Type: System.String
Parameter Sets: UpdateOffice365, UpdateViaIdentityOffice365
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
[Parameter(ParameterSetName = 'UpdateViaIdentityGenericUI')]
 The TenantId.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateDynamics365, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateMicrosoftThreatIntelligence, UpdateMicrosoftThreatProtection, UpdateOffice365, UpdateOfficeATP, UpdateOfficeIRM, UpdateThreatIntelligence, UpdateThreatIntelligenceTaxii, UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesS3, UpdateViaIdentityAADAATP, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityDynamics365, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityMicrosoftThreatIntelligence, UpdateViaIdentityMicrosoftThreatProtection, UpdateViaIdentityOffice365, UpdateViaIdentityOfficeATP, UpdateViaIdentityOfficeIRM, UpdateViaIdentityThreatIntelligence, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Tenant.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatIntelligence

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateThreatIntelligence, UpdateViaIdentityThreatIntelligence
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatIntelligenceTaxii

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigConnectivityCriterion
To construct, see NOTES section for UICONFIGCONNECTIVITYCRITERION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ConnectivityCriteria[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigCustomImage

```yaml
Type: System.String
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigDataType
To construct, see NOTES section for UICONFIGDATATYPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.LastDataReceivedDataType[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigDescriptionMarkdown

```yaml
Type: System.String
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigGraphQueriesTableName

```yaml
Type: System.String
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigGraphQuery
To construct, see NOTES section for UICONFIGGRAPHQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.GraphQueries[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigInstructionStep
To construct, see NOTES section for UICONFIGINSTRUCTIONSTEP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.InstructionSteps[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigPublisher

```yaml
Type: System.String
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigSampleQuery
To construct, see NOTES section for UICONFIGSAMPLEQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.SampleQueries[]
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigTitle

```yaml
Type: System.String
Parameter Sets: UpdateGenericUI, UpdateViaIdentityGenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceId

```yaml
Type: System.String
Parameter Sets: UpdateThreatIntelligenceTaxii, UpdateViaIdentityThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
[Parameter(ParameterSetName = 'UpdateGenericUI', Mandatory)]
 The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAmazonWebServicesS3, UpdateAzureSecurityCenter, UpdateDynamics365, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateMicrosoftThreatIntelligence, UpdateMicrosoftThreatProtection, UpdateOffice365, UpdateOfficeATP, UpdateOfficeIRM, UpdateThreatIntelligence, UpdateThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.DataConnector

## NOTES

## RELATED LINKS
