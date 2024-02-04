### Example 1: Create ServiceForestTrust for ADDomain
```powershell
New-AzADDomainServiceForestTrustObject -FriendlyName FriendlyNameTest
```

```output
FriendlyName     RemoteDnsIP TrustDirection TrustPassword TrustedDomainFqdn
------------     ----------- -------------- ------------- -----------------
FriendlyNameTest
```

Create an in-memory object for ForestTrust. This object can be used to create or update a domain service.
