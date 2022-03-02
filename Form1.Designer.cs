namespace ProgramOppgaveFredrik
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.Serial = new System.Windows.Forms.TabControl();
			this.PortSelect = new System.Windows.Forms.TabPage();
			this.Clear_Log = new System.Windows.Forms.Button();
			this.Connection1 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.textBoxSend = new System.Windows.Forms.TextBox();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonDisconect = new System.Windows.Forms.Button();
			this.BitRateSelect = new System.Windows.Forms.ComboBox();
			this.SerialSelect = new System.Windows.Forms.ComboBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.Connection2 = new System.Windows.Forms.Label();
			this.config_clear = new System.Windows.Forms.Button();
			this.UploadBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.saveText = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.Upload_Button = new System.Windows.Forms.Button();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.PasswordBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ConfigAlarmH = new System.Windows.Forms.TextBox();
			this.SaveConf = new System.Windows.Forms.Button();
			this.LoadConf = new System.Windows.Forms.Button();
			this.ConfigBoxSplit = new System.Windows.Forms.TextBox();
			this.ConfigAlarmL = new System.Windows.Forms.TextBox();
			this.ConfigUrv = new System.Windows.Forms.TextBox();
			this.ConfigLrv = new System.Windows.Forms.TextBox();
			this.ConfigName = new System.Windows.Forms.TextBox();
			this.monitor = new System.Windows.Forms.TabPage();
			this.MonitoringStatus = new System.Windows.Forms.Label();
			this.Connection3 = new System.Windows.Forms.Label();
			this.startTimerScaled = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.readingNameBox = new System.Windows.Forms.TextBox();
			this.clear = new System.Windows.Forms.Button();
			this.textBoxCVS = new System.Windows.Forms.TextBox();
			this.cvsSave = new System.Windows.Forms.Button();
			this.stopTimer = new System.Windows.Forms.Button();
			this.startTimerRaw = new System.Windows.Forms.Button();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.ConnectionTimer = new System.Windows.Forms.Timer(this.components);
			this.MonitorStatusTimer = new System.Windows.Forms.Timer(this.components);
			this.Serial.SuspendLayout();
			this.PortSelect.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.monitor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.SuspendLayout();
			// 
			// Serial
			// 
			this.Serial.Controls.Add(this.PortSelect);
			this.Serial.Controls.Add(this.tabPage2);
			this.Serial.Controls.Add(this.monitor);
			this.Serial.Location = new System.Drawing.Point(13, 12);
			this.Serial.Name = "Serial";
			this.Serial.SelectedIndex = 0;
			this.Serial.Size = new System.Drawing.Size(1115, 553);
			this.Serial.TabIndex = 0;
			// 
			// PortSelect
			// 
			this.PortSelect.Controls.Add(this.Clear_Log);
			this.PortSelect.Controls.Add(this.Connection1);
			this.PortSelect.Controls.Add(this.label13);
			this.PortSelect.Controls.Add(this.textBoxSend);
			this.PortSelect.Controls.Add(this.textBoxResult);
			this.PortSelect.Controls.Add(this.buttonSend);
			this.PortSelect.Controls.Add(this.label2);
			this.PortSelect.Controls.Add(this.label1);
			this.PortSelect.Controls.Add(this.buttonDisconect);
			this.PortSelect.Controls.Add(this.BitRateSelect);
			this.PortSelect.Controls.Add(this.SerialSelect);
			this.PortSelect.Controls.Add(this.buttonConnect);
			this.PortSelect.Location = new System.Drawing.Point(4, 29);
			this.PortSelect.Name = "PortSelect";
			this.PortSelect.Padding = new System.Windows.Forms.Padding(3);
			this.PortSelect.Size = new System.Drawing.Size(1107, 520);
			this.PortSelect.TabIndex = 0;
			this.PortSelect.Text = "Main";
			this.PortSelect.UseVisualStyleBackColor = true;
			// 
			// Clear_Log
			// 
			this.Clear_Log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Clear_Log.Location = new System.Drawing.Point(316, 283);
			this.Clear_Log.Name = "Clear_Log";
			this.Clear_Log.Size = new System.Drawing.Size(159, 41);
			this.Clear_Log.TabIndex = 11;
			this.Clear_Log.Text = "Clear Log";
			this.Clear_Log.UseVisualStyleBackColor = true;
			this.Clear_Log.Click += new System.EventHandler(this.Clear_Log_Click);
			// 
			// Connection1
			// 
			this.Connection1.AutoSize = true;
			this.Connection1.Location = new System.Drawing.Point(957, 3);
			this.Connection1.Name = "Connection1";
			this.Connection1.Size = new System.Drawing.Size(144, 20);
			this.Connection1.TabIndex = 10;
			this.Connection1.Text = "Port: Disconnected";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(339, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(114, 20);
			this.label13.TabIndex = 9;
			this.label13.Text = "inputcommand";
			// 
			// textBoxSend
			// 
			this.textBoxSend.Location = new System.Drawing.Point(316, 41);
			this.textBoxSend.Name = "textBoxSend";
			this.textBoxSend.Size = new System.Drawing.Size(159, 26);
			this.textBoxSend.TabIndex = 8;
			// 
			// textBoxResult
			// 
			this.textBoxResult.Location = new System.Drawing.Point(548, 39);
			this.textBoxResult.Multiline = true;
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.ReadOnly = true;
			this.textBoxResult.Size = new System.Drawing.Size(351, 234);
			this.textBoxResult.TabIndex = 7;
			// 
			// buttonSend
			// 
			this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSend.Location = new System.Drawing.Point(316, 226);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(159, 40);
			this.buttonSend.TabIndex = 6;
			this.buttonSend.Text = "Send";
			this.buttonSend.UseVisualStyleBackColor = true;
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 134);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "BitRate";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "ComPort";
			// 
			// buttonDisconect
			// 
			this.buttonDisconect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDisconect.Location = new System.Drawing.Point(99, 283);
			this.buttonDisconect.Name = "buttonDisconect";
			this.buttonDisconect.Size = new System.Drawing.Size(159, 41);
			this.buttonDisconect.TabIndex = 3;
			this.buttonDisconect.Text = "Disconnect";
			this.buttonDisconect.UseVisualStyleBackColor = true;
			this.buttonDisconect.Click += new System.EventHandler(this.buttonDisconect_Click);
			// 
			// BitRateSelect
			// 
			this.BitRateSelect.FormattingEnabled = true;
			this.BitRateSelect.Location = new System.Drawing.Point(99, 131);
			this.BitRateSelect.Name = "BitRateSelect";
			this.BitRateSelect.Size = new System.Drawing.Size(159, 28);
			this.BitRateSelect.TabIndex = 2;
			// 
			// SerialSelect
			// 
			this.SerialSelect.FormattingEnabled = true;
			this.SerialSelect.Location = new System.Drawing.Point(99, 39);
			this.SerialSelect.Name = "SerialSelect";
			this.SerialSelect.Size = new System.Drawing.Size(159, 28);
			this.SerialSelect.TabIndex = 1;
			// 
			// buttonConnect
			// 
			this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonConnect.Location = new System.Drawing.Point(99, 225);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(159, 41);
			this.buttonConnect.TabIndex = 0;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.Connection2);
			this.tabPage2.Controls.Add(this.config_clear);
			this.tabPage2.Controls.Add(this.UploadBox);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.saveText);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.Upload_Button);
			this.tabPage2.Controls.Add(this.buttonLogin);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.PasswordBox);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.ConfigAlarmH);
			this.tabPage2.Controls.Add(this.SaveConf);
			this.tabPage2.Controls.Add(this.LoadConf);
			this.tabPage2.Controls.Add(this.ConfigBoxSplit);
			this.tabPage2.Controls.Add(this.ConfigAlarmL);
			this.tabPage2.Controls.Add(this.ConfigUrv);
			this.tabPage2.Controls.Add(this.ConfigLrv);
			this.tabPage2.Controls.Add(this.ConfigName);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1107, 520);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Configuration";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// Connection2
			// 
			this.Connection2.AutoSize = true;
			this.Connection2.Location = new System.Drawing.Point(957, 3);
			this.Connection2.Name = "Connection2";
			this.Connection2.Size = new System.Drawing.Size(144, 20);
			this.Connection2.TabIndex = 26;
			this.Connection2.Text = "Port: Disconnected";
			// 
			// config_clear
			// 
			this.config_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.config_clear.Location = new System.Drawing.Point(343, 367);
			this.config_clear.Name = "config_clear";
			this.config_clear.Size = new System.Drawing.Size(172, 41);
			this.config_clear.TabIndex = 25;
			this.config_clear.Text = "Clear configuration";
			this.config_clear.UseVisualStyleBackColor = true;
			this.config_clear.Click += new System.EventHandler(this.config_clear_Click);
			// 
			// UploadBox
			// 
			this.UploadBox.Location = new System.Drawing.Point(884, 330);
			this.UploadBox.Name = "UploadBox";
			this.UploadBox.Size = new System.Drawing.Size(172, 26);
			this.UploadBox.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(790, 203);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 20);
			this.label5.TabIndex = 23;
			this.label5.Text = "Savename:";
			// 
			// saveText
			// 
			this.saveText.Location = new System.Drawing.Point(884, 200);
			this.saveText.Name = "saveText";
			this.saveText.Size = new System.Drawing.Size(172, 26);
			this.saveText.TabIndex = 22;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(790, 330);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 20);
			this.label11.TabIndex = 21;
			this.label11.Text = "Upload file:";
			// 
			// Upload_Button
			// 
			this.Upload_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Upload_Button.Location = new System.Drawing.Point(884, 361);
			this.Upload_Button.Name = "Upload_Button";
			this.Upload_Button.Size = new System.Drawing.Size(172, 41);
			this.Upload_Button.TabIndex = 19;
			this.Upload_Button.Text = "Upload local file";
			this.Upload_Button.UseVisualStyleBackColor = true;
			this.Upload_Button.Click += new System.EventHandler(this.UplaodButton_click);
			// 
			// buttonLogin
			// 
			this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLogin.Location = new System.Drawing.Point(884, 102);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(172, 41);
			this.buttonLogin.TabIndex = 18;
			this.buttonLogin.Text = "Login";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler(this.password_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(807, 73);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 20);
			this.label10.TabIndex = 17;
			this.label10.Text = "Passord:";
			// 
			// PasswordBox
			// 
			this.PasswordBox.Location = new System.Drawing.Point(884, 67);
			this.PasswordBox.Name = "PasswordBox";
			this.PasswordBox.Size = new System.Drawing.Size(172, 26);
			this.PasswordBox.TabIndex = 16;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 367);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(62, 20);
			this.label9.TabIndex = 15;
			this.label9.Text = "AlarmH";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 296);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "AlarmL";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 20);
			this.label7.TabIndex = 13;
			this.label7.Text = "URV";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 164);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 20);
			this.label6.TabIndex = 12;
			this.label6.Text = "LRV";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(102, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Rediger verdier:";
			// 
			// ConfigAlarmH
			// 
			this.ConfigAlarmH.Location = new System.Drawing.Point(84, 361);
			this.ConfigAlarmH.Name = "ConfigAlarmH";
			this.ConfigAlarmH.ReadOnly = true;
			this.ConfigAlarmH.Size = new System.Drawing.Size(148, 26);
			this.ConfigAlarmH.TabIndex = 8;
			// 
			// SaveConf
			// 
			this.SaveConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveConf.Location = new System.Drawing.Point(884, 232);
			this.SaveConf.Name = "SaveConf";
			this.SaveConf.Size = new System.Drawing.Size(172, 41);
			this.SaveConf.TabIndex = 7;
			this.SaveConf.Text = "Save configuration";
			this.SaveConf.UseVisualStyleBackColor = true;
			this.SaveConf.Click += new System.EventHandler(this.SaveConf_Click);
			// 
			// LoadConf
			// 
			this.LoadConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoadConf.Location = new System.Drawing.Point(577, 367);
			this.LoadConf.Name = "LoadConf";
			this.LoadConf.Size = new System.Drawing.Size(172, 41);
			this.LoadConf.TabIndex = 6;
			this.LoadConf.Text = "Load configuration";
			this.LoadConf.UseVisualStyleBackColor = true;
			this.LoadConf.Click += new System.EventHandler(this.Read_config_click);
			// 
			// ConfigBoxSplit
			// 
			this.ConfigBoxSplit.Location = new System.Drawing.Point(343, 79);
			this.ConfigBoxSplit.Multiline = true;
			this.ConfigBoxSplit.Name = "ConfigBoxSplit";
			this.ConfigBoxSplit.ReadOnly = true;
			this.ConfigBoxSplit.Size = new System.Drawing.Size(406, 282);
			this.ConfigBoxSplit.TabIndex = 5;
			// 
			// ConfigAlarmL
			// 
			this.ConfigAlarmL.Location = new System.Drawing.Point(84, 290);
			this.ConfigAlarmL.Name = "ConfigAlarmL";
			this.ConfigAlarmL.ReadOnly = true;
			this.ConfigAlarmL.Size = new System.Drawing.Size(148, 26);
			this.ConfigAlarmL.TabIndex = 4;
			// 
			// ConfigUrv
			// 
			this.ConfigUrv.Location = new System.Drawing.Point(84, 220);
			this.ConfigUrv.Name = "ConfigUrv";
			this.ConfigUrv.ReadOnly = true;
			this.ConfigUrv.Size = new System.Drawing.Size(148, 26);
			this.ConfigUrv.TabIndex = 3;
			// 
			// ConfigLrv
			// 
			this.ConfigLrv.Location = new System.Drawing.Point(84, 158);
			this.ConfigLrv.Name = "ConfigLrv";
			this.ConfigLrv.ReadOnly = true;
			this.ConfigLrv.Size = new System.Drawing.Size(148, 26);
			this.ConfigLrv.TabIndex = 2;
			// 
			// ConfigName
			// 
			this.ConfigName.Location = new System.Drawing.Point(84, 97);
			this.ConfigName.Name = "ConfigName";
			this.ConfigName.ReadOnly = true;
			this.ConfigName.Size = new System.Drawing.Size(148, 26);
			this.ConfigName.TabIndex = 0;
			// 
			// monitor
			// 
			this.monitor.Controls.Add(this.MonitoringStatus);
			this.monitor.Controls.Add(this.Connection3);
			this.monitor.Controls.Add(this.startTimerScaled);
			this.monitor.Controls.Add(this.label12);
			this.monitor.Controls.Add(this.readingNameBox);
			this.monitor.Controls.Add(this.clear);
			this.monitor.Controls.Add(this.textBoxCVS);
			this.monitor.Controls.Add(this.cvsSave);
			this.monitor.Controls.Add(this.stopTimer);
			this.monitor.Controls.Add(this.startTimerRaw);
			this.monitor.Controls.Add(this.chart);
			this.monitor.Location = new System.Drawing.Point(4, 29);
			this.monitor.Name = "monitor";
			this.monitor.Padding = new System.Windows.Forms.Padding(3);
			this.monitor.Size = new System.Drawing.Size(1107, 520);
			this.monitor.TabIndex = 2;
			this.monitor.Text = "Monitored reading";
			this.monitor.UseVisualStyleBackColor = true;
			// 
			// MonitoringStatus
			// 
			this.MonitoringStatus.AutoSize = true;
			this.MonitoringStatus.Location = new System.Drawing.Point(913, 23);
			this.MonitoringStatus.Name = "MonitoringStatus";
			this.MonitoringStatus.Size = new System.Drawing.Size(188, 20);
			this.MonitoringStatus.TabIndex = 11;
			this.MonitoringStatus.Text = "Monitoring Status: Offline";
			// 
			// Connection3
			// 
			this.Connection3.AutoSize = true;
			this.Connection3.Location = new System.Drawing.Point(957, 3);
			this.Connection3.Name = "Connection3";
			this.Connection3.Size = new System.Drawing.Size(144, 20);
			this.Connection3.TabIndex = 9;
			this.Connection3.Text = "Port: Disconnected";
			// 
			// startTimerScaled
			// 
			this.startTimerScaled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startTimerScaled.Location = new System.Drawing.Point(87, 427);
			this.startTimerScaled.Name = "startTimerScaled";
			this.startTimerScaled.Size = new System.Drawing.Size(135, 41);
			this.startTimerScaled.TabIndex = 8;
			this.startTimerScaled.Text = "Scaled reading";
			this.startTimerScaled.UseVisualStyleBackColor = true;
			this.startTimerScaled.Click += new System.EventHandler(this.startTimerScaled_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(660, 61);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(141, 20);
			this.label12.TabIndex = 7;
			this.label12.Text = "Reading file name:";
			// 
			// readingNameBox
			// 
			this.readingNameBox.Location = new System.Drawing.Point(807, 58);
			this.readingNameBox.Name = "readingNameBox";
			this.readingNameBox.Size = new System.Drawing.Size(135, 26);
			this.readingNameBox.TabIndex = 6;
			// 
			// clear
			// 
			this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clear.Location = new System.Drawing.Point(627, 420);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(135, 41);
			this.clear.TabIndex = 5;
			this.clear.Text = "Clear reading:";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.clearReading_Click);
			// 
			// textBoxCVS
			// 
			this.textBoxCVS.Location = new System.Drawing.Point(627, 90);
			this.textBoxCVS.Multiline = true;
			this.textBoxCVS.Name = "textBoxCVS";
			this.textBoxCVS.ReadOnly = true;
			this.textBoxCVS.Size = new System.Drawing.Size(315, 313);
			this.textBoxCVS.TabIndex = 4;
			// 
			// cvsSave
			// 
			this.cvsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cvsSave.Location = new System.Drawing.Point(807, 420);
			this.cvsSave.Name = "cvsSave";
			this.cvsSave.Size = new System.Drawing.Size(135, 41);
			this.cvsSave.TabIndex = 3;
			this.cvsSave.Text = "Save to cvs";
			this.cvsSave.UseVisualStyleBackColor = true;
			this.cvsSave.Click += new System.EventHandler(this.CvsSave);
			// 
			// stopTimer
			// 
			this.stopTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.stopTimer.Location = new System.Drawing.Point(350, 380);
			this.stopTimer.Name = "stopTimer";
			this.stopTimer.Size = new System.Drawing.Size(135, 41);
			this.stopTimer.TabIndex = 2;
			this.stopTimer.Text = "Stop reading";
			this.stopTimer.UseVisualStyleBackColor = true;
			this.stopTimer.Click += new System.EventHandler(this.stopTimer_Click);
			// 
			// startTimerRaw
			// 
			this.startTimerRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startTimerRaw.Location = new System.Drawing.Point(87, 380);
			this.startTimerRaw.Name = "startTimerRaw";
			this.startTimerRaw.Size = new System.Drawing.Size(135, 41);
			this.startTimerRaw.TabIndex = 1;
			this.startTimerRaw.Text = "Raw reading";
			this.startTimerRaw.UseVisualStyleBackColor = true;
			this.startTimerRaw.Click += new System.EventHandler(this.StartTimer_Click);
			// 
			// chart
			// 
			chartArea1.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart.Legends.Add(legend1);
			this.chart.Location = new System.Drawing.Point(87, 90);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Vba";
			this.chart.Series.Add(series1);
			this.chart.Size = new System.Drawing.Size(398, 284);
			this.chart.TabIndex = 0;
			this.chart.Text = "chart";
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// ConnectionTimer
			// 
			this.ConnectionTimer.Tick += new System.EventHandler(this.ConnectionTimer_Tick);
			// 
			// MonitorStatusTimer
			// 
			this.MonitorStatusTimer.Tick += new System.EventHandler(this.MonitorStatusTimer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1140, 578);
			this.Controls.Add(this.Serial);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Serial.ResumeLayout(false);
			this.PortSelect.ResumeLayout(false);
			this.PortSelect.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.monitor.ResumeLayout(false);
			this.monitor.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl Serial;
		private System.Windows.Forms.TabPage PortSelect;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonDisconect;
		private System.Windows.Forms.ComboBox BitRateSelect;
		private System.Windows.Forms.ComboBox SerialSelect;
		private System.Windows.Forms.Button buttonConnect;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxSend;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.Windows.Forms.Button buttonSend;
		private System.Windows.Forms.TextBox ConfigAlarmL;
		private System.Windows.Forms.TextBox ConfigUrv;
		private System.Windows.Forms.TextBox ConfigLrv;
		private System.Windows.Forms.TextBox ConfigName;
		private System.Windows.Forms.Button SaveConf;
		private System.Windows.Forms.Button LoadConf;
		private System.Windows.Forms.TextBox ConfigBoxSplit;
		private System.Windows.Forms.TextBox ConfigAlarmH;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox PasswordBox;
		private System.Windows.Forms.TabPage monitor;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button stopTimer;
		private System.Windows.Forms.Button startTimerRaw;
		private System.Windows.Forms.Button cvsSave;
		private System.Windows.Forms.TextBox textBoxCVS;
		private System.Windows.Forms.Button clear;
		private System.Windows.Forms.Button Upload_Button;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox saveText;
		private System.Windows.Forms.TextBox UploadBox;
		private System.Windows.Forms.Button config_clear;
		private System.Windows.Forms.TextBox readingNameBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button startTimerScaled;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Label Connection3;
		private System.Windows.Forms.Label Connection1;
		private System.Windows.Forms.Label Connection2;
		private System.Windows.Forms.Timer ConnectionTimer;
		private System.Windows.Forms.Button Clear_Log;
		private System.Windows.Forms.Label MonitoringStatus;
		private System.Windows.Forms.Timer MonitorStatusTimer;
	}
}

