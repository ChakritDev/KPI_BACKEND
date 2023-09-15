using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPI_BACKEND.Models
{
    public class KPI_Model
    {
      public long KPI_ID {get;set;}
      public string KPIOrder {get;set;}
      public string KPICode {get;set;}
      public string KPIBullet {get;set;}
      public string KPIName {get;set;}
      public string KPILink {get;set;}
      public string Unit {get;set;}
      public string UnitDivider {get;set;}
      public string TargetYear {get;set;}
      public string HasValue {get;set;}
      public string IsCountryLevel {get;set;}
      public string TargetMonth {get;set;}
      public string ActualMonth {get;set;}
      public string Actual {get;set;}
      public string NoOfDecimalTarget {get;set;}
      public string MeasureType {get;set;}
      public string OrgOwnerCode {get;set;}
      public string OrgOwner {get;set;}
      public string Officer {get;set;}
      public string Tel {get;set;}
      public string EMail {get;set;}
      public string KPIColor {get;set;}
      public string ProblemCode {get;set;}
      public string Problem {get;set;}
      public string Explanation {get;set;}
      public string LastDataDate {get;set;}
      public string KPINameOnly {get;set;}
      public string Weight {get;set;}
      public string FirstScore {get;set;}
      public string FinalScore {get;set;}
      public DateTime CreatedDate {get;set;}
      public bool Active {get;set;}
    }

}