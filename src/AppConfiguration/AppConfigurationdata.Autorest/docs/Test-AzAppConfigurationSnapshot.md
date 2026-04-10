---
external help file:
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/test-azappconfigurationsnapshot
schema: 2.0.0
---

# Test-AzAppConfigurationSnapshot

## SYNOPSIS
Requests the headers and status of the given resource.

## SYNTAX

### Check (Default)
```
Test-AzAppConfigurationSnapshot -Endpoint <String> [-After <String>] [-ClientRequestId <String>]
 [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### Check1
```
Test-AzAppConfigurationSnapshot -Endpoint <String> -Name <String> [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzAppConfigurationSnapshot -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Requests the headers and status of the given resource.

## EXAMPLES

### Example 1: Check if snapshots exist in an App Configuration store
```powershell
Test-AzAppConfigurationSnapshot -Endpoint $endpoint -PassThru
```

```output
True
```

Check whether any snapshots exist in the App Configuration store.
Returns True if snapshots are found.

### Example 2: Check if a specific snapshot exists
```powershell
Test-AzAppConfigurationSnapshot -Endpoint $endpoint -Name "mySnapshot" -PassThru
```

```output
True
```

Check whether a specific snapshot exists in the App Configuration store by name.

## PARAMETERS

### -After
Instructs the server to return elements that appear after the element referred
to by the specified token.

```yaml
Type: System.String
Parameter Sets: Check
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

### -IfMatch
Used to perform an operation only if the targeted resource's etag matches the
value provided.

```yaml
Type: System.String
Parameter Sets: Check1, CheckViaIdentity
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
Parameter Sets: Check1, CheckViaIdentity
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
Parameter Sets: CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the key-value snapshot to check.

```yaml
Type: System.String
Parameter Sets: Check1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IAppConfigurationdataIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

