<!-- region Generated -->
# Az.PlanetaryComputer
This directory contains the PowerShell module for the PlanetaryComputer service.

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
For information on how to develop for `Az.PlanetaryComputer`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 3d41865727e08555114cd851cb6145987474f9d8
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.md

try-require:
  - $(repo)/specification/orbitalplanetarycomputer/resource-manager/readme.powershell.md

tag: package-2026-10-01

# For new RP, the version is 0.1.0
module-version: 0.1.0
title: PlanetaryComputer
subject-prefix: $(service-name)

# Keep service-specific connection management alongside GeoCatalog private-link discovery.
keep-pec-and-plr: true

directive:
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

  # Distinguish connections belonging to a GeoCatalog from other service resources.
  - where:
      subject: PrivateEndpointConnection
    set:
      subject: GeoCatalogPrivateEndpointConnection

  # AutoRest assumes every managed identity supports SystemAssigned. Keep the existing
  # user-assigned identity and GET/PUT update behavior, but expose only supported types.
  - from:
      - NewAzPlanetaryComputerGeoCatalog_CreateExpanded.cs
      - UpdateAzPlanetaryComputerGeoCatalog_UpdateExpanded.cs
      - UpdateAzPlanetaryComputerGeoCatalog_UpdateViaIdentityExpanded.cs
    where: $
    transform: |
      $ = $.replace(
        /        \/\/\/ <summary>Determines whether to enable a system-assigned identity for the resource\.<\/summary>[\s\S]*?public [^\r\n]* EnableSystemAssignedIdentity [^\r\n]*/,
        `        /// <summary>The managed identity type of the GeoCatalog.</summary>
              [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The managed identity type of the GeoCatalog. Use None to remove identities or UserAssigned for user-assigned identities.")]
              [global::System.Management.Automation.ValidateSet("None", "UserAssigned")]
              [global::Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.PSArgumentCompleterAttribute("None", "UserAssigned")]
              public string IdentityType { get; set; }`);
      $ = $.replace(
        /(        private void PreProcessManagedIdentityParameters(?:WithGetResult)?\(\)\r?\n        \{)[\s\S]*?\r?\n        \}/,
        `$1
                  if (this.UserAssignedIdentity?.Length > 0)
                  {
                      _resourceBody.IdentityUserAssignedIdentity.Clear();
                      foreach (var id in this.UserAssignedIdentity)
                      {
                          _resourceBody.IdentityUserAssignedIdentity.Add(id, new Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.UserAssignedIdentity());
                      }
                  }
                  if (this.IdentityType != null)
                  {
                      _resourceBody.IdentityType = this.IdentityType;
                  }
                  else if (true == this.MyInvocation?.BoundParameters?.ContainsKey("UserAssignedIdentity"))
                  {
                      _resourceBody.IdentityType = this.UserAssignedIdentity?.Length > 0 ? "UserAssigned" : "None";
                  }
                  if ("None".Equals(_resourceBody.IdentityType, StringComparison.OrdinalIgnoreCase))
                  {
                      _resourceBody.IdentityUserAssignedIdentity = null;
                  }
              }`);
```
