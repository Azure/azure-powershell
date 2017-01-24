Import-Module AzureRM.Bootstrapper
$global:testProfileMap = "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 

Describe "Get-ProfileCachePath" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Gets the correct profile cache path" {
            It "Should return proper path" {
                Get-ProfileCachePath | Should Match "(.*)ProfileCache$"
            }
        }
    }
}

Describe "Get-RestResponse" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Rest call is properly made" {
            It "Returns proper json" {
                Mock Invoke-RestMethod -Verifiable { return ($testProfileMap | ConvertFrom-Json) }
                Get-RestResponse | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "Rest call threw exception" {
            It "Throws custom exception" {
                Mock Invoke-RestMethod -Verifiable { throw [System.Net.WebException] }
                { Get-RestResponse } | Should throw "Http Status Code:" 
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Get-AzureProfileMap" {
    InModuleScope AzureRM.Bootstrapper {
        
        Mock Get-ProfileCachePath -Verifiable { return "MockPath\ProfileCache"}
        Mock Get-FileHashProfileMap -Verifiable { return "MockedHash" }

        Context "ProfileCachePath does not exist" {
            Mock New-Item -Verifiable { return "Creating ProfilePath"}
            Mock Get-RestResponse -Verifiable { return ($testProfileMap | ConvertFrom-Json) }
            Mock Test-Path -Verifiable { $false }
            Mock Out-File -Verifiable {}
            Mock Invoke-Expression -Verifiable {}
            It "Returns the proper ProfileMap" {
                Get-AzureProfileMap | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileCachePath Exists and hashes are equal" {
            Mock Test-Path -Verifiable { $true }
            Mock Get-RestResponse -Verifiable { return ($testProfileMap | ConvertFrom-Json) }
            Mock New-Item {}
            if (-not (Test-Path '.\mocksymlink.json'))
            {
                Invoke-Expression -Command "cmd /c mklink mocksymlink.json MockedHash.json"
            }

            $symlinkInfo = Get-ChildItem mocksymlink.json
            Mock Get-ChildItem -Verifiable { return $symlinkInfo }
            It "Returns Correct ProfileMap" {
                Get-AzureProfileMap | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
            It "Should not call New-Item" {
                Assert-MockCalled New-Item -Exactly 0
            }
            # Cleanup
            Remove-Item mocksymlink.json
        }

        Context "ProfileCachePath Exists and hashes are different" {
            Mock Test-Path -Verifiable { $true }
            Mock Get-RestResponse -Verifiable { return ($testProfileMap | ConvertFrom-Json) }
            Mock New-Item {}
            Mock RemoveWithRetry -Verifiable {}
            Mock Out-File -Verifiable {}
            Mock Invoke-Expression -Verifiable {}
            Mock Get-ChildItem -Verifiable { return "MockedHashDifferent.json" }
            It "Returns Correct ProfileMap" {
                Get-AzureProfileMap | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
            It "Should not call New-Item" {
                Assert-MockCalled New-Item -Exactly 0
            }
        }

        Context "Invoke-RestMethod throws exception" {
            Mock Invoke-RestMethod { throw [System.Net.WebException] }

            It "Throws Web Exception" {
                { Get-AzureProfileMap } | Should throw 
            }
        }
    }
}

Describe Get-AzProfile {
    InModuleScope AzureRM.Bootstrapper {
        
        Context "Forces update from Azure Endpoint" {
            Mock Get-AzureProfileMap { ($testProfileMap | ConvertFrom-Json) }
            
            It "Should get ProfileMap from Azure Endpoint" {
                 Get-AzProfile -Update  | Should Be "@{profile1=; profile2=}"
            }
            It "Checks Mock calls to Get-AzureProfileMap" {
                Assert-MockCalled Get-AzureProfileMap -Exactly 1
            }
        }
        
        Context "Gets Azure ProfileMap from Cache" {
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Test-Path -Verifiable { $true }
            Mock Get-Content -Verifiable { return $global:testProfileMap }
            
            It "Should get ProfileMap from Cache" {
                Get-AzProfile | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available from cache" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable { return $global:testProfileMap }

            It "Should get ProfileMap from Embedded source" {
                Get-AzProfile | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available in cache or Embedded source" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable {}

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

Describe "Install-ModuleHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Valid module and version" {
            Mock Install-Module -Verifiable {}
            It "Should call Install-Module" {
                Install-ModuleHelper -Module "Module1" -Profile 'Profile1' -ProfileMap ($global:testProfileMap | ConvertFrom-Json)
                Assert-MockCalled Install-Module -Exactly 1
            }
        }

        Context "Invalid module or version" {
            Mock Install-Module -Verifiable { throw }
            It "Should throw" {
                { Install-ModuleHelper -Module "Module1" -Profile 'Profile1' -ProfileMap ($global:testProfileMap | ConvertFrom-Json) } | Should Throw
                Assert-MockCalled Install-Module -Exactly 1
            }
        }
    }
}

Describe "Test-Dependencies" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { "MockCachePath" }
        Mock Get-ChildItem -Verifiable { @("MockFileName")}
        Mock Get-Content -Verifiable { $global:testProfileMap }
        It "Should return proper dependency map" {
            $result = Test-Dependencies 
            $result.Count | Should Be 4
            $result.'Module11.0'.Count | Should Be 2
        }
    }
}

Describe "Get-FileHashProfileMap" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfilesAvailable -Verifiable { "mockprofiles"}

        Context "Valid Profile Map " {
            $profilemapHash = New-Object -TypeName PSObject
            $profilemapHash | Add-Member -MemberType NoteProperty Hash("mockhash")
            Mock Get-FileHash -Verifiable { $profilemapHash }

            It "Should return proper hash" {
                (Get-FileHashProfileMap -ProfileMap ($global:testProfileMap | ConvertFrom-Json))| Should Be "mockhash"
                Assert-VerifiableMocks
            }
        }

        Context "Get-FileHash throws" {
            It "Should throw" {
                Mock Get-FileHash -Verifiable { throw }
                { Get-FileHashProfileMap -ProfileMap ($global:testProfileMap | ConvertFrom-Json)} | Should throw
            }
        }

        Context "Null Profile Map" {
            It "Should throw" {
                { Get-FileHashProfileMap -ProfileMap $null } | Should throw
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
        $pInstalled = @{'Profile1'= @{'Module1' = @('1.0') ;'Module2'= @('1.0')}}
        $dependencyIndex = @{'Module11.0'= @('Profile1'); 'Module22.0'= @('Profile2')}
        Mock Test-Dependencies -Verifiable { $dependencyIndex }
        Mock Get-AllProfilesInstalled -Verifiable { @('Profile1') }
        Context "Profile associated with Module version is installed" {
            It "Should return ProfilesAssociated" {
                $Result = (Test-ProfilesInstalled -Module 'Module1' -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -pInstalled $pInstalled -dependencyIndex $dependencyIndex)
                $Result | Should Be 'Profile1'
            }
        }

        Context "Profile associated with Module version is not installed" {
            It "Should return empty array" {
                $Result = (Test-ProfilesInstalled -Module 'Module2' -Profile 'Profile2' -PMap ($global:testProfileMap | ConvertFrom-Json) -pInstalled $pInstalled -dependencyIndex $dependencyIndex)
                $Result.Count | Should Be 0

            }
        }
    }
}

Describe "Uninstall-ModuleHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Remove-Module -Verifiable { "Removing module from session..." }
        Mock Uninstall-Module -Verifiable { "Uninstalling module..." }
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
                $callResult = Uninstall-ModuleHelper -Module 'Module1' -Version '1.0'
                $Script:mockCalled | Should Be 2
                $callResult[0] | Should Be "Removing module from session..."
                $callResult[1] | Should Be "Uninstalling module..."
                Assert-VerifiableMocks
            } 
        }

        Context "Modules are not installed" {
            Mock Get-Module -Verifiable {}
            It "Should not call Remove-Module or Uninstall-Module" {
                Uninstall-ModuleHelper -Module 'Module1' -Version '1.0'
                Assert-MockCalled Remove-Module -Exactly 0
                Assert-MockCalled Uninstall-Module -Exactly 0
            }
        }
    }
}

Describe "Uninstall-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Uninstall-ModuleHelper -Verifiable {}
        Context "Profile associated with the module is installed" {
            Mock Test-ProfilesInstalled -Verifiable { @("Profile1")}
            It "Should call Uninstall-ModuleHelper" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -Force
                Assert-VerifiableMocks
            }
        }

        Context "Profile associated with the module is not installed" {
            Mock Test-ProfilesInstalled -Verifiable { @()}
            Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
            It "Should not call Uninstall-ModuleHelper" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -Force
                Assert-MockCalled Uninstall-ModuleHelper -Exactly 0
            }
        }

        Context "More than 1 profile associated with the module are installed" {
            Mock Test-ProfilesInstalled -Verifiable { @('Profile1', 'Profile2')}
            It "Should not call Uninstall-ModuleHelper" {
                Uninstall-ProfileHelper -Profile 'Profile1' -PMap ($global:testProfileMap | ConvertFrom-Json) -Force
                Assert-MockCalled Uninstall-ModuleHelper -Exactly 0
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
            Mock Uninstall-ModuleHelper -Verifiable {}
            It "Should not invoke Uninstall module helper" {
                Invoke-UninstallModule -PMap ($global:testProfileMap | ConvertFrom-Json) -Profile 'profile1' -module 'module1'
                Assert-MockCalled Uninstall-ModuleHelper -Exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Remove-PreviousVersions" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Previous versions are installed" {
            $PreveiousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            $VersionObj = New-Object -TypeName System.Version -ArgumentList "0.1" 
            $moduleObj = New-Object -TypeName PSObject 
            $moduleObj | Add-Member NoteProperty Version($VersionObj)
            Mock Get-Module -Verifiable { $moduleObj}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should call Invoke-UninstallModule" {
                Remove-PreviousVersions -Profile 'Profile1' -PreviousMap ($PreveiousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-VerifiableMocks
            }
        }

        Context "Previous versions are not installed" {
            $PreveiousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersions -Profile 'Profile1' -PreviousMap ($PreveiousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-VerifiableMocks
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "No previous versions" {
            $PreveiousMap =  "{`"Profile0`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile3`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersions -Profile 'Profile1' -PreviousMap ($PreveiousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

        Context "Previous version is same as the latest version" {
            $PreveiousMap =  "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Module -Verifiable {}
            Mock Invoke-UninstallModule -Verifiable {}
            It "Should not call Invoke-UninstallModule" {
                Remove-PreviousVersions -Profile 'Profile1' -PreviousMap ($PreveiousMap|ConvertFrom-Json) -LatestMap ($global:testProfileMap|ConvertFrom-Json)
                Assert-MockCalled Get-Module -Exactly 0
                Assert-MockCalled Invoke-UninstallModule -Exactly 0
            }
        }

    }
}

Describe "Get-AllProfilesInstalled" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { '.\MockPath'}
        Mock Get-Content -Verifiable { $global:testProfileMap }
        Context "Profile Maps are available from cache" {
            Mock Test-Path -Verifiable { $true }
            Mock Get-ChildItem -Verifiable { @('ProfileMap.json', 'MockHash.json')}
            Mock Get-ProfilesInstalled -Verifiable { @{'Profile1'= @{'Module1'= '1.0'}}}
            It "Should return profiles Installed" {
                Get-AllProfilesInstalled | Should Be 'Profile1'
                Assert-MockCalled Get-Content -Exactly 1
                Assert-MockCalled Get-ProfilesInstalled -exactly 1
                Assert-VerifiableMocks
            }
        }

        Context "Profiles are not installed" {
            Mock Test-Path -Verifiable { $true }
            Mock Get-ChildItem -Verifiable { @('ProfileMap.json', 'MockHash.json')}
            Mock Get-ProfilesInstalled -Verifiable {}
            
            It "Should return empty" {
                $AllProfilesInstalled = @()
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled Get-Content -Exactly 1
                Assert-MockCalled Get-ProfilesInstalled -exactly 1
                Assert-VerifiableMocks
            }      
        }
        
        Context "Cache is empty" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-Content {}
            Mock Get-ProfilesInstalled {}
            It "Should return empty" {
                $result = (Get-AllProfilesInstalled)
                $result.Count | Should Be 0
                Assert-MockCalled Get-Content -Exactly 0
                Assert-MockCalled Get-ProfilesInstalled -exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Update-ProfileHelper" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-ProfileCachePath -Verifiable { '.\MockPath'}
        Mock Get-Content -Verifiable { $global:testProfileMap } -ParameterFilter { $Path -eq 'MockedHash.json'}
        $profilemapFileInfo = New-Object -TypeName  psobject
        $profilemapFileInfo | Add-Member NoteProperty 'Name' -Value 'ProfileMap.json'
        Mock Get-ChildItem -Verifiable { @($profilemapFileInfo, 'MockHash.json')} -ParameterFilter { $Path -eq '.\MockPath'}
        Invoke-Expression -Command "cmd /c mklink mocksymlink.json MockedHash.json"
        $symlinkInfo = Get-ChildItem mocksymlink.json
        Mock Get-ChildItem -Verifiable { return $symlinkInfo } -ParameterFilter { $Path -eq '.\MockPath\ProfileMap.json' }
        Mock Remove-PreviousVersions -Verifiable {}
        Mock Remove-ProfileMapFile {}

        Context "Previous Profile versions are available and they are installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Content -Verifiable { $PreviousMap }
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
            
            It "Should not remove previous profile map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Exactly 0
                Assert-VerifiableMocks
            }
        }

        Context "Previous profile versions are available but they are not installed" {
            $PreviousMap =  "{`"Profile1`": { `"Module1`": [`"0.1`"], `"Module2`": [`"0.1`"] }, `"Profile2`": { `"Module1`": [`"2.0`", `"1.0`"], `"Module2`": [`"2.0`"] }}" 
            Mock Get-Content -Verifiable { $PreviousMap }
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
            Mock Get-Content -Verifiable { $PreviousMap }
            Mock Get-ProfilesInstalled -Verifiable {@{'Profile1'= @{'Module1'= '1.0'}}}
            It "Should remove the previous profile map" {
                Update-ProfileHelper -profile 'Profile1'
                Assert-MockCalled Remove-ProfileMapFile -Times 1
                Assert-VerifiableMocks
            }
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

Describe "Add-SwitchParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        
        It "Should return Switch parameter object" {
            Add-SwitchParam $params "TestParam"
            $params.ContainsKey("TestParam") | Should Be $true
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
        Mock Install-ModuleHelper { "Installing module..."}
        Mock Import-Module -Verifiable { "Importing Module..."}
        
        Context "Modules not installed" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Length | Should Be 4
                $Result[0] | Should Be "Installing module..."
                $Result[1] | Should Be "Importing Module..."
                Assert-VerifiableMocks
            }
        }

        Context "Modules are installed" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            Mock Get-AzureRmModule -Verifiable { "1.0" } -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module2"}
            Mock Import-Module { "Module1 1.0 Imported"} -ParameterFilter { $Name -eq "Module1" -and $RequiredVersion -eq "1.0"}
            Mock Import-Module { "Module2 1.0 Imported"} -ParameterFilter { $Name -eq "Module2" -and $RequiredVersion -eq "1.0"}
            It "Should skip installing modules, imports the right version module" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force) 
                $Result.length | Should Be 2
                $Result[0] | Should Be "Module1 1.0 Imported"
                Assert-MockCalled Install-ModuleHelper -Exactly 0
                Assert-MockCalled Import-Module -Exactly 2
                Assert-VerifiableMocks
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
    }
}

