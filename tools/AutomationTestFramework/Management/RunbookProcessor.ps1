# ----------------------------------------------------------------------------------
    # Copyright Microsoft Corporation
    # Licensed under the Apache License, Version 2.0 (the "License");
    # you may not use this file except in compliance with the License.
    # You may obtain a copy of the License at
    # http://www.apache.org/licenses/LICENSE-2.0
    # Unless required by applicable law or agreed to in writing, software
    # distributed under the License is distributed on an "AS IS" BASIS,
    # WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    # See the License for the specific language governing permissions and
    # limitations under the License.
# ----------------------------------------------------------------------------------

. "$PSScriptRoot\TestExplorer.ps1"

function Create-TestContent([string] $path, [string] $tag = 'SmokeTest') {
    $testFiles = Filter-TestFiles $path
    if ($testFiles.Count -eq 0) {
        '# No test files found'
        '$testFile = @()'
        return
    }

    $variableList = New-Object System.Collections.ArrayList
    $sessionFunctions = Get-ChildItem function:
    foreach ($testFile in $testFiles) {
        # Get the function list from the script file
        . "$testFile"
        # https://sqljana.wordpress.com/2015/09/23/perform-set-operations-union-intersection-minus-complement-using-powershell/
        $scriptFunctions = Get-ChildItem function: | Where-Object { $sessionFunctions -inotcontains $_ }
        $testFunctions = $scriptFunctions | Where-Object { 
                $desc = (Get-Help $_).Description
                $_.Name -ilike 'Test*' -and $desc -ne $null -and $desc[0].Text -contains $tag
            }
        $scriptFunctions | ForEach-Object { Remove-Item function:\$_ }
       
        if ($testFunctions.Count -eq 0) {
            "# $testFile`: No tests found"
            continue
        }

        $null = $variableList.Add($testFile.BaseName)
        "# $testFile"
        "`$$($testFile.BaseName) = @("
        for ($i = 0; $i -lt $testFunctions.Count; $i++) {
            $testSuffix = if($i -eq $testFunctions.Count - 1) { ' )' } else { ',' }
            "`t'$($testFunctions[$i])'$testSuffix"
        }
    }

    $testListSuffix = if($variableList.Count -eq 0) { ' @()' } else { '' }
    "`$testList =$testListSuffix"
    for ($i = 0; $i -lt $variableList.Count; $i++) {
        $varSuffix = if($i -eq $variableList.Count - 1) { '' } else { ' +' }
        "`t`$$($variableList[$i])$varSuffix"
    }
}

function Create-Runbooks (
    [hashtable] $template,
    [string] $srcPath,
    [string[]] $projectList,
    [string] $outputPath) {

    if (-not (Test-Path $outputPath)) {
        $null = New-Item -ItemType directory -Path $outputPath -ErrorAction Stop
    } else { 
        Write-Verbose "Cleaning up the $outputPath folder..."
        Remove-Item "$outputPath\*" -ErrorAction Stop
    }
    Write-Verbose "Collecting .ps1 test files..."
    foreach($folder in Get-TestFolders $srcPath $projectList) {
        $bookName = "Live$($folder.Name)Tests"
        $bookPath = "$outputPath\$bookName.ps1"
        $null = New-Item $bookPath -type file -Force
        $loginParamsTemplate = '%LOGIN-PARAMS%'
        $testListTemplate = '%TEST-LIST%'
        Get-Content $template.Path | ForEach-Object {
            $content = switch -wildcard ($_) {
                "*$loginParamsTemplate" {
                    $_ -replace $loginParamsTemplate, "'$($template.AutomationConnectionName)' '$($template.SubscriptionName)'"
                } $testListTemplate {
                    Create-TestContent $folder.Path | Out-String
                } default {
                    $_
                }
            }
            $content | Add-Content $bookPath
        }
        Write-Verbose "$bookPath generated."
    }
}

