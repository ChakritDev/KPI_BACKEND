using KPI_BACKEND.Data;
using KPI_BACKEND.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages;

namespace KPI_BACKEND.Controllers
{
    public class ServiceController : ApiController
    {
        private GetDataKPI getData = new GetDataKPI();
        public ServiceController() 
        {

        }
        // GET: Service
        /*'2023','03','0393'*/
        public IHttpActionResult POST([FromBody] KPI_ASTAFF_Model _input)
        {
            try { 
           
                var _dataParam = getData.Get_DataWithParamID(_input.YYYY ?? "", _input.MM ?? "", _input.OrgCode ?? "")
                    .OrderBy(r=>r.OrgLevel).ThenBy(r => r.KPIOrder).GroupBy(g => g.OrgCode).ToList();

                var modifyData = _dataParam.Select(s=>s.Select(b => new KPI_Final_Model {OrgLevel = (long)b.OrgLevel,KpiOrder = (long)b.KPIOrder,HasValue = (bool)b.HasValue, 
                    KpiBullet = (!(bool)b.HasValue) ? double.Parse(b.KPIBullet).ToString() : double.Parse(b.KPIBullet).ToString(), KpiCode = b.KPICode,OrgCode = b.OrgCode,OrgName= b.OrgName,KpiName = b.KPIName,StatusColor = b.StatusColor, FinalScore=b.FinalScore,Weight = b.Weight,TargetMonth = (double)b.TargetMonth,ActualMonth = (double)b.ActualMonth , Unit = b.Unit })).ToList();

                /*long level = 1;
                var dataNewIndex = modifyData.Select(
                    s=>
                s.Select(
                        t1 => new KPI_Final_Model
                        {
                            //NumberID = (!(bool)t1.HasValue) ? (level != (long)t1.OrgLevel) ? mm = (mm - mm)+1 :  mm = Math.Round(++mm, 0) : Math.Round(mm = mm + 0.1, 2),
                            OrgLevel = level = (long)t1.OrgLevel,
                            KpiOrder = (long)t1.KPIOrder,
                            HasValue = (bool)t1.HasValue,
                            KpiBullet = t1.KPIBullet,
                            KpiCode = t1.KPICode,
                            OrgCode = t1.OrgCode,
                            OrgName = t1.OrgName,
                            KpiName = t1.KPIName,
                            StatusColor = t1?.StatusColor,
                            FinalScore = t1?.FinalScore,
                            Weight = t1?.Weight,
                            TargetMonth = (double)t1.TargetMonth,
                            ActualMonth = (double)t1.ActualMonth,
                            Unit = t1?.Unit
                        }
                    )
                );*/

                List<KPI_DATA> listData = new List<KPI_DATA>();

               for( int i = 0;i < modifyData.Count(); i++) 
                {
                   var cc = modifyData.ToList()[i];
                    for( int j = 0; j < cc.Count(); j++) 
                    {
                        var dd = cc.ToList()[j];
                        var gg = double.Parse(dd.KpiBullet) % 1;
                        if ((double.Parse(dd.KpiBullet) % 1) == 0)
                        {
                            listData.Add(
                                new KPI_DATA
                                {
                                    KpiBullet = dd.KpiBullet,
                                    KpiName = dd.KpiName,
                                    StatusColor = dd.StatusColor,
                                    FinalScore = dd.FinalScore,
                                    Weight = dd.Weight,
                                    ActualMonth = dd.ActualMonth,
                                    Unit = dd.Unit,
                                    HasValue = dd.HasValue,
                                    KpiCode = dd.KpiCode,
                                    KpiOrder = dd.KpiOrder,
                                    OrgCode = dd.OrgCode,
                                    OrgLevel = dd.OrgLevel,
                                    OrgName = dd.OrgName,
                                    TargetMonth = dd.TargetMonth,
                                }
                                );
                        }//end if 
                        else 
                        {
                            listData.Last().Childen.Add(
                            new KPI_Final_Model
                            {
                                KpiBullet = dd.KpiBullet,
                                KpiName = dd.KpiName,
                                StatusColor = dd.StatusColor,
                                FinalScore = dd.FinalScore,
                                Weight = dd.Weight,
                                ActualMonth = dd.ActualMonth,
                                Unit = dd.Unit,
                                HasValue = dd.HasValue,
                                KpiCode = dd.KpiCode,
                                KpiOrder = dd.KpiOrder,
                                OrgCode = dd.OrgCode,
                                OrgLevel = dd.OrgLevel,
                                OrgName = dd.OrgName,
                                TargetMonth = dd.TargetMonth,
                            }
                           );
                        }
                        
                        //listData.Add(new KPI_DATA { Childen = })
                    }
                }


                return Ok(listData.GroupBy(g=>g.OrgLevel).ToList());
            }
            catch (Exception) 
            {
                //string json = JsonConvert.SerializeObject(_data);
                throw;
            }

        }
    }
}