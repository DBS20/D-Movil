using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebApi.Model
{
    public class AModel
    {
        string ConectionString = "Server=tcp:dirverdbsservern.database.windows.net,1433;Initial Catalog=DriverDBS;Persist Security Info=False;User ID=driverdbsuser;Password=movilDBSAzure1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int ID { get; set; }

        public string Name { get; set; }//Nombre

        public double Price { get; set; }//Precio

        public string Size { get; set; }//Tamaño: Chico-Mediano-Alto

        public string CustomerName { get; set; }//NombreCliente

        public string Type { get; set; }//Tipo:Frío o Caliente

        public string Image { get; set; }//Imagen



        //METODOS:
        public ResponseModel GetAll()
        {
            List<AModel> list = new List<AModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Tabla";

                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new AModel
                                {
                                    ID = (int)reader["ID"],
                                    Name = reader["Name"].ToString(),
                                    Price = (double)reader["Price"],
                                    Size = reader["Size"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Image = reader["Image"].ToString()
                                });
                            }
                        }
                    }
                }


                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "ÉXITO: Obtenidos correctamente",
                    Result = list
                };

            }
            catch(Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"ERROR: No se pudieron obtener ({ex.Message})",
                    Result = null
                };
            }

            
        }

        public ResponseModel GetByID(int ID)
        {
            AModel obj = new AModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Tabla WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                obj = new AModel
                                {
                                    ID = (int)reader["ID"],
                                    Name = reader["Name"].ToString(),
                                    Price = (double)reader["Price"],
                                    Size = reader["Size"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Image = reader["Image"].ToString()


                                };
                            }
                        }
                    }
                }


                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "ÉXITO: Obtenido correctamente",
                    Result = obj
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"ERROR: No se pudo obtener ({ex.Message})",
                    Result = null
                };
            }
        }

        public ResponseModel Insert()
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "INSERT INTO Tabla (ID, Name, Price, Size, CustomerName, Type, Image) VALUES(@ID, @Name, @Price, @Size, @CustomerName, @Type, @Image);";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Size", Size);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.ExecuteScalar();

                    }

                }

                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "ÉXITO: Insertado correctamente",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"ERROR: No se pudo insertar ({ex.Message})",
                    Result = null
                };
            }
        }

        public ResponseModel Update()
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {

                    conn.Open();
                    string tsql = "UPDATE Tabla SET Name=@Name, Price=@Price, Size=@Size, CustomerName=@CustomerName, Type=@Type, Image=@Image WHERE ID = @ID; ";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Size", Size);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.ExecuteScalar();
                    }
                }
                
                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "ÉXITO: Actualizado correctamente",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"ERROR: No se pudo actualizar ({ex.Message})",
                    Result = null
                };
            }
        }

        public ResponseModel Delete(int ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "DELETE FROM Tabla WHERE ID = @ID;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();
                        
                    }
                }

                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "ÉXITO: Eliminado correctamente",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"ERROR: No se pudo actualizar ({ex.Message})",
                    Result = null
                };
            }
        }
    }
}
