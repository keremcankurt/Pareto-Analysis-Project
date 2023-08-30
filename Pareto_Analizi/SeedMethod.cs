using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pareto_Analizi
{
    public class SeedMethod : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var malzemes = new List<Malzeme>()
            {
                new Malzeme { MalzemeKodu="HM001",MalzemeAdı="Malzeme1",YillikSatis=10000,BirimFiyat=60,MinStok=200,TedarikSuresi=3},
                new Malzeme { MalzemeKodu="HM008",MalzemeAdı="Malzeme2",YillikSatis=15000,BirimFiyat=32,MinStok=230,TedarikSuresi=1 },
                new Malzeme { MalzemeKodu="HM012",MalzemeAdı="Malzeme3",YillikSatis=3000,BirimFiyat=500,MinStok=50,TedarikSuresi=12 },
                new Malzeme { MalzemeKodu="HM010",MalzemeAdı="Malzeme4",YillikSatis=100000,BirimFiyat=14,MinStok=500,TedarikSuresi=2 }

            };
            malzemes.ForEach(s => context.malzemeler.Add(s));
            context.SaveChanges();
        }
    }
}
