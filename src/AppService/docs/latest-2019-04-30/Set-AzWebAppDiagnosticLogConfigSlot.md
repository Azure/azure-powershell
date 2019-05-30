---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebappdiagnosticlogconfigslot
schema: 2.0.0
---

# Set-AzWebAppDiagnosticLogConfigSlot

## SYNOPSIS
Updates the logging configuration of an app.

## SYNTAX

### Update (Default)
```
Set-AzWebAppDiagnosticLogConfigSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-SiteLogsConfig <ISiteLogsConfig>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzWebAppDiagnosticLogConfigSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> -AzureTableStorageSasUrl <String>
 [-ApplicationLogsAzureBlobStorageRetentionInDay <Int32>] [-ApplicationLogsAzureBlobStorageSasUrl <String>]
 [-AzureBlobStorageEnabled] [-AzureBlobStorageLevel <LogLevel>] [-AzureTableStorageLevel <LogLevel>]
 [-DetailedErrorMessageEnabled] [-FailedRequestTracingEnabled] [-FileSystemEnabled]
 [-FileSystemLevel <LogLevel>] [-FileSystemRetentionInDay <Int32>] [-FileSystemRetentionInMb <Int32>]
 [-HttpLogsAzureBlobStorageRetentionInDay <Int32>] [-HttpLogsAzureBlobStorageSasUrl <String>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzWebAppDiagnosticLogConfigSlot -InputObject <IWebSiteIdentity> -AzureTableStorageSasUrl <String>
 [-ApplicationLogsAzureBlobStorageRetentionInDay <Int32>] [-ApplicationLogsAzureBlobStorageSasUrl <String>]
 [-AzureBlobStorageEnabled] [-AzureBlobStorageLevel <LogLevel>] [-AzureTableStorageLevel <LogLevel>]
 [-DetailedErrorMessageEnabled] [-FailedRequestTracingEnabled] [-FileSystemEnabled]
 [-FileSystemLevel <LogLevel>] [-FileSystemRetentionInDay <Int32>] [-FileSystemRetentionInMb <Int32>]
 [-HttpLogsAzureBlobStorageRetentionInDay <Int32>] [-HttpLogsAzureBlobStorageSasUrl <String>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzWebAppDiagnosticLogConfigSlot -InputObject <IWebSiteIdentity> [-SiteLogsConfig <ISiteLogsConfig>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the logging configuration of an app.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationLogsAzureBlobStorageRetentionInDay
Retention in days.Remove blobs older than X days.0 or lower means no retention.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationLogsAzureBlobStorageSasUrl
SAS url to a azure blob container with read/write/list/delete permissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureBlobStorageEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureBlobStorageLevel
Log level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.LogLevel
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureTableStorageLevel
Log level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.LogLevel
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureTableStorageSasUrl
SAS URL to an Azure table with add/query/delete permissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DetailedErrorMessageEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FailedRequestTracingEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemLevel
Log level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.LogLevel
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemRetentionInDay
Retention in days.Remove files older than X days.0 or lower means no retention.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemRetentionInMb
Maximum size in megabytes that http log files can use.When reached old log files will be removed to make space for new ones.Value can range between 25 and 100.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLogsAzureBlobStorageRetentionInDay
Retention in days.Remove blobs older than X days.0 or lower means no retention.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLogsAzureBlobStorageSasUrl
SAS url to a azure blob container with read/write/list/delete permissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteLogsConfig
Configuration of App Service site logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.ISiteLogsConfig
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will update the logging configuration for the production slot.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.ISiteLogsConfig

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.ISiteLogsConfig

## ALIASES

## RELATED LINKS

