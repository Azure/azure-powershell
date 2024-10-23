### Example 1: Create the SourceControl for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "****" -AsPlainText -Force
$RegistryPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$GithubAccessToken = ConvertTo-SecureString -String "****" -AsPlainText -Force

New-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Create the SourceControl for a Container App.
User need to create a base resource of resource type "ContainerRegistry" and set AccessKeys to Enabled.
User needs to provide the ObjectId(AzureCredentialsClientId) and password of the current account.
User needs to provide the DirectoryID(AzureCredentialsTenantId) of the current account.