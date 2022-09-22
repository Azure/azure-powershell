### Example 1: Create a Windows Virtual Desktop Registration Token
```powershell
New-AzWvdRegistrationInfo -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -ExpirationTime $((Get-Date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ'))
```

```output
ExpirationTime       RegistrationTokenOperation Token
--------------       -------------------------- -----
4/1/2020 10:19:33 PM Update                       eyJhbGciOiJSUzI1NiIsImtpZCI6IkMyRjU1RUYxNzg0MEFCNzkzMDk2RUYzRjdEMkNBRDk0NThGNDhEOTQiLCJ0eXAiOiJKV1QifQ.eyJSZWdpc3RyYXRpb25JZCI6IjU5NGJjZWUwLTk5MjQtNDg3ZC1iOW...
```

This command creates a Windows Virtual Desktop Registration Token in a Host Pool.

