---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationkey
schema: 2.0.0
---

# Get-AzAppConfigurationKey

## SYNOPSIS
Gets a list of keys.

## SYNTAX

```
Get-AzAppConfigurationKey -Endpoint <String> [-After <String>] [-Name <String>] [-AcceptDatetime <String>]
 [-SyncToken <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of keys.

## EXAMPLES

### Example 1: List all the keys in an App Configuration store
```powershell
Get-AzAppConfigurationKey -Endpoint $endpoint
```

```output
Name
----
keyName1
keyName2
keyName3
```

List all the keys in an App Configuration store

### Example 2: Get key list in an App Configuration store with wildcard
```powershell
Get-AzAppConfigurationKey -Endpoint $endpoint -Name key*
```

```output
Name
----
keyName1
keyName2
keyName3
```

Get key list in an App Configuration store with wildcard

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

### -After
Instructs the server to return elements that appear after the element referred to by the specified token.

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

### -Name
A filter for the name of the returned keys.

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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKey

## NOTES

## RELATED LINKS
