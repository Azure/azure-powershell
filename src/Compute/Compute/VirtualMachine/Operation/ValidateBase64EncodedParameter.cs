using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.VirtualMachine.Operation
{
    public class ValidateBase64EncodedParameterOld : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var inputtedString = arguments as string;
        }
    }
}
