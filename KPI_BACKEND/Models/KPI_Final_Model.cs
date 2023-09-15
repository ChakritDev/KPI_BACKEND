using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPI_BACKEND.Models
{
    public class KPI_Final_Model
    {
        /*[JsonProperty("NumberID")]
        public double? NumberID { get; set; }*/

        [JsonProperty("OrgLevel")]
        public long OrgLevel { get; set; }

        [JsonProperty("KPIOrder")]
        public long KpiOrder { get; set; }

        [JsonProperty("HasValue")]
        public bool HasValue { get; set; }

        [JsonProperty("KPIBullet")]
        public string KpiBullet { get; set; }

        [JsonProperty("OrgCode")]
        public string OrgCode { get; set; }

        [JsonProperty("KPICode")]
        public string KpiCode { get; set; }

        [JsonProperty("OrgName")]
        public string OrgName { get; set; }

        [JsonProperty("KPIName")]
        public string KpiName { get; set; }

        [JsonProperty("StatusColor")]
        public long? StatusColor { get; set; }

        [JsonProperty("FinalScore")]
        public double? FinalScore { get; set; }

        [JsonProperty("Weight")]
        public long? Weight { get; set; }

        [JsonProperty("TargetMonth")]
        public double TargetMonth { get; set; }

        [JsonProperty("ActualMonth")]
        public double ActualMonth { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; } = null;
    }

    public class KPI_DATA
    {
        public long OrgLevel { get; set; }

        public long KpiOrder { get; set; }

        public bool HasValue { get; set; }

        public string KpiBullet { get; set; }

        public string OrgCode { get; set; }

        public string KpiCode { get; set; }

        public string OrgName { get; set; }

        public string KpiName { get; set; }

        public long? StatusColor { get; set; }

        public double? FinalScore { get; set; }

        public long? Weight { get; set; }

        public double TargetMonth { get; set; }

        public double ActualMonth { get; set; }

        public string Unit { get; set; } = null;

        public List<KPI_Final_Model> Childen { get; set; } = new List<KPI_Final_Model>();
    }

    public class KPI_RESULT_MODEL
    {
      public List<KPI_DATA> kPI_DATAs { get; set; } = new List<KPI_DATA> { new KPI_DATA() };
    }

    
}