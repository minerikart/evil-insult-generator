using Evil_Insult_Generator.ViewModels;

namespace Evil_Insult_Generator;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new BaseViewModel();
	}

	
}