function Start-Runbooks ([hashtable] $automation, [string] $runbooksPath) {
    foreach ($runbook in Get-ChildItem $runbooksPath) {
        $bookName = $runbook.BaseName
        Write-Verbose "Uploading '$bookName' runbook..."
        $null = Import-AzAutomationRunbook -Path $runbook.FullName -Name $bookName -type PowerShell -AutomationAccountName $automation.AccountName -ResourceGroupName $automation.ResourceGroupName -LogVerbose $true -Force -ErrorAction Stop
        Write-Verbose "Publishing '$bookName' runbook..."
        $null = Publish-AzAutomationRunbook -Name $bookName -AutomationAccountName $automation.AccountName -ResourceGroupName $automation.ResourceGroupName -ErrorAction Stop
        
        Start-Job -Name $bookName -ArgumentList (Get-AzContext),$bookName,$automation -ScriptBlock { 
            param ($context,$bookName,$automation) 
            Start-AzAutomationRunbook -DefaultProfile $context -Name $bookName -AutomationAccountName $automation.AccountName -ResourceGroupName $automation.ResourceGroupName -ErrorAction Stop -Wait -MaxWaitSeconds 3600
        }
        Write-Verbose "$bookName started."
    }
}

function Wait-RunbookResults ([hashtable] $automation, $jobs) {
    Write-Verbose 'Waiting for runbooks to complete...'
    $failedJobs = $jobs | Wait-Job | ForEach-Object {
        $name = $_.Name
        # https://stackoverflow.com/a/8751271/294804
        $state = $_.State
        $output = $_ | Receive-Job -Keep
        $jobId = @($output | Where-Object { $_ -like 'JobId:*' } | Select-Object -First 1) -replace 'JobId:','' | Out-String
        $failureCount = @($output | Where-Object { $_ -like '!!!*' } | Measure-Object -Line).Lines
        # https://blogs.msdn.microsoft.com/powershell/2009/12/04/new-object-psobject-property-hashtable/
        New-Object PSObject -Property @{Name = $name; State = $state; JobId = $jobId; FailureCount = $failureCount}
    } | Where-Object { $_.FailureCount -ge 1 -or $_.State -eq 'Failed' }
    
    $success = ($failedJobs | Measure-Object).Count -eq 0
    if($success){
        Write-Verbose 'All tests succeeded!'
        return $success
    } else {
        Write-Verbose "Failed test suites: $(($failedJobs | ForEach-Object {$_.Name}) -join ',')"
    }

    $resultsPath = "$PSScriptRoot\..\Results"
    if (-not (Test-Path $resultsPath)) {
        $null = New-Item -ItemType Directory -Path $resultsPath -ErrorAction Stop
    } else { 
        Write-Verbose "Cleaning up the $resultsPath folder..."
        Remove-Item "$resultsPath\*" -Recurse -Force -ErrorAction Stop
    }

    foreach($failedJob in $failedJobs) {
        if($failedJob.State -eq 'Failed') {
            Write-Verbose "$($failedJob.Name) failed to complete the Runbook job. No results can be created."
            continue
        }
        Write-Verbose "Gathering $($failedJob.Name) suite logs..."
        $streams = Get-AzAutomationJobOutput `
            -id $failedJob.JobId `
            -ResourceGroupName $automation.ResourceGroupName `
            -AutomationAccountName $automation.AccountName `
            -Stream Any `
        | Where-Object {$_.Summary.Length -gt 0} `
        | Get-AzAutomationJobOutputRecord
        
        $suitePath = Join-Path $resultsPath $failedJob.Name
        if (-not (Test-Path $suitePath)) {
            $null = New-Item -ItemType Directory -Path $suitePath -ErrorAction Stop
        }
        foreach($stream in $streams) {
            $content = switch ($stream.Type) {
                'Output' {
                    $stream.Value.value
                } 'Error' {
                    $stream.Value.Exception
                    $stream.Value.ScriptStackTrace
                } 'Warning' {
                    $stream.Value.Message
                    $stream.Value.InvocationInfo
                } default {
                    $stream.Value.Message
                }
            }
            $filePath = Join-Path $suitePath "$($stream.Type).txt"
            if (-not (Test-Path $filePath)) {
                $null = New-Item -type File -Path $filePath -Force -ErrorAction Stop
            }
            $content | Add-Content -Path $filePath
        }
        Write-Verbose "$($failedJob.Name) logs created."
    }

    $success
}