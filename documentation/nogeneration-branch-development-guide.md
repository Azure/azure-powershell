# Guidance for generated AzPS module development on main branch
Readers of this article are expected to be developers with prior experience in creating generated AzPS modules in the generation branch. As the generation branch has now been retired, there will be some adjustments to the process of developing a generated module. Kindly review the following instructions before commencing development. 

## Branch
Development for generated modules is now on main branch, please ensure your local branch is synced with latest main.
```
git remote add Azure https://github.com/Azure/azure-powershell.git
git fetch Azure main
git checkout -b {module-name}/{branch-name} Azure/main
```

## Code Changes
````
- ModuleRootName
  - ParentModule
  - SubModule.Autorest
  - ModuleRoot.sln
````
You might have noticed that files under `SubModule.Autorest` are almost identical as they used to be in generation branch. Code changes are also identical as what you used to do in generation branch.
However, 