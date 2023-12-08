// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Microsoft Azure Powershell - Azure WebApp")]
[assembly: AssemblyCompany(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyCompany)]
[assembly: AssemblyProduct(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyProduct)]
[assembly: AssemblyCopyright(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyCopyright)]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]
[assembly: Guid("76158def-441b-472a-9b1a-a75726a813f4")]
[assembly: AssemblyVersion("3.1.2")]
[assembly: AssemblyFileVersion("3.1.2")]
#if !SIGN
[assembly: InternalsVisibleTo("Microsoft.Azure.PowerShell.Cmdlets.Websites.Test")]
#endif
