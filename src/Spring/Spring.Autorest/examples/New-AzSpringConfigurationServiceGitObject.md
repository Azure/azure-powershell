### Example 1: Create an in-memory object for ConfigurationServiceGitRepository.
```powershell
New-AzSpringConfigurationServiceGitObject -Label "master" -Name "ghatest" -Pattern "app/dev" -Uri "https://github.com/lijinpei2008/ghatest"
```

```output
HostKey               :
HostKeyAlgorithm      :
Label                 : master
Name                  : ghatest
Password              :
Pattern               : {app/dev}
PrivateKey            :
SearchPath            :
StrictHostKeyChecking :
Uri                   : https://github.com/lijinpei2008/ghatest
Username              :
```

Create an in-memory object for ConfigurationServiceGitRepository.