---
external help file:
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationrevision
schema: 2.0.0
---

# Get-AzAppConfigurationRevision

## SYNOPSIS
Gets a list of key-value revisions.

## SYNTAX

```
Get-AzAppConfigurationRevision -Endpoint <String> [-After <String>] [-Key <String>] [-Label <String>]
 [-Select <List<String>>] [-AcceptDatetime <String>] [-SyncToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a list of key-value revisions.

## EXAMPLES

### Example 1: List the revision of all the key-values in an App Configuration store
```powershell
Get-AzAppConfigurationRevision -Endpoint $endpoint
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            VYZXW_mkOPtFCaCR1Yo1UPXrU-4eBSj2zSzIdnOfCiU keyName2 label 7/21/2023 02:37:01 False            value2
            8btgGKjTObZloa_EsIB-WHozAI4-laTWdc-nr2IGAQ0 keyName4 label 7/21/2023 02:36:18 False            value4
            6tRurLbnyEBDKT7ynXV4F3mZpfA2hf_5z58cK2LDsHY keyName3       7/21/2023 02:22:55 False            value3
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2       7/21/2023 02:22:50 False            value2
            7VYSVQjjNgQ987zh8bjsXeDqgdAUkspRblp6Ceh-Zb0 keyName1       7/21/2023 02:22:45 False            value1
```

List the revision of all the key-values in an App Configuration store

### Example 2: List the revision of a key-value in an App Configuration store
```powershell
Get-AzAppConfigurationRevision -Endpoint $endpoint -Key keyName2
```

```output
ContentType Etag                                        Key      Label LastModified       Locked SyncToken Value
----------- ----                                        ---      ----- ------------       ------ --------- -----
            VYZXW_mkOPtFCaCR1Yo1UPXrU-4eBSj2zSzIdnOfCiU keyName2 label 7/21/2023 02:37:01 False            value2
            EAy26mDBHMBrUohZn-uJhNTTxoeKiMRin9h1OpfGpZc keyName2       7/21/2023 02:22:50 False            value2
```

List the revision of a key-value in an App Configuration store

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

### -Key
A filter used to match keys.

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

### -Label
A filter used to match labels

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

### -Select
Used to select what fields are present in the returned resource(s).

```yaml
Type: System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValue

## NOTES

## RELATED LINKS

