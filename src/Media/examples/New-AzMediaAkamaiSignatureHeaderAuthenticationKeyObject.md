### Example 1: Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.
```powershell
New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject -Base64Key "dGVzdGlkMQ==" -Expiration "2029-12-31T16:00:00-08:00" -Identifier "id1"
```

```output
Base64Key    Expiration             Identifier
---------    ----------             ----------
dGVzdGlkMQ== 2030-01-01 08:00:00 AM id1
```

Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.