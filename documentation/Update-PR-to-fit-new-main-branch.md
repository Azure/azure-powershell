# Guidance for existing PR to fit new main branch
Readers of this article are expected to be developers with PR opened before the main branch update recently which introduced new development process for autorest based modules.

## If your PR contains changes for handwritten modules only
```powershell
git remote add Azure https://github.com/Azure/azure-powershell.git
git checkout {your branch}
git fetch Azure legacy-main-2025-02-13
git merge Azure/legacy-main-2025-02-13
# resolve possible conflict
git merge --continue
git fetch Azure legacy-main-before-migrate
git cherry-pick {the one commit does the migration}
git push origin head
```

## If your PR contains changes for autogen modules only
```
git remote add Azure https://github.com/Azure/azure-powershell.git
git fetch Azure main
git checkout -b {new feature branch} Azure/main
```