### Example 1: Create a profile-level Microsoft Entra ID authentication policy
```powershell
$authConfig = New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Issuer "https://login.microsoftonline.com/00000000-0000-0000-0000-000000000001/v2.0" -Audience "api://myApplication" -AuthLocation Header -AuthLocationSelector "Authorization"
$association = New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel $true
New-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile" -Name "myAuthPolicy" -AuthConfig $authConfig -Association $association -Action Block -ForwardTokenToOrigin:$false
```

Creates an authentication policy that validates Microsoft Entra ID tokens for the profile and blocks requests that fail authentication. Replace the example issuer and audience with your identity provider values. Token forwarding defaults to true; this example explicitly disables it.
