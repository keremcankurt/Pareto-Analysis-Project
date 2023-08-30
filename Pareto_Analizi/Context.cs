using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Pareto_Analizi
{
    public class Context : DbContext
    {

        public Context()
            : base("name=Context")
        {
        }
        public DbSet<Malzeme> malzemeler { get; set; }

    }

    public class Malzeme
    {
        [Key]
        public int Id { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdý { get; set; }
        public int YillikSatis { get; set; }
        public int BirimFiyat { get; set; }
        public int MinStok { get; set; }
        public int TedarikSuresi { get; set; }
    }
}