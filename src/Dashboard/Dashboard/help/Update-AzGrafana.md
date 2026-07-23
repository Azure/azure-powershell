---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/update-azgrafana
schema: 2.0.0
---

# Update-AzGrafana

## SYNOPSIS
Update a workspace for Grafana resource.
This API is idempotent, so user can either update a new grafana or update an existing grafana.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzGrafana -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-ApiKey <String>]
 [-CreatorCanAdmin <String>] [-DeterministicOutboundIP <String>] [-EnableSystemAssignedIdentity <Boolean>]
 [-EnterpriseConfigurationMarketplaceAutoRenew <String>] [-EnterpriseConfigurationMarketplacePlanId <String>]
 [-GrafanaMajorVersion <String>] [-GrafanaPlugin <Hashtable>]
 [-MonitorWorkspaceIntegration <IAzureMonitorWorkspaceIntegration[]>] [-PublicNetworkAccess <String>]
 [-SecurityCsrfAlwaysCheck] [-SkuName <String>] [-SmtpEnabled] [-SmtpFromAddress <String>]
 [-SmtpFromName <String>] [-SmtpHost <String>] [-SmtpPassword <SecureString>] [-SmtpSkipVerify]
 [-SmtpStartTlsPolicy <String>] [-SmtpUser <String>] [-SnapshotExternalEnabled] [-Tag <Hashtable>]
 [-UnifiedAlertingScreenshotCaptureEnabled] [-UserAssignedIdentity <String[]>] [-UserEditorsCanAdmin]
 [-UserViewersCanEdit] [-ZoneRedundancy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzGrafana -InputObject <IDashboardIdentity> [-ApiKey <String>] [-CreatorCanAdmin <String>]
 [-DeterministicOutboundIP <String>] [-EnableSystemAssignedIdentity <Boolean>]
 [-EnterpriseConfigurationMarketplaceAutoRenew <String>] [-EnterpriseConfigurationMarketplacePlanId <String>]
 [-GrafanaMajorVersion <String>] [-GrafanaPlugin <Hashtable>]
 [-MonitorWorkspaceIntegration <IAzureMonitorWorkspaceIntegration[]>] [-PublicNetworkAccess <String>]
 [-SecurityCsrfAlwaysCheck] [-SkuName <String>] [-SmtpEnabled] [-SmtpFromAddress <String>]
 [-SmtpFromName <String>] [-SmtpHost <String>] [-SmtpPassword <SecureString>] [-SmtpSkipVerify]
 [-SmtpStartTlsPolicy <String>] [-SmtpUser <String>] [-SnapshotExternalEnabled] [-Tag <Hashtable>]
 [-UnifiedAlertingScreenshotCaptureEnabled] [-UserAssignedIdentity <String[]>] [-UserEditorsCanAdmin]
 [-UserViewersCanEdit] [-ZoneRedundancy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a workspace for Grafana resource.
This API is idempotent, so user can either update a new grafana or update an existing grafana.

## EXAMPLES

### Example 1: Update a workspace for Grafana resource.
```powershell
Update-AzGrafana -GrafanaName azpstest-grafana -ResourceGroupName azpstest-gp -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -EnableSystemAssignedIdentity $true -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.

### Example 2: Update a workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana | Update-AzGrafana -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -EnableSystemAssignedIdentity $true -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.

## PARAMETERS

### -ApiKey
The api key setting of the Grafana instance.

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

### -CreatorCanAdmin
The creator will have admin access for the Grafana instance.

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

### -DeterministicOutboundIP
Whether a Grafana instance uses deterministic outbound IPs.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnterpriseConfigurationMarketplaceAutoRenew
The AutoRenew setting of the Enterprise subscription

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

### -EnterpriseConfigurationMarketplacePlanId
The Plan Id of the Azure Marketplace subscription for the Enterprise plugins

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

### -GrafanaMajorVersion
The major Grafana software version to target.

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

### -GrafanaPlugin
Installed plugin list of the Grafana instance.
Key is plugin id, value is plugin definition.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorWorkspaceIntegration
The MonitorWorkspaceIntegration of Azure Managed Grafana.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IAzureMonitorWorkspaceIntegration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: GrafanaName

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

### -PublicNetworkAccess
Indicate the state for enable or disable traffic over the public interface.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityCsrfAlwaysCheck
Set to true to execute the CSRF check even if the login cookie is not in a request (default false).

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

### -SkuName
The Sku of the grafana resource.

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

### -SmtpEnabled
Enable this to allow Grafana to send email.
Default is false

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

### -SmtpFromAddress
Address used when sending out emailshttps://pkg.go.dev/net/mail#Address

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

### -SmtpFromName
Name to be used when sending out emails.
Default is "Azure Managed Grafana Notification"https://pkg.go.dev/net/mail#Address

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

### -SmtpHost
SMTP server hostname with port, e.g.
test.email.net:587

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

### -SmtpPassword
Password of SMTP auth.
If the password contains # or ;, then you have to wrap it with triple quotes

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmtpSkipVerify
Verify SSL for SMTP server.
Default is falsehttps://pkg.go.dev/crypto/tls#Config

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

### -SmtpStartTlsPolicy
The StartTLSPolicy setting of the SMTP configurationhttps://pkg.go.dev/github.com/go-mail/mail#StartTLSPolicy

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

### -SmtpUser
User of SMTP auth

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

### -SnapshotExternalEnabled
Set to false to disable external snapshot publish endpoint

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnifiedAlertingScreenshotCaptureEnabled
Set to false to disable capture screenshot in Unified Alert due to performance issue.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEditorsCanAdmin
Set to true so editors can administrate dashboards, folders and teams they create.

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

### -UserViewersCanEdit
Set to true so viewers can access and use explore and perform temporary edits on panels in dashboards they have access to.
They cannot save their changes.

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

### -ZoneRedundancy
The zone redundancy setting of the Grafana instance.

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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IManagedGrafana

## NOTES

## RELATED LINKS
