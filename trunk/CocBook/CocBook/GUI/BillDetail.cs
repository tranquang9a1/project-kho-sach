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
using DataAccessLayer.DAL;
using Excel = Microsoft.Office.Interop.Excel; 

namespace CocBook
{
    public partial class BillDetail : Form
    {
        LogFile logger = new LogFile();
        public ImportExport importExport = new ImportExport();
        CustomerDAL customerDAL = new CustomerDAL();
        Customer customer = new Customer();
        Book book = new Book();
        BookDAL bookDAL = new BookDAL();
        IEDetailDAL ieDAL = new IEDetailDAL();
        IEDetail iedetail = new IEDetail();
        public BillDetail()
        {
            InitializeComponent();
            iedetail.CheckNo = importExport.CheckNo;
        }
        public void OrderLoadData()
        {
            try
            {
                iedetail.CheckNo = importExport.CheckNo;
                List<GridViewRow> list = new List<GridViewRow>();
                List<IEDetail> iedetail1 = new List<IEDetail>();
                iedetail1 = ieDAL.GetIEDetailByCheckNo(importExport.CheckNo);
                foreach (var item in iedetail1)
                {
                    GridViewRow gridViewRow = new GridViewRow();
                    gridViewRow.ISBNBook = item.ISBNBook;
                    Book book1 = new Book();
                    book1 = bookDAL.GetBookbyISBN(item.ISBNBook);
                    gridViewRow.BookName = book1.BookName;
                    gridViewRow.Unit = book1.Unit;
                    gridViewRow.Quantity = item.Quantity;
                    gridViewRow.Price = book1.Price;
                    gridViewRow.Discount = item.Discount;
                    gridViewRow.Value = item.Value;
                    list.Add(gridViewRow);
                }
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EditRow editrow = new EditRow();
                editrow.ieDetail.CheckNo = importExport.CheckNo;
                editrow.Add = true;
                editrow.importRowEvent += new ImportRow(editrow_importRowEvent);
                editrow.ShowDialog();
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
                EditRow editrow = new EditRow();
                editrow.ieDetail = iedetail;
                editrow.book = book;
                editrow.Add = false;
                editrow.LoadData();
                editrow.importRowEvent += new ImportRow(editrow_importRowEvent);
                editrow.ShowDialog();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        void editrow_importRowEvent()
        {
            OrderLoadData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                iedetail.ISBNBook = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                book.ISBNBook = iedetail.ISBNBook;
                book.BookName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                book.Unit = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                iedetail.Quantity = (int)dataGridView1.SelectedRows[0].Cells[4].Value;
                book.Price = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
                iedetail.Discount = (int)dataGridView1.SelectedRows[0].Cells[6].Value;
                iedetail.Value = (int)dataGridView1.SelectedRows[0].Cells[7].Value;

            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool del = ieDAL.DeleteOrderByCheckNoAndISBN(importExport.CheckNo, iedetail.ISBNBook);
                if (del)
                    {
                        MessageBox.Show("Đã xóa!");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, vui lòng kiểm tra lại.");
                    }
                OrderLoadData();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        public void AutoNumberRowsForGridView(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView != null)
                {
                    for (int count = 0; (count <= (dataGridView.Rows.Count - 2)); count++)
                    {
                        dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                    }
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = UpdateStore();
                if (rs)
                    {
                        MessageBox.Show("Cập nhật thành công !");
                    }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        private bool UpdateStore()
        {

            try
            {
                bool rs = true;
                int rows;
                string error = "";
                for (rows = 0; rows < dataGridView1.Rows.Count; rows++)
                {
                    BookStore bookStore = new BookStore();
                    BookStoreDAL bookStoreDAL = new BookStoreDAL();
                    string ISBN = dataGridView1.Rows[rows].Cells[1].Value.ToString();
                    int Quantity = (int)dataGridView1.Rows[rows].Cells[4].Value;

                    bookStore = bookStoreDAL.GetBookStorebyISBNBook(ISBN);
                    if (bookStore == null)
                    {
                        if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                        {
                            BookStore bookStore1 = new BookStore();
                            bookStore1.ISBN = ISBN;
                            bookStore1.Quantity = Quantity;
                            rs = bookStoreDAL.CreateBookStore(bookStore1);
                            if (!rs)
                            {
                                error = "Không thể thêm sách tại dòng " + rows;
                                break;
                            }
                        }
                        else
                        {
                            rs = false;
                            error = "Không thể xuất sách không có trong kho";
                            break;
                        }
                    }
                    else
                    {
                        if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                        {
                            bookStore.Quantity += Quantity;
                        }
                        else
                        {
                            if (bookStore.Quantity >= Quantity)
                            {
                                bookStore.Quantity -= Quantity;
                            }
                            else
                            {
                                rs = false;
                                error = "Số lượng sách tại dòng " + rows + " lớn hơn số lượng có trong kho";
                                break;
                            }
                        }

                        rs = bookStoreDAL.UpdateBookStore(bookStore);
                        if (!rs)
                        {
                            error = "Không thể cập nhật sách tại dòng " + rows;
                            break;
                        }
                    }

                }
                if (!rs)
                {
                    MessageBox.Show(error + ". Vui lòng xem lại !");
                }
                return rs;
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
                return false;
            }       
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                bool rs = UpdateStore();
                if (rs)
                {

                    Excel.Application xlApp;

                    Excel.Workbook xlWorkBook;

                    Excel.Worksheet xlWorkSheet;

                    object misValue = System.Reflection.Missing.Value;



                    xlApp = new Excel.Application();
                    xlApp.Visible = false;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    string title = label1.Text;




                    //set thuoc tinh cho tieu de
                    xlWorkSheet.get_Range("A1", Convert.ToChar(dataGridView1.ColumnCount + 65) + "1").Merge(false);
                    Excel.Range caption = xlWorkSheet.get_Range("A1", Convert.ToChar(dataGridView1.ColumnCount + 65) + "1");
                    caption.Select();
                    caption.FormulaR1C1 = title;
                    //căn lề cho tiêu đề
                    caption.HorizontalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Bold = true;
                    caption.VerticalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Size = 25;
                    //màu nền cho tiêu đề
                    //caption.Interior.ColorIndex = 21;
                    //caption.RowHeight = 30;

                    Excel.Range header = xlWorkSheet.get_Range("A14", Convert.ToChar(dataGridView1.ColumnCount + 64) + "14");
                    header.Select();
                    header.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                    header.HorizontalAlignment = Excel.Constants.xlCenter;
                    header.Font.Bold = true;
                    header.Font.Italic = true;
                    header.Font.Size = 12;

                    int i = 0;

                    int j = 0;

                    for (int k = 0; k < dataGridView1.ColumnCount; k++)
                    {
                        string s = this.dataGridView1.Columns[k].HeaderText;
                        xlWorkSheet.Cells[14, k + 1] = s;
                    }


                    //Thiết lập vùng điền dữ liệu
                    int rowStart = 15;
                    int columnStart = 1;

                    int rowEnd = rowStart + dataGridView1.Rows.Count - 1;
                    int columnEnd = dataGridView1.Columns.Count;

                    // Ô bắt đầu điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowStart, columnStart];
                    // Ô kết thúc điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowEnd, columnEnd];
                    // Lấy về vùng điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range(c1, c2);

                    // Kẻ viền
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                    // Căn lề các ô điền dữ liệu
                    Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowEnd, columnStart];
                    Microsoft.Office.Interop.Excel.Range c4 = xlWorkSheet.get_Range(c1, c2);
                    xlWorkSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    string line1 = "Khách hàng";
                    string line2 = "Địa chỉ";
                    string line3 = "Điện thoại";
                    string line4 = "MST";
                    string line5 = "Xuất từ kho";
                    string line6 = "Hình thức thanh toán";


                    xlWorkSheet.Cells[7, 2] = line1;
                    xlWorkSheet.Cells[8, 2] = line2;
                    xlWorkSheet.Cells[9, 2] = line3;
                    xlWorkSheet.Cells[10, 2] = line4;
                    xlWorkSheet.Cells[11, 2] = line5;
                    xlWorkSheet.Cells[12, 2] = line6;

                    xlWorkSheet.Cells[7, 3] = ":" + customer.CustomerName;
                    xlWorkSheet.Cells[8, 3] = ":" + customer.Address;
                    xlWorkSheet.Cells[9, 3] = ":" + customer.Phone;
                    xlWorkSheet.Cells[10, 3] = ":" + customer.TaxNo;
                    xlWorkSheet.Cells[11, 3] = ":";
                    xlWorkSheet.Cells[12, 3] = ":" + customer.CustomerName;


                    for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                    {

                        for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                        {

                            DataGridViewCell cell = dataGridView1[j, i];

                            xlWorkSheet.Cells[i + 15, j + 1] = cell.Value;

                        }


                    }

                    for (i = 0; i < dataGridView1.RowCount + 1; i++)
                    {
                        for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                        {
                            ((Excel.Range)xlWorkSheet.Cells[14, j + 1]).EntireColumn.AutoFit();
                        }
                    }

                    xlWorkBook.SaveAs("D:\\datatest.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);

                    xlApp.Quit();



                    releaseObject(xlWorkSheet);

                    releaseObject(xlWorkBook);

                    releaseObject(xlApp);



                    MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
                }
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }

            
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
    public class GridViewRow
    {
        public string ISBNBook { get; set; }
        public string BookName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Value { get; set; }
    }


}
