<!-- region Generated -->
# Az.{moduleName}
This directory contains the PowerShell module for the {moduleName} service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.{moduleName}`, see [how-to.md](how-to.md).
<!-- endregion -->

---
### AutoRest Configuration 
> see https://aka.ms/autorest 

```yaml 

commit: {commitId}

require: 
  - $(this-folder)/../../readme.azure.noprofile.md 
  - $(repo)/specification/{serviceSpecs}/readme.md 

try-require:  
  - $(repo)/specification/{serviceSpecs}/readme.powershell.md 

input-file:
  - $(repo)/{swaggerFileSpecs}

module-version: 0.1.0 

title: {moduleName}
service-name: {moduleName}
subject-prefix: $(service-name) 

directive: 

  - where: 
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString)) 
    remove: true 

  - where: 
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$ 
    remove: true 

  - where: 
      verb: Set 
    remove: true 
```
