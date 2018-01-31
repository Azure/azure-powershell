using System;

namespace Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters
{
    /// <summary>
    /// This attribute will allow the user to autocomplete the -Location parameter of a cmdlet with valid locations (as determined by the list of ResourceTypes given)
    /// </summary>
    abstract public class PSCompleterBaseAttribute : Attribute
    {
        abstract public string[] GetCompleterValues();
    }
}
