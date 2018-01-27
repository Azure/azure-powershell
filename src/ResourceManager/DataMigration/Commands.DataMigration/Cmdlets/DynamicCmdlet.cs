// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

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

            //Custom Init to creat your dynamic parameter list
            this.CustomInit();
        }

        public InvocationInfo MyInvocation { get; private set; }

        public RuntimeDefinedParameterDictionary RuntimeDefinedParams { get; private set; }

        public void SimpleParam(string paramName, Type type, string helpMessage, bool mandatory = false)
        {
            RuntimeDefinedParameter param = new RuntimeDefinedParameter(paramName, type, new Collection<Attribute>()
                {
                    new ParameterAttribute { Mandatory=mandatory, HelpMessage = helpMessage },
                    new ValidateNotNullOrEmptyAttribute()
                });

            this.RuntimeDefinedParams.Add(param.Name, param);
        }

        /// <summary>
        /// An initialization method that performs custom operations like creating dyanmic prams
        /// </summary>
        public abstract void CustomInit();
        
    }
}
