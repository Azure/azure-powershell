### Example 1: Checks whether the resource name is available in the given region
```powershell
Test-AzVoiceServicesNameAvailability -Location eastus -Name 'VoiceServicesTestName' -Type "Microsoft.VoiceServices/CommunicationsGateways"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True          
```

This command checks whether the resource name is available in the given region.