using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Text;


namespace HSTS_RecipeManager
{
    
    public partial class Form1 : Form, IRecipeMaker
    {
        SqlConnection SqlConn;
        SqlCommand SqlCmd;
        string ConnectionString = ConfigurationManager.ConnectionStrings["HSTS_RecipeManager.Properties.Settings.connString"].ConnectionString;
        string RecipeId = "";
        List<MyRecipe> Recipes = new List<MyRecipe>();
        List<MyRecipe> Results = new List<MyRecipe>();
        Step step;
        MyRecipe favRecipe = new MyRecipe();

        public Form1()
        {
            InitializeComponent();
            SetDefaultSearchOptions();
            SetDefaultCategoryOptions();
            SqlConn = new SqlConnection(ConnectionString);
            SqlConn.Open();
            step = new Step();
            
        }

        public class Step
        {
            public string Content { get; set; }
            public byte? Order { get; set; }

            public override string ToString()
            {
                return Content;
            }
        }
        public class Category
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void SetDefaultCategoryOptions()
        {
            cbCategory.Items.Add(new Category()
            {
                Name = "Mains",
                Value = "mains"
            });

            cbCategory.Items.Add(new Category()
            {
                Name = "Desserts",
                Value = "desserts"
            });

            cbCategory.Items.Add(new Category()
            {
                Name = "Snacks",
                Value = "snacks"
            });

            cbCategory.Items.Add(new Category()
            {
                Name = "Salads",
                Value = "salads"
            });

            cbCategory.Items.Add(new Category()
            {
                Name = "Soups",
                Value = "soups"
            });

            cbCategory.Items.Add(new Category()
            {
                Name = "Drinks",
                Value = "drinks"
            });
        }
        public class SearchOptions
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        
        private void SetDefaultSearchOptions()
        {
            
            cbFilter.Items.Add(new SearchOptions()
            {
                Value = "byKeywords",
                Name = "by Keywords"

            });

            cbFilter.Items.Add(new SearchOptions()
            {
                Value = "byCategory",
                Name = "by Category"

            });

            cbFilter.Items.Add(new SearchOptions()
            {
                Value = "byPrepTime",
                Name = "by Prep Time"

            });

        }


        private void Search()
        {
            string searchWord = txtSearch.Text;
            bool searchValid = false;
            if (cbFilter.SelectedItem is SearchOptions && !string.IsNullOrEmpty(searchWord))
            {
                searchValid = true;
                string searchOption = ((SearchOptions)cbFilter.SelectedItem).Value;
                switch (searchOption)
                {
                    case "byKeywords":
                        Dt.DefaultView.RowFilter = string.Format("Name = '{0}'", searchWord);
                        break;
                    case "byCategory":
                        Dt.DefaultView.RowFilter = string.Format("Category = '{0}'", searchWord);
                        break;
                    case "byPrepTime":
                        Dt.DefaultView.RowFilter = string.Format("Prep_Time = '{0}'", searchWord);
                        break;
                }

            }
            else if(!(cbFilter.SelectedItem is SearchOptions))
            {
                MessageBox.Show("error, Hints: please select a search filter ");

            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Search();
      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
            //dgvList.DataSource = FetchRecipes();
            dgvList.DataSource = Recipes.Where(x => x.Name == txtSearch.Text).ToList();

        }

        private DataTable FetchRecipes()
        {
            if (SqlConn.State == ConnectionState.Closed)
            {
                SqlConn.Open();
            }

            DataTable Dtdata = new DataTable();
            SqlCmd = new SqlCommand("spRecipe", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
            SqlDataAdapter Sqlda = new SqlDataAdapter(SqlCmd);
            Sqlda.Fill(Dtdata);
            return Dtdata;
        }

        private DataTable FetchRecipeRecords(string recipeId)
        {
            if(SqlConn.State == ConnectionState.Closed)
            {
                SqlConn.Open();
            }
            DataTable dtData = new DataTable();
            SqlCmd = new SqlCommand("spRecipe", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
            SqlCmd.Parameters.AddWithValue("@Recipe_Id", recipeId);
            SqlDataAdapter SqlSda = new SqlDataAdapter(SqlCmd);
            SqlSda.Fill(dtData);
            return dtData;
        }

        private BindingSource bindingSource1 = new BindingSource();
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                System.Windows.MessageBox.Show("Please enter name");
                txtName.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtNumServes.Text))
            {
                MessageBox.Show("Please enter number of serves");
                txtNumServes.Select();
            }
            else if (string.IsNullOrWhiteSpace(cbCategory.Text))
            {
                MessageBox.Show("Please enter Category");
                cbCategory.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtPrepTime.Text))
            {
                MessageBox.Show("Please enter prep time");
                txtPrepTime.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtIngredients.Text))
            {
                MessageBox.Show("Please enter ingredients");
                txtIngredients.Select();
            }
         
