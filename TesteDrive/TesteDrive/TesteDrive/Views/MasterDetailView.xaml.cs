using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailView : MasterDetailPage
	{
        private readonly Usuario usuario;
		public MasterDetailView (Usuario usuario)
		{
			InitializeComponent ();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
		}

	}
}