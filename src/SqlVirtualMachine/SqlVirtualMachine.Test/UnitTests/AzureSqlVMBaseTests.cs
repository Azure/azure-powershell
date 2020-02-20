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

using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.ServiceManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Test.ScenarioTests.UnitTest
{
    public abstract class AzureSqlVMBaseTests
    {
        public List<String> UpsertParam;
        public List<String> OptionalUpsertParam;
        public HashSet<String> UpsertParamSet;


        public AzureSqlVMBaseTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        internal abstract void CheckResourceParameters(Type type, bool required = true);
        internal virtual void CheckResourceId(Type type)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceId", true, true);
        }

        internal virtual void CheckInputObject(Type type)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "InputObject", true, false);
        }

        internal virtual void CheckUpsertParameters(Type type, bool isMandatory)
        {
            foreach (String param in UpsertParam)
            {
                UnitTestHelper.CheckCmdletParameterAttributes(type, param, isMandatory, false, UpsertParamSet);
            }
            foreach (String param in OptionalUpsertParam)
            {
                UnitTestHelper.CheckCmdletParameterAttributes(type, param, false, false, UpsertParamSet);
            }
        }

        internal void CheckAsJobParameter(Type type)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "AsJob", false, false);
        }

        internal void CheckPassThruParameter(Type type)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "PassThru", false, false);
        }

        internal void CheckNewParameters(Type type)
        {
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, ConfirmImpact.Medium);

            CheckResourceParameters(type);

            CheckUpsertParameters(type, true);
            CheckAsJobParameter(type);
        }

        internal void CheckGetParameters(Type type)
        {
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "Name", true, false, ParameterSet.Name);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", null, false, new HashSet<String>() {
                ParameterSet.Name,
                ParameterSet.ResourceGroupOnly
            });
            CheckResourceId(type);
        }

        internal void CheckUpdateParameters(Type type)
        {
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, ConfirmImpact.Medium);

            CheckResourceParameters(type);
            CheckResourceId(type);
            CheckInputObject(type);

            CheckUpsertParameters(type, false);
            CheckAsJobParameter(type);
        }

        internal void CheckRemoveParameters(Type type)
        {
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, ConfirmImpact.Medium);

            CheckResourceParameters(type);
            CheckResourceId(type);
            CheckInputObject(type);

            CheckAsJobParameter(type);
            CheckPassThruParameter(type);
        }
    }
}