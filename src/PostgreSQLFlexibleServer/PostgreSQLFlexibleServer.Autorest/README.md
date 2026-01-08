<!-- region Generated -->
# Az.PostgreSqlFlexibleServer
This directory contains the PowerShell module for the PostgreSqlFlexibleServer service.

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
For information on how to develop for `Az.PostgreSqlFlexibleServer`, see [how-to.md](how-to.md).
<!-- endregion -->

# Az.PostgreSQLFlexibleServer

This directory contains the PowerShell module for the Azure Database for PostgreSQL Flexible Server service.

## AutoRest Configuration

> see [autorest](https://aka.ms/autorest)

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: be31c7768b25795ee6aadd24783100254499c845
repo: https://github.com/Azure/azure-rest-api-specs
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/postgresql/resource-manager/readme.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: PostgreSQLFlexibleServer
subject-prefix: PostgreSQLFlexibleServer
input-file:
  - $(repo)/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2025-08-01/openapi.json

use:
  - "@autorest/powershell@latest"

directive:
  # Fix SecureString type conversion issues in BackupStoreDetails
  # AutoRest generates direct string to SecureString casts which are invalid
  # Replace invalid cast with proper SecureString creation helper method
  - from: BackupStoreDetails.json.cs
    where: $
    transform: |
      return $.replace(
        /\(System\.Security\.SecureString\)\(__t\.ToString\(\)\)/g,
        'ConvertToSecureString(__t.ToString())'
      ).replace(
        /(namespace [^{]+\{[\s\S]*?)(internal BackupStoreDetails)/,
        '$1\n        private static System.Security.SecureString ConvertToSecureString(string value)\n        {\n            if (string.IsNullOrEmpty(value)) return null;\n            var secureString = new System.Security.SecureString();\n            foreach (char c in value)\n            {\n                secureString.AppendChar(c);\n            }\n            secureString.MakeReadOnly();\n            return secureString;\n        }\n\n        $2'
      );
    
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
