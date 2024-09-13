using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows;

namespace EmployeeTrackingSystem
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeContext _context;

        public MainWindow()
        {
            InitializeComponent();  // Initialize the XAML components
            _context = App.ServiceProvider.GetService<EmployeeContext>();  // Get the database context
            LoadEmployees();  // Load employees when the window opens
        }

        private void LoadEmployees()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            EmployeeDataGrid.ItemsSource = employees;  // Bind employees to the DataGrid
        }

        private void OpenAddEmployeeWindow(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddEmployeeWindow(_context);  // Open the AddEmployeeWindow
            addEmployeeWindow.ShowDialog();
            LoadEmployees();  // Refresh the DataGrid after adding a new employee
        }
    }
}
