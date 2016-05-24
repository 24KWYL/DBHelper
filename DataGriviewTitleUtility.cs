using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBHelper
{
   public  class DataGriviewTitleUtility
    {
       /// <summary>
       /// 设置DataGridView标题绑定
       /// </summary>
       /// <param name="dt"></param>
       /// <returns></returns>
       public static DataTable CreatBandingTitleDQ(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("DQ", "地区");
           dic.Add("KTXM", "勘探项目");
           dic.Add("JB", "井别");
           dic.Add("JH", "井号");
           dic.Add("SSND", "所属年度");
           dic.Add("JZ", "井字");
           dic.Add("TXLB", "类别");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreateBandingTitleGWJDWZ(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("jh","井号");
           dic.Add("qxcs","取心筒次");
           dic.Add("gwjdwz","归位距顶位置");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreateBandingTitleSD(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("jh", "井号");
           dic.Add("qxcs", "取心筒次");
           dic.Add("gwqssd", "归位起始深度");
           dic.Add("gwzzsd", "归位终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitle_DataBaseSourceConfigure(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("FIELD1", "SourceFieldName");
           dic.Add("FIELD2", "DestinationFieldName");
           dic.Add("LX1", "SourceFieldType");
           dic.Add("LX2", "DestinationFieldType");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleT_DATATRANS(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("TABLE1", "源表名");
           dic.Add("FIELD1", "源字段名");
           dic.Add("LX1", "源字段类型");
           dic.Add("TABLE2", "目标表名");
           dic.Add("FIELD2", "目标字段名");
           dic.Add("LX2", "目标字段类型");
           dic.Add("GZM", "规则名称");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleT_TABLE1(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("GZM", "名称");
           dic.Add("TABLE1", "源数据表");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleT_TABLE2(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("TABLE2", "目的数据表");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleQXTC(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("ZZSD", "终止深度");
           dic.Add("QXTC", "取心筒次");
           dic.Add("QSSD", "起始深度");
           dic.Add("JH", "井号");
           dic.Add("SHL", "收获率");
           dic.Add("JC", "进尺");
           dic.Add("XC", "心长");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreateBandingTitleQXTC_G(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH","井号");
           dic.Add("QXTC", "取心筒次");
           dic.Add("QSSD", "起始深度");
           dic.Add("ZZSD", "终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleXZJBQX(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("YXBH", "岩心编号");
           dic.Add("ZQM", "纵切面");
           dic.Add("WBM", "外表面");
           dic.Add("YX", "主要岩性");
           dic.Add("BZ", "备注");
           dic.Add("QSSD", "起始深度");
           dic.Add("ZZSD", "终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_YGTX_LS(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_YGTX(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           dic.Add("GWJDWZ","归位距顶位置");
           dic.Add("GWSMXC", "归位扫描长度");
           dic.Add("GWQSSD", "归位起始深度");
           dic.Add("GWZZSD", "归位终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_ZQM(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           dic.Add("GWJDWZ", "归位距顶位置");
           dic.Add("GWSMXC", "归位扫描长度");
           dic.Add("GWQSSD", "归位起始深度");
           dic.Add("GWZZSD", "归位终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_ZQM_LS(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_WBM_LS(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
       public static DataTable CreatBandingTitleYXTX_WBM(DataTable dt)
       {
           Dictionary<string, string> dic = new Dictionary<string, string>();
           dic.Add("JH", "井号");
           dic.Add("QXJD", "取心井段");
           dic.Add("QXCS", "取心次数");
           dic.Add("YXBH", "岩心编号");
           dic.Add("QSSD", "起始深度");
           dic.Add("SMXC", "扫描长度");
           dic.Add("ZZSD", "终止深度");
           dic.Add("CW", "层位");
           dic.Add("CH", "层号");
           dic.Add("JDWZ", "距顶位置");
           dic.Add("QXRQ", "取心日期");
           dic.Add("LRRQ", "录入日期");
           dic.Add("ZZYX", "主要岩性");
           dic.Add("YS", "颜色");
           dic.Add("JSJG", "解释结果");
           dic.Add("SYJG", "试油结果");
           dic.Add("WBM", "外表面");
           dic.Add("ZQM", "纵切面");
           dic.Add("YGTX", "荧光图像");
           dic.Add("GWJDWZ", "归位距顶位置");
           dic.Add("GWSMXC", "归位扫描长度");
           dic.Add("GWQSSD", "归位起始深度");
           dic.Add("GWZZSD", "归位终止深度");
           foreach (string key in dic.Keys)
           {
               dt.Columns[key].ColumnName = dic[key];
           }
           return dt;
       }
    }
}
