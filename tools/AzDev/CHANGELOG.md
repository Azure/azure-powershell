## Next
- Feature: further distinguish track 1/2 SDKs, data/management plane, package/project.
- Local static analysis (Invoke-AzStaticAnalyzer)
- New-TestEnvironment and other existing tools
- Scripts to help deploy compliant resources
- Look into tools/, what else can be ported here?
- Install daily build
- Check what CLI's az dev support?
- Wildcard of project and module names - need to implement by hand? Can leverage `DirectoryInfo.GetFiles`? It supports kind of wildcard.
- Quick start templates
- Versioning and publishing AzDev module

## 2026/1/29
- Feature: `Merge-DevPullRequest` cmdlet to help merge PRs in azure-powershell repo.

## 2025/12/22
- Feature: Added cmdlet `New-DevTSPModule` for TypeSpec development.

## 2025/8/26
- Feature: Recognize AutoRest.PowerShell version (v3/v4) for AutoRest-based projects and show as `SubType` in `Get-DevProject` output.

## 2025/1/2
- Misc: moved to azure-powershell repo
- Feature: Connect common repo and ps repo

## 2024/12/30
- Fix: path issue on Windows
- Misc: Better error message when no context

## 2024/12/27
- Feature: Distinguish SDK-based projects, wrapper projects and other projects.
- Feature: Distinguish modules types: SdkBased, autorestBased, Hybrid.

## 2024/12/25
- Fix: Inventory cmdlets ignore live tests

## 2024/10/15
- Feature: Add reason for deducing project type

## 2024/9/11
- Feature: Open swagger link
- Rename SDK-based project type to "Other" because there's no accurate way to distinguish between SDK and wrapper projects

## Older
- Fix: Two misidentified projects because of live tests: ContainerRegistry and Resources
- Feature: Get-DevProject: Add support for `-Type` parameter
- Feature: Add new ProjectType: Test, LegacyHelper, Track1Sdk
- Renamed "Submodule" to "Project"
- Feature: Added "Get-DevProject" cmdlet
