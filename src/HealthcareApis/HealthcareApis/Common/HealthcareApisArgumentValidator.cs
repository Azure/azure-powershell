using Microsoft.Azure.Commands.HealthcareApis.Properties;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Common
{
    public static class HealthcareApisArgumentValidator
    {

        public static bool ValidateObjectId(string AccessPolicyObjectId)
        {
            if (!Guid.TryParse(AccessPolicyObjectId, out _))
            {
                throw new PSArgumentException(Resources.invalidAccessPolicyObjectIdMessage);
            }

            return true;
        }
    }
}
