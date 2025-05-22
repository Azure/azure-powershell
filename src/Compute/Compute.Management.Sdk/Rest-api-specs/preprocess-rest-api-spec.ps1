# Script to preprocess REST API spec files
# 1. Remove all "x-ms-examples" sections from paths and x-ms-paths
# 2. Replace references to common-types/resource-management/v3/types.json and common-types/v1/common.json
# 3. Simplify 202 responses for specific operations by removing headers and using a standard format

# List of operations that need simplified 202 responses
$operationsToModify = @(
    "AvailabilitySets_ConvertToVirtualMachineScaleSet",
    "AvailabilitySets_ConvertToVirtualMachineScaleSet",
    "CapacityReservations_Delete",
    "CapacityReservations_Update",
    "DedicatedHosts_Delete",
    "DiskAccesses_CreateOrUpdate",
    "DiskAccesses_Delete",
    "DiskAccesses_DeleteAPrivateEndpointConnection",
    "DiskAccesses_Update",
    "DiskAccesses_UpdateAPrivateEndpointConnection",
    "DiskEncryptionSets_CreateOrUpdate",
    "DiskEncryptionSets_Delete",
    "DiskEncryptionSets_Update",
    "DiskRestorePoint_GrantAccess",
    "DiskRestorePoint_RevokeAccess",
    "Disks_CreateOrUpdate",
    "Disks_Delete",
    "Disks_GrantAccess",
    "Disks_RevokeAccess",
    "Disks_Update",
    "Galleries_CreateOrUpdate",
    "Galleries_Delete",
    "GalleryApplicationVersions_CreateOrUpdate",
    "GalleryApplicationVersions_Delete",
    "GalleryApplications_CreateOrUpdate",
    "GalleryApplications_Delete",
    "GalleryImageVersions_CreateOrUpdate",
    "GalleryImageVersions_Delete",
    "GalleryImages_CreateOrUpdate",
    "GalleryImages_Delete",
    "GallerySharingProfile_Update",
    "Images_Delete",
    "LogAnalytics_ExportRequestRateByInterval",
    "LogAnalytics_ExportThrottledRequests",
    "RestorePointCollections_Delete",
    "RestorePoints_Delete",
    "Snapshots_CreateOrUpdate",
    "Snapshots_Delete",
    "Snapshots_GrantAccess",
    "Snapshots_RevokeAccess",
    "Snapshots_Update",
    "VirtualMachineExtensions_Delete",
    "VirtualMachineRunCommands_Delete",
    "VirtualMachineScaleSetExtensions_Delete",
    "VirtualMachineScaleSetRollingUpgrades_Cancel",
    "VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade",
    "VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade",
    "VirtualMachineScaleSetVMExtensions_Delete",
    "VirtualMachineScaleSetVMRunCommands_Delete",
    "VirtualMachineScaleSetVMs_Deallocate",
    "VirtualMachineScaleSetVMs_Delete",
    "VirtualMachineScaleSetVMs_PerformMaintenance",
    "VirtualMachineScaleSetVMs_PowerOff",
    "VirtualMachineScaleSetVMs_Redeploy",
    "VirtualMachineScaleSetVMs_Reimage",
    "VirtualMachineScaleSetVMs_ReimageAll",
    "VirtualMachineScaleSetVMs_Restart",
    "VirtualMachineScaleSetVMs_RunCommand",
    "VirtualMachineScaleSetVMs_Start",
    "VirtualMachineScaleSetVMs_Update",
    "VirtualMachineScaleSets_Deallocate",
    "VirtualMachineScaleSets_Delete",
    "VirtualMachineScaleSets_DeleteInstances",
    "VirtualMachineScaleSets_PerformMaintenance",
    "VirtualMachineScaleSets_PowerOff",
    "VirtualMachineScaleSets_Redeploy",
    "VirtualMachineScaleSets_Reimage",
    "VirtualMachineScaleSets_ReimageAll",
    "VirtualMachineScaleSets_Restart",
    "VirtualMachineScaleSets_SetOrchestrationServiceState",
    "VirtualMachineScaleSets_Start",
    "VirtualMachineScaleSets_UpdateInstances",
    "VirtualMachines_AssessPatches",
    "VirtualMachines_Capture",
    "VirtualMachines_ConvertToManagedDisks",
    "VirtualMachines_Deallocate",
    "VirtualMachines_Delete",
    "VirtualMachines_InstallPatches",
    "VirtualMachines_PerformMaintenance",
    "VirtualMachines_PowerOff",
    "VirtualMachines_Reapply",
    "VirtualMachines_Redeploy",
    "VirtualMachines_Reimage",
    "VirtualMachines_Restart",
    "VirtualMachines_RunCommand",
    "VirtualMachines_Start",
    "VirtualMachines_migrateToVMScaleSet"
)

