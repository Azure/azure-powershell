$ProjectRoot = "$PSScriptRoot/../.."

$Modules = Get-ChildItem -Recurse -Depth 2 -Path "$ProjectRoot/src" -File -Filter *.sln | ForEach-Object {$_.BaseName}

$Content = @"
# Azure PowerShell Modules

## Rollup Module

| Description                           | Module Name | PowerShell Gallery Link          |
| ------------------------------------- | ----------- | -------------------------------- |
| Azure PowerShell                      | ``Az``        | [![Az]][AzGallery]               |
| Azure PowerShell with preview Modules | ``AzPreview`` | [![AzPreview]][AzPreviewGallery] |

## Service Modules

| Azure Service                  | Module Name                     | PowerShell Gallery Link                                            | Changelog                                          |
| ------------------------------ | ------------------------------- | ------------------------------------------------------------------ | -------------------------------------------------- |

"@

# Table
foreach ($Module in $Modules)
{
    $ServiceName = $Module
    $ModuleName = "``Az.$Module``"
    $PSGalleryLink = "[![$Module]][${Module}Gallery]"
    $ChangeLogLink = "[Changelog][${Module}ChangeLog]"
    $Content += "| {0,-30} | {1,-31} | {2,-66} | {3,-48} |`n" -f $ServiceName, $ModuleName, $PSGalleryLink, $ChangeLogLink
}

# Shields
$Content += @"

<!-- References -->

<!-- Shields -->
[Az]:                         https://img.shields.io/powershellgallery/v/Az.svg?style=flat-square&label=Az
[AzPreview]:                  https://img.shields.io/powershellgallery/v/AzPreview.svg?style=flat-square&label=AzPreview

"@
foreach ($Module in $Modules)
{
    $ShieldsLink = "[${Module}]:"
    $Content += "{0,-29} https://img.shields.io/powershellgallery/v/Az.$Module.svg?style=flat-square&label=Az.$Module`n" -f $ShieldsLink
}

# PowerShell Gallery
$Content += @"

<!-- PS Gallery -->
[AzGallery]:                         https://www.powershellgallery.com/packages/Az/
[AzPreviewGallery]:                  https://www.powershellgallery.com/packages/AzPreview/

"@
foreach ($Module in $Modules)
{
    $PSGalleryLink = "[${Module}Gallery]:"
    $Content += "{0,-36} https://www.powershellgallery.com/packages/Az.$Module/`n" -f $PSGalleryLink
}

# ChangeLog
$Content += @"

<!-- ChangeLog -->

"@
foreach ($Module in $Modules)
{
    $ChangeLogLink = "[${Module}ChangeLog]:"
    $Content += "{0,-38} ../src/$Module/$Module/ChangeLog.md`n" -f $ChangeLogLink
}

$Content | Out-File -FilePath "$ProjectRoot/documentation/azure-powershell-Modules.md" -Encoding utf8