### Example 1: Initialize a bring-your-own-root policy
```powershell
Initialize-AzDeviceRegistryPolicyBringYourOwnRoot -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -PolicyName "my-policy" -CertificateChain "-----BEGIN CERTIFICATE-----...-----END CERTIFICATE-----"
```

Initializes or renews a bring-your-own-root (BYOR) policy with a signed certificate chain for the specified Device Registry namespace.

{{ Add description here }}

