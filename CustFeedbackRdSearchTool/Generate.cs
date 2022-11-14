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
            //todo:设置输出临时表
            GlobalClasscs.SeaData.SearchDt = dtList.Get_Importdt();

            try
            {
                //todo:

            }
            catch (Exception)
            {
                
                throw;
            }


        }
    }
}
