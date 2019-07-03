[String]$dbname = "CarSignal";
 
# Open ADO.NET Connection with Windows authentification to local SQLSERVER.
$con = New-Object Data.SqlClient.SqlConnection;
$con.ConnectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True;";
$con.Open();
 
# Select-Statement for AD group logins
$sql = "SELECT name
        FROM sys.databases
        WHERE name = '$dbname';";
 
# New command and reader.
$cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
$rd = $cmd.ExecuteReader();
if ($rd.Read())
{   
    Write-Host "Database $dbname already exists";  
    $rd.Close();
    $rd.Dispose();
}
else
{ 
  $rd.Close();
  $rd.Dispose();
  # Create the database.
  $sql = "CREATE DATABASE [$dbname];"
  $cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
  $cmd.ExecuteNonQuery();     
  Write-Host "Database $dbname is created!";
 
 
  # Close & Clear all objects.
  $cmd.Dispose();
  $con.Close();
  $con.Dispose();
}



Write-Host "keep docker runing infinity"
#sleep thread
While($true) {
  sleep 60
}