$aboutFileInputFullName = "C:\Azure\azure-powershell\src\Accounts\Accounts\help\About\about_az.md"
$aboutFileOutputFullName = "C:\Azure\azure-powershell\src\Accounts\Accounts\help\About\about_az.help.txt"

$pandocArgs = @(
    "--from=gfm",
    "--to=plain+multiline_tables",
    "--columns=75",
    "--output=$aboutFileOutputFullName",
    "--quiet"
)

Get-Content $aboutFileInputFullName | pandoc $pandocArgs