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

