### Example 1: Get specific certificate with specified catalog
```powershell
Get-AzSphereCertificate -CatalogName "MyCEVtest" -ResourceGroupName "glumenCEVRG"
```

```output
ExpiryUtc                    : 5/15/2025 2:55:00 PM
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/glumenCEVRG/providers/Microsoft.AzureSphere/catalogs/MyCEVtest/certificates/11D6501213A2B3987929F7909769F7B5
Name                         : 11D6501213A2B3987929F7909769F7B5
NotBeforeUtc                 : 5/16/2023 2:55:00 PM
PropertiesCertificate        : MIIDCzCCApGgAwIBAgIQEdZQEhOis5h5KfeQl2n3tTAKBggqhkjOPQQDAzBTMQswCQYDVQQGEwJVUzEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSQwIgYDVQQDExtBenVyZSBTcGhlcmUgUG9saWN5IENBIDIwMjIwHhcNMjM
                               wNTE2MTQ1NTAwWhcNMjUwNTE1MTQ1NTAwWjCBmjELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjFEMEIGA1UEAxM7TWljcm9zb2Z0IE
                               F6dXJlIFNwaGVyZSBiZTUxMDU3ZS1lNmViLTQ4N2QtODJjOC1hNzA0M2NjYWI5ZTEwdjAQBgcqhkjOPQIBBgUrgQQAIgNiAATrPradtPvdN46uvvSatOAWwuE7wdOGYTxtyWcG8+wEmDJjUhIYqFAfaEGA9SnPFZNJwJAqJvnaQ/XhzIiFL
                               8GvUDBiggAlJVLjYThPkC5Jc7kpOOFcpx8aRcSSaRsydIWjgeEwgd4wDgYDVR0PAQH/BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wUgYDVR0fBEswSTBHoEWgQ4ZBaHR0cDovL2NybC5zcGhlcmUuYXp1cmUubmV0L01pY3Jvc29mdCBBenVy
                               ZSBTcGhlcmUgUG9saWN5MjAyMi5jcmwwZwYIKwYBBQUHAQEEWzBZMFcGCCsGAQUFBzAChktodHRwOi8vcGtpLnNwaGVyZS5henVyZS5uZXQvY2VydGlmaWNhdGVzL01pY3Jvc29mdEF6dXJlU3BoZXJlUG9saWN5MjAyMi5jZXIwCgYIKoZ
                               Izj0EAwMDaAAwZQIxALyiEKIYmCCDIjHVvjoNBeAz14DiTBWR3AWYePPG3oShXL/Je/yT8yOrimtRnrGnpAIwO07WVeqEeqRtyPbmJefdRtJ8/SF89z+wu1Y/CPO0ldDXavoLRQQyQq5yih6N9Cjl
ProvisioningState            : Succeeded
ResourceGroupName            : glumenCEVRG
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere be51057e-e6eb-487d-82c8-a7043ccab9e1, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : BFF18CC17D19D7E3B7884091981E0190F8E84181
Type                         : Microsoft.AzureSphere/catalogs/certificatesExpiryUtc                    : 5/15/2025 2:55:00 PM
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/glumenCEVRG/providers/Microsoft.AzureSphere/catalogs/MyCEVtest/certificates/11D6501213A2B3987929F7909769F7B5
Name                         : 11D6501213A2B3987929F7909769F7B5
NotBeforeUtc                 : 5/16/2023 2:55:00 PM
PropertiesCertificate        : MIIDCzCCApGgAwIBAgIQEdZQEhOis5h5KfeQl2n3tTAKBggqhkjOPQQDAzBTMQswCQYDVQQGEwJVUzEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSQwIgYDVQQDExtBenVyZSBTcGhlcmUgUG9saWN5IENBIDIwMjIwHhcNMjM
                               wNTE2MTQ1NTAwWhcNMjUwNTE1MTQ1NTAwWjCBmjELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjFEMEIGA1UEAxM7TWljcm9zb2Z0IE
                               F6dXJlIFNwaGVyZSBiZTUxMDU3ZS1lNmViLTQ4N2QtODJjOC1hNzA0M2NjYWI5ZTEwdjAQBgcqhkjOPQIBBgUrgQQAIgNiAATrPradtPvdN46uvvSatOAWwuE7wdOGYTxtyWcG8+wEmDJjUhIYqFAfaEGA9SnPFZNJwJAqJvnaQ/XhzIiFL
                               8GvUDBiggAlJVLjYThPkC5Jc7kpOOFcpx8aRcSSaRsydIWjgeEwgd4wDgYDVR0PAQH/BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wUgYDVR0fBEswSTBHoEWgQ4ZBaHR0cDovL2NybC5zcGhlcmUuYXp1cmUubmV0L01pY3Jvc29mdCBBenVy
                               ZSBTcGhlcmUgUG9saWN5MjAyMi5jcmwwZwYIKwYBBQUHAQEEWzBZMFcGCCsGAQUFBzAChktodHRwOi8vcGtpLnNwaGVyZS5henVyZS5uZXQvY2VydGlmaWNhdGVzL01pY3Jvc29mdEF6dXJlU3BoZXJlUG9saWN5MjAyMi5jZXIwCgYIKoZ
                               Izj0EAwMDaAAwZQIxALyiEKIYmCCDIjHVvjoNBeAz14DiTBWR3AWYePPG3oShXL/Je/yT8yOrimtRnrGnpAIwO07WVeqEeqRtyPbmJefdRtJ8/SF89z+wu1Y/CPO0ldDXavoLRQQyQq5yih6N9Cjl
ProvisioningState            : Succeeded
ResourceGroupName            : glumenCEVRG
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere be51057e-e6eb-487d-82c8-a7043ccab9e1, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : BFF18CC17D19D7E3B7884091981E0190F8E84181
Type                         : Microsoft.AzureSphere/catalogs/certificates
```

This command get specific certificate with specified catalog.