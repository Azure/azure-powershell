---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/test-azappconfigurationkeyvalue
schema: 2.0.0
---

# Test-AzAppConfigurationKeyValue

## SYNOPSIS
Requests the headers and status of the given resource.

## SYNTAX

### Check (Default)
```
Test-AzAppConfigurationKeyValue -Endpoint <String> -Key <String> [-Label <String>]
 [-Select <System.Collections.Generic.List`1[System.String]>] [-AcceptDatetime <String>] [-IfMatch <String>]
 [-IfNoneMatch <String>] [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzAppConfigurationKeyValue -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 [-Label <String>] [-Select <System.Collections.Generic.List`1[System.String]>] [-AcceptDatetime <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Requests the headers and status of the given resource.

## EXAMPLES

### Example 1: Test a key-value in an App Configuration store
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName1
```

Test a key-value in an App Configuration store

### Example 2: Test a key-value in an App Configuration store with wildcard
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName*
```

Test a key-value in an App Configuration store with wildcard

### Example 3: Test a key-value in an App Configuration store
```powershell
Test-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName5
```

```output
Test-AzAppConfigurationKeyValue_Check: The server responded with a Request Error, Status: NotFound
```

If the key-value does not exist, the cmdlet will throw an error.

## PARAMETERS

### -AcceptDatetime
Requests the server to respond with the state of the resource at the specified time.

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
Used to perform an operation only if the targeted resource's etag matches the value provided.

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
Used to perform an operation only if the targeted resource's etag does not match the value provided.

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
Parameter Sets: CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Key
The key of the key-value to retrieve.

```yaml
Type: System.String
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
The label of the key-value to retrieve.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
Used to select what fields are present in the returned resource(s).

```yaml
Type: System.Collections.Generic.List`1[System.String]
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
