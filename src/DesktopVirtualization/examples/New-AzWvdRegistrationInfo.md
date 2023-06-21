### Example 1: Create a Registration Info for a HostPool
```powershell
New-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolName hpName -ExpirationTime "2050-02-14 12:00"
```

```output
ExpirationTime         RegistrationTokenOperation Token
--------------         -------------------------- -----
02/14/2050 12:00:00 PM Update                     <base64 encoded string>
```

Creates a new Registration Info object for the selected HostPool