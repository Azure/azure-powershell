Param(
    [Parameter(Mandatory = $true)]
    [string]$FeedPsd1FullPath
)

$feedDir = (Get-Item $FeedPsd1FullPath).Directory
$feedName = (Get-Item $FeedPsd1FullPath).Name
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $feedDir -FileName $feedName
$modules = $ModuleMetadata.RequiredModules

$dotnetCsv = New-Item -Path "$PSScriptRoot\" -Name "az-ps-latest.csv" -ItemType "file" -Force
$dotnetCsvContent = ""
for ($index = 0; $index -lt $modules.Count; $index++){
    $moduleName = $modules[$index].ModuleName
    $moduleVersion = if([string]::IsNullOrEmpty($modules[$index].RequiredVersion)){ $modules[$index].ModuleVersion } else{ $modules[$index].RequiredVersion } 
    $dotnetCsvContent += "pac$index,[ps=true;customSource=https://www.powershellgallery.com/api/v2/],$moduleName,$moduleVersion`n"
}
Set-Content -Path $dotnetCsv.FullName -Value $dotnetCsvContent -Encoding UTF8




