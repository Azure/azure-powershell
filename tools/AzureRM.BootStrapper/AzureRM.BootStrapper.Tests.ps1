#Requires -Modules AzureRM.BootStrapper
$global:testProfileMap = "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 

Describe "Get-ProfileCachePath" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Windows OS Admin" {
            $IsWindows = $true
            $Script:IsAdmin = $true
            It "Should return ProgramData path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains("ProgramData") | Should Be $true
            }
        }

        Context "Windows OS Non-Admin" {
            $IsWindows = $true
            $Script:IsAdmin = $false
            It "Should return LOCALAPPDATA path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains("AppData\Local") | Should Be $true                
            }            
        }

        Context "Linux OS Admin" {
            $IsWindows = $false
            $Script:IsCoreEdition = $true
            It "Should return .config path" {
                $result = Get-ProfileCachePath
                $result | Should Match "(.*)ProfileCache$"
                $result.Contains(".config") | Should Be $true
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
            Mock Test-Path -Verifiable { $true }
            Mock Get-ChildItem -Verifiable { $null }
            It "Should return null" {
                Get-LatestProfileMapPath | Should be $null
            }
        }

        Context "Two profile maps available at profile cache" {
            Mock Test-Path -Verifiable {$true} 
            $profilemap1 = New-Object -TypeName PSObject 
            $profilemap1 | Add-Member NoteProperty -Name "Name" -Value '123-pmap1.json'
            $profilemap2 = New-Object -TypeName PSObject 
            $profilemap2 | Add-Member NoteProperty -Name "Name" -Value '42-pmap2.json'
            Mock Get-ChildItem -Verifiable { @($profilemap1, $profilemap2)}
            Mock Get-LargestNumber -Verifiable { 123 }
            It "Should return Latest map" {
                Get-LatestProfileMapPath | Should Be $profilemap1
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
            It "Returns proper response" {
                $result = Get-AzureStorageBlob
                $result.Headers["Content-Type"] | Should Be "application/json"
                $result.StatusCode | Should Be "200"
            }
        }

        Context "Invoke-WebRequest threw exception" {
            $PSProfileMapEndpoint = "http://foo.bar"
            It "Throws exception" {
                { Get-WebResponse } | Should throw 
            }
        }
    }
}

