### Example 1: Gets the status and operation id of the email send operation.
```powershell
Get-AzCommunicationServicesEmailSendResult -Endpoint "https://contoso.unitedstates.communications.azure.com" -OperationId 8540c0de-899f-5cce-acb5-3ec493af3800
```

```output
AdditionalInfo    :
Code              :
Detail            :
Id                : 8540c0de-899f-5cce-acb5-3ec493af3800
Message           :
ResourceGroupName :
RetryAfter        :
Status            : Succeeded
Target            : 
```

Returns a status and operation id of the email send operation.

