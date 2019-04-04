# Azure PowerShell AutoRest Configuration

> Values
``` yaml
azure: true
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