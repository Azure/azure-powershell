---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentineldataconnector
schema: 2.0.0
---

# New-AzSentinelDataConnector

## SYNOPSIS
Creates or updates the data connector.

## SYNTAX

### AADAATP (Default)
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AmazonWebServicesCloudTrail
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -AWSRoleArn <String>
 -Kind <DataConnectorKind> [-Id <String>] [-SubscriptionId <String>] [-Log <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AmazonWebServicesS3
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -AWSRoleArn <String>
 -DetinationTable <String> -Kind <DataConnectorKind> -Log <String> -SQSURL <String[]> [-Id <String>]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AzureSecurityCenter
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -ASCSubscriptionId <String>
 -Kind <DataConnectorKind> [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Dynamics365
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-CommonDataServiceActivity <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenericUI
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String>
 -AvailabilityIsPreview <Boolean> -Kind <DataConnectorKind>
 -UiConfigConnectivityCriterion <ConnectivityCriteria[]> -UiConfigDataType <LastDataReceivedDataType[]>
 -UiConfigDescriptionMarkdown <String> -UiConfigGraphQueriesTableName <String>
 -UiConfigGraphQuery <GraphQueries[]> -UiConfigInstructionStep <InstructionSteps[]>
 -UiConfigPublisher <String> -UiConfigSampleQuery <SampleQueries[]> -UiConfigTitle <String> [-Id <String>]
 [-SubscriptionId <String>] [-AvailabilityStatus <Int32>] [-PermissionCustom <PermissionsCustomsItem[]>]
 [-PermissionResourceProvider <PermissionsResourceProviderItem[]>] [-UiConfigCustomImage <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftCloudAppSecurity
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-DiscoveryLog <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftDefenderAdvancedThreatProtection
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftThreatIntelligence
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-BingSafetyPhishingURL <String>]
 [-BingSafetyPhishingUrlLookbackPeriod <String>] [-MicrosoftEmergingThreatFeed <String>]
 [-MicrosoftEmergingThreatFeedLookbackPeriod <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftThreatProtection
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Incident <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Office365
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Exchange <String>] [-SharePoint <String>] [-Teams <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### OfficeATP
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfficeIRM
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ThreatIntelligence
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -Kind <DataConnectorKind>
 [-Id <String>] [-SubscriptionId <String>] [-Indicator <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ThreatIntelligenceTaxii
```
New-AzSentinelDataConnector -ResourceGroupName <String> -WorkspaceName <String> -APIRootURL <String>
 -CollectionId <String> -FriendlyName <String> -Kind <DataConnectorKind> -PollingFrequency <PollingFrequency>
 -WorkspaceId <String> [-Id <String>] [-SubscriptionId <String>] [-Password <String>]
 [-TaxiiLookbackPeriod <String>] [-TenantId <String>] [-UserName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the data connector.

## EXAMPLES

### Example 1: Enable a data connector.
```powershell
New-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind 'MicrosoftThreatIntelligence' -BingSafetyPhishingURL Enabled -BingSafetyPhishingUrlLookbackPeriod All  -MicrosoftEmergingThreatFeed Enabled -MicrosoftEmergingThreatFeedLookbackPeriod All
```

This command enables the Threat Intelligence data connector
s
## PARAMETERS

### -Alerts


```yaml
Type: System.String
Parameter Sets: AADAATP, AzureSecurityCenter, MicrosoftCloudAppSecurity, MicrosoftDefenderAdvancedThreatProtection, OfficeATP, OfficeIRM
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
Parameter Sets: ThreatIntelligenceTaxii
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
Parameter Sets: AzureSecurityCenter
Aliases:

Required: True
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
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]

```yaml
Type: System.Boolean
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityStatus
[Parameter(ParameterSetName = 'APIPolling')]

```yaml
Type: System.Int32
Parameter Sets: GenericUI
Aliases:

Required: False
Position: Named
Default value: 1
Accept pipeline input: False
Accept wildcard characters: False
```

### -AWSRoleArn


```yaml
Type: System.String
Parameter Sets: AmazonWebServicesCloudTrail, AmazonWebServicesS3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BingSafetyPhishingURL


```yaml
Type: System.String
Parameter Sets: MicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BingSafetyPhishingUrlLookbackPeriod


```yaml
Type: System.String
Parameter Sets: MicrosoftThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionId


```yaml
Type: System.String
Parameter Sets: ThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonDataServiceActivity


```yaml
Type: System.String
Parameter Sets: Dynamics365
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

### -DetinationTable


```yaml
Type: System.String
Parameter Sets: AmazonWebServicesS3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveryLog


```yaml
Type: System.String
Parameter Sets: MicrosoftCloudAppSecurity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exchange


```yaml
Type: System.String
Parameter Sets: Office365
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
Parameter Sets: ThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The Id of the Data Connector.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -Incident


```yaml
Type: System.String
Parameter Sets: MicrosoftThreatProtection
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
Parameter Sets: ThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of the the data connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.DataConnectorKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Log


```yaml
Type: System.String
Parameter Sets: AmazonWebServicesCloudTrail, AmazonWebServicesS3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftEmergingThreatFeed


```yaml
Type: System.String
Parameter Sets: MicrosoftThreatIntelligence
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
Parameter Sets: MicrosoftThreatIntelligence
Aliases:

Required: False
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

### -Password


```yaml
Type: System.String
Parameter Sets: ThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionCustom
[Parameter(ParameterSetName = 'APIPolling')]
To construct, see NOTES section for PERMISSIONCUSTOM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.PermissionsCustomsItem[]
Parameter Sets: GenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionResourceProvider
[Parameter(ParameterSetName = 'APIPolling')]
To construct, see NOTES section for PERMISSIONRESOURCEPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.PermissionsResourceProviderItem[]
Parameter Sets: GenericUI
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
Parameter Sets: ThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: Office365
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
Parameter Sets: AmazonWebServicesS3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: ThreatIntelligenceTaxii
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
Parameter Sets: Office365
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The TenantId.

```yaml
Type: System.String
Parameter Sets: AADAATP, Dynamics365, MicrosoftCloudAppSecurity, MicrosoftDefenderAdvancedThreatProtection, MicrosoftThreatIntelligence, MicrosoftThreatProtection, Office365, OfficeATP, OfficeIRM, ThreatIntelligence, ThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Tenant.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigConnectivityCriterion
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]
To construct, see NOTES section for UICONFIGCONNECTIVITYCRITERION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ConnectivityCriteria[]
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigCustomImage
[Parameter(ParameterSetName = 'APIPolling')]

```yaml
Type: System.String
Parameter Sets: GenericUI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigDataType
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]
To construct, see NOTES section for UICONFIGDATATYPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.LastDataReceivedDataType[]
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigDescriptionMarkdown
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]

```yaml
Type: System.String
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigGraphQueriesTableName
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]

```yaml
Type: System.String
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigGraphQuery
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]
To construct, see NOTES section for UICONFIGGRAPHQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.GraphQueries[]
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigInstructionStep
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]
To construct, see NOTES section for UICONFIGINSTRUCTIONSTEP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.InstructionSteps[]
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigPublisher
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]

```yaml
Type: System.String
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigSampleQuery
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]
To construct, see NOTES section for UICONFIGSAMPLEQUERY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.SampleQueries[]
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UiConfigTitle
[Parameter(ParameterSetName = 'APIPolling', Mandatory)]

