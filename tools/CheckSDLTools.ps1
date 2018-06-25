# BinScope
$dllFiles = Get-ChildItem $PSScriptRoot/../src/Package -Recurse | Where-Object { $_.FullName -like "*dll"}

$dllFiles | ForEach-Object { BinScope.exe $_.FullName /LogFile "$PSScriptRoot/../src/Package/BinScope/Binscope-$_.html"}