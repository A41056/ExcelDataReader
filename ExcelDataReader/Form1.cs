using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelDataReader
{
    public partial class Form1 : Form
    {

        DataTableCollection dataTableCollection;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tenfile_txt.Text = openFileDialog.FileName;
                    using(var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_)=> new ExcelDataTableConfiguration() { UseHeaderRow = true}
                            });
                            dataTableCollection = result.Tables;
                            cbData.DataSource = null;
                            cbSheet.Items.Clear();
                            cbSheet.Items.AddRange(dataTableCollection.Cast<DataTable>().Select(t => t.TableName).ToArray<string>());
                        }
                    }
                    
                }
            }
        }

        DataTable dt;
        private void cbSheet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // lấy cột
            dt = dataTableCollection[cbSheet.SelectedItem.ToString()];
            var columnNames = (from c in dt.Columns.Cast<DataColumn>()
                               select c.ColumnName).ToArray();
            cbColumn.Items.Clear();
            cbColumn.Items.AddRange(columnNames);
        }

        private void cbColumn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //    using(QuanLyKhoEntities db = new QuanLyKhoEntities())
        //    {
        //        dataGridView1.DataSource = db.Customers.ToList();
        //    }
        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
           
            data_CC.Rows.Insert(0, row);

            data_CC.Rows[0].Cells[0].Value = "id";
            data_CC.Rows[0].Cells[1].Value = "student_code";
            data_CC.Rows[0].Cells[2].Value = "study_module_code";
            data_CC.Rows[0].Cells[3].Value = "evaluation_template_code";
            data_CC.Rows[0].Cells[4].Value = "evaluation_point_code";
            data_CC.Rows[0].Cells[5].Value = "quantitative_result";
            data_CC.Rows[0].Cells[6].Value = "qualitative_result";
            data_CC.Rows[0].Cells[7].Value = "study_evaluation_result_status";


            data_CC.SelectAll();
            DataObject copydata = data_CC.GetClipboardContent();
            if (copydata != null)
            {
                Clipboard.SetDataObject(copydata);
            }
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object misseddata = System.Reflection.Missing.Value;
            xlWook = xlapp.Workbooks.Add(misseddata);
            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[1, 1];
            xlr.Select();

            xlSheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
       
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(txt_somon.Text == " " || txt_mamon.Text == " " || txt_sttmon.Text == " ")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!");
            }
            else
            {
                Data_CC();

            }


        }
        public void Data_CC()
        {
           
            int SoCot = 5 + 9 * (Int32.Parse(txt_somon.Text) - 1);
            if (dt != null)
            {
                string columnName = cbColumn.SelectedItem.ToString();

                var data = dt.DefaultView.ToTable(false, columnName);

                cbData.DataSource = data;
                cbData.DisplayMember = columnName;
                cbData.ValueMember = columnName;


                for (int i = 0; i <= SoCot; i++)
                {
                    data_CC.Columns.Add(new DataGridViewTextBoxColumn());
                }

                foreach (DataRow dr in dt.Rows)
                {
                    data_CC.Rows.Add(dr.ItemArray);
                }


                for (int i = 0; i < 4; i++)
                {
                    data_CC.Rows.RemoveAt(0);
                }

                data_CC.Columns.RemoveAt(0);// xóa cột id gốc
                data_CC.Columns.RemoveAt(3);// xóa cột ngày sinh
                data_CC.Columns.RemoveAt(2);// xóa cột họ tên
                data_CC.Columns.RemoveAt(0);// xóa cột mã lớp


                DataGridViewColumn idColumn = new DataGridViewColumn();
                idColumn.Name = "id";
                idColumn.DataPropertyName = "id";
                idColumn.CellTemplate = new DataGridViewTextBoxCell();
                data_CC.Columns.Insert(0, idColumn);

                DataGridViewColumn moduleColumn = new DataGridViewColumn();
                moduleColumn.Name = "study_module_code";
                moduleColumn.DataPropertyName = "study_module_code";
                moduleColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(2, moduleColumn);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {
                    data_CC.Rows[i].Cells[2].Value = txt_mamon.Text;
                }

                DataGridViewColumn evaColumn = new DataGridViewColumn();
                evaColumn.Name = "evaluation_template_code";
                evaColumn.DataPropertyName = "evaluation_template_code";
                evaColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(3, evaColumn);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {

                    data_CC.Rows[i].Cells[3].Value = "CC";

                }

                //dataGridView2.Columns[0].HeaderText = "id";
                data_CC.Columns[1].HeaderText = "student_code";

                DataGridViewColumn statusColumn = new DataGridViewColumn();
                statusColumn.Name = "study_evaluation_result_status";
                statusColumn.DataPropertyName = "study_evaluation_result_status";
                statusColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(SoCot, statusColumn);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {

                    data_CC.Rows[i].Cells[SoCot].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }
                
                DataGridViewColumn thk2Column = new DataGridViewColumn();
                thk2Column.Name = "qualitative_result";
                thk2Column.DataPropertyName = "qualitative_result";
                thk2Column.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(5, thk2Column);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {

                    data_CC.Rows[i].Cells[5].Value = " ";

                }

                data_CC.Columns[4].HeaderText = "quantitative_result";

                DataGridViewColumn QCColumn = new DataGridViewColumn();
                QCColumn.Name = "evaluation_template_code";
                QCColumn.DataPropertyName = "evaluation_template_code";
                QCColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(3, QCColumn);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {
                    data_CC.Rows[i].Cells[3].Value = "QC-53";
                }

                if(Int32.Parse(txt_sttmon.Text) == 1)
                {
                    for (int i = 0; i < 2 + (9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text))); i++)
                    {
                        data_CC.Columns.RemoveAt(6);
                    }
                }
                else
                {
                    for (int i = 0; i <= (9 * (Int32.Parse(txt_sttmon.Text) - 1)); i++)
                    {
                        data_CC.Columns.RemoveAt(5);
                    }
                    for (int i = 0; i <= 9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text)); i++)
                    {
                        data_CC.Columns.RemoveAt(6);

                    }
                }
                DataGridViewColumn statusColumn2 = new DataGridViewColumn();
                statusColumn2.Name = "study_evaluation_result_status";
                statusColumn2.DataPropertyName = "study_evaluation_result_status";
                statusColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(data_CC.Columns.Count, statusColumn2);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {

                    data_CC.Rows[i].Cells[data_CC.Columns.Count - 1].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }
                DataGridViewColumn evaColumn2 = new DataGridViewColumn();
                evaColumn2.Name = "qualitative_result";
                evaColumn2.DataPropertyName = "qualitative_result";
                evaColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_CC.Columns.Insert(data_CC.Columns.Count - 1, evaColumn2);
                for (int i = 0; i < data_CC.Rows.Count - 1; i++)
                {

                    data_CC.Rows[i].Cells[data_CC.Columns.Count - 2].Value = "";

                }
                data_CC.Columns[5].HeaderText = "quantitative_result";


            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            data_CC.Rows.Clear();
            data_CC.Columns.Clear();
            txt_somon.Clear();
            txt_mamon.Clear();
            txt_sttmon.Clear();
        }

        private void btn_ok_qt_Click(object sender, EventArgs e)
        {
            if (txt_somon.Text == " " || txt_mamon.Text == " " || txt_sttmon.Text == " ")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!");
            }
            else
            {
                Data_QT();


            }
        }

        public void Data_QT()
        {
            int SoCot = 6 + 9 * (Int32.Parse(txt_somon.Text) - 1);
            if (dt != null)
            {
                string columnName = cbColumn.SelectedItem.ToString();

                var data = dt.DefaultView.ToTable(false, columnName);

                cbData.DataSource = data;
                cbData.DisplayMember = columnName;
                cbData.ValueMember = columnName;


                for (int i = 0; i <= SoCot; i++)
                {
                    data_QT.Columns.Add(new DataGridViewTextBoxColumn());
                }

                foreach (DataRow dr in dt.Rows)
                {
                    data_QT.Rows.Add(dr.ItemArray);
                }


                for (int i = 0; i < 4; i++)
                {
                    data_QT.Rows.RemoveAt(0);
                }

                data_QT.Columns.RemoveAt(0);// xóa cột id gốc
                data_QT.Columns.RemoveAt(3);// xóa cột ngày sinh
                data_QT.Columns.RemoveAt(2);// xóa cột họ tên
                data_QT.Columns.RemoveAt(0);// xóa cột mã lớp


                DataGridViewColumn idColumn = new DataGridViewColumn();
                idColumn.Name = "id";
                idColumn.DataPropertyName = "id";
                idColumn.CellTemplate = new DataGridViewTextBoxCell();
                data_QT.Columns.Insert(0, idColumn);

                DataGridViewColumn moduleColumn = new DataGridViewColumn();
                moduleColumn.Name = "study_module_code";
                moduleColumn.DataPropertyName = "study_module_code";
                moduleColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(2, moduleColumn);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {
                    data_QT.Rows[i].Cells[2].Value = txt_mamon.Text;
                }

                DataGridViewColumn evaColumn = new DataGridViewColumn();
                evaColumn.Name = "evaluation_template_code";
                evaColumn.DataPropertyName = "evaluation_template_code";
                evaColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(3, evaColumn);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {

                    data_QT.Rows[i].Cells[3].Value = "QT";

                }

                //dataGridView2.Columns[0].HeaderText = "id";
                data_QT.Columns[1].HeaderText = "student_code";

                DataGridViewColumn statusColumn = new DataGridViewColumn();
                statusColumn.Name = "study_evaluation_result_status";
                statusColumn.DataPropertyName = "study_evaluation_result_status";
                statusColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(SoCot, statusColumn);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {

                    data_QT.Rows[i].Cells[SoCot].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }

                DataGridViewColumn thk2Column = new DataGridViewColumn();
                thk2Column.Name = "qualitative_result";
                thk2Column.DataPropertyName = "qualitative_result";
                thk2Column.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(5, thk2Column);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {

                    data_QT.Rows[i].Cells[5].Value = " ";

                }

                data_QT.Columns[4].HeaderText = "quantitative_result";

                DataGridViewColumn QCColumn = new DataGridViewColumn();
                QCColumn.Name = "evaluation_template_code";
                QCColumn.DataPropertyName = "evaluation_template_code";
                QCColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(3, QCColumn);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {
                    data_QT.Rows[i].Cells[3].Value = "QC-53";
                }

                if (Int32.Parse(txt_sttmon.Text) == 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        data_QT.Columns.RemoveAt(5);

                    }
                    for (int i = 0; i < 1 + (9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text))); i++)
                    {
                        data_QT.Columns.RemoveAt(6);
                    }
                }
                else
                {
                    for (int i = 0; i <= (9 * (Int32.Parse(txt_sttmon.Text) - 1)) + 1 ; i++)
                    {
                        data_QT.Columns.RemoveAt(5);
                    }
                    for (int i = 0; i <=  9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text)); i++)
                    {
                        data_QT.Columns.RemoveAt(6);

                    }
                }
                DataGridViewColumn statusColumn2 = new DataGridViewColumn();
                statusColumn2.Name = "study_evaluation_result_status";
                statusColumn2.DataPropertyName = "study_evaluation_result_status";
                statusColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(data_QT.Columns.Count, statusColumn2);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {

                    data_QT.Rows[i].Cells[data_QT.Columns.Count - 1].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }
                DataGridViewColumn evaColumn2 = new DataGridViewColumn();
                evaColumn2.Name = "qualitative_result";
                evaColumn2.DataPropertyName = "qualitative_result";
                evaColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_QT.Columns.Insert(data_QT.Columns.Count - 1, evaColumn2);
                for (int i = 0; i < data_QT.Rows.Count - 1; i++)
                {

                    data_QT.Rows[i].Cells[data_QT.Columns.Count - 2].Value = "";

                }
                data_QT.Columns[5].HeaderText = "quantitative_result";

            }
        }

        private void btn_refresh_qt_Click(object sender, EventArgs e)
        {
            data_QT.Rows.Clear();
            data_QT.Columns.Clear();
            txt_somon.Clear();
            txt_mamon.Clear();
            txt_sttmon.Clear();
        }

        private void btn_ok_thk1_Click(object sender, EventArgs e)
        {
            if (txt_somon.Text == " " || txt_mamon.Text == " " || txt_sttmon.Text == " ")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!");
            }
            else
            {
                Data_THK1();
            }
        }

        public void Data_THK1()
        {
            int SoCot = 7 + 9 * (Int32.Parse(txt_somon.Text) - 1);
            if (dt != null)
            {
                string columnName = cbColumn.SelectedItem.ToString();

                var data = dt.DefaultView.ToTable(false, columnName);

                cbData.DataSource = data;
                cbData.DisplayMember = columnName;
                cbData.ValueMember = columnName;


                for (int i = 0; i <= SoCot; i++)
                {
                    data_THK1.Columns.Add(new DataGridViewTextBoxColumn());
                }

                foreach (DataRow dr in dt.Rows)
                {
                    data_THK1.Rows.Add(dr.ItemArray);
                }


                for (int i = 0; i < 4; i++)
                {
                    data_THK1.Rows.RemoveAt(0);
                }

                data_THK1.Columns.RemoveAt(0);// xóa cột id gốc
                data_THK1.Columns.RemoveAt(3);// xóa cột ngày sinh
                data_THK1.Columns.RemoveAt(2);// xóa cột họ tên
                data_THK1.Columns.RemoveAt(0);// xóa cột mã lớp


                DataGridViewColumn idColumn = new DataGridViewColumn();
                idColumn.Name = "id";
                idColumn.DataPropertyName = "id";
                idColumn.CellTemplate = new DataGridViewTextBoxCell();
                data_THK1.Columns.Insert(0, idColumn);

                DataGridViewColumn moduleColumn = new DataGridViewColumn();
                moduleColumn.Name = "study_module_code";
                moduleColumn.DataPropertyName = "study_module_code";
                moduleColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(2, moduleColumn);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {
                    data_THK1.Rows[i].Cells[2].Value = txt_mamon.Text;
                }

                DataGridViewColumn evaColumn = new DataGridViewColumn();
                evaColumn.Name = "evaluation_template_code";
                evaColumn.DataPropertyName = "evaluation_template_code";
                evaColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(3, evaColumn);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {

                    data_THK1.Rows[i].Cells[3].Value = "THK1";

                }

                //dataGridView2.Columns[0].HeaderText = "id";
                data_THK1.Columns[1].HeaderText = "student_code";

                DataGridViewColumn statusColumn = new DataGridViewColumn();
                statusColumn.Name = "study_evaluation_result_status";
                statusColumn.DataPropertyName = "study_evaluation_result_status";
                statusColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(SoCot, statusColumn);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {

                    data_THK1.Rows[i].Cells[SoCot].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }

                DataGridViewColumn thk2Column = new DataGridViewColumn();
                thk2Column.Name = "qualitative_result";
                thk2Column.DataPropertyName = "qualitative_result";
                thk2Column.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(5, thk2Column);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {

                    data_THK1.Rows[i].Cells[5].Value = " ";

                }

                data_THK1.Columns[4].HeaderText = "quantitative_result";

                DataGridViewColumn QCColumn = new DataGridViewColumn();
                QCColumn.Name = "evaluation_template_code";
                QCColumn.DataPropertyName = "evaluation_template_code";
                QCColumn.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(3, QCColumn);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {
                    data_THK1.Rows[i].Cells[3].Value = "QC-53";
                }

                if (Int32.Parse(txt_sttmon.Text) == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        data_THK1.Columns.RemoveAt(5);

                    }
                    for (int i = 0; i < 1 + (9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text))); i++)
                    {
                        data_THK1.Columns.RemoveAt(6);
                    }
                }
                else
                {
                    for (int i = 0; i <= (9 * (Int32.Parse(txt_sttmon.Text) - 1)) + 2; i++)
                    {
                        data_THK1.Columns.RemoveAt(5);
                    }
                    for (int i = 0; i <= 9 * (Int32.Parse(txt_somon.Text) - Int32.Parse(txt_sttmon.Text)); i++)
                    {
                        data_THK1.Columns.RemoveAt(6);

                    }
                }
                DataGridViewColumn statusColumn2 = new DataGridViewColumn();
                statusColumn2.Name = "study_evaluation_result_status";
                statusColumn2.DataPropertyName = "study_evaluation_result_status";
                statusColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(data_THK1.Columns.Count, statusColumn2);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {

                    data_THK1.Rows[i].Cells[data_THK1.Columns.Count - 1].Value = "STUDY_EVALUATION_RESULT_STATUS_DRAFT";

                }
                DataGridViewColumn evaColumn2 = new DataGridViewColumn();
                evaColumn2.Name = "qualitative_result";
                evaColumn2.DataPropertyName = "qualitative_result";
                evaColumn2.CellTemplate = new DataGridViewTextBoxCell();

                data_THK1.Columns.Insert(data_THK1.Columns.Count - 1, evaColumn2);
                for (int i = 0; i < data_THK1.Rows.Count - 1; i++)
                {

                    data_THK1.Rows[i].Cells[data_THK1.Columns.Count - 2].Value = "";

                }
                data_THK1.Columns[5].HeaderText = "quantitative_result";

            }
        }

        private void btn_refresh_thk1_Click(object sender, EventArgs e)
        {
            data_THK1.Rows.Clear();
            data_THK1.Columns.Clear();
            txt_somon.Clear();
            txt_mamon.Clear();
            txt_sttmon.Clear();
        }

        private void btn_export_qt_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            data_QT.Rows.Insert(0, row);

            data_QT.Rows[0].Cells[0].Value = "id";
            data_QT.Rows[0].Cells[1].Value = "student_code";
            data_QT.Rows[0].Cells[2].Value = "study_module_code";
            data_QT.Rows[0].Cells[3].Value = "evaluation_template_code";
            data_QT.Rows[0].Cells[4].Value = "evaluation_point_code";
            data_QT.Rows[0].Cells[5].Value = "quantitative_result";
            data_QT.Rows[0].Cells[6].Value = "qualitative_result";
            data_QT.Rows[0].Cells[7].Value = "study_evaluation_result_status";


            data_QT.SelectAll();
            DataObject copydata = data_QT.GetClipboardContent();
            if (copydata != null)
            {
                Clipboard.SetDataObject(copydata);
            }
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object misseddata = System.Reflection.Missing.Value;
            xlWook = xlapp.Workbooks.Add(misseddata);
            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[1, 1];
            xlr.Select();

            xlSheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void btn_export_thk1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            data_THK1.Rows.Insert(0, row);

            data_THK1.Rows[0].Cells[0].Value = "id";
            data_THK1.Rows[0].Cells[1].Value = "student_code";
            data_THK1.Rows[0].Cells[2].Value = "study_module_code";
            data_THK1.Rows[0].Cells[3].Value = "evaluation_template_code";
            data_THK1.Rows[0].Cells[4].Value = "evaluation_point_code";
            data_THK1.Rows[0].Cells[5].Value = "quantitative_result";
            data_THK1.Rows[0].Cells[6].Value = "qualitative_result";
            data_THK1.Rows[0].Cells[7].Value = "study_evaluation_result_status";


            data_THK1.SelectAll();
            DataObject copydata = data_THK1.GetClipboardContent();
            if (copydata != null)
            {
                Clipboard.SetDataObject(copydata);
            }
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object misseddata = System.Reflection.Missing.Value;
            xlWook = xlapp.Workbooks.Add(misseddata);
            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[1, 1];
            xlr.Select();

            xlSheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void btn_SV_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                data_SV.Columns.Add(new DataGridViewTextBoxColumn());
            }

            foreach (DataRow dr in dt.Rows)
            {
                data_SV.Rows.Add(dr.ItemArray);
            }
            for (int i = 0; i < 4; i++)
            {
                data_SV.Rows.RemoveAt(0);
            }
            data_SV.Columns.RemoveAt(0);// xóa cột id gốc
            data_SV.Columns.RemoveAt(2);// xóa cột họ tên
            data_SV.Columns.RemoveAt(0);// xóa cột mã lớp
            DataGridViewColumn idColumn = new DataGridViewColumn();
            idColumn.Name = "id";
            idColumn.DataPropertyName = "id";
            idColumn.CellTemplate = new DataGridViewTextBoxCell();
            data_SV.Columns.Insert(0, idColumn);

            DataGridViewColumn jobColumn = new DataGridViewColumn();
            jobColumn.Name = "job_category_code";
            jobColumn.DataPropertyName = "job_category_code";
            jobColumn.CellTemplate = new DataGridViewTextBoxCell();
           
            data_SV.Columns.Add(jobColumn);
            for (int i = 0; i < data_SV.Rows.Count - 1; i++)
            {
                data_SV.Rows[i].Cells[2].Value = "SV";
            }

            DataGridViewColumn posColumn = new DataGridViewColumn();
            posColumn.Name = "job_position_code";
            posColumn.DataPropertyName = "job_position_code";
            posColumn.CellTemplate = new DataGridViewTextBoxCell();

            data_SV.Columns.Add(posColumn);

            DataGridViewColumn statusColumn = new DataGridViewColumn();
            statusColumn.Name = "class_student_status";
            statusColumn.DataPropertyName = "class_student_status";
            statusColumn.CellTemplate = new DataGridViewTextBoxCell();

            data_SV.Columns.Add(statusColumn);
            for (int i = 0; i < data_SV.Rows.Count - 1; i++)
            {
                data_SV.Rows[i].Cells[4].Value = "STUDENT_CLASS_STATUS_DRAFT";
            }

            data_SV.Columns[1].HeaderText = "student_code";


        }

        private void btn_export_sv_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            data_SV.Rows.Insert(0, row);

            data_SV.Rows[0].Cells[0].Value = "id";
            data_SV.Rows[0].Cells[1].Value = "student_code";
            data_SV.Rows[0].Cells[2].Value = "job_category_code";
            data_SV.Rows[0].Cells[3].Value = "job_position_code";
            data_SV.Rows[0].Cells[4].Value = "class_student_status";
            


            data_SV.SelectAll();
            DataObject copydata = data_SV.GetClipboardContent();
            if (copydata != null)
            {
                Clipboard.SetDataObject(copydata);
            }
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object misseddata = System.Reflection.Missing.Value;
            xlWook = xlapp.Workbooks.Add(misseddata);
            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[1, 1];
            xlr.Select();

            xlSheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
