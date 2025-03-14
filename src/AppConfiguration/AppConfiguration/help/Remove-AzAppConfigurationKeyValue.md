---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/remove-azappconfigurationkeyvalue
schema: 2.0.0
---

# Remove-AzAppConfigurationKeyValue

## SYNOPSIS
Deletes a key-value.

## SYNTAX

### Delete (Default)
```
Remove-AzAppConfigurationKeyValue -Endpoint <String> -Key <String> [-Label <String>] [-IfMatch <String>]
 [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzAppConfigurationKeyValue -Endpoint <String> -InputObject <IAppConfigurationdataIdentity>
 [-Label <String>] [-IfMatch <String>] [-SyncToken <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes a key-value.

## EXAMPLES

### Example 1: Remove a key-value in an App Configuration store
```powershell
Remove-AzAppConfigurationKeyValue -Endpoint $endpoint -Key keyName1
```

```output
ContentType  :
Etag         : jXrYtz3qx3qEP0icqPfFWmD24a6qvOnR5LO08NseiR0
Key          : keyName1
Label        :
LastModified : 7/21/2023 02:49:20
Locked       : True
SyncToken    : xxxxxx
Tag          : {
               }
Value        : value1
```

Remove a key-value in an App Configuration store

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IAppConfigurationdataIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Key
The key of the key-value to delete.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
The label of the key-value to delete.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValue

## NOTES

## RELATED LINKS