Get-ChildItem -Path . -Filter *.json -Recurse | ForEach-Object {
    $filePath = $_.FullName
    Write-Host "Processing $filePath"
    
    # First read the file as text to perform string replacements for $ref paths
    $content = Get-Content $filePath -Raw
    
    # Replace references to types.json
    $content = $content -replace '"\$ref"\s*:\s*"../../../../../../common-types/resource-management/v3/types.json', '"$ref": "./types.json'
    
    # Replace references to common.json
    $content = $content -replace '"\$ref"\s*:\s*"../../../common-types/v1/common.json', '"$ref": "./common.json'
    
    # Convert to JSON for structured manipulation
    $json = $content | ConvertFrom-Json
    
    # Remove x-ms-examples sections from paths
    if ($json.paths) {
        foreach ($pathKey in $json.paths.PSObject.Properties.Name) {
            $pathObj = $json.paths.$pathKey
            foreach ($methodKey in $pathObj.PSObject.Properties.Name) {
                $methodObj = $pathObj.$methodKey
                if ($methodObj.PSObject.Properties['x-ms-examples']) {
                    $methodObj.PSObject.Properties.Remove('x-ms-examples')
                }
                
                # Check if this is an operation that needs to be modified
                if ($methodObj.operationId -and $operationsToModify -contains $methodObj.operationId) {
                    Write-Host "  Modifying 202 response for operation: $($methodObj.operationId)"
                    
                    # Check if it has a 202 response
                    if ($methodObj.responses.PSObject.Properties['202']) {
                        # Create a new simplified 202 response
                        $simplifiedResponse = New-Object PSObject
                        Add-Member -InputObject $simplifiedResponse -MemberType NoteProperty -Name "description" -Value "Accepted"
                        
                        # Replace the existing 202 response
                        $methodObj.responses.PSObject.Properties.Remove('202')
                        Add-Member -InputObject $methodObj.responses -MemberType NoteProperty -Name "202" -Value $simplifiedResponse
                    }
                }
            }
        }
    }

    # Remove x-ms-examples sections from x-ms-paths
    if ($json.'x-ms-paths') {
        foreach ($pathKey in $json.'x-ms-paths'.PSObject.Properties.Name) {
            $pathObj = $json.'x-ms-paths'.$pathKey
            foreach ($methodKey in $pathObj.PSObject.Properties.Name) {
                $methodObj = $pathObj.$methodKey
                if ($methodObj.PSObject.Properties['x-ms-examples']) {
                    $methodObj.PSObject.Properties.Remove('x-ms-examples')
                }
                
                # Check if this is an operation that needs to be modified
                if ($methodObj.operationId -and $operationsToModify -contains $methodObj.operationId) {
                    Write-Host "  Modifying 202 response for operation: $($methodObj.operationId)"
                    
                    # Check if it has a 202 response
                    if ($methodObj.responses.PSObject.Properties['202']) {
                        # Create a new simplified 202 response
                        $simplifiedResponse = New-Object PSObject
                        Add-Member -InputObject $simplifiedResponse -MemberType NoteProperty -Name "description" -Value "Accepted"
                        
                        # Replace the existing 202 response
                        $methodObj.responses.PSObject.Properties.Remove('202')
                        Add-Member -InputObject $methodObj.responses -MemberType NoteProperty -Name "202" -Value $simplifiedResponse
                    }
                }
            }
        }
    }
    
    # Save the modified JSON back to the file
    $json | ConvertTo-Json -Depth 100 | Set-Content $filePath
    Write-Host "Completed processing $filePath"
}

Write-Host "All files have been preprocessed successfully."