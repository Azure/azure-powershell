param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPlatform,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPowerShell
)

Write-Output "##vso[task.setprogress value=1;]Initializing live test scenarios"

$srcDir = Join-Path -Path ${env:BUILD_SOURCESDIRECTORY} -ChildPath "src"
$targetModules = @("Storage", "Dns", "Automation", "ApplicationInsights", "Databricks", "ContainerInstance")
$liveScenarios = $targetModules | ForEach-Object {
    $moduleSrcDir = Join-Path -Path $srcDir -ChildPath $_
    Get-ChildItem -Path $moduleSrcDir -Directory -Filter "LiveTests" -Recurse -ErrorAction SilentlyContinue
} | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" -Recurse | Select-Object -ExpandProperty FullName

$maxRunspaces = 9
[void][int]::TryParse(${env:RSPTHROTTLE}, [ref]$maxRunspaces)

$numRunspaces = [Math]::Min($liveScenarios.Count, $maxRunspaces)
$rsp = [runspacefactory]::CreateRunspacePool(1, $numRunspaces)
$rsp.CleanupInterval = [timespan]::FromMinutes(30)
[void]$rsp.Open()

$liveJobs = $liveScenarios | ForEach-Object {
    $module = [regex]::match($_, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value

    $ps = [powershell]::Create()
    $ps.RunspacePool = $rsp
    [void]$ps.AddScript({
            param (
                [string] $Module,
                [string] $RunPlatform,
                [string] $LiveScenarioScript
            )

            function Get-TypeTableDiag {
                param([string]$Label)
                try {
                    $bf = [System.Reflection.BindingFlags]("Public,NonPublic,Instance")
                    $rs = [runspace]::DefaultRunspace
                    $ec = $rs.GetType().GetProperty("ExecutionContext", $bf).GetValue($rs)
                    $tt = $ec.GetType().GetProperty("TypeTable", $bf).GetValue($ec)
                    $em = $tt.GetType().GetField("_extendedMembers", $bf).GetValue($tt)
                    $ttCount = $em.Count
                    $hasJob = $em.ContainsKey("System.Management.Automation.Job")
                    $ttHash = [System.Runtime.CompilerServices.RuntimeHelpers]::GetHashCode($tt)
                    $diag = "TT._ext=$ttCount,hasJob=$hasJob,ttHash=$ttHash"
                } catch { $diag = "TT_ERROR: $($_.Exception.Message)"; $ttCount = -1 }
                try {
                    $iss = $rs.GetType().GetProperty("InitialSessionState", $bf).GetValue($rs)
                    $diag += " | ISS.Types=$($iss.Types.Count)"
                } catch { $diag += " | ISS=ERR" }
                try { $diag += " | Mods=$((Get-Module).Count)" } catch {}
                Write-Output "##[warning]DIAG[$Module|$Label] $diag"
                if ($ttCount -ge 0 -and $ttCount -lt 100) {
                    try {
                        $keys = ($em.Keys | Sort-Object) -join ","
                        Write-Output "##[warning]DIAG[$Module|$Label] INCOMPLETE TT keys: $keys"
                    } catch {}
                }
            }

            Get-TypeTableDiag -Label "ENTRY"
            Import-Module "./tools/TestFx/Assert.ps1" -Force
            Get-TypeTableDiag -Label "POST-ASSERT"
            Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $Module, $RunPlatform, ${env:DATALOCATION} -Force
            Get-TypeTableDiag -Label "POST-UTILITY"
            . $LiveScenarioScript
            Get-TypeTableDiag -Label "POST-SCENARIOS"
        }
    ).AddParameter("Module", $module).AddParameter("RunPlatform", $RunPlatform).AddParameter("LiveScenarioScript", $_)

    [PSCustomObject]@{
        Id          = $ps.InstanceId
        Module      = $module
        Instance    = $ps
        AsyncHandle = $ps.BeginInvoke()
    } | Add-Member -MemberType ScriptProperty -Name State -Value {
        $bFlags = "NonPublic", "Instance", "Static"
        $fWorker = $this.Instance.GetType().GetField("_worker", $bFlags)
        if ($null -eq $fWorker) {
            $fWorker = $this.Instance.GetType().GetField("worker", $bFlags)
        }
        $vWorker = $fWorker.GetValue($this.Instance)
        $isCRP = [bool]$vWorker.GetType().GetProperty("CurrentlyRunningPipeline", $bFlags).GetValue($vWorker, $null)
        if ($this.AsyncHandle.IsCompleted -and !$isCRP) {
            "Completed"
        }
        elseif (!$this.AsyncHandle.IsCompleted -and $isCRP) {
            "Running"
        }
        elseif (!$this.AsyncHandle.IsCompleted -and !$isCRP) {
            "NotStarted"
        }
        else {
            "Unknown"
        }
    } -PassThru
}

$totalJobsCount = $liveJobs.Count
$completedJobsCount = 0
$queuedJobs = $liveJobs

while ($queuedJobs.Count -gt 0) {
    Start-Sleep -Seconds 60

    $waitingJobs = [System.Collections.Generic.List[PSObject]]::new()
    $runningJobs = [System.Collections.Generic.List[PSObject]]::new()
    $completedJobs = [System.Collections.Generic.List[PSObject]]::new()
    foreach ($job in $queuedJobs) {
        switch ($job.State) {
            "NotStarted" {
                [void]$waitingJobs.Add($job)
            }
            "Running" {
                [void]$runningJobs.Add($job)
            }
            "Completed" {
                [void]$completedJobs.Add($job)
            }
        }
    }

    $completedJobsCount += $completedJobs.Count
    if ($completedJobs.Count -gt 0) {
        $completedJobs | ForEach-Object {
            $curLiveJob = $_
            if ($null -ne $curLiveJob.Instance) {
                $liveJobOutput = $curLiveJob.Instance.EndInvoke($_.AsyncHandle)

                Write-Output "##[section][Test Scenario Result] Live test run for module `"$($curLiveJob.Module)`"."
                $liveJobOutput

                $liveJobStreams = $curLiveJob.Instance.Streams

                if ($liveJobStreams.Debug.Count -gt 0) {
                    Write-Output "##[group]Debug stream for module `"$($curLiveJob.Module)`""
                    $liveJobStreams.Debug | ForEach-Object {
                        $_ -split "`r?`n" | ForEach-Object {
                            Write-Output "##[debug]$_"
                        }
                    }
                    Write-Output "##[endgroup]"
                }

                if ($liveJobStreams.Error.Count -gt 0) {
                    Write-Output "##[group]Error stream for module `"$($curLiveJob.Module)`""
                    $liveJobStreams.Error | ForEach-Object {
                        ($_ | Format-List * -Force | Out-String) -split "`r?`n" | ForEach-Object {
                            Write-Output "##[error]$_"
                        }
                    }
                    Write-Output "##[endgroup]"
                }

                Write-Output ""
            }
        }
    }

    $queuedJobs = [System.Collections.Generic.List[PSObject]]::new($waitingJobs.Count + $runningJobs.Count)
    $queuedJobs.AddRange($waitingJobs)
    $queuedJobs.AddRange($runningJobs)

    $progressValue = if ($totalJobsCount -gt 0) {
        [int]($completedJobsCount / $totalJobsCount * 100)
    }
    else {
        0
    }
    $runningModules = ($runningJobs | Select-Object -ExpandProperty Module) -join ", "
    $progressMsg = "Total: $totalJobsCount | Waiting: $($waitingJobs.Count) | Running: $($runningJobs.Count) [$runningModules] | Completed: $completedJobsCount"
    Write-Output "##vso[task.setprogress value=$progressValue;]$progressMsg"
}

$accountsDir = Join-Path -Path $srcDir -ChildPath "Accounts"
$accountsLiveScenario = Get-ChildItem -Path $accountsDir -Directory -Filter "LiveTests" -Recurse -ErrorAction SilentlyContinue | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" -Recurse | Select-Object -ExpandProperty FullName
if ($null -ne $accountsLiveScenario) {
    Write-Output ""
    Write-Output "##[section]Live test run for module `"Accounts`"."

    Import-Module "./tools/TestFx/Assert.ps1" -Force
    Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList "Accounts", $RunPlatform, ${env:DATALOCATION} -Force
    . $accountsLiveScenario
}

$liveJobs | ForEach-Object {
    if ($null -ne $_.Instance) {
        $_.Instance.Commands.Clear()
        [void]$_.Instance.AddScript({
                $cleanupJobs = Get-Job
                $cleanupJobs | Wait-Job | Out-Null
                $cleanupJobs | Select-Object Name, Command, State, PSBeginTime, PSEndTime, Output
                $cleanupJobs | Remove-Job
            }
        )
        $_.AsyncHandle = $_.Instance.BeginInvoke()
    }
}

Write-Output ""
Write-Output "##[group]Live Test Resource Group Cleanup Jobs"

$liveJobs | ForEach-Object {
    $cleanupOutput = $_.Instance.EndInvoke($_.AsyncHandle)
    $cleanupOutput

    $_.Instance.Dispose()
}

Write-Output "##[endgroup]"

$rsp.Dispose()

$ltDir = Join-Path -Path ${env:DATALOCATION} -ChildPath "LiveTestAnalysis" | Join-Path -ChildPath "Raw"
$ltResults = Get-ChildItem -Path $ltDir -Filter "*.csv" -File -ErrorAction SilentlyContinue | Select-Object -ExpandProperty FullName

if ($null -ne $ltResults) {
    $tag = ${env:TAG}
    if (![string]::IsNullOrWhiteSpace($tag)) {
        $exProps = @{ Tag = $tag } | ConvertTo-Json -Compress
    }

    $failedScenarios = [System.Collections.Generic.List[PSObject]]::new()

    $ltResults | ForEach-Object {
        $ltCsv = (Import-Csv -Path $_)
        if ($null -ne $ltCsv) {
            $ltCsv |
            Select-Object `
            @{ Name = "Source"; Expression = { "LiveTest" } }, `
            @{ Name = "BuildId"; Expression = { ${env:BUILD_BUILDID} } }, `
            @{ Name = "OSVersion"; Expression = { $OSVersion } }, `
            @{ Name = "PSVersion"; Expression = { $_.PSVersion } }, `
            @{ Name = "Module"; Expression = { $_.Module } }, `
            @{ Name = "Name"; Expression = { $_.Name } }, `
            @{ Name = "Description"; Expression = { $_.Description } }, `
            @{ Name = "StartDateTime"; Expression = { $_.StartDateTime } }, `
            @{ Name = "EndDateTime"; Expression = { $_.EndDateTime } }, `
            @{ Name = "IsSuccess"; Expression = { $_.IsSuccess } }, `
            @{ Name = "Errors"; Expression = { $_.Errors } }, `
            @{ Name = "ExtendedProperties"; Expression = { $exProps } } |
            Export-Csv -Path $_ -Encoding utf8 -NoTypeInformation -Force

            $ltCsv | Where-Object { $_.IsSuccess -eq "False" } | ForEach-Object {
                [void]$failedScenarios.Add($_)
            }
        }
        else {
            Remove-Item -Path $_ -Force
        }
    }

    if ($failedScenarios.Count -gt 0) {
        Write-Output ""
        Write-Output "##[section]The following $($failedScenarios.Count) live test scenario(s) failed:"
        $failedScenarios | Sort-Object -Property Module, Name | ForEach-Object {
            Write-Output "##vso[task.logissue type=error;]Module: $($_.Module) | Scenario: $($_.Name)"
        }
        Write-Output ""

        Write-Output "##vso[task.complete result=Failed;]$($failedScenarios.Count) live test scenario(s) failed."
    }
}
