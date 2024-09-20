enum PSVersion
{
    NONE = 0
    PATCH = 1
    MINOR = 2
    MAJOR = 3
}

function Get-BumpedVersion
{
    Param(
        [Parameter(Mandatory = $true)]
        [string]$Version,
        [Parameter(Mandatory = $true)]
        [PSVersion]$VersionBump
    )

    $versionSplit = $Version.Split('.')
    if ($VersionBump -eq [PSVersion]::MAJOR)
    {
        $versionSplit[0] = 1 + $versionSplit[0]
        $versionSplit[1] = "0"
        $versionSplit[2] = "0"
    }
    elseif ($VersionBump -eq [PSVersion]::MINOR)
    {
        $versionSplit[1] = 1 + $versionSplit[1]
        $versionSplit[2] = "0"
    }
    elseif ($VersionBump -eq [PSVersion]::PATCH)
    {
        $versionSplit[2] = 1 + $versionSplit[2]
    }

    return $versionSplit -join "."
}