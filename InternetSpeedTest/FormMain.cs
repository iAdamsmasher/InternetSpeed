using System;
using System.Net.NetworkInformation;

using System.Windows.Forms;

namespace InternetSpeedTest
{
	public partial class FrmMain : Form
	{
		FrmTest frmT = new FrmTest();
		NetworkUtils rede = new NetworkUtils();

		public FrmMain()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			frmT.Show();
			this.Hide();

			rede.getUpLinkDownLink();
			Application.DoEvents();

		}
		
		

	}
}
