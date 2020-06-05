using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    using Microsoft.Azure.Management.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSGetRegistrationDefinition : PSRegistrationDefinition
    {
        [Ps1Xml(Label = "Scope", Target = ViewControl.Table, Position = 4)]
        public string Scope { get; set; }

        public PSGetRegistrationDefinition(RegistrationDefinition registrationDefinition, string scope) : base(registrationDefinition)
        {
            if (registrationDefinition != null)
            {
                this.Id = registrationDefinition.Id;

                this.Name = registrationDefinition.Name;
                this.Type = registrationDefinition.Type;
                this.Plan = new PSPlan(registrationDefinition.Plan);
                this.Properties = new PSRegistrationDefinitionProperties(registrationDefinition.Properties);
                this.Scope = scope;
            }
        }

    }
}
