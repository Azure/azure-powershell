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

namespace StaticAnalysis
{
    public static class AppDomainHelpers
    {
        /// <summary>
        /// Create a new AppDomain and create a remote instance of AssemblyLoader we can use there
        /// </summary>
        /// <param name="directoryPath">directory containing assemblies</param>
        /// <param name="testDomain">A new AppDomain, where assemblies can be loaded</param>
        /// <returns>A proxy to the AssemblyLoader running in the newly created app domain</returns>
        public static T CreateProxy<T>(string directoryPath, out AppDomain testDomain) where T:MarshalByRefObject
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException("directoryPath");
            }

            var setup = new AppDomainSetup();
            setup.ApplicationBase = directoryPath;
            setup.ApplicationName = "TestDomain";
            setup.ApplicationTrust = AppDomain.CurrentDomain.ApplicationTrust;
            setup.DisallowApplicationBaseProbing = false;
            setup.DisallowCodeDownload = false;
            setup.DisallowBindingRedirects = false;
            setup.DisallowPublisherPolicy = false;
            testDomain = AppDomain.CreateDomain("TestDomain", null, setup);
            return testDomain.CreateInstanceFromAndUnwrap(typeof(T).Assembly.Location,
                typeof(T).FullName) as T;
        }
    }
}
