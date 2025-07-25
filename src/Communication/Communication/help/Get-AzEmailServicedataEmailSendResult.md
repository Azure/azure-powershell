---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azemailservicedataemailsendresult
schema: 2.0.0
---

# Get-AzEmailServicedataEmailSendResult

## SYNOPSIS
Gets the status of the email send operation.

## SYNTAX

### Get (Default)
```
Get-AzEmailServicedataEmailSendResult -Endpoint <String> -OperationId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEmailServicedataEmailSendResult -Endpoint <String> -InputObject <IEmailServicedataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the status of the email send operation.

## EXAMPLES

### Example 1: Gets the status and operation id of the email send operation.
```powershell
Get-AzEmailServicedataEmailSendResult -Endpoint "https://contoso.unitedstates.communication.azure.com" -OperationId 1111c0de-899f-5cce-acb5-3ec493af3800
```

```output
AdditionalInfo    :
Code              :
Detail            :
Id                : 1111c0de-899f-5cce-acb5-3ec493af3800
Message           :
ResourceGroupName :
RetryAfter        :
Status            : Succeeded
Target            :
```

Returns a status and operation id of the email send operation.

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
The communication resource, for example `https://my-resource.communication.azure.com`

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailServicedataIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
ID of the long running operation (GUID) returned from a previous call to send email

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailServicedataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailSendResult

## NOTES

## RELATED LINKS
