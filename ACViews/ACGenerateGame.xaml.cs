using AntonellaCortes_PROGRESOFINAL.ACModels;
using AntonellaCortes_PROGRESOFINAL.ACAPI;
using System.Net;
using Newtonsoft.Json;

namespace AntonellaCortes_PROGRESOFINAL.ACViews;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ACGenerateGame : ContentPage
{
    ACGame Item = new ACGame();
    bool _flag;
    public ACGenerateGame()
    {
        InitializeComponent();
        LoadGame();
    }

    private void OnGenerateClicked(object sender, EventArgs e)
    {
        WebRequest request = WebRequest.Create("https://www.freetogame.com/api/games");
        //request.Headers.Add("", "YOUR API KEY HERE");
        WebResponse response = request.GetResponse();
        //var client = new HttpClient();

        using (Stream dataStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            responseFromServer = responseFromServer.Trim();
            var resultado = JsonConvert.DeserializeObject<List<Rootobject>>(responseFromServer); // nombre de la clase q viene de la api - og json - objeto
            // retorna lista

            // generar num rec random
            Random rnd = new Random();
            int numRnd = rnd.Next(0, 200);
            int numLista = numRnd;

            JuegoRandom.Text = resultado[numLista].title;
            desc.Text = resultado[numLista].short_description;
            genero.Text = resultado[numLista].genre;
            platforma.Text = resultado[numLista].platform;
            pub.Text = resultado[numLista].publisher;
            dev.Text = resultado[numLista].developer;
            estreno.Text = resultado[numLista].release_date;


        }
        response.Close();
    }

    public int ItemId
    {
        set { LoadGame(value); }
    }

    public void LoadGame(int value = -1)
    {
        if (value > -1)
        {
            Item = App.GameRepo.GetGame(value);
            SaveBtn.Text = "Editar";

        }

        BindingContext = Item;

    }

    private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }

    private void OnSavedClicked(object sender, EventArgs e)
    {
        Item.title = JuegoRandom.Text;
        Item.short_description = desc.Text;
        Item.genre = genero.Text;
        Item.platform = platforma.Text;
        Item.publisher = pub.Text;
        Item.developer = dev.Text;
        Item.release_date = estreno.Text;

        if (SaveBtn.Text == "Editar")
        {
            App.GameRepo.UpadateGame(Item);
        }
        else
        {
            App.GameRepo.AddNewGame(Item);
        }
        Shell.Current.GoToAsync("..");
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

}