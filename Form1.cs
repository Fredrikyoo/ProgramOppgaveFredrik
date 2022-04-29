using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace ProgramOppgaveFredrik
{
	public partial class Form1 : Form
	{
		List<float> analogReading = new List<float>();
		List<DateTime> timestamp = new List<DateTime>();
		string DataBase = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
		readonly DataTable dt = new DataTable();
		DataRow dr;

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
			ConnectionTimer.Interval = 5000;
			ConnectionTimer.Tick += new EventHandler(ConnectionTimer_Tick);
			dt.Columns.Add("Tag");
			dt.Columns.Add("InstrumentType");
			dt.Columns.Add("AreaCode");
			dt.Columns.Add("DAU_id");
			dt.Columns.Add("Manufacturer_id");
			dt.Columns.Add("LRV");
			dt.Columns.Add("URV");
			dt.Columns.Add("AlarmL");
			dt.Columns.Add("AlarmH");
		}

		void ViewSqlResultInDataGridView(string sqlQuery)
		{
			try
			{
				SqlConnection con = new SqlConnection(DataBase);
				SqlDataAdapter sda;
				DataTable dt;
				con.Open();
				sda = new SqlDataAdapter(sqlQuery, con);
				dt = new DataTable();
				sda.Fill(dt);
				dataGridView1.DataSource = dt;
				con.Close();
			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
			}
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			try //kobler til serialport og starter en klokke som skal sjekke koblingen
			{
				serialPort1.Close();
				serialPort1.PortName = SerialSelect.Text;
				while (serialPort1.IsOpen) ;
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
			string RecivedData = "";
			RecivedData = ((SerialPort)sender).ReadLine(); //leser det motatt fra serielport
			string[] seperateParts = RecivedData.Split(';'); //splitter det opp i deler

			int status;
			if (seperateParts[0] == "readstatus") //hvis vi motar readstatus som første verdi
			{
				if (int.TryParse(seperateParts[1], out status))//leser vi verdien og gir en tilbakemelding i textboksen
				{
					if (status == 0)
					{
						MonitoringStatus.Text = "Monitoring status: ok";
						MonitoringStatusMain.Text = "Monitoring status: ok";
					}
					else if (status == 1)
					{
						MonitoringStatus.Text = "Monitoring status: fail";
						MonitoringStatusMain.Text = "Monitoring status: fail";
					}
					else if (status == 2)
					{
						MonitoringStatus.Text = "Monitoring status: alarmL";
						MonitoringStatusMain.Text = "Monitoring status: alarmL";
					}
					else if (status == 3)
					{
						MonitoringStatus.Text = "Monitoring status: alarmH";
						MonitoringStatusMain.Text = "Monitoring status: alarmH";
					}
					else
					{
						MonitoringStatus.Text = "Monitoring status: Offline";
						MonitoringStatusMain.Text = "Monitoring status: Offline";
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
			{//ser om det er en statusoppdatering
				if (seperateParts[0] == "readstatus") { }
				else if (seperateParts[0] == "readraw" && timer.Enabled) { }
				else if (seperateParts[0] == "readscaled" && timer2.Enabled) { }
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
							System.Windows.Forms.MessageBox.Show("du kan endre configurasjons verdiene nå");
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
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Porten er ikke åpen");
			}
		}

		private void Load_config_click(object sender, EventArgs e)
		{
			dr = dt.NewRow();
			dr["InstrumentType"] = "PT100";
			dr["AreaCode"] = 3123.ToString();
			dr["DAU_id"] = 1.ToString();
			dr["Manufacturer_id"] = 1.ToString();

			string[] AdjustedConfigs = { ConfigName.Text, ConfigLrv.Text, ConfigUrv.Text, ConfigAlarmL.Text, ConfigAlarmH.Text };
			string[] OriginalConfigs = { "C385IT001", "0.0", "500.0", "40", "440" };
			string[] NewConfigs = { "Tag", "LRV", "URV", "AlarmL", "AlarmH" };

			for (int i = 0; i < OriginalConfigs.Length; i++)
			{
				if (AdjustedConfigs[i] == "")//om de redigerte verdiene er tomme legger vi til standarverdiene
				{
					dr[NewConfigs[i]] = OriginalConfigs[i];
				}
				else//ellers legger vi til de redigerte verdiene
				{
					dr[NewConfigs[i]] = AdjustedConfigs[i];
				}
			}
			dt.Rows.Add(dr);
			dataGridView1.DataSource = DataBase;

			string sqlQuery = @"SELECT * FROM Instrument ORDER BY Tag ASC";
			ViewSqlResultInDataGridView(sqlQuery);
		}

		private void SaveConf_Click(object sender, EventArgs e)
		{
			if (saveText.Text == "")//sjekker om filen får et navn
			{
				System.Windows.Forms.MessageBox.Show("Gi filen et navn");
			}
			else
			{
				//lager ny fil med det som står i configurasjons boksen
				StreamWriter outputfile = new StreamWriter(@"C:\tmp\" + saveText.Text + ".ssc");
				outputfile.WriteLine(dataGridView1.Text);
				outputfile.Close();
				System.Windows.Forms.MessageBox.Show("Filen er lagret i mappen tmp");


				string Tag, InstrumentType, AreaCode, DAU_id, Manufacturer_id, sqlQuery, LRV, URV, AlarmL, AlarmH;
				try
				{
					//Oppretter en connection mot databasen med string definert i App.config:
					SqlConnection con = new SqlConnection(DataBase);
					Tag = ConfigName.Text;
					InstrumentType = "PT100";
					AreaCode = 3123.ToString();
					DAU_id = 1.ToString();
					Manufacturer_id = 1.ToString();
					URV = "500.0";
					AlarmL = "40";
					AlarmH = "440";
					string[] AdjustedConfigs = { ConfigName.Text, ConfigLrv.Text, ConfigUrv.Text, ConfigAlarmL.Text, ConfigAlarmH.Text };

					if (AdjustedConfigs[1] == "") { LRV = "0.0"; }
					else { LRV = AdjustedConfigs[1]; }
					if (AdjustedConfigs[2] == "") { URV = "500.0"; }
					else { LRV = AdjustedConfigs[2]; }
					if (AdjustedConfigs[3] == "") { AlarmL = "40"; }
					else { LRV = AdjustedConfigs[3]; }
					if (AdjustedConfigs[4] == "") { AlarmH = "440"; }
					else { LRV = AdjustedConfigs[4]; }

					sqlQuery = String.Concat(@"INSERT INTO Instrument ([Tag], [InstrumentType], [AreaCode], [DAU_id], [Manufacturer_id], [LRV], [URV], [AlarmL], [AlarmH])
						VALUES ('" + Tag + "','" + InstrumentType + "','" + AreaCode + "','" + DAU_id + "','" + Manufacturer_id + "','" + LRV + "','" + URV + "','" + AlarmL + "','" + AlarmH + "')");
					con.Open();
					SqlCommand command = new SqlCommand(sqlQuery, con);
					command.ExecuteNonQuery();
					con.Close();
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
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
			MonitoringStatus.Text = "Monitoring status: Offline";
			MonitoringStatusMain.Text = "Monitoring status: Offline";
			Connection1.Text = "Port: Disconnected";
			Connection1.Text = "Port: Disconnected";
			Connection1.Text = "Port: Disconnected";
		}

		private void password_Click(object sender, EventArgs e)
		{
			if (PasswordBox.Text == "password")//om passordet i passordboksen er riktig
			{
				ConfigName.ReadOnly = false;//redigeringsboksene åpnes for redigering
				ConfigLrv.ReadOnly = false;
				ConfigUrv.ReadOnly = false;
				ConfigAlarmL.ReadOnly = false;
				ConfigAlarmH.ReadOnly = false;
				System.Windows.Forms.MessageBox.Show("login sucsess");
				PasswordBox.Text = "";

			}
			else if (PasswordBox.Text.Length == 0)
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
				if (textBoxCVS.Text.Length == 0)
				{
					System.Windows.Forms.MessageBox.Show("du må starte en reading");
				}
				else
				{
					string Tag, Reading_Type, sqlQuery;
					SqlConnection con = new SqlConnection(DataBase);
					Tag = ConfigName.Text;
					int Status;
					var Time = new List<string>();
					var Val = new List<string>();
					int z = 0;


					string[] stat = MonitoringStatus.Text.Split(':');
					if (stat[1] == " ok") { Status = 0; } 
					else if (stat[1] == " AlarmH") { Status = 3; } 
					else if (stat[1] == " AlarmL") { Status = 2; } 
					else { Status = 1; }
					

					System.Windows.Forms.MessageBox.Show("Lagret filen " + readingNameBox.Text + ".csv");
					StreamWriter recordfile = new StreamWriter(@"C:\tmp\" + readingNameBox.Text + ".csv");//lager ny fil med egetdefinert navn
					char[] splits = new char[] { ';', ',' };
					string[] readValues = textBoxCVS.Text.Split(splits);//splitter opp teksten i fra målingboksen
					recordfile.WriteLine(readValues[0]);//skriver opp om det er scaled eller raw og statusen o filen
					recordfile.WriteLine(readValues[1] + ": ," + readValues[3] + ":");//colonne for tid og colonne for verdi
					if(readValues[0] == "Reading scaled")
					{
						Reading_Type = "Scaled";
					} else
					{
						Reading_Type = "Raw";
					}

					for (int i = 4; i < readValues.Length;)
					{//sriver ut tiden og Mplingverdiene nedover
						int y = i - 2;
						z = z + 1;
						recordfile.WriteLine(readValues[y] + "," + readValues[i]);
						Time.Add(readValues[y]);
						Val.Add(readValues[i]);
						i = i + 4;
					}
					recordfile.Close();


					for (int a = 0; a < z;)
					{
						sqlQuery = String.Concat(@"INSERT INTO Datalog ([Tag], [Status], [Reading_Type], [Timestamp], [Value])
						VALUES ('" + Tag + "','" + Status + "','" + Reading_Type + "','" + Time[a] + "','" + Val[a] + "')");
						con.Open();
						SqlCommand command = new SqlCommand(sqlQuery, con);
						command.ExecuteNonQuery();
						con.Close();
						a = a + 1;
					}

				}
			}
		}

		private void clearReading_Click(object sender, EventArgs e)
		{
			textBoxCVS.Text = "";//fjerner tekst fra reading
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
				serialPort1.WriteLine("readstatus");
			}
			else
			{//om seriealport1 blir stengt
				timer.Stop();
				timer2.Stop();
				ConnectionTimer.Stop();//stopper timerene gir pop_up melding
				System.Windows.Forms.MessageBox.Show("Disconected from Port");
				MonitoringStatus.Text = "Monitoring status: Offline";//endrer tilkoblingsstatus
				MonitoringStatusMain.Text = "Monitoring status: Offline";
				Connection1.Text = "Port: Disconnected";
				Connection1.Text = "Port: Disconnected";
				Connection1.Text = "Port: Disconnected";
			}
		}

		private void Clear_Log_Click(object sender, EventArgs e)
		{
			textBoxResult.Text = "";
		}

		private void Connection1_Click(object sender, EventArgs e)
		{

		}

		private void MonitoringStatus_Click(object sender, EventArgs e)
		{

		}
	}
}

