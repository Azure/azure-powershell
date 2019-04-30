# Azure PowerShell AutoRest Configuration

> Usings
``` yaml
use: "@microsoft.azure/autorest.powershell@beta"
```

> Values
``` yaml
azure: true
enable-multi-api: true
branch: multiapi
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
```

> Names
``` yaml
prefix: Az
subject-prefix: $(service-name)
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
```

> Folders
``` yaml
clear-output-folder: true
output-folder: .
```

> Profiles
``` yaml
require: $(repo)/profiles/readme.md
profile:
  - hybrid-2019-03-01
  - latest-2019-04-30
```

> Directives
``` yaml
directive:
  - where:
      subject: Operation
    hide: true
```