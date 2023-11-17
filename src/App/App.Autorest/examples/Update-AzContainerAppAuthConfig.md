### Example 1: Create the AuthConfig for a Container App.
```powershell
Update-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.

### Example 2: Create the AuthConfig for a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-2

Update-AzContainerAppAuthConfig -Name current -ContainerAppInputObject $containerapp -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.

### Example 3: Create the AuthConfig for a Container App.
```powershell
$authconfig = Get-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app

Update-AzContainerAppAuthConfig -InputObject $authconfig -PlatformEnabled -GlobalValidationUnauthenticatedClientAction RedirectToLoginPage -IdentityProvider $identity
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Create the AuthConfig for a Container App.