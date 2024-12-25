function Get-OutdatedSubModule {
    param (
        [string]$SourceDirectory,
        [string]$GeneratedDirectory,
        [switch]$ForceRegenerate
    )
    $outdatedSubModule = @()
    $subModuleSource = Get-ChildItem -Path $SourceDirectory -Directory | Foreach-Object { $_.Name } | Where-Object { $_ -match "^*.Autorest$" }
    foreach ($subModule in $subModuleSource) {
        $generateInfoSource = Join-Path $SourceDirectory $subModule "generate-info.json"
        $generateInfoGenerated = Join-Path $GeneratedDirectory $subModule "generate-info.json"
        if (-not (Test-Path $generateInfoSource)) {
            Write-Error "$generateInfoSource was not found!"
            Exit 1
        }
        if (Test-Path $generateInfoGenerated) {
            $generateIdSource = (Get-Content -Path $generateInfoSource | ConvertFrom-Json).generate_Id
            $generateIdGenerated = (Get-Content -Path $generateInfoGenerated | ConvertFrom-Json).generate_Id
            Write-Host "Submodule $subModule generate Id src: $generateIdSource" -ForegroundColor Cyan
            Write-Host "Submodule $subModule generate Id generated: $generateIdGenerated" -ForegroundColor Cyan
            if ($generateIdSource -And $generateIdGenerated -And ($generateIdSource -eq $generateIdGenerated) -And (-not $ForceRegenerate)) {
                continue
            }
        }
        Write-Host "Found outdated submodule: $subModule" -ForegroundColor DarkMagenta
        $outDatedSubModule += $subModule
    }
    return $outDatedSubModule
}

function Get-AllModule {
    param (
        [string]$RepoRoot
    )
    $sourceDirectory = Join-Path $RepoRoot 'src'
    $notModules = @('lib', 'shared', 'helpers')
    $allModule = Get-Childitem -Path $sourceDirectory -Directory | ForEach-Object {
        if ($_.Name -notin $notModules) {
            return $_.Name
        }
    }
    return $allModule
}

function Get-OutdatedModuleFromTargetModule {
    param (
        [string]$RepoRoot,
        [string]$TargetModule,
        [bool]$ForceRegenerate
    )
    $sourceDirectory = Join-Path $RepoRoot 'src'
    $generatedDirectory = Join-Path $RepoRoot 'generated'

    if ('all' -eq $TargetModule) {
        $result = Get-AllModule -RepoRoot $RepoRoot
    } else {
        $result = $TargetModule.Split(',')
    } 
    
    $result = $result | Foreach-Object {
        $moduleRootSource = Join-Path $sourceDirectory $_
        $moduleRootGenerated = Join-Path $generatedDirectory $_
        if (Get-OutdatedSubModule -SourceDirectory $moduleRootSource -GeneratedDirectory $moduleRootGenerated -ForceRegenerate:$ForceRegenerate) {
            return $_
        }
    }
    
    return $result
}

function Get-FilesChangedFromPR {
    param (
        [string]$RepoRoot,
        [string]$TargetBranch
    )
    # refer to https://learn.microsoft.com/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#system-variables-devops-services
      # get the target branch name
      # fetch the targetBranch from origin to local branch and rename the branch to 'origin/base'
      git fetch --no-tags origin "${TargetBranch}:origin/base"
      # refer to https://git-scm.com/docs/git-diff
      # compare the pr and targetBranch branch, get the changed file list
      # diff-filter options are ACDMRT, which are: Added, Copied, Deleted, Modified, Renamed, Changed
      Set-Location $RepoRoot
      $changedFiles = git --no-pager diff --name-only --diff-filter=ACDMRT origin/base -- .
      Write-Host "Total updated files:" $changedFiles.Count
      Write-Host "All Updated files:"
      $changedFiles | Foreach-Object {Write-Host $_}
      return $changedFiles
}

function Get-FilesChangedFromCommit {
    param (
        [string]$Owner = "Azure",
        [string]$Repository = "azure-powershell",
        [string]$CommitId,
        [string]$AccessToken
    )
    $uri = "https://api.github.com/repos/$Owner/$Repository/commits/$CommitId"
    $Headers = @{ "Accept" = "application/vnd.github+json"; "Authorization" = "Bearer $AccessToken"; "X-GitHub-Api-Version" = "2022-11-28" }
    $response = Invoke-WebRequest -Uri $uri -Headers $Headers -Method GET
    $response | Foreach-Object { Write-Warning $_ }

    $response | ConvertFrom-Json | Select-Object -ExpandProperty files | ForEach-Object { Write-Warning $_.filename }
    Write-Warning "********************************exit now********************************"
    # exit 1
}