param(
    [Parameter(Mandatory=$true)]
    [string]$autorestVersion,

    [Parameter(Mandatory=$true)]
    [string]$changeLogEntry
)

Write-Host "Script started"
$root = "src"

Get-ChildItem -Path $root -Directory | ForEach-Object {
    $moduleOuter = $_.FullName
    $moduleInner = Join-Path $moduleOuter $_.Name

    $upgradeLog = Join-Path $moduleInner "AutorestUpgradeLog.md"
    $changeLog  = Join-Path $moduleInner "ChangeLog.md"

    Write-Host $upgradeLog

    if (-not (Test-Path $upgradeLog)) {
        return 
    }

    $lines = Get-Content $upgradeLog
    $lastLine = ($lines | Select-Object -Last 1).Trim()

    if ($lastLine -ne $autorestVersion) {
        return
    }


    if (Test-Path $changeLog) {

        $cl = Get-Content $changeLog
        
        $index = -1
        for ($i = 0; $i -lt $cl.Count; $i++) {
            if ($cl[$i] -match '^## Upcoming Release$') {
                $index = $i
                break
            }
        }

        if ($index -ge 0) {
            $before = $cl[0..$index]
            $after  = $cl[($index+1)..($cl.Length-1)]
            $new = $before + $changeLogEntry + $after
        } else {
            $new = @("## Upcoming Release", $changeLogEntry, "") + $cl
        }

        Set-Content -Path $changeLog -Value $new

    } else {
        $content = @(
            "## Upcoming Release",
            $changeLogEntry,
            ""
        )
        Set-Content -Path $changeLog -Value $content
    }
}