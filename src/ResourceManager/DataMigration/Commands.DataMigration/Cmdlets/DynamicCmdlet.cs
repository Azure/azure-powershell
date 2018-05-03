// // ----------------------------------------------------------------------------------
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
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public abstract class DynamicCmdlet
    {
        public DynamicCmdlet(InvocationInfo myInvocation)
        {
            if (myInvocation == null)
            {
                throw new ArgumentNullException("InvocationInfo");
            }

            this.MyInvocation = myInvocation;
            this.RuntimeDefinedParams = new RuntimeDefinedParameterDictionary();

            //Custom Init to create your dynamic parameter list
            this.CustomInit();
        }

        public InvocationInfo MyInvocation { get; private set; }

        public RuntimeDefinedParameterDictionary RuntimeDefinedParams { get; private set; }

        public void SimpleParam(string paramName, Type type, string helpMessage, bool mandatory = false, params string[] argumentCompleterList)
        {
            RuntimeDefinedParameter param = new RuntimeDefinedParameter(paramName, type, new Collection<Attribute>()
                {
                    new ParameterAttribute { Mandatory=mandatory, HelpMessage = helpMessage },
                    new ValidateNotNullOrEmptyAttribute(),
                    new PSArgumentCompleterAttribute(argumentCompleterList)
                });

            this.RuntimeDefinedParams.Add(param.Name, param);
        }

        /// <summary>
        /// An initialization method that performs custom operations like creating dyanmic prams
        /// </summary>
        public abstract void CustomInit();

    }
}
