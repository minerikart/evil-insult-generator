using CommunityToolkit.Mvvm.ComponentModel;
using Evil_Insult_Generator.Services;
using Evil_Insult_Generator.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Evil_Insult_Generator.ViewModels
{
    public partial class BaseViewModel : TemplateViewModel
    {
        //public ObservableCollection<Root> Insults { get; } = new();
        public InsultGeneratorService InsultsGenerator { get; } = new();

        public BaseViewModel()
        {

        }

        [ObservableProperty]
        Root insults;

        [RelayCommand]
        async Task ReceiveInsultAsync() 
        {
            try 
            {
                var insultsGen = await InsultsGenerator.GetInsultAsync();

                if (insultsGen != null)
                {
                    Insults = insultsGen;
                }
            }

            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
