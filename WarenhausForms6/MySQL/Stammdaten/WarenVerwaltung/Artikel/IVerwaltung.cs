
namespace WarenhausForms6
{
    internal interface IVerwaltung
    {
        List<Artikel> ArtikelListe { get; set; }
        void Download();
        void Submit(List<int> neu, List<int> alt);
        bool SuchenName(string name);
    }
}