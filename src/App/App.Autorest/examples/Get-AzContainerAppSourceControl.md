### Example 1: List SourceControl of a Container App.
```powershell
Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

List SourceControl of a Container App.

### Example 2: Get a SourceControl of a Container App by name.
```powershell
Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Get a SourceControl of a Container App by name.

### Example 3: Get a SourceControl of a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Get-AzContainerAppSourceControl -ContainerAppInputObject $containerapp -Name current
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Get a SourceControl of a Container App.