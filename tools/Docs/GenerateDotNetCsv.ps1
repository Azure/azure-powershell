Param(
    [Parameter(Mandatory = $true)]
    [string]$FeedPsd1FullPath,
    [Parameter(Mandatory = $false)]
    [string]$CustomSource = "https://www.powershellgallery.com/api/v2/"
)

$feedDir = (Get-Item $FeedPsd1FullPath).Directory
$feedName = (Get-Item $FeedPsd1FullPath).Name
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $feedDir -FileName $feedName
$modules = $ModuleMetadata.RequiredModules

$dotnetCsv = New-Item -Path "$PSScriptRoot\" -Name "az-ps-latest.csv" -ItemType "file" -Force
$dotnetCsvContent = ""
for ($index = 0; $index -lt $modules.Count; $index++){
    $moduleName = $modules[$index].ModuleName
    $moduleVersion = [string]::IsNullOrEmpty($modules[$index].RequiredVersion) ? $modules[$index].ModuleVersion : $modules[$index].RequiredVersion
    $dotnetCsvContent += "pac$index,[ps=true;customSource=$CustomSource]$moduleName,$moduleVersion`n"
}
Set-Content -Path $dotnetCsv.FullName -Value $dotnetCsvContent -Encoding UTF8




