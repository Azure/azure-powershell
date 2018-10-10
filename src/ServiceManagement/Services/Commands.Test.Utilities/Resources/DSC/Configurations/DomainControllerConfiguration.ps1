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

Configuration DomainController
{
    Import-DscResource -Name MSFT_xComputer, MSFT_xADDomain, MSFT_xADUser

    Node $AllNodes.Where({$_.MachineName -eq $VMName}).NodeName
    {   
        xComputer MachineName
        {
            Name     = $Node.MachineName
        }

        WindowsFeature ADDS
        {
            Ensure     = "Present"
            Name       = "AD-Domain-Services"
            DependsOn  = "[xComputer]MachineName"
        }

        xADDomain Forest
        {
            DomainName = $Node.DomainName
            DomainAdministratorCredential = (Import-Clixml $Node.DomainCredFile)
            SafemodeAdministratorPassword = (Import-Clixml $Node.DomainCredFile)
            DependsOn               = "[WindowsFeature]ADDS"
        }  
                
        foreach($User in $Node.Users)
        {
            xADUser $User.UserName
            {
                Ensure = "Present"
                UserName = $User.UserName
                Password = (Import-Clixml $User.UserCredFile)
                DomainName = $Node.DomainName
                DomainAdministratorCredential = (Import-Clixml $Node.DomainCredFile)
                DependsOn = "[DNSTransferZone]Setting"
            }
        }
    }
}
