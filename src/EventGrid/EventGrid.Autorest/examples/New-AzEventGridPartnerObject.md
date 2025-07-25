### Example 1: Create an in-memory object for Partner.
```powershell
New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -Name "Auth0" -RegistrationImmutableId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
```

```output
AuthorizationExpirationTimeInUtc Name  RegistrationImmutableId
-------------------------------- ----  -----------------------
2023-11-19 下午 05:31:42         Auth0 804a11ca-ce9b-4158-8e94-3c8dc7a072ec
```

Create an in-memory object for Partner.