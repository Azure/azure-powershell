### Example 1
```powershell
New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net"
```

```output
Address           : contoso1.azurewebsites.net
HttpPort          : 80
HttpsPort         : 443
Priority          : 1
Weight            : 50
BackendHostHeader :
EnabledState      : Enabled
```

Create a PSBackend object for Front Door creation