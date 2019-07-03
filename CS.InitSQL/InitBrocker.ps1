[String]$dbname = "CarSignal";
 
# Open ADO.NET Connection with Windows authentification to local SQLSERVER.
$con = New-Object Data.SqlClient.SqlConnection;
$con.ConnectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True;";
$con.Open();

  
  # Create the brocker.
  $sql = "USE [$dbname] ALTER DATABASE  [$dbname] SET NEW_BROKER;"
  $cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
  $cmd.ExecuteNonQuery();     
                              
  # Close & Clear all objects.
  $cmd.Dispose();
  $con.Close();
  $con.Dispose();
              

Write-Host "keep docker runing infinity"
#sleep thread
While($true) {
  sleep 60
}