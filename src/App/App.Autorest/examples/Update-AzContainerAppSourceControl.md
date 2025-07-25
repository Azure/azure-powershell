### Example 1: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "****" -AsPlainText -Force
$RegistryPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$GithubAccessToken = ConvertTo-SecureString -String "****" -AsPlainText -Force

Update-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.

### Example 2: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "****" -AsPlainText -Force
$RegistryPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$GithubAccessToken = ConvertTo-SecureString -String "****" -AsPlainText -Force
$sourcecontrol = Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current

Update-AzContainerAppSourceControl -InputObject $sourcecontrol -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.

### Example 3: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "****" -AsPlainText -Force
$RegistryPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$GithubAccessToken = ConvertTo-SecureString -String "****" -AsPlainText -Force
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1

Update-AzContainerAppSourceControl -ContainerAppInputObject $containerapp -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.