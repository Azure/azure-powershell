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

$srcDir = Join-Path -Path ${env:BUILD_SOURCESDIRECTORY} -ChildPath "src"
$liveScenarios = Get-ChildItem -Path $srcDir -Directory -Exclude "Accounts" -ErrorAction SilentlyContinue | Get-ChildItem -Directory -Filter "LiveTests" -Recurse | Get-ChildItem -File -Filter "TestLiveScenarios.ps1" -Recurse | Select-Object -ExpandProperty FullName

$rsp = [runspacefactory]::CreateRunspacePool(1, 5)
$rsp.CleanupInterval = [timespan]::FromHours(1)
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

            Import-Module "./tools/TestFx/Assert.ps1" -Force
            Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $Module, $RunPlatform -Force
            . $LiveScenarioScript
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

Start-Sleep -Seconds 30

$totalJobsCount = $liveJobs.Count
$queuedJobs = $liveJobs
while ($queuedJobs.Count -gt 0) {
    Start-Sleep -Seconds 60

    $waitingJobs = @()
    $runningJobs = @()
    $completedJobs = @()
    foreach ($job in $queuedJobs) {
        switch ($job.State) {
            "NotStarted" {
                $waitingJobs += $job
            }
            "Running" {
                $runningJobs += $job
            }
            "Completed" {
                $completedJobs += $job
            }
        }
    }

    $completedJobsCount += $completedJobs.Count
    if ($completedJobs.Count -gt 0) {
        $completedJobs | ForEach-Object {
            $curLiveJob = $_
            if ($null -ne $curLiveJob.Instance) {
                $liveJobOutput = $curLiveJob.Instance.EndInvoke($_.AsyncHandle)

                Write-Output ""

                Write-Output "##[section]Live test run for module `"$($curLiveJob.Module)`"."
                $liveJobOutput

                $liveJobStreams = $curLiveJob.Instance.Streams
                if ("" -ne $liveJobStreams.Debug) {
                    Write-Output "##[group]Debug stream for module `"$($curLiveJob.Module)`""
                    $liveJobStreams.Debug | ForEach-Object {
                        Write-Output "##[debug]DEBUG: $_"
                    }
                    Write-Output "##[endgroup]"
                }

                if ("" -ne $liveJobStreams.Error) {
                    $liveJobStreams.Error | ForEach-Object {
                        $_ | Format-List * -Force
                    }
                }
            }
        }
    }

    $queuedJobs = $waitingJobs + $runningJobs

    Write-Output ""

    Write-Output "##[group]Progress of Live Test Jobs"
    Write-Output "##[section]Total jobs: $totalJobsCount"
    Write-Output "##[section]Waiting jobs: $($waitingJobs.Count)"
    Write-Output "##[section]Running jobs: $($runningJobs.Count)"
    Write-Output "##[section]Completed jobs: $completedJobsCount"
    Write-Output "##[section]Max runspaces in the pool: $($rsp.GetMaxRunspaces())"
    Write-Output "##[section]Available runspaces in the pool: $($rsp.GetAvailableRunspaces())"
    $queuedJobs | Select-Object Id, Module, State | Format-Table -AutoSize
    Write-Output "##[endgroup]"
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
