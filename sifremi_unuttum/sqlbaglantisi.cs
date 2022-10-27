using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using.System.Data.SqlClient;
using System.Data.SqlClient;

namespace sifremi_unuttum
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KPNR185M\\SQLEXPRESS;Initial Catalog=Ornek;Integrated Security=True");
            baglanti.Open();
            return baglanti;


 }
    }
}
