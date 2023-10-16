using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Salary
{
    internal class StatementDAO
    {
        private const string _connectionString =
            "datasource=localhost;port=3306;username=root;password=root;database=payment_statement";

        #region Statement
        public List<Entry> GetEntries()
        {
            List<Entry> entries = new List<Entry>();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT employees.ID, employees.Name, positions.Name as Position, positions.Salary, taxes.Tax, taxes.Fund FROM `employees` JOIN positions ON positions_ID = positions.ID JOIN taxes ON positions.Taxes_ID = taxes.ID";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Entry entry = new Entry
                    (
                        id: reader.GetInt32(0),
                        name: reader.GetString(1),
                        position: reader.GetString(2),
                        accrue: reader.GetDouble(3),
                        tax: reader.GetDouble(4),
                        fund: reader.GetDouble(5)
                    );

                    entries.Add(entry);
                }
            }
            connection.Close();

            return entries;
        }

        public Entry GetEntry(int entryID)
        {
            Entry entry = new Entry();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT employees.ID, employees.Name, positions.Name as Position, positions.Salary, taxes.Tax, taxes.Fund FROM `employees` JOIN positions ON positions_ID = positions.ID JOIN taxes ON positions.Taxes_ID = taxes.ID WHERE employees.ID = @searchID";
            command.Parameters.AddWithValue("@searchID", entryID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    entry.ID = reader.GetInt32(0);
                    entry.Name = reader.GetString(1);
                    entry.Position = reader.GetString(2);
                    entry.Accrue = reader.GetDouble(3);
                    entry.Tax = reader.GetDouble(4);
                    entry.Fund = reader.GetDouble(5);
                }
                entry.CalculateResult(entry.Accrue, entry.Tax, entry.Fund);
            }
            connection.Close();

            return entry;
        }

        public Employee GetEmployee(int employeeID)
        {
            Employee employee = new Employee();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT employees.ID, employees.Name, positions.ID, positions.Name FROM `employees` JOIN positions ON positions_ID = positions.ID WHERE employees.ID = @employeeID";
            command.Parameters.AddWithValue("@employeeID", employeeID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    employee.ID = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.Position.ID = reader.GetInt32(2);
                    employee.Position.Name = reader.GetString(3);
                }
            }
            connection.Close();

            return employee;
        }

        public List<Entry> GetSearchResult(string searchString, string filter = "employees.Name")
        {
            List<Entry> entries = new List<Entry>();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            string wildString = '%' + searchString + '%';
            string columnName = "";
            if (filter == "Name")
                columnName = "employees.Name";
            else
                columnName = "positions.Name";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT employees.ID, employees.Name, positions.Name as Position, positions.Salary, taxes.Tax, taxes.Fund FROM `employees` JOIN positions ON positions_ID = positions.ID JOIN taxes ON positions.Taxes_ID = taxes.ID WHERE " + columnName + " LIKE @search";
            command.Parameters.AddWithValue("@search", wildString);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Entry entry = new Entry
                    (
                        id: reader.GetInt32(0),
                        name: reader.GetString(1),
                        position: reader.GetString(2),
                        accrue: reader.GetDouble(3),
                        tax: reader.GetDouble(4),
                        fund: reader.GetDouble(5)
                    );

                    entries.Add(entry);
                }
            }
            connection.Close();

            return entries;
        }

        public void AddEmployee(string employeeName, string employeePosition)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT `ID` FROM `positions` WHERE Name = @positionName";
            command.Parameters.AddWithValue("@positionName", employeePosition);
            int positionID = 0;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    positionID = reader.GetInt32(0);
                }
            }

            command.CommandText = "INSERT INTO `employees`(`Name`, `positions_ID`) VALUES (@name, @positionID)";
            command.Parameters.AddWithValue("@name", employeeName);
            command.Parameters.AddWithValue("@positionID", positionID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteEmployee(int employeeID)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM `employees` WHERE employees.ID = @employeeID", connection);

            command.Parameters.AddWithValue("@employeeID", employeeID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void EditEmployee(int employeeID, string employeeName, string employeePosition)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT `ID` FROM `positions` WHERE Name = @positionName";
            command.Parameters.AddWithValue("@positionName", employeePosition);
            int positionID = 0;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    positionID = reader.GetInt32(0);
                }
            }

            command.CommandText = "UPDATE `employees` SET `Name`= @name,`positions_ID`= @positionID WHERE ID = @employeeID";

            command.Parameters.AddWithValue("@employeeID", employeeID);
            command.Parameters.AddWithValue("@name", employeeName);
            command.Parameters.AddWithValue("@positionID", positionID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region Positions

        public List<Position> GetPositions()
        {
            List<Position> positions = new List<Position>();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT positions.ID, positions.Name, positions.Salary, taxes.Type FROM `positions` JOIN taxes ON Taxes_ID = taxes.ID";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Position position = new Position();

                    position.ID = reader.GetInt32(0);
                    position.Name = reader.GetString(1);
                    position.Salary = reader.GetDouble(2);
                    position.TaxType = (reader.GetString(3) == "Contract") ? Taxes.TaxType.Contract : Taxes.TaxType.Income;

                    positions.Add(position);
                }
            }
            connection.Close();

            return positions;
        }

        public Position GetPosition(int positionID)
        {
            Position position = new Position();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT positions.ID, positions.Name, positions.Salary, taxes.Type FROM `positions` JOIN taxes ON Taxes_ID = taxes.ID WHERE positions.ID = @positionID";
            command.Parameters.AddWithValue("@positionID", positionID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    position.ID = reader.GetInt32(0);
                    position.Name = reader.GetString(1);
                    position.Salary = reader.GetDouble(2);
                    position.TaxType = reader.GetString(3) == "Contract" ? Taxes.TaxType.Contract : Taxes.TaxType.Income;
                }
            }

            connection.Close();
            return position;
        }

        public void DeletePosition(int positionID)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM `positions` WHERE positions.ID = @positionID", connection);
            command.Parameters.AddWithValue("@positionID", positionID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void EditPosition(int positionID, Position newPosition)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT `ID` FROM `taxes` WHERE Type = @taxType";
            command.Parameters.AddWithValue("@taxType", newPosition.TaxType.ToString());
            int taxID = 0;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    taxID = reader.GetInt32(0);
                }
            }

            command.CommandText = "UPDATE `positions` SET `Name`= @positionName,`Salary`= @positionSalary,`Taxes_ID`= @taxID WHERE ID = @positionID";

            command.Parameters.AddWithValue("@positionID", positionID);
            command.Parameters.AddWithValue("@positionName", newPosition.Name);
            command.Parameters.AddWithValue("@positionSalary", newPosition.Salary);
            command.Parameters.AddWithValue("@taxID", taxID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void AddPosition(Position newPosition)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT `ID` FROM `taxes` WHERE Type = @taxType";
            command.Parameters.AddWithValue("@taxType", newPosition.TaxType.ToString());
            int taxID = 0;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    taxID = reader.GetInt32(0);
                }
            }

            command.CommandText = "INSERT INTO `positions`(`Name`, `Salary`, `Taxes_ID`) VALUES (@positionName, @positionSalary, @taxID)";
            command.Parameters.AddWithValue("@positionName", newPosition.Name);
            command.Parameters.AddWithValue("@positionSalary", newPosition.Salary);
            command.Parameters.AddWithValue("@taxID", taxID);

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion

        #region Taxes

        public List<Taxes> GetTaxes()
        {
            List<Taxes> taxes = new List<Taxes>();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `ID`, `Type`, `Tax`, `Fund` FROM `taxes` WHERE 1";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Taxes tax = new Taxes
                    {
                        ID = reader.GetInt32(0),
                        Type = (reader.GetString(1) == "Contract") ? Taxes.TaxType.Contract : Taxes.TaxType.Income,
                        Tax = reader.GetDouble(2),
                        Fund = reader.GetDouble(3),
                    };

                    taxes.Add(tax);
                }
            }
            connection.Close();

            return taxes;
        }

        public void EditTaxes(List<Taxes> newTaxes)
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = "UPDATE `taxes` SET `Tax`= @contractTax,`Fund`= @contractFund WHERE ID = 1; UPDATE `taxes` SET `Tax`= @incomeTax,`Fund`= @incomeFund WHERE ID = 2;";
            command.Parameters.AddWithValue("@contractTax", newTaxes[0].Tax);
            command.Parameters.AddWithValue("@contractFund", newTaxes[0].Fund);
            command.Parameters.AddWithValue("@incomeTax", newTaxes[1].Tax);
            command.Parameters.AddWithValue("@incomeFund", newTaxes[1].Fund);

            command.ExecuteNonQuery();

            connection.Close();
        }

        #endregion
    }
}
