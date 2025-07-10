<!-- region Generated -->
# Az.MongoDB
This directory contains the PowerShell module for the MongoDb service.

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
For information on how to develop for `Az.MongoDB`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration 

> see https://aka.ms/autorest 

```yaml 

# pin the swagger version by using the commit id instead of branch name 

commit: 589f71f4a7fe1c6ca70b0988cadd93687df8f73c 

require: 

  - $(this-folder)/../../readme.azure.noprofile.md 

  - $(repo)/specification/liftrmongodb/resource-manager/readme.md 

try-require:  

  - $(repo)/specification/liftrmongodb/resource-manager/readme.powershell.md 

module-version: 0.1.0 

title: MongoDB 

service-name: MongoDB 

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
