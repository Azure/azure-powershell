<!-- region Generated -->
# Az.EdgeAction
This directory contains the PowerShell module for the EdgeAction service.

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
For information on how to develop for `Az.EdgeAction`, see [how-to.md](how-to.md).

Use the existing repository preparation/build scripts, platyPS help commands, and
the built artifact's `test-module.ps1` harness as described in the
[development steps](how-to.md). No module-specific development wrapper is required.
Commit maintained inputs, meaningful help changes, and reviewed scenario recordings.
Do not include development tools, build artifacts, or changes under `generated`;
the repository pipeline archives generated output through a separate bot PR.
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
# pin the swagger version by using the commit id instead of branch name
commit: 65eb9311d304dcf9874d05fdec39ea65baae8db8
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/stable/2026-10-01/openapi.json

# For new RP, the version is 0.1.0
module-version: 0.1.1
# Normally, title is the service name
title: EdgeAction
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

directive:
  # Generated help must name the public PowerShell cmdlet, not the REST operation.
  - from: swagger-document
    where: $..description
    transform: |
      if (typeof $ === 'string') {
        $ = $.replace(/\bswapDefault\b/g, 'Switch-AzEdgeActionVersionDefault');
      }

  # ARM POST operations require an empty body for ASP.NET pipeline compatibility
  # The getVersionCode and swapDefault operations need {} body even though swagger doesn't define request body
  - from: source-file-csharp
    where: $
    transform: |
      $ = $.replace(
        /var request = new global::System\.Net\.Http\.HttpRequestMessage\(Microsoft\.Azure\.PowerShell\.Cmdlets\.EdgeAction\.Runtime\.Method\.Post, _url\);\s*await eventListener\.Signal\(Microsoft\.Azure\.PowerShell\.Cmdlets\.EdgeAction\.Runtime\.Events\.RequestCreated, request\.RequestUri\.PathAndQuery\)/gm,
        'var request = new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.Method.Post, _url);\n                request.Content = new global::System.Net.Http.StringContent("{}", global::System.Text.Encoding.UTF8, "application/json");\n                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery)'
      );
      return $;

  # Remove the unexpanded parameter set
  # For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Patch$|^PatchViaIdentity$
    remove: true
  
  # Parent updates support only tags; properties are empty and any supplied SKU is rejected.
  - from: swagger-document
    where: $.definitions.EdgeActionUpdate.properties
    transform: |
      delete $.properties;
      delete $.sku;

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  
  # Fix SubscriptionId parameter type conflict - keep only single string variant
  - where:
      parameter-name: SubscriptionId
    set:
      parameter-name: SubscriptionId

  # Format table to exclude system metadata
  - where:
      model-name: .*
    set:
      format-table:
        exclude-properties:
          - SystemData
          - SystemDataCreatedAt
          - SystemDataCreatedBy
          - SystemDataCreatedByType
          - SystemDataLastModifiedAt
          - SystemDataLastModifiedBy
          - SystemDataLastModifiedByType

  # Hide DeployVersionCode to customize with file deployment
  - where:
      verb: Deploy
      subject: EdgeActionVersionCode
    hide: true
  
  # Hide GetVersionCode to customize with empty body for ARM POST requirement
  - where:
      verb: Get
      subject: EdgeActionVersionCode
    hide: true
  
  # Hide Switch-AzEdgeActionVersionDefault to customize with empty body for ARM POST requirement
  - where:
      verb: Switch
      subject: EdgeActionVersionDefault
    hide: true
  
  # Remove array variant of SubscriptionId to fix parameter type conflict
  - where:
      parameter-name: SubscriptionId
    clear-alias: true
```
