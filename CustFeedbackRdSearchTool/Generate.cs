using System;
using System.Data;

namespace CustFeedbackRdSearchTool
{
    public class Generate
    {
        DtList dtList=new DtList();

        /// <summary>
        /// 根据指定记录查询相关值
        /// </summary>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        public void GenerateSearchRd(string searchvalue)
        {
            var searchlist = string.Empty;
        
            //设置查询临时表
            var searchdt = dtList.Get_Searchdt();

            try
            {
                //收集从EXCEL导入的信息
                var importdt = GlobalClasscs.ImData.ImporTable.Copy();

                //根据查询条件查询出相关值,并返回
                var dtlrows = importdt.Select("历史反馈配方内部色号 like '%"+searchvalue+ "%'");
                if (dtlrows.Length > 0)
                {
                    for (var i = 0; i < dtlrows.Length; i++)
                    {
                        //整合数据
                        searchlist = Convert.ToString(dtlrows[i][1])+","
                                     +Convert.ToString(dtlrows[i][2])+"序号"+Convert.ToString(dtlrows[i][3])
                                     +","+Convert.ToString(dtlrows[i][4])+Convert.ToString(dtlrows[i][6])+
                                     "反馈"+Convert.ToString(dtlrows[i][5]);

                        var newrow = searchdt.NewRow();
                        newrow[0] = dtlrows[i][0]; //历史反馈配方内部色号
                        newrow[1] = searchlist;    //查询结果
                        searchdt.Rows.Add(newrow);
                    }
                    //todo:无论有没有记录,都将searchdt的内容赋值至GlobalClasscs.SeaData.SearchDt内
                    GlobalClasscs.SeaData.SearchDt = searchdt.Copy();
                }
                else
                {
                    GlobalClasscs.SeaData.SearchDt = searchdt.Clone();
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                GlobalClasscs.SeaData.SearchDt.Rows.Clear();
            }
        }
    }
}
