using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustFeedbackRdSearchTool
{
    public class TaskLogic
    {
        ImportDt importDt = new ImportDt();
        Generate generate = new Generate();

        #region 变量参数
        private int _taskid;
        private string _fileAddress;       //文件地址

        private DataTable _resultTable;   //返回DT(运算使用)
        private bool _resultMark;        //返回是否成功标记
        private string _searchvalue;     //返回查询值
        #endregion

        #region Set

        /// <summary>
        /// 中转ID
        /// </summary>
        public int TaskId { set { _taskid = value; } }

        /// <summary>
        /// //接收文件地址信息
        /// </summary>
        public string FileAddress { set { _fileAddress = value; } }

        /// <summary>
        /// 返回查询值
        /// </summary>
        public string Searchvalue { set { _searchvalue = value; } }

        #endregion

        #region Get

        /// <summary>
        ///  返回是否成功标记
        /// </summary>
        public bool ResultMark => _resultMark;

        /// <summary>
        ///返回DataTable至主窗体
        /// </summary>
        public DataTable ResultTable => _resultTable;

        #endregion

        public void StartTask()
        {
            switch (_taskid)
            {
                //导入
                case 0:
                    OpenExcelImportToDt(_fileAddress);
                    break;
                //查询
                case 1:
                    GenerateSearchRd(_searchvalue);
                    break;
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="fileAddress"></param>
        private void OpenExcelImportToDt(string fileAddress)
        {
            //若_resultTable有值,即先将其清空,再进行赋值
            if (_resultTable?.Rows.Count > 0)
            {
                _resultTable.Rows.Clear();
                _resultTable.Columns.Clear();
            }
            _resultTable = importDt.OpenExcelImporttoDt(fileAddress).Copy();
        }

        /// <summary>
        /// 查询记录
        /// </summary>
        private void GenerateSearchRd(string searchvalue)
        {
            generate.GenerateSearchRd(searchvalue);
        }

    }
}
