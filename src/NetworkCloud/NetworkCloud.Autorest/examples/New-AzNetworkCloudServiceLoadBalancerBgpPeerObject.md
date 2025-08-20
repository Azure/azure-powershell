### Example 1: Create an in-memory object for ServiceLoadBalancerBgpPeer.
```powershell
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name name -PeerAddress "203.0.113.254" -PeerAsn "64497" -BfdEnabled False -BgpMultiHop False -HoldTime "P300s" -KeepAliveTime "P300s" -MyAsn 64512 -Password REDACTED -PeerPort 1234
```

```output
BfdEnabled BgpMultiHop HoldTime KeepAliveTime MyAsn Name Password  PeerAddress   PeerAsn PeerPort
---------- ----------- -------- ------------- ----- ---- --------  -----------   ------- --------
False      False       P300s    P300s         64512 name REDACTED 203.0.113.254 64497   1234
```

Create an in-memory object for ServiceLoadBalancerBgpPeer.
