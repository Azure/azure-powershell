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

Edit maintained inputs here, then use `..\tools\GenerationScripts\Update-EdgeActionGeneratedFiles.ps1`
to generate, build, and refresh help locally. This is not a source-only generator:
it also writes intermediate files under `generated\EdgeAction` and runnable modules under `artifacts\Debug`.
Keep those outputs out of feature commits; review source-side help changes separately.
Use `..\tools\TestScripts\Test-EdgeAction.ps1` for authorized Record runs and subsequent offline Playback.
HTTP recordings are reviewed test inputs, not generated-code archives.
See the [workflow and commit boundaries](how-to.md#workflow-and-commit-boundaries), including staged-change checks.
The repository pipeline publishes generated-code changes through a separate bot archive PR.
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
