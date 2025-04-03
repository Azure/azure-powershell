$module = 'AzDev'
$artifacts = "$PSScriptRoot/../../artifacts"

dotnet publish $PSScriptRoot/src --sc -o "$artifacts/$module/bin"
Copy-Item "$PSScriptRoot/$module/*" "$artifacts/$module" -Recurse -Force
