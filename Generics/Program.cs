// Generic : bir tane class yazıp birçok işi yapabilmek üzerine dayandırılmış bir yapı

using System.Text.Json;

public class Program
{



    public static void Main()
    {
        #region Örnek 1
        // CRUD Operation  varlıkların %90 ında bı operasyonlar aynıdır.


        //Çay ürün olsaydı.Çaybardağı yerinde ürünIşlemleri.Operasyonlar aynı Doldur - Boşalt
        //Cay cay = new Cay();
        //cay.Adi = "doğuş Filiz Çayı";
        //CayBardak cayBardak = new CayBardak();
        //cayBardak.Doldur(cay);
        //var x = cayBardak.Bosatl();

        //// Kahve Cari olsaydı. Kahvefincanı yerinde cariIslemleri  Operasyonlar aynı Doldur-Boşalt
        //Kahve kahve = new Kahve();
        //kahve.Adi = "Arabica";
        //KahveFincani kahveFincani = new KahveFincani();
        //kahveFincani.Doldur(kahve);
        //var y = kahveFincani.Bosatl();

        //Bardak<Cay> cayBardagi = new Bardak<Cay>();
        //Bardak<Kahve> kahveBardagi = new Bardak<Kahve>();
        //cayBardagi.Doldur();
        //kahveBardagi.Doldur(); 
        #endregion

        MyJsonSerializer serializer = new MyJsonSerializer();
        var data = serializer.Deserialize<string>("");
        var hasta = serializer.Deserialize<Hasta>("");
        var urun = serializer.Deserialize<Urun>("");

    }
}

public class MyJsonSerializer
{
    // bana bir tane string json ver ben onu sana sen  hangi T den istiyosan dönüştürüp vereyim
    public T Deserialize<T>(string json)
    {
       return JsonSerializer.Deserialize<T>(json);    
    }
}

public class Hasta
{
    public string Adi { get; set; }

    public string Soyadi { get; set; }

    public byte Yasi { get; set; }
}

public class Urun
{
    public string urunAdi { get; set; }

    public decimal UrunFiyat { get; set; }

    public int StokAdedi { get; set; }
}



#region Örnek 2
// Bardak T sınıfı için T nin ISivi den implemente oması zorunludur
public class Bardak<T> where T : Sivi   //ISivi 
{
    private T sivi;


    public void Doldur(T sivi)
    {
        this.sivi = sivi;
        Console.WriteLine($"{sivi.Adi} dolduruldu");
    }

    public T Bosatl()
    {
        Console.WriteLine($"{sivi.Adi} boşaltıldı");
        return sivi;
    }
}


// doldur boşalt yani iş yapan sınıf. Önceden dosyaişlemleri sınıfı gibi.
// içine string bir değer alıyordu ve bir dosyaya yazıyordu. Yada dosya yolundan datayı okuyodu string olarak dönüyodu
// burdada içerde çay diye değişkeni var. Doldur metodu dışarıdan aldığı değeri alıyor çay değişkeninin içine atıyor
// Boşalt metoduda ordaki değeri return ediyor geriye

//public class CayBardak
//{
//    private Cay sivi;


//    public void Doldur(Cay sivi)
//    {
//        this.sivi = sivi;
//        Console.WriteLine($"{sivi.Adi} dolduruldu");
//    }

//    public Cay Bosatl()
//    {
//        Console.WriteLine($"{sivi.Adi} boşaltıldı");
//        return sivi;
//    }
//}

//public class KahveFincani
//{
//    private Kahve sivi;


//    public void Doldur(Kahve sivi)
//    {
//        this.sivi = sivi;
//        Console.WriteLine($"{sivi.Adi} dolduruldu");
//    }

//    public Kahve Bosatl()
//    {
//        Console.WriteLine($"{sivi.Adi} boşaltıldı");
//        return sivi;
//    }
//}


//public interface ISivi
//{
//     string Adi { get; set; }
//}

public class Sivi
{
    public string Adi { get; set; }
}

public class Cay : Sivi
{
    //public string Adi { get; set; }
}

public class Kahve : Sivi
{
    //public string Adi { get; set; }
} 
#endregion