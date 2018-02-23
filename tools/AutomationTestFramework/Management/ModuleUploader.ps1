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

function Upload-ModuleToStorage (
    [hashtable] $storage,
    [string] $modulePath,
    [string] $moduleName) {

    Write-Verbose "Uploading module '$moduleName' to Storage container..."
    $zipName = "$moduleName.zip"
    $now = Get-Date
    $context = (Get-AzureRmStorageAccount -ResourceGroupName $storage.ResourceGroupName -AccountName $storage.AccountName).Context
    $null = Set-AzureStorageBlobContent -Container $storage.ContainerName -File "$modulePath\$zipName" -Blob $zipName -Context $context -Verbose:$false -Force -ErrorAction Stop
    New-AzureStorageBlobSASToken -Container $storage.ContainerName -Blob $zipName -Context $context -Permission rwd -StartTime $now.AddHours(-1) -ExpiryTime $now.AddHours(1) -FullUri -ErrorAction Stop
    Write-Verbose "$zipName uploaded to Storage."
}

function Poll-ModuleProvisionState ([hashtable] $automation, [string[]] $moduleList) {
    $waitSeconds = 10
    $attemptMax = 20
    $attemptCount = 0
    $moduleStatuses = @($moduleList | ForEach-Object { @{Name = $_; Success = $null} })

    Write-Verbose "Checking modules provision state... (Retry total: $attemptMax)"
    while (($attemptCount -lt $attemptMax) -and (($moduleStatuses | Where-Object { $_.Success -eq $null }).Count -gt 0)) {
        if($attemptCount -ne 0) {
            Write-Verbose "Attempt #$attemptCount. Waiting $waitSeconds seconds..."
            Start-Sleep -Seconds $waitSeconds
        }

        foreach ($moduleName in @($moduleStatuses | Where-Object { $_.Success -eq $null } | ForEach-Object { $_.Name })) {
            $provisionState = (Get-AzureRmAutomationModule `
                -AutomationAccountName $automation.AccountName `
                -ResourceGroupName $automation.ResourceGroupName `
                -Name $moduleName `
                -ErrorAction Stop).ProvisioningState

            Write-Verbose "`t$moduleName state: $provisionState"
            $success = $provisionState -eq 'Succeeded'
            if ($success -or ($provisionState -eq 'Failed'))  {
                $index = ($moduleStatuses | ForEach-Object { $_.Name }).IndexOf($moduleName)
                $moduleStatuses[$index].Success = $success
            }
        }
        $attemptCount++
    }
    
    if ($attemptCount -eq $attemptMax) {
        Write-Warning "Provision state polling timed out after $($attemptMax * $waitSeconds) seconds."
    }

    $moduleStatuses
}

function Upload-Modules(
    [hashtable] $automation,
    [hashtable] $storage,
    [hashtable] $signedModules,
    [string] $archiveDir) {
    
    $signedModuleList = $signedModules.Profile + $signedModules.Storage + $signedModules.Other
    $nonSignedModules = @(Get-ChildItem $archiveDir -ErrorAction Stop `
        | ForEach-Object { $_.BaseName } `
        | Where-Object { $signedModuleList -inotcontains $_ })

    @($signedModules.Profile, $signedModules.Storage, ($signedModules.Other + $nonSignedModules)) | ForEach-Object {
        $_ | ForEach-Object {
            $url = Upload-ModuleToStorage `
                -storage $storage `
                -modulePath $archiveDir `
                -moduleName $_ `
            Write-Verbose "Adding module '$_' to Automation account..."
            $null = New-AzureRmAutomationModule `
                -AutomationAccountName $automation.AccountName `
                -ResourceGroupName $automation.ResourceGroupName `
                -Name $_ `
                -ContentLink $url `
                -ErrorAction Stop
            $moduleStatuses = Poll-ModuleProvisionState -automation $automation -moduleList $_

            $failedModules = $moduleStatuses | Where-Object {$_.Success -eq $false} | ForEach-Object { $_.Name }
            if ($failedModules.Count -gt 0) {
                throw "Modules ($failedModules) failed to upload"
            }
        }
    }
    Write-Verbose "Modules have been uploaded successfully."
}