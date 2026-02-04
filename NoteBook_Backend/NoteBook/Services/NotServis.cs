using Microsoft.Data.SqlClient;
using NoteBook.Models;
namespace NoteBook.Services

{
    public class NotServis
    {
        private readonly string baglantiCumlesi;
        public NotServis(IConfiguration configuration)
        {
            baglantiCumlesi = "Server=sql-server;Database=master;User Id=sa;Password=Sifre123!_;TrustServerCertificate=True;";
        }

        // CREATE - EKleme
        public void Create(Notes not) //Notes model adı not, metoddaki geçici ismi
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("INSERT INTO [NOT] (Title,Contents) VALUES(@V2, @V3)", baglanti);

                sorgu.Parameters.AddWithValue("@V2", not.Title);
                sorgu.Parameters.AddWithValue("@V3", not.Contents);

                sorgu.ExecuteNonQuery();
            }
        }

        // READ - Listeleme
        public List<Notes> Listele()
        {
            List<Notes> tumNotlar = new List<Notes>();

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                // Soru: Tüm notları getirecek SQL komutu neydi? "SELECT ..."
                SqlCommand sorgu = new SqlCommand("SELECT Id, Title, Contents FROM [NOT]", baglanti);

                using (SqlDataReader oku = sorgu.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        Notes n = new Notes();
                        n.Id = Convert.ToInt32(oku["Id"]);
                        n.Title = oku["Title"].ToString();
                        n.Contents = oku["Contents"].ToString();

                        tumNotlar.Add(n);
                    }
                }
            }
            return tumNotlar;
        }

        //DELETE - Silme
        public void Sil(int id)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("DELETE FROM [NOT] WHERE Id = @Id", baglanti);
                sorgu.Parameters.AddWithValue("@Id", id);

                sorgu.ExecuteNonQuery();
            }
        }

        //UPDATE - Güncelleme
        public void Guncelle(Notes not)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("UPDATE [NOT] SET Title = @Title, Contents = @Contents WHERE Id = @Id", baglanti);

                sorgu.Parameters.AddWithValue("@Id", not.Id);
                sorgu.Parameters.AddWithValue("@Title", not.Title);
                sorgu.Parameters.AddWithValue("@Contents", not.Contents);

                sorgu.ExecuteNonQuery();
            }
        }
    }
}
