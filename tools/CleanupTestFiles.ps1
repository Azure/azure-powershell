[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$ExitCode,
    [Parameter()]
    [string]$FileName,
    [Parameter()]
    [string]$FolderName
)

if ($ExitCode -eq 0)
{
    Move-Item -Path $FolderName/$FileName.html -Destination $FolderName/PassingTests/$FileName.html
}

else
{
    Move-Item -Path $FolderName/$FileName.html -Destination $FolderName/FailingTests/$FileName.html
}
