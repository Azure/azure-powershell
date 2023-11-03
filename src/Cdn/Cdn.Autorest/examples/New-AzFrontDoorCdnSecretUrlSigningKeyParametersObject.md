### Example 1: Create an in-memory object for UrlSigningKeyParameters
```powershell
New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject -KeyId keyId01 -Type Byoc -SecretVersion v1.0
```

```output
KeyId   SecretVersion
-----   -------------
keyId01 v1.0
```

Create an in-memory object for UrlSigningKeyParameters.
