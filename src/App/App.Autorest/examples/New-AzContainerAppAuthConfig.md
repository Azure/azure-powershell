### Example 1: Create or update the AuthConfig for a Container App.
```powershell
$identity = New-AzContainerAppIdentityProviderObject -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName facebook-secret

New-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -PlatformEnabled -GlobalValidationUnauthenticatedClientAction 'AllowAnonymous' -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azpstest_gp
```

Create or update the AuthConfig for a Container App.