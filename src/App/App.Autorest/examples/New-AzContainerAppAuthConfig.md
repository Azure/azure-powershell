### Example 1: Create the AuthConfig for a Container App.
```powershell
$identity = New-AzContainerAppIdentityProviderObject -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName redis-config

New-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app -PlatformEnabled -GlobalValidationUnauthenticatedClientAction 'AllowAnonymous' -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.