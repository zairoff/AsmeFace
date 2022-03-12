using System;
using System.Data;
using System.Drawing;

namespace AsmeFace
{
    public class DataBase
    {
        public System.Collections.Generic.List<Tree> GetTree(string query)
        {
            System.Collections.Generic.List<Tree> myTrees = new System.Collections.Generic.List<Tree>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                connection.Open();
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    cmd.AllResultTypesAreUnknown = true;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tree myTree = new Tree
                            {
                                Ttext = reader[0].ToString(),
                                Tname = reader[1].ToString()
                            };
                            myTrees.Add(myTree);
                        }
                    }
                }
            }
            return myTrees;
        }

        public bool InsertData(string query)
        {
            bool bln = false;
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                connection.Open();
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    cmd.AllResultTypesAreUnknown = true;
                    cmd.ExecuteNonQuery();
                    bln = true;
                }
            }
            return bln;
        }

        public System.Collections.Generic.List<string> GetStringList(string query)
        {
            System.Collections.Generic.List<string> devices = new System.Collections.Generic.List<string>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {                
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        devices.Add(reader[0].ToString());
                    }
                }
            }
            return devices;
        }

        public System.Collections.Generic.List<DeviceInfo> GetDevices(string query)
        {
            var devices = new System.Collections.Generic.List<DeviceInfo>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DeviceInfo deviceInfo = new DeviceInfo
                        {
                            szMac = reader["device_mac"].ToString(),
                            szVersion = reader["device_version"].ToString(),
                            dwIPAddress = reader["device_ip"].ToString(),                            
                            dwStatus = reader["device_status"].ToString(),
                            dwDoor = reader["device_door"].ToString(),
                            dwType = reader["device_type"].ToString()
                        };
                        devices.Add(deviceInfo);
                    }
                }
            }
            return devices;
        }

        public int InsertFace(string query, byte[] photo, byte[] finger)
        {
            int index = -1;
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Image", NpgsqlTypes.NpgsqlDbType.Bytea, photo);
                    if(finger == null)
                        cmd.Parameters.AddWithValue("Finger", NpgsqlTypes.NpgsqlDbType.Bytea, DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("Finger", NpgsqlTypes.NpgsqlDbType.Bytea, finger);

                    connection.Open();
                    index = Convert.ToInt32(cmd.ExecuteScalar());                    
                }
            }
            return index;
        }

        public int GetID(string query)
        {
            int index = -1;
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {                   
                    connection.Open();
                    index = System.Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return index;
        }

        public bool CheckDB(string query)
        {
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
        }

        public void GetRecords(string query, System.Windows.Forms.DataGridView dataGridView)
        {
            using (var conn = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                conn.Open();
                using (var adapter = new Npgsql.NpgsqlDataAdapter(query, conn))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                    //GridHeaders();
                }
            }
        }

        public System.Collections.Generic.List<MySmena> GetSmena(string query)
        {
            System.Collections.Generic.List<MySmena> mySmenas = new System.Collections.Generic.List<MySmena>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MySmena deviceInfo = new MySmena
                        {
                            Smena_nomi = reader["smena_nomi"].ToString(),
                            Smena_boshlanishi = reader["smena_boshlanishi"].ToString(),
                            Smena_tugashi = reader["smena_tugashi"].ToString(),
                            Obed_boshlanishi = reader["obed_boshlanishi"].ToString(),
                            Obed_tugashi = reader["obed_tugashi"].ToString(),
                            Kech_keldi = reader["kech_keldi"].ToString(),
                            Vox_ketdi = reader["vox_ketdi"].ToString()
                        };
                        mySmenas.Add(deviceInfo);
                    }
                }
            }
            return mySmenas;
        }

        public System.Collections.Generic.List<MyGrafik> GetGrafik(string query)
        {
            System.Collections.Generic.List<MyGrafik> mySmenas = new System.Collections.Generic.List<MyGrafik>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MyGrafik deviceInfo = new MyGrafik
                        {
                            Grafik_nomi = reader[0].ToString(),
                            Smena_boshlanishi = reader[1].ToString(),
                            Smena_tugashi = reader[2].ToString(),
                            Obed_boshlanishi = reader[3].ToString(),
                            Obed_tugashi = reader[4].ToString(),
                            Kech_keldi = reader[5].ToString(),
                            Vox_ketdi = reader[6].ToString(),
                            Kun = reader[7].ToString()
                        };
                        mySmenas.Add(deviceInfo);
                    }
                }
            }
            return mySmenas;
        }

        public System.Collections.Generic.List<EmployeeShortInfo> GetEmployeeShortInfo(string query)
        {
            var employeeShortInfos = new System.Collections.Generic.List<EmployeeShortInfo>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeShortInfo employeeShortInfo = new EmployeeShortInfo
                        {
                            ID = Convert.ToInt32(reader["employeeid"]),
                            Familiya = reader["familiya"].ToString(),
                            Ism = reader["ism"].ToString(),
                            Otchestvo = reader["otchestvo"].ToString(),
                            Otdel = reader["otdel"].ToString(),
                            Lavozim = reader["lavozim"].ToString()
                        };
                        employeeShortInfos.Add(employeeShortInfo);
                    }
                }
            }
            return employeeShortInfos;
        }

        public System.Collections.Generic.List<EmployeeGrafik> GetEmployeeGrafik(string query)
        {
            System.Collections.Generic.List<EmployeeGrafik> mySmenas = new System.Collections.Generic.List<EmployeeGrafik>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeGrafik deviceInfo = new EmployeeGrafik
                        {
                            ID = System.Convert.ToInt32(reader["employeeid"]),
                            Familiya = reader["familiya"].ToString(),
                            Ism = reader["ism"].ToString(),
                            Otchestvo = reader["otchestvo"].ToString(),
                            Otdel = reader["otdel"].ToString(),
                            Lavozim = reader["lavozim"].ToString(),
                            Grafik = reader["grafik_nomi"].ToString(),
                            Dan = ((DateTime)reader["dan"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            Gacha = ((DateTime)reader["gacha"]).ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        mySmenas.Add(deviceInfo);
                    }
                }
            }
            return mySmenas;
        }

        /*For Single*/

        public System.Collections.Generic.List<EmployeeGrafik> GetEmployeeGrafikSingle(string query)
        {
            System.Collections.Generic.List<EmployeeGrafik> mySmenas = new System.Collections.Generic.List<EmployeeGrafik>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeGrafik deviceInfo = new EmployeeGrafik
                        {
                            ID = System.Convert.ToInt32(reader["employeeid"]),
                            Familiya = reader["familiya"].ToString(),
                            Ism = reader["ism"].ToString(),
                            Otchestvo = reader["otchestvo"].ToString(),
                            Otdel = reader["otdel"].ToString(),
                            Lavozim = reader["lavozim"].ToString(),
                            Grafik = reader["grafik_nomi"].ToString()
                        };
                        mySmenas.Add(deviceInfo);
                    }
                }
            }
            return mySmenas;
        }

        public System.Collections.Generic.List<Employee> GetEmployee(string query)
        {
            var employees = new System.Collections.Generic.List<Employee>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    //cmd.AllResultTypesAreUnknown = true;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                ID = Convert.ToInt32(reader["employeeid"])
                                //Photo = (byte[])reader["photo"]
                            };

                            if (reader["finger"] != DBNull.Value)
                                employee.Finger = (byte[])reader["finger"];

                            if (reader["photo"] != DBNull.Value)
                                employee.Photo = (byte[])reader["photo"];

                            employee.Card = reader["card"].ToString();
                            employee.Familiya = reader["familiya"].ToString();
                            employee.Ism = reader["ism"].ToString();
                            employee.Otchestvo = reader["otchestvo"].ToString();
                            employee.Otdel = reader["otdel"].ToString();
                            employee.Lavozim = reader["lavozim"].ToString();                            
                            employee.Address = reader["address"].ToString();                            
                            employees.Add(employee);
                        }
                    }                        
                }
            }
            return employees;
        }

        public System.Collections.Generic.List<EmployeeInDevice> GetEmployeeInDevices(string query)
        {
            var employees = new System.Collections.Generic.List<EmployeeInDevice>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    //cmd.AllResultTypesAreUnknown = true;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new EmployeeShortInfo
                            {
                                ID = Convert.ToInt32(reader["employeeid"]),
                                Familiya = reader["familiya"].ToString(),
                                Ism = reader["ism"].ToString(),
                                Otchestvo = reader["otchestvo"].ToString(),
                                Otdel = reader["otdel"].ToString(),
                                Lavozim = reader["lavozim"].ToString()
                            };
                            var device = new DeviceInfo
                            {
                                dwType = reader["device_type"].ToString(),
                                szMac = reader["device_mac"].ToString(),
                                dwIPAddress = reader["device_ip"].ToString(),
                                dwStatus = reader["device_status"].ToString(),
                                dwDoor = reader["device_door"].ToString()
                            };

                            var employeeInDevice = new EmployeeInDevice
                            {
                                EmployeeShortInfo = employee,
                                DeviceInfo = device
                            };

                            employees.Add(employeeInDevice);
                        }
                    }
                }
            }
            return employees;
        }

        public string GetString(string query)
        {
            var str = "";
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            str = reader[0].ToString();
                    }
                }
            }
            return str;
        }

        public System.Collections.Generic.List<Door> GetDoors(string query)
        {
            var doors = new System.Collections.Generic.List<Door>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var door = new Door
                        {
                            Name = reader["name"].ToString(),
                            Main = Convert.ToBoolean(reader["main"])
                        };
                        doors.Add(door);
                    }
                }
            }
            return doors;
        }

        public System.Collections.Generic.List<Access> GetAccess(string query)
        {
            var acceses = new System.Collections.Generic.List<Access>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var access = new Access
                        {
                            Employeeid = Convert.ToInt32(reader["employeeid"]),
                            Card = reader["card"].ToString(),
                            GroupID = Convert.ToInt32(reader["id"]),
                            Grafik = reader["access_grafik_nomi"].ToString(),
                            DeviceIp = reader["device_ip"].ToString()
                        };
                        acceses.Add(access);
                    }
                }
            }
            return acceses;
        }

        public System.Collections.Generic.List<AccessSmenaClass> GetAccessSmenas(string query)
        {
            var accessSmenas = new System.Collections.Generic.List<AccessSmenaClass>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var accessSmena = new AccessSmenaClass
                        {
                            AccessSmenaNomi = reader["access_smena_nomi"].ToString(),
                            Boshlanishi1 = reader["boshlanishi_1"].ToString(),
                            Tugashi1 = reader["tugashi_1"].ToString(),
                            Boshlanishi2 = reader["boshlanishi_2"].ToString(),
                            Tugashi2 = reader["tugashi_2"].ToString(),
                            Boshlanishi3 = reader["boshlanishi_3"].ToString(),
                            Tugashi3 = reader["tugashi_3"].ToString(),
                        };
                        accessSmenas.Add(accessSmena);
                    }
                }
            }
            return accessSmenas;
        }

        public System.Collections.Generic.List<AccessGrafikClass> GetAccessGrafik(string query)
        {
            var grafiks = new System.Collections.Generic.List<AccessGrafikClass>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var grafik = new AccessGrafikClass
                        {
                            AccessSmenaNomi = reader[0].ToString(),
                            Boshlanishi1 = reader[1].ToString(),
                            Tugashi1 = reader[2].ToString(),
                            Boshlanishi2 = reader[3].ToString(),
                            Tugashi2 = reader[4].ToString(),
                            Boshlanishi3 = reader[5].ToString(),
                            Tugashi3 = reader[6].ToString(),
                            Kun = reader[7].ToString()
                        };
                        grafiks.Add(grafik);
                    }
                }
            }
            return grafiks;
        }

        public System.Collections.Generic.List<EmployeeGrafik> GetEmployeeAccessGrafik(string query)
        {
            var grafiks = new System.Collections.Generic.List<EmployeeGrafik>();
            using (var connection = new Npgsql.NpgsqlConnection(Helper.CnnVal("DBConnection")))
            {
                using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var grafik = new EmployeeGrafik
                        {
                            ID = System.Convert.ToInt32(reader["employeeid"]),
                            Familiya = reader["familiya"].ToString(),
                            Ism = reader["ism"].ToString(),
                            Otchestvo = reader["otchestvo"].ToString(),
                            Otdel = reader["otdel"].ToString(),
                            Lavozim = reader["lavozim"].ToString(),
                            Grafik = reader["access_grafik_nomi"].ToString()
                        };
                        grafiks.Add(grafik);
                    }
                }
            }
            return grafiks;
        }
    }    
}
