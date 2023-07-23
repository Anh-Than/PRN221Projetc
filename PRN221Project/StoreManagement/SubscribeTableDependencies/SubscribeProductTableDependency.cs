using StoreManagement.DataAcces;
using StoreManagement.Hubs;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace StoreManagement.SubscribeTableDependencies
{
    public class SubscribeProductTableDependency
    {
        SqlTableDependency<Product> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeProductTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency()
        {
            string connectionString = "server=DESKTOP-9DJECVQ\\JUSTTVA;uid=sa;pwd=123;database=Northwind";
            tableDependency = new SqlTableDependency<Product>(connectionString, "Products");
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependency error: {e.Error.Message}");
        }

        private void TableDependency_OnChanged(object sender, RecordChangedEventArgs<Product> e)
        {
            if(e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendProducts();
            }            
        }
    }
}
