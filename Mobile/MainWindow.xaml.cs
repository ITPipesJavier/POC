using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Enums;
using Logic.Core.Services;
using Repository.Implementations.SQLServer;

namespace Mobile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Example of using the IAssetService

            var assetService = new AssetService(new SqlServerAssetRepository(new SqlServerDatabaseProvider("")));

            var asset = assetService.GetAsset(AssetType.ML, 1);

            //Print the asset details to the console or UI
            if (asset != null)
            {
                Console.WriteLine($"Asset: {asset}");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
        }
    }
}