### Example 1: Create an in-memory object for GitPatternRepository
```powershell
New-AzSpringCloudGitPatternRepositoryObject -Name fake -Uri "https://github.com/fake-user/fake-repository"
```

```output
HostKey HostKeyAlgorithm Label Name Password Pattern PrivateKey SearchPath StrictHostKeyChecking Uri
------- ---------------- ----- ---- -------- ------- ---------- ---------- --------------------- ---
                               fake                                                              https://github.com/fa…
```

Create an in-memory object for GitPatternRepository.
