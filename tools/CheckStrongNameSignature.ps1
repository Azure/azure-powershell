function Check-StrongName {
    [CmdletBinding()]
    param([Parameter(ValueFromPipeline=$true)][string]$path)
    $output = & "sn.exe" -vf $path
    $length = $output.Length - 1
    if (-not $output[$length].Contains("is valid")) {
        Write-Output "$path has an invalid string name."
    }
}

function Check-All {    
    $invalidList = Get-ChildItem -Recurse -Filter *.dll | %{Check-StrongName -path $_.FullName}

    if ($invalidList.Length -gt 0) {
        Write-Output($invalidList)
        throw "Strong name signature checked failed. One (or more) of the dlls has an invalid string name."
    }
}