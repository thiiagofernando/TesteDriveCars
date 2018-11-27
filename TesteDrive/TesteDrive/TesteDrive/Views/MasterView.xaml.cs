using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using TesteDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : ContentPage
	{
        public MasterViewModel viewModel { get; set; }
        public MasterView (Usuario usuario)
		{
			InitializeComponent ();
            this.viewModel = new MasterViewModel(usuario);
            this.BindingContext = this.viewModel;
		}
	}
}