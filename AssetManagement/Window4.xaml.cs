using AssetManagement.Controllers;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssetManagement
{

    LoanRequestsController loanrequestscontroller = new LoanRequestsController();
    AssetsController assetcontroller = new AssetsController();
    ReturnsController returncontroller = new ReturnsController();
    LoanRequestDetailsController loanrequestdetailscontroller = new LoanRequestDetailsController();
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        public void LoadCombo()
        {
            cmbuserBox.ItemsSource = usercontroller.Get();
            comboloanrequestBox.ItemsSource = loanrequestscontroller.Get();
        }
        public void Cleaning()
        {
            //loan request
            idtxtloanBox.Text = "";
            dtpickerloan.Text = "";
            statustxtloanBox.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }
        public void LoadGrid()
        {
            loandtGrid.ItemsSource = loanrequestscontroller.Get();
        }
        
        //==================Loan Request========================================
        private void savebtnloan_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpickerloan.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new LoanRequestVM(dtpickerloan.SelectedDate, "Pending", Convert.ToInt32(cmbuserBox.SelectedValue));
                var result = loanrequestscontroller.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }
        private void updatebtnloan_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpickerloan.Text) || string.IsNullOrWhiteSpace(cmbuserBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new LoanRequestVM(Convert.ToDateTime(dtpickerloan.Text), "Submitted", Convert.ToInt32(cmbuserBox.SelectedValue));
                    var result = loanrequestscontroller.Update(Convert.ToInt32(idtxtloanBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update Successfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Update Canceled");
                }
                Cleaning();
            }
        }
        private void deletebtnloan_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtloanBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var result = loanrequestscontroller.Delete(Convert.ToInt32(idtxtloanBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Successfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }
        private void loandtGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = loandtGrid.SelectedItem;
            try
            {
                idtxtloanBox.Text = (loandtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                dtpickerloan.Text = (loandtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                //statustxtloanBox.Text = (loandtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                cmbuserBox.Text = (loandtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        //==================Loan Request Detail========================================
        private void savebtnloandtl_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(quantitytxtloandtlBox.Text) || string.IsNullOrWhiteSpace(assetnametxtloandtlBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new LoanRequestDetailVM(Convert.ToInt32(quantitytxtloandtlBox.Text), assetnametxtloandtlBox.Text, Convert.ToInt32(comboloanrequestBox.SelectedValue), Convert.ToInt32(comboassetBox.SelectedValue));
                var result = loanrequestdetailscontroller.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }
        private void updatebtnloandtl_Click(object sender, RoutedEventArgs e)
        {

        }
        private void deletebtnloandtl_Click(object sender, RoutedEventArgs e)
        {

        }
        private void loandtldtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = loandtldtGrid.SelectedItem;
            try
            {
                idtxtloandtlBox.Text = (loandtldtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                quantitytxtloandtlBox.Text = (loandtldtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                assetnametxtloandtlBox.Text = (loandtldtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                comboloanrequestBox.Text = (loandtldtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        
        //==================Return========================================
        private void savebtnreturn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(totalfinetxtbox.Text) || string.IsNullOrWhiteSpace(dtreturnDate.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new ReturnVM(Convert.ToDateTime(dtreturnDate.Text), Convert.ToInt32(totalfinetxtbox.Text));
                var result = returncontroller.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }

        private void updatebtnreturn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(totalfinetxtbox.Text) || string.IsNullOrWhiteSpace(dtreturnDate.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new ReturnVM(Convert.ToDateTime(dtreturnDate.Text), Convert.ToInt32(totalfinetxtbox.Text));
                    var result = returncontroller.Update(Convert.ToInt32(idtxtboxreturn.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update Successfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Update Canceled");
                }
                Cleaning();
            }
        }

        private void deletebtnreturn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void returndtldtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = returndtldtGrid.SelectedItem;
            try
            {
                idtxtboxreturn.Text = (returndtldtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                dtreturnDate.Text = (returndtldtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                totalfinetxtbox.Text = (returndtldtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
