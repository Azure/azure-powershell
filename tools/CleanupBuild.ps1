[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$BuildConfig
)

function Cleanup-MarkdownHelp
{
    [CmdletBinding()]
    Param
    (
        [Parameter()]
        [string]$BuildConfig
    )

    $HelpFolders = Get-ChildItem "help" -Recurse -Directory | where { $_.FullName -like "*$BuildConfig*" }
    $HelpFolders | foreach { Remove-Item -Path $_ -Recurse -Force }
}

Cleanup-MarkdownHelp -BuildConfig $BuildConfig