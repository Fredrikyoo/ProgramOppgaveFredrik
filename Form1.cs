using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace ProgramOppgaveFredrik
{
	public partial class Form1 : Form
	{
		List<float> analogReading = new List<float>();
		List<DateTime> timestamp = new List<DateTime>();
		public Form1()
		{
			InitializeComponent();
			SerialSelect.Items.AddRange(SerialPort.GetPortNames());//lager en liste med utvalgte bit rater med 9600 som standar
			SerialSelect.Text = "--Select--";
			string[] bitRate = new string[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
			BitRateSelect.Items.AddRange(bitRate);
			BitRateSelect.SelectedIndex = BitRateSelect.Items.IndexOf("9600");
			serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataRecivedHandeler);
			timer.Interval = 5000; //klokker for måling og å teste connection
			timer.Tick += new EventHandler(timer_Tick);
			timer2.Interval = 5000;
			timer2.Tick += new EventHandler(timer2_Tick);
			ConnectionTimer.Interval = 2000;
			ConnectionTimer.Tick += new EventHandler(ConnectionTimer_Tick);
			MonitorStatusTimer.Interval = 5000;
			MonitorStatusTimer.Tick += new EventHandler(MonitorStatusTimer_Tick);
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			try //kobler til serialport og starter en klokke som skal sjekke koblingen
			{
				serialPort1.Close();
				serialPort1.PortName = SerialSelect.Text;
				while (serialPort1.IsOpen);
				serialPort1.Open();
				System.Windows.Forms.MessageBox.Show("tilkoblet " + SerialSelect.Text);
				Connection1.Text = "Port: Connected";
				Connection2.Text = "Port: Connected";
				Connection3.Text = "Port: Connected";
				ConnectionTimer.Start();
			} 
			catch (Exception ex) //gir feilmelding om koblingen ikke gikk
			{
				serialPort1.Close();
				if (ex is ArgumentException)
				{
					System.Windows.Forms.MessageBox.Show("ikke gyldig port valgt!");
				}
			}
		}
		void DataRecivedHandeler(object sender, SerialDataReceivedEventArgs e)
		{
			string RecivedData = ((SerialPort)sender).ReadLine(); //leser det motatt fra serielport
			string[] seperateParts = RecivedData.Split(';'); //splitter det opp i deler

			int status;
			if (seperateParts[0] == "readstatus") //hvis vi motar readstatus som første verdi
			{
				if (int.TryParse(seperateParts[1], out status))//leser vi verdien og gir en tilbakemelding i textboksen
				{
					if (status == 0)
					{
						MonitoringStatus.Text = "Monitoring status: ok";
					}
					else if (status == 1)
					{
						MonitoringStatus.Text = "Monitoring status: fail";
					}
					else if (status == 2)
					{
						MonitoringStatus.Text = "Monitoring status: alarmL";
					}
					else if (status == 3)
					{
						MonitoringStatus.Text = "Monitoring status: alarmH";
					}
					else
					{
						MonitoringStatus.Text = "Monitoring status: Offline";
					}
				}
			}
		

			float iVab;
			if (seperateParts[0] == "readraw" || seperateParts[0] == "readscaled") //hvis vi motar readraw eller readscaled
			{
				if (float.TryParse(seperateParts[1], out iVab))
				{
					analogReading.Add(iVab);//legger vi andre verdien i y listen
					timestamp.Add(DateTime.Now);//og tidsverdien i x listen
					chart.Series["Vba"].Points.DataBindXY(timestamp, analogReading);//og plotter grafen med x og y verdiene
					chart.Invalidate();
					textBoxCVS.AppendText("tid; " + DateTime.Now + ", Verdi; " + iVab + "; \r\n");//og skriver verdiene ut i tekstboks
				}
			}

			int passord;//lager en numerisk verdi for passord
			textBoxResult.Invoke((MethodInvoker)delegate
			{//ser om det er en jevlig statusoppdatering
				if (seperateParts[0] == "readstatus" && MonitorStatusTimer.Enabled){}
				else if(seperateParts[0] == "readraw" && timer.Enabled) { }
				else if(seperateParts[0] == "readscaled" && timer2.Enabled) { }
				else
				{//hvis det ikke er det legges data'en til i resultboksen 
					textBoxResult.AppendText("recived " + RecivedData + "\r\n"); 
				}

				if (seperateParts[0] == "writeconf") //hvis første motatt verdi er writeconf
				{						
					if (int.TryParse(seperateParts[1], out passord))//blir den andre verdien tilegnet passordet
					{
						if (passord == 0)//feil passord
						{
							System.Windows.Forms.MessageBox.Show("feil passord");							
						}
						if (passord == 1)//riktig passord gjør at du kan endre på konfigurasjonen
						{
							System.Windows.Forms.MessageBox.Show("du kan nå endre configverdiene under fanen Config change ");
							ConfigName.ReadOnly = false;
							ConfigLrv.ReadOnly = false;
							ConfigUrv.ReadOnly = false;
							ConfigAlarmL.ReadOnly = false;
							ConfigAlarmH.ReadOnly = false;
						}
					}
					else
					{
						System.Windows.Forms.MessageBox.Show("error");
					}
				}
			});
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen)
			{
				serialPort1.WriteLine(textBoxSend.Text);//sender det som er skrevet i tekstboksen til serialport
				textBoxResult.AppendText("sendt " + textBoxSend.Text + "\r\n");
				textBoxSend = null;
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Porten er ikke åpen");
			}
		}

		private void Read_config_click(object sender, EventArgs e)
		{
			ConfigBoxSplit.Text = "";//sletter tideligere verdier
			if (serialPort1.IsOpen)
			{
				serialPort1.WriteLine("readconf");//sender readconf til serialport
			}
			else
			{
				ConfigBoxSplit.AppendText("recived readconf: \r\n");
				string[] AdjustedConfigs = {ConfigName.Text, ConfigLrv.Text, ConfigUrv.Text, ConfigAlarmL.Text, ConfigAlarmH.Text };
				string[] OriginalConfigs = { "C385IT001", "0.0", "500.0", "40", "440" };
				for (int i = 0; i < OriginalConfigs.Length; i++)
				{
					if (AdjustedConfigs[i] == "")//om de redigerte verdiene er tomme legger vi til standarverdiene
					{
						ConfigBoxSplit.AppendText(OriginalConfigs[i] + " \r\n");
					}
					else//ellers legger vi til de redigerte verdiene
					{
						ConfigBoxSplit.AppendText(AdjustedConfigs[i] + " \r\n");
					}
				}
			}
		}

		private void SaveConf_Click(object sender, EventArgs e)
		{
			if(saveText.Text == "")//sjekker om filen får et navn
			{
				System.Windows.Forms.MessageBox.Show("Gi filen et navn");
			}
			else
			{
				if (ConfigBoxSplit.Text == "")//sjekker om det er verdier i configboksen
				{
					System.Windows.Forms.MessageBox.Show("Du burde laste til verdier i configboksen");
				}
				else
				{//lager ny fil med det som står i configurasjons boksen
					StreamWriter outputfile = new StreamWriter(@"C:\tmp\"+ saveText.Text+".ssc");
					outputfile.WriteLine(ConfigBoxSplit.Text);
					outputfile.Close();
					System.Windows.Forms.MessageBox.Show("Fil lagret i mappen tmp");
				}
			}
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}

		private void buttonDisconect_Click(object sender, EventArgs e)
		{
			serialPort1.Close();//stenger serialporten
			System.Windows.Forms.MessageBox.Show("Porten er nå stengt");
			ConnectionTimer.Stop();//stopper testingen av koblingstilstanden intill videre
		}

		private void password_Click(object sender, EventArgs e)
		{
			if(PasswordBox.Text == "password")//om passordet i passordboksen er riktig
			{
				ConfigName.ReadOnly = false;//redigeringsboksene åpnes for redigering
				ConfigLrv.ReadOnly = false;
				ConfigUrv.ReadOnly = false;
				ConfigAlarmL.ReadOnly = false;
				ConfigAlarmH.ReadOnly = false;
				System.Windows.Forms.MessageBox.Show("login sucsess");

			}
			else if(PasswordBox.Text.Length == 0)
			{
				System.Windows.Forms.MessageBox.Show("Du må skrive inn passordet"); 
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Feil passord");
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			serialPort1.WriteLine("readraw");//sender readraw til ardruino hvert femte sekund timer1 kjører
		}

		private void StartTimer_Click(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen)
			{
				serialPort1.WriteLine("readstatus"); //spør ardruino om status
				textBoxCVS.Text = "Reading Raw; \r\n";
				if (timer2.Enabled)//stopper timer 2 hvis den kjører
				{
					timer2.Stop();
					System.Windows.Forms.MessageBox.Show("readscaled stoppet");
				}
				timer.Start();//starter timer 1
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Porten er ikke åpen");
			}
		}

		private void stopTimer_Click(object sender, EventArgs e)
		{
			timer.Stop(); //stopper begger timere
			timer2.Stop();
			System.Windows.Forms.MessageBox.Show("Monitoring stoppet");
		}

		private void CvsSave(object sender, EventArgs e)
		{
			if (timer.Enabled || timer2.Enabled)//stopper begge timere
			{
				timer.Stop();
				timer2.Stop();
				System.Windows.Forms.MessageBox.Show("Monitoring stoppet");
			}
			if (readingNameBox.Text.Length == 0) //krever navn på filen
			{
				System.Windows.Forms.MessageBox.Show("Gi filen et navn før du lagrer");
			}
			else 
			{
				if(textBoxCVS.Text.Length == 0)
				{
					System.Windows.Forms.MessageBox.Show("trykk på start reading");
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("Lagret filen " + readingNameBox.Text + ".csv");
					StreamWriter recordfile = new StreamWriter(@"C:\tmp\" + readingNameBox.Text + ".csv");//lager ny fil med egetdefinert navn
					char[] splits = new char[] { ';', ',' };
					string[] readValues = textBoxCVS.Text.Split(splits);//splitter opp teksten i fra målingboksen
					recordfile.WriteLine(readValues[0]);//skriver opp om det er scaled eller raw og statusen o filen
					recordfile.WriteLine(readValues[1]+": ,"+readValues[3]+":");//colonne for tid og colonne for verdi
					for (int i = 4; i < readValues.Length;)
					{//sriver ut tiden og Mplingverdiene nedover
						int y = i - 2;
						recordfile.WriteLine(readValues[y]+","+readValues[i]);
						i = i + 4;
					}
					recordfile.Close();
				}
			}
		}

		private void clearReading_Click(object sender, EventArgs e)
		{
			textBoxCVS.Text = "";//fjerner tekst fra reading
		}

		private void UplaodButton_click(object sender, EventArgs e)
		{
			ConfigBoxSplit.Text = "File uploaded: "+UploadBox.Text;
			StreamReader inputfile = new StreamReader(@"C:\tmp\" + UploadBox.Text + ".ssc");//finner ønsket fil "inputfil"
			string inputread = inputfile.ReadToEnd();
			string[] seperateRead = inputread.Split(' ');//splitter filen opp
			ConfigName.Text = seperateRead[2];//setter verdiene i redigeringsboksen
			ConfigLrv.Text = seperateRead[3];
			ConfigUrv.Text = seperateRead[4];
			ConfigAlarmL.Text = seperateRead[5];
			ConfigAlarmH.Text = seperateRead[6];
			for(int i = 2;i < seperateRead.Length; i++)//leger verdiene til i configurasjonsboksen
			{
				ConfigBoxSplit.AppendText(seperateRead[i]);
			}
			inputfile.Close();
		}

		private void config_clear_Click(object sender, EventArgs e)
		{
			ConfigBoxSplit.Text = "";//fjerner tekst
			ConfigName.Text = "";
			ConfigLrv.Text = "";
			ConfigUrv.Text = "";
			ConfigAlarmL.Text = "";
			ConfigAlarmH.Text = "";
		}

		private void startTimerScaled_Click(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen)
			{
				serialPort1.WriteLine("readstatus"); //spør ardruino om status
				textBoxCVS.Text = "Reading scaled; \r\n";
				if (timer.Enabled)
				{
					timer.Stop();//stopper timer 1 hvis den kjører
					System.Windows.Forms.MessageBox.Show("readraw stoppet");
				}
				timer2.Start();//starter timer 2
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Porten er ikke åpen");
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			serialPort1.WriteLine("readscaled"); //når timer 2 kjører leses readscaled av
		}

		private void ConnectionTimer_Tick(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen)//tilkoblingsverdien sier connection så lenger serielport er koblet til
			{
				Connection1.Text = "Port: Conneted";
				Connection2.Text = "Port: Conneted";
				Connection3.Text = "Port: Conneted";
			}
			else
			{
				ConnectionTimer.Stop();//stopper timeren gir pop_up melding og endrer tilkoblingsstatus
				System.Windows.Forms.MessageBox.Show("Disconected from Port");
				Connection1.Text = "Port: Disconnected";
				Connection1.Text = "Port: Disconnected";
				Connection1.Text = "Port: Disconnected";
			}
		}

		private void Clear_Log_Click(object sender, EventArgs e)
		{
			textBoxResult.Text = "";
		}

		private void readStatus_click(object sender, EventArgs e)
		{
			MonitorStatusTimer.Start();
		}

		private void MonitorStatusTimer_Tick(object sender, EventArgs e)
		{
			serialPort1.WriteLine("readstatus");
		}
	}
}

