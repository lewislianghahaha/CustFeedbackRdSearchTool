using System.Data;

namespace CustFeedbackRdSearchTool
{
    public class GlobalClasscs
    {
        public struct ImportData
        {
            public DataTable ImporTable;
        }

        public struct SearchData
        {
            public DataTable SearchDt;
        }

        //保存导入的数据
        public static ImportData ImData;
        //保存查询后的数据
        public static SearchData SeaData;
    }
}
