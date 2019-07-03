using CS.DashBoard.Hubs;
using CS.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CS.DashBoard.Helpers
{
    public class SqlNotification
    {
        private readonly IConfiguration config;
        private readonly IHubContext<SignalHub> signalHub;

        public SqlNotification(IConfiguration config, IHubContext<SignalHub> signalHub)
        {
            this.config = config;
            this.signalHub = signalHub;
        }

        public IEnumerable<Customer_Car> Get() {

            List<Customer_Car> cars = null;
            SqlDependency dependency = null;
            Customer_Car customerCar = null;

            var connectionString = config.GetConnectionString("CarSignalDb");

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("spGetCars", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Notification = null;
                    dependency = new SqlDependency(cmd);
                    dependency.OnChange += RefreshDashboard;
                    SqlDependency.Start(connectionString);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        cars = new List<Customer_Car>();

                        while (dr.Read()) {
                            customerCar = new Customer_Car()
                            {
                                Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? -1 : dr.GetInt32(dr.GetOrdinal("Id")),
                                LastPing = dr.IsDBNull(dr.GetOrdinal("LastPing")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("LastPing")),
                                Vin = dr.IsDBNull(dr.GetOrdinal("Vin")) ? "" : dr.GetString(dr.GetOrdinal("Vin")),
                                RegNr = dr.IsDBNull(dr.GetOrdinal("RegNr")) ? "" : dr.GetString(dr.GetOrdinal("RegNr")),
                                StatusId = dr.IsDBNull(dr.GetOrdinal("StatusId")) ? (short)-1 : dr.GetInt16(dr.GetOrdinal("StatusId")),
                                CustomerId = dr.IsDBNull(dr.GetOrdinal("CustomerId")) ? -1 : dr.GetInt32(dr.GetOrdinal("CustomerId")),
                            };
                            cars.Add(customerCar);
                        }
                    }
                    return cars;
                }
                finally {
                    cn.Close();
                }
            }
        }

        private void RefreshDashboard(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                signalHub.Clients.All.SendAsync("NotifyData");
            }
            Get();
        }
    }
}
