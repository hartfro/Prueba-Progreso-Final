using AntonellaCortes_PROGRESOFINAL.ACViewModels;
using AntonellaCortes_PROGRESOFINAL.Models;
using AntonellaCortes_PROGRESOFINAL.API;
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
        //request.Headers.Add("X-TheySaidSo-Api-Secret", "YOUR API KEY HERE");
        WebResponse response = request.GetResponse();
        //var client = new HttpClient();

        using (Stream dataStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            // este trim solo quita basura como dobles espacios y así
            responseFromServer = responseFromServer.Trim();
            var resultado = JsonConvert.DeserializeObject<List<Rootobject>>(responseFromServer); // nombre de la clase q viene de la api - og json - objeto
            // retorna lista

            // generar num rec random
            Random rnd = new Random();
            int numRnd = rnd.Next(0, 200);

            JuegoRandom.Text = resultado[numRnd].title;

            // variables
            Item.title = resultado[numRnd].title;
            Item.short_description = resultado[numRnd].short_description;
            Item.genre = resultado[numRnd].genre;
            Item.platform = resultado[numRnd].platform;
            Item.publisher = resultado[numRnd].publisher;
            Item.developer = resultado[numRnd].developer;
            Item.release_date = resultado[numRnd].release_date;

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
            //SaveButton.Text = "Editar";

        }

        BindingContext = Item;

    }

    private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }

    private void OnSavedClicked(object sender, EventArgs e)
    {

        /*Item.Date = DateTime.ParseExact(Fecha.Text, "dd/MM/yyyy HH:mm:ss", null);
        if (SaveButton.Text == "Editar")
        {
            App.GameRepo.UpadateGame(Item);
        }
        else
        {
            App.GameRepo.AddNewGame(Item);
        }
        Shell.Current.GoToAsync("..");*/
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

}