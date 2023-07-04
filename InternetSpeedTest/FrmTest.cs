using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetSpeedTest
{
	public partial class FrmTest : Form
	{
		private static FrmTest INSTANCE = null;
		public FrmTest()
		{
			InitializeComponent();
			INSTANCE = this;
		}
		public static FrmTest getInstance()
		{
			if (INSTANCE == null)
				INSTANCE = new FrmTest();

			return INSTANCE;
		}
		
	}
}
