using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.ICommon
{
    public interface IOfficeHelper
    {
        DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true);
    }
}
