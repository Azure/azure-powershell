#input path to parent folder to perform recursive replace under
param([Parameter(Mandatory=$true)]$ResourceProviderFolder)

$regexA = '(token\\":\\")(.*?)(\\")'

$fileNames = Get-ChildItem -Path $ResourceProviderFolder -Recurse -Include '*.Recording.json'

foreach ($file in $filenames) {
    Write-Host "Processing file: $($file.FullName)"
    select-string -path $file -pattern $regexA | % {$_ -match $regexA > $null; $matches[1]}
    $c = (Get-Content $file.FullName) -replace $regexA, '${1}This-is-a-sas-token${3}' -join "`r`n"
    [IO.File]::WriteAllText($file.FullName, $c)

    Write-Host $matches
}