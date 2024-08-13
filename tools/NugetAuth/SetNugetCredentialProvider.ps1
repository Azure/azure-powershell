$scriptPath = Join-Path $PSScriptRoot installcredprovider.ps1
New-Item -ItemType File -Path $scriptPath
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/microsoft/artifacts-credprovider/master/helpers/installcredprovider.ps1").Content | Set-Content $scriptPath -force

. $scriptPath -AddNetfx

Remove-Item $scriptPath -Force