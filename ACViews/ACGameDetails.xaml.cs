using AntonellaCortes_PROGRESOFINAL.ACModels;

namespace AntonellaCortes_PROGRESOFINAL.ACViews;

public partial class ACGameDetails : ContentPage
{
    public ACGameDetails()
    {
        InitializeComponent();
        LoadData();
    }

    protected override void OnAppearing()
    {
        LoadData();
    }

    public void LoadData()
    {
        List<ACGame> game = App.GameRepo.GetAllGames();
        ACgameList.ItemsSource = game; //check
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ACGenerateGame));
    }

    private async void gamesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var game = (ACModels.ACGame)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Escoja:", "Cancelar", null, "Editar", "Borrar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(ACGenerateGame)}?{nameof(ACGenerateGame.ItemId)}={game.ID}");
            }
            else if (action == "Borrar")
            {
                App.GameRepo.DeleteGame(game);
                LoadData();
            }
            else
            {
                LoadData();
            }

            ACgameList.SelectedItem = null;
        }
    }
}