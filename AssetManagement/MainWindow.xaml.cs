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
using System.Data.SqlClient;
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
        UserController usercontroller = new UserController();

        public string ConfigurationManagerConfigurationManager { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
           // categoriescontroller.Get("SELECT * FROM Categories", nametxtBox.Text);
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

        public void LoadGrid()
        {
            categorydtGrid.ItemsSource = categoriescontroller.Get();
            userdtGrid.ItemsSource = usercontroller.Get();
            roledtGrid.ItemsSource = rolescontroller.Get();
        }
        public void LoadCombo()
        {
            rolecmbBox.ItemsSource = rolescontroller.Get();
        }
        public void Cleaning()
        {
            idtxtBox.Text = "";
            nametxtBox.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
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
                    LoadGridRole();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                CleaningRole();
            }
        }
        private void updatebtnrole_Click(object sender, RoutedEventArgs e)
        {

        }
        private void deletebtnrole_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadGridRole()
        {

        }
        public void CleaningRole()
        {
            idtxtroleBox.Text = "";
            nametxtroleBox.Text = "";
        }
        private void roledtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //errorhadling
            object item = roledtGrid.SelectedItem;
            try
            {
                idtxtBox.Text = (roledtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nametxtBox.Text = (roledtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
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
            if (string.IsNullOrWhiteSpace(emailtxtuserBox.Text))
            {
                MessageBox.Show("Please Fill Name Role Blank TextBox");
            }
            else
            {
                var push = new UserVM(emailtxtuserBox.Text, "metrodata.1", Convert.ToInt32(rolecmbBox.SelectedValue));
                var result = usercontroller.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGridUser();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                CleaningUser();
            }
        }

        private void updatebtnuser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebtnuser_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadGridUser()
        {
            
        }
        public void CleaningUser()
        {
            idtxtroleBox.Text = "";
            nametxtroleBox.Text = "";
        }
        //==================Employee========================================
        private void savebtnemployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updatebtnemplyee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebtnemployee_Click(object sender, RoutedEventArgs e)
        {

        }
        //==================Loan Request========================================
        private void savebtnloan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updatebtnloan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebtnloan_Click(object sender, RoutedEventArgs e)
        {

        }
        //==================Loan Request Detail========================================
        private void savebtnloandtl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updatebtnloandtl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebtnloandtl_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
