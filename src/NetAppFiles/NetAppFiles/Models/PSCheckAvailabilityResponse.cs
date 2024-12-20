using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.Models
{
    public class PSCheckAvailabilityResponse
    {
        /// <summary>
        /// Gets or sets &lt;code&gt;true&lt;/code&gt; indicates name is valid and available.
        /// &lt;code&gt;false&lt;/code&gt; indicates the name is invalid, unavailable, or both.
        /// </summary>        
        public bool? IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets &lt;code&gt;Invalid&lt;/code&gt; indicates the name provided does not
        /// match Azure App Service naming requirements. &lt;code&gt;AlreadyExists&lt;/code&gt;
        /// indicates that the name is already in use and is therefore unavailable. Possible values include: &#39;Invalid&#39;, &#39;AlreadyExists&#39;
        /// </summary>        
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets if reason == invalid, provide the user with the reason why the
        /// given name is invalid, and provide the resource naming requirements so that
        /// the user can select a valid name. If reason == AlreadyExists, explain that
        /// resource name is already in use, and direct them to select a different
        /// name.
        /// </summary>        
        public string Message { get; set; }
    }
}
