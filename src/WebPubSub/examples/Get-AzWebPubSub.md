### Example 1: List all Web PubSub resources in a subscription
```powershell
PS C:\> Get-AzWebPubSub -SubscriptionId ef72249e-9785-4799-a76b-7cdd80e1b1d0

Location      Name                Type
--------      ----                ----
eastus        demo-live           Microsoft.SignalRService/WebPubSub
eastus        testcli             Microsoft.SignalRService/WebPubSub
southeastasia demo                Microsoft.SignalRService/WebPubSub
southeastasia livedemo            Microsoft.SignalRService/WebPubSub
westcentralus demo1               Microsoft.SignalRService/WebPubSub
```



### Example 2: List all Web PubSub resources in a resource group
```powershell
PS C:\> Get-AzWebPubSub -ResourceGroupName demo-rg

Location Name             Type
-------- ----             ----
eastus   demo-testWPS  Microsoft.SignalRService/WebPubSub
eastus   demo-testwps2 Microsoft.SignalRService/WebPubSub
```



### Example 3: Get a specific Web PubSub resource
```powershell
PS C:\> Get-AzWebPubSub -ResourceGroupName demo-rg -ResourceName demo-testWPS

Location Name            Type
-------- ----            ----
eastus   demo-testWPS Microsoft.SignalRService/WebPubSub
```



### Example 4: Get a specific Web PubSub resource via identity object
```powershell
PS C:\> Get-AzWebPubSub -ResourceGroupName demo-rg -ResourceName demo-testWPS

Location Name            Type
-------- ----            ----
eastus   demo-testWPS Microsoft.SignalRService/WebPubSub
```


