# ----------------------------------------------------------------------------------
#
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

param([string] $VMName, [string] $VMConfigDataPath, [string] $MofDestinationPath)

Configuration CorpClientVMConfiguration
{ 
    Node $AllNodes.Where{$_.Role -eq "CorpClient"}.NodeName
    {     	
       Import-DscResource -Name MSFT_xComputer
	   
        xComputer NameAndDomain
        {
            Name     = $Node.MachineName
            DomainName = $Node.DomainName
            Credential = (Import-CliXML $Node.DomainCredFile)
        }

        Group RemoteDesktop
        {
            Ensure     = "Present"
            GroupName  = "Remote Desktop Users"
            Members    = @("Corporate\User1","Corporate\PAPA","Corporate\DeptHead")
            Credential = (Import-CliXML $Node.DomainCredFile)
            DependsOn  = "[xComputer]NameAndDomain"
        }
        
        Group Administrator
        {
            Ensure           = "Present"
            GroupName        = "Administrators"
            MembersToInclude = @("Corporate\PAPA","Corporate\DeptHead")
            Credential       = (Import-CliXML $Node.DomainCredFile)
            DependsOn        = "[xComputer]NameAndDomain"
        }
    }
}

# Generate mof
$scriptLocation = $PSScriptRoot
. CorpClientVMConfiguration -OutputPath .
