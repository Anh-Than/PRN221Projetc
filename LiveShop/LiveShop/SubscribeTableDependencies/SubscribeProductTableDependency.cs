using LiveShop.Hubs;
using LiveShop.Model;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace LiveShop.SubscribeTableDependencies
{
    public class SubscribeProductTableDependency
    {
        SqlTableDependency<Car> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeProductTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }
        public void SubscribeTableDependency()
        {
            string connectionString = "Data Source=JUSTTVA;Initial Catalog=MyStock;Integrated Security=True";
            tableDependency = new SqlTableDependency<Car> (connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();

        }

        private void TableDependency_OnChanged(object sender, RecordChangedEventArgs<Car> e)
        {
            if(e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendProducts();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Car)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
