# Azure PowerShell AutoRest Configuration

> Language
``` yaml
use:
- "@microsoft.azure/autorest.powershell@beta"

```

> Values
``` yaml
azure: true
enable-multi-api: true
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
output-folder: $(service-name)
```

> Directives
``` yaml
directive:
  - where:
      subject: Operation
    set:
      hidden: true
```

