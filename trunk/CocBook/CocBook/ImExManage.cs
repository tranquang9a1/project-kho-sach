using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.cs.DTO;
using DataAccessLayer.cs.DAL;

namespace CocBook
{
    public partial class ImExManage : Form
    {
        ImportExport importExport = new ImportExport();
        public ImExManage()
        {
            InitializeComponent();
            LoadAllData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InfoDetail infoDetail = new InfoDetail();
            infoDetail.add = true;
            infoDetail.Show();
            this.Close();
        }
        private void LoadAllData()
        {
            List<ImportExport> list1 = new List<ImportExport>();
            List<LoadResult> list2 = new List<LoadResult>();
            ImportExportDAL importexportDAL = new ImportExportDAL();
            list1 = importexportDAL.GetAllIE();
            foreach (var ie in list1)
            {
                LoadResult loadResult = new LoadResult();
                CustomerDAL customerDAL = new CustomerDAL();
                loadResult.CheckNo = ie.CheckNo;
                loadResult.Date = ie.Date;
                loadResult.Type = ie.Type;
                loadResult.ImEx = ie.ImEx;
                loadResult.CustomerName = customerDAL.GetCustomerbyID(ie.CustomerID).CustomerName;
                list2.Add(loadResult);
            }
            dataGridView1.DataSource = list2;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (importExport == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu muốn chỉnh sửa !");
            }
            else
            {
                InfoDetail infoDetail = new InfoDetail();
                infoDetail.add = false;
                infoDetail.importExport = importExport;
                CustomerDAL cusDAL = new CustomerDAL();
                infoDetail.customer = cusDAL.GetCustomerbyID(importExport.CustomerID);
                infoDetail.LoadData();
                infoDetail.Show();
                this.Close();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            importExport.CheckNo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            importExport.Date = (DateTime)dataGridView1.SelectedRows[0].Cells[1].Value;
            importExport.Type = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            importExport.ImEx = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            CustomerDAL cusDAL = new CustomerDAL();
            string CusName = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            importExport.CustomerID = cusDAL.GetCustomerbyName(CusName).CustomerID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbExport.Checked)
            {
                ImportExportDAL IEDAL = new ImportExportDAL();

                if (IEDAL.GetExport() != null)
                {
                    importExport = IEDAL.GetExport();
                    List<ImportExport> list = new List<ImportExport>();
                    list.Add(importExport);
                    dataGridView1.DataSource = list;
                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("Không có kết quả được tìm thấy");
                }
            }
            else if (rbImport.Checked)
            {
                 ImportExportDAL IEDAL = new ImportExportDAL();

                if (IEDAL.GetExport() != null)
                {
                    importExport = IEDAL.GetExport();
                    List<ImportExport> list = new List<ImportExport>();
                    list.Add(importExport);
                    dataGridView1.DataSource = list;
                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("Không có kết quả được tìm thấy");
                }
            }
            else if (rbExport.Checked == false && rbImport.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm!");
            }
                
        }

    }
    public class LoadResult
    {
        public int CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string ImEx { get; set; }
        public string CustomerName { get; set; }
    }
}
