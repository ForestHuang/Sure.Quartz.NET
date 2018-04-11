using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Sure.Quartz.CronForms
{
    public class Cron : Form
    {
        private Dictionary<string, int> dicWeek = new Dictionary<string, int>();
        private IContainer components = (IContainer)null;
        private TabControl tabTime;
        private TabPage tabMinite;
        private TabPage tabHour;
        private TabPage tabDay;
        private GroupBox gb1;
        private TabPage tabMouth;
        private TabPage tabWeek;
        private Label label3;
        private Label label2;
        private TextBox txtWeek;
        private TextBox txtMonth;
        private TextBox txtDay;
        private TextBox txtHour;
        private TextBox txtMinite;
        private TextBox txtSecond;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label1;
        private Label label4;
        private TextBox txtCron;
        private Button btnCopy;
        private RadioButton rbMinAppoint;
        private RadioButton rbMin;
        private Label label11;
        private Label label10;
        private NumericUpDown numMinEvery;
        private NumericUpDown numMinStart;
        private CheckedListBox chkMin;
        private CheckedListBox chkHour;
        private RadioButton rbHourAppoint;
        private RadioButton rbHourEvery;
        private Label label13;
        private Label label12;
        private RadioButton rbDayAppoint;
        private RadioButton rbDayEvery;
        private CheckedListBox chkDay;
        private CheckedListBox chkMouth;
        private RadioButton rbMouthAppoint;
        private RadioButton rbMouth;
        private Label label14;
        private TextBox txtYear;
        private TabPage tabYear;
        private NumericUpDown numYearCO;
        private NumericUpDown numYearCS;
        private Label label15;
        private Label label16;
        private Label label17;
        private RadioButton rbYear;
        private RadioButton rbYearAppoint;
        private RadioButton rbWeekCycle;
        private NumericUpDown numWeekCO;
        private NumericUpDown numWeekCS;
        private Label label20;
        private Label label21;
        private TabPage tabIntro;
        private TextBox textBox1;
        private RadioButton rbWeekNoAppoint;
        private RadioButton rbMouthCycle;
        private NumericUpDown numMouthCO;
        private NumericUpDown numMouthCS;
        private Label label22;
        private Label label23;
        private NumericUpDown numMouthEvery;
        private NumericUpDown numMouthStart;
        private Label label9;
        private Label label24;
        private RadioButton rbWeek;
        private RadioButton rbMouthEvery;
        private RadioButton rbDayNoAppoint;
        private RadioButton rbYearNoAppoint;
        private RadioButton rbMouthNoAppoint;
        private RadioButton rbWeekLast;
        private Label label19;
        private NumericUpDown numWeek;
        private RadioButton rbWeekNumIn;
        private CheckedListBox chkWeek;
        private RadioButton rbWeekAppoint;
        private RadioButton rbMinCycle;
        private RadioButton rbMinEvery;
        private NumericUpDown numMinCO;
        private NumericUpDown numMinCS;
        private Label label18;
        private Label label25;
        private NumericUpDown numHourCO;
        private NumericUpDown numHourCS;
        private Label label26;
        private Label label27;
        private RadioButton rbHourCycle;
        private NumericUpDown numHourEvery;
        private NumericUpDown numHourStart;
        private Label label28;
        private Label label29;
        private RadioButton rbHour;
        private NumericUpDown numDayCO;
        private NumericUpDown numDayCS;
        private Label label30;
        private Label label31;
        private RadioButton rbDayCycle;
        private NumericUpDown numDayEvery;
        private NumericUpDown numDayStart;
        private Label label32;
        private Label label33;
        private RadioButton rbDay;
        private RadioButton rbDayL;
        private Label label34;
        private NumericUpDown numDayW;
        private RadioButton rbDayW;
        private TabPage tabSecond;
        private NumericUpDown numSecCO;
        private NumericUpDown numSecCS;
        private Label label35;
        private Label label36;
        private RadioButton rbSecCycle;
        private RadioButton rbSecEvery;
        private CheckedListBox chkSec;
        private NumericUpDown numSecEvery;
        private NumericUpDown numSecStart;
        private Label label37;
        private Label label38;
        private RadioButton rbSecAppoint;
        private RadioButton rbSec;

        public Cron()
        {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示",$"错误:{ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.numYearCS.Minimum = (Decimal)DateTime.Now.Year;
            this.numYearCO.Minimum = (Decimal)DateTime.Now.Year;
            this.numYearCS.Maximum = new Decimal(2050);
            this.numYearCO.Maximum = new Decimal(2050);
            this.txtWeek.Text = "?";
            this.txtYear.Text = string.Empty;
            this.dicWeek.Add("SUN", 1);
            this.dicWeek.Add("MON", 2);
            this.dicWeek.Add("TUES", 3);
            this.dicWeek.Add("WED", 4);
            this.dicWeek.Add("THUR", 5);
            this.dicWeek.Add("FRI", 6);
            this.dicWeek.Add("SAT", 7);
        }

        private void rbClick(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Name)
            {
                case "rbSecEvery":
                    this.txtSecond.Text = "*";
                    this.chkSec.Enabled = false;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    break;
                case "rbSecCycle":
                    this.txtSecond.Text = this.numSecCS.Value + "-" + this.numSecCO.Value;
                    this.chkSec.Enabled = false;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = true;
                    this.numSecCO.Enabled = true;
                    break;
                case "rbSec":
                    this.txtSecond.Text = this.numSecStart.Value + "/" + this.numSecEvery.Value;
                    this.numSecStart.Enabled = true;
                    this.numSecEvery.Enabled = true;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    this.chkSec.Enabled = false;
                    break;
                case "rbSecAppoint":
                    this.txtSecond.Text = "*";
                    this.chkSec.Enabled = true;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    break;
                case "rbMinEvery":
                    this.txtMinite.Text = "*";
                    this.chkMin.Enabled = false;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    break;
                case "rbMinCycle":
                    this.txtMinite.Text = this.numMinCS.Value + "-" + this.numMinCO.Value;
                    this.chkMin.Enabled = false;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = true;
                    this.numMinCO.Enabled = true;
                    break;
                case "rbMin":
                    this.txtMinite.Text = this.numMinStart.Value + "/" + this.numMinEvery.Value;
                    this.numMinStart.Enabled = true;
                    this.numMinEvery.Enabled = true;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    this.chkMin.Enabled = false;
                    break;
                case "rbMinAppoint":
                    this.txtMinite.Text = "*";
                    this.chkMin.Enabled = true;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    break;
                case "rbHourEvery":
                    this.txtHour.Text = "*";
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;
                case "rbHour":
                    this.txtHour.Text = this.numHourStart.Value + "/" + this.numHourEvery.Value;
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = true;
                    this.numHourEvery.Enabled = true;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;
                case "rbHourCycle":
                    this.txtHour.Text = this.numHourCS.Value + "-" + this.numHourCO.Value;
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = true;
                    this.numHourCO.Enabled = true;
                    break;
                case "rbHourAppoint":
                    this.txtHour.Text = "*";
                    this.chkHour.Enabled = true;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;
                case "rbDayEvery":
                case "rbDayNoAppoint":
                    this.txtDay.Text = radioButton.Name == "rbDayEvery" ? "*" : "?";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;
                case "rbDayCycle":
                    this.chkDay.Enabled = false;
                    this.txtDay.Text = this.numDayCS.Value + "-" + this.numDayCO.Value;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = true;
                    this.numDayCO.Enabled = true;
                    this.numDayW.Enabled = false;
                    break;
                case "rbDay":
                    this.chkDay.Enabled = false;
                    this.txtDay.Text = this.numDayStart.Value + "/" + this.numDayEvery.Value;
                    this.numDayStart.Enabled = true;
                    this.numDayEvery.Enabled = true;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    break;
                case "rbDayAppoint":
                    this.txtDay.Text = "*";
                    this.chkDay.Enabled = true;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;
                case "rbDayW":
                    this.txtDay.Text = this.numDayW.Value + "W";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = true;
                    break;
                case "rbDayL":
                    this.txtDay.Text = "L";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;
                case "rbMouthEvery":
                case "rbMouthNoAppoint":
                    this.txtMonth.Text = this.rbMouthEvery.Checked ? "*" : "?";
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;
                case "rbMouth":
                    this.txtMonth.Text = this.numMouthStart.Value + "/" + this.numMouthEvery.Value;
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = true;
                    this.numMouthStart.Enabled = true;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;
                case "rbMouthAppoint":
                    this.chkMouth.Enabled = true;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;
                case "rbMouthCycle":
                    this.txtMonth.Text = this.numMouthCS.Value + "-" + this.numMouthCO.Value;
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = true;
                    this.numMouthCS.Enabled = true;
                    break;
                case "rbWeek":
                case "rbWeekNoAppoint":
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.txtWeek.Text = radioButton.Name == "rbWeek" ? "*" : "?";
                    this.chkWeek.Enabled = false;
                    break;
                case "rbWeekAppoint":
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.txtWeek.Text = "*";
                    this.chkWeek.Enabled = true;
                    break;
                case "rbWeekNumIn":
                case "rbWeekLast":
                    this.numWeek.Enabled = true;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.chkWeek.Enabled = true;
                    this.chkWeek.ClearSelected();
                    this.chkWeek.SelectedIndex = 0;
                    break;
                case "rbWeekCycle":
                    this.txtWeek.Text = this.numWeekCS.Value + "/" + this.numWeekCO.Value;
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = true;
                    this.numWeekCO.Enabled = true;
                    this.chkWeek.Enabled = false;
                    break;
                case "rbYear":
                case "rbYearNoAppoint":
                    this.txtYear.Text = this.rbYear.Checked ? "*" : "";
                    this.numYearCS.Enabled = false;
                    this.numYearCO.Enabled = false;
                    break;
                case "rbYearAppoint":
                    this.txtYear.Text = this.numYearCS.Value + "-" + this.numYearCO.Value;
                    this.numYearCS.Enabled = true;
                    this.numYearCO.Enabled = true;
                    break;
            }
        }

        private void chk_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.rbWeekNumIn.Checked || this.rbWeekLast.Checked)
            {
                for (int index = 0; index < this.chkWeek.Items.Count; ++index)
                    this.chkWeek.SetItemCheckState(index, CheckState.Unchecked);
                if (this.chkWeek.SelectedIndex > -1)
                    this.chkWeek.SetItemCheckState(this.chkWeek.SelectedIndex, CheckState.Checked);
            }
            CheckedListBox checkedListBox = sender as CheckedListBox;
            ArrayList arrayList = new ArrayList();
            foreach (string index in checkedListBox.CheckedItems)
            {
                if (checkedListBox.Name == "chkWeek")
                    arrayList.Add(Convert.ToInt32(this.dicWeek[index]));
                else
                    arrayList.Add(Convert.ToInt32(index));
            }
            if (arrayList == null || arrayList.Count <= 0)
                return;
            arrayList.Sort();
            string str = string.Join<int>(",", (IEnumerable<int>)arrayList.ToArray(typeof(int)));
            switch (checkedListBox.Name)
            {
                case "chkSec":
                    this.txtSecond.Text = str;
                    break;
                case "chkMin":
                    this.txtMinite.Text = str;
                    break;
                case "chkHour":
                    this.txtHour.Text = str;
                    break;
                case "chkDay":
                    this.txtDay.Text = str;
                    break;
                case "chkMouth":
                    this.txtMonth.Text = str;
                    break;
                case "chkWeek":
                    if (this.rbWeekNumIn.Checked)
                    {
                        this.txtWeek.Text = str + "#" + this.numWeek.Value;
                        break;
                    }
                    if (this.rbWeekLast.Checked)
                    {
                        this.txtWeek.Text = str + "L";
                        break;
                    }
                    this.txtWeek.Text = str;
                    break;
            }
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            switch ((sender as NumericUpDown).Tag.ToString())
            {
                case "numSec":
                    this.txtSecond.Text = this.numSecStart.Value + "/" + this.numSecEvery.Value;
                    break;
                case "numSecC":
                    this.txtSecond.Text = this.numSecCS.Value + "-" + this.numSecCO.Value;
                    break;
                case "numMin":
                    this.txtMinite.Text = this.numMinStart.Value + "/" + this.numMinEvery.Value;
                    break;
                case "numMinC":
                    this.txtMinite.Text = this.numMinCS.Value + "-" + this.numMinCO.Value;
                    break;
                case "numHour":
                    this.txtHour.Text = this.numHourStart.Value + "/" + this.numHourEvery.Value;
                    break;
                case "numHourC":
                    this.txtHour.Text = this.numHourCS.Value + "-" + this.numHourCO.Value;
                    break;
                case "numDay":
                    this.txtDay.Text = this.numDayStart.Value + "/" + this.numDayEvery.Value;
                    break;
                case "numDayC":
                    this.txtDay.Text = this.numDayCS.Value + "-" + this.numDayCO.Value;
                    break;
                case "numDayW":
                    this.txtDay.Text = this.numDayW.Value + "W";
                    break;
                case "numMouth":
                    this.txtMonth.Text = this.numMouthStart.Value + "/" + this.numMouthEvery.Value;
                    break;
                case "numMouthC":
                    this.txtMonth.Text = this.numMouthCS.Value + "-" + this.numMouthCO.Value;
                    break;
                case "numWeekC":
                    this.txtWeek.Text = this.numWeekCS.Value + "/" + this.numWeekCO.Value;
                    break;
                case "numYearC":
                    this.txtYear.Text = this.numYearCS.Value + "-" + this.numYearCO.Value;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            new Process()
            {
                StartInfo = {
          FileName = "iexplore.exe",
          Arguments = linkLabel.Text
        }
            }.Start();
        }

        private void tabTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabTime.SelectedTab.Name == "tabIntro")
            {
                this.tabTime.Dock = DockStyle.Fill;
                this.gb1.Visible = false;
            }
            else
            {
                this.tabTime.Dock = DockStyle.Top;
                this.gb1.Visible = true;
            }
        }

        private void txtChanged(object sender, EventArgs e)
        {
            string str1 = this.txtSecond.Text.Trim();
            string str2 = this.txtMinite.Text.Trim();
            string str3 = this.txtHour.Text.Trim();
            string str4 = this.txtDay.Text.Trim();
            string str5 = this.txtMonth.Text.Trim();
            string str6 = this.txtWeek.Text.Trim();
            string str7 = this.txtYear.Text.Trim();
            this.txtCron.Text = string.Format("{0} {1} {2} {3} {4} {5} {6}", string.IsNullOrEmpty(str1) ? "*" : str1, string.IsNullOrEmpty(str2) ? "*" : str2, string.IsNullOrEmpty(str3) ? "*" : str3, string.IsNullOrEmpty(str4) ? "*" : str4, string.IsNullOrEmpty(str5) ? "*" : str5, string.IsNullOrEmpty(str6) ? "?" : str6, string.IsNullOrEmpty(str7) ? "" : str7);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCron.Text))
                return;
            Clipboard.SetDataObject(this.txtCron.Text);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Cron));
            this.tabTime = new TabControl();
            this.tabSecond = new TabPage();
            this.numSecCO = new NumericUpDown();
            this.numSecCS = new NumericUpDown();
            this.label35 = new Label();
            this.label36 = new Label();
            this.rbSecCycle = new RadioButton();
            this.rbSecEvery = new RadioButton();
            this.chkSec = new CheckedListBox();
            this.numSecEvery = new NumericUpDown();
            this.numSecStart = new NumericUpDown();
            this.label37 = new Label();
            this.label38 = new Label();
            this.rbSecAppoint = new RadioButton();
            this.rbSec = new RadioButton();
            this.tabMinite = new TabPage();
            this.numMinCO = new NumericUpDown();
            this.numMinCS = new NumericUpDown();
            this.label18 = new Label();
            this.label25 = new Label();
            this.rbMinCycle = new RadioButton();
            this.rbMinEvery = new RadioButton();
            this.chkMin = new CheckedListBox();
            this.numMinEvery = new NumericUpDown();
            this.numMinStart = new NumericUpDown();
            this.label11 = new Label();
            this.label10 = new Label();
            this.rbMinAppoint = new RadioButton();
            this.rbMin = new RadioButton();
            this.tabHour = new TabPage();
            this.numHourCO = new NumericUpDown();
            this.numHourCS = new NumericUpDown();
            this.label26 = new Label();
            this.label27 = new Label();
            this.rbHourCycle = new RadioButton();
            this.numHourEvery = new NumericUpDown();
            this.numHourStart = new NumericUpDown();
            this.label28 = new Label();
            this.label29 = new Label();
            this.rbHour = new RadioButton();
            this.label13 = new Label();
            this.label12 = new Label();
            this.chkHour = new CheckedListBox();
            this.rbHourAppoint = new RadioButton();
            this.rbHourEvery = new RadioButton();
            this.tabDay = new TabPage();
            this.rbDayL = new RadioButton();
            this.label34 = new Label();
            this.numDayW = new NumericUpDown();
            this.rbDayW = new RadioButton();
            this.numDayCO = new NumericUpDown();
            this.numDayCS = new NumericUpDown();
            this.label30 = new Label();
            this.label31 = new Label();
            this.rbDayCycle = new RadioButton();
            this.numDayEvery = new NumericUpDown();
            this.numDayStart = new NumericUpDown();
            this.label32 = new Label();
            this.label33 = new Label();
            this.rbDay = new RadioButton();
            this.rbDayNoAppoint = new RadioButton();
            this.chkDay = new CheckedListBox();
            this.rbDayAppoint = new RadioButton();
            this.rbDayEvery = new RadioButton();
            this.tabMouth = new TabPage();
            this.rbMouthNoAppoint = new RadioButton();
            this.rbMouthEvery = new RadioButton();
            this.numMouthEvery = new NumericUpDown();
            this.numMouthStart = new NumericUpDown();
            this.label9 = new Label();
            this.label24 = new Label();
            this.rbMouthCycle = new RadioButton();
            this.numMouthCO = new NumericUpDown();
            this.numMouthCS = new NumericUpDown();
            this.label22 = new Label();
            this.label23 = new Label();
            this.chkMouth = new CheckedListBox();
            this.rbMouthAppoint = new RadioButton();
            this.rbMouth = new RadioButton();
            this.tabWeek = new TabPage();
            this.rbWeekLast = new RadioButton();
            this.rbWeek = new RadioButton();
            this.label19 = new Label();
            this.numWeek = new NumericUpDown();
            this.rbWeekNumIn = new RadioButton();
            this.rbWeekNoAppoint = new RadioButton();
            this.rbWeekCycle = new RadioButton();
            this.numWeekCO = new NumericUpDown();
            this.numWeekCS = new NumericUpDown();
            this.label20 = new Label();
            this.label21 = new Label();
            this.chkWeek = new CheckedListBox();
            this.rbWeekAppoint = new RadioButton();
            this.tabYear = new TabPage();
            this.rbYearNoAppoint = new RadioButton();
            this.rbYearAppoint = new RadioButton();
            this.numYearCO = new NumericUpDown();
            this.numYearCS = new NumericUpDown();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.rbYear = new RadioButton();
            this.tabIntro = new TabPage();
            this.textBox1 = new TextBox();
            this.gb1 = new GroupBox();
            this.label14 = new Label();
            this.txtYear = new TextBox();
            this.btnCopy = new Button();
            this.label8 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label1 = new Label();
            this.label4 = new Label();
            this.txtCron = new TextBox();
            this.txtWeek = new TextBox();
            this.txtMonth = new TextBox();
            this.txtDay = new TextBox();
            this.txtHour = new TextBox();
            this.txtMinite = new TextBox();
            this.txtSecond = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.tabTime.SuspendLayout();
            this.tabSecond.SuspendLayout();
            this.numSecCO.BeginInit();
            this.numSecCS.BeginInit();
            this.numSecEvery.BeginInit();
            this.numSecStart.BeginInit();
            this.tabMinite.SuspendLayout();
            this.numMinCO.BeginInit();
            this.numMinCS.BeginInit();
            this.numMinEvery.BeginInit();
            this.numMinStart.BeginInit();
            this.tabHour.SuspendLayout();
            this.numHourCO.BeginInit();
            this.numHourCS.BeginInit();
            this.numHourEvery.BeginInit();
            this.numHourStart.BeginInit();
            this.tabDay.SuspendLayout();
            this.numDayW.BeginInit();
            this.numDayCO.BeginInit();
            this.numDayCS.BeginInit();
            this.numDayEvery.BeginInit();
            this.numDayStart.BeginInit();
            this.tabMouth.SuspendLayout();
            this.numMouthEvery.BeginInit();
            this.numMouthStart.BeginInit();
            this.numMouthCO.BeginInit();
            this.numMouthCS.BeginInit();
            this.tabWeek.SuspendLayout();
            this.numWeek.BeginInit();
            this.numWeekCO.BeginInit();
            this.numWeekCS.BeginInit();
            this.tabYear.SuspendLayout();
            this.numYearCO.BeginInit();
            this.numYearCS.BeginInit();
            this.tabIntro.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            this.tabTime.Controls.Add((Control)this.tabSecond);
            this.tabTime.Controls.Add((Control)this.tabMinite);
            this.tabTime.Controls.Add((Control)this.tabHour);
            this.tabTime.Controls.Add((Control)this.tabDay);
            this.tabTime.Controls.Add((Control)this.tabMouth);
            this.tabTime.Controls.Add((Control)this.tabWeek);
            this.tabTime.Controls.Add((Control)this.tabYear);
            this.tabTime.Controls.Add((Control)this.tabIntro);
            this.tabTime.Dock = DockStyle.Top;
            this.tabTime.Location = new Point(0, 0);
            this.tabTime.Name = "tabTime";
            this.tabTime.SelectedIndex = 0;
            this.tabTime.Size = new Size(829, 261);
            this.tabTime.TabIndex = 0;
            this.tabTime.SelectedIndexChanged += new EventHandler(this.tabTime_SelectedIndexChanged);
            this.tabSecond.Controls.Add((Control)this.numSecCO);
            this.tabSecond.Controls.Add((Control)this.numSecCS);
            this.tabSecond.Controls.Add((Control)this.label35);
            this.tabSecond.Controls.Add((Control)this.label36);
            this.tabSecond.Controls.Add((Control)this.rbSecCycle);
            this.tabSecond.Controls.Add((Control)this.rbSecEvery);
            this.tabSecond.Controls.Add((Control)this.chkSec);
            this.tabSecond.Controls.Add((Control)this.numSecEvery);
            this.tabSecond.Controls.Add((Control)this.numSecStart);
            this.tabSecond.Controls.Add((Control)this.label37);
            this.tabSecond.Controls.Add((Control)this.label38);
            this.tabSecond.Controls.Add((Control)this.rbSecAppoint);
            this.tabSecond.Controls.Add((Control)this.rbSec);
            this.tabSecond.Location = new Point(4, 22);
            this.tabSecond.Name = "tabSecond";
            this.tabSecond.Padding = new Padding(3);
            this.tabSecond.Size = new Size(821, 235);
            this.tabSecond.TabIndex = 7;
            this.tabSecond.Text = "秒";
            this.tabSecond.UseVisualStyleBackColor = true;
            this.numSecCO.Enabled = false;
            this.numSecCO.Location = new Point(117, 26);
            NumericUpDown numericUpDown1 = this.numSecCO;
            int[] bits1 = new int[4];
            bits1[0] = 59;
            Decimal num1 = new Decimal(bits1);
            numericUpDown1.Maximum = num1;
            NumericUpDown numericUpDown2 = this.numSecCO;
            int[] bits2 = new int[4];
            bits2[0] = 2;
            Decimal num2 = new Decimal(bits2);
            numericUpDown2.Minimum = num2;
            this.numSecCO.Name = "numSecCO";
            this.numSecCO.Size = new Size(31, 21);
            this.numSecCO.TabIndex = 69;
            this.numSecCO.Tag = "numSecC";
            NumericUpDown numericUpDown3 = this.numSecCO;
            int[] bits3 = new int[4];
            bits3[0] = 2;
            Decimal num3 = new Decimal(bits3);
            numericUpDown3.Value = num3;
            this.numSecCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numSecCS.Enabled = false;
            this.numSecCS.Location = new Point(70, 26);
            NumericUpDown numericUpDown4 = this.numSecCS;
            int[] bits4 = new int[4];
            bits4[0] = 58;
            Decimal num4 = new Decimal(bits4);
            numericUpDown4.Maximum = num4;
            NumericUpDown numericUpDown5 = this.numSecCS;
            int[] bits5 = new int[4];
            bits5[0] = 1;
            Decimal num5 = new Decimal(bits5);
            numericUpDown5.Minimum = num5;
            this.numSecCS.Name = "numSecCS";
            this.numSecCS.Size = new Size(31, 21);
            this.numSecCS.TabIndex = 68;
            this.numSecCS.Tag = "numSecC";
            NumericUpDown numericUpDown6 = this.numSecCS;
            int[] bits6 = new int[4];
            bits6[0] = 1;
            Decimal num6 = new Decimal(bits6);
            numericUpDown6.Value = num6;
            this.numSecCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label35.AutoSize = true;
            this.label35.Location = new Point(103, 30);
            this.label35.Name = "label35";
            this.label35.Size = new Size(11, 12);
            this.label35.TabIndex = 67;
            this.label35.Text = "-";
            this.label36.AutoSize = true;
            this.label36.Location = new Point(151, 30);
            this.label36.Name = "label36";
            this.label36.Size = new Size(17, 12);
            this.label36.TabIndex = 66;
            this.label36.Text = "秒";
            this.rbSecCycle.AutoSize = true;
            this.rbSecCycle.Location = new Point(8, 28);
            this.rbSecCycle.Name = "rbSecCycle";
            this.rbSecCycle.Size = new Size(59, 16);
            this.rbSecCycle.TabIndex = 65;
            this.rbSecCycle.Text = "周期从";
            this.rbSecCycle.UseVisualStyleBackColor = true;
            this.rbSecCycle.Click += new EventHandler(this.rbClick);
            this.rbSecEvery.AutoSize = true;
            this.rbSecEvery.Checked = true;
            this.rbSecEvery.Location = new Point(8, 6);
            this.rbSecEvery.Name = "rbSecEvery";
            this.rbSecEvery.Size = new Size(179, 16);
            this.rbSecEvery.TabIndex = 64;
            this.rbSecEvery.TabStop = true;
            this.rbSecEvery.Text = "每秒 允许的通配符[, - * /]";
            this.rbSecEvery.UseVisualStyleBackColor = true;
            this.rbSecEvery.Click += new EventHandler(this.rbClick);
            this.chkSec.BorderStyle = BorderStyle.None;
            this.chkSec.CheckOnClick = true;
            this.chkSec.ColumnWidth = 40;
            this.chkSec.Enabled = false;
            this.chkSec.FormattingEnabled = true;
            this.chkSec.Items.AddRange(new object[60]
            {
         "1",
         "11",
         "21",
         "31",
         "41",
         "51",
         "2",
         "12",
         "22",
         "32",
         "42",
         "52",
         "3",
         "13",
         "23",
         "33",
         "43",
         "53",
         "4",
         "14",
         "24",
         "34",
         "44",
         "54",
         "5",
         "15",
         "25",
         "35",
         "45",
         "55",
         "6",
         "16",
         "26",
         "36",
         "46",
         "56",
         "7",
         "17",
         "27",
         "37",
         "47",
         "57",
         "8",
         "18",
         "28",
         "38",
         "48",
         "58",
         "9",
         "19",
         "29",
         "39",
         "49",
         "59",
         "10",
         "20",
         "30",
         "40",
         "50",
         "0"
            });
            this.chkSec.Location = new Point(26, 98);
            this.chkSec.MultiColumn = true;
            this.chkSec.Name = "chkSec";
            this.chkSec.Size = new Size(448, 96);
            this.chkSec.TabIndex = 63;
            this.chkSec.TabStop = false;
            this.chkSec.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.numSecEvery.Enabled = false;
            this.numSecEvery.Location = new Point(158, 51);
            NumericUpDown numericUpDown7 = this.numSecEvery;
            int[] bits7 = new int[4];
            bits7[0] = 59;
            Decimal num7 = new Decimal(bits7);
            numericUpDown7.Maximum = num7;
            NumericUpDown numericUpDown8 = this.numSecEvery;
            int[] bits8 = new int[4];
            bits8[0] = 1;
            Decimal num8 = new Decimal(bits8);
            numericUpDown8.Minimum = num8;
            this.numSecEvery.Name = "numSecEvery";
            this.numSecEvery.Size = new Size(57, 21);
            this.numSecEvery.TabIndex = 62;
            this.numSecEvery.Tag = "numSec";
            NumericUpDown numericUpDown9 = this.numSecEvery;
            int[] bits9 = new int[4];
            bits9[0] = 1;
            Decimal num9 = new Decimal(bits9);
            numericUpDown9.Value = num9;
            this.numSecEvery.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numSecStart.Enabled = false;
            this.numSecStart.Location = new Point(41, 51);
            NumericUpDown numericUpDown10 = this.numSecStart;
            int[] bits10 = new int[4];
            bits10[0] = 59;
            Decimal num10 = new Decimal(bits10);
            numericUpDown10.Maximum = num10;
            this.numSecStart.Name = "numSecStart";
            this.numSecStart.Size = new Size(52, 21);
            this.numSecStart.TabIndex = 61;
            this.numSecStart.Tag = "numSec";
            this.numSecStart.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label37.AutoSize = true;
            this.label37.Location = new Point(217, 55);
            this.label37.Name = "label37";
            this.label37.Size = new Size(65, 12);
            this.label37.TabIndex = 60;
            this.label37.Text = "秒执行一次";
            this.label38.AutoSize = true;
            this.label38.Location = new Point(97, 55);
            this.label38.Name = "label38";
            this.label38.Size = new Size(59, 12);
            this.label38.TabIndex = 59;
            this.label38.Text = "秒开始,每";
            this.rbSecAppoint.AutoSize = true;
            this.rbSecAppoint.Location = new Point(8, 76);
            this.rbSecAppoint.Name = "rbSecAppoint";
            this.rbSecAppoint.Size = new Size(47, 16);
            this.rbSecAppoint.TabIndex = 58;
            this.rbSecAppoint.Text = "指定";
            this.rbSecAppoint.UseVisualStyleBackColor = true;
            this.rbSecAppoint.Click += new EventHandler(this.rbClick);
            this.rbSec.AutoSize = true;
            this.rbSec.Location = new Point(8, 53);
            this.rbSec.Name = "rbSec";
            this.rbSec.Size = new Size(35, 16);
            this.rbSec.TabIndex = 57;
            this.rbSec.Text = "从";
            this.rbSec.UseVisualStyleBackColor = true;
            this.rbSec.Click += new EventHandler(this.rbClick);
            this.tabMinite.Controls.Add((Control)this.numMinCO);
            this.tabMinite.Controls.Add((Control)this.numMinCS);
            this.tabMinite.Controls.Add((Control)this.label18);
            this.tabMinite.Controls.Add((Control)this.label25);
            this.tabMinite.Controls.Add((Control)this.rbMinCycle);
            this.tabMinite.Controls.Add((Control)this.rbMinEvery);
            this.tabMinite.Controls.Add((Control)this.chkMin);
            this.tabMinite.Controls.Add((Control)this.numMinEvery);
            this.tabMinite.Controls.Add((Control)this.numMinStart);
            this.tabMinite.Controls.Add((Control)this.label11);
            this.tabMinite.Controls.Add((Control)this.label10);
            this.tabMinite.Controls.Add((Control)this.rbMinAppoint);
            this.tabMinite.Controls.Add((Control)this.rbMin);
            this.tabMinite.Location = new Point(4, 22);
            this.tabMinite.Name = "tabMinite";
            this.tabMinite.Padding = new Padding(3);
            this.tabMinite.Size = new Size(821, 235);
            this.tabMinite.TabIndex = 0;
            this.tabMinite.Text = "分钟";
            this.tabMinite.UseVisualStyleBackColor = true;
            this.numMinCO.Enabled = false;
            this.numMinCO.Location = new Point(117, 26);
            NumericUpDown numericUpDown11 = this.numMinCO;
            int[] bits11 = new int[4];
            bits11[0] = 59;
            Decimal num11 = new Decimal(bits11);
            numericUpDown11.Maximum = num11;
            NumericUpDown numericUpDown12 = this.numMinCO;
            int[] bits12 = new int[4];
            bits12[0] = 2;
            Decimal num12 = new Decimal(bits12);
            numericUpDown12.Minimum = num12;
            this.numMinCO.Name = "numMinCO";
            this.numMinCO.Size = new Size(31, 21);
            this.numMinCO.TabIndex = 43;
            this.numMinCO.Tag = "numMinC";
            NumericUpDown numericUpDown13 = this.numMinCO;
            int[] bits13 = new int[4];
            bits13[0] = 2;
            Decimal num13 = new Decimal(bits13);
            numericUpDown13.Value = num13;
            this.numMinCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numMinCS.Enabled = false;
            this.numMinCS.Location = new Point(70, 26);
            NumericUpDown numericUpDown14 = this.numMinCS;
            int[] bits14 = new int[4];
            bits14[0] = 58;
            Decimal num14 = new Decimal(bits14);
            numericUpDown14.Maximum = num14;
            NumericUpDown numericUpDown15 = this.numMinCS;
            int[] bits15 = new int[4];
            bits15[0] = 1;
            Decimal num15 = new Decimal(bits15);
            numericUpDown15.Minimum = num15;
            this.numMinCS.Name = "numMinCS";
            this.numMinCS.Size = new Size(31, 21);
            this.numMinCS.TabIndex = 42;
            this.numMinCS.Tag = "numMinC";
            NumericUpDown numericUpDown16 = this.numMinCS;
            int[] bits16 = new int[4];
            bits16[0] = 1;
            Decimal num16 = new Decimal(bits16);
            numericUpDown16.Value = num16;
            this.numMinCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label18.AutoSize = true;
            this.label18.Location = new Point(103, 30);
            this.label18.Name = "label18";
            this.label18.Size = new Size(11, 12);
            this.label18.TabIndex = 41;
            this.label18.Text = "-";
            this.label25.AutoSize = true;
            this.label25.Location = new Point(151, 30);
            this.label25.Name = "label25";
            this.label25.Size = new Size(17, 12);
            this.label25.TabIndex = 40;
            this.label25.Text = "分";
            this.rbMinCycle.AutoSize = true;
            this.rbMinCycle.Location = new Point(8, 28);
            this.rbMinCycle.Name = "rbMinCycle";
            this.rbMinCycle.Size = new Size(59, 16);
            this.rbMinCycle.TabIndex = 26;
            this.rbMinCycle.Text = "周期从";
            this.rbMinCycle.UseVisualStyleBackColor = true;
            this.rbMinCycle.Click += new EventHandler(this.rbClick);
            this.rbMinEvery.AutoSize = true;
            this.rbMinEvery.Checked = true;
            this.rbMinEvery.Location = new Point(8, 6);
            this.rbMinEvery.Name = "rbMinEvery";
            this.rbMinEvery.Size = new Size(191, 16);
            this.rbMinEvery.TabIndex = 25;
            this.rbMinEvery.TabStop = true;
            this.rbMinEvery.Text = "每分钟 允许的通配符[, - * /]";
            this.rbMinEvery.UseVisualStyleBackColor = true;
            this.rbMinEvery.Click += new EventHandler(this.rbClick);
            this.chkMin.BorderStyle = BorderStyle.None;
            this.chkMin.CheckOnClick = true;
            this.chkMin.ColumnWidth = 40;
            this.chkMin.Enabled = false;
            this.chkMin.FormattingEnabled = true;
            this.chkMin.Items.AddRange(new object[60]
            {
         "1",
         "11",
         "21",
         "31",
         "41",
         "51",
         "2",
         "12",
         "22",
         "32",
         "42",
         "52",
         "3",
         "13",
         "23",
         "33",
         "43",
         "53",
         "4",
         "14",
         "24",
         "34",
         "44",
         "54",
         "5",
         "15",
         "25",
         "35",
         "45",
         "55",
         "6",
         "16",
         "26",
         "36",
         "46",
         "56",
         "7",
         "17",
         "27",
         "37",
         "47",
         "57",
         "8",
         "18",
         "28",
         "38",
         "48",
         "58",
         "9",
         "19",
         "29",
         "39",
         "49",
         "59",
         "10",
         "20",
         "30",
         "40",
         "50",
         "0"
            });
            this.chkMin.Location = new Point(26, 98);
            this.chkMin.MultiColumn = true;
            this.chkMin.Name = "chkMin";
            this.chkMin.Size = new Size(420, 96);
            this.chkMin.TabIndex = 18;
            this.chkMin.TabStop = false;
            this.chkMin.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.numMinEvery.Enabled = false;
            this.numMinEvery.Location = new Point(168, 51);
            NumericUpDown numericUpDown17 = this.numMinEvery;
            int[] bits17 = new int[4];
            bits17[0] = 59;
            Decimal num17 = new Decimal(bits17);
            numericUpDown17.Maximum = num17;
            NumericUpDown numericUpDown18 = this.numMinEvery;
            int[] bits18 = new int[4];
            bits18[0] = 1;
            Decimal num18 = new Decimal(bits18);
            numericUpDown18.Minimum = num18;
            this.numMinEvery.Name = "numMinEvery";
            this.numMinEvery.Size = new Size(57, 21);
            this.numMinEvery.TabIndex = 17;
            this.numMinEvery.Tag = "numMin";
            NumericUpDown numericUpDown19 = this.numMinEvery;
            int[] bits19 = new int[4];
            bits19[0] = 1;
            Decimal num19 = new Decimal(bits19);
            numericUpDown19.Value = num19;
            this.numMinEvery.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numMinStart.Enabled = false;
            this.numMinStart.Location = new Point(41, 51);
            NumericUpDown numericUpDown20 = this.numMinStart;
            int[] bits20 = new int[4];
            bits20[0] = 59;
            Decimal num20 = new Decimal(bits20);
            numericUpDown20.Maximum = num20;
            this.numMinStart.Name = "numMinStart";
            this.numMinStart.Size = new Size(52, 21);
            this.numMinStart.TabIndex = 16;
            this.numMinStart.Tag = "numMin";
            this.numMinStart.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(229, 55);
            this.label11.Name = "label11";
            this.label11.Size = new Size(77, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "分钟执行一次";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(97, 55);
            this.label10.Name = "label10";
            this.label10.Size = new Size(71, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "分钟开始,每";
            this.rbMinAppoint.AutoSize = true;
            this.rbMinAppoint.Location = new Point(8, 76);
            this.rbMinAppoint.Name = "rbMinAppoint";
            this.rbMinAppoint.Size = new Size(47, 16);
            this.rbMinAppoint.TabIndex = 1;
            this.rbMinAppoint.Text = "指定";
            this.rbMinAppoint.UseVisualStyleBackColor = true;
            this.rbMinAppoint.Click += new EventHandler(this.rbClick);
            this.rbMin.AutoSize = true;
            this.rbMin.Location = new Point(8, 53);
            this.rbMin.Name = "rbMin";
            this.rbMin.Size = new Size(35, 16);
            this.rbMin.TabIndex = 0;
            this.rbMin.Text = "从";
            this.rbMin.UseVisualStyleBackColor = true;
            this.rbMin.Click += new EventHandler(this.rbClick);
            this.tabHour.Controls.Add((Control)this.numHourCO);
            this.tabHour.Controls.Add((Control)this.numHourCS);
            this.tabHour.Controls.Add((Control)this.label26);
            this.tabHour.Controls.Add((Control)this.label27);
            this.tabHour.Controls.Add((Control)this.rbHourCycle);
            this.tabHour.Controls.Add((Control)this.numHourEvery);
            this.tabHour.Controls.Add((Control)this.numHourStart);
            this.tabHour.Controls.Add((Control)this.label28);
            this.tabHour.Controls.Add((Control)this.label29);
            this.tabHour.Controls.Add((Control)this.rbHour);
            this.tabHour.Controls.Add((Control)this.label13);
            this.tabHour.Controls.Add((Control)this.label12);
            this.tabHour.Controls.Add((Control)this.chkHour);
            this.tabHour.Controls.Add((Control)this.rbHourAppoint);
            this.tabHour.Controls.Add((Control)this.rbHourEvery);
            this.tabHour.Location = new Point(4, 22);
            this.tabHour.Name = "tabHour";
            this.tabHour.Padding = new Padding(3);
            this.tabHour.Size = new Size(821, 235);
            this.tabHour.TabIndex = 1;
            this.tabHour.Text = "小时";
            this.tabHour.UseVisualStyleBackColor = true;
            this.numHourCO.Enabled = false;
            this.numHourCO.Location = new Point(117, 27);
            NumericUpDown numericUpDown21 = this.numHourCO;
            int[] bits21 = new int[4];
            bits21[0] = 59;
            Decimal num21 = new Decimal(bits21);
            numericUpDown21.Maximum = num21;
            NumericUpDown numericUpDown22 = this.numHourCO;
            int[] bits22 = new int[4];
            bits22[0] = 2;
            Decimal num22 = new Decimal(bits22);
            numericUpDown22.Minimum = num22;
            this.numHourCO.Name = "numHourCO";
            this.numHourCO.Size = new Size(31, 21);
            this.numHourCO.TabIndex = 53;
            this.numHourCO.Tag = "numHourC";
            NumericUpDown numericUpDown23 = this.numHourCO;
            int[] bits23 = new int[4];
            bits23[0] = 2;
            Decimal num23 = new Decimal(bits23);
            numericUpDown23.Value = num23;
            this.numHourCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numHourCS.Enabled = false;
            this.numHourCS.Location = new Point(70, 27);
            NumericUpDown numericUpDown24 = this.numHourCS;
            int[] bits24 = new int[4];
            bits24[0] = 58;
            Decimal num24 = new Decimal(bits24);
            numericUpDown24.Maximum = num24;
            NumericUpDown numericUpDown25 = this.numHourCS;
            int[] bits25 = new int[4];
            bits25[0] = 1;
            Decimal num25 = new Decimal(bits25);
            numericUpDown25.Minimum = num25;
            this.numHourCS.Name = "numHourCS";
            this.numHourCS.Size = new Size(31, 21);
            this.numHourCS.TabIndex = 52;
            this.numHourCS.Tag = "numHourC";
            NumericUpDown numericUpDown26 = this.numHourCS;
            int[] bits26 = new int[4];
            bits26[0] = 1;
            Decimal num26 = new Decimal(bits26);
            numericUpDown26.Value = num26;
            this.numHourCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label26.AutoSize = true;
            this.label26.Location = new Point(103, 31);
            this.label26.Name = "label26";
            this.label26.Size = new Size(11, 12);
            this.label26.TabIndex = 51;
            this.label26.Text = "-";
            this.label27.AutoSize = true;
            this.label27.Location = new Point(151, 31);
            this.label27.Name = "label27";
            this.label27.Size = new Size(29, 12);
            this.label27.TabIndex = 50;
            this.label27.Text = "小时";
            this.rbHourCycle.AutoSize = true;
            this.rbHourCycle.Location = new Point(8, 29);
            this.rbHourCycle.Name = "rbHourCycle";
            this.rbHourCycle.Size = new Size(59, 16);
            this.rbHourCycle.TabIndex = 49;
            this.rbHourCycle.Text = "周期从";
            this.rbHourCycle.UseVisualStyleBackColor = true;
            this.rbHourCycle.Click += new EventHandler(this.rbClick);
            this.numHourEvery.Enabled = false;
            this.numHourEvery.Location = new Point(168, 52);
            NumericUpDown numericUpDown27 = this.numHourEvery;
            int[] bits27 = new int[4];
            bits27[0] = 23;
            Decimal num27 = new Decimal(bits27);
            numericUpDown27.Maximum = num27;
            NumericUpDown numericUpDown28 = this.numHourEvery;
            int[] bits28 = new int[4];
            bits28[0] = 1;
            Decimal num28 = new Decimal(bits28);
            numericUpDown28.Minimum = num28;
            this.numHourEvery.Name = "numHourEvery";
            this.numHourEvery.Size = new Size(57, 21);
            this.numHourEvery.TabIndex = 48;
            this.numHourEvery.Tag = "numHour";
            NumericUpDown numericUpDown29 = this.numHourEvery;
            int[] bits29 = new int[4];
            bits29[0] = 1;
            Decimal num29 = new Decimal(bits29);
            numericUpDown29.Value = num29;
            this.numHourEvery.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numHourStart.Enabled = false;
            this.numHourStart.Location = new Point(41, 52);
            NumericUpDown numericUpDown30 = this.numHourStart;
            int[] bits30 = new int[4];
            bits30[0] = 23;
            Decimal num30 = new Decimal(bits30);
            numericUpDown30.Maximum = num30;
            this.numHourStart.Name = "numHourStart";
            this.numHourStart.Size = new Size(52, 21);
            this.numHourStart.TabIndex = 47;
            this.numHourStart.Tag = "numHour";
            this.numHourStart.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label28.AutoSize = true;
            this.label28.Location = new Point(229, 56);
            this.label28.Name = "label28";
            this.label28.Size = new Size(77, 12);
            this.label28.TabIndex = 46;
            this.label28.Text = "小时执行一次";
            this.label29.AutoSize = true;
            this.label29.Location = new Point(97, 56);
            this.label29.Name = "label29";
            this.label29.Size = new Size(59, 12);
            this.label29.TabIndex = 45;
            this.label29.Text = "点开始,每";
            this.rbHour.AutoSize = true;
            this.rbHour.Location = new Point(8, 54);
            this.rbHour.Name = "rbHour";
            this.rbHour.Size = new Size(35, 16);
            this.rbHour.TabIndex = 44;
            this.rbHour.Text = "从";
            this.rbHour.UseVisualStyleBackColor = true;
            this.rbHour.Click += new EventHandler(this.rbClick);
            this.label13.AutoSize = true;
            this.label13.Location = new Point(24, 116);
            this.label13.Name = "label13";
            this.label13.Size = new Size(29, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "PM：";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(24, 100);
            this.label12.Name = "label12";
            this.label12.Size = new Size(29, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "AM：";
            this.chkHour.BorderStyle = BorderStyle.None;
            this.chkHour.CheckOnClick = true;
            this.chkHour.ColumnWidth = 40;
            this.chkHour.Enabled = false;
            this.chkHour.FormattingEnabled = true;
            this.chkHour.Items.AddRange(new object[24]
            {
         "1",
         "13",
         "2",
         "14",
         "3",
         "15",
         "4",
         "16",
         "5",
         "17",
         "6",
         "18",
         "7",
         "19",
         "8",
         "20",
         "9",
         "21",
         "10",
         "22",
         "11",
         "23",
         "12",
         "0"
            });
            this.chkHour.Location = new Point(52, 99);
            this.chkHour.MultiColumn = true;
            this.chkHour.Name = "chkHour";
            this.chkHour.Size = new Size(548, 32);
            this.chkHour.TabIndex = 21;
            this.chkHour.TabStop = false;
            this.chkHour.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.rbHourAppoint.AutoSize = true;
            this.rbHourAppoint.Location = new Point(8, 77);
            this.rbHourAppoint.Name = "rbHourAppoint";
            this.rbHourAppoint.Size = new Size(47, 16);
            this.rbHourAppoint.TabIndex = 20;
            this.rbHourAppoint.TabStop = true;
            this.rbHourAppoint.Text = "指定";
            this.rbHourAppoint.UseVisualStyleBackColor = true;
            this.rbHourAppoint.Click += new EventHandler(this.rbClick);
            this.rbHourEvery.AutoSize = true;
            this.rbHourEvery.Checked = true;
            this.rbHourEvery.Location = new Point(8, 6);
            this.rbHourEvery.Name = "rbHourEvery";
            this.rbHourEvery.Size = new Size(191, 16);
            this.rbHourEvery.TabIndex = 19;
            this.rbHourEvery.TabStop = true;
            this.rbHourEvery.Text = "每小时 允许的通配符[, - * /]";
            this.rbHourEvery.UseVisualStyleBackColor = true;
            this.rbHourEvery.Click += new EventHandler(this.rbClick);
            this.tabDay.Controls.Add((Control)this.rbDayL);
            this.tabDay.Controls.Add((Control)this.label34);
            this.tabDay.Controls.Add((Control)this.numDayW);
            this.tabDay.Controls.Add((Control)this.rbDayW);
            this.tabDay.Controls.Add((Control)this.numDayCO);
            this.tabDay.Controls.Add((Control)this.numDayCS);
            this.tabDay.Controls.Add((Control)this.label30);
            this.tabDay.Controls.Add((Control)this.label31);
            this.tabDay.Controls.Add((Control)this.rbDayCycle);
            this.tabDay.Controls.Add((Control)this.numDayEvery);
            this.tabDay.Controls.Add((Control)this.numDayStart);
            this.tabDay.Controls.Add((Control)this.label32);
            this.tabDay.Controls.Add((Control)this.label33);
            this.tabDay.Controls.Add((Control)this.rbDay);
            this.tabDay.Controls.Add((Control)this.rbDayNoAppoint);
            this.tabDay.Controls.Add((Control)this.chkDay);
            this.tabDay.Controls.Add((Control)this.rbDayAppoint);
            this.tabDay.Controls.Add((Control)this.rbDayEvery);
            this.tabDay.Location = new Point(4, 22);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new Padding(3);
            this.tabDay.Size = new Size(821, 235);
            this.tabDay.TabIndex = 2;
            this.tabDay.Text = "日";
            this.tabDay.UseVisualStyleBackColor = true;
            this.rbDayL.AutoSize = true;
            this.rbDayL.Location = new Point(9, 194);
            this.rbDayL.Name = "rbDayL";
            this.rbDayL.Size = new Size(95, 16);
            this.rbDayL.TabIndex = 67;
            this.rbDayL.Text = "本月最后一天";
            this.rbDayL.UseVisualStyleBackColor = true;
            this.rbDayL.Click += new EventHandler(this.rbClick);
            this.label34.AutoSize = true;
            this.label34.Location = new Point(87, 169);
            this.label34.Name = "label34";
            this.label34.Size = new Size(113, 12);
            this.label34.TabIndex = 66;
            this.label34.Text = "号最近的那个工作日";
            this.numDayW.Enabled = false;
            this.numDayW.Location = new Point(54, 165);
            NumericUpDown numericUpDown31 = this.numDayW;
            int[] bits31 = new int[4];
            bits31[0] = 31;
            Decimal num31 = new Decimal(bits31);
            numericUpDown31.Maximum = num31;
            NumericUpDown numericUpDown32 = this.numDayW;
            int[] bits32 = new int[4];
            bits32[0] = 1;
            Decimal num32 = new Decimal(bits32);
            numericUpDown32.Minimum = num32;
            this.numDayW.Name = "numDayW";
            this.numDayW.Size = new Size(31, 21);
            this.numDayW.TabIndex = 65;
            this.numDayW.Tag = "numDayW";
            NumericUpDown numericUpDown33 = this.numDayW;
            int[] bits33 = new int[4];
            bits33[0] = 1;
            Decimal num33 = new Decimal(bits33);
            numericUpDown33.Value = num33;
            this.numDayW.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.rbDayW.AutoSize = true;
            this.rbDayW.Location = new Point(9, 167);
            this.rbDayW.Name = "rbDayW";
            this.rbDayW.Size = new Size(47, 16);
            this.rbDayW.TabIndex = 64;
            this.rbDayW.Text = "每月";
            this.rbDayW.UseVisualStyleBackColor = true;
            this.rbDayW.Click += new EventHandler(this.rbClick);
            this.numDayCO.Enabled = false;
            this.numDayCO.Location = new Point(118, 110);
            NumericUpDown numericUpDown34 = this.numDayCO;
            int[] bits34 = new int[4];
            bits34[0] = 23;
            Decimal num34 = new Decimal(bits34);
            numericUpDown34.Maximum = num34;
            NumericUpDown numericUpDown35 = this.numDayCO;
            int[] bits35 = new int[4];
            bits35[0] = 2;
            Decimal num35 = new Decimal(bits35);
            numericUpDown35.Minimum = num35;
            this.numDayCO.Name = "numDayCO";
            this.numDayCO.Size = new Size(31, 21);
            this.numDayCO.TabIndex = 63;
            this.numDayCO.Tag = "numDayC";
            NumericUpDown numericUpDown36 = this.numDayCO;
            int[] bits36 = new int[4];
            bits36[0] = 2;
            Decimal num36 = new Decimal(bits36);
            numericUpDown36.Value = num36;
            this.numDayCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numDayCS.Enabled = false;
            this.numDayCS.Location = new Point(71, 110);
            NumericUpDown numericUpDown37 = this.numDayCS;
            int[] bits37 = new int[4];
            bits37[0] = 58;
            Decimal num37 = new Decimal(bits37);
            numericUpDown37.Maximum = num37;
            NumericUpDown numericUpDown38 = this.numDayCS;
            int[] bits38 = new int[4];
            bits38[0] = 1;
            Decimal num38 = new Decimal(bits38);
            numericUpDown38.Minimum = num38;
            this.numDayCS.Name = "numDayCS";
            this.numDayCS.Size = new Size(31, 21);
            this.numDayCS.TabIndex = 62;
            this.numDayCS.Tag = "numDayC";
            NumericUpDown numericUpDown39 = this.numDayCS;
            int[] bits39 = new int[4];
            bits39[0] = 1;
            Decimal num39 = new Decimal(bits39);
            numericUpDown39.Value = num39;
            this.numDayCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label30.AutoSize = true;
            this.label30.Location = new Point(104, 114);
            this.label30.Name = "label30";
            this.label30.Size = new Size(11, 12);
            this.label30.TabIndex = 61;
            this.label30.Text = "-";
            this.label31.AutoSize = true;
            this.label31.Location = new Point(152, 114);
            this.label31.Name = "label31";
            this.label31.Size = new Size(29, 12);
            this.label31.TabIndex = 60;
            this.label31.Text = "小时";
            this.rbDayCycle.AutoSize = true;
            this.rbDayCycle.Location = new Point(9, 112);
            this.rbDayCycle.Name = "rbDayCycle";
            this.rbDayCycle.Size = new Size(59, 16);
            this.rbDayCycle.TabIndex = 59;
            this.rbDayCycle.Text = "周期从";
            this.rbDayCycle.UseVisualStyleBackColor = true;
            this.rbDayCycle.Click += new EventHandler(this.rbClick);
            this.numDayEvery.Enabled = false;
            this.numDayEvery.Location = new Point(169, 135);
            NumericUpDown numericUpDown40 = this.numDayEvery;
            int[] bits40 = new int[4];
            bits40[0] = 30;
            Decimal num40 = new Decimal(bits40);
            numericUpDown40.Maximum = num40;
            NumericUpDown numericUpDown41 = this.numDayEvery;
            int[] bits41 = new int[4];
            bits41[0] = 1;
            Decimal num41 = new Decimal(bits41);
            numericUpDown41.Minimum = num41;
            this.numDayEvery.Name = "numDayEvery";
            this.numDayEvery.Size = new Size(57, 21);
            this.numDayEvery.TabIndex = 58;
            this.numDayEvery.Tag = "numDay";
            NumericUpDown numericUpDown42 = this.numDayEvery;
            int[] bits42 = new int[4];
            bits42[0] = 1;
            Decimal num42 = new Decimal(bits42);
            numericUpDown42.Value = num42;
            this.numDayEvery.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numDayStart.Enabled = false;
            this.numDayStart.Location = new Point(42, 135);
            NumericUpDown numericUpDown43 = this.numDayStart;
            int[] bits43 = new int[4];
            bits43[0] = 23;
            Decimal num43 = new Decimal(bits43);
            numericUpDown43.Maximum = num43;
            this.numDayStart.Name = "numDayStart";
            this.numDayStart.Size = new Size(52, 21);
            this.numDayStart.TabIndex = 57;
            this.numDayStart.Tag = "numDay";
            this.numDayStart.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label32.AutoSize = true;
            this.label32.Location = new Point(230, 139);
            this.label32.Name = "label32";
            this.label32.Size = new Size(65, 12);
            this.label32.TabIndex = 56;
            this.label32.Text = "天执行一次";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(98, 139);
            this.label33.Name = "label33";
            this.label33.Size = new Size(59, 12);
            this.label33.TabIndex = 55;
            this.label33.Text = "日开始,每";
            this.rbDay.AutoSize = true;
            this.rbDay.Location = new Point(9, 137);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new Size(35, 16);
            this.rbDay.TabIndex = 54;
            this.rbDay.Text = "从";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.Click += new EventHandler(this.rbClick);
            this.rbDayNoAppoint.AutoSize = true;
            this.rbDayNoAppoint.Location = new Point(8, 28);
            this.rbDayNoAppoint.Name = "rbDayNoAppoint";
            this.rbDayNoAppoint.Size = new Size(59, 16);
            this.rbDayNoAppoint.TabIndex = 24;
            this.rbDayNoAppoint.TabStop = true;
            this.rbDayNoAppoint.Text = "不指定";
            this.rbDayNoAppoint.UseVisualStyleBackColor = true;
            this.rbDayNoAppoint.Click += new EventHandler(this.rbClick);
            this.chkDay.BorderStyle = BorderStyle.None;
            this.chkDay.CheckOnClick = true;
            this.chkDay.ColumnWidth = 40;
            this.chkDay.Enabled = false;
            this.chkDay.FormattingEnabled = true;
            this.chkDay.Items.AddRange(new object[31]
            {
         "1",
         "17",
         "2",
         "18",
         "3",
         "19",
         "4",
         "20",
         "5",
         "21",
         "6",
         "22",
         "7",
         "23",
         "8",
         "24",
         "9",
         "25",
         "10",
         "26",
         "11",
         "27",
         "12",
         "28",
         "13",
         "29",
         "14",
         "30",
         "15",
         "31",
         "16"
            });
            this.chkDay.Location = new Point(26, 72);
            this.chkDay.MultiColumn = true;
            this.chkDay.Name = "chkDay";
            this.chkDay.Size = new Size(658, 32);
            this.chkDay.TabIndex = 23;
            this.chkDay.TabStop = false;
            this.chkDay.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.rbDayAppoint.AutoSize = true;
            this.rbDayAppoint.Location = new Point(8, 50);
            this.rbDayAppoint.Name = "rbDayAppoint";
            this.rbDayAppoint.Size = new Size(47, 16);
            this.rbDayAppoint.TabIndex = 22;
            this.rbDayAppoint.TabStop = true;
            this.rbDayAppoint.Text = "指定";
            this.rbDayAppoint.UseVisualStyleBackColor = true;
            this.rbDayAppoint.Click += new EventHandler(this.rbClick);
            this.rbDayEvery.AutoSize = true;
            this.rbDayEvery.Checked = true;
            this.rbDayEvery.Location = new Point(8, 6);
            this.rbDayEvery.Name = "rbDayEvery";
            this.rbDayEvery.Size = new Size(221, 16);
            this.rbDayEvery.TabIndex = 21;
            this.rbDayEvery.TabStop = true;
            this.rbDayEvery.Text = "每日 允许的通配符[ , - * ? / L W]";
            this.rbDayEvery.UseVisualStyleBackColor = true;
            this.rbDayEvery.Click += new EventHandler(this.rbClick);
            this.tabMouth.Controls.Add((Control)this.rbMouthNoAppoint);
            this.tabMouth.Controls.Add((Control)this.rbMouthEvery);
            this.tabMouth.Controls.Add((Control)this.numMouthEvery);
            this.tabMouth.Controls.Add((Control)this.numMouthStart);
            this.tabMouth.Controls.Add((Control)this.label9);
            this.tabMouth.Controls.Add((Control)this.label24);
            this.tabMouth.Controls.Add((Control)this.rbMouthCycle);
            this.tabMouth.Controls.Add((Control)this.numMouthCO);
            this.tabMouth.Controls.Add((Control)this.numMouthCS);
            this.tabMouth.Controls.Add((Control)this.label22);
            this.tabMouth.Controls.Add((Control)this.label23);
            this.tabMouth.Controls.Add((Control)this.chkMouth);
            this.tabMouth.Controls.Add((Control)this.rbMouthAppoint);
            this.tabMouth.Controls.Add((Control)this.rbMouth);
            this.tabMouth.Location = new Point(4, 22);
            this.tabMouth.Name = "tabMouth";
            this.tabMouth.Size = new Size(821, 235);
            this.tabMouth.TabIndex = 3;
            this.tabMouth.Text = "月";
            this.tabMouth.UseVisualStyleBackColor = true;
            this.rbMouthNoAppoint.AutoSize = true;
            this.rbMouthNoAppoint.Location = new Point(8, 31);
            this.rbMouthNoAppoint.Name = "rbMouthNoAppoint";
            this.rbMouthNoAppoint.Size = new Size(59, 16);
            this.rbMouthNoAppoint.TabIndex = 46;
            this.rbMouthNoAppoint.Text = "不指定";
            this.rbMouthNoAppoint.UseVisualStyleBackColor = true;
            this.rbMouthNoAppoint.Click += new EventHandler(this.rbClick);
            this.rbMouthEvery.AutoSize = true;
            this.rbMouthEvery.Checked = true;
            this.rbMouthEvery.Location = new Point(8, 6);
            this.rbMouthEvery.Name = "rbMouthEvery";
            this.rbMouthEvery.Size = new Size(185, 16);
            this.rbMouthEvery.TabIndex = 45;
            this.rbMouthEvery.TabStop = true;
            this.rbMouthEvery.Text = "每月 允许的通配符[ , - * /]";
            this.rbMouthEvery.UseVisualStyleBackColor = true;
            this.rbMouthEvery.Click += new EventHandler(this.rbClick);
            this.numMouthEvery.Location = new Point(158, 54);
            NumericUpDown numericUpDown44 = this.numMouthEvery;
            int[] bits44 = new int[4];
            bits44[0] = 12;
            Decimal num44 = new Decimal(bits44);
            numericUpDown44.Maximum = num44;
            NumericUpDown numericUpDown45 = this.numMouthEvery;
            int[] bits45 = new int[4];
            bits45[0] = 1;
            Decimal num45 = new Decimal(bits45);
            numericUpDown45.Minimum = num45;
            this.numMouthEvery.Name = "numMouthEvery";
            this.numMouthEvery.Size = new Size(43, 21);
            this.numMouthEvery.TabIndex = 44;
            this.numMouthEvery.Tag = "numMouth";
            NumericUpDown numericUpDown46 = this.numMouthEvery;
            int[] bits46 = new int[4];
            bits46[0] = 1;
            Decimal num46 = new Decimal(bits46);
            numericUpDown46.Value = num46;
            this.numMouthEvery.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numMouthStart.Location = new Point(43, 54);
            NumericUpDown numericUpDown47 = this.numMouthStart;
            int[] bits47 = new int[4];
            bits47[0] = 59;
            Decimal num47 = new Decimal(bits47);
            numericUpDown47.Maximum = num47;
            this.numMouthStart.Name = "numMouthStart";
            this.numMouthStart.Size = new Size(52, 21);
            this.numMouthStart.TabIndex = 43;
            this.numMouthStart.Tag = "numMouth";
            this.numMouthStart.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(203, 58);
            this.label9.Name = "label9";
            this.label9.Size = new Size(77, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "个月执行一次";
            this.label24.AutoSize = true;
            this.label24.Location = new Point(99, 58);
            this.label24.Name = "label24";
            this.label24.Size = new Size(59, 12);
            this.label24.TabIndex = 41;
            this.label24.Text = "日开始,每";
            this.rbMouthCycle.AutoSize = true;
            this.rbMouthCycle.Location = new Point(8, 106);
            this.rbMouthCycle.Name = "rbMouthCycle";
            this.rbMouthCycle.Size = new Size(59, 16);
            this.rbMouthCycle.TabIndex = 40;
            this.rbMouthCycle.Text = "周期从";
            this.rbMouthCycle.UseVisualStyleBackColor = true;
            this.rbMouthCycle.Click += new EventHandler(this.rbClick);
            this.numMouthCO.Enabled = false;
            this.numMouthCO.Location = new Point(114, 104);
            NumericUpDown numericUpDown48 = this.numMouthCO;
            int[] bits48 = new int[4];
            bits48[0] = 12;
            Decimal num48 = new Decimal(bits48);
            numericUpDown48.Maximum = num48;
            NumericUpDown numericUpDown49 = this.numMouthCO;
            int[] bits49 = new int[4];
            bits49[0] = 2;
            Decimal num49 = new Decimal(bits49);
            numericUpDown49.Minimum = num49;
            this.numMouthCO.Name = "numMouthCO";
            this.numMouthCO.Size = new Size(31, 21);
            this.numMouthCO.TabIndex = 39;
            NumericUpDown numericUpDown50 = this.numMouthCO;
            int[] bits50 = new int[4];
            bits50[0] = 2;
            Decimal num50 = new Decimal(bits50);
            numericUpDown50.Value = num50;
            this.numMouthCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numMouthCS.Enabled = false;
            this.numMouthCS.Location = new Point(67, 104);
            NumericUpDown numericUpDown51 = this.numMouthCS;
            int[] bits51 = new int[4];
            bits51[0] = 11;
            Decimal num51 = new Decimal(bits51);
            numericUpDown51.Maximum = num51;
            NumericUpDown numericUpDown52 = this.numMouthCS;
            int[] bits52 = new int[4];
            bits52[0] = 1;
            Decimal num52 = new Decimal(bits52);
            numericUpDown52.Minimum = num52;
            this.numMouthCS.Name = "numMouthCS";
            this.numMouthCS.Size = new Size(31, 21);
            this.numMouthCS.TabIndex = 38;
            NumericUpDown numericUpDown53 = this.numMouthCS;
            int[] bits53 = new int[4];
            bits53[0] = 1;
            Decimal num53 = new Decimal(bits53);
            numericUpDown53.Value = num53;
            this.numMouthCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label22.AutoSize = true;
            this.label22.Location = new Point(100, 108);
            this.label22.Name = "label22";
            this.label22.Size = new Size(11, 12);
            this.label22.TabIndex = 37;
            this.label22.Text = "-";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(148, 108);
            this.label23.Name = "label23";
            this.label23.Size = new Size(17, 12);
            this.label23.TabIndex = 36;
            this.label23.Text = "月";
            this.chkMouth.BorderStyle = BorderStyle.None;
            this.chkMouth.CheckOnClick = true;
            this.chkMouth.ColumnWidth = 40;
            this.chkMouth.Enabled = false;
            this.chkMouth.FormattingEnabled = true;
            this.chkMouth.Items.AddRange(new object[12]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8",
         "9",
         "10",
         "11",
         "12"
            });
            this.chkMouth.Location = new Point(61, 81);
            this.chkMouth.MultiColumn = true;
            this.chkMouth.Name = "chkMouth";
            this.chkMouth.Size = new Size(512, 16);
            this.chkMouth.TabIndex = 26;
            this.chkMouth.TabStop = false;
            this.chkMouth.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.rbMouthAppoint.AutoSize = true;
            this.rbMouthAppoint.Location = new Point(8, 81);
            this.rbMouthAppoint.Name = "rbMouthAppoint";
            this.rbMouthAppoint.Size = new Size(47, 16);
            this.rbMouthAppoint.TabIndex = 25;
            this.rbMouthAppoint.Text = "指定";
            this.rbMouthAppoint.UseVisualStyleBackColor = true;
            this.rbMouthAppoint.Click += new EventHandler(this.rbClick);
            this.rbMouth.AutoSize = true;
            this.rbMouth.Location = new Point(8, 56);
            this.rbMouth.Name = "rbMouth";
            this.rbMouth.Size = new Size(35, 16);
            this.rbMouth.TabIndex = 24;
            this.rbMouth.Text = "从";
            this.rbMouth.UseVisualStyleBackColor = true;
            this.rbMouth.Click += new EventHandler(this.rbClick);
            this.tabWeek.Controls.Add((Control)this.rbWeekLast);
            this.tabWeek.Controls.Add((Control)this.rbWeek);
            this.tabWeek.Controls.Add((Control)this.label19);
            this.tabWeek.Controls.Add((Control)this.numWeek);
            this.tabWeek.Controls.Add((Control)this.rbWeekNumIn);
            this.tabWeek.Controls.Add((Control)this.rbWeekNoAppoint);
            this.tabWeek.Controls.Add((Control)this.rbWeekCycle);
            this.tabWeek.Controls.Add((Control)this.numWeekCO);
            this.tabWeek.Controls.Add((Control)this.numWeekCS);
            this.tabWeek.Controls.Add((Control)this.label20);
            this.tabWeek.Controls.Add((Control)this.label21);
            this.tabWeek.Controls.Add((Control)this.chkWeek);
            this.tabWeek.Controls.Add((Control)this.rbWeekAppoint);
            this.tabWeek.Location = new Point(4, 22);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Size = new Size(821, 235);
            this.tabWeek.TabIndex = 4;
            this.tabWeek.Text = "周";
            this.tabWeek.UseVisualStyleBackColor = true;
            this.rbWeekLast.AutoSize = true;
            this.rbWeekLast.Location = new Point(173, 55);
            this.rbWeekLast.Name = "rbWeekLast";
            this.rbWeekLast.Size = new Size(131, 16);
            this.rbWeekLast.TabIndex = 41;
            this.rbWeekLast.Text = "本月最后一个星期几";
            this.rbWeekLast.UseVisualStyleBackColor = true;
            this.rbWeekLast.Click += new EventHandler(this.rbClick);
            this.rbWeek.AutoSize = true;
            this.rbWeek.Checked = true;
            this.rbWeek.Location = new Point(8, 6);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new Size(221, 16);
            this.rbWeek.TabIndex = 40;
            this.rbWeek.TabStop = true;
            this.rbWeek.Text = "每周 允许的通配符[ , - * ? / L #]";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.Click += new EventHandler(this.rbClick);
            this.label19.AutoSize = true;
            this.label19.Location = new Point(136, 57);
            this.label19.Name = "label19";
            this.label19.Size = new Size(17, 12);
            this.label19.TabIndex = 39;
            this.label19.Text = "周";
            this.numWeek.Enabled = false;
            this.numWeek.Location = new Point(102, 53);
            NumericUpDown numericUpDown54 = this.numWeek;
            int[] bits54 = new int[4];
            bits54[0] = 4;
            Decimal num54 = new Decimal(bits54);
            numericUpDown54.Maximum = num54;
            NumericUpDown numericUpDown55 = this.numWeek;
            int[] bits55 = new int[4];
            bits55[0] = 1;
            Decimal num55 = new Decimal(bits55);
            numericUpDown55.Minimum = num55;
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new Size(31, 21);
            this.numWeek.TabIndex = 38;
            NumericUpDown numericUpDown56 = this.numWeek;
            int[] bits56 = new int[4];
            bits56[0] = 1;
            Decimal num56 = new Decimal(bits56);
            numericUpDown56.Value = num56;
            this.rbWeekNumIn.AutoSize = true;
            this.rbWeekNumIn.Location = new Point(67, 55);
            this.rbWeekNumIn.Name = "rbWeekNumIn";
            this.rbWeekNumIn.Size = new Size(35, 16);
            this.rbWeekNumIn.TabIndex = 37;
            this.rbWeekNumIn.Text = "第";
            this.rbWeekNumIn.UseVisualStyleBackColor = true;
            this.rbWeekNumIn.Click += new EventHandler(this.rbClick);
            this.rbWeekNoAppoint.AutoSize = true;
            this.rbWeekNoAppoint.Location = new Point(8, 31);
            this.rbWeekNoAppoint.Name = "rbWeekNoAppoint";
            this.rbWeekNoAppoint.Size = new Size(59, 16);
            this.rbWeekNoAppoint.TabIndex = 36;
            this.rbWeekNoAppoint.Text = "不指定";
            this.rbWeekNoAppoint.UseVisualStyleBackColor = true;
            this.rbWeekNoAppoint.Click += new EventHandler(this.rbClick);
            this.rbWeekCycle.AutoSize = true;
            this.rbWeekCycle.Location = new Point(8, 101);
            this.rbWeekCycle.Name = "rbWeekCycle";
            this.rbWeekCycle.Size = new Size(47, 16);
            this.rbWeekCycle.TabIndex = 35;
            this.rbWeekCycle.Text = "周期";
            this.rbWeekCycle.UseVisualStyleBackColor = true;
            this.rbWeekCycle.Click += new EventHandler(this.rbClick);
            this.numWeekCO.Enabled = false;
            this.numWeekCO.Location = new Point(141, 99);
            NumericUpDown numericUpDown57 = this.numWeekCO;
            int[] bits57 = new int[4];
            bits57[0] = 7;
            Decimal num57 = new Decimal(bits57);
            numericUpDown57.Maximum = num57;
            NumericUpDown numericUpDown58 = this.numWeekCO;
            int[] bits58 = new int[4];
            bits58[0] = 2;
            Decimal num58 = new Decimal(bits58);
            numericUpDown58.Minimum = num58;
            this.numWeekCO.Name = "numWeekCO";
            this.numWeekCO.Size = new Size(31, 21);
            this.numWeekCO.TabIndex = 34;
            this.numWeekCO.Tag = "numWeekC";
            NumericUpDown numericUpDown59 = this.numWeekCO;
            int[] bits59 = new int[4];
            bits59[0] = 2;
            Decimal num59 = new Decimal(bits59);
            numericUpDown59.Value = num59;
            this.numWeekCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numWeekCS.Enabled = false;
            this.numWeekCS.Location = new Point(93, 99);
            NumericUpDown numericUpDown60 = this.numWeekCS;
            int[] bits60 = new int[4];
            bits60[0] = 6;
            Decimal num60 = new Decimal(bits60);
            numericUpDown60.Maximum = num60;
            NumericUpDown numericUpDown61 = this.numWeekCS;
            int[] bits61 = new int[4];
            bits61[0] = 1;
            Decimal num61 = new Decimal(bits61);
            numericUpDown61.Minimum = num61;
            this.numWeekCS.Name = "numWeekCS";
            this.numWeekCS.Size = new Size(31, 21);
            this.numWeekCS.TabIndex = 33;
            this.numWeekCS.Tag = "numWeekC";
            NumericUpDown numericUpDown62 = this.numWeekCS;
            int[] bits62 = new int[4];
            bits62[0] = 1;
            Decimal num62 = new Decimal(bits62);
            numericUpDown62.Value = num62;
            this.numWeekCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label20.AutoSize = true;
            this.label20.Location = new Point((int)sbyte.MaxValue, 103);
            this.label20.Name = "label20";
            this.label20.Size = new Size(11, 12);
            this.label20.TabIndex = 31;
            this.label20.Text = "-";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(52, 103);
            this.label21.Name = "label21";
            this.label21.Size = new Size(41, 12);
            this.label21.TabIndex = 30;
            this.label21.Text = "从星期";
            this.chkWeek.BorderStyle = BorderStyle.None;
            this.chkWeek.CheckOnClick = true;
            this.chkWeek.ColumnWidth = 50;
            this.chkWeek.FormattingEnabled = true;
            this.chkWeek.Items.AddRange(new object[7]
            {
         "SUN",
         "MON",
         "TUES",
         "WED",
         "THUR",
         "FRI",
         "SAT"
            });
            this.chkWeek.Location = new Point(26, 77);
            this.chkWeek.MultiColumn = true;
            this.chkWeek.Name = "chkWeek";
            this.chkWeek.Size = new Size(365, 16);
            this.chkWeek.TabIndex = 29;
            this.chkWeek.TabStop = false;
            this.chkWeek.SelectedValueChanged += new EventHandler(this.chk_SelectedValueChanged);
            this.rbWeekAppoint.AutoSize = true;
            this.rbWeekAppoint.Location = new Point(8, 55);
            this.rbWeekAppoint.Name = "rbWeekAppoint";
            this.rbWeekAppoint.Size = new Size(47, 16);
            this.rbWeekAppoint.TabIndex = 28;
            this.rbWeekAppoint.Text = "指定";
            this.rbWeekAppoint.UseVisualStyleBackColor = true;
            this.rbWeekAppoint.Click += new EventHandler(this.rbClick);
            this.tabYear.Controls.Add((Control)this.rbYearNoAppoint);
            this.tabYear.Controls.Add((Control)this.rbYearAppoint);
            this.tabYear.Controls.Add((Control)this.numYearCO);
            this.tabYear.Controls.Add((Control)this.numYearCS);
            this.tabYear.Controls.Add((Control)this.label15);
            this.tabYear.Controls.Add((Control)this.label16);
            this.tabYear.Controls.Add((Control)this.label17);
            this.tabYear.Controls.Add((Control)this.rbYear);
            this.tabYear.Location = new Point(4, 22);
            this.tabYear.Name = "tabYear";
            this.tabYear.Padding = new Padding(3);
            this.tabYear.Size = new Size(821, 235);
            this.tabYear.TabIndex = 5;
            this.tabYear.Text = "年";
            this.tabYear.UseVisualStyleBackColor = true;
            this.rbYearNoAppoint.AutoSize = true;
            this.rbYearNoAppoint.Checked = true;
            this.rbYearNoAppoint.Location = new Point(8, 6);
            this.rbYearNoAppoint.Name = "rbYearNoAppoint";
            this.rbYearNoAppoint.Size = new Size(233, 16);
            this.rbYearNoAppoint.TabIndex = 25;
            this.rbYearNoAppoint.TabStop = true;
            this.rbYearNoAppoint.Text = "未指定 允许的通配符[, - * /] 非必填";
            this.rbYearNoAppoint.UseVisualStyleBackColor = true;
            this.rbYearNoAppoint.Click += new EventHandler(this.rbClick);
            this.rbYearAppoint.AutoSize = true;
            this.rbYearAppoint.Location = new Point(8, 51);
            this.rbYearAppoint.Name = "rbYearAppoint";
            this.rbYearAppoint.Size = new Size(47, 16);
            this.rbYearAppoint.TabIndex = 24;
            this.rbYearAppoint.Text = "周期";
            this.rbYearAppoint.UseVisualStyleBackColor = true;
            this.rbYearAppoint.Click += new EventHandler(this.rbClick);
            this.numYearCO.Enabled = false;
            this.numYearCO.Location = new Point(141, 49);
            NumericUpDown numericUpDown63 = this.numYearCO;
            int[] bits63 = new int[4];
            bits63[0] = 59;
            Decimal num63 = new Decimal(bits63);
            numericUpDown63.Maximum = num63;
            NumericUpDown numericUpDown64 = this.numYearCO;
            int[] bits64 = new int[4];
            bits64[0] = 1;
            Decimal num64 = new Decimal(bits64);
            numericUpDown64.Minimum = num64;
            this.numYearCO.Name = "numYearCO";
            this.numYearCO.Size = new Size(57, 21);
            this.numYearCO.TabIndex = 23;
            this.numYearCO.Tag = "numYearC";
            NumericUpDown numericUpDown65 = this.numYearCO;
            int[] bits65 = new int[4];
            bits65[0] = 1;
            Decimal num65 = new Decimal(bits65);
            numericUpDown65.Value = num65;
            this.numYearCO.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.numYearCS.Enabled = false;
            this.numYearCS.Location = new Point(69, 49);
            NumericUpDown numericUpDown66 = this.numYearCS;
            int[] bits66 = new int[4];
            bits66[0] = 59;
            Decimal num66 = new Decimal(bits66);
            numericUpDown66.Maximum = num66;
            this.numYearCS.Name = "numYearCS";
            this.numYearCS.Size = new Size(52, 21);
            this.numYearCS.TabIndex = 22;
            this.numYearCS.Tag = "numYearC";
            this.numYearCS.ValueChanged += new EventHandler(this.num_ValueChanged);
            this.label15.AutoSize = true;
            this.label15.Location = new Point(202, 53);
            this.label15.Name = "label15";
            this.label15.Size = new Size(17, 12);
            this.label15.TabIndex = 21;
            this.label15.Text = "年";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(125, 53);
            this.label16.Name = "label16";
            this.label16.Size = new Size(11, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "-";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(52, 53);
            this.label17.Name = "label17";
            this.label17.Size = new Size(17, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "从";
            this.rbYear.AutoSize = true;
            this.rbYear.Location = new Point(8, 27);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new Size(47, 16);
            this.rbYear.TabIndex = 18;
            this.rbYear.Text = "每年";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.Click += new EventHandler(this.rbClick);
            this.tabIntro.Controls.Add((Control)this.textBox1);
            this.tabIntro.Location = new Point(4, 22);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Padding = new Padding(3);
            this.tabIntro.Size = new Size(821, 235);
            this.tabIntro.TabIndex = 6;
            this.tabIntro.Text = "cron-expression说明";
            this.tabIntro.UseVisualStyleBackColor = true;
            this.textBox1.BackColor = SystemColors.Window;
            this.textBox1.BorderStyle = BorderStyle.None;
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Location = new Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new Size(815, 229);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = componentResourceManager.GetString("textBox1.Text");
            this.gb1.Controls.Add((Control)this.label14);
            this.gb1.Controls.Add((Control)this.txtYear);
            this.gb1.Controls.Add((Control)this.btnCopy);
            this.gb1.Controls.Add((Control)this.label8);
            this.gb1.Controls.Add((Control)this.label7);
            this.gb1.Controls.Add((Control)this.label6);
            this.gb1.Controls.Add((Control)this.label5);
            this.gb1.Controls.Add((Control)this.label1);
            this.gb1.Controls.Add((Control)this.label4);
            this.gb1.Controls.Add((Control)this.txtCron);
            this.gb1.Controls.Add((Control)this.txtWeek);
            this.gb1.Controls.Add((Control)this.txtMonth);
            this.gb1.Controls.Add((Control)this.txtDay);
            this.gb1.Controls.Add((Control)this.txtHour);
            this.gb1.Controls.Add((Control)this.txtMinite);
            this.gb1.Controls.Add((Control)this.txtSecond);
            this.gb1.Controls.Add((Control)this.label3);
            this.gb1.Controls.Add((Control)this.label2);
            this.gb1.Dock = DockStyle.Top;
            this.gb1.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.gb1.Location = new Point(0, 261);
            this.gb1.Name = "gb1";
            this.gb1.Size = new Size(829, 116);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "表达式";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(705, 29);
            this.label14.Name = "label14";
            this.label14.Size = new Size(17, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "年";
            this.txtYear.BorderStyle = BorderStyle.FixedSingle;
            this.txtYear.Location = new Point(707, 54);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new Size(100, 21);
            this.txtYear.TabIndex = 19;
            this.txtYear.TextChanged += new EventHandler(this.txtChanged);
            this.btnCopy.Location = new Point(753, 80);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new Size(54, 23);
            this.btnCopy.TabIndex = 17;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new EventHandler(this.btnCopy_Click);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(190, 29);
            this.label8.Name = "label8";
            this.label8.Size = new Size(29, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "分钟";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(602, 29);
            this.label7.Name = "label7";
            this.label7.Size = new Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "星期";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(499, 29);
            this.label6.Name = "label6";
            this.label6.Size = new Size(17, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "月";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(293, 29);
            this.label5.Name = "label5";
            this.label5.Size = new Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "小时";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(396, 29);
            this.label1.Name = "label1";
            this.label1.Size = new Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "日";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(87, 29);
            this.label4.Name = "label4";
            this.label4.Size = new Size(17, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "秒";
            this.txtCron.BorderStyle = BorderStyle.FixedSingle;
            this.txtCron.Location = new Point(89, 82);
            this.txtCron.Name = "txtCron";
            this.txtCron.Size = new Size(658, 21);
            this.txtCron.TabIndex = 9;
            this.txtWeek.BorderStyle = BorderStyle.FixedSingle;
            this.txtWeek.Location = new Point(604, 54);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.Size = new Size(100, 21);
            this.txtWeek.TabIndex = 8;
            this.txtWeek.Text = "*";
            this.txtWeek.TextChanged += new EventHandler(this.txtChanged);
            this.txtMonth.BorderStyle = BorderStyle.FixedSingle;
            this.txtMonth.Location = new Point(501, 54);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new Size(100, 21);
            this.txtMonth.TabIndex = 7;
            this.txtMonth.Text = "*";
            this.txtMonth.TextChanged += new EventHandler(this.txtChanged);
            this.txtDay.BorderStyle = BorderStyle.FixedSingle;
            this.txtDay.Location = new Point(398, 54);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new Size(100, 21);
            this.txtDay.TabIndex = 6;
            this.txtDay.Text = "*";
            this.txtDay.TextChanged += new EventHandler(this.txtChanged);
            this.txtHour.BorderStyle = BorderStyle.FixedSingle;
            this.txtHour.Location = new Point(295, 54);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new Size(100, 21);
            this.txtHour.TabIndex = 5;
            this.txtHour.Text = "*";
            this.txtHour.TextChanged += new EventHandler(this.txtChanged);
            this.txtMinite.BorderStyle = BorderStyle.FixedSingle;
            this.txtMinite.Location = new Point(192, 54);
            this.txtMinite.Name = "txtMinite";
            this.txtMinite.Size = new Size(100, 21);
            this.txtMinite.TabIndex = 4;
            this.txtMinite.Text = "*";
            this.txtMinite.TextChanged += new EventHandler(this.txtChanged);
            this.txtSecond.BorderStyle = BorderStyle.FixedSingle;
            this.txtSecond.Location = new Point(89, 54);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new Size(100, 21);
            this.txtSecond.TabIndex = 3;
            this.txtSecond.Text = "*";
            this.txtSecond.TextChanged += new EventHandler(this.txtChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cron表达式：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "表达式字段：";
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(829, 392);
            this.Controls.Add((Control)this.gb1);
            this.Controls.Add((Control)this.tabTime);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimumSize = new Size(830, 430);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cron - senlin.huang";
            this.Load += new EventHandler(this.Form1_Load);
            this.tabTime.ResumeLayout(false);
            this.tabSecond.ResumeLayout(false);
            this.tabSecond.PerformLayout();
            this.numSecCO.EndInit();
            this.numSecCS.EndInit();
            this.numSecEvery.EndInit();
            this.numSecStart.EndInit();
            this.tabMinite.ResumeLayout(false);
            this.tabMinite.PerformLayout();
            this.numMinCO.EndInit();
            this.numMinCS.EndInit();
            this.numMinEvery.EndInit();
            this.numMinStart.EndInit();
            this.tabHour.ResumeLayout(false);
            this.tabHour.PerformLayout();
            this.numHourCO.EndInit();
            this.numHourCS.EndInit();
            this.numHourEvery.EndInit();
            this.numHourStart.EndInit();
            this.tabDay.ResumeLayout(false);
            this.tabDay.PerformLayout();
            this.numDayW.EndInit();
            this.numDayCO.EndInit();
            this.numDayCS.EndInit();
            this.numDayEvery.EndInit();
            this.numDayStart.EndInit();
            this.tabMouth.ResumeLayout(false);
            this.tabMouth.PerformLayout();
            this.numMouthEvery.EndInit();
            this.numMouthStart.EndInit();
            this.numMouthCO.EndInit();
            this.numMouthCS.EndInit();
            this.tabWeek.ResumeLayout(false);
            this.tabWeek.PerformLayout();
            this.numWeek.EndInit();
            this.numWeekCO.EndInit();
            this.numWeekCS.EndInit();
            this.tabYear.ResumeLayout(false);
            this.tabYear.PerformLayout();
            this.numYearCO.EndInit();
            this.numYearCS.EndInit();
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
