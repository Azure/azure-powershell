#Requires -Modules AzureRM.BootStrapper
$global:testProfileMap = "{`"Profile1`": { `"Module1`": [`"1.0`", `"0.1`"], `"Module2`": [`"1.0`", `"0.2`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 

Describe "Get-ProfileCachePath" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Test-Path -Verifiable { $false }
        Mock New-Item -Verifiable {}
        Context "Windows OS Admin" {
            $IsWindows = $true
            $Script:IsAdmin = $true
            It "Should return ProgramData path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains("ProgramData") | Should Be $true
                Assert-VerifiableMock
            }
        }

        Context "Windows OS Non-Admin" {
            $IsWindows = $true
            $Script:IsAdmin = $false
            It "Should return LOCALAPPDATA path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains("AppData\Local") | Should Be $true
                Assert-VerifiableMock            
            }            
        }

        Context "Linux OS Admin" {
            $IsWindows = $false
            $Script:IsCoreEdition = $true
            It "Should return .config path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains(".config") | Should Be $true
                Assert-VerifiableMock
            }
        }

        # Cleanup
        $Script:IsCoreEdition = ($PSVersionTable.PSEdition -eq 'Core')
        $script:IsAdmin = $false
        if ((-not $Script:IsCoreEdition) -or ($IsWindows))
        {
            If (([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
            {
                $script:IsAdmin = $true
            }
        }
        else {
            # on Linux, tests run via sudo will generally report "root" for whoami
            if ( (whoami) -match "root" ) 
            {
                $script:IsAdmin = $true
            }
        }
    }
}

Describe "Get-LatestProfileMapPath" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { "foo\bar" }

        Context "ProfileCache is empty/no profilemaps available" {
            Mock Get-ChildItem -Verifiable { $null }
            It "Should return null" {
                Get-LatestProfileMapPath | Should be $null
                Assert-VerifiableMock
            }
        }

        context "Largest number did not exist" {
            Mock Get-LargestNumber -Verifiable { $null }
            Mock Get-ChildItem -Verifiable { "foo" }
            It "Should return null" {
                Get-LatestProfileMapPath | Should be $null
                Assert-VerifiableMock
            }
        }

        Context "Two profile maps available at profile cache" {
            $profilemap1 = New-Object -TypeName PSObject 
            $profilemap1 | Add-Member NoteProperty -Name "Name" -Value '123-pmap1.json'
            $profilemap2 = New-Object -TypeName PSObject 
            $profilemap2 | Add-Member NoteProperty -Name "Name" -Value '42-pmap2.json'
            Mock Get-ChildItem -Verifiable { @($profilemap1, $profilemap2)}
            Mock Get-LargestNumber -Verifiable { 123 }
            It "Should return Latest map" {
                Get-LatestProfileMapPath | Should Be $profilemap1
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-LargestNumber" {
    InModuleScope AzureRM.BootStrapper {
        Context "Profile cache is empty" {
            Mock Get-ChildItem -Verifiable { }
            It "Should return null" {
                Get-LargestNumber | Should Be $null
            }
        }

        Context "ProfileMaps weren't numbered" {
            $profilemap1 = New-Object -TypeName PSObject 
            $profilemap1 | Add-Member NoteProperty -Name "Name" -Value 'pmap1.json'
            $profilemap2 = New-Object -TypeName PSObject 
            $profilemap2 | Add-Member NoteProperty -Name "Name" -Value 'pmap2.json'
            Mock Get-ChildItem -Verifiable { @($profilemap1, $profilemap2) }
            It "Should return null" {
                Get-LargestNumber | Should Be $null
            }
        }

        Context "Two numbered Profiles were returned" {
            $profilemap1 = New-Object -TypeName PSObject 
            $profilemap1 | Add-Member NoteProperty -Name "Name" -Value '123-pmap1.json'
            $profilemap2 = New-Object -TypeName PSObject 
            $profilemap2 | Add-Member NoteProperty -Name "Name" -Value '456-pmap2.json'
            Mock Get-ChildItem -Verifiable { @($profilemap1, $profilemap2) }
            It "Should return largest number" {
                Get-LargestNumber | Should Be 456
            }
        }
    }
}

Describe "Get-AzureStorageBlob" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Invoke-WebRequest is properly made" {
            $response = New-Object -TypeName psobject
            $response | Add-Member -MemberType NoteProperty -Name "StatusCode" -Value "200"
            $response | Add-Member -MemberType NoteProperty -Name "Content" -Value "ProfileMap json"
            Mock Invoke-CommandWithRetry -Verifiable { $response }
            It "Returns proper response" {
                $result = Get-AzureStorageBlob
                $result.Content | Should Not Be $null
                $result.StatusCode | Should Be "200"
                Assert-VerifiableMock
            }
        }

        Context "Invoke-WebRequest threw exception at all retries" {
            Mock Invoke-CommandWithRetry -Verifiable { throw }
            It "Throws exception" {
                { Get-AzureStorageBlob } | Should throw 
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-AzureProfileMap" {
    InModuleScope AzureRM.Bootstrapper {
        $script:LatestProfileMapPath = New-Object -TypeName PSObject
        $script:LatestProfileMapPath | Add-Member NoteProperty -Name "FullName" -Value "C:\mock\123-MockETag.json"
        Mock Get-ProfileCachePath -Verifiable { return "MockPath\ProfileCache"}
        $WebResponse = New-Object -TypeName PSObject 
        $Header = @{"Headers" = @{"ETag" = "MockETag"}}
        $WebResponse | Add-Member $Header
        Mock Get-AzureStorageBlob -Verifiable { return $WebResponse }
        Mock Invoke-CommandWithRetry -Verifiable { ($testProfileMap | ConvertFrom-Json) }

        Context "ProfileCachePath Exists and Etags are equal" {
            Mock Test-Path -Verifiable { $true }
            It "Returns Correct ProfileMap" {
                $result = Get-AzureProfileMap
                $result.Profile1 | Should Not Be Empty
                $result.Profile2 | Should Not Be Empty
                Assert-VerifiableMock
            }
        }

        Context "ProfileCachePath Exists and ETags are different" {
            Mock Out-File -Verifiable {}
            $script:LatestProfileMapPath.FullName =  "123-MockedDifferentETag.json" 
            Mock RetrieveProfileMap -Verifiable {$global:testProfileMap | ConvertFrom-Json}
            Mock Get-LargestNumber -Verifiable {}
            $ProfileMapPath = New-Object -TypeName  PSObject
            $ProfileMapPath | Add-Member NoteProperty 'FullName' -Value '124-MockedDifferentETag.json'
            Mock Get-ChildItem -Verifiable { @($ProfileMapPath)}
            Mock Test-Path -Verifiable { $true }

            It "Returns Correct ProfileMap and removes old profilemap" {
                $result = Get-AzureProfileMap
                $result.Profile1 | Should Not Be Empty
                $result.Profile2 | Should Not Be Empty
                Assert-VerifiableMock
            }
        }

        Context "Get-AzureStorageBlob throws exception" {
            Mock Get-AzureStorageBlob { throw [System.Net.WebException] }
            Mock Test-Path -Verifiable { $true }
            It "Throws Web Exception" {
                { Get-AzureProfileMap } | Should throw 
            }
        }
    }
}

Describe "RetrieveProfileMap" {
    InModuleScope AzureRM.Bootstrapper {
        Context "WebResponse content has extra line breaks" {
            $WebResponse = "{`n`"Profile1`":`t { `"Module1`": [`"1.0`"], `n`"Module2`": [`"1.0`"] }, `"Profile2`": `n{ `"Module1`": [`"2.0`", `"1.0`"],`n `r`"Module2`": `t[`"2.0`"] }}" 
            It "Should return proper profile map" {
                (RetrieveProfileMap -WebResponse $WebResponse) -like ($global:testProfileMap | ConvertFrom-Json) | Should Be $true
            }
        }

        Context "WebResponse content has no extra line breaks" {
            $WebResponse = $global:testProfileMap
            It "Should return proper profile map" {
                (RetrieveProfileMap -WebResponse $WebResponse) -like ($global:testProfileMap | ConvertFrom-Json) | Should Be $true
            }
            
        }
    }
}

Describe Get-AzProfile {
    InModuleScope AzureRM.Bootstrapper {
        
        Context "Forces update from Azure Endpoint" {
            Mock Get-AzureProfileMap { ($testProfileMap | ConvertFrom-Json) }
            It "Should get ProfileMap from Azure Endpoint" {
                $result = Get-AzProfile -Update  
                $result.Profile1 | Should Not Be Empty
                $result.Profile2 | Should Not Be Empty
            }
            It "Checks Mock calls to Get-AzureProfileMap" {
                Assert-MockCalled Get-AzureProfileMap -Exactly 1
            }
        }
        
        Context "Gets Azure ProfileMap from Cache" {
            $script:LatestProfileMapPath = New-Object -TypeName PSObject
            $script:LatestProfileMapPath | Add-Member NoteProperty -Name "FullName" -Value "C:\mock\MockETag.json"
            Mock Invoke-CommandWithRetry -Verifiable { $global:testProfileMap | ConvertFrom-Json }
            Mock Test-Path -Verifiable { $true }
            It "Should get ProfileMap from Cache" {
                $result = Get-AzProfile 
                $result.Profile1 | Should Not Be Empty
                $result.Profile2 | Should Not Be Empty
                Assert-VerifiableMock
            }
        }

        Context "ProfileMap is not available from cache" {
            Mock Test-Path -Verifiable { $false }
            Mock Invoke-CommandWithRetry -Verifiable { return $global:testProfileMap  | ConvertFrom-Json}
            It "Should get ProfileMap from Embedded source" {
                $result = Get-AzProfile 
                $result.Profile1 | Should Not Be Empty
                $result.Profile2 | Should Not Be Empty
                Assert-VerifiableMock
            }
        }

        Context "ProfileMap is not available in cache or Embedded source" {
            Mock Test-Path -Verifiable { $false }
            Mock Invoke-CommandWithRetry -Verifiable {}

            It "Should throw FileNotFound Exception" {
                { Get-AzProfile } | Should Throw
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-ProfilesInstalled" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Valid ProfileMap and Invoke with IncompleteProfiles parameter" {
            # Arrange
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -le 4)
                {
                    return $moduleObj
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Get-Module -MockWith $mockTestPath

            $IncompleteProfiles = @()
            $expected = @{'Profile1'= @{'Module1' = @('1.0') ;'Module2'= @('1.0')}}
            
            # Act
            $result = (Get-ProfilesInstalled -ProfileMap ($global:testProfileMap | ConvertFrom-Json) ([REF]$IncompleteProfiles))
            
            # Assert
            It "Should return profiles installed" {
                $expected -like $result | Should Be $true
            }
            It "Should return Incomplete profiles" {
                $incompleteprofiles[0] -eq 'Profile2' | Should Be $true
            }
        }

        Context "No profiles Installed and invoke without IncompleteProfiles parameter" {
            Mock Get-Module -Verifiable {}
            It "Should return empty" {
                $result = (Get-ProfilesInstalled -ProfileMap ($global:testProfileMap | ConvertFrom-Json))
                $result.count | Should Be 0
            }
        }
        
        Context "Null ProfileMap" {
            It "Should throw exception" {
                { Get-ProfilesInstalled -ProfileMap $null } | Should Throw
            }
        }
    }    
}

Describe "Test-ProfilesInstalled" {
    InModuleScope AzureRm.Bootstrapper {
        Context "Profile associated with Module version is installed" {
            $AllProfilesInstalled = @{'Module11.0'= @('Profile1', 'Profile2'); 'Module22.0'= @('Profile2')}
            It "Should return ProfilesAssociated" {
                $Result = (Test-ProfilesInstalled -version 1.0 -Module 'Module1' -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -AllProfilesInstalled $AllProfilesInstalled)
                $Result[0] | Should Be 'Profile1'
            }
        }

        Context "Profile associated with Module version is not installed" {
                $AllProfilesInstalled = @{'Module11.0'= @('Profile1', 'Profile2')}
                It "Should return empty array" {
                $Result = (Test-ProfilesInstalled -version 1.0 -Module 'Module2' -Profile 'Profile2' -PMap ($global:testProfileMap | ConvertFrom-Json) -AllProfilesInstalled $AllProfilesInstalled)
                $Result.Count | Should Be 0

            }
        }
    }
}

Describe "Uninstall-ModuleHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Remove-Module -Verifiable { }
        Mock Uninstall-Module -Verifiable { }
        Context "Modules are installed" {
            # Arrange
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return $moduleObj
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Get-Module -MockWith $mockTestPath

            It "Should call Remove-Module and Uninstall-Module" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0' -Profile 'Profile1' -RemovePreviousVersions
                $Script:mockCalled | Should Be 2
                Assert-VerifiableMock
            } 
        }

        Context "Modules are not installed" {
            Mock Get-Module -Verifiable {}
            It "Should not call Remove-Module or Uninstall-Module" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0' -Profile 'Profile1'
                Assert-MockCalled Remove-Module -Exactly 0
                Assert-MockCalled Uninstall-Module -Exactly 0
            }
        }

        Context "Uninstall-Module threw error" {
            # Arrange
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Path" -Value "TestPath"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return $moduleObj
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Get-Module -MockWith $mockTestPath
            Mock Uninstall-Module -Verifiable { throw "No match was found for the specified search criteria and module names" }
            It "Should write error 'custom directory' to error pipeline" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0' -Profile 'Profile1' -RemovePreviousVersions -ErrorVariable ev -ea SilentlyContinue 
                ($null -ne ($ev -match "If you installed the module to a custom directory in your path")) | Should be $true
                $Script:mockCalled | Should Be 1
                Assert-VerifiableMock
            }
        }

        Context "Uninstall-Module threw error MSI Install" {
            # Arrange
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Path" -Value "${env:ProgramFiles(x86)}\Microsoft SDKs\Azure\PowerShell\"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return $moduleObj
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Get-Module -MockWith $mockTestPath
            Mock Uninstall-Module -Verifiable { throw "No match was found for the specified search criteria and module names" }
            It "Should write error 'msi' to error pipeline" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0' -Profile 'Profile1' -RemovePreviousVersions -ErrorVariable ev -ea SilentlyContinue 
                ($ev -match "If you installed via an MSI") | Should not be $null
                $Script:mockCalled | Should Be 1
                Assert-VerifiableMock
            } 
        }

        Context "Uninstall-Module threw error In Use" {
            # Arrange
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Path" -Value "TestPath"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return $moduleObj
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Get-Module -MockWith $mockTestPath
            Mock Uninstall-Module -Verifiable { throw "The module is currently in use" }
            It "Should write error 'in use' to error pipeline" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0' -Profile 'Profile1' -RemovePreviousVersions -ErrorVariable ev -ea SilentlyContinue 
                ($ev -match "The module is currently in use") | Should not be $null
                $Script:mockCalled | Should Be 1
                Assert-VerifiableMock
            } 
        }
    }
}

Describe "Uninstall-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AllProfilesInstalled -Verifiable {}
        Mock Invoke-UninstallModule -Verifiable {}

        Context "Profile associated with the module is installed" {
            It "Should call Invoke-UninstallModule: With Force param" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -Force
                Assert-VerifiableMock
                Assert-MockCalled Invoke-UninstallModule -Exactly 4
            }
        }

         Context "Profile associated with the module is installed" {
           It "Should call Invoke-UninstallModule: Without Force param" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) 
                Assert-VerifiableMock
                Assert-MockCalled Invoke-UninstallModule -Exactly 4
            }
        }
    }
}

Describe "Invoke-UninstallModule" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Module not associated with any other profile" {
            Mock Test-ProfilesInstalled -Verifiable { 'profile1'}
            Mock Uninstall-ModuleHelper -Verifiable {}
            It "Should Call Uninstall module helper" {
                Invoke-UninstallModule -PMap ($global:testProfileMap | ConvertFrom-Json) -Profile 'profile1' -module 'module1'
                Assert-VerifiableMock
            }
        }

        Context "Module associated with more than one profile" {
            Mock Test-ProfilesInstalled -Verifiable { @('Profile1', 'Profile2')}
            Mock Uninstall-ModuleHelper {}
            It "Should not invoke Uninstall module helper" {
                Invoke-UninstallModule -PMap ($global:testProfileMap | ConvertFrom-Json) -Profile 'profile1' -module 'module1'
                Assert-MockCalled Uninstall-ModuleHelper -Exactly 0
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Remove-PreviousVersion" {
    InModuleScope AzureRM.Bootstrapper {
        $AllProfilesInstalled = @{}
        Context "Previous versions are installed" {
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "0.1" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj}
            Mock Import-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -LatestMap ($global:testProfileMap|ConvertFrom-Json) 
                Assert-VerifiableMock
            }

            It "Invoke with Module parameter: Should call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -Module 'Module1' -LatestMap ($global:testProfileMap|ConvertFrom-Json) 
                Assert-VerifiableMock                
            }
        }

        Context "Previous versions are not installed" {
            Mock Get-Module -Verifiable {}
            Mock Import-Module -Verifiable {}
            Mock Invoke-UninstallModule {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-VerifiableMock
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "No previous versions" {
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            Mock Import-Module -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile2' -module 'Module2' -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "Previous version is same as the latest version" {
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            Mock Import-Module -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile2' -module 'Module2' -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
                Assert-MockCalled Import-Module -Times 1
            }
        }
    }
}

Describe "Get-AllProfilesInstalled" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Invoke-CommandWithRetry { $global:testProfileMap | ConvertFrom-Json }
        Context "Profile Maps are available from cache" {
            Mock Get-ProfilesInstalled -Verifiable { @{'Profile1'= @{'Module1'= '1.0'}}}
            $expectedResult = @{"Module21.0"=@('Profile1'); "Module11.0"=@('Profile1')}
            It "Should return Modules & Profiles Installed" {
                (Get-AllProfilesInstalled) -like $expectedResult | Should Be $true
                Assert-MockCalled Invoke-CommandWithRetry -Exactly 1
                Assert-MockCalled Get-ProfilesInstalled -exactly 1
                Assert-VerifiableMock
            }
        }

        Context "Profiles are not installed" {
            Mock Get-ProfilesInstalled -Verifiable {}
            
            It "Should return empty" {
                $AllProfilesInstalled = @()
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled Invoke-CommandWithRetry -Exactly 1
                Assert-MockCalled Get-ProfilesInstalled -exactly 1
                Assert-VerifiableMock
            }      
        }
        
        Context "Cache is empty" {
            $script:LatestProfileMapPath = $null
            Mock Get-Item -Verifiable {}
            Mock Get-ProfilesInstalled {}
            It "Should return empty" {
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled Invoke-CommandWithRetry -Exactly 1
                Assert-MockCalled Get-ProfilesInstalled -exactly 1
                Assert-VerifiableMock
            }

            # Cleanup
            $script:LatestProfileMapPath = Get-LatestProfileMapPath
        }
    }
}

Describe "Update-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Invoke-CommandWithRetry -Verifiable { $global:testProfileMap } 
        $script:LatestProfileMapPath = New-Object -TypeName PSObject
        $script:LatestProfileMapPath | Add-Member NoteProperty -Name "FullName" -Value "C:\mock\MockETag.json"
        Mock Get-AllProfilesInstalled -Verifiable {}
        Mock Remove-PreviousVersion -Verifiable {}

        Context "Previous Versions were present" {
            It "Should invoke Remove-PreviousVersion" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-VerifiableMock
            }
            
            It "Invoke with -Module param: Should invoke Remove-PreviousVerison" {
                Update-ProfileHelper -profile 'Profile1' -Module 'Module1' -RemovePreviousVersions
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Find-PotentialConflict" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Modules are installed in other scope" {
            $script:IsAdmin = $true
            $moduleobj = New-Object -TypeName PSObject
            $moduleobj | Add-Member NoteProperty -Name "Path" -Value $Env:HOMEPATH
            Mock Get-Module -Verifiable { $moduleobj}
            It "Should return false, because force is present" {
                (Find-PotentialConflict -Module 'Module1' -Force) | Should Be $false
            }
        }

        Context "Modules are not installed in other scope" {
            $script:IsAdmin = $false
            $moduleobj = New-Object -TypeName PSObject
            $moduleobj | Add-Member NoteProperty -Name "Path" -Value $Env:HOMEPATH
            Mock Get-Module -Verifiable { $moduleobj}
            It "Should return false, no conflict" {
                (Find-PotentialConflict -Module 'Module1') | Should Be $false
            }
        }

        Context "Modules were not installed before" {
            Mock Get-Module -Verifiable { $null }
            It "Should return false, no conflict" {
                Find-PotentialConflict -Module 'Module1' | Should Be $false
            }
        }
    }
}

Describe "Invoke-InstallModule" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Install-Module has AllowClobber param" {
            $cmd = New-Object -TypeName PSObject 
            $cmd | Add-Member -MemberType NoteProperty -Name "Parameters" -Value @{"AllowClobber" = $true }
            Mock Get-Command -Verifiable { $cmd }
            
           <# It "Should invoke install-module with AllowClobber: No Scope" {
                Mock Install-Module -Verifiable {} 
                Invoke-InstallModule -module "Module1" -version "1.0"
                Assert-VerifiableMock
            }

            It "Should invoke install-module with AllowClobber: CurrentUser Scope" {
                Mock Install-Module -Verifiable -ParameterFilter { $Scope -eq "CurrentUser"} {}
                Invoke-InstallModule -module "Module1" -version "1.0" -scope "CurrentUser" 
                Assert-VerifiableMock
            } #>
        }

        Context "Install-Module doesn not have AllowClobber" {
            $cmd = New-Object -TypeName PSObject 
            $cmd | Add-Member -MemberType NoteProperty -Name "Parameters" -Value @{}
            Mock Get-Command -Verifiable { $cmd }
            It "Should invoke install-module with Force: No Scope" {
                Mock Install-Module -Verifiable -ParameterFilter { '$Force'} {}
                Invoke-InstallModule -module "Module1" -version "1.0"
                Assert-VerifiableMock
            }

            It "Should invoke install-module with Force: CurrentUser Scope" {
                Mock Install-Module -Verifiable -ParameterFilter { '$Force' -and ($Scope -eq "CurrentUser")} {}
                Invoke-InstallModule -module "Module1" -version "1.0" -scope "CurrentUser" 
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Invoke-CommandWithRetry" {
    InModuleScope AzureRM.Bootstrapper {
        $scriptBlock = {
           Get-ChildItem -ErrorAction Stop
        }

        Context "Executes script block successfully at first attempt" {
            Mock Get-ChildItem -Verifiable { "contents" }
            It "Should return successfully" {
                $result = Invoke-CommandWithRetry -scriptBlock $scriptBlock
                $result | Should Be "contents"
                Assert-VerifiableMock
            }
        }

        Context "Executes script successfully at one of the retries" {
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    throw
                }
                else {
                    return "contents"
                }
            }   

            Mock -CommandName Get-ChildItem -MockWith $mockTestPath
            Mock Start-Sleep -Verifiable {}

            It "Should return successfully" {
                $result = Invoke-CommandWithRetry -scriptBlock $scriptBlock
                $result | Should Be "contents"
                Assert-MockCalled Get-ChildItem -Times 2
                Assert-VerifiableMock
            }
        }

        Context "Fails to execute script during all retries" {
            Mock Get-ChildItem -Verifiable { throw }
            Mock Start-Sleep -Verifiable {}
            It "Throws exception" {
                { Invoke-CommandWithRetry -scriptBlock $scriptBlock } | Should throw
            }
        }
    }   
}

Describe "Select-Profile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Test-Path -Verifiable { $true }
        Context "Scope AllUsers with Admin rights" {
            $script:IsAdmin = $true
            It "Should return AllUsersAllHosts profile" {
                Select-Profile -scope "AllUsers" | Should Be $profile.AllUsersAllHosts 
                Assert-VerifiableMock
            }
        }

        Context "Scope CurrentUser" {
            It "Should return CurrentUserAllHosts profile" {
                Select-Profile -scope "CurrentUser" | Should Be $profile.CurrentUserAllHosts 
                Assert-VerifiableMock
            }
        }

        Context "Scope AllUsers no admin rights" {
            $script:IsAdmin = $false
            It "Should throw for admin rights" {
                { Select-Profile -scope "AllUsers" } | Should throw
            }
        }

        Context "ProfilePath does not exist" {
            $script:IsAdmin = $false
            Mock Test-Path -Verifiable { $false }
            Mock New-Item -Verifiable {}
            It "Should create a new file for profile" {
                Select-Profile -scope "CurrentUser" | Should Be $profile.CurrentUserAllHosts 
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-LatestModuleVersion" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Returns latest version in a version array" {
            $versionarray = @("2.0", "1.5", "1.0")
            It "Should return the latest version" {
                $result = Get-LatestModuleVersion -versions $versionarray
                $result | Should Be "2.0"
            }
        }
    }
}

Describe "Get-ModuleVersion" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { $testProfileMap | ConvertFrom-Json }
        Mock Get-LatestModuleVersion -Verifiable { "2.0" }
        Context "Gets module version" {
            $RollupModule = "Azure.Module1"
            It "Should return script block" {
                Get-ModuleVersion -armProfile "Profile1" -invocationLine "ipmo azure.module1" | Should Be "2.0"
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-ScriptBlock" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Creates a script block" {
            It "Should return script block" {
                $result = Get-ScriptBlock -ProfilePath "Profilepath"
                $result[1].contains("Import-Module:RequiredVersion") | Should Be $true
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Remove-ProfileSetting" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Set-Content -Verifiable {}

        Context "Profile contents had bootstrapper scripts" {
            $contents = @"
Temp Line 1
##BEGIN AzureRM.Bootstrapper scripts
Temp Line 2
Temp Line 3
##END AzureRM.Bootstrapper scripts
Temp Line 4
"@
            Mock Get-Content -Verifiable { $contents }
            It "Should return lines 1 and 4" {
                Remove-ProfileSetting -profilePath "testpath"
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Add-ScopeParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary

        It "Should return Scope parameter object" {
            (Add-ScopeParam $params)
            $params.ContainsKey("Scope") | Should Be $true
        }
    }
}

Describe "Add-ProfileParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        It "Should return Profile parameter object" {
            (Add-ProfileParam $params)
            $params.ContainsKey("Profile") | Should Be $true
            Assert-VerifiableMock
        }
    }
}

Describe "Add-ForceParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        
        It "Should return Force parameter object" {
            Add-ForceParam $params
            $params.ContainsKey("Force") | Should Be $true
        }
    }
}

Describe "Add-RemoveParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary

        It "Should return RemovePreviousVersions parameter object" {
            (Add-RemoveParam $params)
            $params.ContainsKey("RemovePreviousVersions") | Should Be $true
        }
    }
}

Describe "Add-SwitchParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        
        It "Should return Switch parameter object" {
            Add-SwitchParam $params "TestParam"
            $params.ContainsKey("TestParam") | Should Be $true
        }
    }
}

Describe "Add-ModuleParam" {
    InModuleScope AzureRM.Bootstrapper {
        
        Context "ProfileMap has more than one profile" {
            $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
           Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
            It "Should return Module parameter object" {
                (Add-ModuleParam $params)
                $params.ContainsKey("Module") | Should Be $true
                Assert-VerifiableMock
            }
        }

        Context "ProfileMap has one profile" {
            $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
            Mock Get-AzProfile -Verifiable { ("{`"Profile1`": { `"Module1`": [`"1.0`", `"0.1`"], `"Module2`": [`"1.0`", `"0.2`"] }}" ) | ConvertFrom-Json }
            It "Should return Module parameter object" {
                (Add-ModuleParam $params)
                $params.ContainsKey("Module") | Should Be $true
                Assert-VerifiableMock
            }
        }
    }

}

