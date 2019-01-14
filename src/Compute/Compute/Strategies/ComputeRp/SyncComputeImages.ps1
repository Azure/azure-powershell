
$aliaspage = Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-compute/quickstart-templates/aliases.json" -TimeoutSec 5
$parsedJson = $aliaspage.Content | ConvertFrom-Json

ConvertTo-Json $parsedJson.Outputs.Aliases.Value | Set-Content -Path $PSScriptRoot/Images.json