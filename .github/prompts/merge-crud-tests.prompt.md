---
description: "Use when: merging CRUD test files for an AutoRest module. Consolidates Get/Update/Remove/Start/Stop tests into the New-* test file for each resource."
---

# Merge CRUD Tests Workflow

Merge separate Get/Update/Remove/Start/Stop test files into a single `New-Az<Resource>.Tests.ps1` file per resource, following the CRUD-in-one-file pattern.

## Pattern

Each merged test file follows this exact structure:

```powershell
if(($null -eq $TestName) -or ($TestName -contains 'New-Az<Resource>'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-Az<Resource>.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-Az<Resource>' {
    It 'CreateExpanded' {
        # New - create resource with all interesting parameters in one call
        # Get - List, by name, ViaIdentity
        # Update - with tags/properties, ViaIdentity
        # Stop/Start (if applicable)
        # Remove - with PassThru
    }
}
```

## Rules

1. **Describe name**: Keep the original `New-Az<Resource>` name — changing it breaks test discovery.
2. **Single `It` block**: One `It 'CreateExpanded'` that runs New → Get → Update → Remove sequentially.
3. **Self-contained**: Create your own resources inside the test. Use `$env.ResourceGroupName` and `$env.*ProfileName` from setupEnv, but create all sub-resources (endpoints, origins, etc.) inline.
4. **No redundancy**: If a feature (e.g., LogScrubbing) can be tested during New, don't create a separate resource for it.
5. **CRUD order**: New → Get (List, by name, ViaIdentity) → Update (direct, ViaIdentity) → Stop/Start (if applicable) → Remove (with PassThru).
6. **ViaIdentity**: Test ViaIdentity for Get and Update within the same flow — no need for separate resources.
7. **Remove last**: Always remove at the end so all other operations can use the resource.

## Merge Groups

These are the CRUD groups to merge. Each group lists the verbs whose test files should be consolidated into the `New-*` file:

### CDN Resources
| Target File | Merge From |
|------------|------------|
| New-AzCdnProfile | Get, Update, Remove |
| New-AzCdnEndpoint | Get, Update, Remove, Start, Stop |
| New-AzCdnOrigin | Get, Update, Remove |
| New-AzCdnOriginGroup | Get, Update, Remove |
| New-AzCdnCustomDomain | Get, Remove + Enable/Disable-AzCdnCustomDomainCustomHttps |
| New-AzCdnPolicy | Get, Update, Remove |
| New-AzCdnProfileAgent | Get, Update, Remove |
| New-AzCdnWebAgent | Get, Update, Remove |
| New-AzCdnKnowledgeSource | Get, Update, Remove, Clear |
| New-AzCdnDeploymentVersion | Get, Update, Approve, Compare |

### FrontDoor CDN Resources
| Target File | Merge From |
|------------|------------|
| New-AzFrontDoorCdnProfile | Get, Update, Remove |
| New-AzFrontDoorCdnEndpoint | Get, Update, Remove |
| New-AzFrontDoorCdnOrigin | Get, Update, Remove |
| New-AzFrontDoorCdnOriginGroup | Get, Update, Remove |
| New-AzFrontDoorCdnCustomDomain | Get, Update, Remove |
| New-AzFrontDoorCdnRoute | Get, Update, Remove |
| New-AzFrontDoorCdnRule | Get, Update, Remove |
| New-AzFrontDoorCdnRuleSet | Get, Remove |
| New-AzFrontDoorCdnSecret | Get, Update, Remove |
| New-AzFrontDoorCdnSecurityPolicy | Get, Update, Remove |

### Migration (special)
| Target File | Merge From |
|------------|------------|
| Test-AzFrontDoorCdnProfileMigration | Enable, Stop |

## After Merging

1. Delete the old Get/Update/Remove/Start/Stop `.Tests.ps1` files
2. Delete their corresponding `.Recording.json` files
3. Run `.\test-module.ps1 -Record` to generate new recordings
4. The test runner will find the merged file by the `Describe` name

## Files to KEEP as-is (not merge)
- `New-Az*Object.Tests.ps1` — memory object cmdlets, no Azure resources
- Single-verb cmdlets (Test, Invoke, Move, Clear, etc.) that don't have CRUD counterparts
- `Get-Az*ResourceUsage.Tests.ps1` — read-only queries
