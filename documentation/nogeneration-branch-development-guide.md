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
Modules under /src should look like
````
- ModuleRootName
  - ParentModule
  - SubModule.Autorest
  - ModuleRoot.sln
````
The directory you will work on is `SubModule.Autorest`

## Code Changes
You might have noticed that files under `SubModule.Autorest` are almost identical as they used to be in generation branch. Code changes are also identical as what you used to do in generation branch.

## Commit and Pull Request
 **Note: Besides changes under `SubModule.Autorest`, there are something more under `ParentModule` and possibly `ModuleRoot.sln`.**

 After Successfully executed `Build-Module.ps1`. Updated syntax and cmdlets from
 ```
SubModule.Autorest/docs
SubModule.Autorest/Az.SubModule.psd1
 ```
 will be synced to 
 ```
ParentModule/help
ParentModule/Az.ModuleRoot.psd1
 ```
 and if you are adding a new submodule, this new module will also be added in
 ```
ModuleRoot.sln
 ```
 Please be sure to use `git add` to commit these changes in your pull request.

 ## Test the entire module
This used to be impossible on generation branch when you working on submodule part of a hybrid module. Now you can do
```
/tools/BuildScripts/BuildModules.ps1 -TargetModule ${ModuleRootName}
Import-Module artifacts/Debug/Az.${ModuleRootName}/Az.${ModuleRootName}.psd1
```
the submodule along with handwritten part will be both imported for local tests.