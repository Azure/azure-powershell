# Guidance for generated AzPS module development on main branch
Readers of this article are expected to be developers with prior experience in creating generated AzPS modules in the generation branch. As the generation branch has now been retired, there will be some adjustments to the process of developing a generated module. Kindly review the following instructions before commencing development. 

## Branch
Development for generated modules is now on main branch, please ensure your local branch is synced with latest main.
```
git remote add Azure https://github.com/Azure/azure-powershell.git
git fetch Azure main
git checkout -b {module-name}/{branch-name} Azure/main
```

## Folder structure
Generally speaking modules under /src should look like
````
- ModuleRootName
  - ParentModule
  - SubModule1.Autorest
  - SubModule2.Autorest
    ...
  - ModuleRoot.sln
````
The directory you will work on is `src/ModuleRootName/SubModule.Autorest`

## Code Changes
You might have noticed that files under `SubModule.Autorest` are almost identical as they used to be in generation branch. Code changes are also identical as what you used to do in generation branch.

**Note: Please include release notes along with your code changes in `/src/ModuleRootName/ParentModule/Changelog.md`**

## Commit and Pull Request
**Note: Please double check file `generate-info.json` under `SubModule.Autorest` was updated each time `build-module.ps1` was executed, please be sure to include this change in your PR, PR validation won't pass otherwise**

**Note: Besides changes under `SubModule.Autorest`, there are something more under `ParentModule` and possibly `ModuleRoot.sln`.**

 After Successfully executed `Build-Module.ps1`. Updated syntax and cmdlets from
```
/src/ModuleRootName/SubModule.Autorest/docs
/src/ModuleRootName/SubModule.Autorest/Az.SubModule.psd1
```
will be synced to 
```
/src/ModuleRootName/ParentModule/help
/src/ModuleRootName/ParentModule/Az.ModuleRoot.psd1
```
and if you are adding a new submodule, this new module will also be added in
```
/src/ModuleRootName/ModuleRoot.sln
/src/ModuleRootName/ParentModule/Az.ModuleRoot.psd1
```
Besides, if the module is completely new, these below item will also be created
```
/src/ModuleRootName/ParentModule/Changelog.md
/src/ModuleRootName/ParentModule/ParentModule.csproj
/src/ModuleRootName/ParentModule/Properties/AssemblyInfo.cs
```
Please be sure to commit these changes in your pull request.
```
cd ${azure-powershell}/src/ModuleRootName
git add .
git commit -m "$commitMessage"
git push origin head
```

## Test the entire module
This used to be impossible on generation branch when you working on submodule part of a hybrid module. Now you can do
```
cd ${azure-powershell}
./tools/BuildScripts/BuildModules.ps1 -TargetModule ${ModuleRootName}
Import-Module /artifacts/Debug/Az.${ModuleRootName}/Az.${ModuleRootName}.psd1
```
the submodule along with handwritten part will be both imported for local tests.

## Archive generated assets
**Note: This section is for Azure-PowerShell team internal**

Soon after a PR for generated submodule was merged, a PR with title: `[skip ci] Archive ${CommitId}` will be created automatically. It should contains file changes under `/generated/ModuleRootName/SubModule.Autorest`, please confirm `/generated/ModuleRootName/SubModule.Autorest/generate-info.json` was updated and is the same as `/src/ModuleRootName/SubModule.Autorest/generate-info.json`.