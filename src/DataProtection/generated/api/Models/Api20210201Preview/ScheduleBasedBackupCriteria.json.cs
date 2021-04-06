namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Schedule based backup criteria</summary>
    public partial class ScheduleBasedBackupCriteria
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new ScheduleBasedBackupCriteria(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="ScheduleBasedBackupCriteria" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ScheduleBasedBackupCriteria(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __backupCriteria = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.BackupCriteria(json);
            {_absoluteCriterion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("absoluteCriteria"), out var __jsonAbsoluteCriteria) ? If( __jsonAbsoluteCriteria as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker) (__u is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString __t ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker)(__t.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker)""))) ))() : null : AbsoluteCriterion;}
            {_daysOfMonth = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("daysOfMonth"), out var __jsonDaysOfMonth) ? If( __jsonDaysOfMonth as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDay[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDay) (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.Day.FromJson(__p) )) ))() : null : DaysOfMonth;}
            {_daysOfTheWeek = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("daysOfTheWeek"), out var __jsonDaysOfTheWeek) ? If( __jsonDaysOfTheWeek as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek) (__k is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString __j ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek)(__j.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek)""))) ))() : null : DaysOfTheWeek;}
            {_monthsOfYear = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("monthsOfYear"), out var __jsonMonthsOfYear) ? If( __jsonMonthsOfYear as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month) (__f is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString __e ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month)(__e.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month)""))) ))() : null : MonthsOfYear;}
            {_scheduleTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("scheduleTimes"), out var __jsonScheduleTimes) ? If( __jsonScheduleTimes as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<global::System.DateTime[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(global::System.DateTime) (__a is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString ___z ? global::System.DateTime.TryParse((string)___z, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var ___zValue) ? ___zValue : default(global::System.DateTime) : default(global::System.DateTime))) ))() : null : ScheduleTime;}
            {_weeksOfTheMonth = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("weeksOfTheMonth"), out var __jsonWeeksOfTheMonth) ? If( __jsonWeeksOfTheMonth as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber) (___v is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString ___u ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber)(___u.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber)""))) ))() : null : WeeksOfTheMonth;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ScheduleBasedBackupCriteria" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ScheduleBasedBackupCriteria" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __backupCriteria?.ToJson(container, serializationMode);
            if (null != this._absoluteCriterion)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __x in this._absoluteCriterion )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("absoluteCriteria",__w);
            }
            if (null != this._daysOfMonth)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __s in this._daysOfMonth )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("daysOfMonth",__r);
            }
            if (null != this._daysOfTheWeek)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __n in this._daysOfTheWeek )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("daysOfTheWeek",__m);
            }
            if (null != this._monthsOfYear)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __i in this._monthsOfYear )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("monthsOfYear",__h);
            }
            if (null != this._scheduleTime)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __d in this._scheduleTime )
                {
                    AddIf((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__d.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) ,__c.Add);
                }
                container.Add("scheduleTimes",__c);
            }
            if (null != this._weeksOfTheMonth)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var ___y in this._weeksOfTheMonth )
                {
                    AddIf(null != (((object)___y)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(___y.ToString()) : null ,___x.Add);
                }
                container.Add("weeksOfTheMonth",___x);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}