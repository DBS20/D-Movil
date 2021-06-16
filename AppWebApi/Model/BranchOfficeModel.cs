using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebApi.Model
{
    public class BranchOfficeModel
    {
        string ConectionString = "Server=tcp:dirverdbsservern.database.windows.net,1433;Initial Catalog=DriverDBS;Persist Security Info=False;User ID=driverdbsuser;Password=movilDBSAzure1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int ID { get; set; }

        public string Place { get; set; }//Lugar

        public string Address { get; set; }//Dirección

        public string Image { get; set; }//Imagen

        public double Latitude { get; set; }//Latitud

        public double Longitude { get; set; }//Longitud


        //METODOS:
        public ResponseModel GetAll()
        {
            List<BranchOfficeModel> list = new List<BranchOfficeModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM BOffice";

                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new BranchOfficeModel
                                {
                                    ID = (int)reader["ID"],
                                    Place = reader["Place"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Image = reader["Image"].ToString(),
                                    Latitude = (double)reader["Latitude"],
                                    Longitude = (double)reader["Longitude"]

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
            catch (Exception ex)
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
            BranchOfficeModel obj = new BranchOfficeModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM BOffice WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                obj = new BranchOfficeModel
                                {
                                    ID = (int)reader["ID"],
                                    Place = reader["Place"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Image = reader["Image"].ToString(),
                                    Latitude = (double)reader["Latitude"],
                                    Longitude = (double)reader["Longitude"]


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
                    string tsql = "INSERT INTO BOffice (ID, Place, Address, Image, Latitude, Longitude) VALUES(@ID, @Place, @Address, @Image, @Latitude, @Longitude);";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Place", Place);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);
                        
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
                    string tsql = "UPDATE BOffice SET Place=@Place, Address=@Address, Image=@Image, Latitude=@Latitude, Longitude=@Longitude WHERE ID = @ID; ";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Place", Place);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Image", Image);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);

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
                    string tsql = "DELETE FROM BOffice WHERE ID = @ID;";
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
