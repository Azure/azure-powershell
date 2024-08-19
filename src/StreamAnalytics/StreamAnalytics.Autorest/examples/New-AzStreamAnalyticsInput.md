### Example 1: Create a job input with a definition from a file
```powershell
New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\EventHub.json
```
```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file EventHub.json.

(below is an example for "EventHub.json")
{
  "properties": {
    "type": "Stream",
    "serialization": {
      "type": "Json",
      "properties": {
        "encoding": "UTF8"
      }
    },
    "compression": {
      "type": "None"
    },
    "datasource": {
      "type": "Microsoft.EventHub/EventHub",
      "properties": {
        "serviceBusNamespace": "xxxxxxxxxxxxxx",
        "sharedAccessPolicyName": "xxxxxxxxxxxxxxxx",
        "sharedAccessPolicyKey": "xxxxxxxxxxxxxxxxxxxxxx",
        "authenticationMode": "ConnectionString",
        "eventHubName": "xxxxxxxxxxxxxxxx",
        "consumerGroupName": "xxxxxxxxxxxxxxxx"
      }
    }
  }
}

### Example 2: Create a job input with a definition from a file
```powershell
New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\IotHub.json
```
```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file IotHub.json.

(below is an example for "IotHub.json")
{
  "properties": {
    "type": "Stream",
    "serialization": {
      "type": "Json",
      "properties": {
        "encoding": "UTF8"
      }
    },
    "compression": {
      "type": "None"
    },
    "partitionKey": "",
    "datasource": {
      "type": "Microsoft.Devices/IotHubs",
      "properties": {
        "iotHubNamespace": "xxxxxxxxxxx",
        "sharedAccessPolicyName": "xxxxxxxxxxxxxx",
        "sharedAccessPolicyKey": "xxxxxxxxxxxxxxxxx",
        "consumerGroupName": "$Default",
        "endpoint": "messages/events"
      }
    }
  }
}