Describe "Install-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Get-AzureRmModule -Verifiable {} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module1'}
        Mock Get-AzureRmModule -Verifiable { "1.0"} -ParameterFilter { $Profile -eq 'Profile1' -and $Module -eq 'Module2'}
        Context "Invoke with valid profile name" {
            Mock Install-ModuleHelper -Verifiable { "Installing module Module1... Version 1.0"} 
            It "Should install Module1" {
                (Install-AzureRmProfile -Profile 'Profile1') | Should be "Installing module Module1... Version 1.0"
                Assert-VerifiableMocks
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
    }
}

Describe "Uninstall-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Uninstall-ProfileHelper -Verifiable {}
        Context "Profile is installed" {
            Mock Get-ProfilesInstalled -Verifiable { @{'Profile1'= @{'Module1' = @('1.0') ;'Module2'= @('1.0')}}}
            It "Should remove and uninstall modules" {
                Uninstall-AzureRmProfile -Profile 'Profile1' -Force
                Assert-VerifiableMocks
            }
        }

        Context "Profile is not installed" {
            Mock Get-ProfilesInstalled -Verifiable {}
            It "Should not call Uninstall-ProfileHelper" {
                Uninstall-AzureRmProfile -Profile 'Profile1' -Force
                Assert-MockCalled Uninstall-ProfileHelper -Exactly 0
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
        Mock Use-AzureRmProfile -Verifiable {} -ParameterFilter { ($RemovePreviousVersions.IsPresent) -and ($Force.IsPresent)}
        Mock Update-ProfileHelper -Verifiable {}
    
        # Act
        Update-AzureRmProfile -Profile 'Profile2' -RemovePreviousVersions -Force

        # Assert
        It "Updates and Removes previous versions" {
            Assert-VerifiableMocks
        }
    }
}

