<!-- region Generated -->
# Az.CloudHealth
This directory contains the PowerShell module for the CloudHealth service.

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


<!-- endregion -->

### Regenerating the module and help

Prerequisites:
- `autorest` and `platyPS` must be available in your PowerShell session.
- `Az.Accounts` and `Az.CloudHealth` must already be built under `./artifacts/Debug`.

From the repository root, run:

```powershell
$repoRoot = (Resolve-Path .).Path
& (Join-Path $repoRoot "tools/BuildScripts/BuildModules.ps1") -RepoRoot $repoRoot -Configuration Debug -TargetModule CloudHealth
```

`BuildModules.ps1` always appends `Accounts` to `-TargetModule`, so this command builds both `CloudHealth` and `Accounts`.

The source of truth depends on the content:

| Content | Source of truth | Generated output |
| --- | --- | --- |
| Cmdlet syntax, parameters, and descriptions | This AutoRest configuration, the referenced API specification, and files under `custom` | `exports`, `internal`, and `docs` |
| Examples | Files under `examples` | Example sections in `docs` and the parent module `help` folder |
| Shipped help | Generated `docs` combined with the built module metadata | `../CloudHealth/help` |

Do not edit files under `docs`, `exports`, `internal`, the parent module `help` folder, or `generated/CloudHealth` directly.

From the repository root, regenerate the local AutoRest output, build the module, and propagate the generated documentation to the shipped help:

```powershell
$repoRoot = (Resolve-Path .).Path
$autorestModulePath = Join-Path $repoRoot "src/CloudHealth/CloudHealth.Autorest"

Push-Location -Path $autorestModulePath
try {
    autorest --max-memory-size=8192
    ./build-module.ps1
}
finally {
    Pop-Location
}
```

The first regeneration step may rewrite tracked files such as the `Project(...)` entry (project GUID and `src/CloudHealth/CloudHealth.Autorest/Az.CloudHealth.csproj` path) in `src/CloudHealth/CloudHealth.sln`, the assembly version attributes in `src/CloudHealth/CloudHealth.Autorest/Properties/AssemblyInfo.cs`, and the `generate_Id` in `src/CloudHealth/CloudHealth.Autorest/generate-info.json`.

To refresh the committed module under `generated/CloudHealth`, use the repository build tooling:

```powershell
$repoRoot = (Resolve-Path .).Path
$prepareScript = Join-Path $repoRoot "tools/BuildScripts/PrepareAutorestModule.ps1"

Push-Location -Path $repoRoot
try {
    & $prepareScript -RepoRoot $repoRoot -ModuleRootName CloudHealth -Configuration Debug -ForceRegenerate
}
finally {
    Pop-Location
}
```

`PrepareAutorestModule.ps1` regenerates in `src/CloudHealth/CloudHealth.Autorest`, then moves its known generated output set into `generated/CloudHealth/CloudHealth.Autorest` (`generated`, `resources`, module `.psd1/.psm1/.format.ps1xml`, `exports`, `internal`, `test-module.ps1`, and `check-dependencies.ps1`). Source-side disappearance of those paths is expected.

Always inspect the generated changes before committing:

```powershell
git status --short
git diff --name-status
git diff --check
```

The diff should contain only the source changes you intended and their generated outputs. Files removed under `generated/CloudHealth` may be expected when directives remove cmdlets. If the source and committed `generate-info.json` files have different `generate_Id` values, rerun the PrepareAutorestModule block above to reconcile them. `-ForceRegenerate` forces refresh even when the two `generate_Id` values already match.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 801a60cdad2669e8f824fedfbabbfe7f7093b940
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

# The cloudhealth spec readme (openapi-type: arm / rpaas) declares no PowerShell tag or
# swagger-to-sdk block, so inputs are resolved directly from the versioned swagger below.
try-require:
  - $(repo)/specification/cloudhealth/resource-manager/readme.powershell.md

input-file:
  - $(repo)/specification/cloudhealth/resource-manager/Microsoft.CloudHealth/CloudHealth/preview/2026-05-01-preview/cloudhealth.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: CloudHealth
subject-prefix: MonitorHealthModel
service-name: CloudHealth

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  #
  # AuthenticationSetting, SignalDefinition and DiscoveryRule carry discriminated
  # (polymorphic) property bags. The Expanded variants only flatten the base type, so
  # the subtype-required fields (authenticationKind/managedIdentityName, the
  # signalKind subtype metric fields, and specification/entityName) are unreachable and
  # every Expanded call fails API payload validation. Keep their unexpanded variants so
  # the property object built by the *Object cmdlets below can be passed directly.
  - where:
      subject: ^(AuthenticationSetting|SignalDefinition|DiscoveryRule)$
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: false
  - where:
      subject: ^(?!AuthenticationSetting$|SignalDefinition$|DiscoveryRule$).*$
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Strip ShouldProcess/ConfirmImpact from every Get-* cmdlet.
  # Why: several health-model reads 
  #    - entity history
  #    - signal history/recommendation
  #    - data annotation
  # are using POST, so AutoRest gives them SupportsShouldProcess + ConfirmImpact='Medium'. 
  
  - where:
      verb: Get
    set:
      suppress-should-process: true

  # Keep the discriminated property bags as explicit models and emit constructor
  # cmdlets for them, so the unexpanded variants above are actually usable.
  - no-inline:
    - AuthenticationSettingProperties
    - ManagedIdentityAuthenticationSettingProperties
    - SignalDefinitionProperties
    - ResourceMetricSignalDefinitionProperties
    - LogAnalyticsQuerySignalDefinitionProperties
    - PrometheusMetricsSignalDefinitionProperties
    - DiscoveryRuleSpecification
    - ApplicationInsightsTopologySpecification
    - ResourceGraphQuerySpecification
    - EvaluationRule
    - ThresholdRuleV2

  - model-cmdlet:
    - model-name: ManagedIdentityAuthenticationSettingProperties
    - model-name: ResourceMetricSignalDefinitionProperties
    - model-name: LogAnalyticsQuerySignalDefinitionProperties
    - model-name: PrometheusMetricsSignalDefinitionProperties
    - model-name: ApplicationInsightsTopologySpecification
    - model-name: ResourceGraphQuerySpecification
    - model-name: EvaluationRule
    - model-name: ThresholdRuleV2
```
