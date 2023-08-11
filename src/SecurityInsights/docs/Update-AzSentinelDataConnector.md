---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentineldataconnector
schema: 2.0.0
---

# Update-AzSentinelDataConnector

## SYNOPSIS
Create the data connector.

## SYNTAX

### UpdateAADAATP (Default)
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -AzureADorAATP
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateAmazonWebServicesCloudTrail
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -AWSCloudTrail
 [-SubscriptionId <String>] [-AWSRoleArn <String>] [-Log <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateAmazonWebServicesS3
```
Update-AzSentinelDataConnector [-DetinationTable <String>] [-SQSURL <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateAzureSecurityCenter
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -AzureSecurityCenter [-SubscriptionId <String>] [-Alerts <String>] [-ASCSubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateMicrosoftCloudAppSecurity
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -CloudAppSecurity [-SubscriptionId <String>] [-Alerts <String>] [-DiscoveryLog <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateMicrosoftDefenderAdvancedThreatProtection
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -DefenderATP
 [-SubscriptionId <String>] [-Alerts <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateOffice365
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String> -Office365
 [-SubscriptionId <String>] [-Exchange <String>] [-SharePoint <String>] [-Teams <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateThreatIntelligence
```
Update-AzSentinelDataConnector -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 -ThreatIntelligence [-SubscriptionId <String>] [-Indicator <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAADAATP
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AzureADorAATP [-Alerts <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityAmazonWebServicesCloudTrail
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AWSCloudTrail [-AWSRoleArn <String>]
 [-Log <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityAzureSecurityCenter
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -AzureSecurityCenter
 [-Alerts <String>] [-ASCSubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftCloudAppSecurity
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -CloudAppSecurity [-Alerts <String>]
 [-DiscoveryLog <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -DefenderATP [-Alerts <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityOffice365
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -Office365 [-Exchange <String>]
 [-SharePoint <String>] [-Teams <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityThreatIntelligence
```
Update-AzSentinelDataConnector -InputObject <ISecurityInsightsIdentity> -ThreatIntelligence
 [-Indicator <String>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the data connector.

## EXAMPLES

### Example 1: Update a Sentinel data connector
```powershell
Update-AzSentinelDataConnector -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id 3bd6c555-1412-4103-9b9d-2b0b40cda6b6 -SharePoint "Enabled"
```

This command updates a Sentinel data connector

## PARAMETERS

### -Alerts


```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityAADAATP, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection
Aliases:

Required: False
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
Parameter Sets: UpdateAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesCloudTrail
Aliases:

Required: False
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

### -CloudAppSecurity


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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Parameter Sets: UpdateAmazonWebServicesS3
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

### -Id
Connector ID

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOffice365, UpdateThreatIntelligence
Aliases: DataConnectorId

Required: True
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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityAADAATP, UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityOffice365, UpdateViaIdentityThreatIntelligence
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
Parameter Sets: UpdateAmazonWebServicesCloudTrail, UpdateViaIdentityAmazonWebServicesCloudTrail
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOffice365, UpdateThreatIntelligence
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
Parameter Sets: UpdateAmazonWebServicesS3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOffice365, UpdateThreatIntelligence
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
The TenantId.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOffice365, UpdateThreatIntelligence, UpdateViaIdentityAADAATP, UpdateViaIdentityAmazonWebServicesCloudTrail, UpdateViaIdentityAzureSecurityCenter, UpdateViaIdentityMicrosoftCloudAppSecurity, UpdateViaIdentityMicrosoftDefenderAdvancedThreatProtection, UpdateViaIdentityOffice365, UpdateViaIdentityThreatIntelligence
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

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateAADAATP, UpdateAmazonWebServicesCloudTrail, UpdateAzureSecurityCenter, UpdateMicrosoftCloudAppSecurity, UpdateMicrosoftDefenderAdvancedThreatProtection, UpdateOffice365, UpdateThreatIntelligence
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IDataConnector

## NOTES

## RELATED LINKS

