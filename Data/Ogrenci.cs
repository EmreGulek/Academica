using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academica.Data
{
    
public class Ogrenci
{
    [DisplayName("Öğrenci Numarası")]
    [Key]
    public int? Id { get; set; }
    [DisplayName("Öğrenci Adı")]
    public string? OgrenciAd { get; set; }
    public string? Eposta { get; set; }
    public string? Telefon { get; set; }
    
}
}