### Example 1: Get a Windows Virtual Desktop Registration Token	
```powershell	
PS C:\> Get-AzWvdRegistrationInfo -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName	
ExpirationTime       RegistrationTokenOperation Token	
--------------       -------------------------- -----	
4/1/2020 10:19:33 PM None                       eyJhbGciOiJSUzI1NiIsImtpZCI6IkMyRjU1RUYxNzg0MEFCNzkzMDk2RUYzRjdEMkNBRDk0NThGNDhEOTQiLCJ0eXAiOiJKV1QifQ.eyJSZWdpc3RyYXRpb25JZCI6IjU5NGJjZWUwLTk5MjQtNDg3ZC1iOW...	
```

This command gets a Windows Virtual Desktop Registration Token in a Host Pool.