Describe "RetryGetContent" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Gets content at first attempt" {
            Mock Get-Content -Verifiable { $global:testProfileMap }
            It "Should return successfully" {
                $result = RetryGetContent -FilePath ".\MockPath"
                $result | Should Be "@{Profile1=; Profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "Gets content at one of the retries" {
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    throw
                }
                else {
                    return $global:testProfileMap
                }
            }   

            Mock -CommandName Get-Content -MockWith $mockTestPath
            Mock Start-Sleep -Verifiable {}

            It "Should return successfully" {
                RetryGetContent -FilePath ".\MockPath"
                Assert-MockCalled Get-Content -Times 2
                Assert-VerifiableMocks
            }
        }

        Context "Fails to get content during all retries" {
            Mock Get-Content -Verifiable { throw }
            Mock Start-Sleep -Verifiable {}
            It "Returns null" {
                RetryGetContent -FilePath ".\MockPath" | Should Be $null
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
        Mock RetryGetContent -Verifiable { ($testProfileMap | ConvertFrom-Json) }

        Context "ProfileCachePath Exists and Etags are equal" {
            Mock Test-Path -Verifiable { $true }
            It "Returns Correct ProfileMap" {
                Get-AzureProfileMap | Should Be "@{Profile1=; Profile2=}"
                Assert-VerifiableMocks
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
            It "Returns Correct ProfileMap" {
                Get-AzureProfileMap | Should Be "@{Profile1=; Profile2=}"
                Assert-VerifiableMocks
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
            $WebResponse = New-Object -TypeName PSObject
            $WebResponse | Add-Member NoteProperty -Name "Content" -Value "{`n`"Profile1`":`t { `"Module1`": [`"1.0`"], `n`"Module2`": [`"1.0`"] }, `"Profile2`": `n{ `"Module1`": [`"2.0`", `"1.0`"],`n `r`"Module2`": `t[`"2.0`"] }}" 
            It "Should return proper profile map" {
                (RetrieveProfileMap -WebResponse $WebResponse) -like ($global:testProfileMap | ConvertFrom-Json) | Should Be $true
            }
        }

        Context "WebResponse content has no extra line breaks" {
            $WebResponse = New-Object -TypeName PSObject
            $WebResponse | Add-Member NoteProperty -Name "Content" -Value $global:testProfileMap
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
                Get-AzProfile -Update  | Should Be "@{Profile1=; Profile2=}"
            }
            It "Checks Mock calls to Get-AzureProfileMap" {
                Assert-MockCalled Get-AzureProfileMap -Exactly 1
            }
        }
        
        Context "Gets Azure ProfileMap from Cache" {
            $script:LatestProfileMapPath = New-Object -TypeName PSObject
            $script:LatestProfileMapPath | Add-Member NoteProperty -Name "FullName" -Value "C:\mock\MockETag.json"
            Mock RetryGetContent -Verifiable { $global:testProfileMap | ConvertFrom-Json }
            Mock Test-Path -Verifiable { $true }
            It "Should get ProfileMap from Cache" {
                Get-AzProfile | Should Be "@{Profile1=; Profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available from cache" {
            Mock Test-Path -Verifiable { $false }
            Mock RetryGetContent -Verifiable { return $global:testProfileMap  | ConvertFrom-Json}
            It "Should get ProfileMap from Embedded source" {
                Get-AzProfile | Should Be "@{Profile1=; Profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available in cache or Embedded source" {
            Mock Test-Path -Verifiable { $false }
            Mock RetryGetContent -Verifiable {}

            It "Should throw FileNotFound Exception" {
                { Get-AzProfile } | Should Throw
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Get-ProfilesAvailable" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Valid ProfilMap" {
            It "Should return array of profiles and module versions" {
                $result = Get-ProfilesAvailable ($global:testProfileMap | ConvertFrom-Json)
                $result.contains("Profile: Profile1") | Should Be $true
                $result.contains("Module1 : {1.0}") | Should Be $true
            }
        }

        Context "Null ProfileMap" {
            It "Should throw exception" {
                { Get-ProfilesAvailable -ProfileMap $null } | Should throw
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

Describe "Remove-ProfileMapFile" {
    InModuleScope AzureRM.Bootstrapper {
        Context "ProfileMapPath exists" {
            Mock Test-Path -Verifiable { $true }
            Mock RemoveWithRetry -Verifiable {}
            It "Should call RemovewithRetry function" {
                Remove-ProfileMapFile ".\MockPath"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMapPath does not exist" {
            Mock Test-Path -Verifiable { $false }
            Mock RemoveWithRetry {}
            It "Should not call RemoveWithRetry" {
                Remove-ProfileMapFile  ".\MockPath"
                Assert-MockCalled RemoveWithRetry -Exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "RemoveWithRetry" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Removes item at first attempt" {
            Mock Remove-Item -Verifiable {}
            It "Should return successfully" {
                RemoveWithRetry -Path ".\MockPath"
                Assert-VerifiableMocks
            }
        }

        Context "Removes item at one of the retries" {
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    throw
                }
                else {
                    return $null
                }
            }   

            Mock -CommandName Remove-Item -MockWith $mockTestPath
            Mock Start-Sleep -Verifiable {}

            It "Should return successfully" {
                RemoveWithRetry -Path ".\MockPath"
                Assert-MockCalled Remove-Item -Times 2
                Assert-VerifiableMocks
            }
        }

        Context "Fails to remove item during all retries" {
            Mock Remove-Item -Verifiable { throw }
            Mock Start-Sleep -Verifiable {}
            It "Should throw" {
                { RemoveWithRetry -Path ".\MockPath" } | Should throw
            }
        }
    }
}

Describe "Test-ProfilesInstalled" {
    InModuleScope AzureRm.Bootstrapper {
        Context "Profile associated with Module version is installed" {
            $AllProfilesInstalled = @{'Module11.0'= @('Profile1', 'Profile2'); 'Module22.0'= @('Profile2')}
            It "Should return ProfilesAssociated" {
                $Result = (Test-ProfilesInstalled -Module 'Module1' -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -AllProfilesInstalled $AllProfilesInstalled)
                $Result[0] | Should Be 'Profile1'
                $Result[1] | Should Be 'Profile2'
            }
        }

        Context "Profile associated with Module version is not installed" {
                $AllProfilesInstalled = @{'Module11.0'= @('Profile1', 'Profile2')}
                It "Should return empty array" {
                $Result = (Test-ProfilesInstalled -Module 'Module2' -Profile 'Profile2' -PMap ($global:testProfileMap | ConvertFrom-Json) -AllProfilesInstalled $AllProfilesInstalled)
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
                Assert-VerifiableMocks
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
    }
}

Describe "Uninstall-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AllProfilesInstalled -Verifiable {}
        Mock Invoke-UninstallModule -Verifiable {}

        Context "Profile associated with the module is installed" {
            It "Should call Invoke-UninstallModule" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -Force
                Assert-VerifiableMocks
                Assert-MockCalled Invoke-UninstallModule -Exactly 2
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
                Assert-VerifiableMocks
            }
        }

        Context "Module associated with more than one profile" {
            Mock Test-ProfilesInstalled -Verifiable { @('Profile1', 'Profile2')}
            Mock Uninstall-ModuleHelper {}
            It "Should not invoke Uninstall module helper" {
                Invoke-UninstallModule -PMap ($global:testProfileMap | ConvertFrom-Json) -Profile 'profile1' -module 'module1'
                Assert-MockCalled Uninstall-ModuleHelper -Exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Remove-PreviousVersion" {
    InModuleScope AzureRM.Bootstrapper {
        $AllProfilesInstalled = @{}
        Context "Previous versions are installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "0.1" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj}
            Mock Import-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -PreviousMap ($PreviousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json) 
                Assert-VerifiableMocks
            }

            It "Invoke with Module parameter: Should call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -Module 'Module1' -PreviousMap ($PreviousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json) 
                Assert-VerifiableMocks                
            }
        }

        Context "Previous versions are not installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Import-Module -Verifiable {}
            Mock Invoke-UninstallModule {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -PreviousMap ($PreviousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-VerifiableMocks
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "No previous versions" {
            $PreviousMap =  "{`"Profile0`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile3`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -PreviousMap ($PreviousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "Previous version is same as the latest version" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersion -Profile 'Profile1' -PreviousMap ($PreviousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }
    }
}

Describe "Get-AllProfilesInstalled" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { '.\MockPath'}
        Mock RetryGetContent { $global:testProfileMap | ConvertFrom-Json }
        Context "Profile Maps are available from cache" {
            $ProfileMapHash = New-Object -TypeName  PSObject
            $ProfileMapHash | Add-Member NoteProperty 'Name' -Value 'ProfileMap.json'
            Mock Get-ChildItem -Verifiable { @($ProfileMapHash, 'MockHash.json')}
            Mock Get-ProfilesInstalled -Verifiable { @{'Profile1'= @{'Module1'= '1.0'}}}
            $expectedResult = @{"Module21.0"=@('Profile1'); "Module11.0"=@('Profile1')}
            It "Should return Modules & Profiles Installed" {
                (Get-AllProfilesInstalled) -like $expectedResult | Should Be $true
                Assert-MockCalled RetryGetContent -Exactly 2
                Assert-MockCalled Get-ProfilesInstalled -exactly 2
                Assert-VerifiableMocks
            }
        }

        Context "Profiles are not installed" {
            $ProfileMapHash = New-Object -TypeName  PSObject
            $ProfileMapHash | Add-Member NoteProperty 'Name' -Value 'ProfileMap.json'
            Mock Get-ChildItem -Verifiable { @($ProfileMapHash, 'MockHash.json')}
            Mock Get-ProfilesInstalled -Verifiable {}
            
            It "Should return empty" {
                $AllProfilesInstalled = @()
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled RetryGetContent -Exactly 2
                Assert-MockCalled Get-ProfilesInstalled -exactly 2
                Assert-VerifiableMocks
            }      
        }
        
        Context "Cache is empty" {
            Mock Get-ChildItem {}
            Mock Get-ProfilesInstalled {}
            It "Should return empty" {
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled RetryGetContent -Exactly 0
                Assert-MockCalled Get-ProfilesInstalled -exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Update-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { '.\MockPath'}
        $profilemapFileInfo = New-Object -TypeName  psobject
        $profilemapFileInfo | Add-Member NoteProperty 'Name' -Value 'ProfileMap.json'
        Mock Get-ChildItem -Verifiable { @($profilemapFileInfo, 'MockETag.json')} -ParameterFilter { $Path -eq '.\MockPath'}
        Mock RetryGetContent -Verifiable { $global:testProfileMap } -ParameterFilter { $FilePath -eq "C:\mock\MockETag.json"}
        $script:LatestProfileMapPath = New-Object -TypeName PSObject
        $script:LatestProfileMapPath | Add-Member NoteProperty -Name "FullName" -Value "C:\mock\MockETag.json"
        Mock Get-AllProfilesInstalled -Verifiable {}
        Mock Remove-PreviousVersion -Verifiable {}
        Mock Remove-ProfileMapFile {}

        Context "Previous Profile versions are available and they are installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock RetryGetContent -Verifiable { $PreviousMap }
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return @{'Profile1'= @{'Module1'= '1.0'}}
                }
                else {
                    return @{'Profile2' = @{ 'Module2' = '0.1'}}
                }
            }   

            Mock -CommandName Get-ProfilesInstalled -MockWith $mockTestPath
            
            It "Should remove previous profile map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Exactly 1
                Assert-VerifiableMocks
            }
            
            It "Invoke with -Module param: Should remove previous profile map" {
                Update-ProfileHelper -profile 'Profile1' -Module 'Module1' -RemovePreviousVersions
                Assert-MockCalled Remove-ProfileMapFile -Exactly 1
                Assert-VerifiableMocks
            }
        }

        Context "Previous profile versions are available but they are not installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock RetryGetContent -Verifiable { $PreviousMap }
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return @{'Profile1'= @{'Module1'= '1.0'}}
                }
                else {
                    return @{}
                }
            }   

            Mock -CommandName Get-ProfilesInstalled -MockWith $mockTestPath
            It "Should remove the previous profile map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Times 1
                Assert-VerifiableMocks
            }
        }

        Context "Previous profile versions are same as latest profile versions" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock RetryGetContent -Verifiable { $PreviousMap }
            Mock Get-ProfilesInstalled -Verifiable {@{'Profile1'= @{'Module1'= '1.0'}}}
            It "Should remove the previous profile map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Times 1
                Assert-VerifiableMocks
            }
        }

        Context "Previous profile versions are installed - and part of other profiles" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock RetryGetContent -Verifiable { $PreviousMap }
            $Script:mockCalled = 0
            $mockTestPath = {
                $Script:mockCalled++
                if ($Script:mockCalled -eq 1)
                {
                    return @{'Profile2'= @{'Module1'= '1.0'}}
                }
                else {
                    return @{'Profile2' = @{ 'Module2' = '0.1'}}
                }
            }   

            Mock -CommandName Get-ProfilesInstalled -MockWith $mockTestPath
            It "Should not remove previous map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Times 0
                Assert-VerifiableMocks

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
            Assert-VerifiableMocks
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
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        It "Should return Module parameter object" {
            (Add-ModuleParam $params)
            $params.ContainsKey("Module") | Should Be $true
            Assert-VerifiableMocks
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
                Assert-VerifiableMocks
            }
        }
        
        Context "Module is not installed" {
            Mock Get-Module -Verifiable {}
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should be $null
                Assert-VerifiableMocks
            }
        }

        Context "Module not in the list" {
            Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile2' -Module 'Module2' | Should be $null
                Assert-VerifiableMocks
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
    }
}

Describe "Get-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        Context "With ListAvailable Switch" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable)
                $Result.Contains("Profile: Profile1") | Should Be $true
                $Result.Contains("Profile: Profile2") | Should Be $true
                Assert-VerifiableMocks
            }
        }

        Context "With ListAvailable and update Switches" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable -Update)
                $Result.Contains("Profile: Profile1") | Should Be $true
                $Result.Contains("Profile: Profile2") | Should Be $true
                Assert-VerifiableMocks
            }
        }

        Context "Without ListAvailable Switch" {
            $IncompleteProfiles = @('Profile2')
            Mock Get-ProfilesInstalled -Verifiable -ParameterFilter {[REF]$IncompleteProfiles} { @{'Profile1'= @{'Module1' = @('1.0') ;'Module2'= @('1.0')}} } 
            It "Returns installed Profile" {
                $Result = (Get-AzureRmProfile)
                $result[0] | Should be "Profile : Profile1"
                Assert-VerifiableMocks
            }
        }

        Context "No profiles installed" {
            Mock Get-ProfilesInstalled -Verifiable {}
            It "Returns null" {
                (Get-AzureRmProfile) | Should Be $null
                Assert-VerifiableMocks
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
        if (($PSVersionTable.PSVersion.Major -ge 5) -and ($PSVersionTable.PSVersion.Minor -ge 1)){
        Context "Modules not installed" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Length | Should Be 3 # Includes "Loading module" 
                $Result[1] | Should Be "Installing module..."
                $Result[2] | Should Be "Importing Module..."
                Assert-VerifiableMocks
            }

            It "Invoke with Module param: Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1' -Force)
                $Result.Length | Should Be 3
                $Result[1] | Should Be "Installing module..."
                $Result[2] | Should Be "Importing Module..."
                Assert-VerifiableMocks
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
                Assert-VerifiableMocks
            }

            It "Invoke with Module param: Should skip installing modules, imports the right version module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Module 'Module1', 'Module2' -Force) 
                $Result.length | Should Be 3
                $Result[1] | Should Be "Module1 1.0 Imported"
                Assert-MockCalled Install-Module -Exactly 0
                Assert-VerifiableMocks
                
            }
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
        if (($PSVersionTable.PSVersion.Major -ge 5) -and ($PSVersionTable.PSVersion.Minor -ge 1)){

        Context "Invoke with Scope as CurrentUser" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "CurrentUser"}
            It "Should invoke Install-ModuleHelper with scope currentuser" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force -scope CurrentUser)
                Assert-VerifiableMocks
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "AllUsers"}
            It "Should invoke Install-ModuleHelper with scope AllUsers" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force -scope AllUsers)
                Assert-VerifiableMocks
            }
        }
        }

        Context "Invoke with invalide module name" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile 'Profile1' -Module 'MockModule'} | Should Throw
            }            
        }
        if (($PSVersionTable.PSVersion.Major -ge 5) -and ($PSVersionTable.PSVersion.Minor -ge 1)){

        Context "Potential Conflict found" {
            Mock Find-PotentialConflict -Verifiable { $true }
            It "Should skip installing module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Contains("Installing module...") | Should Be $false
                Assert-VerifiableMocks
            }
        }

        Context "Other versions of the same module found imported" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } 
            Mock Find-PotentialConflict -Verifiable { $false }
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "2.0" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj }
            It "Should skip importing module" {
                $result = Use-AzureRmProfile -Profile 'Profile1' -ErrorVariable useError -ErrorAction SilentlyContinue
                $useError -like "A different version of module Module1 is already imported in this session. Start a new PowerShell session and retry the operation." | Should Be $true
            }
        }
        }
    }
}

