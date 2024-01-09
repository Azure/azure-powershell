$Modules = Get-ChildItem -Recurse -Depth 2 -Path src -File -Filter *.sln | ForEach-Object {$_.BaseName}

$Content = @"
# Azure PowerShell Modules

## Rollup Module

| Description                           | Module Name | PowerShell Gallery Link          |
| ------------------------------------- | ----------- | -------------------------------- |
| Azure PowerShell                      | ``Az``        | [![Az]][AzGallery]               |
| Azure PowerShell with preview modules | ``AzPreview`` | [![AzPreview]][AzPreviewGallery] |

## Service Modules

| Azure Service                  | Module Name                     | PowerShell Gallery Link                                            | Changelog                                          |
| ------------------------------ | ------------------------------- | ------------------------------------------------------------------ | -------------------------------------------------- |

"@

foreach ($module in $Modules)
{
    $serviceName = $module
    $moduleName = "``Az.$module``"
    $PSGalleryLink = "[![$module]][${module}Gallery]"
    $changeLogLink = "[Changelog][${module}ChangeLog]"
    $content += "| {0, -30} | {1, -31} | {2, -66} | {3, -48} |`n" -f $serviceName, $moduleName, $PSGalleryLink, $changeLogLink
}

$content += @"

<!-- References -->

<!-- Shields -->
[Az]:                         https://img.shields.io/powershellgallery/v/Az.svg?style=flat-square&label=Az
[AzPreview]:                  https://img.shields.io/powershellgallery/v/AzPreview.svg?style=flat-square&label=AzPreview

"@

foreach ($module in $Modules)
{
    $ShieldsLink = "[${module}]:"
    $content += "{0, -29} https://img.shields.io/powershellgallery/v/Az.$Module.svg?style=flat-square&label=Az.$Module`n" -f $ShieldsLink
}

$content += @"

<!-- PS Gallery -->
[AzGallery]:                         https://www.powershellgallery.com/packages/Az/
[AzPreviewGallery]:                  https://www.powershellgallery.com/packages/AzPreview/

"@

foreach ($module in $Modules)
{
    $PSGalleryLink = "[${module}Gallery]:"
    $content += "{0, -36} https://www.powershellgallery.com/packages/Az.$Module/`n" -f $PSGalleryLink
}
$content += @"

<!-- ChangeLog -->

"@
foreach ($module in $Modules)
{
    $ChangeLogLink = "[${Module}ChangeLog]:"
    $content += "{0, -38} ../src/$Module/$Module/ChangeLog.md`n" -f $ChangeLogLink
}

$content | Out-File -FilePath .\documentation\azure-powershell-modules.md -Encoding utf8