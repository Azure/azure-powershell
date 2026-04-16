---
external help file:
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationsnapshot
schema: 2.0.0
---

# Get-AzAppConfigurationSnapshot

## SYNOPSIS
Gets a single key-value snapshot or lists key-value snapshots.

## SYNTAX

### List (Default)
```
Get-AzAppConfigurationSnapshot -Endpoint <String> [-Name <String>] [-After <String>] [-Select <List<String>>]
 [-Status <List<String>>] [-SyncToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-Select <List<String>>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a single key-value snapshot by name, or lists key-value snapshots with optional filtering.

## EXAMPLES

### Example 1: List all snapshots in an App Configuration store
```powershell
Get-AzAppConfigurationSnapshot -Endpoint $endpoint
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

List all key-value snapshots in an App Configuration store.

### Example 2: Get a specific snapshot by name
```powershell
Get-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot"
```

```output
Name       Status CompositionType Created               Expires RetentionPeriod Size ItemsCount Etag
----       ------ --------------- -------               ------- --------------- ---- ---------- ----
mySnapshot ready  key             7/21/2023 02:40:00                 3600        1024 5          abcdef
```

Get a single key-value snapshot by name from an App Configuration store.

## PARAMETERS

### -After
Instructs the server to return elements that appear after the element referred to by the specified token.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientRequestId
An opaque, globally-unique, client-generated string identifier for the request.

```yaml
Type: System.String
Parameter Sets: Get
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

### -IfMatch
Used to perform an operation only if the targeted resource's etag matches the value provided.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
Used to perform an operation only if the targeted resource's etag does not match the value provided.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the snapshot.
When used with the Get parameter set, retrieves a single snapshot by exact name.
When used with the List parameter set, filters the returned snapshots by name.

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

### -Select
Used to select what fields are present in the returned resource(s).

```yaml
Type: System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Used to filter returned snapshots by their status property.

```yaml
Type: System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: List
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ISnapshot

## NOTES

## RELATED LINKS

