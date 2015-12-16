using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ScenarioTest
{
    public static class PageExtensions 
    {
        public static void SetItemValue<T> (this Page<T> pagableObj, List<T> collection) {
            var property = typeof(Page<T>).GetProperty("Items", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(pagableObj, collection);
        }
    }
}
