---
external help file: Az.WebSite-help.xml
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
 -SubscriptionId <String> [-SiteLogsConfig <ISiteLogsConfig>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzWebAppDiagnosticLogConfigSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-ApplicationLogsAzureBlobStorageRetentionInDay <Int32>]
 [-ApplicationLogsAzureBlobStorageSasUrl <String>] [-AzureBlobStorageEnabled <Boolean>]
 [-AzureBlobStorageLevel <LogLevel>] [-AzureTableStorageLevel <LogLevel>] -AzureTableStorageSasUrl <String>
 [-DetailedErrorMessageEnabled <Boolean>] [-FailedRequestTracingEnabled <Boolean>]
 [-FileSystemEnabled <Boolean>] [-FileSystemLevel <LogLevel>] [-FileSystemRetentionInDay <Int32>]
 [-FileSystemRetentionInMb <Int32>] [-HttpLogsAzureBlobStorageRetentionInDay <Int32>]
 [-HttpLogsAzureBlobStorageSasUrl <String>] [-Kind <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzWebAppDiagnosticLogConfigSlot -InputObject <IWebSiteIdentity>
 [-ApplicationLogsAzureBlobStorageRetentionInDay <Int32>] [-ApplicationLogsAzureBlobStorageSasUrl <String>]
 [-AzureBlobStorageEnabled <Boolean>] [-AzureBlobStorageLevel <LogLevel>] [-AzureTableStorageLevel <LogLevel>]
 -AzureTableStorageSasUrl <String> [-DetailedErrorMessageEnabled <Boolean>]
 [-FailedRequestTracingEnabled <Boolean>] [-FileSystemEnabled <Boolean>] [-FileSystemLevel <LogLevel>]
 [-FileSystemRetentionInDay <Int32>] [-FileSystemRetentionInMb <Int32>]
 [-HttpLogsAzureBlobStorageRetentionInDay <Int32>] [-HttpLogsAzureBlobStorageSasUrl <String>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzWebAppDiagnosticLogConfigSlot -InputObject <IWebSiteIdentity> [-SiteLogsConfig <ISiteLogsConfig>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the logging configuration of an app.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
```

### -AzureBlobStorageEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
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

### -DetailedErrorMessageEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailedRequestTracingEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSystemEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.ISiteLogsConfig
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebappdiagnosticlogconfigslot](https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebappdiagnosticlogconfigslot)

