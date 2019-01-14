$files = Get-ChildItem . *.cs -rec
foreach ($file in $files)
{
    (Get-Content $file.PSPath) |
    Foreach-Object { $_ -replace "Management.Sql", "Management.Sql.LegacySdk" } |
    Set-Content $file.PSPath
}
