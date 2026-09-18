### Example 1
```powershell
New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net"
```

```output
Address                    : contoso1.azurewebsites.net
BackendHostHeader          : contoso1.azurewebsites.net
EnabledState               : Enabled
HttpPort                   : 80
HttpsPort                  : 443
Priority                   : 1
PrivateEndpointStatus      :
PrivateLinkAlias           :
PrivateLinkApprovalMessage :
PrivateLinkLocation        :
PrivateLinkResourceId      :
Weight                     : 50
```

Create a PSBackend object for Front Door creation