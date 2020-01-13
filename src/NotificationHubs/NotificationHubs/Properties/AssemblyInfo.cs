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

[assembly: AssemblyTitle("Microsoft Azure Powershell - NotificationHubs")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Microsoft Azure Powershell")]
[assembly: AssemblyCopyright("Copyright © Microsoft")]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]
[assembly: Guid("9e93b969-6685-4a67-b07d-cfd5ebd0091e")]
[assembly: AssemblyVersion("1.1.1")]
[assembly: AssemblyFileVersion("1.1.1")]
#if !SIGN
[assembly: InternalsVisibleTo("Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Test")]
#endif
