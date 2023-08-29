### Example 1: Create an in-memory object for NetworkAttachment.
```powershell
New-AzNetworkCloudNetworkAttachmentObject -AttachedNetworkId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3NetworkName" -IPAllocationMethod "Dynamic" -DefaultGateway "True" -Ipv4Address "198.51.100.1" -Ipv6Address "2001:0db8:0000:0000:0000:0000:0000:0001" -Name "netAttachName01"
```
```output
AttachedNetworkId                                                                                                        DefaultGateway IPAllocationMethod Ipv4Address  Ipv6Address
-----------------                                                                                                        -------------- ------------------ -----------  -----------                   
/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3NetworkName True           Dynamic            198.51.100.1 2001:0db8:0000:0000:0000:0000…

```

Create an in-memory object for NetworkAttachment.