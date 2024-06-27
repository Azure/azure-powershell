### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: c858811c29ee22362eafd8be94ad0ff808fe7cf9
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/oracle/resource-manager/readme.md

try-require: 
  - $(repo)/specification/oracle/resource-manager/readme.md

module-version: 0.1.0
title: OracleDatabase
subject-prefix: $(service-name)
 
inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true
 
directive:
  - from: swagger-document
    where: $.definitions..isProtected
    transform: $.readOnly = false
  - from: swagger-document
    where: $.definitions..serial
    transform: $.readOnly = false
  - from: swagger-document
    where: $.definitions..timeCreated
    transform: $.readOnly = false
  - from: swagger-document
    where: $.definitions..availableCoreCount
    transform: $.readOnly = false
  - from: swagger-document
    where: $.definitions..timeUpdated
    transform: $.readOnly = false
```