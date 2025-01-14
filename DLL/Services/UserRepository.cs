using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models.User;
using DLL.Repositories;
using Microsoft.Extensions.Configuration;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace DLL.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GlobalConnectionSting");
        }
        public void AddUser(MstUsers user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Mst_Users (LABID, UserName, Password, GlobalUID, MobileNumber, Emailid, LastLoginDate, ActiveFlag, CreationUID, CreationDateTime, ModifyUID, ModifyDateTime)
                                 VALUES (@LABID, @UserName, @Password, @GlobalUID, @MobileNumber, @Emailid, @LastLoginDate, @ActiveFlag, @CreationUID, @CreationDateTime, @ModifyUID, @ModifyDateTime)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LABID", user.LABID);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@GlobalUID", user.GlobalUID);
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Emailid", user.EmailId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LastLoginDate", user.LastLoginDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ActiveFlag", user.ActiveFlag ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreationUID", user.CreationUID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreationDateTime", user.CreationDateTime ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ModifyUID", user.ModifyUID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ModifyDateTime", user.ModifyDateTime ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<MstUsers> GetAllUsers()
        {
            var users = new List<MstUsers>();
            try
            {

            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mst_Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new MstUsers
                            {
                                UID = reader.GetInt32(reader.GetOrdinal("UID")),
                                LABID = reader.GetGuid(reader.GetOrdinal("LABID")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                GlobalUID = reader.GetGuid(reader.GetOrdinal("GlobalUID")),
                                MobileNumber = reader.IsDBNull(reader.GetOrdinal("MobileNumber")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("MobileNumber")),
                                EmailId = reader.IsDBNull(reader.GetOrdinal("Emailid")) ? null : reader.GetString(reader.GetOrdinal("Emailid")),
                                LastLoginDate = reader.IsDBNull(reader.GetOrdinal("LastLoginDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastLoginDate")),
                                ActiveFlag = reader.IsDBNull(reader.GetOrdinal("ActiveFlag")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("ActiveFlag")),
                                CreationUID = reader.IsDBNull(reader.GetOrdinal("CreationUID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CreationUID")),
                                CreationDateTime = reader.IsDBNull(reader.GetOrdinal("CreationDateTime")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreationDateTime")),
                                ModifyUID = reader.IsDBNull(reader.GetOrdinal("ModifyUID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ModifyUID")),
                                ModifyDateTime = reader.IsDBNull(reader.GetOrdinal("ModifyDateTime")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifyDateTime"))
                            };

                            users.Add(user);
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {

            }

            return users;
        }


        public MstUsers GetUserById(int id)
        {
            MstUsers user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mst_Users WHERE UID = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new MstUsers
                    {
                        UID = reader.GetInt32(reader.GetOrdinal("UID")),
                        LABID = reader.GetGuid(reader.GetOrdinal("LABID")),
                        UserName = reader.GetString(reader.GetOrdinal("UserName")),
                        Password = reader.GetString(reader.GetOrdinal("Password")),
                        GlobalUID = reader.GetGuid(reader.GetOrdinal("GlobalUID")),
                        MobileNumber = reader.IsDBNull(reader.GetOrdinal("MobileNumber")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("MobileNumber")),
                        EmailId = reader.IsDBNull(reader.GetOrdinal("Emailid")) ? null : reader.GetString(reader.GetOrdinal("Emailid")),
                        LastLoginDate = reader.IsDBNull(reader.GetOrdinal("LastLoginDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastLoginDate")),
                        ActiveFlag = reader.IsDBNull(reader.GetOrdinal("ActiveFlag")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("ActiveFlag")),
                        CreationUID = reader.IsDBNull(reader.GetOrdinal("CreationUID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CreationUID")),
                        CreationDateTime = reader.IsDBNull(reader.GetOrdinal("CreationDateTime")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreationDateTime")),
                        ModifyUID = reader.IsDBNull(reader.GetOrdinal("ModifyUID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ModifyUID")),
                        ModifyDateTime = reader.IsDBNull(reader.GetOrdinal("ModifyDateTime")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ModifyDateTime"))
                    };
                }

                reader.Close();
            }

            return user;

        }

        public void UpdateUser(MstUsers user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Mst_Users SET
                                 LABID = @LABID,
                                 UserName = @UserName,
                                 Password = @Password,
                                 GlobalUID = @GlobalUID,
                                 MobileNumber = @MobileNumber,
                                 Emailid = @Emailid,
                                 LastLoginDate = @LastLoginDate,
                                 ActiveFlag = @ActiveFlag,
                                 CreationUID = @CreationUID,
                                 CreationDateTime = @CreationDateTime,
                                 ModifyUID = @ModifyUID,
                                 ModifyDateTime = @ModifyDateTime
                                 WHERE UID = @UID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UID", user.UID);
                cmd.Parameters.AddWithValue("@LABID", user.LABID);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@GlobalUID", user.GlobalUID);
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Emailid", user.EmailId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LastLoginDate", user.LastLoginDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ActiveFlag", user.ActiveFlag ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreationUID", user.CreationUID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CreationDateTime", user.CreationDateTime ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ModifyUID", user.ModifyUID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ModifyDateTime", user.ModifyDateTime ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
