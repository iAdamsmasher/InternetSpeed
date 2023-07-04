using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetSpeedTest
{
    class NetworkUtils
    {
        FrmTest frmT = FrmTest.getInstance();
        public void getUpLinkDownLink()
        {

            if (!NetworkInterface.GetIsNetworkAvailable())
                return;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            DateTime today = DateTime.Now; //log 
            string filepath = @"C:\temp\NetworkMonitorLog.csv";

            string time = today.ToString();

            today = DateTime.Now;
            time = today.ToString();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.GetIPv4Statistics().BytesSent.Equals(0))
                {
                    //do nothing
                }
                else
                {
                    var nics = NetworkInterface.GetAllNetworkInterfaces();
                    // Select desired NIC
                    var reads = Enumerable.Empty<double>();
                    var sw = new Stopwatch();
                    var lastBr = ni.GetIPv4Statistics().BytesReceived;


                    var nicss = NetworkInterface.GetAllNetworkInterfaces();
                    // Select desired NIC
                    var readss = Enumerable.Empty<double>();
                    var sww = new Stopwatch();
                    var lastBrr = ni.GetIPv4Statistics().BytesSent;


                    for (var i = 0; i < 1000; i++)
                    {

                        sw.Restart();
                        Thread.Sleep(100);
                        var elapsed = sw.Elapsed.TotalSeconds;
                        var br = ni.GetIPv4Statistics().BytesReceived;

                        var local = (br - lastBr) / elapsed;
                        lastBr = br;

                        sww.Restart();
                        Thread.Sleep(100);
                        var elapsedd = sw.Elapsed.TotalSeconds;
                        var brr = ni.GetIPv4Statistics().BytesReceived;

                        var locall = (brr - lastBrr) / elapsedd;
                        lastBrr = brr;

                        // Keep last 20, ~2 seconds
                        reads = new[] { local }.Concat(reads).Take(20);
                        readss = new[] { locall }.Concat(readss).Take(20);

                        if (i % 10 == 0)
                        { // ~1 second
                            var bSec = reads.Sum() / reads.Count();
                            var kbs = ((bSec * 8) / 1024 );
                            var bSecc = readss.Sum() / readss.Count();
                            var kbss = ((bSecc * 8) / 1024 );

                            frmT.textBoxDown.Text = kbs.ToString("F2") + " Kbs";
                            frmT.textBoxUpload.Text = kbss.ToString("F2") + " Kbs";
                            GetPing();
                            Application.DoEvents();
                        }
                    }


                }

            }
        }
        public void GetPing()
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = "10.114.97.20";
            r = p.Send(s);

            if (r.Status == IPStatus.Success)
            {
                frmT.textBoxPing.Text =  r.RoundtripTime.ToString() + " ms";
            }
        }
    }
}
