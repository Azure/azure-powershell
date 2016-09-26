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
using Xunit;

[assembly: AssemblyTitle("Microsoft Azure Powershell - Common Library")]
[assembly: AssemblyCompany(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyCompany)]
[assembly: AssemblyProduct(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyProduct)]
[assembly: AssemblyCopyright(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.AssemblyCopyright)]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]
[assembly: Guid("080bc9b8-3c00-4d0e-bec2-38d2fd0d7061")]
[assembly: AssemblyVersion("2.1.0")]
[assembly: AssemblyFileVersion("2.1.0")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

#if SIGN
[assembly: InternalsVisibleTo("Microsoft.WindowsAzure.Commands.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
#else
[assembly: InternalsVisibleTo("Microsoft.WindowsAzure.Commands.Test")]
#endif
