using AssetManagement.Controllers;
using AssetManagement.Repositories;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Text.RegularExpressions;

namespace AssetManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initialize
        CategoriesController categoriescontroller = new CategoriesController();
        RolesController rolescontroller = new RolesController();
        SuppliersController suppliercontroller = new SuppliersController();
        UserController usercontroller = new UserController();
        AssetsController assetcontroller = new AssetsController();
        EmployeesController employeescontroller = new EmployeesController();
        ReturnsController returnscontroller = new ReturnsController();

        public string ConfigurationManagerConfigurationManager { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadCombo()
        {
            rolecmbBox.ItemsSource = rolescontroller.Get();
            combosupplierBox.ItemsSource = suppliercontroller.Get();
            combocategoryBox.ItemsSource = categoriescontroller.Get();
        }
        public void Cleaning()
        {
            //category
            idtxtBox.Text = "";
            nametxtBox.Text = "";
            //role
            idtxtroleBox.Text = "";
            nametxtroleBox.Text = "";
            //user
            idtxtuserBox.Text = "";
            emailtxtuserBox.Text = "";
            passwordtxtuserBox.Text = "";
            rolecmbBox.Text = "";
            //employee
            idtxtemployeeBox.Text = "";
            firstnametxtemployeeBox.Text = "";
            lastnametxtemployeeBox.Text = "";
            addresstxtemployeeBox.Text = "";
            religiontxtemployeeBox.Text = "";
            departmenttxtemployeeBox.Text = "";
            //supplier
            idtxtsupplier.Text = "";
            nametxtsupplier.Text = "";
            emailtxtsupplier.Text = "";
            addresstxtsupplier.Text = "";
            phonetxtphone.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }
        public void LoadGrid()
        {
            categorydtGrid.ItemsSource = categoriescontroller.Get();
            userdtGrid.ItemsSource = usercontroller.Get();
            roledtGrid.ItemsSource = rolescontroller.Get();
            assetdtldtGrid.ItemsSource = assetcontroller.Get();
            supplierdtldtGrid.ItemsSource = suppliercontroller.Get();
        }

        //==================Category========================================
        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
                if (string.IsNullOrWhiteSpace(nametxtBox.Text))
                {
                    MessageBox.Show("Please Fill Name Blank TextBox");
                }
                else
                {
                    var push = new CategoryVM(nametxtBox.Text);
                    var result = categoriescontroller.Insert(push);
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
        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtBox.Text) || string.IsNullOrWhiteSpace(idtxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new CategoryVM(nametxtBox.Text);
                    var result = categoriescontroller.Update(Convert.ToInt32(idtxtBox.Text), push);
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
        //minor satu bug yang sepele
        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var result = categoriescontroller.Delete(Convert.ToInt32(idtxtBox.Text));
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
        private void idtxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void categorydtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //errorhadling
            object item = categorydtGrid.SelectedItem;
            try
            {
                idtxtBox.Text = (categorydtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nametxtBox.Text = (categorydtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch(Exception ex)
            {

            }
        }

        //==================Role========================================
        private void savebtnrole_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtroleBox.Text))
            {
                MessageBox.Show("Please Fill Name Role Blank TextBox");
            }
            else
            {
                var push = new RoleVM(nametxtroleBox.Text);
                var result = rolescontroller.Insert(push);
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
        private void updatebtnrole_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtroleBox.Text) || string.IsNullOrWhiteSpace(idtxtroleBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new RoleVM(nametxtroleBox.Text);
                    var result = rolescontroller.Update(Convert.ToInt32(idtxtroleBox.Text), push);
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
        private void deletebtnrole_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtroleBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var result = rolescontroller.Delete(Convert.ToInt32(idtxtroleBox.Text));
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
        private void roledtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //errorhadling
            object item = roledtGrid.SelectedItem;
            try
            {
                idtxtroleBox.Text = (roledtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nametxtroleBox.Text = (roledtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        private void idtxtroleBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //==================User========================================
        private void savebtnuser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailtxtuserBox.Text) || string.IsNullOrWhiteSpace(passwordtxtuserBox.Text) || string.IsNullOrWhiteSpace(rolecmbBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new UserVM(emailtxtuserBox.Text, "metrodata.1", Convert.ToInt32(rolecmbBox.SelectedValue));
                var result = usercontroller.Insert(push);
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
        private void updatebtnuser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailtxtuserBox.Text) || string.IsNullOrWhiteSpace(idtxtuserBox.Text) || string.IsNullOrWhiteSpace(passwordtxtuserBox.Text) || string.IsNullOrWhiteSpace(Convert.ToString(rolecmbBox.SelectedValue)))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new UserVM(emailtxtuserBox.Text, passwordtxtuserBox.Text, Convert.ToInt32(rolecmbBox.SelectedValue));
                    var result = usercontroller.Update(Convert.ToInt32(idtxtuserBox.Text), push);
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
        private void deletebtnuser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtuserBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var result = usercontroller.Delete(Convert.ToInt32(idtxtuserBox.Text));
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
        private void userdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = userdtGrid.SelectedItem;
            try
            {
                idtxtuserBox.Text = (userdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                emailtxtuserBox.Text = (userdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                passwordtxtuserBox.Text = (userdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                rolecmbBox.Text = (userdtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        private void idtxtuserBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //==================Employee========================================
        private void savebtnemployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstnametxtemployeeBox.Text) || string.IsNullOrWhiteSpace(lastnametxtemployeeBox.Text) || string.IsNullOrWhiteSpace(addresstxtemployeeBox.Text) || string.IsNullOrWhiteSpace(departmenttxtemployeeBox.Text) || string.IsNullOrWhiteSpace(religiontxtemployeeBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var check = false;
                if(radiobtnemployee.IsChecked == false)
                {
                    check = false;
                } else if(radiobtnemployee1.IsChecked == true)
                {
                    check = true;
                }                     
                var push = new EmployeeVM(firstnametxtemployeeBox.Text, lastnametxtemployeeBox.Text, check , religiontxtemployeeBox.Text, departmenttxtemployeeBox.Text,addresstxtemployeeBox.Text, Convert.ToInt32(combomanagerBox.SelectedValue));
                var result = employeescontroller.Insert(push);
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
        private void updatebtnemplyee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstnametxtemployeeBox.Text) || string.IsNullOrWhiteSpace(lastnametxtemployeeBox.Text) || string.IsNullOrWhiteSpace(idtxtemployeeBox.Text) || string.IsNullOrWhiteSpace(addresstxtemployeeBox.Text) || string.IsNullOrWhiteSpace(departmenttxtemployeeBox.Text) || string.IsNullOrWhiteSpace(addresstxtemployeeBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Update Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new EmployeeVM(firstnametxtemployeeBox.Text, lastnametxtemployeeBox.Text, true, religiontxtemployeeBox.Text, departmenttxtemployeeBox.Text, addresstxtemployeeBox.Text, Convert.ToInt32(combomanagerBox.SelectedValue));
                    var result = employeescontroller.Update(Convert.ToInt32(idtxtemployeeBox.Text), push);
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
        private void deletebtnemployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtemployeeBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var result = employeescontroller.Delete(Convert.ToInt32(idtxtemployeeBox.Text));
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
        private void employeedtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = employeedtGrid.SelectedItem;
            try
            {
                idtxtemployeeBox.Text = (employeedtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                firstnametxtemployeeBox.Text = (employeedtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lastnametxtemployeeBox.Text = (employeedtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                addresstxtemployeeBox.Text = (employeedtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                //(employeedtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                religiontxtemployeeBox.Text = (employeedtGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                departmenttxtemployeeBox.Text = (employeedtGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        private void idtxtemployeeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

      
        //==================Supplier========================================
        private void savebtnsupplier_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtsupplier.Text) || string.IsNullOrWhiteSpace(emailtxtsupplier.Text) || string.IsNullOrWhiteSpace(addresstxtsupplier.Text) || string.IsNullOrWhiteSpace(phonetxtphone.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new SupplierVM(nametxtsupplier.Text, emailtxtsupplier.Text, phonetxtphone.Text, addresstxtsupplier.Text);
                var result = suppliercontroller.Insert(push);
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
        private void updatebtnsupplier_Click(object sender, RoutedEventArgs e)
        {

        }
        private void deletebtnsupplier_Click(object sender, RoutedEventArgs e)
        {

        }
        private void supplierdtldtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = supplierdtldtGrid.SelectedItem;
            try
            {
                idtxtsupplier.Text = (supplierdtldtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nametxtsupplier.Text = (supplierdtldtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                emailtxtsupplier.Text = (supplierdtldtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                addresstxtsupplier.Text = (supplierdtldtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                phonetxtphone.Text = (supplierdtldtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        private void idtxtsupplier_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //==================Asset========================================
        private void savebtnasset_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnameasset.Text) || string.IsNullOrWhiteSpace(txtstockasset.Text) || string.IsNullOrWhiteSpace(txtkeyasset.Text) || string.IsNullOrWhiteSpace(txtspecasset.Text) || string.IsNullOrWhiteSpace(combosupplierBox.Text) || string.IsNullOrWhiteSpace(combocategoryBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new AssetVM(txtnameasset.Text, Convert.ToInt32(txtstockasset.Text), Convert.ToInt32(txtkeyasset.Text), txtspecasset.Text, Convert.ToInt32(combosupplierBox.SelectedValue), Convert.ToInt32(combocategoryBox.SelectedValue));
                var result = assetcontroller.Insert(push);
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

        private void updatebtnasset_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtasset.Text) || string.IsNullOrWhiteSpace(txtnameasset.Text) || string.IsNullOrWhiteSpace(txtstockasset.Text) || string.IsNullOrWhiteSpace(txtkeyasset.Text) || string.IsNullOrWhiteSpace(txtspecasset.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
                else
                {
                MessageBoxResult msg = System.Windows.MessageBox.Show("Are You Sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    var push = new AssetVM(txtnameasset.Text, Convert.ToInt32(txtstockasset.Text), Convert.ToInt32(txtkeyasset.Text), txtspecasset.Text, Convert.ToInt32(combosupplierBox.SelectedValue), Convert.ToInt32(combocategoryBox.SelectedValue));
                    var result = assetcontroller.Update(Convert.ToInt32(idtxtasset.Text), push);
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

        private void deletebtnasset_Click(object sender, RoutedEventArgs e)
        {

        }
        private void assetdtldtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = assetdtldtGrid.SelectedItem;
            try
            {
                idtxtasset.Text = (assetdtldtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txtnameasset.Text = (assetdtldtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txtstockasset.Text = (assetdtldtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txtkeyasset.Text = (assetdtldtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                txtspecasset.Text = (assetdtldtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                combocategoryBox.Text = (assetdtldtGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                combosupplierBox.Text = (assetdtldtGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
        private void idtxtasset_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        
        
    }
}
