---
external help file:
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/new-azappconfigurationsnapshot
schema: 2.0.0
---

# New-AzAppConfigurationSnapshot

## SYNOPSIS
Create a key-value snapshot.

## SYNTAX

### Create (Default)
```
New-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> -Entity <ISnapshot> [-SyncToken <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> -Filter <IKeyValueFilter[]>
 [-SyncToken <String>] [-CompositionType <String>] [-RetentionPeriod <Int64>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzAppConfigurationSnapshot -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 -Entity <ISnapshot> [-SyncToken <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzAppConfigurationSnapshot -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 -Filter <IKeyValueFilter[]> [-SyncToken <String>] [-CompositionType <String>] [-RetentionPeriod <Int64>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> -JsonFilePath <String> [-SyncToken <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> -JsonString <String> [-SyncToken <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a key-value snapshot.

## EXAMPLES

### Example 1: Create a snapshot with a key filter
```powershell
$filter = @{ Key = "app/*" }
New-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Filter $filter
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Create a key-value snapshot that captures all key-values matching the key filter "app/*".

### Example 2: Create a snapshot with a retention period and composition type
```powershell
$filter = @{ Key = "app/*"; Label = "prod" }
New-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "prodSnapshot" -Filter $filter -CompositionType "key_label" -RetentionPeriod 7776000
```

```output
Name         Status CompositionType Created               Expires                RetentionPeriod Size ItemsCount Etag
----         ------ --------------- -------               -------                --------------- ---- ---------- ----
prodSnapshot ready  key_label       7/21/2023 02:40:00    10/19/2023 02:40:00    7776000         2048 10         ghijkl
```

Create a snapshot with key_label composition type and a 90-day retention period, filtering by both key and label.

## PARAMETERS

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

### -CompositionType
The composition type describes how the key-values within the snapshot are composed.
The 'key' composition type ensures there are no two key-values containing the same key.
The 'key_label' composition type ensures there are no two key-values containing the same key and label.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -Endpoint
The endpoint of the App Configuration instance to send requests to.

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

### -Entity
A snapshot is a named, immutable subset of an App Configuration store's key-values.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshot
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Filter
A list of filters used to filter the key-values included in the snapshot.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValueFilter[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IAppConfigurationdataIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the key-value snapshot to create.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -RetentionPeriod
The amount of time, in seconds, that a snapshot will remain in the archived state before expiring.
This property is only writable during the creation of a snapshot.
If not specified, the default lifetime of key-value revisions will be used.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncToken
Used to guarantee real-time consistency between requests.

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

### -Tag
The tags of the snapshot.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IAppConfigurationdataIdentity

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshot

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshot

## NOTES

## RELATED LINKS

