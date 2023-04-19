### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
    - $(this-folder)/../../tools/SwaggerCI/readme.azure.noprofile.md
    - $(this-folder)/../../../azure-rest-api-specs/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/readme.md
try-require:
    - $(this-folder)/../../../azure-rest-api-specs/specification/containerservice/resource-manager/Microsoft.ContainerService/aks/readme.powershell.md
```