            else
            {
                try
                {
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();

                    }
                    Step newStep = new Step()
                    {
                        Content = lbSteps.Items.ToString()

                };
                   
                    List<Step> steps = new List<Step>();
                    steps.Add(newStep);
                    
                    DataTable dtdata = new DataTable();
                    SqlCmd = new SqlCommand("spRecipe", SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                    SqlCmd.Parameters.AddWithValue("@Recipe_Id", RecipeId);
                    SqlCmd.Parameters.AddWithValue("@Name", txtName.Text);
                    SqlCmd.Parameters.AddWithValue("@Num_Serves", txtNumServes.Text);
                    SqlCmd.Parameters.AddWithValue("@Category", cbCategory.Text);
                    SqlCmd.Parameters.AddWithValue("@Prep_Time", txtPrepTime.Text);
                    SqlCmd.Parameters.AddWithValue("@Ingredients", txtIngredients.Text);
                    SqlCmd.Parameters.AddWithValue("@Methods", lbSteps.Items[0].ToString());
                    bindingSource1.DataSource = dtdata;

                    int numRes = SqlCmd.ExecuteNonQuery();
                        if (numRes > 0)
                        {
                            MessageBox.Show("Recipe is saved successfully");
                            
                            ClearAllData();
                            btnSubmit.Text = "Save";
                        }
                        else
                        {
                            MessageBox.Show("Please try again");
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " +  ex.Message);
                }

            }
        }

       

