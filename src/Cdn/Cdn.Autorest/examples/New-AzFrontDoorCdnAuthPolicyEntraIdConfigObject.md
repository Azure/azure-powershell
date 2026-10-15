### Example 1: Create a Microsoft Entra ID authentication configuration
```powershell
New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Issuer "https://login.microsoftonline.com/00000000-0000-0000-0000-000000000001/v2.0" -Audience "api://myApplication" -AuthLocation Header -AuthLocationSelector "Authorization"
```

Creates an in-memory Microsoft Entra ID authentication configuration that reads a token from the Authorization header. Replace the example issuer and audience with your identity provider values. Pass the object to an authentication policy create or update command; this command does not create or update an Azure resource.
