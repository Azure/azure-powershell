---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azwebappdiagnosticlogconfig
schema: 2.0.0
---

# Set-AzWebAppDiagnosticLogConfig

## SYNOPSIS
Updates the logging configuration of an app.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWebAppDiagnosticLogConfig -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ApplicationLogsAzureBlobStorageRetentionInDay <Int32>] [-ApplicationLogsAzureBlobStorageSasUrl <String>]
 [-AzureBlobStorageEnabled] [-AzureBlobStorageLevel <LogLevel>] [-AzureTableStorageLevel <LogLevel>]
 [-AzureTableStorageSasUrl <String>] [-DetailedErrorMessageEnabled] [-FailedRequestTracingEnabled]
 [-FileSystemEnabled] [-FileSystemLevel <LogLevel>] [-FileSystemRetentionInDay <Int32>]
 [-FileSystemRetentionInMb <Int32>] [-HttpLogsAzureBlobStorageRetentionInDay <Int32>]
 [-HttpLogsAzureBlobStorageSasUrl <String>] [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzWebAppDiagnosticLogConfig -Name <String> -ResourceGroupName <String> -SiteLogsConfig <ISiteLogsConfig>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationLogsAzureBlobStorageSasUrl
SAS url to a azure blob container with read/write/list/delete permissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureBlobStorageLevel
Log level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.LogLevel
Parameter Sets: UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.LogLevel
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FailedRequestTracingEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemEnabled
True if configuration is enabled, false if it is disabled and null if configuration is not set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemLevel
Log level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.LogLevel
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileSystemRetentionInMb
Maximum size in megabytes that http log files can use.When reached old log files will be removed to make space for new ones.Value can range between 25 and 100.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLogsAzureBlobStorageRetentionInDay
Retention in days.Remove blobs older than X days.0 or lower means no retention.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLogsAzureBlobStorageSasUrl
SAS url to a azure blob container with read/write/list/delete permissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
To construct, see NOTES section for SITELOGSCONFIG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.ISiteLogsConfig
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.ISiteLogsConfig

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.ISiteLogsConfig

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### SITELOGSCONFIG <ISiteLogsConfig>: Configuration of App Service site logs.
  - `AzureTableStorageSasUrl <String>`: SAS URL to an Azure table with add/query/delete permissions.
  - `[Kind <String>]`: Kind of resource.
  - `[ApplicationLogsAzureBlobStorageRetentionInDay <Int32?>]`: Retention in days.         Remove blobs older than X days.         0 or lower means no retention.
  - `[ApplicationLogsAzureBlobStorageSasUrl <String>]`: SAS url to a azure blob container with read/write/list/delete permissions.
  - `[AzureBlobStorageEnabled <Boolean?>]`: True if configuration is enabled, false if it is disabled and null if configuration is not set.
  - `[AzureBlobStorageLevel <LogLevel?>]`: Log level.
  - `[AzureTableStorageLevel <LogLevel?>]`: Log level.
  - `[DetailedErrorMessageEnabled <Boolean?>]`: True if configuration is enabled, false if it is disabled and null if configuration is not set.
  - `[FailedRequestTracingEnabled <Boolean?>]`: True if configuration is enabled, false if it is disabled and null if configuration is not set.
  - `[FileSystemEnabled <Boolean?>]`: True if configuration is enabled, false if it is disabled and null if configuration is not set.
  - `[FileSystemLevel <LogLevel?>]`: Log level.
  - `[FileSystemRetentionInDay <Int32?>]`: Retention in days.         Remove files older than X days.         0 or lower means no retention.
  - `[FileSystemRetentionInMb <Int32?>]`: Maximum size in megabytes that http log files can use.         When reached old log files will be removed to make space for new ones.         Value can range between 25 and 100.
  - `[HttpLogsAzureBlobStorageRetentionInDay <Int32?>]`: Retention in days.         Remove blobs older than X days.         0 or lower means no retention.
  - `[HttpLogsAzureBlobStorageSasUrl <String>]`: SAS url to a azure blob container with read/write/list/delete permissions.

## RELATED LINKS