        private void ClearAllData()
        {
            txtName.Text = "";
            txtNumServes.Text = "";
            //txtCategory.Text = "";
            cbCategory.Text = "";
            txtPrepTime.Text = "";
            txtIngredients.Text = "";
            txtMethods.Text = "";
            RecipeId = "";
            //lbSteps.Items.Clear();
            dgvList.DataSource = FetchRecipes();
            btnSubmit.Text = "Save";

        }

       
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                btnSubmit.Text = "Update";
                RecipeId = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                DataTable dtData = FetchRecipeRecords(RecipeId);
                if(dtData.Rows.Count > 0)
                {
                    RecipeId = dtData.Rows[0][0].ToString();
                    txtName.Text = dtData.Rows[0][1].ToString();
                    txtNumServes.Text = dtData.Rows[0][2].ToString();
                    cbCategory.Text = dtData.Rows[0][3].ToString();
                    txtPrepTime.Text = dtData.Rows[0][4].ToString();
                    txtIngredients.Text = dtData.Rows[0][5].ToString();
                    if (string.IsNullOrEmpty(lbSteps.Text))
                    {
                        lbSteps.Items.Clear();
                        lbSteps.Items.Add((string)dtData.Rows[0][6]);
                    }
                    
                   
                    
                    //lbSteps.Items.Add(dtData.Rows[0][6].ToString());
                    //txtMethods.Text = dtData.Rows[0][6].ToString();

                }
                else
                {
                    ClearAllData();
         

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RecipeId))
            {
                try
                {
                    if(SqlConn.State == ConnectionState.Closed)
                    {
                        SqlConn.Open();
                    }
                    SqlCmd = new SqlCommand("spRecipe",SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                    SqlCmd.Parameters.AddWithValue("@Recipe_Id", RecipeId);
                    int numRes = SqlCmd.ExecuteNonQuery();
                    if (numRes > 0)
                    {
                        MessageBox.Show("Recipe deleted successfully");
                        ClearAllData();
                    }
                    else
                    {
                        MessageBox.Show("Please try again");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error:-" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a record");
            }
        }

        //serialize favourite recipe to data stream
        private void chkbox_fav_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_fav.Checked)
            {
                serialize(favRecipe);
                ClearAllData();
                

            }
        }

        DataTable Dt;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Dt = FetchRecipes();
            dgvList.DataSource = Dt;

        }


        private void Refresh_Result()
        {
            if(Results == null)
            {
                Results = new List<MyRecipe>();
            }
            else
            {
                dgvList.DataSource = Results;
                CollectionViewSource.GetDefaultView(dgvList.DataSource).Refresh();
            }
        }

        private void Refresh_Result_method()
        {
            
            CollectionViewSource.GetDefaultView(lbSteps.DataSource).Refresh();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dgvList.DataSource = FetchRecipes();
            Search();
            
        }

        private void txtMethods_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewStep_Click(object sender, EventArgs e)
        {
            addMethodStep();
        }
        
        public void serialize(MyRecipe Ar)
        {
            
            Ar.Name = txtName.Text;
            //Ar.PrepTime = Int32.Parse(txtPrepTime.Text);
            Ar.Ingredients = txtIngredients.Text;
            Ar.Methods = lbSteps.Text;
            //Ar.Serving = Int32.Parse(txtNumServes.Text);
            Ar.Category = cbCategory.Text;

            //open a file and serialize objects into binary format
            Stream stream = File.Open("favourite_recipes.osl", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, Ar);
            stream.Close();
            MessageBox.Show("Recipe is added as favourite");
            chkbox_fav.Checked = false;

            //deserialize and load
            string Error;

            try
            {
                stream = File.Open("favourite_recipes.osl", FileMode.Open);
                bf = new BinaryFormatter();
                Ar = (MyRecipe)bf.Deserialize(stream);
                stream.Close();
                Console.WriteLine("name: {0}", Ar.Name);
                Console.WriteLine("prep time: {0}", Ar.PrepTime);
                Console.WriteLine("Ingredients: {0}", Ar.Ingredients);
                Console.WriteLine("Serving: {0}", Ar.Serving);
                Console.WriteLine("Methods: {0}", Ar.Methods);
                Console.WriteLine("Category: {0}", Ar.Category);
                //Add item to list view

                if (lvFavourite.Columns.Count< 1)
                {
                    lvFavourite.Columns.Add("Name", 100);
                    lvFavourite.Columns.Add("Ingredients", 100);
                    lvFavourite.Columns.Add("Steps", 100);
                    lvFavourite.Columns.Add("Category", 100);
                    lvFavourite.Items.Add(new System.Windows.Forms.ListViewItem(new string[] { txtName.Text, txtIngredients.Text, lbSteps.Text, cbCategory.Text }));
                }
                else
                {
                    lvFavourite.Items.Add(new System.Windows.Forms.ListViewItem(new string[] { txtName.Text, txtIngredients.Text, lbSteps.Text, cbCategory.Text }));
                }
                lvFavourite.View = View.Details;
                Controls.Add(lvFavourite);



            }
            catch (Exception exception)
            {
                Error = exception.ToString();

                // TODO: catch other exceptions
                Console.WriteLine(exception);
            }
        }
        public void deserializeAndLoad(MyRecipe Ar)
        {
            Stream FileStream;
            Ar = null;
            BinaryFormatter bf = new BinaryFormatter();
            string Error;

            try
            {
                FileStream = File.Open("favourite_recipes.osl", FileMode.Open);
                bf = new BinaryFormatter();
                Ar = (MyRecipe)bf.Deserialize(FileStream);
                FileStream.Close();
                Console.WriteLine("name: {0}", Ar.Name);
                Console.WriteLine("prep time: {0}", Ar.PrepTime);
                Console.WriteLine("Ingredients: {0}", Ar.Ingredients);
                Console.WriteLine("Serving: {0}", Ar.Serving);
                Console.WriteLine("Methods: {0}", Ar.Methods);
                Console.WriteLine("Category: {0}", Ar.Category);
                //Add item to list view
                System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem();
                lvi.SubItems.Add(Ar.Name);
                lvi.SubItems.Add(Ar.Ingredients);
                lvi.SubItems.Add(Ar.Category);
                lvi.SubItems.Add(Ar.Methods);
                lvFavourite.Items.Add(lvi);

            }
            catch (Exception exception)
            {
                Error = exception.ToString();

                // TODO: catch other exceptions
                Console.WriteLine(exception);
            }
            
        }

        public void clearMethodStep()
        {
            txtMethods.Text ="";
        }
        public void addMethodStep()
        {
            if (!string.IsNullOrEmpty(txtMethods.Text))
            {
                Step step = new Step()
                {
                    Content = txtMethods.Text,
                };
                lbSteps.Items.Add(step);
                clearMethodStep();
            }
            else
            {
                MessageBox.Show("Please fill in step");
            }
           
        }
        private void btnDeleteStep_Click(object sender, EventArgs e)
        {
            if (lbSteps.SelectedIndex != -1)
            {
                deleteMethodStep();
            }
            else
            {
                MessageBox.Show("Please select a step to delete");
            }
        }

        public void deleteMethodStep()
        {
            lbSteps.Items.RemoveAt(lbSteps.SelectedIndex);
        }

        public void reorderMethodStep(bool up)
        {
            //To move down steps
            if (!up)
            {
                lbSteps.BeginUpdate();
                int[] indexes = lbSteps.SelectedIndices.Cast<int>().ToArray();
                if (indexes.Length > 0 && indexes[indexes.Length - 1] < lbSteps.Items.Count - 1)
                {
                    for (int i = lbSteps.Items.Count - 1; i > -1; --i)
                    {
                        if (indexes.Contains(i))
                        {
                            object moveItem = lbSteps.Items[i];
                            lbSteps.Items.Remove(moveItem);
                            lbSteps.Items.Insert(i + 1, moveItem);
                            lbSteps.SetSelected(i + 1, true);
                        }
                    }
                }
                lbSteps.EndUpdate();
            }
            //To move up steps
            else
            {
                lbSteps.BeginUpdate();
                int[] indexes = lbSteps.SelectedIndices.Cast<int>().ToArray();
                if (indexes.Length > 0 && indexes[0] > 0)
                {
                    for (int i = 0; i < lbSteps.Items.Count; ++i)
                    {
                        if (indexes.Contains(i))
                        {
                            object moveItem = lbSteps.Items[i];
                            lbSteps.Items.Remove(moveItem);
                            lbSteps.Items.Insert(i - 1, moveItem);
                            lbSteps.SetSelected(i - 1, true);
                        }
                    }
                }
                lbSteps.EndUpdate();
            }
        }

        private void btnStepUp_Click(object sender, EventArgs e)
        {
            if(lbSteps.SelectedItem is Step)
            {
                reorderMethodStep(true);
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbSteps.SelectedItem is Step)
            {
                reorderMethodStep(false);
            }

        }


        private void lvFavourite_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lbSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSteps.Items.Clear();
        }
    }
}
