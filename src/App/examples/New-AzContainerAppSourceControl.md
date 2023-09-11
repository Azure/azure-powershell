### Example 1: Create the SourceControl for a Container App.
```powershell
$AzureCredentialsClientSecret = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$RegistryInfoRegistryPassword = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$GithubActionConfigurationGithubPersonalAccessToken = ConvertTo-SecureString -String "1234" -Force -AsPlainText

New-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -AzureCredentialsClientId "UserObjectId" -AzureCredentialsClientSecret $AzureCredentialsClientSecret -AzureCredentialsKind "feaderated" -AzureCredentialsTenantId "UserDirectoryID" -Branch "main" -GithubActionConfigurationContextPath "./" -GithubActionConfigurationGithubPersonalAccessToken $GithubActionConfigurationGithubPersonalAccessToken -GithubActionConfigurationImage "azps-containerapp-1" -RegistryInfoRegistryPassword $RegistryInfoRegistryPassword -RegistryInfoRegistryUrl "azpscontainerregistry.azurecr.io" -RegistryInfoRegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
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