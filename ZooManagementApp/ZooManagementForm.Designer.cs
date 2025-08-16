//Quinn Keenan, 301504914, 08/08/2025

using Microsoft.VisualBasic.Logging;

namespace ZooManagementApp
{
    partial class ZooManagementForm : Form
    {
        private Panel activePanel;
        private Dictionary<PanelTag, Panel> panelMap = new Dictionary<PanelTag, Panel>();
        private System.ComponentModel.IContainer components = null;

        private void createPanelMap()
        {
            panelMap.Add(PanelTag.CreateNewAnimals, CreateNewAnimals);
            panelMap.Add(PanelTag.CreateNewService, CreateNewService);
            panelMap.Add(PanelTag.CreateNewVisitors, CreateNewVisitors); 
            panelMap.Add(PanelTag.Dashboard, Dashboard);
            panelMap.Add(PanelTag.EditAnimal, EditAnimal);
            panelMap.Add(PanelTag.Intro, Intro);
            panelMap.Add(PanelTag.LoadService, LoadService);
            panelMap.Add(PanelTag.Login, Login);
            panelMap.Add(PanelTag.ManageHabitats, ManageHabitats);
            panelMap.Add(PanelTag.ManagePasswords, ManagePasswords);
            panelMap.Add(PanelTag.ManageVisitors, ManageVisitors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZooManagementForm));
            Intro = new Panel();
            IntroLoadServiceBtn = new Button();
            IntroCreateNewServiceBtn = new Button();
            IntroTitleLbl = new Label();
            CreateNewService = new Panel();
            CreateNewServiceBackBtn = new Button();
            CreateNewServiceOutputLbl = new Label();
            CreateNewServiceBtn = new Button();
            CreateNewServiceConfirmPasswordInput = new TextBox();
            CreateNewServiceConfirmPasswordLbl = new Label();
            CreateNewServicePasswordInput = new TextBox();
            CreateNewServicePasswordLbl = new Label();
            CreateNewServiceNameInput = new TextBox();
            CreateNewServiceNameLbl = new Label();
            CreateNewServicePromptLbl = new Label();
            CreateNewServiceTitleLbl = new Label();
            Dashboard = new Panel();
            DashboardExportServiceBtn = new Button();
            DashboardManageVisitorsBtn = new Button();
            DashboardTitleLbl = new Label();
            DashboardLogOutBtn = new Button();
            DashboardManagePasswordsBtn = new Button();
            DashboardManageHabitatsBtn = new Button();
            DashboardPromptLbl = new Label();
            Login = new Panel();
            LoginBackBtn = new Button();
            LoginTitleLbl = new Label();
            LoginBtn = new Button();
            LoginOutputLbl = new Label();
            LoginPasswordInput = new TextBox();
            LoginPasswordLbl = new Label();
            ManagePasswords = new Panel();
            ManagePasswordsPromptLbl = new Label();
            ManagePasswordsBackBtn = new Button();
            ManagePasswordsRemovePasscodesBtn = new Button();
            ManagePasswordsAddPasscodesBtn = new Button();
            ManagePasswordsListBox = new ListBox();
            ManagePasswordsTitleLbl = new Label();
            ManageHabitats = new Panel();
            ManageHabitatsEditAnimalBtn = new Button();
            ManageHabitatsBackBtn = new Button();
            ManageHabitatsOutputLbl = new Label();
            ManageHabitatsTotalWeightBtn = new Button();
            ManageHabitatsAvgAgeBtn = new Button();
            ManageHabitatsFeedAllBtn = new Button();
            ManageHabitatsRemoveAnimalsBtn = new Button();
            ManageHabitatsAddAnimalsBtn = new Button();
            ManageHabitatsAnimalsListBox = new ListBox();
            ManageHabitatsAnimalsPromptLbl = new Label();
            ManageHabitatsAnimalsTitleLbl = new Label();
            ManageHabitatsRemoveHabitatsBtn = new Button();
            ManageHabitatsAddHabitatsBtn = new Button();
            ManageHabitatsHabitatsListBox = new ListBox();
            ManageHabitatsHabitatsPromptLbl = new Label();
            ManageHabitatsHabitatsTitleLbl = new Label();
            CreateNewAnimals = new Panel();
            CreateNewAnimalsOutputLbl = new Label();
            CreateNewAnimalsHungerLevelInput = new TextBox();
            CreateNewAnimalsHungerLevelLbl = new Label();
            CreateNewAnimalsWeightInput = new TextBox();
            CreateNewAnimalsWeightLbl = new Label();
            CreateNewAnimalsBackBtn = new Button();
            CreateNewAnimalsBtn = new Button();
            CreateNewAnimalsNameInput = new TextBox();
            CreateNewAnimalsNameLbl = new Label();
            CreateNewAnimalsAgeInput = new TextBox();
            CreateNewAnimalsAgeLbl = new Label();
            CreateNewAnimalsFoodTypeListBox = new ListBox();
            CreateNewAnimalsAnimalTypeListBox = new ListBox();
            CreateNewAnimalsFoodTypeLbl = new Label();
            CreateNewAnimalsAnimalTypeLbl = new Label();
            CreateNewAnimalsTitleLbl = new Label();
            CreateNewVisitors = new Panel();
            CreateNewVisitorsOutputLbl = new Label();
            CreateNewVisitorsBackBtn = new Button();
            CreateNewVisitorsBtn = new Button();
            CreateNewVisitorsPhoneNumberInput = new TextBox();
            CreateNewVisitorsPhoneNumberLbl = new Label();
            CreateNewVisitorsEmailInput = new TextBox();
            CreateNewVisitorsEmailLbl = new Label();
            CreateNewVisitorsAgeInput = new TextBox();
            CreateNewVisitorsAgeLbl = new Label();
            CreateNewVisitorsNameInput = new TextBox();
            CreateNewVisitorsNameLbl = new Label();
            CreateNewVisitorsTitleLbl = new Label();
            ManageVisitors = new Panel();
            ManageVisitorsBackBtn = new Button();
            ManageVisitorsRemoveVisitorsBtn = new Button();
            ManageVisitorsAddVisitorsBtn = new Button();
            ManageVisitorsListBox = new ListBox();
            ManageVisitorsTitleLbl = new Label();
            LoadService = new Panel();
            LoadServiceBackBtn = new Button();
            LoadServiceBtn = new Button();
            LoadServiceListBox = new ListBox();
            LoadServiceTitleLbl = new Label();
            EditAnimal = new Panel();
            EditAnimalFeedListBox = new ListBox();
            EditAnimalFeedAnimalLbl = new Label();
            EditAnimalGreetBtn = new Button();
            EditAnimalBackBtn = new Button();
            EditAnimalOutputLbl = new Label();
            EditAnimalTitleLbl = new Label();
            EditAnimalFeedBtn = new Button();
            EditAnimalWeightInput = new TextBox();
            EditAnimalWeightLbl = new Label();
            EditAnimalBtn = new Button();
            EditAnimalHungerLevelInput = new TextBox();
            EditAnimalHungerLevelLbl = new Label();
            EditAnimalAgeInput = new TextBox();
            EditAnimalAgeLbl = new Label();
            EditAnimalDietListBox = new ListBox();
            EditAnimalLbl = new Label();
            Intro.SuspendLayout();
            CreateNewService.SuspendLayout();
            Dashboard.SuspendLayout();
            Login.SuspendLayout();
            ManagePasswords.SuspendLayout();
            ManageHabitats.SuspendLayout();
            CreateNewAnimals.SuspendLayout();
            CreateNewVisitors.SuspendLayout();
            ManageVisitors.SuspendLayout();
            LoadService.SuspendLayout();
            EditAnimal.SuspendLayout();
            SuspendLayout();
            // 
            // Intro
            // 
            Intro.BorderStyle = BorderStyle.FixedSingle;
            Intro.Controls.Add(IntroLoadServiceBtn);
            Intro.Controls.Add(IntroCreateNewServiceBtn);
            Intro.Controls.Add(IntroTitleLbl);
            resources.ApplyResources(Intro, "Intro");
            Intro.Name = "Intro";
            Intro.Tag = "Intro";
            // 
            // IntroLoadServiceBtn
            // 
            IntroLoadServiceBtn.BackColor = Color.Lime;
            resources.ApplyResources(IntroLoadServiceBtn, "IntroLoadServiceBtn");
            IntroLoadServiceBtn.Name = "IntroLoadServiceBtn";
            IntroLoadServiceBtn.Tag = "Intro";
            IntroLoadServiceBtn.UseVisualStyleBackColor = false;
            IntroLoadServiceBtn.Click += IntroLoadServiceBtn_Click;
            // 
            // IntroCreateNewServiceBtn
            // 
            IntroCreateNewServiceBtn.BackColor = Color.Lime;
            resources.ApplyResources(IntroCreateNewServiceBtn, "IntroCreateNewServiceBtn");
            IntroCreateNewServiceBtn.Name = "IntroCreateNewServiceBtn";
            IntroCreateNewServiceBtn.Tag = "Intro";
            IntroCreateNewServiceBtn.UseVisualStyleBackColor = false;
            IntroCreateNewServiceBtn.Click += IntroCreateNewServiceBtn_Click;
            // 
            // IntroTitleLbl
            // 
            resources.ApplyResources(IntroTitleLbl, "IntroTitleLbl");
            IntroTitleLbl.Name = "IntroTitleLbl";
            IntroTitleLbl.Tag = "Intro";
            // 
            // CreateNewService
            // 
            CreateNewService.Controls.Add(CreateNewServiceBackBtn);
            CreateNewService.Controls.Add(CreateNewServiceOutputLbl);
            CreateNewService.Controls.Add(CreateNewServiceBtn);
            CreateNewService.Controls.Add(CreateNewServiceConfirmPasswordInput);
            CreateNewService.Controls.Add(CreateNewServiceConfirmPasswordLbl);
            CreateNewService.Controls.Add(CreateNewServicePasswordInput);
            CreateNewService.Controls.Add(CreateNewServicePasswordLbl);
            CreateNewService.Controls.Add(CreateNewServiceNameInput);
            CreateNewService.Controls.Add(CreateNewServiceNameLbl);
            CreateNewService.Controls.Add(CreateNewServicePromptLbl);
            CreateNewService.Controls.Add(CreateNewServiceTitleLbl);
            resources.ApplyResources(CreateNewService, "CreateNewService");
            CreateNewService.Name = "CreateNewService";
            CreateNewService.Tag = "CreateNewService";
            // 
            // CreateNewServiceBackBtn
            // 
            CreateNewServiceBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewServiceBackBtn, "CreateNewServiceBackBtn");
            CreateNewServiceBackBtn.Name = "CreateNewServiceBackBtn";
            CreateNewServiceBackBtn.Tag = "CreateNewService";
            CreateNewServiceBackBtn.UseVisualStyleBackColor = false;
            CreateNewServiceBackBtn.Click += CreateNewServiceBackBtn_Click;
            // 
            // CreateNewServiceOutputLbl
            // 
            resources.ApplyResources(CreateNewServiceOutputLbl, "CreateNewServiceOutputLbl");
            CreateNewServiceOutputLbl.Name = "CreateNewServiceOutputLbl";
            CreateNewServiceOutputLbl.Tag = "CreateNewService";
            // 
            // CreateNewServiceBtn
            // 
            CreateNewServiceBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewServiceBtn, "CreateNewServiceBtn");
            CreateNewServiceBtn.Name = "CreateNewServiceBtn";
            CreateNewServiceBtn.Tag = "CreateNewService";
            CreateNewServiceBtn.UseVisualStyleBackColor = false;
            CreateNewServiceBtn.Click += CreateNewServiceBtn_Click;
            // 
            // CreateNewServiceConfirmPasswordInput
            // 
            CreateNewServiceConfirmPasswordInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewServiceConfirmPasswordInput, "CreateNewServiceConfirmPasswordInput");
            CreateNewServiceConfirmPasswordInput.Name = "CreateNewServiceConfirmPasswordInput";
            CreateNewServiceConfirmPasswordInput.Tag = "CreateNewService";
            CreateNewServiceConfirmPasswordInput.TextChanged += CreateNewServiceInput_TextChanged;
            // 
            // CreateNewServiceConfirmPasswordLbl
            // 
            resources.ApplyResources(CreateNewServiceConfirmPasswordLbl, "CreateNewServiceConfirmPasswordLbl");
            CreateNewServiceConfirmPasswordLbl.Name = "CreateNewServiceConfirmPasswordLbl";
            CreateNewServiceConfirmPasswordLbl.Tag = "CreateNewService";
            // 
            // CreateNewServicePasswordInput
            // 
            CreateNewServicePasswordInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewServicePasswordInput, "CreateNewServicePasswordInput");
            CreateNewServicePasswordInput.Name = "CreateNewServicePasswordInput";
            CreateNewServicePasswordInput.Tag = "CreateNewService";
            CreateNewServicePasswordInput.TextChanged += CreateNewServiceInput_TextChanged;
            // 
            // CreateNewServicePasswordLbl
            // 
            resources.ApplyResources(CreateNewServicePasswordLbl, "CreateNewServicePasswordLbl");
            CreateNewServicePasswordLbl.Name = "CreateNewServicePasswordLbl";
            CreateNewServicePasswordLbl.Tag = "CreateNewService";
            // 
            // CreateNewServiceNameInput
            // 
            CreateNewServiceNameInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewServiceNameInput, "CreateNewServiceNameInput");
            CreateNewServiceNameInput.Name = "CreateNewServiceNameInput";
            CreateNewServiceNameInput.Tag = "CreateNewService";
            CreateNewServiceNameInput.TextChanged += CreateNewServiceInput_TextChanged;
            // 
            // CreateNewServiceNameLbl
            // 
            resources.ApplyResources(CreateNewServiceNameLbl, "CreateNewServiceNameLbl");
            CreateNewServiceNameLbl.Name = "CreateNewServiceNameLbl";
            CreateNewServiceNameLbl.Tag = "CreateNewService";
            // 
            // CreateNewServicePromptLbl
            // 
            resources.ApplyResources(CreateNewServicePromptLbl, "CreateNewServicePromptLbl");
            CreateNewServicePromptLbl.Name = "CreateNewServicePromptLbl";
            CreateNewServicePromptLbl.Tag = "CreateNewService";
            // 
            // CreateNewServiceTitleLbl
            // 
            resources.ApplyResources(CreateNewServiceTitleLbl, "CreateNewServiceTitleLbl");
            CreateNewServiceTitleLbl.Name = "CreateNewServiceTitleLbl";
            CreateNewServiceTitleLbl.Tag = "CreateNewService";
            // 
            // Dashboard
            // 
            Dashboard.Controls.Add(DashboardExportServiceBtn);
            Dashboard.Controls.Add(DashboardManageVisitorsBtn);
            Dashboard.Controls.Add(DashboardTitleLbl);
            Dashboard.Controls.Add(DashboardLogOutBtn);
            Dashboard.Controls.Add(DashboardManagePasswordsBtn);
            Dashboard.Controls.Add(DashboardManageHabitatsBtn);
            Dashboard.Controls.Add(DashboardPromptLbl);
            resources.ApplyResources(Dashboard, "Dashboard");
            Dashboard.Name = "Dashboard";
            Dashboard.Tag = "Dashboard";
            // 
            // DashboardExportServiceBtn
            // 
            DashboardExportServiceBtn.BackColor = Color.Lime;
            resources.ApplyResources(DashboardExportServiceBtn, "DashboardExportServiceBtn");
            DashboardExportServiceBtn.Name = "DashboardExportServiceBtn";
            DashboardExportServiceBtn.Tag = "Dashboard";
            DashboardExportServiceBtn.UseVisualStyleBackColor = false;
            DashboardExportServiceBtn.Click += DashboardExportServiceBtn_Click;
            // 
            // DashboardManageVisitorsBtn
            // 
            DashboardManageVisitorsBtn.BackColor = Color.Lime;
            resources.ApplyResources(DashboardManageVisitorsBtn, "DashboardManageVisitorsBtn");
            DashboardManageVisitorsBtn.Name = "DashboardManageVisitorsBtn";
            DashboardManageVisitorsBtn.Tag = "Dashboard";
            DashboardManageVisitorsBtn.UseVisualStyleBackColor = false;
            DashboardManageVisitorsBtn.Click += DashboardManageVisitorsBtn_Click;
            // 
            // DashboardTitleLbl
            // 
            resources.ApplyResources(DashboardTitleLbl, "DashboardTitleLbl");
            DashboardTitleLbl.Name = "DashboardTitleLbl";
            DashboardTitleLbl.Tag = "Dashboard";
            // 
            // DashboardLogOutBtn
            // 
            DashboardLogOutBtn.BackColor = Color.Lime;
            resources.ApplyResources(DashboardLogOutBtn, "DashboardLogOutBtn");
            DashboardLogOutBtn.Name = "DashboardLogOutBtn";
            DashboardLogOutBtn.Tag = "Dashboard";
            DashboardLogOutBtn.UseVisualStyleBackColor = false;
            DashboardLogOutBtn.Click += DashboardLogOutBtn_Click;
            // 
            // DashboardManagePasswordsBtn
            // 
            DashboardManagePasswordsBtn.BackColor = Color.Lime;
            resources.ApplyResources(DashboardManagePasswordsBtn, "DashboardManagePasswordsBtn");
            DashboardManagePasswordsBtn.Name = "DashboardManagePasswordsBtn";
            DashboardManagePasswordsBtn.Tag = "Dashboard";
            DashboardManagePasswordsBtn.UseVisualStyleBackColor = false;
            DashboardManagePasswordsBtn.Click += DashboardManagePasswordsBtn_Click;
            // 
            // DashboardManageHabitatsBtn
            // 
            DashboardManageHabitatsBtn.BackColor = Color.Lime;
            resources.ApplyResources(DashboardManageHabitatsBtn, "DashboardManageHabitatsBtn");
            DashboardManageHabitatsBtn.Name = "DashboardManageHabitatsBtn";
            DashboardManageHabitatsBtn.Tag = "Dashboard";
            DashboardManageHabitatsBtn.UseVisualStyleBackColor = false;
            DashboardManageHabitatsBtn.Click += DashboardManageHabitatsBtn_Click;
            // 
            // DashboardPromptLbl
            // 
            resources.ApplyResources(DashboardPromptLbl, "DashboardPromptLbl");
            DashboardPromptLbl.Name = "DashboardPromptLbl";
            DashboardPromptLbl.Tag = "Dashboard";
            // 
            // Login
            // 
            Login.Controls.Add(LoginBackBtn);
            Login.Controls.Add(LoginTitleLbl);
            Login.Controls.Add(LoginBtn);
            Login.Controls.Add(LoginOutputLbl);
            Login.Controls.Add(LoginPasswordInput);
            Login.Controls.Add(LoginPasswordLbl);
            resources.ApplyResources(Login, "Login");
            Login.Name = "Login";
            Login.Tag = "Login";
            // 
            // LoginBackBtn
            // 
            LoginBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(LoginBackBtn, "LoginBackBtn");
            LoginBackBtn.Name = "LoginBackBtn";
            LoginBackBtn.Tag = "Login";
            LoginBackBtn.UseVisualStyleBackColor = false;
            LoginBackBtn.Click += LoginBackBtn_Click;
            // 
            // LoginTitleLbl
            // 
            resources.ApplyResources(LoginTitleLbl, "LoginTitleLbl");
            LoginTitleLbl.Name = "LoginTitleLbl";
            LoginTitleLbl.Tag = "Login";
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.Lime;
            resources.ApplyResources(LoginBtn, "LoginBtn");
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Tag = "Login";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // LoginOutputLbl
            // 
            resources.ApplyResources(LoginOutputLbl, "LoginOutputLbl");
            LoginOutputLbl.Name = "LoginOutputLbl";
            LoginOutputLbl.Tag = "Login";
            // 
            // LoginPasswordInput
            // 
            LoginPasswordInput.BackColor = Color.LightYellow;
            resources.ApplyResources(LoginPasswordInput, "LoginPasswordInput");
            LoginPasswordInput.Name = "LoginPasswordInput";
            LoginPasswordInput.Tag = "Login";
            LoginPasswordInput.TextChanged += LoginPasswordInput_TextChanged;
            // 
            // LoginPasswordLbl
            // 
            resources.ApplyResources(LoginPasswordLbl, "LoginPasswordLbl");
            LoginPasswordLbl.Name = "LoginPasswordLbl";
            LoginPasswordLbl.Tag = "Login";
            // 
            // ManagePasswords
            // 
            ManagePasswords.Controls.Add(ManagePasswordsPromptLbl);
            ManagePasswords.Controls.Add(ManagePasswordsBackBtn);
            ManagePasswords.Controls.Add(ManagePasswordsRemovePasscodesBtn);
            ManagePasswords.Controls.Add(ManagePasswordsAddPasscodesBtn);
            ManagePasswords.Controls.Add(ManagePasswordsListBox);
            ManagePasswords.Controls.Add(ManagePasswordsTitleLbl);
            resources.ApplyResources(ManagePasswords, "ManagePasswords");
            ManagePasswords.Name = "ManagePasswords";
            ManagePasswords.Tag = "ManagePasswords";
            // 
            // ManagePasswordsPromptLbl
            // 
            resources.ApplyResources(ManagePasswordsPromptLbl, "ManagePasswordsPromptLbl");
            ManagePasswordsPromptLbl.Name = "ManagePasswordsPromptLbl";
            ManagePasswordsPromptLbl.Tag = "ManagePasswords";
            // 
            // ManagePasswordsBackBtn
            // 
            ManagePasswordsBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManagePasswordsBackBtn, "ManagePasswordsBackBtn");
            ManagePasswordsBackBtn.Name = "ManagePasswordsBackBtn";
            ManagePasswordsBackBtn.Tag = "ManagePasswords";
            ManagePasswordsBackBtn.UseVisualStyleBackColor = false;
            ManagePasswordsBackBtn.Click += ManagePasswordsBackBtn_Click;
            // 
            // ManagePasswordsRemovePasscodesBtn
            // 
            ManagePasswordsRemovePasscodesBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManagePasswordsRemovePasscodesBtn, "ManagePasswordsRemovePasscodesBtn");
            ManagePasswordsRemovePasscodesBtn.Name = "ManagePasswordsRemovePasscodesBtn";
            ManagePasswordsRemovePasscodesBtn.Tag = "ManagePasswords";
            ManagePasswordsRemovePasscodesBtn.UseVisualStyleBackColor = false;
            ManagePasswordsRemovePasscodesBtn.Click += ManagePasswordsRemovePasswordsBtn_Click;
            // 
            // ManagePasswordsAddPasscodesBtn
            // 
            ManagePasswordsAddPasscodesBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManagePasswordsAddPasscodesBtn, "ManagePasswordsAddPasscodesBtn");
            ManagePasswordsAddPasscodesBtn.Name = "ManagePasswordsAddPasscodesBtn";
            ManagePasswordsAddPasscodesBtn.Tag = "ManagePasswords";
            ManagePasswordsAddPasscodesBtn.UseVisualStyleBackColor = false;
            ManagePasswordsAddPasscodesBtn.Click += ManagePasswordsAddPasswordsBtn_Click;
            // 
            // ManagePasswordsListBox
            // 
            ManagePasswordsListBox.BackColor = Color.LightYellow;
            resources.ApplyResources(ManagePasswordsListBox, "ManagePasswordsListBox");
            ManagePasswordsListBox.FormattingEnabled = true;
            ManagePasswordsListBox.Name = "ManagePasswordsListBox";
            ManagePasswordsListBox.SelectionMode = SelectionMode.MultiExtended;
            ManagePasswordsListBox.Tag = "ManagePasswords";
            // 
            // ManagePasswordsTitleLbl
            // 
            resources.ApplyResources(ManagePasswordsTitleLbl, "ManagePasswordsTitleLbl");
            ManagePasswordsTitleLbl.Name = "ManagePasswordsTitleLbl";
            ManagePasswordsTitleLbl.Tag = "ManagePasswords";
            // 
            // ManageHabitats
            // 
            ManageHabitats.Controls.Add(ManageHabitatsEditAnimalBtn);
            ManageHabitats.Controls.Add(ManageHabitatsBackBtn);
            ManageHabitats.Controls.Add(ManageHabitatsOutputLbl);
            ManageHabitats.Controls.Add(ManageHabitatsTotalWeightBtn);
            ManageHabitats.Controls.Add(ManageHabitatsAvgAgeBtn);
            ManageHabitats.Controls.Add(ManageHabitatsFeedAllBtn);
            ManageHabitats.Controls.Add(ManageHabitatsRemoveAnimalsBtn);
            ManageHabitats.Controls.Add(ManageHabitatsAddAnimalsBtn);
            ManageHabitats.Controls.Add(ManageHabitatsAnimalsListBox);
            ManageHabitats.Controls.Add(ManageHabitatsAnimalsPromptLbl);
            ManageHabitats.Controls.Add(ManageHabitatsAnimalsTitleLbl);
            ManageHabitats.Controls.Add(ManageHabitatsRemoveHabitatsBtn);
            ManageHabitats.Controls.Add(ManageHabitatsAddHabitatsBtn);
            ManageHabitats.Controls.Add(ManageHabitatsHabitatsListBox);
            ManageHabitats.Controls.Add(ManageHabitatsHabitatsPromptLbl);
            ManageHabitats.Controls.Add(ManageHabitatsHabitatsTitleLbl);
            resources.ApplyResources(ManageHabitats, "ManageHabitats");
            ManageHabitats.Name = "ManageHabitats";
            ManageHabitats.Tag = "ManageHabitats";
            // 
            // ManageHabitatsEditAnimalBtn
            // 
            ManageHabitatsEditAnimalBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsEditAnimalBtn, "ManageHabitatsEditAnimalBtn");
            ManageHabitatsEditAnimalBtn.Name = "ManageHabitatsEditAnimalBtn";
            ManageHabitatsEditAnimalBtn.Tag = "ManageHabitats";
            ManageHabitatsEditAnimalBtn.UseVisualStyleBackColor = false;
            ManageHabitatsEditAnimalBtn.Click += ManageHabitatsEditAnimalBtn_Click;
            // 
            // ManageHabitatsBackBtn
            // 
            ManageHabitatsBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsBackBtn, "ManageHabitatsBackBtn");
            ManageHabitatsBackBtn.Name = "ManageHabitatsBackBtn";
            ManageHabitatsBackBtn.Tag = "ManageHabitats";
            ManageHabitatsBackBtn.UseVisualStyleBackColor = false;
            ManageHabitatsBackBtn.Click += ManageHabitatsBackBtn_Click;
            // 
            // ManageHabitatsOutputLbl
            // 
            resources.ApplyResources(ManageHabitatsOutputLbl, "ManageHabitatsOutputLbl");
            ManageHabitatsOutputLbl.Name = "ManageHabitatsOutputLbl";
            ManageHabitatsOutputLbl.Tag = "ManageHabitats";
            // 
            // ManageHabitatsTotalWeightBtn
            // 
            ManageHabitatsTotalWeightBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsTotalWeightBtn, "ManageHabitatsTotalWeightBtn");
            ManageHabitatsTotalWeightBtn.Name = "ManageHabitatsTotalWeightBtn";
            ManageHabitatsTotalWeightBtn.Tag = "ManageHabitats";
            ManageHabitatsTotalWeightBtn.UseVisualStyleBackColor = false;
            ManageHabitatsTotalWeightBtn.Click += ManageHabitatsTotalWeightBtn_Click;
            // 
            // ManageHabitatsAvgAgeBtn
            // 
            ManageHabitatsAvgAgeBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsAvgAgeBtn, "ManageHabitatsAvgAgeBtn");
            ManageHabitatsAvgAgeBtn.Name = "ManageHabitatsAvgAgeBtn";
            ManageHabitatsAvgAgeBtn.Tag = "ManageHabitats";
            ManageHabitatsAvgAgeBtn.UseVisualStyleBackColor = false;
            ManageHabitatsAvgAgeBtn.Click += ManageHabitatsAvgAgeBtn_Click;
            // 
            // ManageHabitatsFeedAllBtn
            // 
            ManageHabitatsFeedAllBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsFeedAllBtn, "ManageHabitatsFeedAllBtn");
            ManageHabitatsFeedAllBtn.Name = "ManageHabitatsFeedAllBtn";
            ManageHabitatsFeedAllBtn.Tag = "ManageHabitats";
            ManageHabitatsFeedAllBtn.UseVisualStyleBackColor = false;
            ManageHabitatsFeedAllBtn.Click += ManageHabitatsFeedAllBtn_Click;
            // 
            // ManageHabitatsRemoveAnimalsBtn
            // 
            ManageHabitatsRemoveAnimalsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsRemoveAnimalsBtn, "ManageHabitatsRemoveAnimalsBtn");
            ManageHabitatsRemoveAnimalsBtn.Name = "ManageHabitatsRemoveAnimalsBtn";
            ManageHabitatsRemoveAnimalsBtn.Tag = "ManageHabitats";
            ManageHabitatsRemoveAnimalsBtn.UseVisualStyleBackColor = false;
            ManageHabitatsRemoveAnimalsBtn.Click += ManageHabitatsRemoveAnimalsBtn_Click;
            // 
            // ManageHabitatsAddAnimalsBtn
            // 
            ManageHabitatsAddAnimalsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsAddAnimalsBtn, "ManageHabitatsAddAnimalsBtn");
            ManageHabitatsAddAnimalsBtn.Name = "ManageHabitatsAddAnimalsBtn";
            ManageHabitatsAddAnimalsBtn.Tag = "ManageHabitats";
            ManageHabitatsAddAnimalsBtn.UseVisualStyleBackColor = false;
            ManageHabitatsAddAnimalsBtn.Click += ManageHabitatsAddAnimalsBtn_Click;
            // 
            // ManageHabitatsAnimalsListBox
            // 
            ManageHabitatsAnimalsListBox.BackColor = Color.LightYellow;
            ManageHabitatsAnimalsListBox.DisplayMember = "ManageHabitats";
            resources.ApplyResources(ManageHabitatsAnimalsListBox, "ManageHabitatsAnimalsListBox");
            ManageHabitatsAnimalsListBox.FormattingEnabled = true;
            ManageHabitatsAnimalsListBox.Name = "ManageHabitatsAnimalsListBox";
            ManageHabitatsAnimalsListBox.SelectionMode = SelectionMode.MultiExtended;
            ManageHabitatsAnimalsListBox.Tag = "ManagePasswords";
            ManageHabitatsAnimalsListBox.ValueMember = "ManageHabitats";
            ManageHabitatsAnimalsListBox.SelectedIndexChanged += ManageHabitatsAnimalsListBox_SelectedIndexChanged;
            // 
            // ManageHabitatsAnimalsPromptLbl
            // 
            resources.ApplyResources(ManageHabitatsAnimalsPromptLbl, "ManageHabitatsAnimalsPromptLbl");
            ManageHabitatsAnimalsPromptLbl.Name = "ManageHabitatsAnimalsPromptLbl";
            ManageHabitatsAnimalsPromptLbl.Tag = "ManageHabitats";
            // 
            // ManageHabitatsAnimalsTitleLbl
            // 
            resources.ApplyResources(ManageHabitatsAnimalsTitleLbl, "ManageHabitatsAnimalsTitleLbl");
            ManageHabitatsAnimalsTitleLbl.Name = "ManageHabitatsAnimalsTitleLbl";
            ManageHabitatsAnimalsTitleLbl.Tag = "ManageHabitats";
            // 
            // ManageHabitatsRemoveHabitatsBtn
            // 
            ManageHabitatsRemoveHabitatsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsRemoveHabitatsBtn, "ManageHabitatsRemoveHabitatsBtn");
            ManageHabitatsRemoveHabitatsBtn.Name = "ManageHabitatsRemoveHabitatsBtn";
            ManageHabitatsRemoveHabitatsBtn.Tag = "ManageHabitats";
            ManageHabitatsRemoveHabitatsBtn.UseVisualStyleBackColor = false;
            ManageHabitatsRemoveHabitatsBtn.Click += ManageHabitatsRemoveHabitatsBtn_Click;
            // 
            // ManageHabitatsAddHabitatsBtn
            // 
            ManageHabitatsAddHabitatsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageHabitatsAddHabitatsBtn, "ManageHabitatsAddHabitatsBtn");
            ManageHabitatsAddHabitatsBtn.Name = "ManageHabitatsAddHabitatsBtn";
            ManageHabitatsAddHabitatsBtn.Tag = "ManageHabitats";
            ManageHabitatsAddHabitatsBtn.UseVisualStyleBackColor = false;
            ManageHabitatsAddHabitatsBtn.Click += ManageHabitatsAddHabitatsBtn_Click;
            // 
            // ManageHabitatsHabitatsListBox
            // 
            ManageHabitatsHabitatsListBox.BackColor = Color.LightYellow;
            ManageHabitatsHabitatsListBox.DisplayMember = "ManageHabitats";
            resources.ApplyResources(ManageHabitatsHabitatsListBox, "ManageHabitatsHabitatsListBox");
            ManageHabitatsHabitatsListBox.FormattingEnabled = true;
            ManageHabitatsHabitatsListBox.Name = "ManageHabitatsHabitatsListBox";
            ManageHabitatsHabitatsListBox.Tag = "ManagePasswords";
            ManageHabitatsHabitatsListBox.ValueMember = "ManageHabitats";
            ManageHabitatsHabitatsListBox.SelectedIndexChanged += ManageHabitatsHabitatListBox_SelectedIndexChanged;
            // 
            // ManageHabitatsHabitatsPromptLbl
            // 
            resources.ApplyResources(ManageHabitatsHabitatsPromptLbl, "ManageHabitatsHabitatsPromptLbl");
            ManageHabitatsHabitatsPromptLbl.Name = "ManageHabitatsHabitatsPromptLbl";
            ManageHabitatsHabitatsPromptLbl.Tag = "ManageHabitats";
            // 
            // ManageHabitatsHabitatsTitleLbl
            // 
            resources.ApplyResources(ManageHabitatsHabitatsTitleLbl, "ManageHabitatsHabitatsTitleLbl");
            ManageHabitatsHabitatsTitleLbl.Name = "ManageHabitatsHabitatsTitleLbl";
            ManageHabitatsHabitatsTitleLbl.Tag = "ManageHabitats";
            // 
            // CreateNewAnimals
            // 
            CreateNewAnimals.Controls.Add(CreateNewAnimalsOutputLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsHungerLevelInput);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsHungerLevelLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsWeightInput);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsWeightLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsBackBtn);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsBtn);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsNameInput);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsNameLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsAgeInput);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsAgeLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsFoodTypeListBox);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsAnimalTypeListBox);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsFoodTypeLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsAnimalTypeLbl);
            CreateNewAnimals.Controls.Add(CreateNewAnimalsTitleLbl);
            resources.ApplyResources(CreateNewAnimals, "CreateNewAnimals");
            CreateNewAnimals.Name = "CreateNewAnimals";
            CreateNewAnimals.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsOutputLbl
            // 
            resources.ApplyResources(CreateNewAnimalsOutputLbl, "CreateNewAnimalsOutputLbl");
            CreateNewAnimalsOutputLbl.Name = "CreateNewAnimalsOutputLbl";
            CreateNewAnimalsOutputLbl.Tag = "CreateNewAnimal";
            // 
            // CreateNewAnimalsHungerLevelInput
            // 
            CreateNewAnimalsHungerLevelInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewAnimalsHungerLevelInput, "CreateNewAnimalsHungerLevelInput");
            CreateNewAnimalsHungerLevelInput.Name = "CreateNewAnimalsHungerLevelInput";
            CreateNewAnimalsHungerLevelInput.Tag = "CreateNewAnimals";
            CreateNewAnimalsHungerLevelInput.TextChanged += CreateNewAnimalsTextBox_TextChanged;
            // 
            // CreateNewAnimalsHungerLevelLbl
            // 
            resources.ApplyResources(CreateNewAnimalsHungerLevelLbl, "CreateNewAnimalsHungerLevelLbl");
            CreateNewAnimalsHungerLevelLbl.Name = "CreateNewAnimalsHungerLevelLbl";
            CreateNewAnimalsHungerLevelLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsWeightInput
            // 
            CreateNewAnimalsWeightInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewAnimalsWeightInput, "CreateNewAnimalsWeightInput");
            CreateNewAnimalsWeightInput.Name = "CreateNewAnimalsWeightInput";
            CreateNewAnimalsWeightInput.Tag = "CreateNewAnimals";
            CreateNewAnimalsWeightInput.TextChanged += CreateNewAnimalsTextBox_TextChanged;
            // 
            // CreateNewAnimalsWeightLbl
            // 
            resources.ApplyResources(CreateNewAnimalsWeightLbl, "CreateNewAnimalsWeightLbl");
            CreateNewAnimalsWeightLbl.Name = "CreateNewAnimalsWeightLbl";
            CreateNewAnimalsWeightLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsBackBtn
            // 
            CreateNewAnimalsBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewAnimalsBackBtn, "CreateNewAnimalsBackBtn");
            CreateNewAnimalsBackBtn.Name = "CreateNewAnimalsBackBtn";
            CreateNewAnimalsBackBtn.Tag = "CreateNewAnimals";
            CreateNewAnimalsBackBtn.UseVisualStyleBackColor = false;
            CreateNewAnimalsBackBtn.Click += CreateNewAnimalsBackBtn_Click;
            // 
            // CreateNewAnimalsBtn
            // 
            CreateNewAnimalsBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewAnimalsBtn, "CreateNewAnimalsBtn");
            CreateNewAnimalsBtn.Name = "CreateNewAnimalsBtn";
            CreateNewAnimalsBtn.Tag = "CreateNewAnimals";
            CreateNewAnimalsBtn.UseVisualStyleBackColor = false;
            CreateNewAnimalsBtn.Click += CreateNewAnimalsBtn_Click;
            // 
            // CreateNewAnimalsNameInput
            // 
            CreateNewAnimalsNameInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewAnimalsNameInput, "CreateNewAnimalsNameInput");
            CreateNewAnimalsNameInput.Name = "CreateNewAnimalsNameInput";
            CreateNewAnimalsNameInput.Tag = "CreateNewAnimals";
            CreateNewAnimalsNameInput.TextChanged += CreateNewAnimalsTextBox_TextChanged;
            // 
            // CreateNewAnimalsNameLbl
            // 
            resources.ApplyResources(CreateNewAnimalsNameLbl, "CreateNewAnimalsNameLbl");
            CreateNewAnimalsNameLbl.Name = "CreateNewAnimalsNameLbl";
            CreateNewAnimalsNameLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsAgeInput
            // 
            CreateNewAnimalsAgeInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewAnimalsAgeInput, "CreateNewAnimalsAgeInput");
            CreateNewAnimalsAgeInput.Name = "CreateNewAnimalsAgeInput";
            CreateNewAnimalsAgeInput.Tag = "CreateNewAnimals";
            CreateNewAnimalsAgeInput.TextChanged += CreateNewAnimalsTextBox_TextChanged;
            // 
            // CreateNewAnimalsAgeLbl
            // 
            resources.ApplyResources(CreateNewAnimalsAgeLbl, "CreateNewAnimalsAgeLbl");
            CreateNewAnimalsAgeLbl.Name = "CreateNewAnimalsAgeLbl";
            CreateNewAnimalsAgeLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsFoodTypeListBox
            // 
            CreateNewAnimalsFoodTypeListBox.BackColor = Color.LightYellow;
            CreateNewAnimalsFoodTypeListBox.DisplayMember = "CreateNewAnimals";
            resources.ApplyResources(CreateNewAnimalsFoodTypeListBox, "CreateNewAnimalsFoodTypeListBox");
            CreateNewAnimalsFoodTypeListBox.FormattingEnabled = true;
            CreateNewAnimalsFoodTypeListBox.Name = "CreateNewAnimalsFoodTypeListBox";
            CreateNewAnimalsFoodTypeListBox.SelectionMode = SelectionMode.MultiExtended;
            CreateNewAnimalsFoodTypeListBox.Tag = "CreateNewAnimals";
            CreateNewAnimalsFoodTypeListBox.ValueMember = "CreateNewAnimals";
            CreateNewAnimalsFoodTypeListBox.SelectedIndexChanged += CreateNewAnimalsListBox_SelectedIndexChanged;
            // 
            // CreateNewAnimalsAnimalTypeListBox
            // 
            CreateNewAnimalsAnimalTypeListBox.BackColor = Color.LightYellow;
            CreateNewAnimalsAnimalTypeListBox.DisplayMember = "CreateNewAnimals";
            resources.ApplyResources(CreateNewAnimalsAnimalTypeListBox, "CreateNewAnimalsAnimalTypeListBox");
            CreateNewAnimalsAnimalTypeListBox.FormattingEnabled = true;
            CreateNewAnimalsAnimalTypeListBox.Name = "CreateNewAnimalsAnimalTypeListBox";
            CreateNewAnimalsAnimalTypeListBox.Tag = "CreateNewAnimals";
            CreateNewAnimalsAnimalTypeListBox.ValueMember = "CreateNewAnimals";
            CreateNewAnimalsAnimalTypeListBox.SelectedIndexChanged += CreateNewAnimalsListBox_SelectedIndexChanged;
            // 
            // CreateNewAnimalsFoodTypeLbl
            // 
            resources.ApplyResources(CreateNewAnimalsFoodTypeLbl, "CreateNewAnimalsFoodTypeLbl");
            CreateNewAnimalsFoodTypeLbl.Name = "CreateNewAnimalsFoodTypeLbl";
            CreateNewAnimalsFoodTypeLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsAnimalTypeLbl
            // 
            resources.ApplyResources(CreateNewAnimalsAnimalTypeLbl, "CreateNewAnimalsAnimalTypeLbl");
            CreateNewAnimalsAnimalTypeLbl.Name = "CreateNewAnimalsAnimalTypeLbl";
            CreateNewAnimalsAnimalTypeLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewAnimalsTitleLbl
            // 
            resources.ApplyResources(CreateNewAnimalsTitleLbl, "CreateNewAnimalsTitleLbl");
            CreateNewAnimalsTitleLbl.Name = "CreateNewAnimalsTitleLbl";
            CreateNewAnimalsTitleLbl.Tag = "CreateNewAnimals";
            // 
            // CreateNewVisitors
            // 
            CreateNewVisitors.Controls.Add(CreateNewVisitorsOutputLbl);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsBackBtn);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsBtn);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsPhoneNumberInput);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsPhoneNumberLbl);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsEmailInput);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsEmailLbl);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsAgeInput);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsAgeLbl);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsNameInput);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsNameLbl);
            CreateNewVisitors.Controls.Add(CreateNewVisitorsTitleLbl);
            resources.ApplyResources(CreateNewVisitors, "CreateNewVisitors");
            CreateNewVisitors.Name = "CreateNewVisitors";
            CreateNewVisitors.Tag = "CreateNewVisitor";
            // 
            // CreateNewVisitorsOutputLbl
            // 
            resources.ApplyResources(CreateNewVisitorsOutputLbl, "CreateNewVisitorsOutputLbl");
            CreateNewVisitorsOutputLbl.Name = "CreateNewVisitorsOutputLbl";
            CreateNewVisitorsOutputLbl.Tag = "CreateNewVisitors";
            // 
            // CreateNewVisitorsBackBtn
            // 
            CreateNewVisitorsBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewVisitorsBackBtn, "CreateNewVisitorsBackBtn");
            CreateNewVisitorsBackBtn.Name = "CreateNewVisitorsBackBtn";
            CreateNewVisitorsBackBtn.Tag = "CreateNewVisitors";
            CreateNewVisitorsBackBtn.UseVisualStyleBackColor = false;
            CreateNewVisitorsBackBtn.Click += CreateNewVisitorsBackBtn_Click;
            // 
            // CreateNewVisitorsBtn
            // 
            CreateNewVisitorsBtn.BackColor = Color.Lime;
            resources.ApplyResources(CreateNewVisitorsBtn, "CreateNewVisitorsBtn");
            CreateNewVisitorsBtn.Name = "CreateNewVisitorsBtn";
            CreateNewVisitorsBtn.Tag = "CreateNewVisitors";
            CreateNewVisitorsBtn.UseVisualStyleBackColor = false;
            CreateNewVisitorsBtn.Click += CreateNewVisitorsBtn_Click;
            // 
            // CreateNewVisitorsPhoneNumberInput
            // 
            CreateNewVisitorsPhoneNumberInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewVisitorsPhoneNumberInput, "CreateNewVisitorsPhoneNumberInput");
            CreateNewVisitorsPhoneNumberInput.Name = "CreateNewVisitorsPhoneNumberInput";
            CreateNewVisitorsPhoneNumberInput.Tag = "CreateNewVisitors";
            CreateNewVisitorsPhoneNumberInput.TextChanged += CreateNewVisitorsInput_TextChanged;
            // 
            // CreateNewVisitorsPhoneNumberLbl
            // 
            resources.ApplyResources(CreateNewVisitorsPhoneNumberLbl, "CreateNewVisitorsPhoneNumberLbl");
            CreateNewVisitorsPhoneNumberLbl.Name = "CreateNewVisitorsPhoneNumberLbl";
            CreateNewVisitorsPhoneNumberLbl.Tag = "CreateNewVisitors";
            // 
            // CreateNewVisitorsEmailInput
            // 
            CreateNewVisitorsEmailInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewVisitorsEmailInput, "CreateNewVisitorsEmailInput");
            CreateNewVisitorsEmailInput.Name = "CreateNewVisitorsEmailInput";
            CreateNewVisitorsEmailInput.Tag = "CreateNewVisitors";
            CreateNewVisitorsEmailInput.TextChanged += CreateNewVisitorsInput_TextChanged;
            // 
            // CreateNewVisitorsEmailLbl
            // 
            resources.ApplyResources(CreateNewVisitorsEmailLbl, "CreateNewVisitorsEmailLbl");
            CreateNewVisitorsEmailLbl.Name = "CreateNewVisitorsEmailLbl";
            CreateNewVisitorsEmailLbl.Tag = "CreateNewVisitors";
            // 
            // CreateNewVisitorsAgeInput
            // 
            CreateNewVisitorsAgeInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewVisitorsAgeInput, "CreateNewVisitorsAgeInput");
            CreateNewVisitorsAgeInput.Name = "CreateNewVisitorsAgeInput";
            CreateNewVisitorsAgeInput.Tag = "CreateNewVisitors";
            CreateNewVisitorsAgeInput.TextChanged += CreateNewVisitorsInput_TextChanged;
            // 
            // CreateNewVisitorsAgeLbl
            // 
            resources.ApplyResources(CreateNewVisitorsAgeLbl, "CreateNewVisitorsAgeLbl");
            CreateNewVisitorsAgeLbl.Name = "CreateNewVisitorsAgeLbl";
            CreateNewVisitorsAgeLbl.Tag = "CreateNewVisitors";
            // 
            // CreateNewVisitorsNameInput
            // 
            CreateNewVisitorsNameInput.BackColor = Color.LightYellow;
            resources.ApplyResources(CreateNewVisitorsNameInput, "CreateNewVisitorsNameInput");
            CreateNewVisitorsNameInput.Name = "CreateNewVisitorsNameInput";
            CreateNewVisitorsNameInput.Tag = "CreateNewVisitors";
            CreateNewVisitorsNameInput.TextChanged += CreateNewVisitorsInput_TextChanged;
            // 
            // CreateNewVisitorsNameLbl
            // 
            resources.ApplyResources(CreateNewVisitorsNameLbl, "CreateNewVisitorsNameLbl");
            CreateNewVisitorsNameLbl.Name = "CreateNewVisitorsNameLbl";
            CreateNewVisitorsNameLbl.Tag = "CreateNewVisitors";
            // 
            // CreateNewVisitorsTitleLbl
            // 
            resources.ApplyResources(CreateNewVisitorsTitleLbl, "CreateNewVisitorsTitleLbl");
            CreateNewVisitorsTitleLbl.Name = "CreateNewVisitorsTitleLbl";
            CreateNewVisitorsTitleLbl.Tag = "CreateNewVisitors";
            // 
            // ManageVisitors
            // 
            ManageVisitors.Controls.Add(ManageVisitorsBackBtn);
            ManageVisitors.Controls.Add(ManageVisitorsRemoveVisitorsBtn);
            ManageVisitors.Controls.Add(ManageVisitorsAddVisitorsBtn);
            ManageVisitors.Controls.Add(ManageVisitorsListBox);
            ManageVisitors.Controls.Add(ManageVisitorsTitleLbl);
            resources.ApplyResources(ManageVisitors, "ManageVisitors");
            ManageVisitors.Name = "ManageVisitors";
            ManageVisitors.Tag = "ManageVisitors";
            // 
            // ManageVisitorsBackBtn
            // 
            ManageVisitorsBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageVisitorsBackBtn, "ManageVisitorsBackBtn");
            ManageVisitorsBackBtn.Name = "ManageVisitorsBackBtn";
            ManageVisitorsBackBtn.Tag = "ManageVisitors";
            ManageVisitorsBackBtn.UseVisualStyleBackColor = false;
            ManageVisitorsBackBtn.Click += ManageVisitorsBackBtn_Click;
            // 
            // ManageVisitorsRemoveVisitorsBtn
            // 
            ManageVisitorsRemoveVisitorsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageVisitorsRemoveVisitorsBtn, "ManageVisitorsRemoveVisitorsBtn");
            ManageVisitorsRemoveVisitorsBtn.Name = "ManageVisitorsRemoveVisitorsBtn";
            ManageVisitorsRemoveVisitorsBtn.Tag = "ManageVisitors";
            ManageVisitorsRemoveVisitorsBtn.UseVisualStyleBackColor = false;
            ManageVisitorsRemoveVisitorsBtn.Click += ManageVisitorsRemoveVisitorsBtn_Click;
            // 
            // ManageVisitorsAddVisitorsBtn
            // 
            ManageVisitorsAddVisitorsBtn.BackColor = Color.Lime;
            resources.ApplyResources(ManageVisitorsAddVisitorsBtn, "ManageVisitorsAddVisitorsBtn");
            ManageVisitorsAddVisitorsBtn.Name = "ManageVisitorsAddVisitorsBtn";
            ManageVisitorsAddVisitorsBtn.Tag = "ManageVisitors";
            ManageVisitorsAddVisitorsBtn.UseVisualStyleBackColor = false;
            ManageVisitorsAddVisitorsBtn.Click += ManageVisitorsAddVisitorsBtn_Click;
            // 
            // ManageVisitorsListBox
            // 
            ManageVisitorsListBox.BackColor = Color.LightYellow;
            ManageVisitorsListBox.DisplayMember = "ManageVisitors";
            resources.ApplyResources(ManageVisitorsListBox, "ManageVisitorsListBox");
            ManageVisitorsListBox.FormattingEnabled = true;
            ManageVisitorsListBox.Name = "ManageVisitorsListBox";
            ManageVisitorsListBox.Tag = "ManageVisitors";
            ManageVisitorsListBox.ValueMember = "ManageVisitors";
            // 
            // ManageVisitorsTitleLbl
            // 
            resources.ApplyResources(ManageVisitorsTitleLbl, "ManageVisitorsTitleLbl");
            ManageVisitorsTitleLbl.Name = "ManageVisitorsTitleLbl";
            ManageVisitorsTitleLbl.Tag = "ManageVisitors";
            // 
            // LoadService
            // 
            LoadService.Controls.Add(LoadServiceBackBtn);
            LoadService.Controls.Add(LoadServiceBtn);
            LoadService.Controls.Add(LoadServiceListBox);
            LoadService.Controls.Add(LoadServiceTitleLbl);
            resources.ApplyResources(LoadService, "LoadService");
            LoadService.Name = "LoadService";
            LoadService.Tag = "LoadService";
            // 
            // LoadServiceBackBtn
            // 
            LoadServiceBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(LoadServiceBackBtn, "LoadServiceBackBtn");
            LoadServiceBackBtn.Name = "LoadServiceBackBtn";
            LoadServiceBackBtn.Tag = "LoadService";
            LoadServiceBackBtn.UseVisualStyleBackColor = false;
            LoadServiceBackBtn.Click += LoadServiceBackBtn_Click;
            // 
            // LoadServiceBtn
            // 
            LoadServiceBtn.BackColor = Color.Lime;
            resources.ApplyResources(LoadServiceBtn, "LoadServiceBtn");
            LoadServiceBtn.Name = "LoadServiceBtn";
            LoadServiceBtn.Tag = "LoadService";
            LoadServiceBtn.UseVisualStyleBackColor = false;
            LoadServiceBtn.Click += LoadServiceBtn_Click;
            // 
            // LoadServiceListBox
            // 
            LoadServiceListBox.BackColor = Color.LightYellow;
            LoadServiceListBox.DisplayMember = "LoadService";
            resources.ApplyResources(LoadServiceListBox, "LoadServiceListBox");
            LoadServiceListBox.FormattingEnabled = true;
            LoadServiceListBox.Name = "LoadServiceListBox";
            LoadServiceListBox.Tag = "LoadService";
            LoadServiceListBox.ValueMember = "LoadService";
            // 
            // LoadServiceTitleLbl
            // 
            resources.ApplyResources(LoadServiceTitleLbl, "LoadServiceTitleLbl");
            LoadServiceTitleLbl.Name = "LoadServiceTitleLbl";
            LoadServiceTitleLbl.Tag = "LoadService";
            // 
            // EditAnimal
            // 
            EditAnimal.Controls.Add(EditAnimalFeedListBox);
            EditAnimal.Controls.Add(EditAnimalFeedAnimalLbl);
            EditAnimal.Controls.Add(EditAnimalGreetBtn);
            EditAnimal.Controls.Add(EditAnimalBackBtn);
            EditAnimal.Controls.Add(EditAnimalOutputLbl);
            EditAnimal.Controls.Add(EditAnimalTitleLbl);
            EditAnimal.Controls.Add(EditAnimalFeedBtn);
            EditAnimal.Controls.Add(EditAnimalWeightInput);
            EditAnimal.Controls.Add(EditAnimalWeightLbl);
            EditAnimal.Controls.Add(EditAnimalBtn);
            EditAnimal.Controls.Add(EditAnimalHungerLevelInput);
            EditAnimal.Controls.Add(EditAnimalHungerLevelLbl);
            EditAnimal.Controls.Add(EditAnimalAgeInput);
            EditAnimal.Controls.Add(EditAnimalAgeLbl);
            EditAnimal.Controls.Add(EditAnimalDietListBox);
            EditAnimal.Controls.Add(EditAnimalLbl);
            resources.ApplyResources(EditAnimal, "EditAnimal");
            EditAnimal.Name = "EditAnimal";
            EditAnimal.Tag = "EditAnimal";
            // 
            // EditAnimalFeedListBox
            // 
            EditAnimalFeedListBox.BackColor = Color.LightYellow;
            EditAnimalFeedListBox.DisplayMember = "EditAnimal";
            resources.ApplyResources(EditAnimalFeedListBox, "EditAnimalFeedListBox");
            EditAnimalFeedListBox.FormattingEnabled = true;
            EditAnimalFeedListBox.Name = "EditAnimalFeedListBox";
            EditAnimalFeedListBox.Tag = "EditAnimal";
            EditAnimalFeedListBox.ValueMember = "EditAnimal";
            EditAnimalFeedListBox.SelectedIndexChanged += EditAnimalFeedListBox_SelectedIndexChanged;
            // 
            // EditAnimalFeedAnimalLbl
            // 
            resources.ApplyResources(EditAnimalFeedAnimalLbl, "EditAnimalFeedAnimalLbl");
            EditAnimalFeedAnimalLbl.Name = "EditAnimalFeedAnimalLbl";
            EditAnimalFeedAnimalLbl.Tag = "EditAnimal";
            // 
            // EditAnimalGreetBtn
            // 
            EditAnimalGreetBtn.BackColor = Color.Lime;
            resources.ApplyResources(EditAnimalGreetBtn, "EditAnimalGreetBtn");
            EditAnimalGreetBtn.Name = "EditAnimalGreetBtn";
            EditAnimalGreetBtn.Tag = "EditAnimal";
            EditAnimalGreetBtn.UseVisualStyleBackColor = false;
            EditAnimalGreetBtn.Click += EditAnimalGreetBtn_Click;
            // 
            // EditAnimalBackBtn
            // 
            EditAnimalBackBtn.BackColor = Color.Lime;
            resources.ApplyResources(EditAnimalBackBtn, "EditAnimalBackBtn");
            EditAnimalBackBtn.Name = "EditAnimalBackBtn";
            EditAnimalBackBtn.Tag = "EditAnimal";
            EditAnimalBackBtn.UseVisualStyleBackColor = false;
            EditAnimalBackBtn.Click += EditAnimalBackBtn_Click;
            // 
            // EditAnimalOutputLbl
            // 
            resources.ApplyResources(EditAnimalOutputLbl, "EditAnimalOutputLbl");
            EditAnimalOutputLbl.Name = "EditAnimalOutputLbl";
            EditAnimalOutputLbl.Tag = "EditAnimal";
            // 
            // EditAnimalTitleLbl
            // 
            resources.ApplyResources(EditAnimalTitleLbl, "EditAnimalTitleLbl");
            EditAnimalTitleLbl.Name = "EditAnimalTitleLbl";
            // 
            // EditAnimalFeedBtn
            // 
            EditAnimalFeedBtn.BackColor = Color.Lime;
            resources.ApplyResources(EditAnimalFeedBtn, "EditAnimalFeedBtn");
            EditAnimalFeedBtn.Name = "EditAnimalFeedBtn";
            EditAnimalFeedBtn.Tag = "EditAnimal";
            EditAnimalFeedBtn.UseVisualStyleBackColor = false;
            EditAnimalFeedBtn.Click += EditAnimalFeedBtn_Click;
            // 
            // EditAnimalWeightInput
            // 
            EditAnimalWeightInput.BackColor = Color.LightYellow;
            resources.ApplyResources(EditAnimalWeightInput, "EditAnimalWeightInput");
            EditAnimalWeightInput.Name = "EditAnimalWeightInput";
            EditAnimalWeightInput.Tag = "EditAnimal";
            EditAnimalWeightInput.TextChanged += EditAnimalTextBox_TextChanged;
            // 
            // EditAnimalWeightLbl
            // 
            resources.ApplyResources(EditAnimalWeightLbl, "EditAnimalWeightLbl");
            EditAnimalWeightLbl.Name = "EditAnimalWeightLbl";
            EditAnimalWeightLbl.Tag = "EditAnimal";
            // 
            // EditAnimalBtn
            // 
            EditAnimalBtn.BackColor = Color.Lime;
            resources.ApplyResources(EditAnimalBtn, "EditAnimalBtn");
            EditAnimalBtn.Name = "EditAnimalBtn";
            EditAnimalBtn.Tag = "EditAnimal";
            EditAnimalBtn.UseVisualStyleBackColor = false;
            EditAnimalBtn.Click += EditAnimalBtn_Click;
            // 
            // EditAnimalHungerLevelInput
            // 
            EditAnimalHungerLevelInput.BackColor = Color.LightYellow;
            resources.ApplyResources(EditAnimalHungerLevelInput, "EditAnimalHungerLevelInput");
            EditAnimalHungerLevelInput.Name = "EditAnimalHungerLevelInput";
            EditAnimalHungerLevelInput.Tag = "EditAnimal";
            EditAnimalHungerLevelInput.TextChanged += EditAnimalTextBox_TextChanged;
            // 
            // EditAnimalHungerLevelLbl
            // 
            resources.ApplyResources(EditAnimalHungerLevelLbl, "EditAnimalHungerLevelLbl");
            EditAnimalHungerLevelLbl.Name = "EditAnimalHungerLevelLbl";
            EditAnimalHungerLevelLbl.Tag = "EditAnimal";
            // 
            // EditAnimalAgeInput
            // 
            EditAnimalAgeInput.BackColor = Color.LightYellow;
            resources.ApplyResources(EditAnimalAgeInput, "EditAnimalAgeInput");
            EditAnimalAgeInput.Name = "EditAnimalAgeInput";
            EditAnimalAgeInput.Tag = "EditAnimal";
            EditAnimalAgeInput.TextChanged += EditAnimalTextBox_TextChanged;
            // 
            // EditAnimalAgeLbl
            // 
            resources.ApplyResources(EditAnimalAgeLbl, "EditAnimalAgeLbl");
            EditAnimalAgeLbl.Name = "EditAnimalAgeLbl";
            EditAnimalAgeLbl.Tag = "EditAnimal";
            // 
            // EditAnimalDietListBox
            // 
            EditAnimalDietListBox.BackColor = Color.LightYellow;
            EditAnimalDietListBox.DisplayMember = "EditAnimal";
            resources.ApplyResources(EditAnimalDietListBox, "EditAnimalDietListBox");
            EditAnimalDietListBox.FormattingEnabled = true;
            EditAnimalDietListBox.Name = "EditAnimalDietListBox";
            EditAnimalDietListBox.SelectionMode = SelectionMode.MultiExtended;
            EditAnimalDietListBox.Tag = "EditAnimal";
            EditAnimalDietListBox.ValueMember = "EditAnimal";
            EditAnimalDietListBox.SelectedIndexChanged += EditAnimalDietListBox_SelectedIndexChanged;
            // 
            // EditAnimalLbl
            // 
            resources.ApplyResources(EditAnimalLbl, "EditAnimalLbl");
            EditAnimalLbl.Name = "EditAnimalLbl";
            EditAnimalLbl.Tag = "EditAnimal";
            // 
            // ZooManagementForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            Controls.Add(CreateNewVisitors);
            Controls.Add(ManageVisitors);
            Controls.Add(Dashboard);
            Controls.Add(EditAnimal);
            Controls.Add(ManagePasswords);
            Controls.Add(CreateNewAnimals);
            Controls.Add(Intro);
            Controls.Add(CreateNewService);
            Controls.Add(ManageHabitats);
            Controls.Add(LoadService);
            Controls.Add(Login);
            Name = "ZooManagementForm";
            Intro.ResumeLayout(false);
            CreateNewService.ResumeLayout(false);
            CreateNewService.PerformLayout();
            Dashboard.ResumeLayout(false);
            Login.ResumeLayout(false);
            Login.PerformLayout();
            ManagePasswords.ResumeLayout(false);
            ManageHabitats.ResumeLayout(false);
            CreateNewAnimals.ResumeLayout(false);
            CreateNewAnimals.PerformLayout();
            CreateNewVisitors.ResumeLayout(false);
            CreateNewVisitors.PerformLayout();
            ManageVisitors.ResumeLayout(false);
            LoadService.ResumeLayout(false);
            EditAnimal.ResumeLayout(false);
            EditAnimal.PerformLayout();
            ResumeLayout(false);
        }

        private void ShowPanel(PanelTag panelTag)
        {   
            if (activePanel is not null)
            {
                activePanel.Visible = false;
            }

            switch (panelTag)
            {
                case PanelTag.CreateNewAnimals:
                    this.AcceptButton = CreateNewAnimalsBtn; 
                    this.Size = new Size(1200, 785);
                    activePanel = panelMap[PanelTag.CreateNewAnimals];
                    break;
                case PanelTag.CreateNewService:
                    this.AcceptButton = CreateNewServiceBtn;
                    this.Size = new Size(600, 630);
                    activePanel = panelMap[PanelTag.CreateNewService];
                    break;
                case PanelTag.CreateNewVisitors:
                    this.AcceptButton = CreateNewVisitorsBtn;
                    this.Size = new Size(600, 490);
                    activePanel = panelMap[PanelTag.CreateNewVisitors]; 
                    break; 
                case PanelTag.Dashboard:
                    this.AcceptButton = null;
                    DashboardTitleLbl.Text = $"Welcome to {ZooManagementLib.ZooManagementService.ActiveInstanceName()}!";
                    this.Size = new Size(600, 580);
                    activePanel = panelMap[PanelTag.Dashboard];
                    break;
                case PanelTag.EditAnimal:
                    this.AcceptButton = EditAnimalBtn;
                    this.Size = new Size(1200, 745);
                    activePanel = panelMap[PanelTag.EditAnimal];
                    break;
                case PanelTag.Intro:
                    this.AcceptButton = null;
                    this.Size = new Size(600, 290);
                    activePanel = panelMap[PanelTag.Intro];
                    break;
                case PanelTag.LoadService:
                    this.AcceptButton = LoadServiceBtn;
                    this.Size = new Size(600, 540);
                    activePanel = panelMap[PanelTag.LoadService];
                    break;
                case PanelTag.Login:
                    this.AcceptButton = LoginBtn;
                    LoginTitleLbl.Text = $"Log in to {ZooManagementLib.ZooManagementService.ActiveInstanceName()}";
                    this.Size = new Size(600, 430);
                    activePanel = panelMap[PanelTag.Login];
                    break;
                case PanelTag.ManageHabitats:
                    this.AcceptButton = null;
                    this.Size = new Size(1200, 885);
                    activePanel = panelMap[PanelTag.ManageHabitats];
                    break;
                case PanelTag.ManagePasswords:
                    this.AcceptButton = null;
                    this.Size = new Size(600, 665);
                    activePanel = panelMap[PanelTag.ManagePasswords];
                    break;
                case PanelTag.ManageVisitors:
                    this.AcceptButton = null;
                    this.Size = new Size(600, 665);
                    activePanel = panelMap[PanelTag.ManageVisitors];
                    break; 
            }

            activePanel.BringToFront();
            activePanel.Visible = true;
        }

        private Panel Intro;
        private Label IntroTitleLbl;
        private Button IntroLoadServiceBtn;
        private Button IntroCreateNewServiceBtn;
        private Label CreateNewServicePasswordLbl;
        private Panel CreateNewService;
        private Label CreateNewServiceTitleLbl;
        private Label CreateNewServicePromptLbl;
        private TextBox CreateNewServiceNameInput;
        private Label CreateNewServiceNameLbl;
        private Label CreateNewServiceConfirmPasswordLbl;
        private TextBox CreateNewServicePasswordInput;
        private TextBox CreateNewServiceConfirmPasswordInput;
        private Button CreateNewServiceBtn;
        private Label CreateNewServiceOutputLbl;
        private Panel Dashboard;
        private Label DashboardPromptLbl;
        private Button DashboardManageHabitatsBtn;
        private Button DashboardLogOutBtn;
        private Button DashboardManagePasswordsBtn;
        private Panel Login;
        private Label LoginPasswordLbl;
        private Button LoginBtn;
        private Label LoginOutputLbl;
        private TextBox LoginPasswordInput;
        private Label DashboardTitleLbl;
        private Label LoginTitleLbl;
        private Panel ManagePasswords;
        private Label ManagePasswordsTitleLbl;
        private Button ManagePasswordsRemovePasscodesBtn;
        private Button ManagePasswordsAddPasscodesBtn;
        private ListBox ManagePasswordsListBox;
        private Button ManagePasswordsBackBtn;
        private Label ManagePasswordsPromptLbl;
        private Button LoginBackBtn;
        private Panel ManageHabitats;
        private ListBox ManageHabitatsHabitatsListBox;
        private Label ManageHabitatsHabitatsPromptLbl;
        private Label ManageHabitatsHabitatsTitleLbl;
        private Button ManageHabitatsRemoveHabitatsBtn;
        private Button ManageHabitatsAddHabitatsBtn;
        private Button DashboardExportServiceBtn;
        private Button DashboardManageVisitorsBtn;
        private Label ManageHabitatsAnimalsTitleLbl;
        private Button ManageHabitatsAddAnimalsBtn;
        private ListBox ManageHabitatsAnimalsListBox;
        private Label ManageHabitatsAnimalsPromptLbl;
        private Button ManageHabitatsRemoveAnimalsBtn;
        private Button ManageHabitatsFeedAllBtn;
        private Button ManageHabitatsAvgAgeBtn;
        private Label ManageHabitatsOutputLbl;
        private Button ManageHabitatsTotalWeightBtn;
        private Panel CreateNewAnimals;
        private Label CreateNewAnimalsTitleLbl;
        private Label CreateNewAnimalsAnimalTypeLbl;
        private Label CreateNewAnimalsAgeLbl;
        private ListBox CreateNewAnimalsFoodTypeListBox;
        private ListBox CreateNewAnimalsAnimalTypeListBox;
        private Label CreateNewAnimalsFoodTypeLbl;
        private Button CreateNewAnimalsBackBtn;
        private Button CreateNewAnimalsBtn;
        private TextBox CreateNewAnimalsNameInput;
        private Label CreateNewAnimalsNameLbl;
        private TextBox CreateNewAnimalsAgeInput;
        private Label CreateNewAnimalsOutputLbl;
        private Button CreateNewServiceBackBtn; 
        private Button ManageHabitatsBackBtn;
        private TextBox CreateNewAnimalsWeightInput;
        private Label CreateNewAnimalsWeightLbl;
        private TextBox CreateNewAnimalsHungerLevelInput;
        private Label CreateNewAnimalsHungerLevelLbl;
        private Button ManageHabitatsEditAnimalBtn;
        private Panel EditAnimal;
        private Label EditAnimalAgeLbl;
        private ListBox EditAnimalDietListBox;
        private Label EditAnimalLbl;
        private Button EditAnimalBtn;
        private TextBox EditAnimalWeightInput;
        private Label EditAnimalWeightLbl;
        private TextBox EditAnimalHungerLevelInput;
        private Label EditAnimalHungerLevelLbl;
        private TextBox EditAnimalAgeInput;
        private Button EditAnimalFeedBtn;
        private Label EditAnimalTitleLbl;
        private Label EditAnimalOutputLbl;
        private Button EditAnimalBackBtn;
        private Button EditAnimalGreetBtn;
        private Panel LoadService;
        private Label LoadServiceTitleLbl;
        private ListBox LoadServiceListBox;
        private Button LoadServiceBackBtn;
        private Button LoadServiceBtn;
        private Panel ManageVisitors;
        private Label EditAnimalFeedAnimalLbl;
        private ListBox EditAnimalFeedListBox;
        private Label ManageVisitorsTitleLbl;
        private Button ManageVisitorsBackBtn;
        private Button ManageVisitorsRemoveVisitorsBtn;
        private Button ManageVisitorsAddVisitorsBtn;
        private ListBox ManageVisitorsListBox;
        private Label CreateNewVisitorsTitleLbl;
        private Panel CreateNewVisitors;
        private Label CreateNewVisitorsNameLbl;
        private TextBox CreateNewVisitorsAgeInput;
        private Label CreateNewVisitorsAgeLbl;
        private TextBox CreateNewVisitorsEmailInput;
        private Label CreateNewVisitorsEmailLbl;
        private Button CreateNewVisitorsBackBtn;
        private Button CreateNewVisitorsBtn;
        private TextBox CreateNewVisitorsPhoneNumberInput;
        private Label CreateNewVisitorsPhoneNumberLbl;
        private Label CreateNewVisitorsOutputLbl;
        private TextBox CreateNewVisitorsNameInput;
    }
}