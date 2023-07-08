if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevDevBox'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevDevBox.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevDevBox' {
    It 'List' -skip {
        $listOfDevBoxes = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint
        $listOfDevBoxes.Count | Should -Be 2

        $listOfDevBoxes = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -UserId $env.userObjectId
        $listOfDevBoxes.Count | Should -Be 2

        $listOfDevBoxes = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me"
        $listOfDevBoxes.Count | Should -Be 1


        $listOfDevBoxes = Get-AzDevCenterDevDevBox -DevCenter $env.devCenterName
        $listOfDevBoxes.Count | Should -Be 2

        $listOfDevBoxes = Get-AzDevCenterDevDevBox -DevCenter $env.devCenterName -UserId "me"
        $listOfDevBoxes.Count | Should -Be 2

        $listOfDevBoxes = Get-AzDevCenterDevDevBox -DevCenter $env.devCenterName -ProjectName $env.projectName2 -UserId $env.userObjectId
        $listOfDevBoxes.Count | Should -Be 1
    
    }

    It 'Get' -skip {
        $devbox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId $env.userObjectId -Name $env.devboxName

        $devbox.Name | Should -Be $env.devboxName
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 64
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"

        $devbox = Get-AzDevCenterDevDevBox -DevCenter $env.devCenterName -ProjectName $env.projectName -UserId "me" -Name $env.devboxName

        $devbox.Name | Should -Be $env.devboxName
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 64
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"
    
    }

    It 'GetViaIdentity' -skip {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName}
        $devbox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -InputObject $devBoxInput

        $devbox.Name | Should -Be $env.devboxName
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 64
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"

        $devbox = Get-AzDevCenterDevDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput 

        $devbox.Name | Should -Be $env.devboxName
        $devBox.User | Should -Be $env.userObjectId
        $devBox.ProjectName | Should -Be $env.projectName
        $devBox.poolName | Should -Be $env.poolName
        $devBox.OSType | Should -Be "Windows"
        $devBox.OSDiskSizeGb | Should -Be "1024"
        $devBox.Location | Should -Be $env.location
        $devBox.LocalAdministrator | Should -Be "Enabled"
        $devBox.ImageReferenceVersion | Should -Be "1.0.0"
        $devBox.HibernateSupport | Should -Be "Enabled"
        $devBox.ImageReferenceName | Should -Be $env.imageName
        $devBox.HardwareProfileVCpUs | Should -Be 8
        $devBox.HardwareProfileMemoryGb | Should -Be 64
        $devBox.HardwareProfileSkuName | Should -Be $env.skuName
        $devBox.ImageReferenceOSBuildNumber | Should -Be "win11-22h2-ent-cpc-os"
        $devBox.ImageReferenceOperatingSystem | Should -Be "Windows11"
        $devBox.ProvisioningState | Should -Be "Succeeded"
        $devBox.PowerState | Should -Be "Running"
     }
}
