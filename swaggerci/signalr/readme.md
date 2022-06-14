### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
    - $(this-folder)/../../tools/SwaggerCI/readme.azure.noprofile.md
    - $(this-folder)/../../../azure-rest-api-specs/specification/signalr/resource-manager/readme.md
try-require:
    - $(this-folder)/../../../azure-rest-api-specs/specification/signalr/resource-manager/readme.powershell.md
```