Describe "Install-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Get-AzureRmModule -Verifiable {} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module1'}
        Mock Get-AzureRmModule -Verifiable { "1.0"} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module2'}
        if (($PSVersionTable.PSVersion.Major -ge 5) -and ($PSVersionTable.PSVersion.Minor -ge 1)){

        Context "Invoke with valid profile name" {
            Mock Install-Module -Verifiable { "Installing module Module1... Version 1.0"} 
            It "Should install Module1" {
                (Install-AzureRmProfile -Profile 'Profile1') | Should be "Installing module Module1... Version 1.0"
                Assert-VerifiableMocks
          }
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
        if (($PSVersionTable.PSVersion.Major -ge 5) -and ($PSVersionTable.PSVersion.Minor -ge 1)){

        Context "Invoke with Scope as CurrentUser" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "CurrentUser"}
            It "Should invoke Install-ModuleHelper with scope currentuser" {
                (Install-AzureRmProfile -Profile 'Profile1' -scope CurrentUser)
                Assert-VerifiableMocks
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {} -ParameterFilter { $Scope -eq "AllUsers"}
            It "Should invoke Install-ModuleHelper with scope AllUsers" {
                (Install-AzureRmProfile -Profile 'Profile1' -scope AllUsers)
                Assert-VerifiableMocks
            }
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
                Assert-VerifiableMocks
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
                Assert-VerifiableMocks
            }

            It "Invoke with Module param: Imports profile modules and invokes Update-ProfileHelper" {
                Update-AzureRmProfile -Profile 'Profile2' -module 'Module1' -RemovePreviousVersions -Force
                Assert-VerifiableMocks
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
                Assert-VerifiableMocks
            }
        }
        
        Context "Invoke with Scope as AllUsers" {
            Mock Use-AzureRmProfile -Verifiable {} -ParameterFilter { ($Force.IsPresent) -and {$Scope -like 'CurrentUser'}}
            Mock Update-ProfileHelper -Verifiable {}
            It "Should invoke Use-AzureRmProfile with scope AllUsers" {
                (Update-AzureRmProfile -Profile 'Profile1' -scope AllUsers -Force -r)
                Assert-VerifiableMocks
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

# Cleanup: Reset $script:LatestProfileMapPath
#$script:LatestProfileMapPath = Get-LatestProfileMapPath
