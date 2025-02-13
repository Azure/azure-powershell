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
After the above steps, you can continue developing on {your branch}, and the target branch for your new PR should be Azure/main.

## If your PR contains changes for autogen modules only
```powershell
git remote add Azure https://github.com/Azure/azure-powershell.git
git checkout {your branch}
git fetch Azure legacy-gen-2025-02-13
git merge Azure/legacy-gen-2025-02-14
# resolve possible conflict
git merge --continue

cp src/ModuleRootName/xxx.Autorest {backup of the current .Autorest folder you are developing}

git fetch Azure main
git checkout -b {new feature branch} Azure/main
rm -r src/ModuleRootName/xxx.Autorest
cp {backup of the current .Autorest folder you are developing} src/ModuleRootName
cd src/ModuleRootName/xxx.Autorest

autorest
./build-modules.ps1
cd ..
git add .
git commit -m "commit message"
git push origin head
```
after the above steps, you can continue developing on {new feature branch}, and the target branch for your new PR should be Azure/main.