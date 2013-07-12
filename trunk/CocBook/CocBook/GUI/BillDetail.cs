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
        IEDetail ieDetail = new IEDetail();
        bool isADD = false;
        BookManage chooseBook = new BookManage(false);
        public BillDetail()
        {
            InitializeComponent();
        }

        public void OrderLoadData()
        {
            try
            {
                lbDetail.Text = "Phiếu " + importExport.ImEx + "\nKiểu " + importExport.Type + "\nSố " + importExport.CheckNo;
                ieDetail.CheckNo = importExport.CheckNo;
                customer = customerDAL.GetCustomerbyID(importExport.CustomerID);
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
                //EditRow editrow = new EditRow();
                //editrow.ieDetail.CheckNo = importExport.CheckNo;
                //editrow.Add = true;
                //editrow.importRowEvent += new ImportRow(OrderLoadData);
                //editrow.ShowDialog();

                txtBookName.ReadOnly = false;
                btnChooseBook.Enabled = true;
                groupBoxDetail.Enabled = true;
                isADD = true;
                ClearAll();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }

        }
        private void ClearAll()
        {
            txtBookName.Text = "";
            txtDiscount.Text = "";
            txtQuantity.Text = "";
        }


        void editrow_importRowEvent()
        {
            OrderLoadData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                isADD = false;
                groupBoxDetail.Enabled = true;
                ieDetail.ISBNBook = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                book.ISBNBook = ieDetail.ISBNBook;
                book.BookName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                book.Unit = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                ieDetail.Quantity = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                book.Price = (int)dataGridView1.SelectedRows[0].Cells[4].Value;
                ieDetail.Discount = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
                ieDetail.Value = (int)dataGridView1.SelectedRows[0].Cells[6].Value;

                btnChooseBook.Enabled = false;
                txtBookName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtQuantity.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtDiscount.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

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
                if (MessageBox.Show("Bạn có muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Restore book's quantity in Store when Delete Row
                    BookStore bookStore = new BookStore();
                    BookStoreDAL bookStoreDAL = new BookStoreDAL();
                    string ISBN = ieDetail.ISBNBook;
                    int Quantity = ieDetail.Quantity;
                    bookStore = bookStoreDAL.GetBookStorebyISBNBook(ISBN);
                    string error = "";
                    bool rs = true;
                    if (String.Compare(importExport.ImEx, "Xuất", true) == 0)
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
                            error = error + "Số lượng sách nhỏ hơn số sách cần xóa từ phiếu Nhập này";
                        }
                    }

                    rs = bookStoreDAL.UpdateBookStore(bookStore);
                    if (!rs)
                    {
                        error = error + "Không thể cập nhật sách.";
                        MessageBox.Show(error);
                    }
                    else
                    {
                        // Delete Book in IEDetail
                        ieDAL.DeleteOrderByCheckNoAndISBN(importExport.CheckNo, ieDetail.ISBNBook);
                    }


                }
                ClearAll();
                OrderLoadData();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }


        private bool UpdateStore(bool IsChangeQuantity)
        {

            try
            {
                bool rs = true;

                string error = "";

                BookStore bookStore = new BookStore();
                BookStoreDAL bookStoreDAL = new BookStoreDAL();
                string ISBN = ieDetail.ISBNBook;
                int Quantity = ieDetail.Quantity;
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
                            error = "Không thể thêm sách vào kho.";
                        }
                    }
                    else
                    {
                        rs = false;
                        error = "Không thể xuất sách không có trong kho";
                    }
                }
                else
                {
                    if (String.Compare(importExport.ImEx, "Nhập", true) == 0)
                    {
                        if (IsChangeQuantity)
                        {
                            bookStore.Quantity += Quantity;
                        }
                        else
                        {
                            bookStore.Quantity = Quantity;
                        }
                    }
                    else
                    {
                        if (bookStore.Quantity >= Quantity)
                        {
                            if (IsChangeQuantity)
                            {
                                bookStore.Quantity -= Quantity;
                            }
                            else
                            {
                                bookStore.Quantity = Quantity;
                            }
                        }
                        else
                        {
                            rs = false;
                            error = "Số lượng sách lớn hơn số lượng có trong kho";
                        }
                    }
                    if (rs)
                    {
                        rs = bookStoreDAL.UpdateBookStore(bookStore);
                    }
                    if (!rs)
                    {
                        error = "Không thể cập nhật sách.";
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
            Excel.Application xlApp;

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.Visible = false;

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            try
            {
                saveFileDialog1.ShowDialog();
                bool check = saveFileDialog1.CheckPathExists;


                if (check)
                {

                    string filepath = saveFileDialog1.FileName;



                    string title = "PHIẾU " + importExport.ImEx.ToUpper() + " KHO";


                    //set thuoc tinh cho tieu de
                    xlWorkSheet.get_Range("C3", Convert.ToChar(4 + 65) + "3").Merge(false);
                    Excel.Range caption = xlWorkSheet.get_Range("C3", Convert.ToChar(4 + 65) + "3");
                    caption.Select();
                    caption.FormulaR1C1 = title;
                    //căn lề cho tiêu đề
                    caption.HorizontalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Bold = true;
                    caption.VerticalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Size = 18;
                    //màu nền cho tiêu đề
                    //caption.Interior.ColorIndex = 21;
                    //caption.RowHeight = 30;

                    Excel.Range header = xlWorkSheet.get_Range("A14", Convert.ToChar(dataGridView1.ColumnCount + 64) + "14");
                    header.Select();
                    header.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                    header.HorizontalAlignment = Excel.Constants.xlCenter;
                    header.Font.Bold = true;
                    header.Font.Italic = true;
                    header.Font.Size = 10;

                    string dates = "Ngày: " + (importExport.Date.ToString("dd/MM/yyyy"));

                    xlWorkSheet.get_Range("C4", Convert.ToChar(4 + 65) + "4").Merge(false);
                    Excel.Range date = xlWorkSheet.get_Range("C4", Convert.ToChar(4 + 65) + "4");
                    date.Select();
                    date.FormulaR1C1 = dates;

                    date.HorizontalAlignment = Excel.Constants.xlCenter;
                    date.Font.Bold = true;
                    date.VerticalAlignment = Excel.Constants.xlCenter;
                    date.Font.Size = 11;

                    string websites = "    www.facebook.com/cocbook";


                    xlWorkSheet.get_Range("A5", Convert.ToChar(2 + 65) + "5").Merge(false);
                    Excel.Range website = xlWorkSheet.get_Range("A5", Convert.ToChar(2 + 65) + "5");
                    website.Select();
                    website.FormulaR1C1 = websites;

                    website.Font.Bold = true;
                    website.Font.Size = 11;

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

                    int rowEnd = rowStart + dataGridView1.Rows.Count - 1 + 6;
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

                    xlWorkSheet.Cells[7, 3] = ": " + customer.CustomerName;
                    xlWorkSheet.Cells[8, 3] = ": " + customer.Address;
                    xlWorkSheet.Cells[9, 3] = ": " + customer.Phone;
                    xlWorkSheet.Cells[10, 3] = ": " + customer.TaxNo;
                    xlWorkSheet.Cells[11, 3] = ": " + "Trụ sở 182/49 Lê Văn Sỹ";
                    xlWorkSheet.Cells[12, 3] = ": " + importExport.Type;

                    string rline1 = "Số phiếu";
                    string rline2 = "Số chứng từ";
                    string rline3 = "Ký hiệu HĐ";
                    string rline4 = "Phương thức xuất";

                    xlWorkSheet.Cells[1, 6] = rline1;
                    xlWorkSheet.Cells[2, 6] = rline2;
                    xlWorkSheet.Cells[3, 6] = rline3;
                    xlWorkSheet.Cells[4, 6] = rline4;


                    xlWorkSheet.Cells[1, 9] = ": " + importExport.CheckNo;
                    xlWorkSheet.Cells[2, 9] = ": ";
                    xlWorkSheet.Cells[3, 9] = ": ";
                    xlWorkSheet.Cells[4, 9] = ": ";


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



                    xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


                    MessageBox.Show("Đã xuất file. Bạn có thể tìm file ở " + filepath);
                }

            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
            finally
            {
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();



                releaseObject(xlWorkSheet);

                releaseObject(xlWorkBook);

                releaseObject(xlApp);
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

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                SaveToDB();
            }

        }
        private bool ValidateData()
        {
            if (txtBookName.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sách !");
                return false;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng !");
                return false;
            } 
            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Vui lòng nhập chiết khấu !");
                return false;
            }
            return true;
        }
        private void SaveToDB()
        {
            ieDetail.Quantity = int.Parse(txtQuantity.Text);
            ieDetail.Discount = int.Parse(txtDiscount.Text);
            ieDetail.Value = (book.Price * ieDetail.Quantity * (100 - ieDetail.Discount)) / 100;

            if (isADD)
            {
                if (ieDAL.GetIEDetailByCheckNoAndISBN(ieDetail.CheckNo, ieDetail.ISBNBook) == null && UpdateStore(true) && ieDAL.CreateIEDetail(ieDetail))
                {
                    MessageBox.Show("Đã lưu !");
                    groupBoxDetail.Enabled = false;
                    OrderLoadData();
                }
                else
                {
                    MessageBox.Show("Đã có sách trong phiếu. Vui lòng chỉnh sửa từ danh sách !");
                }
            }
            else if (UpdateStore(false) && ieDAL.UpdateIEDetail(ieDetail))
            {
                MessageBox.Show("Đã lưu !");
                groupBoxDetail.Enabled = false;
                OrderLoadData();
            }
            else
            {
                MessageBox.Show("Không thể lưu !");
            }


        }

        private void btnChooseBook_Click(object sender, EventArgs e)
        {
            try
            {
                chooseBook.chooseEvent += new ChooseBook(chooseBook_importEvent);
                chooseBook.ShowDialog();
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }
        private void chooseBook_importEvent()
        {
            try
            {
                book = chooseBook.book;
                ieDetail.ISBNBook = book.ISBNBook;
                txtBookName.Text = book.BookName;
            }
            catch (Exception ex)
            {

                logger.MyLogFile(DateTime.Now.ToString(), "' Error '" + ex.Message + "'");
            }
        }

        private void btnViewStore_Click(object sender, EventArgs e)
        {
            ViewStore viewStore = new ViewStore();
            viewStore.Show();
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
