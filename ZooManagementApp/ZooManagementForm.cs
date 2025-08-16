//Quinn Keenan, 301504914, 08/08/2025

using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using ZooManagementLib;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZooManagementApp
{
    public partial class ZooManagementForm : Form
    { 
        private static string REMOVE_ALL_COMMAND = "REMOVE_ALL";
        public static string SELECTION_FAILURE_PROMPT = "Please make valid selections!";

        public ZooManagementForm()
        {
            InitializeComponent();
            panelMap = new Dictionary<PanelTag, Panel>();
            createPanelMap();
            ShowPanel(PanelTag.Intro);
        }

        private int[] AnimalsToIdArr(Animal[] animals)
        {
            int count;
            int[] resultInts = new int[animals.Length];

            for (count = 0; count < animals.Length; count++)
            {
                resultInts[count] = animals[count].Id;
            }

            return resultInts;
        }
        private string[] AnimalsToStringArr(Animal[] animals)
        {
            int count;
            string[] resultStrings = new string[animals.Length];

            for (count = 0; count < animals.Length; count++)
            {
                resultStrings[count] = animals[count].ToString();
            }

            return resultStrings;
        }

        private void ClearControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Text = null;
            }
        }

        private void ClearListBoxSelectedIndices(params ListBox[] listBoxes)
        {
            foreach (ListBox listBox in listBoxes)
            {
                listBox.SelectedItems.Clear();
            }
        }

        private void CreateNewAnimalsBackBtn_Click(object sender, EventArgs e)
        {
            ClearControls(CreateNewAnimalsAgeInput, CreateNewAnimalsNameInput, CreateNewAnimalsHungerLevelInput,
                        CreateNewAnimalsWeightInput);
            ClearListBoxSelectedIndices(CreateNewAnimalsAnimalTypeListBox, CreateNewAnimalsFoodTypeListBox);
            ShowPanel(PanelTag.ManageHabitats);
        }
        //Currently only creates a single animal at a time, for simplicity: 
        private void CreateNewAnimalsBtn_Click(object sender, EventArgs e)
        {
            int age;
            int animalTypeIndex;
            int count;
            int[] foodTypeIndices;
            FoodType[] diet;
            int habitatIndex;
            byte hungerLevel;
            string name; 
            string[] updatedAnimals;
            double weight;

            try
            {
                animalTypeIndex = DetermineSelectedListBoxIndices(CreateNewAnimalsAnimalTypeListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                foodTypeIndices = DetermineSelectedListBoxIndices(CreateNewAnimalsFoodTypeListBox);
                diet = new FoodType[foodTypeIndices.Length];
                name = ZooManagementService.ValidateNameOrPassword(CreateNewAnimalsNameInput.Text.Trim().ToUpper(), nameof(name));
                age = ZooManagementService.ValidateAge(Convert.ToInt32(CreateNewAnimalsAgeInput.Text.Trim()));
                hungerLevel = ZooManagementService.ValidateHungerLevel(Convert.ToInt32(CreateNewAnimalsHungerLevelInput.Text.Trim()));
                weight = ZooManagementService.ValidateWeight(Convert.ToDouble(CreateNewAnimalsWeightInput.Text.Trim()));

                if (foodTypeIndices.Length == 0)
                {
                    throw new InvalidSelectionException(nameof(CreateNewAnimalsFoodTypeListBox));
                }

                for (count = 0; count < foodTypeIndices.Length; count++)
                {
                    diet[count] = (FoodType)foodTypeIndices[count];
                }

                EmployeeInterface.AddAnimal(age, diet, hungerLevel, name, weight, animalTypeIndex, habitatIndex);
                ClearControls(CreateNewAnimalsAgeInput, CreateNewAnimalsNameInput, CreateNewAnimalsHungerLevelInput,
                         CreateNewAnimalsWeightInput);
                CreateNewAnimalsOutputLbl.Text = $"Animal \"{name}\" added.";
                updatedAnimals = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                FillListBoxes(null, null, habitatIndex, updatedAnimals, ManageHabitatsAnimalsListBox, -1);
            }
            catch (Exception exception) //Done to account for the plethora of possible-to-be-thrown exceptions 
            {                           //when a conversion fails. 
                CreateNewAnimalsOutputLbl.Text = exception.Message;
            }
        }
        private void CreateNewAnimalsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls(CreateNewAnimalsOutputLbl);
        }
        private void CreateNewAnimalsTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearControls(CreateNewAnimalsOutputLbl);
        }

        private void CreateNewServiceBackBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelTag.Intro);
        }
        private void CreateNewServiceBtn_Click(object sender, EventArgs e)
        {
            string confirmPassword;
            string name;
            string password;

            try
            {
                confirmPassword = ZooManagementService.ValidateNameOrPassword(CreateNewServiceConfirmPasswordInput.Text.Trim(), nameof(confirmPassword));
                name = ZooManagementService.ValidateNameOrPassword(CreateNewServiceNameInput.Text.Trim().ToUpper(), nameof(name));
                password = ZooManagementService.ValidateNameOrPassword(CreateNewServicePasswordInput.Text.Trim(), nameof(password)); 

                if (password != confirmPassword)
                {
                    throw new InvalidInputException(nameof(confirmPassword));
                }

                EmployeeInterface.ServiceCreationRequest(name, password);
                ShowPanel(PanelTag.Login);
                ClearControls(CreateNewServiceNameInput, CreateNewServicePasswordInput,
                         CreateNewServiceConfirmPasswordInput, CreateNewServiceOutputLbl);
            }
            catch (InvalidInputException iiException)
            {
                CreateNewServiceOutputLbl.Text = iiException.Message;
            }
            catch (ArgumentException argException)
            {
                CreateNewServiceOutputLbl.Text = argException.Message;
            }
        }
        private void CreateNewServiceInput_TextChanged(object sender, EventArgs e)
        {
            ClearControls(CreateNewServiceOutputLbl);
        }

        private void CreateNewVisitorsBackBtn_Click(object sender, EventArgs e)
        {
            ClearControls(CreateNewVisitorsAgeInput, CreateNewVisitorsNameInput, CreateNewVisitorsEmailInput, 
                          CreateNewVisitorsPhoneNumberInput, CreateNewVisitorsOutputLbl);
            ShowPanel(PanelTag.ManageVisitors);
        }
        private void CreateNewVisitorsBtn_Click(object sender, EventArgs e)
        {
            int age;  
            string email; 
            string name;
            string phoneNumber;
            string[] visitorStrings; 

            try
            {
                age = ZooManagementService.ValidateAge(Convert.ToInt32(CreateNewVisitorsAgeInput.Text.Trim()));
                name = ZooManagementService.ValidateNameOrPassword(CreateNewVisitorsNameInput.Text.Trim(), nameof(name));
                email = CreateNewVisitorsEmailInput.Text.Trim();
                phoneNumber = CreateNewVisitorsPhoneNumberInput.Text.Trim();

                if (!System.String.IsNullOrEmpty(email))
                {
                    email = ZooManagementService.ValidateEmail(email);
                }
                
                if (!System.String.IsNullOrEmpty(phoneNumber))
                {
                    phoneNumber = ZooManagementService.ValidatePhoneNumber(phoneNumber);
                }

                EmployeeInterface.AddVisitor(age, email, name, phoneNumber);
                visitorStrings = VisitorsToStringArr(EmployeeInterface.GetVisitors()); 
                FillListBoxes(visitorStrings, ManageVisitorsListBox, -1);
                ClearControls(CreateNewVisitorsAgeInput, CreateNewVisitorsNameInput, CreateNewVisitorsEmailInput, CreateNewVisitorsPhoneNumberInput);
                CreateNewVisitorsOutputLbl.Text = $"Visitor \"{name}\" added.";
            }
            catch (InvalidInputException iiException)
            {
                CreateNewVisitorsOutputLbl.Text = iiException.Message;
            }
            catch (ArgumentException argException)
            {
                CreateNewServiceOutputLbl.Text = argException.Message;
            }
        }
        private void CreateNewVisitorsInput_TextChanged(object sender, EventArgs e)
        {
            ClearControls(CreateNewVisitorsOutputLbl);
        }

        private void DashboardExportServiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeInterface.Export();
                MessageBox.Show($"Service \"{ZooManagementService.ActiveInstanceName()}\" exported successfully.", "Export Completed");
            }
            catch (JsonSerializationException jsException)
            {
                MessageBox.Show(jsException.Message, "Export Failed");
            }
        }
        private void DashboardManageHabitatsBtn_Click(object sender, EventArgs e)
        {
            int count;
            Habitat<Animal>[] habitats = EmployeeInterface.GetHabitats();
            string[] habitatStrings = new string[habitats.Length];

            for (count = 0; count < habitats.Length; count++)
            {
                habitatStrings[count] = habitats[count].Name;
            }

            FillListBoxes(habitatStrings, ManageHabitatsHabitatsListBox, -1, null, null, -1);
            ManageHabitatsAnimalsListBox.Items.Clear();
            ShowPanel(PanelTag.ManageHabitats);
        }
        private void DashboardManagePasswordsBtn_Click(object sender, EventArgs e)
        {
            FillListBoxes(EmployeeInterface.GetPasswords().ToArray(), ManagePasswordsListBox, -1, null, null, -1);
            ShowPanel(PanelTag.ManagePasswords);
        }
        private void DashboardManageVisitorsBtn_Click(object sender, EventArgs e)
        {
            string[] visitorStrings = VisitorsToStringArr(EmployeeInterface.GetVisitors());
            
            FillListBoxes(visitorStrings, ManageVisitorsListBox, -1, null, null, -1);
            ShowPanel(PanelTag.ManageVisitors);
        }
        private void DashboardLogOutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeInterface.Logout();
            }
            catch (InvalidLogoutException ilException)
            {
                MessageBox.Show(ilException.Message);
            }

            ShowPanel(PanelTag.Intro);
        }

        private int[] DetermineSelectedListBoxIndices(ListBox listBox)
        {
            int[] selectedIndices;

            switch (listBox.SelectionMode)
            {
                case SelectionMode.One:
                    if (listBox.SelectedIndex == -1)
                    {
                        throw new InvalidSelectionException(listBox.Name);
                    }

                    selectedIndices = new int[1];
                    selectedIndices[0] = listBox.SelectedIndex;
                    return selectedIndices;
                default:
                    selectedIndices = listBox.SelectedIndices.Cast<int>().ToArray();

                    if (selectedIndices.Length == 0)
                    {
                        throw new InvalidSelectionException(listBox.Name);
                    }

                    return selectedIndices;
            }
        }

        private void EditAnimalBackBtn_Click(object sender, EventArgs e)
        {
            int animalIndex;
            int habitatIndex;
            string[] updatedAnimals;

            try
            {
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                updatedAnimals = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));

                FillListBoxes(updatedAnimals, ManageHabitatsAnimalsListBox, animalIndex, null, null, -1);
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }

            ShowPanel(PanelTag.ManageHabitats);
        }
        private void EditAnimalBtn_Click(object sender, EventArgs e)
        {
            string ageString; 
            int animalIndex;
            string[] updatedAnimals;
            int count;
            FoodType[] diet;
            int[] foodTypesIndices; 
            int habitatIndex;
            string hungerLevelString; 
            string weightString; 

            try
            {
                foodTypesIndices = DetermineSelectedListBoxIndices(EditAnimalDietListBox);

                if (foodTypesIndices.Length == 0)
                {
                    throw new InvalidSelectionException(nameof(EditAnimalDietListBox));
                }

                ageString = EditAnimalAgeInput.Text.Trim();
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                hungerLevelString = EditAnimalHungerLevelInput.Text.Trim();
                weightString = EditAnimalWeightInput.Text.Trim();

                diet = new FoodType[foodTypesIndices.Length];
                for (count = 0; count < foodTypesIndices.Length; count++)
                {
                    diet[count] = (FoodType)foodTypesIndices[count];
                }

                EmployeeInterface.EditAnimal(ageString, diet, hungerLevelString, weightString, habitatIndex, animalIndex);
                ClearControls(EditAnimalAgeInput, EditAnimalHungerLevelInput, EditAnimalWeightInput);
                updatedAnimals = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                FillListBoxes(null, null, habitatIndex, updatedAnimals, ManageHabitatsAnimalsListBox, -1);
                ShowPanel(PanelTag.ManageHabitats);
            }
            catch (Exception exception)
            {
                EditAnimalOutputLbl.Text = exception.Message;
            }
        }
        private void EditAnimalDietListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int animalIndex;
            int count;
            int habitatIndex;
            FoodType[] selectedDietFoodTypes;
            string[] selectedDietFoodTypeStrings;
            int[] selectedDietIndices;
            string[] totalFoodTypeNames = Enum.GetNames(typeof(FoodType));

            try
            {
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                selectedDietIndices = DetermineSelectedListBoxIndices(EditAnimalDietListBox);
                selectedDietFoodTypes = new FoodType[selectedDietIndices.Length];
                selectedDietFoodTypeStrings = new string[selectedDietIndices.Length];

                for (count = 0; count < selectedDietIndices.Length; count++)
                {
                    selectedDietFoodTypes[count] = (FoodType)Enum.Parse(typeof(FoodType), totalFoodTypeNames[selectedDietIndices[count]]);
                }

                for (count = 0; count < selectedDietFoodTypes.Length; count++)
                {
                    selectedDietFoodTypeStrings[count] = selectedDietFoodTypes[count].ToString();
                }

                EmployeeInterface.EditAnimalDiet(animalIndex, habitatIndex, selectedDietFoodTypes);
                FillListBoxes(null, null, -1, selectedDietFoodTypeStrings, EditAnimalFeedListBox, -1);
            }
            catch (InvalidSelectionException isException)
            {
                EditAnimalOutputLbl.Text = isException.Message;
            }
            catch (ArgumentException argException)
            {
                EditAnimalOutputLbl.Text = argException.Message;
            }
        }
        private void EditAnimalFeedBtn_Click(object sender, EventArgs e)
        {
            int animalIndex;
            byte foodIndex;
            string[] animalStrings;
            int habitatIndex;

            try
            {
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                foodIndex = (byte)DetermineSelectedListBoxIndices(EditAnimalFeedListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                animalStrings = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                EditAnimalOutputLbl.Text = EmployeeInterface.FeedAnimal(animalIndex, foodIndex, habitatIndex);
                FillListBoxes(null, null, habitatIndex, animalStrings, ManageHabitatsAnimalsListBox, animalIndex);
            }
            catch (InvalidSelectionException isException)
            {
                EditAnimalOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
            catch (ArgumentException argException)
            {
                EditAnimalOutputLbl.Text = argException.Message;
            }
        }
        private void EditAnimalFeedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls(EditAnimalOutputLbl);
        }
        private void EditAnimalGreetBtn_Click(object sender, EventArgs e)
        {
            int animalIndex;
            int habitatIndex;

            try
            {
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                EditAnimalOutputLbl.Text = EmployeeInterface.GreetAnimal(habitatIndex, animalIndex);
            }
            catch (InvalidSelectionException isException)
            {
                EditAnimalOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
            catch (ArgumentException argException)
            {
                CreateNewServiceOutputLbl.Text = argException.Message;
            }
        }
        private void EditAnimalTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearControls(EditAnimalOutputLbl);
        }

        private void FillListBoxes(string[] primaryItems = null, ListBox primaryListBox = null, int primaryItemsSelectedIndex = -1,
                                 string[] secondaryItems = null, ListBox secondaryListBox = null, int secondaryItemsSelectedIndex = -1)
        {
            int count;

            if (primaryListBox is not null)
            {
                primaryListBox.Items.Clear();

                for (count = 0; count < primaryItems.Length; count++)
                {
                    primaryListBox.Items.Add(primaryItems[count]);
                }

                if (primaryItemsSelectedIndex >= 0 && primaryItemsSelectedIndex <= primaryListBox.Items.Count - 1)
                {
                    primaryListBox.SelectedIndex = primaryItemsSelectedIndex;
                }
            }

            if (secondaryListBox is not null)
            {
                secondaryListBox.Items.Clear();

                for (count = 0; count < secondaryItems.Length; count++)
                {
                    secondaryListBox.Items.Add(secondaryItems[count]);
                }

                if (secondaryItemsSelectedIndex >= 0 && secondaryItemsSelectedIndex <= secondaryListBox.Items.Count - 1)
                {
                    secondaryListBox.SelectedIndex = secondaryItemsSelectedIndex;
                }
            }
        }

        private string[] HabitatsToStringArr(params Habitat<Animal>[] habitats)
        {
            int count;
            string[] resultStrings = new string[habitats.Length];

            for (count = 0; count < habitats.Length; count++)
            {
                resultStrings[count] = habitats[count].Name;
            }

            return resultStrings;
        }

        private void IntroCreateNewServiceBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelTag.CreateNewService);
        }
        private void IntroLoadServiceBtn_Click(object sender, EventArgs e)
        {
            int count;
            string[] filePaths = Directory.GetFiles(ZooManagementLib.ZooManagementService.SERVICE_FILES_PATH);
            string[] serviceNames = new string[filePaths.Length];

            for (count = 0; count < filePaths.Length; count++)
            {
                serviceNames[count] = Path.GetFileNameWithoutExtension(filePaths[count]);
            }

            FillListBoxes(serviceNames, LoadServiceListBox, -1, null, null, -1);
            ClearListBoxSelectedIndices(LoadServiceListBox);
            ShowPanel(PanelTag.LoadService);
        }

        private void LoadServiceBackBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelTag.Intro);
        }
        private void LoadServiceBtn_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(ZooManagementService.SERVICE_FILES_PATH);
            byte selectedIndex;

            try
            {
                selectedIndex = (byte)DetermineSelectedListBoxIndices(LoadServiceListBox)[0];
                EmployeeInterface.Import(filePaths[selectedIndex]);
                ShowPanel(PanelTag.Login);
            }
            catch (JsonSerializationException jsException)
            {
                Debug.WriteLine((jsException.Message, "Import Failed"));
            }
        }

        private void LoginBackBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelTag.Intro);
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string password = ZooManagementService.ValidateNameOrPassword(LoginPasswordInput.Text.Trim(), nameof(password));
            bool success = false;

            try
            {
                success = EmployeeInterface.Login(password);
            }
            catch (InvalidInputException iiException)
            {
                LoginOutputLbl.Text = iiException.Message;
            }
            catch (InvalidLoginException ilException)
            {
                LoginOutputLbl.Text = ilException.Message;
                return;
            }
            catch (ArgumentException argException)
            {
                LoginOutputLbl.Text = argException.Message;
                return;
            }

            if (success)
                        
            {
                ShowPanel(PanelTag.Dashboard);
                ClearControls(LoginPasswordInput);
            }
            else
            {
                LoginOutputLbl.Text = "Incorrect password!";
            }
        }
        private void LoginPasswordInput_TextChanged(object sender, EventArgs e)
        {
            ClearControls(LoginOutputLbl);
        }

        private void ManageHabitatsAddAnimalsBtn_Click(object sender, EventArgs e)
        {
            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                int habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];

                FillListBoxes(Enum.GetNames(typeof(AnimalType)), CreateNewAnimalsAnimalTypeListBox, -1, Enum.GetNames
                            (typeof(FoodType)), CreateNewAnimalsFoodTypeListBox, -1);
                CreateNewAnimalsTitleLbl.Text = $"Create new Animal for {EmployeeInterface.GetHabitatName(habitatIndex)}";
                ShowPanel(PanelTag.CreateNewAnimals);
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }
        private void ManageHabitatsAddHabitatsBtn_Click(object sender, EventArgs e)
        {
            int count; 
            string userInput = Interaction.InputBox("Enter as many habitat names into this window as you would like " +
                                                    "to add. Seperate them with commas.");
            string[] inputStrings = ParseInputBoxInput(userInput.ToUpper());
            string[] habitatStrings = HabitatsToStringArr(EmployeeInterface.GetHabitats());
            string[] parsedInputStrings = new string[inputStrings.Length];

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                for (count = 0; count < inputStrings.Length; count++)
                {
                    if (habitatStrings.Contains(parsedInputStrings[count])) 
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }

                    parsedInputStrings[count] = ZooManagementService.ValidateNameOrPassword(inputStrings[count], nameof(inputStrings));
                }

                EmployeeInterface.AddHabitats(parsedInputStrings);
                habitatStrings = HabitatsToStringArr(EmployeeInterface.GetHabitats());
                FillListBoxes(habitatStrings, ManageHabitatsHabitatsListBox, -1, null, null, -1);
            }
            catch (InvalidInputException iiException)
            {
                MessageBox.Show(iiException.Message);
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }
        private void ManageHabitatsAnimalsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls(ManageHabitatsOutputLbl);
        }
        private void ManageHabitatsAvgAgeBtn_Click(object sender, EventArgs e)
        {
            int habitatIndex;

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                ManageHabitatsOutputLbl.Text = $"The average age of the occupants of {EmployeeInterface.
                                                GetHabitatName(habitatIndex)} is {EmployeeInterface.GetHabitatAvgAge(habitatIndex):N2} years.";
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }
        private void ManageHabitatsBackBtn_Click(object sender, EventArgs e)
        {
            ClearControls(ManageHabitatsOutputLbl);
            ShowPanel(PanelTag.Dashboard);
        }
        private void ManageHabitatsEditAnimalBtn_Click(object sender, EventArgs e)
        {
            Animal animal;
            int animalIndex;
            int habitatIndex;

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                animalIndex = DetermineSelectedListBoxIndices(ManageHabitatsAnimalsListBox)[0];
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                animal = EmployeeInterface.GetAnimal(habitatIndex, animalIndex);

                FillListBoxes(Enum.GetNames(typeof(FoodType)), EditAnimalDietListBox, -1);
                SetListBoxSelectedIndices(animal.DietToIntArr(), EditAnimalDietListBox);
                EditAnimalTitleLbl.Text = $"Edit {animal.Name}";
                ShowPanel(PanelTag.EditAnimal);
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }
        private void ManageHabitatsFeedAllBtn_Click(object sender, EventArgs e)
        {
            string[] animalStrings;
            int habitatIndex;

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                EmployeeInterface.FeedAll(habitatIndex);
                animalStrings = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                FillListBoxes(null, null, habitatIndex, animalStrings, ManageHabitatsAnimalsListBox, -1);
                ManageHabitatsOutputLbl.Text = $"You fed all the animals in {EmployeeInterface.GetHabitatName(habitatIndex)}.";
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }
        private void ManageHabitatsHabitatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int habitatIndex;
            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                string[] animalStrings = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                FillListBoxes(null, null, habitatIndex, animalStrings, ManageHabitatsAnimalsListBox, -1);
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }
        private void ManageHabitatsRemoveAnimalsBtn_Click(object sender, EventArgs e)
        {
            int[] animalIDs;
            string[] animalStrings;
            int count;
            int habitatIndex;
            string[] inputStrings;
            int[] inputIDs;
            string userInput;

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                animalIDs = AnimalsToIdArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                inputStrings = new string[animalIDs.Length];
                inputIDs = new int[animalIDs.Length];

                userInput = Interaction.InputBox("Enter as many animal IDs into this window as you would like to remove. Seperate them " +
                                                 $"with commas. Enter \"{REMOVE_ALL_COMMAND}\" to remove all of the animals.");
                inputStrings = ParseInputBoxInput(userInput.ToUpper());

                for (count = 0; count < inputStrings.Length; count++)
                {
                    if (inputStrings[count] == REMOVE_ALL_COMMAND)
                    {
                        inputIDs = animalIDs;
                        break;
                    }
                    else if (!animalIDs.Contains(Convert.ToInt32(inputStrings[count])))
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }

                    inputIDs[count] = Convert.ToInt32(inputStrings[count]);
                }

                EmployeeInterface.RemoveAnimals(habitatIndex, inputIDs);
                animalStrings = AnimalsToStringArr(EmployeeInterface.GetHabitatAnimals(habitatIndex));
                FillListBoxes(null, null, habitatIndex, animalStrings, ManageHabitatsAnimalsListBox, -1);
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
            catch (Exception exception)
            {
                ManageHabitatsOutputLbl.Text = exception.Message;
            }
        }
        private void ManageHabitatsRemoveHabitatsBtn_Click(object sender, EventArgs e)
        {
            int count; 
            string userInput = Interaction.InputBox("Enter as many habitat names into this window as you would like to remove. Seperate " +
                                                    $"them with commas. Enter \"{REMOVE_ALL_COMMAND}\" to remove all of the habitats.");
            string[] habitatStrings = HabitatsToStringArr(EmployeeInterface.GetHabitats());
            string[] inputStrings = ParseInputBoxInput(userInput.ToUpper());
            string[] parsedInputStrings = new string[inputStrings.Length]; 

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                for (count = 0; count <  inputStrings.Length; count++) 
                {
                    if (inputStrings[count] == REMOVE_ALL_COMMAND)
                    {
                        parsedInputStrings = habitatStrings;
                        break;
                    }
                    else if (!habitatStrings.Contains(inputStrings[count]))
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }

                    parsedInputStrings[count] = ZooManagementService.ValidateNameOrPassword(inputStrings[count], nameof(inputStrings));
                }

                ClearControls(ManageHabitatsOutputLbl, ManageHabitatsAnimalsListBox);
                EmployeeInterface.RemoveHabitats(parsedInputStrings);
                habitatStrings = HabitatsToStringArr(EmployeeInterface.GetHabitats());
                FillListBoxes(habitatStrings, ManageHabitatsHabitatsListBox, -1, null, null, -1);
                ManageHabitatsAnimalsListBox.Items.Clear();
            }
            catch (InvalidInputException ilException)
            {
                MessageBox.Show(ilException.Message);
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }
        private void ManageHabitatsTotalWeightBtn_Click(object sender, EventArgs e)
        {
            int habitatIndex;

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                habitatIndex = DetermineSelectedListBoxIndices(ManageHabitatsHabitatsListBox)[0];
                ManageHabitatsOutputLbl.Text = $"The total weight of the occupants of {EmployeeInterface.GetHabitatName
                                               (habitatIndex)} is {EmployeeInterface.GetHabitatTotalWeight(habitatIndex):N2} kg.";
            }
            catch (InvalidSelectionException isException)
            {
                ManageHabitatsOutputLbl.Text = SELECTION_FAILURE_PROMPT;
            }
        }

        private void ManagePasswordsAddPasswordsBtn_Click(object sender, EventArgs e)
        {
            int count; 
            string userInput = Interaction.InputBox("Enter as many 6+ character passwords into this window as you would like to add. " +
                                                    "Seperate them with commas.");
            string[] inputStrings = ParseInputBoxInput(userInput);
            string[] passwords = EmployeeInterface.GetPasswords().ToArray();
            string[] parsedInputStrings = new string[inputStrings.Length];

            ClearControls(ManageHabitatsOutputLbl);

            try
            {
                for (count = 0; count < inputStrings.Length; count++) 
                {
                    if (passwords.Contains(inputStrings[count]))
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }
                    
                    parsedInputStrings[count] = ZooManagementService.ValidateNameOrPassword(inputStrings[count], nameof(inputStrings));
                }

                EmployeeInterface.AddPasswords(parsedInputStrings);
                FillListBoxes(EmployeeInterface.GetPasswords().ToArray(), ManagePasswordsListBox, -1, null, null, -1);
            }
            catch (InvalidInputException ilException)
            {
                MessageBox.Show(ilException.Message);
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }
        private void ManagePasswordsBackBtn_Click(object sender, EventArgs e)
        {
            ClearControls(ManageHabitatsOutputLbl);
            ShowPanel(PanelTag.Dashboard);
        }
        private void ManagePasswordsRemovePasswordsBtn_Click(object sender, EventArgs e)
        {
            int count; 
            string userInput = Interaction.InputBox("Enter as many 6-digit passwords into this window as you would " +
                                                    $"like to remove. Seperate them with commas. Enter \"{REMOVE_ALL_COMMAND}\" to " +
                                                    "remove all of the passwords.");
            string[] inputStrings = ParseInputBoxInput(userInput.ToUpper());
            string[] passwords = EmployeeInterface.GetPasswords().ToArray();
            string[] parsedInputStrings = new string[inputStrings.Length];

            try
            {
                for (count = 0; count <  inputStrings.Length; count++) 
                {
                    if (inputStrings[count] == REMOVE_ALL_COMMAND)
                    {
                        parsedInputStrings = passwords;
                        break;
                    }
                    else if (!passwords.Contains(inputStrings[count]))
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }

                    parsedInputStrings[count] = ZooManagementService.ValidateNameOrPassword(inputStrings[count], nameof(inputStrings));
                }

                EmployeeInterface.RemovePasswords(parsedInputStrings);
                FillListBoxes(EmployeeInterface.GetPasswords().ToArray(), ManagePasswordsListBox, -1, null, null, -1);
            }
            catch (InvalidInputException ilException)
            {
                MessageBox.Show(ilException.Message);
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private void ManageVisitorsAddVisitorsBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelTag.CreateNewVisitors);
        }
        private void ManageVisitorsBackBtn_Click(object sender, EventArgs e)
        {
            ClearListBoxSelectedIndices(ManageVisitorsListBox);
            ShowPanel(PanelTag.Dashboard);
        }
        private void ManageVisitorsRemoveVisitorsBtn_Click(object sender, EventArgs e)
        {
            int count;  
            string userInput = Interaction.InputBox("Enter as many visitor IDs into this window as you would like to remove. Seperate " +
                                                    $"them with commas. Enter \"{REMOVE_ALL_COMMAND}\" to remove all of the visitors.");
            string[] inputStrings = ParseInputBoxInput(userInput.ToUpper());
            int[] removeableIds = new int[inputStrings.Length];
            Visitor[] visitors = EmployeeInterface.GetVisitors();
            int[] visitorIds = new int[visitors.Length];
            string[] updatedVisitorStrings;

            try
            {
                for (count = 0; count <  visitors.Length; count++)
                {
                    visitorIds[count] = visitors[count].Id; 
                }

                for (count = 0; count < inputStrings.Length; count++)
                {
                    if (inputStrings[count] == REMOVE_ALL_COMMAND)
                    {
                        removeableIds = visitorIds;
                        break; 
                    }
                    else if (!visitorIds.Contains(Convert.ToInt32(inputStrings[count])))
                    {
                        throw new InvalidInputException(nameof(inputStrings));
                    }

                    removeableIds[count] = Convert.ToInt32(inputStrings[count]);
                }

                EmployeeInterface.RemoveVisitors(removeableIds);
                updatedVisitorStrings = VisitorsToStringArr(EmployeeInterface.GetVisitors());
                FillListBoxes(updatedVisitorStrings, ManageVisitorsListBox, -1, null, null, -1);
            }
            catch (InvalidInputException ilException)
            {
                MessageBox.Show(ilException.Message);
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private string[] ParseInputBoxInput(string inputStr)
        {
            int count;
            const char DELIMITER = ',';
            string[] items = inputStr.Split(DELIMITER);

            for (count = 0; count < items.Length; count++)
            {
                items[count] = items[count].Trim();
            }

            return items;
        }

        private void SetListBoxSelectedIndices(int[] indices, ListBox listBox)
        {
            int count;

            for (count = 0; count < listBox.Items.Count; count++)
            {
                listBox.SetSelected(count, indices.Contains(count));
            }
        }

        private string[] VisitorsToStringArr(Visitor[] visitors)
        {
            int count; 
            string[] resultStrings = new string[visitors.Length];

            for (count = 0; count <  visitors.Length; count++)
            {
                resultStrings[count] = visitors[count].ToString();
            }

            return resultStrings; 
        }
    }
}