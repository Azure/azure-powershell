
$basePath = "C:\Users\hoppe\work\azure-powershell"
remove-module Az.Batch
import-module $basePath\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
import-module $basePath\artifacts\Debug\Az.Batch\Az.Batch.psd1
Push-Location $basePath\tools
Import-Module .\Repo-Tasks.psd1 
$pathToHelpFolder = "$basePath\src\Batch\Batch\help"
Update-MarkdownHelpModule -Path $pathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName
Pop-Location
