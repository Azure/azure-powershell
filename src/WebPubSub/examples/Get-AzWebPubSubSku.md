### Example 1: List all available SKUs of a Web PubSub resource
```powershell
PS C:\>  Get-AzWebPubSubSku -ResourceGroupName psdemo -ResourceName psdemo-wps | Format-List

CapacityAllowedValue : {0, 1}
CapacityDefault      : 1
CapacityMaximum      : 1
CapacityMinimum      : 0
CapacityScaleType    : Manual
Family               :
Name                 : Free_F1
ResourceType         : Microsoft.SignalRService/WebPubSub
Size                 :
SkuCapacity          :
Tier                 : Free

CapacityAllowedValue : {0, 1, 2, 5…}
CapacityDefault      : 1
CapacityMaximum      : 100
CapacityMinimum      : 0
CapacityScaleType    : Automatic
Family               :
Name                 : Standard_S1
ResourceType         : Microsoft.SignalRService/WebPubSub
Size                 :
SkuCapacity          :
Tier                 : Standard
```

The example lists the SKUs of a Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result. We can see from the result that there are two SKUs, one's Tier is "Free", and the other is "Standard".



