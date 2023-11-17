### Example 1: Continue Troubleshooter to next step
```powershell
$continueRequest = [ordered]@{ 
    "StepId" ="15ebac6c-96a1-4a67-ae9d-b06011d232ff" 
} 

Invoke-AzSelfHelpContinueTroubleshooter  -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"  -TroubleshooterName  "02d59989-f8a9-4b69-9919-1ef51df4eff6" -ContinueRequestBody $continueRequest 
```

```output
[No Response Body If Success - HttpStatus Code 204]
```

If continue is success, you will see no response. If continue is not success, you will see the error message. You can see the status of the troubleshooter step by using `Get-AzSelfHelpTroubleshooter` cmdlet.
