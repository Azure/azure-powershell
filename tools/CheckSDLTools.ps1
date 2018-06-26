# BinScope
$dllFiles = Get-ChildItem $PSScriptRoot/../src/Package -Recurse | Where-Object { $_.FullName -like "*dll"}

$dllFiles | ForEach-Object { BinScope.exe $_.FullName /LogFile "$PSScriptRoot/../src/Package/BinScope/Binscope-$_.html"}

# PoliCheck
Get-ChildItem -Recurse $PSScriptRoot\.. -File | ForEach-Object { $_.FullName } | Out-File "$PSScriptRoot\..\src\Package\policheckfiles.txt"
PoliCheck.exe /f:"$PSScriptRoot\..\src\Package\policheckfiles.txt" /T:"9" /O:"$PSScriptRoot\..\src\Package\policheckresult.xml"
