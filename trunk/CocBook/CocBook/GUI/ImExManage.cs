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
using CocBook.DTO;
using System.Globalization;

namespace CocBook
{

    public partial class ImExManage : Form
    {
        LogFile logger = new LogFile();
        ImportExport importExport = new ImportExport();
        bool isAdd = false;
        CustomerManage customerManage = new CustomerManage();
        public ImExManage()
        {
            InitializeComponent();
            LoadAllData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                InfoDetail infoDetail = new InfoDetail();
                infoDetail.add = true;

                isAdd = true;
                txtCheckNo.Text = "";
                txtCheckNo.ReadOnly = false;
                txtDay.Text = "";
                radioButtonExport.Checked = false;
                radioButtonImport.Checked = false;
                cbType.Items.Clear();
                txtCustomerName.Text = "";
                infoDetail.Show();
                //this.Close();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        private void LoadAllData()
        {
            try
            {
                List<ImportExport> list1 = new List<ImportExport>();
                List<OpenImportExport> list2 = new List<OpenImportExport>();
                ImportExportDAL importexportDAL = new ImportExportDAL();
                list1 = importexportDAL.GetAllIE();
                list2 = importexportDAL.GetAllOpenIE(list1);
                dataGridView1.DataSource = list2;
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                importExport.CheckNo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                importExport.Date = (DateTime)dataGridView1.SelectedRows[0].Cells[1].Value;
                importExport.ImEx = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                importExport.Type = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                CustomerDAL cusDAL = new CustomerDAL();
                string CusName = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                importExport.CustomerID = cusDAL.GetCustomerbyName(CusName).CustomerID;

                txtCheckNo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtCheckNo.ReadOnly = true;
                txtDay.Text = String.Format("{0:dd/MM/yyyy}", dataGridView1.SelectedRows[0].Cells[1].Value);
                string ImEx = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                if (String.Compare(ImEx, "Nhập", true) == 0)
                {
                    radioButtonImport.Checked = true;
                }
                else
                {
                    radioButtonExport.Checked = true;
                }
                string type = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                if (String.Compare(type, "Ký gửi", true) == 0)
                {
                    cbType.SelectedIndex = 0;
                }
                if (String.Compare(type, "Bán lẻ", true) == 0)
                {
                    cbType.SelectedIndex = 1;
                }
                if (String.Compare(type, "Nhập trả", true) == 0 && String.Compare(importExport.ImEx, "Nhập", true) == 0)
                {
                    cbType.SelectedIndex = 2;
                }
                if (String.Compare(type, "Lưu kho", true) == 0 && String.Compare(importExport.ImEx, "Xuất", true) == 0)
                {
                    cbType.SelectedIndex = 2;
                }
                if (String.Compare(type, "Trả hàng", true) == 0 && String.Compare(importExport.ImEx, "Xuất", true) == 0)
                {
                    cbType.SelectedIndex = 3;
                }
                txtCustomerName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbExport.Checked)
                {
                    ImportExportDAL IEDAL = new ImportExportDAL();

                    if (IEDAL.GetExport() != null)
                    {
                        List<OpenImportExport> list = new List<OpenImportExport>();
                        list = IEDAL.GetExport();
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không có kết quả được tìm thấy");
                        LoadAllData();
                    }


                }
                else if (rbImport.Checked)
                {
                    ImportExportDAL IEDAL = new ImportExportDAL();

                    if (IEDAL.GetImport() != null)
                    {
                        List<OpenImportExport> list = new List<OpenImportExport>();
                        list = IEDAL.GetImport();
                        dataGridView1.DataSource = list;
                        dataGridView1.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Không có kết quả được tìm thấy");
                        LoadAllData();
                    }
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void radioButtonImportExport_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonImport.Checked == true)
                {
                    cbType.Items.Clear();
                    cbType.Items.Add("Ký gửi");
                    cbType.Items.Add("Bán lẻ");
                    cbType.Items.Add("Nhập trả");
                }
                else if (radioButtonExport.Checked == true)
                {
                    cbType.Items.Clear();
                    cbType.Items.Add("Ký gửi");
                    cbType.Items.Add("Bán lẻ");
                    cbType.Items.Add("Lưu kho");
                    cbType.Items.Add("Trả hàng");
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToDB();
        }
        private void SaveToDB()
        {
            ImportExportDAL importExportDAL = new ImportExportDAL();
            if (txtCheckNo.Text != null)
            {
                importExport.CheckNo = int.Parse(txtCheckNo.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa điền số phiếu! Vui lòng nhập lại! ");
                txtCheckNo.Focus();
            }
            if (txtDay.Text != null)
            {
                importExport.Date = DateTime.ParseExact(txtDay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thời gian dạng 25/12/1993 !");
                txtDay.Focus();
            }

            if (radioButtonImport.Checked)
            {
                importExport.ImEx = "Nhập";
            }
            else if (radioButtonExport.Checked)
            {
                importExport.ImEx = "Xuất";
            }
            importExport.Type = cbType.SelectedItem.ToString();
            if (txtCustomerName != null)
            {
                CustomerDAL customerDAL = new CustomerDAL();
                importExport.CustomerID = customerDAL.GetCustomerbyName(txtCustomerName.Text).CustomerID;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng. Vui lòng chọn!");
                txtCustomerName.Focus();
            }
            if (isAdd)
            {
                importExportDAL.CreateIE(importExport);
            }
            else
            {
                importExportDAL.UpdateIE(importExport);
            }
        }

        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                
                customerManage.loadCustomerNameEvent += new LoadCustomerName(loadCustomerName);
                customerManage.ShowDialog();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        void loadCustomerName()
        {
            try
            {
                txtCustomerName.Text = customerManage.customer.CustomerName.ToString();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnCheckDetail_Click(object sender, EventArgs e)
        {
            SaveToDB();
            BillDetail billDetail = new BillDetail();
            billDetail.importExport = this.importExport;
            billDetail.OrderLoadData();
            billDetail.Show();
            this.Close();
        }
    }
}