```yaml
Type: System.String
Parameter Sets: GenericUI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName


```yaml
Type: System.String
Parameter Sets: ThreatIntelligenceTaxii
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
Parameter Sets: ThreatIntelligenceTaxii
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.DataConnector

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PERMISSIONCUSTOM <PermissionsCustomsItem[]>`: [Parameter(ParameterSetName = 'APIPolling')]
  - `[Description <String>]`: Customs permissions description
  - `[Name <String>]`: Customs permissions name

`PERMISSIONRESOURCEPROVIDER <PermissionsResourceProviderItem[]>`: [Parameter(ParameterSetName = 'APIPolling')]
  - `[PermissionsDisplayText <String>]`: Permission description text
  - `[Provider <ProviderName?>]`: Provider name
  - `[ProviderDisplayName <String>]`: Permission provider display name
  - `[RequiredPermissionAction <Boolean?>]`: action permission
  - `[RequiredPermissionDelete <Boolean?>]`: delete permission
  - `[RequiredPermissionRead <Boolean?>]`: read permission
  - `[RequiredPermissionWrite <Boolean?>]`: write permission
  - `[Scope <PermissionProviderScope?>]`: Permission provider scope

`UICONFIGCONNECTIVITYCRITERION <ConnectivityCriteria[]>`: [Parameter(ParameterSetName = 'APIPolling', Mandatory)]
  - `[Type <ConnectivityType?>]`: type of connectivity
  - `[Value <String[]>]`: Queries for checking connectivity

`UICONFIGDATATYPE <LastDataReceivedDataType[]>`: [Parameter(ParameterSetName = 'APIPolling', Mandatory)]
  - `[LastDataReceivedQuery <String>]`: Query for indicate last data received
  - `[Name <String>]`: Name of the data type to show in the graph. can be use with {{graphQueriesTableName}} placeholder

`UICONFIGGRAPHQUERY <GraphQueries[]>`: [Parameter(ParameterSetName = 'APIPolling', Mandatory)]
  - `[BaseQuery <String>]`: The base query for the graph
  - `[Legend <String>]`: The legend for the graph
  - `[MetricName <String>]`: the metric that the query is checking

`UICONFIGINSTRUCTIONSTEP <InstructionSteps[]>`: [Parameter(ParameterSetName = 'APIPolling', Mandatory)]
  - `[Description <String>]`: Instruction step description
  - `[Instruction <IConnectorInstructionModelBase[]>]`: Instruction step details
    - `Type <SettingType>`: The kind of the setting
    - `[Parameter <IAny>]`: The parameters for the setting
  - `[Title <String>]`: Instruction step title

`UICONFIGSAMPLEQUERY <SampleQueries[]>`: [Parameter(ParameterSetName = 'APIPolling', Mandatory)]
  - `[Description <String>]`: The sample query description
  - `[Query <String>]`: the sample query

## RELATED LINKS

