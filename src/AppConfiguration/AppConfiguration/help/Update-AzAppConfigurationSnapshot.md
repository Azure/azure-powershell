---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/update-azappconfigurationsnapshot
schema: 2.0.0
---

# Update-AzAppConfigurationSnapshot

## SYNOPSIS
Update the state of a key-value snapshot.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] [-Status <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] -Entity <ISnapshotUpdateParameters>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>]
 [-Status <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAppConfigurationSnapshot -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>]
 -Entity <ISnapshotUpdateParameters> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update the state of a key-value snapshot.

## EXAMPLES

### Example 1: Archive a snapshot
```powershell
Update-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Status "archived"
```

```output
Name       Status   CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------   --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot archived key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Archive a snapshot by updating its status to "archived".

### Example 2: Recover an archived snapshot
```powershell
Update-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -Status "ready"
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Recover an archived snapshot by updating its status back to "ready".

## PARAMETERS

### -ClientRequestId
An opaque, globally-unique, client-generated string identifier for the request.

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
Parameters used to update a snapshot.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshotUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IfMatch
Used to perform an operation only if the targeted resource's etag matches the
value provided.

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

### -IfNoneMatch
Used to perform an operation only if the targeted resource's etag does not
match the value provided.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IAppConfigurationdataIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the key-value snapshot to update.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The desired status of the snapshot.

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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshotUpdateParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshot

## NOTES

## RELATED LINKS
