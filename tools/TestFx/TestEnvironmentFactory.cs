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

using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Test.HttpRecorder;
using System;

namespace Microsoft.Azure.Commands.TestFx
{
    public static class TestEnvironmentFactory
    {
        private static readonly TestEnvironment _environment;

        static TestEnvironmentFactory()
        {
            string envStr = Environment.GetEnvironmentVariable(ConnectionStringKeys.TestCSMOrgIdConnectionStringKey);
            _environment = new TestEnvironment(envStr);
        }

        internal static TestEnvironment BuildTestFxEnvironment()
        {
            _environment.SetRecordedEnvironmentVariables();
            return _environment;
        }

        public static TestEnvironment GetTestEnvironment()
        {
            return _environment;
        }
    }
}
