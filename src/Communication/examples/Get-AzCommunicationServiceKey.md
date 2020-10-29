### Example 1: Fetch the Key for the specified Communcation service

```powershell
PS C:\> Get-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1

PrimaryConnectionString                                                                                                                                     PrimaryKey
-----------------------                                                                                                                                     ----------
endpoint=https://contosoacsresource1.communication.azure.com/;accesskey=s+UXFUc4/t5BvFJbb3TKRa+XX1jRXRAWrTQkejPubvRcHTcQSF6OT99Nd7UfCwRGFw0EO1oXgr+0YP1dIxa2YQ== s+UXFUc4/t5BvFJbb3TKRa+XX1jRXRAWrTQkejPubvRcHTcQSF6OT99Nd7UfCwRGFw0EO1oXgr+0YP1dIxa2YQ==
```

Displays the ConnectionString and Key for the specified Communcation service.
