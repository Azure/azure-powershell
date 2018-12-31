param(
    [Parameter(Position=0)]
    [string]$Path
)

if ($Path -eq $null) {
    $Path=$PSScriptRoot
} else {
    $Path = Resolve-Path $Path
}

Write-Output "Under the'$Path' folder"

"Signed","Unsigned" | ForEach-Object {
    Write-Output "'$_' artifacts deletion..."
    $foldersToDelete = Get-ChildItem  -Path $Path -filter $_ -Directory -Recurse
    $itemsQnty = $foldersToDelete.Count
    Write-Output "Number of folders found: $itemsQnty"
    if ($itemsQnty -gt 0) {
        Write-Output "Folders list:"
        $foldersToDelete | ForEach-Object {
            $_.FullName
        }
        $foldersToDelete | ForEach-Object { 
            Remove-Item (Join-Path $_.FullName *.*) -Force
        }
        $foldersToDelete | ForEach-Object {
            Remove-Item $_.FullName -Force
        }
        Write-Output "Deleted"
    }
}