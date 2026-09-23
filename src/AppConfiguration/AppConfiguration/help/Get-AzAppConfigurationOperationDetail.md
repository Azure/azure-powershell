---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationoperationdetail
schema: 2.0.0
---

# Get-AzAppConfigurationOperationDetail

## SYNOPSIS
Gets the state of a long running operation.

## SYNTAX

```
Get-AzAppConfigurationOperationDetail -Endpoint <String> -Snapshot <String> [-ClientRequestId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the state of a long running operation.

## EXAMPLES

### Example 1: Get the status of a snapshot creation operation
```powershell
Get-AzAppConfigurationOperationDetail -Endpoint $endpoint -Snapshot "mySnapshot"
```

```output
Id     : xxxx
Status : Succeeded
```

Get the state of a long running operation for a snapshot creation.

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

### -Snapshot
Snapshot identifier for the long running operation.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IOperationDetails

## NOTES

## RELATED LINKS
