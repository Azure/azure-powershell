### Example 1: Create an in-memory object for BgpAdvertisement.
```powershell
New-AzNetworkCloudBgpAdvertisementObject -IPAddressPool  @("pool1","pool2") -AdvertiseToFabric "True" -Community  @("communityString") -Peer @("peer1") 
```
```output
AdvertiseToFabric Community         IPAddressPool  Peer
----------------- ---------         -------------  ----
True              {communityString} {pool1, pool2} {peer1}
```

Create an in-memory object for BgpAdvertisement.
