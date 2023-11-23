### Example 1: Create an in-memory object for ConfigurationServiceGitRepository
```powershell
New-AzSpringCloudConfigurationServiceGitRepositoryObject -Name fake -Label master -Uri "https://github.com/fake-user/fake-repository" -Pattern "app/dev" -debug
```

```output
HostKey HostKeyAlgorithm Label  Name Password Pattern   PrivateKey SearchPath StrictHostKeyChecking Uri
------- ---------------- -----  ---- -------- -------   ---------- ---------- --------------------- ---
                         master fake          {app/dev}                                             https://github.com…
```

Create an in-memory object for ConfigurationServiceGitRepository.

