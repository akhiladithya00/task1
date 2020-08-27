using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Archanagrand.Models;
using System.Data;
using System.Configuration;

namespace Archanagrand.Controllers
{
    public class archanadapiController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["akhil"].ConnectionString);


        [HttpGet]
        public List<rooms> getrooms()
        {

            SqlCommand cmd = new SqlCommand("select*From roomstable", con);
            cmd.CommandType = CommandType.Text;
            List<rooms> tr = new List<rooms>();
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    var dd = new rooms();
                    dd.roomnumber = dr["RoomNumber"].ToString();
                    dd.floor = dr["level"].ToString();
                    dd.status = dr["status"].ToString();
                    dd.colour = dr["colour"].ToString();
                    tr.Add(dd);



                }
                dr.Close();
                return tr;
            }
            catch (Exception ex)
            {
                return tr;
            }
            finally
            {
                con.Close();
            }


        }
    }
}