Describe "Get-AzureRmModule" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        
        Context "Module is installed" {
           Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
           It "Should return installed version" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should Be "1.0"
                Assert-VerifiableMock
            }
        }
        
        Context "Module is not installed" {
            Mock Get-Module -Verifiable {}
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should be $null
                Assert-VerifiableMock
            }
        }

        Context "Module not in the list" {
            Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile2' -Module 'Module2' | Should be $null
                Assert-VerifiableMock
            }
        }

        Context "Invoke with invalid parameters" {
            It "Should throw" {
                { Get-AzureRmModule -Profile 'XYZ' -Module 'ABC' } | Should Throw
            }
        }

        Context "Invoke with null parameters" {
            It "Should throw" {
                { Get-AzureRmModule -Profile $null -Module $null } | Should Throw
            }
        }

        Context "ProfileMap has one profile" {
            $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
            Mock Get-AzProfile -Verifiable { ("{`"Profile1`": { `"Module1`": [`"1.0`", `"0.1`"], `"Module2`": [`"1.0`", `"0.2`"] }}" ) | ConvertFrom-Json }
            Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
            It "Should return installed version" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should Be "1.0"
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Get-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        Context "With ListAvailable Switch" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable)
                $Result.Count | Should be 2
                $Result.ProfileName | Should Not Be $null
                $Result.Module1 | Should Not Be $null
                Assert-VerifiableMock
            }
        }

        Context "With ListAvailable and update Switches" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable -Update)
                $Result.Count | Should be 2
                $Result.ProfileName | Should Not Be $null
                $Result.Module1 | Should Not Be $null
                Assert-VerifiableMock
            }
        }

        Context "Without ListAvailable Switch" {
            $IncompleteProfiles = @('Profile2')
            Mock Get-ProfilesInstalled -Verifiable -ParameterFilter {[REF]$IncompleteProfiles} { @{'Profile1'= @{'Module1' = @('1.0') ;'Module2'= @('1.0')}} } 
            It "Returns installed Profile" {
                $Result = (Get-AzureRmProfile)
                $Result.ProfileName | Should Not Be $null
                $Result.Module1 | Should Not Be $null
                Assert-VerifiableMock
            }
        }

        Context "No profiles installed" {
            Mock Get-ProfilesInstalled -Verifiable {}
            It "Returns null" {
                (Get-AzureRmProfile) | Should Be $null
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Use-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        $RollupModule = 'Module1'
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Install-Module { "Installing module..."}
        Mock Import-Module -Verifiable { "Importing Module..."}
        Mock Find-PotentialConflict {}
        Context "Modules not installed" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Length | Should Be 3 # Includes "Loading module" 
                $Result[1] | Should Be "Installing module..."
                $Result[2] | Should Be "Importing Module..."
                Assert-VerifiableMock
            }

            It "Invoke with Module param: Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1' -Force)
                $Result.Length | Should Be 3
                $Result[1] | Should Be "Installing module..."
                $Result[2] | Should Be "Importing Module..."
                Assert-VerifiableMock
            }
        }

        Context "Modules are installed" {
            $RollupModule = "None"
            Mock Get-AzureRmModule -Verifiable { "1.0" } -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Get-AzureRmModule -Verifiable { "1.0" } -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module2"}
            Mock Import-Module { "Module1 1.0 Imported"} -ParameterFilter { $Name -eq "Module1" -and $RequiredVersion -eq "1.0"}
            Mock Import-Module { "Module2 1.0 Imported"} -ParameterFilter { $Name -eq "Module2" -and $RequiredVersion -eq "1.0"}
            It "Should skip installing modules, imports the right version module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force) 
                $Result.length | Should Be 3
                $Result[1] | Should Be "Module1 1.0 Imported"
                Assert-MockCalled Install-Module -Exactly 0
                Assert-MockCalled Import-Module -Exactly 2
                Assert-VerifiableMock
            }

            It "Invoke with Module param: Should skip installing modules, imports the right version module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1', 'Module2' -Force) 
                $Result.length | Should Be 3
                $Result[1] | Should Be "Module1 1.0 Imported"
                Assert-MockCalled Install-Module -Exactly 0
                Assert-VerifiableMock
                
            }
        }
        Context "Invoke with invalid profile" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile 'WrongProfileName'} | Should Throw
            }
        }

        Context "Invoke with $null profile" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile $null} | Should Throw
            }
        }

        Context "Invoke with Scope as CurrentUser" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "CurrentUser"}
            It "Should invoke Install-ModuleHelper with scope currentuser" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force -scope CurrentUser)
                Assert-VerifiableMock
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "AllUsers"}
            It "Should invoke Install-ModuleHelper with scope AllUsers" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force -scope AllUsers)
                Assert-VerifiableMock
            }
        }

        Context "Invoke with invalide module name" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile 'Profile1' -Module 'MockModule'} | Should Throw
            }            
        }

        Context "Potential Conflict found" {
            Mock Find-PotentialConflict -Verifiable { $true }
            It "Should skip installing module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Contains("Installing module...") | Should Be $false
                Assert-VerifiableMock
            }
        }

        Context "Other versions of the same module found imported" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } 
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "2.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Name" -Value "Module1"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj }
            It "Should skip importing module" {
                $result = Use-AzureRmProfile -Profile 'Profile1' -ErrorVariable useError -ErrorAction SilentlyContinue
                $useError.exception.message.contains("A different profile version of module") | Should Be $true
            }
        }

        # User tries to execute Use-AzureRmProfile with different profiles & different modules
        Context "A different profile's module was previously imported" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } 
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "2.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Name" -Value "Module1"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj }
            It "Should skip importing module" {
                $result = Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1' -ErrorVariable useError -ErrorAction SilentlyContinue
                $useError.exception.message.contains("A different profile version of module") | Should Be $true
            }
        }

        # User has module2 from profile1 imported; tries to execute Use-AzureRmProfile for profile1 with module1. Should import.
        Context "A different module from same profile was previously imported" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } 
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "1.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty -Name "Name" -Value "Module2"
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj }
            It "Should import module" {
                $result = Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1' 
                Assert-MockCalled Import-Module -Times 1
            }
        }
    }
}

Describe "Install-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Get-AzureRmModule -Verifiable {} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module1'}
        Mock Get-AzureRmModule -Verifiable { "1.0"} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module2'}
        Mock Find-PotentialConflict -Verifiable { $false }
        
        Context "Invoke with valid profile name" {
            Mock Invoke-InstallModule -Verifiable { "Installing module Module1... Version 1.0"} 
            It "Should install Module1" {
                (Install-AzureRmProfile -Profile 'Profile1') | Should be "Installing module Module1... Version 1.0"
                Assert-VerifiableMock
          }
        }

        Context "Invoke with invalid profile name" {
            It "Should throw" {
                { Install-AzureRmProfile -Profile 'WrongProfileName'} | Should Throw
            }
        }

        Context "Invoke with null profile name" {
            It "Should throw" {
                { Install-AzureRmProfile -Profile $null } | Should Throw
            }
        }

        Context "Invoke with Scope as CurrentUser" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Invoke-InstallModule -Verifiable {} -ParameterFilter { $Scope -eq "CurrentUser"}
            It "Should invoke Install-ModuleHelper with scope currentuser" {
                (Install-AzureRmProfile -Profile 'Profile1' -scope CurrentUser)
                Assert-VerifiableMock
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Invoke-InstallModule -Verifiable {} -ParameterFilter { $Scope -eq "AllUsers"}
            It "Should invoke Install-ModuleHelper with scope AllUsers" {
                (Install-AzureRmProfile -Profile 'Profile1' -scope AllUsers)
                Assert-VerifiableMock
            }
        }

        Context "Potential Conflict found" {
            Mock Find-PotentialConflict -Verifiable { $true }
            Mock Invoke-InstallModule {}
            It "Should skip installing module" {
                Install-AzureRmProfile -Profile 'Profile1'
                Assert-MockCalled Invoke-InstallModule -Exactly 0
                Assert-VerifiableMock
            }
        }

    }
}

Describe "Uninstall-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Uninstall-ProfileHelper -Verifiable {}
        Context "Valid profile name" {
            It "Should invoke Uninstall-ProfileHelper" {
                Uninstall-AzureRmProfile -Profile 'Profile1' -Force
                Assert-VerifiableMock
            }
        }

        Context "Invoke with invalid profile name" {
            It "Should throw" {
                { Uninstall-AzureRmProfile -Profile 'WrongProfileName' } | Should Throw
            }
        }

        Context "Invoke with null profile name" {
            It "Should throw" {
                { Uninstall-AzureRmProfile -Profile $null } | Should Throw
            }
        }
    }
}

Describe "Update-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        # Arrange
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Get-AzProfile -Verifiable -ParameterFilter { $Update.IsPresent } { ($global:testProfileMap | ConvertFrom-Json) }
        
        Context "Proper profile with '-RemovePreviousVersions' and '-Force' params" {
            Mock Use-AzureRmProfile -Verifiable {} -ParameterFilter { ($Force.IsPresent)}
            Mock Update-ProfileHelper -Verifiable {}
    
            It "Imports profile modules and invokes Update-ProfileHelper" {
                Update-AzureRmProfile -Profile 'Profile2' -RemovePreviousVersions -Force
                Assert-VerifiableMock
            }

            It "Invoke with Module param: Imports profile modules and invokes Update-ProfileHelper" {
                Update-AzureRmProfile -Profile 'Profile2' -module 'Module1' -RemovePreviousVersions -Force
                Assert-VerifiableMock
            }
        }

        Context "Invoke with invalid profile name" {
            It "Should throw" {
                { Update-AzureRmProfile -Profile 'WrongProfileName'} | Should Throw
            }
        }

        Context "Invoke with null profile name" {
            It "Should throw" {
                { Update-AzureRmProfile -Profile $null } | Should Throw
            }
        }

        Context "Invoke with Scope as CurrentUser" {
            Mock Use-AzureRmProfile -Verifiable {} -ParameterFilter { ($Force.IsPresent) -and {$Scope -like 'CurrentUser'}}
            Mock Update-ProfileHelper -Verifiable {}
            It "Should invoke Use-AzureRmProfile with scope currentuser" {
                (Update-AzureRmProfile -Profile 'Profile1' -scope CurrentUser -Force -r)
                Assert-VerifiableMock
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Use-AzureRmProfile -Verifiable {} -ParameterFilter { ($Force.IsPresent) -and {$Scope -like 'CurrentUser'}}
            Mock Update-ProfileHelper -Verifiable {}
            It "Should invoke Use-AzureRmProfile with scope AllUsers" {
                (Update-AzureRmProfile -Profile 'Profile1' -scope AllUsers -Force -r)
                Assert-VerifiableMock
            }
        }
            
        Context "Invoke with invalid module name" {
            It "Should throw" {
                { Update-AzureRmProfile -Profile 'Profile1' -module 'MockModule' } | Should Throw
            }
        }

        # Cleanup
        if (Test-Path '.\MockPath')
        {
            Remove-Item -Path '.\MockPath' -Force -Recurse
        }
    }
}

Describe "Set-BootstrapRepo" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Repo name is given" {
            # Arrange
            $currentBootstrapRepo = $script:BootStrapRepo
            It "Should set given repo as BootstrapRepo" {
                Set-BootstrapRepo -Repo "MockName"
                $script:BootStrapRepo | Should Be "MockName"
            }

            # Cleanup
            $script:BootStrapRepo = $currentBootstrapRepo
        }
    }
}

Describe "Set-AzureRmDefaultProfile" {
    InModuleScope AzureRM.Bootstrapper {
        $sb = {
            if ($MyInvocation.Line.Contains("Module1")) { "1.0"}
        }
        Mock Get-ScriptBlock -Verifiable { $sb }
        Mock Invoke-CommandWithRetry -Verifiable {}
        Mock Select-Profile -verifiable {}
        Mock Remove-ProfileSetting -Verifiable {}
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        Context "New default profile value is given" {
            It "Setting default profile succeeds" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                Set-AzureRmDefaultProfile -Profile "Profile1" -Force
                $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] | Should Be "Profile1"
                Assert-VerifiableMock
            }
        }

        Context "User wants to update default profile value" {
            It "Should update default profile value" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                Set-AzureRmDefaultProfile -Profile "Profile2" -Force
                $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] | Should Be "Profile2"
                Assert-VerifiableMock
            }
        }

        Context "Removing old default profile vaule throws" {
            Mock Invoke-CommandWithRetry -Verifiable { throw }
            It "Should throw for updating default profile" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                { Set-AzureRmDefaultProfile -Profile "Profile1" -Force } | Should throw
                Assert-VerifiableMock
            }
        }

        Context "Set Default Profile with scope as AllUsers in admin shell" {
            $script:IsAdmin = $true
            Mock Select-Profile -Verifiable { "AllUsersProfile"}
            It "Should succeed setting AllUsers Profile" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                Set-AzureRmDefaultProfile -Profile "Profile1" -Scope "AllUsers" -Force
                $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] | Should Be "Profile1"
                Assert-VerifiableMock
            }
        }

        Context "Set Default Profile with scope as AllUsers in non-admin shell" {
            $script:IsAdmin = $false
            Mock Select-Profile -Verifiable { throw }
            It "Should throw for AllUsers Profile" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                { Set-AzureRmDefaultProfile -Profile "Profile2" -Scope "AllUsers" -Force } | Should throw
                Assert-VerifiableMock
            }
        }

        Context "Set a Default Profile twice" {
            It "Should not edit profile content twice" {
                $Global:PSDefaultParameterValues.Remove("*-AzureRmProfile:Profile")
                Set-AzureRmDefaultProfile -Profile "Profile1" -Force 
                Set-AzureRmDefaultProfile -Profile "Profile1" -Force 
                Assert-MockCalled Invoke-CommandWithRetry -Exactly 1
                Assert-VerifiableMock
            }
        }
    }
}

Describe "Remove-AzureRmDefaultProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Remove-Module -Verifiable {}
        Mock Remove-ProfileSetting -Verifiable {}
        Mock Test-Path -Verifiable { $true }
        Mock Get-Module -Verifiable { "AzureRm" }

        Context "Default profile presents in the profile file & default variable" {
            It "Should successfully remove default profile from shell & profile file" {
                Remove-AzureRmDefaultProfile -Force
                $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] | Should Be $null
                Assert-VerifiableMock
            }
        }
        
        Context "Default profile is not set previously or was removed" {
            It "Should return null for default profile" {
                Remove-AzureRmDefaultProfile -Force
                $Global:PSDefaultParameterValues["*-AzureRmProfile:Profile"] | Should Be $null
                Assert-VerifiableMock
            }
        }

        Context "Profile files do not exist" {
            Mock Test-Path -Verifiable { $false }
            It "Should not invoke remove script" {
                Remove-AzureRmDefaultProfile -Force
                Assert-MockCalled Remove-ProfileSetting -Exactly 0
            }
        }

        Context "Remove default profile in admin mode" {
            Mock Remove-Module -verifiable {}
            $Script:IsAdmin = $true
            It "Should remove setting in AllUsersAllHosts and CurrentUserAllHosts profiles" {
                Remove-AzureRmDefaultProfile -Force
                # For Admin, two profile paths are tested 
                Assert-MockCalled Test-Path -Exactly 2
            }
        }

        Context "Remove default profile in non-admin mode" {
            Mock Remove-Module -verifiable {}
            $Script:IsAdmin = $false
            Mock Invoke-CommandWithRetry -Verifiable {}
            It "Should remove setting in CurrentUserAllHosts profile" {
                Remove-AzureRmDefaultProfile -Force
                Assert-MockCalled Test-Path -Exactly 1
            }
        }
    }    
}